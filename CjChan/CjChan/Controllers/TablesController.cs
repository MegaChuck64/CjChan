using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;

using CjChan.Models;

using System.Web.Mvc;
using System;

namespace CjChan.Controllers
{
    public class TablesController : Controller
    {
        // GET: Tables
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateTable()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
   CloudConfigurationManager.GetSetting("megachuck64_AzureStorageConnectionString"));

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable table = tableClient.GetTableReference("TestTable");

            ViewBag.Success = table.CreateIfNotExists();

            ViewBag.TableName = table.Name;
            return View();
        }

        public ActionResult AddEntity()
        {
            try
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
       CloudConfigurationManager.GetSetting("megachuck64_AzureStorageConnectionString"));

                CloudTableClient tableClient = storageAccount.CreateCloudTableClient();


                CloudTable table = tableClient.GetTableReference("TestTable");

                          

                TableOperation retriveOperation = TableOperation.Retrieve<CustomerEntity>("Carey", "CJ");
                TableResult res = table.Execute(retriveOperation);

                ViewBag.Email = (res.Result as CustomerEntity).Email;
                ViewBag.TableName = table.Name;
            }
            catch(Exception e)
            {
                ViewBag.Result = e.Message;
            }

            return View();
        }
    }
}