using System;
using System.Configuration;
using DataLibrary;
using System.Web.Mvc;
using System.Linq;
using DataLibrary.Repositories;
using DockerDebug.Models;

namespace DockerDebug.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var msg = "No Db Connection";
            var tableList = string.Empty;

            ViewBag.Message = "Your application home page.";

            try
            {
                var db = new DataContext(ConfigurationManager.ConnectionStrings["dockerdb"].ConnectionString);
                var textRepo = new ListsRepo(db);
                var returnText = textRepo.GetCount();

                foreach (var item in textRepo.GetData())
                {
                    tableList += item.table_name + "/n";
                }

                msg = "Db Connection OK: Count of records - " + returnText.ToString() + "/n" + tableList;
            }
            catch (Exception e)
            {
                msg = e.Message;
            }


            var vm = new TextViewModel
            {
                Description = msg
            };




            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}