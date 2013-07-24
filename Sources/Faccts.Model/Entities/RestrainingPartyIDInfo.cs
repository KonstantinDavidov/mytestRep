//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using ReactiveUI;
using System.Reactive.Linq;

namespace Faccts.Model.Entities
{
    public partial class RestrainingPartyIDInfo : INotifyComplexPropertyChanging, IReactiveNotifyPropertyChanged
    {
    
    	private MakeObjectReactiveHelper _reactiveHelper;
    	public RestrainingPartyIDInfo()
    	{
    		_reactiveHelper = new MakeObjectReactiveHelper(this);
    		Initialize();
    		Observable.Merge<Object>(
    				this.ObservableForProperty(x => x.IDType)
    				,this.ObservableForProperty(x => x.IDNumber)
    				,this.ObservableForProperty(x => x.IDIssuedDate)
    			).
    			Subscribe(_ =>
    			{
    				IsDirty = true;
    			}
    			);
    	}
    
    	partial void Initialize();
    	
    	private bool _isDirty;
    	public bool IsDirty
    	{
    		get
    		{
    			return _isDirty;
    		}
    		set
    		{
    			if (_isDirty == value)
    				return;
    			OnPropertyChanging("IsDirty");
    			_isDirty = value;
    			OnPropertyChanged("IsDirty");
    		}
    	}
    
    	public IObservable<IObservedChange<object, object>> Changed 
    	{
    		get { return _reactiveHelper.Changed; }
    	}
    	public IObservable<IObservedChange<object, object>> Changing 
    	{
    		get { return _reactiveHelper.Changing; }
    	}
    	public IDisposable SuppressChangeNotifications() 
    	{
    		return _reactiveHelper.SuppressChangeNotifications();
    	}
    
    	private PropertyChangingEventHandler _propertyChanging;
    	public event PropertyChangingEventHandler PropertyChanging
    	{
    		add { _propertyChanging += value; }
    		remove {_propertyChanging -= value; }
    	}
        #region Simple Properties
    
        [DataMember]
        public FACCTS.Server.Model.Enums.IdentificationIDType IDType
        {
            get { return _iDType; }
            set
            {
                if (_iDType != value)
                {
                    OnComplexPropertyChanging();
    				OnPropertyChanging("IDType");
                    _iDType = value;
                    OnPropertyChanged("IDType");
                }
            }
        }
        private FACCTS.Server.Model.Enums.IdentificationIDType _iDType;
    
        [DataMember]
        public string IDNumber
        {
            get { return _iDNumber; }
            set
            {
                if (_iDNumber != value)
                {
                    OnComplexPropertyChanging();
    				OnPropertyChanging("IDNumber");
                    _iDNumber = value;
                    OnPropertyChanged("IDNumber");
                }
            }
        }
        private string _iDNumber;
    
        [DataMember]
        public Nullable<System.DateTime> IDIssuedDate
        {
            get { return _iDIssuedDate; }
            set
            {
                if (_iDIssuedDate != value)
                {
                    OnComplexPropertyChanging();
    				OnPropertyChanging("IDIssuedDate");
                    _iDIssuedDate = value;
                    OnPropertyChanged("IDIssuedDate");
                }
            }
        }
        private Nullable<System.DateTime> _iDIssuedDate;

        #endregion

        #region ChangeTracking
    
        private void OnComplexPropertyChanging()
        {
            if (_complexPropertyChanging != null)
            {
                _complexPropertyChanging(this, new EventArgs());
            }
        }
    
        event EventHandler INotifyComplexPropertyChanging.ComplexPropertyChanging { add { _complexPropertyChanging += value; } remove { _complexPropertyChanging -= value; } }
        private event EventHandler _complexPropertyChanging;
    
        private void OnPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
    	private void OnPropertyChanging(String propertyName)
        {
            if (_propertyChanging != null)
            {
                _propertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged { add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
    
        public static void RecordComplexOriginalValues(String parentPropertyName, RestrainingPartyIDInfo complexObject, ObjectChangeTracker changeTracker)
        {
            if (String.IsNullOrEmpty(parentPropertyName))
            {
                throw new ArgumentException("String parameter cannot be null or empty.", "parentPropertyName");
            }
    
            if (changeTracker == null)
            {
                throw new ArgumentNullException("changeTracker");
            }
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.IDType", parentPropertyName), complexObject == null ? null : (object)complexObject.IDType);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.IDNumber", parentPropertyName), complexObject == null ? null : (object)complexObject.IDNumber);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.IDIssuedDate", parentPropertyName), complexObject == null ? null : (object)complexObject.IDIssuedDate);
        }

        #endregion

    }
}
