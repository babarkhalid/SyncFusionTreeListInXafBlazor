using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using SyncFusionTreeListInXafBlazor.Blazor.Server.Pages;
using SyncFusionTreeListInXafBlazor.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SyncFusionTreeListInXafBlazor.Blazor.Server.Controllers
{
    public partial class IssueTreeListController : ViewController
    {
        RefreshController refreshController;
        DashboardCustomizationController customizationController;
        public IssueTreeListController()
        {
            InitializeComponent();
            TargetViewId = "IssueTreeListDB";
            SimpleAction actionNew = new SimpleAction(this, nameof(actionNew), PredefinedCategory.Edit)
            { Caption = "New", ImageName= "Action_New" };
            //SimpleAction actionDelete = new SimpleAction(this, nameof(actionDelete), PredefinedCategory.Edit)
            //{ Caption = "Delete", ImageName = "Action_Delete" };

            actionNew.Execute += ActionNew_Execute;
        }

        private void ActionNew_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var objectSpace = Application.CreateObjectSpace(typeof(Issue));
            Issue newIssue = objectSpace.CreateObject<Issue>();
            DetailView detailView = Application.CreateDetailView(objectSpace, newIssue);
            detailView.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            //e.ActionArguments.ShowViewParameters.CreatedView = detailView;
            e.ShowViewParameters.CreatedView = detailView;
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            customizationController = Frame.GetController<DashboardCustomizationController>();
            refreshController = Frame.GetController<RefreshController>();
            if(customizationController != null)
            {
                customizationController.Active.SetItemValue("IssueTreeList",false);
            }
            if(refreshController != null)
            {
                refreshController.Active.SetItemValue("RefreshIssueTreeList", false);
            }
            
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
        }
        protected override void OnDeactivated()
        {
            if (customizationController != null)
            {
                customizationController.Active.SetItemValue("IssueTreeList", true);
            }
            if (refreshController != null)
            {
                refreshController.Active.SetItemValue("RefreshIssueTreeList", true);
            }
            base.OnDeactivated();
        }
    }
}
