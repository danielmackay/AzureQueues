using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AzureQueue.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace AzureQueue.Controllers
{
    public class MessageController : Controller
    {
        public ActionResult Index()
        {
            var queue = GetQueue();
            var items = queue.GetMessages(10, new TimeSpan(0,0,1));

            var messages = items.Select(m => new MessageViewModel {Message = m.AsString, ID = m.Id, PopReceipt = m.PopReceipt}).ToList();

            return View(messages);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Message = "";
            return View();
        }

        [HttpPost]
        public ActionResult Create(MessageViewModel model)
        {
            var queue = GetQueue();
            var msg = new CloudQueueMessage(model.Message);
            queue.AddMessage(msg);

            ViewBag.Message = "Message added to queue!";
            return RedirectToAction("Create");
        }

        public ActionResult Delete(string id, string receipt)
        {
            var queue = GetQueue();
            queue.DeleteMessage(id, receipt);

            return RedirectToAction("Index");
        }

        private static CloudQueue GetQueue()
        {
            var account = CloudStorageAccount.DevelopmentStorageAccount;
            var client = account.CreateCloudQueueClient();
            var queue = client.GetQueueReference("myqueue");
            return queue;
        }
    }
}