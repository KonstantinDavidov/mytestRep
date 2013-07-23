using FACCTS.Services.DataRepository.Core.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FACCTS.Services.DataRepository.Core
{
    public static class UnitOfWork
    {
        private static IUnitOfWorkFactory _unitOfWorkFactory;
        private static readonly Hashtable _threads = new Hashtable();

        public static void Commit()
        {
            IUnitOfWork unitOfWork = GetUnitOfWork();

            if (unitOfWork != null)
            {
                unitOfWork.Commit();
            }
        }

        public static IUnitOfWork Current
        {
            get
            {
                IUnitOfWork unitOfWork = GetUnitOfWork();

                if (unitOfWork == null)
                {
                    _unitOfWorkFactory = MefServiceLocator.Instance.GetInstance<IUnitOfWorkFactory>();
                    unitOfWork = _unitOfWorkFactory.Create();
                    SaveUnitOfWork(unitOfWork);
                }

                return unitOfWork;
            }
        }

        private static IUnitOfWork GetUnitOfWork()
        {
                Thread thread = Thread.CurrentThread;
                if (string.IsNullOrEmpty(thread.Name))
                {
                    thread.Name = Guid.NewGuid().ToString();
                    return null;
                }
                else
                {
                    lock (_threads.SyncRoot)
                    {
                        return (IUnitOfWork)_threads[Thread.CurrentThread.Name];
                    }
                }
        }

        private static void SaveUnitOfWork(IUnitOfWork unitOfWork)
        {
                lock (_threads.SyncRoot)
                {
                    _threads[Thread.CurrentThread.Name] = unitOfWork;
                }
        }
    }
}
