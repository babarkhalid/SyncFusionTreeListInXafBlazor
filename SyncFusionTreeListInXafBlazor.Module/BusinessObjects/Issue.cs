using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SyncFusionTreeListInXafBlazor.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Issue : BaseObject
    { 
        public Issue(Session session) : base(session)
        { }


        private Issue _ParentIssue;
        public Issue ParentIssue
        {
            get { return _ParentIssue; }
            set { SetPropertyValue<Issue>(nameof(ParentIssue), ref _ParentIssue, value); }
        }


        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetPropertyValue<string>(nameof(Name), ref _Name, value); }
        }


        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { SetPropertyValue<string>(nameof(Description), ref _Description, value); }
        }


        private DateTime _LogDate;
        public DateTime LogDate
        {
            get { return _LogDate; }
            set { SetPropertyValue<DateTime>(nameof(LogDate), ref _LogDate, value); }
        }

        public Guid? ParentId
        {
            get => ParentIssue?.Oid; 
        }
    }
}