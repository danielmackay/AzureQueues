﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.WindowsAzure.Storage;

namespace AzureQueue
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ConfigureQueue();
        }

        private void ConfigureQueue()
        {
            var account = CloudStorageAccount.DevelopmentStorageAccount;
            var client = account.CreateCloudQueueClient();
            var queue = client.GetQueueReference("myqueue");
            queue.CreateIfNotExists();
        }
    }
}
