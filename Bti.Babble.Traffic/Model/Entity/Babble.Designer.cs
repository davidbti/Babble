﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("Babble", "TrafficLogTrafficEvent", "TrafficLog", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(Bti.Babble.Traffic.Model.Entity.TrafficLog), "TrafficEvent", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Bti.Babble.Traffic.Model.Entity.TrafficEvent), true)]
[assembly: EdmRelationshipAttribute("Babble", "TrafficItemTrafficEvent", "TrafficItem", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(Bti.Babble.Traffic.Model.Entity.TrafficItem), "TrafficEvent", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Bti.Babble.Traffic.Model.Entity.TrafficEvent), true)]
[assembly: EdmRelationshipAttribute("Babble", "TrafficItemBabbleItem", "TrafficItem", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(Bti.Babble.Traffic.Model.Entity.TrafficItem), "BabbleItem", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Bti.Babble.Traffic.Model.Entity.BabbleItem), true)]

#endregion

namespace Bti.Babble.Traffic.Model.Entity
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class BabbleContainer : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new BabbleContainer object using the connection string found in the 'BabbleContainer' section of the application configuration file.
        /// </summary>
        public BabbleContainer() : base("name=BabbleContainer", "BabbleContainer")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new BabbleContainer object.
        /// </summary>
        public BabbleContainer(string connectionString) : base(connectionString, "BabbleContainer")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new BabbleContainer object.
        /// </summary>
        public BabbleContainer(EntityConnection connection) : base(connection, "BabbleContainer")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<TrafficLog> TrafficLogs
        {
            get
            {
                if ((_TrafficLogs == null))
                {
                    _TrafficLogs = base.CreateObjectSet<TrafficLog>("TrafficLogs");
                }
                return _TrafficLogs;
            }
        }
        private ObjectSet<TrafficLog> _TrafficLogs;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<TrafficEvent> TrafficEvents
        {
            get
            {
                if ((_TrafficEvents == null))
                {
                    _TrafficEvents = base.CreateObjectSet<TrafficEvent>("TrafficEvents");
                }
                return _TrafficEvents;
            }
        }
        private ObjectSet<TrafficEvent> _TrafficEvents;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<BabbleItem> BabbleItems
        {
            get
            {
                if ((_BabbleItems == null))
                {
                    _BabbleItems = base.CreateObjectSet<BabbleItem>("BabbleItems");
                }
                return _BabbleItems;
            }
        }
        private ObjectSet<BabbleItem> _BabbleItems;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<TrafficItem> TrafficItems
        {
            get
            {
                if ((_TrafficItems == null))
                {
                    _TrafficItems = base.CreateObjectSet<TrafficItem>("TrafficItems");
                }
                return _TrafficItems;
            }
        }
        private ObjectSet<TrafficItem> _TrafficItems;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the TrafficLogs EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToTrafficLogs(TrafficLog trafficLog)
        {
            base.AddObject("TrafficLogs", trafficLog);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the TrafficEvents EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToTrafficEvents(TrafficEvent trafficEvent)
        {
            base.AddObject("TrafficEvents", trafficEvent);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the BabbleItems EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToBabbleItems(BabbleItem babbleItem)
        {
            base.AddObject("BabbleItems", babbleItem);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the TrafficItems EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToTrafficItems(TrafficItem trafficItem)
        {
            base.AddObject("TrafficItems", trafficItem);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Babble", Name="BabbleItem")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class BabbleItem : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new BabbleItem object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="body">Initial value of the Body property.</param>
        /// <param name="type">Initial value of the Type property.</param>
        /// <param name="link">Initial value of the Link property.</param>
        /// <param name="trafficItemId">Initial value of the TrafficItemId property.</param>
        public static BabbleItem CreateBabbleItem(global::System.Int32 id, global::System.String body, global::System.Int32 type, global::System.String link, global::System.Int32 trafficItemId)
        {
            BabbleItem babbleItem = new BabbleItem();
            babbleItem.Id = id;
            babbleItem.Body = body;
            babbleItem.Type = type;
            babbleItem.Link = link;
            babbleItem.TrafficItemId = trafficItemId;
            return babbleItem;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Body
        {
            get
            {
                return _Body;
            }
            set
            {
                OnBodyChanging(value);
                ReportPropertyChanging("Body");
                _Body = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Body");
                OnBodyChanged();
            }
        }
        private global::System.String _Body;
        partial void OnBodyChanging(global::System.String value);
        partial void OnBodyChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Type
        {
            get
            {
                return _Type;
            }
            set
            {
                OnTypeChanging(value);
                ReportPropertyChanging("Type");
                _Type = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Type");
                OnTypeChanged();
            }
        }
        private global::System.Int32 _Type;
        partial void OnTypeChanging(global::System.Int32 value);
        partial void OnTypeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Link
        {
            get
            {
                return _Link;
            }
            set
            {
                OnLinkChanging(value);
                ReportPropertyChanging("Link");
                _Link = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Link");
                OnLinkChanged();
            }
        }
        private global::System.String _Link;
        partial void OnLinkChanging(global::System.String value);
        partial void OnLinkChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 TrafficItemId
        {
            get
            {
                return _TrafficItemId;
            }
            set
            {
                OnTrafficItemIdChanging(value);
                ReportPropertyChanging("TrafficItemId");
                _TrafficItemId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("TrafficItemId");
                OnTrafficItemIdChanged();
            }
        }
        private global::System.Int32 _TrafficItemId;
        partial void OnTrafficItemIdChanging(global::System.Int32 value);
        partial void OnTrafficItemIdChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("Babble", "TrafficItemBabbleItem", "TrafficItem")]
        public TrafficItem TrafficItem
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<TrafficItem>("Babble.TrafficItemBabbleItem", "TrafficItem").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<TrafficItem>("Babble.TrafficItemBabbleItem", "TrafficItem").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<TrafficItem> TrafficItemReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<TrafficItem>("Babble.TrafficItemBabbleItem", "TrafficItem");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<TrafficItem>("Babble.TrafficItemBabbleItem", "TrafficItem", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Babble", Name="TrafficEvent")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class TrafficEvent : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new TrafficEvent object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="time">Initial value of the Time property.</param>
        /// <param name="length">Initial value of the Length property.</param>
        /// <param name="trafficLogId">Initial value of the TrafficLogId property.</param>
        /// <param name="trafficItemId">Initial value of the TrafficItemId property.</param>
        public static TrafficEvent CreateTrafficEvent(global::System.Int32 id, global::System.String time, global::System.String length, global::System.Int32 trafficLogId, global::System.Int32 trafficItemId)
        {
            TrafficEvent trafficEvent = new TrafficEvent();
            trafficEvent.Id = id;
            trafficEvent.Time = time;
            trafficEvent.Length = length;
            trafficEvent.TrafficLogId = trafficLogId;
            trafficEvent.TrafficItemId = trafficItemId;
            return trafficEvent;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Time
        {
            get
            {
                return _Time;
            }
            set
            {
                OnTimeChanging(value);
                ReportPropertyChanging("Time");
                _Time = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Time");
                OnTimeChanged();
            }
        }
        private global::System.String _Time;
        partial void OnTimeChanging(global::System.String value);
        partial void OnTimeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Length
        {
            get
            {
                return _Length;
            }
            set
            {
                OnLengthChanging(value);
                ReportPropertyChanging("Length");
                _Length = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Length");
                OnLengthChanged();
            }
        }
        private global::System.String _Length;
        partial void OnLengthChanging(global::System.String value);
        partial void OnLengthChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 TrafficLogId
        {
            get
            {
                return _TrafficLogId;
            }
            set
            {
                OnTrafficLogIdChanging(value);
                ReportPropertyChanging("TrafficLogId");
                _TrafficLogId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("TrafficLogId");
                OnTrafficLogIdChanged();
            }
        }
        private global::System.Int32 _TrafficLogId;
        partial void OnTrafficLogIdChanging(global::System.Int32 value);
        partial void OnTrafficLogIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 TrafficItemId
        {
            get
            {
                return _TrafficItemId;
            }
            set
            {
                OnTrafficItemIdChanging(value);
                ReportPropertyChanging("TrafficItemId");
                _TrafficItemId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("TrafficItemId");
                OnTrafficItemIdChanged();
            }
        }
        private global::System.Int32 _TrafficItemId;
        partial void OnTrafficItemIdChanging(global::System.Int32 value);
        partial void OnTrafficItemIdChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("Babble", "TrafficLogTrafficEvent", "TrafficLog")]
        public TrafficLog TrafficLog
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<TrafficLog>("Babble.TrafficLogTrafficEvent", "TrafficLog").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<TrafficLog>("Babble.TrafficLogTrafficEvent", "TrafficLog").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<TrafficLog> TrafficLogReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<TrafficLog>("Babble.TrafficLogTrafficEvent", "TrafficLog");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<TrafficLog>("Babble.TrafficLogTrafficEvent", "TrafficLog", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("Babble", "TrafficItemTrafficEvent", "TrafficItem")]
        public TrafficItem TrafficItem
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<TrafficItem>("Babble.TrafficItemTrafficEvent", "TrafficItem").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<TrafficItem>("Babble.TrafficItemTrafficEvent", "TrafficItem").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<TrafficItem> TrafficItemReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<TrafficItem>("Babble.TrafficItemTrafficEvent", "TrafficItem");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<TrafficItem>("Babble.TrafficItemTrafficEvent", "TrafficItem", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Babble", Name="TrafficItem")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class TrafficItem : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new TrafficItem object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="type">Initial value of the Type property.</param>
        /// <param name="description">Initial value of the Description property.</param>
        /// <param name="iSCI">Initial value of the ISCI property.</param>
        /// <param name="barcode">Initial value of the Barcode property.</param>
        public static TrafficItem CreateTrafficItem(global::System.Int32 id, global::System.Int32 type, global::System.String description, global::System.String iSCI, global::System.String barcode)
        {
            TrafficItem trafficItem = new TrafficItem();
            trafficItem.Id = id;
            trafficItem.Type = type;
            trafficItem.Description = description;
            trafficItem.ISCI = iSCI;
            trafficItem.Barcode = barcode;
            return trafficItem;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Type
        {
            get
            {
                return _Type;
            }
            set
            {
                OnTypeChanging(value);
                ReportPropertyChanging("Type");
                _Type = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Type");
                OnTypeChanged();
            }
        }
        private global::System.Int32 _Type;
        partial void OnTypeChanging(global::System.Int32 value);
        partial void OnTypeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                OnDescriptionChanging(value);
                ReportPropertyChanging("Description");
                _Description = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Description");
                OnDescriptionChanged();
            }
        }
        private global::System.String _Description;
        partial void OnDescriptionChanging(global::System.String value);
        partial void OnDescriptionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String ISCI
        {
            get
            {
                return _ISCI;
            }
            set
            {
                OnISCIChanging(value);
                ReportPropertyChanging("ISCI");
                _ISCI = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("ISCI");
                OnISCIChanged();
            }
        }
        private global::System.String _ISCI;
        partial void OnISCIChanging(global::System.String value);
        partial void OnISCIChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Barcode
        {
            get
            {
                return _Barcode;
            }
            set
            {
                OnBarcodeChanging(value);
                ReportPropertyChanging("Barcode");
                _Barcode = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Barcode");
                OnBarcodeChanged();
            }
        }
        private global::System.String _Barcode;
        partial void OnBarcodeChanging(global::System.String value);
        partial void OnBarcodeChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("Babble", "TrafficItemTrafficEvent", "TrafficEvent")]
        public EntityCollection<TrafficEvent> TrafficEvents
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<TrafficEvent>("Babble.TrafficItemTrafficEvent", "TrafficEvent");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<TrafficEvent>("Babble.TrafficItemTrafficEvent", "TrafficEvent", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("Babble", "TrafficItemBabbleItem", "BabbleItem")]
        public EntityCollection<BabbleItem> BabbleItems
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<BabbleItem>("Babble.TrafficItemBabbleItem", "BabbleItem");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<BabbleItem>("Babble.TrafficItemBabbleItem", "BabbleItem", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Babble", Name="TrafficLog")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class TrafficLog : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new TrafficLog object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="date">Initial value of the Date property.</param>
        /// <param name="parseDate">Initial value of the ParseDate property.</param>
        /// <param name="stationName">Initial value of the StationName property.</param>
        public static TrafficLog CreateTrafficLog(global::System.Int32 id, global::System.DateTime date, global::System.DateTime parseDate, global::System.String stationName)
        {
            TrafficLog trafficLog = new TrafficLog();
            trafficLog.Id = id;
            trafficLog.Date = date;
            trafficLog.ParseDate = parseDate;
            trafficLog.StationName = stationName;
            return trafficLog;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime Date
        {
            get
            {
                return _Date;
            }
            set
            {
                OnDateChanging(value);
                ReportPropertyChanging("Date");
                _Date = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Date");
                OnDateChanged();
            }
        }
        private global::System.DateTime _Date;
        partial void OnDateChanging(global::System.DateTime value);
        partial void OnDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime ParseDate
        {
            get
            {
                return _ParseDate;
            }
            set
            {
                OnParseDateChanging(value);
                ReportPropertyChanging("ParseDate");
                _ParseDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ParseDate");
                OnParseDateChanged();
            }
        }
        private global::System.DateTime _ParseDate;
        partial void OnParseDateChanging(global::System.DateTime value);
        partial void OnParseDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String StationName
        {
            get
            {
                return _StationName;
            }
            set
            {
                OnStationNameChanging(value);
                ReportPropertyChanging("StationName");
                _StationName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("StationName");
                OnStationNameChanged();
            }
        }
        private global::System.String _StationName;
        partial void OnStationNameChanging(global::System.String value);
        partial void OnStationNameChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("Babble", "TrafficLogTrafficEvent", "TrafficEvent")]
        public EntityCollection<TrafficEvent> TrafficEvents
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<TrafficEvent>("Babble.TrafficLogTrafficEvent", "TrafficEvent");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<TrafficEvent>("Babble.TrafficLogTrafficEvent", "TrafficEvent", value);
                }
            }
        }

        #endregion
    }

    #endregion
    
}
