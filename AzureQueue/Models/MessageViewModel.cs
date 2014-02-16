using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace AzureQueue.Models
{
    public class MessageViewModel
    {
        public string Message { get; set; }
        public string ID { get; set; }
        public string PopReceipt { get; set; }
    }
}