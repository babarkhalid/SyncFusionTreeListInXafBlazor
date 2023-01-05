using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Editors;
using Microsoft.AspNetCore.Components;

namespace SyncFusionTreeListInXafBlazor.Blazor.Server.Pages
{
    public class IssueTreeListViewAdapter : IComponentAdapter, IComplexControl
    {
        private XafApplication application;
        private RenderFragment component;
        public RenderFragment ComponentContent
        {
            get
            {
                if (component == null)
                {
                    component = builder =>
                    {
                        builder.OpenComponent<IssueTreeListView>(0);
                        //builder.AddAttribute(1, nameof(IssueTreeListView.Title), application.Title);
                        builder.CloseComponent();
                    };
                }
                return component;
            }
        }
        public void Refresh() { }
        public void Setup(IObjectSpace objectSpace, XafApplication application)
        {
            this.application = application;
        }
        public object GetValue()
        {
            return null;
        }
        public void SetValue(object value) { }
        public event EventHandler ValueChanged;
    }
}
