using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.GetRenderingDatasource;
using Sitecore.Text;
using System.Collections.Generic;

namespace KraftHeinz.Pipelines
{
    public class GetQueryableDatasourceLocation
    {
        //public void Process(GetRenderingDatasourceArgs args)
        //{
        //    foreach (var location in
        //        new ListString(args.RenderingItem["Datasource Location"]))
        //    {
        //        if (location.StartsWith("query:"))
        //        {
        //            Item contextItem = args.ContentDatabase.Items[args.ContextItemPath];
        //            if (contextItem != null)
        //            {
        //                string query = location.Substring("query:".Length);
        //                IList<Item> queryItems = contextItem.Axes.SelectItems(query);
        //                Item queryItem = contextItem.Axes.SelectSingleItem(query);
        //                if (queryItem != null)
        //                {
        //                    args.DatasourceRoots.Add(queryItem);
        //                }
        //            }
        //        }
        //    }
        //}

        public void Process(GetRenderingDatasourceArgs args)
        {
            Assert.IsNotNull(args, "args");
            DatasourceLocation = args.RenderingItem["Datasource Location"];
            if (QueryInDataSourceLocation())
                ProcessQuery(args);
        }

        private void ProcessQuery(GetRenderingDatasourceArgs args)
        {
            ContextItemPath = args.ContextItemPath;
            ContentDataBase = args.ContentDatabase;
            Item datasourceLocation = ResolveDatasourceRootFromQuery();
            if (datasourceLocation != null)
                args.DatasourceRoots.Add(datasourceLocation);
        }

        private bool QueryInDataSourceLocation()
        {
            return DatasourceLocation.StartsWith(_query);
        }

        private Item ResolveDatasourceRootFromQuery()
        {
            string query = DatasourceLocation.Replace(_query, ContextItemPath);
            return ContentDataBase.SelectSingleItem(query);
        }

        private string DatasourceLocation { get; set; }
        private string ContextItemPath { get; set; }
        private Database ContentDataBase { get; set; }
        private const string _query = "query:.";
    }
}
