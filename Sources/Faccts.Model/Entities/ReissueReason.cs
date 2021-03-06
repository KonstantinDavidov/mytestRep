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
using System.Reflection;

namespace Faccts.Model.Entities
{
    public partial class ReissueReason : INotifyComplexPropertyChanging, IReactiveNotifyPropertyChanged
    {
    
    	private MakeObjectReactiveHelper _reactiveHelper;
    	public ReissueReason()
    	{
    		_reactiveHelper = new MakeObjectReactiveHelper(this);
    		Initialize();
    		Observable.Merge<Object>(
    				this.ObservableForProperty(x => x.NoPOS)
    				,this.ObservableForProperty(x => x.FCSReferral)
    				,this.ObservableForProperty(x => x.GetAttyToPrepare)
    				,this.ObservableForProperty(x => x.IsOtherReason)
    				,this.ObservableForProperty(x => x.OtherReasonDescription)
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
        public bool NoPOS
        {
            get { return _noPOS; }
            set
            {
                if (_noPOS != value)
                {
                    OnComplexPropertyChanging();
    				OnPropertyChanging("NoPOS");
                    _noPOS = value;
                    OnPropertyChanged("NoPOS");
                }
            }
        }
        private bool _noPOS;
    
        [DataMember]
        public bool FCSReferral
        {
            get { return _fCSReferral; }
            set
            {
                if (_fCSReferral != value)
                {
                    OnComplexPropertyChanging();
    				OnPropertyChanging("FCSReferral");
                    _fCSReferral = value;
                    OnPropertyChanged("FCSReferral");
                }
            }
        }
        private bool _fCSReferral;
    
        [DataMember]
        public bool GetAttyToPrepare
        {
            get { return _getAttyToPrepare; }
            set
            {
                if (_getAttyToPrepare != value)
                {
                    OnComplexPropertyChanging();
    				OnPropertyChanging("GetAttyToPrepare");
                    _getAttyToPrepare = value;
                    OnPropertyChanged("GetAttyToPrepare");
                }
            }
        }
        private bool _getAttyToPrepare;
    
        [DataMember]
        public bool IsOtherReason
        {
            get { return _isOtherReason; }
            set
            {
                if (_isOtherReason != value)
                {
                    OnComplexPropertyChanging();
    				OnPropertyChanging("IsOtherReason");
                    _isOtherReason = value;
                    OnPropertyChanged("IsOtherReason");
                }
            }
        }
        private bool _isOtherReason;
    
        [DataMember]
        public string OtherReasonDescription
        {
            get { return _otherReasonDescription; }
            set
            {
                if (_otherReasonDescription != value)
                {
                    OnComplexPropertyChanging();
    				OnPropertyChanging("OtherReasonDescription");
                    _otherReasonDescription = value;
                    OnPropertyChanged("OtherReasonDescription");
                }
            }
        }
        private string _otherReasonDescription;

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
    
        public static void RecordComplexOriginalValues(String parentPropertyName, ReissueReason complexObject, ObjectChangeTracker changeTracker)
        {
            if (String.IsNullOrEmpty(parentPropertyName))
            {
                throw new ArgumentException("String parameter cannot be null or empty.", "parentPropertyName");
            }
    
            if (changeTracker == null)
            {
                throw new ArgumentNullException("changeTracker");
            }
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.NoPOS", parentPropertyName), complexObject == null ? null : (object)complexObject.NoPOS);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.FCSReferral", parentPropertyName), complexObject == null ? null : (object)complexObject.FCSReferral);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.GetAttyToPrepare", parentPropertyName), complexObject == null ? null : (object)complexObject.GetAttyToPrepare);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.IsOtherReason", parentPropertyName), complexObject == null ? null : (object)complexObject.IsOtherReason);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.OtherReasonDescription", parentPropertyName), complexObject == null ? null : (object)complexObject.OtherReasonDescription);
        }

        #endregion

    }
}
