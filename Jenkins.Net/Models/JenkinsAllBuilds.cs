namespace JenkinsNET.Models
{
    // temporary solution, I may have to rewrite all this things
    // 注意: 生成的代码可能至少需要 .NET Framework 4.5 或 .NET Core/Standard 2.0。
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class freeStyleProject
    {
        private string _classField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("allBuild")]
        public freeStyleProjectBuild[] allBuild { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("build")]
        public freeStyleProjectBuild[] build { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string _class
        {
            get
            {
                return this._classField;
            }
            set
            {
                this._classField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class freeStyleProjectBuild
    {

        private freeStyleProjectBuildAction[] actionField;

        private bool buildingField;

        private string displayNameField;

        private uint durationField;

        private uint estimatedDurationField;

        private object executorField;

        private string fullDisplayNameField;

        private int idField;

        private bool keepLogField;

        private int numberField;

        private uint queueIdField;

        private string resultField;

        private ulong timestampField;

        private string urlField;

        private string builtOnField;

        private freeStyleProjectBuildChangeSet changeSetField;

        private string _classField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("action")]
        public freeStyleProjectBuildAction[] action
        {
            get
            {
                return this.actionField;
            }
            set
            {
                this.actionField = value;
            }
        }

        /// <remarks/>
        public bool building
        {
            get
            {
                return this.buildingField;
            }
            set
            {
                this.buildingField = value;
            }
        }

        /// <remarks/>
        public string displayName
        {
            get
            {
                return this.displayNameField;
            }
            set
            {
                this.displayNameField = value;
            }
        }

        /// <remarks/>
        public uint duration
        {
            get
            {
                return this.durationField;
            }
            set
            {
                this.durationField = value;
            }
        }

        /// <remarks/>
        public uint estimatedDuration
        {
            get
            {
                return this.estimatedDurationField;
            }
            set
            {
                this.estimatedDurationField = value;
            }
        }

        /// <remarks/>
        public object executor
        {
            get
            {
                return this.executorField;
            }
            set
            {
                this.executorField = value;
            }
        }

        /// <remarks/>
        public string fullDisplayName
        {
            get
            {
                return this.fullDisplayNameField;
            }
            set
            {
                this.fullDisplayNameField = value;
            }
        }

        /// <remarks/>
        public int id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public bool keepLog
        {
            get
            {
                return this.keepLogField;
            }
            set
            {
                this.keepLogField = value;
            }
        }

        /// <remarks/>
        public int number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }

        /// <remarks/>
        public uint queueId
        {
            get
            {
                return this.queueIdField;
            }
            set
            {
                this.queueIdField = value;
            }
        }

        /// <remarks/>
        public string result
        {
            get
            {
                return this.resultField;
            }
            set
            {
                this.resultField = value;
            }
        }

        /// <remarks/>
        public ulong timestamp
        {
            get
            {
                return this.timestampField;
            }
            set
            {
                this.timestampField = value;
            }
        }

        /// <remarks/>
        public string url
        {
            get
            {
                return this.urlField;
            }
            set
            {
                this.urlField = value;
            }
        }

        /// <remarks/>
        public string builtOn
        {
            get
            {
                return this.builtOnField;
            }
            set
            {
                this.builtOnField = value;
            }
        }

        /// <remarks/>
        public freeStyleProjectBuildChangeSet changeSet
        {
            get
            {
                return this.changeSetField;
            }
            set
            {
                this.changeSetField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string _class
        {
            get
            {
                return this._classField;
            }
            set
            {
                this._classField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class freeStyleProjectBuildAction
    {

        private string _classField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string _class
        {
            get
            {
                return this._classField;
            }
            set
            {
                this._classField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class freeStyleProjectBuildChangeSet
    {

        private string _classField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string _class
        {
            get
            {
                return this._classField;
            }
            set
            {
                this._classField = value;
            }
        }
    }


}

