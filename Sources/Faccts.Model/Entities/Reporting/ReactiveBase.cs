using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Faccts.Model.Annotations;
using ReactiveUI;

namespace Faccts.Model.Entities.Reporting
{
    public abstract class ReactiveBase : IReactiveNotifyPropertyChanged
    {
        private readonly MakeObjectReactiveHelper _reactiveHelper;

        protected ReactiveBase()
        {
            _reactiveHelper = new MakeObjectReactiveHelper(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        public IDisposable SuppressChangeNotifications()
        {
            return _reactiveHelper.SuppressChangeNotifications();
        }

        public IObservable<IObservedChange<object, object>> Changing
        {
            get { return _reactiveHelper.Changing; }
        }

        public IObservable<IObservedChange<object, object>> Changed
        {
            get { return _reactiveHelper.Changed; }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}