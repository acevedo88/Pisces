﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.0.3705.288
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace HydrometTools {
    using System;
    using System.Data;
    using System.Xml;
    using System.Runtime.Serialization;
    
    
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.ToolboxItem(true)]
    public class TimeSeriesDataset : DataSet {
        
        private TimeSeriesDataDataTable tableTimeSeriesData;
        
        private DefinitionDataTable tableDefinition;
        
        public TimeSeriesDataset() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected TimeSeriesDataset(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["TimeSeriesData"] != null)) {
                    this.Tables.Add(new TimeSeriesDataDataTable(ds.Tables["TimeSeriesData"]));
                }
                if ((ds.Tables["Definition"] != null)) {
                    this.Tables.Add(new DefinitionDataTable(ds.Tables["Definition"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.InitClass();
            }
            this.GetSerializationData(info, context);
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public TimeSeriesDataDataTable TimeSeriesData {
            get {
                return this.tableTimeSeriesData;
            }
        }
        
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public DefinitionDataTable Definition {
            get {
                return this.tableDefinition;
            }
        }
        
        public override DataSet Clone() {
            TimeSeriesDataset cln = ((TimeSeriesDataset)(base.Clone()));
            cln.InitVars();
            return cln;
        }
        
        protected override bool ShouldSerializeTables() {
            return false;
        }
        
        protected override bool ShouldSerializeRelations() {
            return false;
        }
        
        protected override void ReadXmlSerializable(XmlReader reader) {
            this.Reset();
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            if ((ds.Tables["TimeSeriesData"] != null)) {
                this.Tables.Add(new TimeSeriesDataDataTable(ds.Tables["TimeSeriesData"]));
            }
            if ((ds.Tables["Definition"] != null)) {
                this.Tables.Add(new DefinitionDataTable(ds.Tables["Definition"]));
            }
            this.DataSetName = ds.DataSetName;
            this.Prefix = ds.Prefix;
            this.Namespace = ds.Namespace;
            this.Locale = ds.Locale;
            this.CaseSensitive = ds.CaseSensitive;
            this.EnforceConstraints = ds.EnforceConstraints;
            this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
            this.InitVars();
        }
        
        protected override System.Xml.Schema.XmlSchema GetSchemaSerializable() {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            this.WriteXmlSchema(new XmlTextWriter(stream, null));
            stream.Position = 0;
            return System.Xml.Schema.XmlSchema.Read(new XmlTextReader(stream), null);
        }
        
        internal void InitVars() {
            this.tableTimeSeriesData = ((TimeSeriesDataDataTable)(this.Tables["TimeSeriesData"]));
            if ((this.tableTimeSeriesData != null)) {
                this.tableTimeSeriesData.InitVars();
            }
            this.tableDefinition = ((DefinitionDataTable)(this.Tables["Definition"]));
            if ((this.tableDefinition != null)) {
                this.tableDefinition.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "TimeSeriesDataset";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/TimeSeriesDataset.xsd";
            this.Locale = new System.Globalization.CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableTimeSeriesData = new TimeSeriesDataDataTable();
            this.Tables.Add(this.tableTimeSeriesData);
            this.tableDefinition = new DefinitionDataTable();
            this.Tables.Add(this.tableDefinition);
        }
        
        private bool ShouldSerializeTimeSeriesData() {
            return false;
        }
        
        private bool ShouldSerializeDefinition() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void TimeSeriesDataRowChangeEventHandler(object sender, TimeSeriesDataRowChangeEvent e);
        
        public delegate void DefinitionRowChangeEventHandler(object sender, DefinitionRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class TimeSeriesDataDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnDateTime;
            
            private DataColumn columnValue;
            
            private DataColumn columnflag;
            
            internal TimeSeriesDataDataTable() : 
                    base("TimeSeriesData") {
                this.InitClass();
            }
            
            internal TimeSeriesDataDataTable(DataTable table) : 
                    base(table.TableName) {
                if ((table.CaseSensitive != table.DataSet.CaseSensitive)) {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if ((table.Locale.ToString() != table.DataSet.Locale.ToString())) {
                    this.Locale = table.Locale;
                }
                if ((table.Namespace != table.DataSet.Namespace)) {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
                this.DisplayExpression = table.DisplayExpression;
            }
            
            [System.ComponentModel.Browsable(false)]
            public int Count {
                get {
                    return this.Rows.Count;
                }
            }
            
            internal DataColumn DateTimeColumn {
                get {
                    return this.columnDateTime;
                }
            }
            
            internal DataColumn ValueColumn {
                get {
                    return this.columnValue;
                }
            }
            
            internal DataColumn flagColumn {
                get {
                    return this.columnflag;
                }
            }
            
            public TimeSeriesDataRow this[int index] {
                get {
                    return ((TimeSeriesDataRow)(this.Rows[index]));
                }
            }
            
            public event TimeSeriesDataRowChangeEventHandler TimeSeriesDataRowChanged;
            
            public event TimeSeriesDataRowChangeEventHandler TimeSeriesDataRowChanging;
            
            public event TimeSeriesDataRowChangeEventHandler TimeSeriesDataRowDeleted;
            
            public event TimeSeriesDataRowChangeEventHandler TimeSeriesDataRowDeleting;
            
            public void AddTimeSeriesDataRow(TimeSeriesDataRow row) {
                this.Rows.Add(row);
            }
            
            public TimeSeriesDataRow AddTimeSeriesDataRow(System.DateTime DateTime, System.Double Value, short flag) {
                TimeSeriesDataRow rowTimeSeriesDataRow = ((TimeSeriesDataRow)(this.NewRow()));
                rowTimeSeriesDataRow.ItemArray = new object[] {
                        DateTime,
                        Value,
                        flag};
                this.Rows.Add(rowTimeSeriesDataRow);
                return rowTimeSeriesDataRow;
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                TimeSeriesDataDataTable cln = ((TimeSeriesDataDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new TimeSeriesDataDataTable();
            }
            
            internal void InitVars() {
                this.columnDateTime = this.Columns["DateTime"];
                this.columnValue = this.Columns["Value"];
                this.columnflag = this.Columns["flag"];
            }
            
            private void InitClass() {
                this.columnDateTime = new DataColumn("DateTime", typeof(System.DateTime), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnDateTime);
                this.columnValue = new DataColumn("Value", typeof(System.Double), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnValue);
                this.columnflag = new DataColumn("flag", typeof(short), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnflag);
            }
            
            public TimeSeriesDataRow NewTimeSeriesDataRow() {
                return ((TimeSeriesDataRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new TimeSeriesDataRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(TimeSeriesDataRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.TimeSeriesDataRowChanged != null)) {
                    this.TimeSeriesDataRowChanged(this, new TimeSeriesDataRowChangeEvent(((TimeSeriesDataRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.TimeSeriesDataRowChanging != null)) {
                    this.TimeSeriesDataRowChanging(this, new TimeSeriesDataRowChangeEvent(((TimeSeriesDataRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.TimeSeriesDataRowDeleted != null)) {
                    this.TimeSeriesDataRowDeleted(this, new TimeSeriesDataRowChangeEvent(((TimeSeriesDataRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.TimeSeriesDataRowDeleting != null)) {
                    this.TimeSeriesDataRowDeleting(this, new TimeSeriesDataRowChangeEvent(((TimeSeriesDataRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveTimeSeriesDataRow(TimeSeriesDataRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class TimeSeriesDataRow : DataRow {
            
            private TimeSeriesDataDataTable tableTimeSeriesData;
            
            internal TimeSeriesDataRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableTimeSeriesData = ((TimeSeriesDataDataTable)(this.Table));
            }
            
            public System.DateTime DateTime {
                get {
                    try {
                        return ((System.DateTime)(this[this.tableTimeSeriesData.DateTimeColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableTimeSeriesData.DateTimeColumn] = value;
                }
            }
            
            public System.Double Value {
                get {
                    try {
                        return ((System.Double)(this[this.tableTimeSeriesData.ValueColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableTimeSeriesData.ValueColumn] = value;
                }
            }
            
            public short flag {
                get {
                    try {
                        return ((short)(this[this.tableTimeSeriesData.flagColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableTimeSeriesData.flagColumn] = value;
                }
            }
            
            public bool IsDateTimeNull() {
                return this.IsNull(this.tableTimeSeriesData.DateTimeColumn);
            }
            
            public void SetDateTimeNull() {
                this[this.tableTimeSeriesData.DateTimeColumn] = System.Convert.DBNull;
            }
            
            public bool IsValueNull() {
                return this.IsNull(this.tableTimeSeriesData.ValueColumn);
            }
            
            public void SetValueNull() {
                this[this.tableTimeSeriesData.ValueColumn] = System.Convert.DBNull;
            }
            
            public bool IsflagNull() {
                return this.IsNull(this.tableTimeSeriesData.flagColumn);
            }
            
            public void SetflagNull() {
                this[this.tableTimeSeriesData.flagColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class TimeSeriesDataRowChangeEvent : EventArgs {
            
            private TimeSeriesDataRow eventRow;
            
            private DataRowAction eventAction;
            
            public TimeSeriesDataRowChangeEvent(TimeSeriesDataRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public TimeSeriesDataRow Row {
                get {
                    return this.eventRow;
                }
            }
            
            public DataRowAction Action {
                get {
                    return this.eventAction;
                }
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class DefinitionDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnLocation;
            
            private DataColumn columnParameterType;
            
            private DataColumn columnTitle;
            
            private DataColumn columnSource;
            
            private DataColumn columnTagInfo;
            
            internal DefinitionDataTable() : 
                    base("Definition") {
                this.InitClass();
            }
            
            internal DefinitionDataTable(DataTable table) : 
                    base(table.TableName) {
                if ((table.CaseSensitive != table.DataSet.CaseSensitive)) {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if ((table.Locale.ToString() != table.DataSet.Locale.ToString())) {
                    this.Locale = table.Locale;
                }
                if ((table.Namespace != table.DataSet.Namespace)) {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
                this.DisplayExpression = table.DisplayExpression;
            }
            
            [System.ComponentModel.Browsable(false)]
            public int Count {
                get {
                    return this.Rows.Count;
                }
            }
            
            internal DataColumn LocationColumn {
                get {
                    return this.columnLocation;
                }
            }
            
            internal DataColumn ParameterTypeColumn {
                get {
                    return this.columnParameterType;
                }
            }
            
            internal DataColumn TitleColumn {
                get {
                    return this.columnTitle;
                }
            }
            
            internal DataColumn SourceColumn {
                get {
                    return this.columnSource;
                }
            }
            
            internal DataColumn TagInfoColumn {
                get {
                    return this.columnTagInfo;
                }
            }
            
            public DefinitionRow this[int index] {
                get {
                    return ((DefinitionRow)(this.Rows[index]));
                }
            }
            
            public event DefinitionRowChangeEventHandler DefinitionRowChanged;
            
            public event DefinitionRowChangeEventHandler DefinitionRowChanging;
            
            public event DefinitionRowChangeEventHandler DefinitionRowDeleted;
            
            public event DefinitionRowChangeEventHandler DefinitionRowDeleting;
            
            public void AddDefinitionRow(DefinitionRow row) {
                this.Rows.Add(row);
            }
            
            public DefinitionRow AddDefinitionRow(string Location, string ParameterType, string Title, string Source, string TagInfo) {
                DefinitionRow rowDefinitionRow = ((DefinitionRow)(this.NewRow()));
                rowDefinitionRow.ItemArray = new object[] {
                        Location,
                        ParameterType,
                        Title,
                        Source,
                        TagInfo};
                this.Rows.Add(rowDefinitionRow);
                return rowDefinitionRow;
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                DefinitionDataTable cln = ((DefinitionDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new DefinitionDataTable();
            }
            
            internal void InitVars() {
                this.columnLocation = this.Columns["Location"];
                this.columnParameterType = this.Columns["ParameterType"];
                this.columnTitle = this.Columns["Title"];
                this.columnSource = this.Columns["Source"];
                this.columnTagInfo = this.Columns["TagInfo"];
            }
            
            private void InitClass() {
                this.columnLocation = new DataColumn("Location", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnLocation);
                this.columnParameterType = new DataColumn("ParameterType", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnParameterType);
                this.columnTitle = new DataColumn("Title", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnTitle);
                this.columnSource = new DataColumn("Source", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnSource);
                this.columnTagInfo = new DataColumn("TagInfo", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnTagInfo);
            }
            
            public DefinitionRow NewDefinitionRow() {
                return ((DefinitionRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new DefinitionRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(DefinitionRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.DefinitionRowChanged != null)) {
                    this.DefinitionRowChanged(this, new DefinitionRowChangeEvent(((DefinitionRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.DefinitionRowChanging != null)) {
                    this.DefinitionRowChanging(this, new DefinitionRowChangeEvent(((DefinitionRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.DefinitionRowDeleted != null)) {
                    this.DefinitionRowDeleted(this, new DefinitionRowChangeEvent(((DefinitionRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.DefinitionRowDeleting != null)) {
                    this.DefinitionRowDeleting(this, new DefinitionRowChangeEvent(((DefinitionRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveDefinitionRow(DefinitionRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class DefinitionRow : DataRow {
            
            private DefinitionDataTable tableDefinition;
            
            internal DefinitionRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableDefinition = ((DefinitionDataTable)(this.Table));
            }
            
            public string Location {
                get {
                    try {
                        return ((string)(this[this.tableDefinition.LocationColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableDefinition.LocationColumn] = value;
                }
            }
            
            public string ParameterType {
                get {
                    try {
                        return ((string)(this[this.tableDefinition.ParameterTypeColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableDefinition.ParameterTypeColumn] = value;
                }
            }
            
            public string Title {
                get {
                    try {
                        return ((string)(this[this.tableDefinition.TitleColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableDefinition.TitleColumn] = value;
                }
            }
            
            public string Source {
                get {
                    try {
                        return ((string)(this[this.tableDefinition.SourceColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableDefinition.SourceColumn] = value;
                }
            }
            
            public string TagInfo {
                get {
                    try {
                        return ((string)(this[this.tableDefinition.TagInfoColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableDefinition.TagInfoColumn] = value;
                }
            }
            
            public bool IsLocationNull() {
                return this.IsNull(this.tableDefinition.LocationColumn);
            }
            
            public void SetLocationNull() {
                this[this.tableDefinition.LocationColumn] = System.Convert.DBNull;
            }
            
            public bool IsParameterTypeNull() {
                return this.IsNull(this.tableDefinition.ParameterTypeColumn);
            }
            
            public void SetParameterTypeNull() {
                this[this.tableDefinition.ParameterTypeColumn] = System.Convert.DBNull;
            }
            
            public bool IsTitleNull() {
                return this.IsNull(this.tableDefinition.TitleColumn);
            }
            
            public void SetTitleNull() {
                this[this.tableDefinition.TitleColumn] = System.Convert.DBNull;
            }
            
            public bool IsSourceNull() {
                return this.IsNull(this.tableDefinition.SourceColumn);
            }
            
            public void SetSourceNull() {
                this[this.tableDefinition.SourceColumn] = System.Convert.DBNull;
            }
            
            public bool IsTagInfoNull() {
                return this.IsNull(this.tableDefinition.TagInfoColumn);
            }
            
            public void SetTagInfoNull() {
                this[this.tableDefinition.TagInfoColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class DefinitionRowChangeEvent : EventArgs {
            
            private DefinitionRow eventRow;
            
            private DataRowAction eventAction;
            
            public DefinitionRowChangeEvent(DefinitionRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public DefinitionRow Row {
                get {
                    return this.eventRow;
                }
            }
            
            public DataRowAction Action {
                get {
                    return this.eventAction;
                }
            }
        }
    }
}