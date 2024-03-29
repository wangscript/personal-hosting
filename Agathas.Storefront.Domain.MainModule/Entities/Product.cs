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
using System.Runtime.Serialization;
using Agathas.Storefront.Domain.Entities;

namespace Agathas.Storefront.Domain.MainModule.Entities
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(ProductTitle))]
    [KnownType(typeof(Size))]
    public partial class Product: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int ProductId
        {
            get { return _productId; }
            set
            {
                if (_productId != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'ProductId' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _productId = value;
                    OnPropertyChanged("ProductId");
                }
            }
        }
        private int _productId;

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public ProductTitle ProductTitle
        {
            get { return _productTitle; }
            set
            {
                if (!ReferenceEquals(_productTitle, value))
                {
                    var previousValue = _productTitle;
                    _productTitle = value;
                    FixupProductTitle(previousValue);
                    OnNavigationPropertyChanged("ProductTitle");
                }
            }
        }
        private ProductTitle _productTitle;
    
        [DataMember]
        public Size Size
        {
            get { return _size; }
            set
            {
                if (!ReferenceEquals(_size, value))
                {
                    var previousValue = _size;
                    _size = value;
                    FixupSize(previousValue);
                    OnNavigationPropertyChanged("Size");
                }
            }
        }
        private Size _size;

        #endregion
        #region ChangeTracking
    
        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        protected virtual void OnNavigationPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged{ add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
        private ObjectChangeTracker _changeTracker;
    
        [DataMember]
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
                return _changeTracker;
            }
            set
            {
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging -= HandleObjectStateChanging;
                }
                _changeTracker = value;
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
            }
        }
    
        private void HandleObjectStateChanging(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                ClearNavigationProperties();
            }
        }
    
        protected bool IsDeserializing { get; private set; }
    
        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext context)
        {
            IsDeserializing = true;
        }
    
        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            IsDeserializing = false;
            ChangeTracker.ChangeTrackingEnabled = true;
        }
    
        protected virtual void ClearNavigationProperties()
        {
            ProductTitle = null;
            FixupProductTitleKeys();
            Size = null;
            FixupSizeKeys();
        }

        #endregion
        #region Association Fixup
    
        private void FixupProductTitle(ProductTitle previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Products.Contains(this))
            {
                previousValue.Products.Remove(this);
            }
    
            if (ProductTitle != null)
            {
                if (!ProductTitle.Products.Contains(this))
                {
                    ProductTitle.Products.Add(this);
                }
    
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("ProductTitle")
                    && (ChangeTracker.OriginalValues["ProductTitle"] == ProductTitle))
                {
                    ChangeTracker.OriginalValues.Remove("ProductTitle");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("ProductTitle", previousValue);
                }
                if (ProductTitle != null && !ProductTitle.ChangeTracker.ChangeTrackingEnabled)
                {
                    ProductTitle.StartTracking();
                }
                FixupProductTitleKeys();
            }
        }
    
        private void FixupProductTitleKeys()
        {
            const string ProductTitleIdKeyName = "ProductTitle.ProductTitleId";
    
            if(ChangeTracker.ExtendedProperties.ContainsKey(ProductTitleIdKeyName))
            {
                if(ProductTitle == null ||
                   !Equals(ChangeTracker.ExtendedProperties[ProductTitleIdKeyName], ProductTitle.ProductTitleId))
                {
                    ChangeTracker.RecordOriginalValue(ProductTitleIdKeyName, ChangeTracker.ExtendedProperties[ProductTitleIdKeyName]);
                }
                ChangeTracker.ExtendedProperties.Remove(ProductTitleIdKeyName);
            }
        }
    
        private void FixupSize(Size previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Products.Contains(this))
            {
                previousValue.Products.Remove(this);
            }
    
            if (Size != null)
            {
                if (!Size.Products.Contains(this))
                {
                    Size.Products.Add(this);
                }
    
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Size")
                    && (ChangeTracker.OriginalValues["Size"] == Size))
                {
                    ChangeTracker.OriginalValues.Remove("Size");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Size", previousValue);
                }
                if (Size != null && !Size.ChangeTracker.ChangeTrackingEnabled)
                {
                    Size.StartTracking();
                }
                FixupSizeKeys();
            }
        }
    
        private void FixupSizeKeys()
        {
            const string SizeIdKeyName = "Size.SizeId";
    
            if(ChangeTracker.ExtendedProperties.ContainsKey(SizeIdKeyName))
            {
                if(Size == null ||
                   !Equals(ChangeTracker.ExtendedProperties[SizeIdKeyName], Size.SizeId))
                {
                    ChangeTracker.RecordOriginalValue(SizeIdKeyName, ChangeTracker.ExtendedProperties[SizeIdKeyName]);
                }
                ChangeTracker.ExtendedProperties.Remove(SizeIdKeyName);
            }
        }

        #endregion
    }
}
