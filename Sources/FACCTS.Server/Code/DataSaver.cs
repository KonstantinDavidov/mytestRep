using FACCTS.Server.DataContracts;
using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using log4net;
using FACCTS.Server.Data.Repositiries;
using System.Linq.Expressions;

namespace FACCTS.Server.Code
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DataSaver : IDisposable
    {
        [ImportingConstructor]
        public DataSaver(IDataManager dataManager, ILog logger)
        {
            DataManager = dataManager;
            Logger = logger;
        }


        public IDataManager DataManager { get; set; }

        public ILog Logger { private get; set; }
        //[Import]
        //public IRepositoryProvider RepositoryProvider { private get; set; }

        public CourtCase SaveData(CourtCase cc)
        {
            Logger.Info("DataSaver: trying to save the Court Case...");
            if (cc.State == ObjectState.Unchanged)
            {
                Logger.Info("The Court Case was not modified");
                return cc;
            }
                
            try
            {
                DataManager.CourtCaseRepository.SaveData(cc);
                //DataManager.CourtPartyRepository.SaveData(cc.Party1);
                //DataManager.CourtPartyRepository.SaveData(cc.Party2);
                //DataManager.CourtPartyAttorneyDataRepository.SaveData(cc.Party1.AttorneyData);
                //DataManager.AttorneyRepository.SaveData(cc.Party1.AttorneyData.Attorney);
                //DataManager.CourtPartyAttorneyDataRepository.SaveData(cc.Party2.AttorneyData);
                //DataManager.AttorneyRepository.SaveData(cc.Party2.AttorneyData.Attorney);
                //DataManager.CaseHistoryRepository.SaveData(cc.CaseHistory);
                //DataManager.HearingRepository.SaveData(cc.CaseHistory.Select(x => x.Hearing));
                //DataManager.CaseNoteRepository.SaveData(cc.CaseNotes);
                //DataManager.WitnessRepository.SaveData(cc.Witnesses);
                //DataManager.InterpreterRepository.SaveData(cc.Interpreters);
                //DataManager.ChildrenRepository.SaveData(cc.Children);
                DataManager.Commit();
            }
            catch (Exception ex)
            {
                Logger.Error("An error while saving the Court Case: ", ex);
                throw;
            }
            
            return null;
        }

        //protected virtual void SaveDataInclude<TEntity>(TEntity entity, params Expression<Func<TEntity, object>>[] includes)
        //    where TEntity: BaseEntity
        //{
        //    RepositoryProvider.GetRepositoryForEntityType<TEntity>().SaveData(entity);
        //    includes.Aggregate(0, (index, current) =>
        //        {
        //            Type repoType = GetObjectType(current);
        //            var repository = RepositoryProvider.GetRepositoryForEntityType(repoType);

        //            return ++index;
        //        }

        //        );
        //}

        private static Type GetObjectType<T>(Expression<Func<T, object>> expr)
        {
            if ((expr.Body.NodeType == ExpressionType.Convert) ||
                (expr.Body.NodeType == ExpressionType.ConvertChecked))
            {
                var unary = expr.Body as UnaryExpression;
                if (unary != null)
                    return unary.Operand.Type;
            }
            return expr.Body.Type;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~DataSaver()
        {
            Dispose(false);
        }

        private bool _wasDisposed = false;
        protected virtual void Dispose(bool isDisposing)
        {
            if (_wasDisposed)
                return;

            if (isDisposing)
            {
                DataManager.Dispose();
                DataManager = null;
            }
            Logger = null;
            _wasDisposed = true;
        }
    }
}