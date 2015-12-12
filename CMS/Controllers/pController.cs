using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS.Models.Repository;
using CMS.Models;
using CMS.DAL.Models;

namespace CMS.Controllers
{
    [RoutePrefix("p")]
    [Route("{action}")]
    public class pController : Controller
    {
        //Stores repository in field
        private IPageRepository _repository;
    
        /// <summary>
        /// The controller’s default constructor [PageController()] 
        /// Invoked by the MVC framework when application runs will populate the [ _repository ] field with the
        /// default implementation of the repository.
        /// </summary>
        public pController() 
        {
            _repository = new PageRepository();  //Creates Default Repository
        }

       
        /// <summary>
        /// Allows repository to be injected by passing in a repository 
        /// [ PageController(repository) of Type IpageRepository]
        /// </summary>
        /// <param name="repository"> PageController(repository) of Type IPageRepository</param>
        /// <remarks>This allows for the controller to use any datasource.</remarks>
        public pController(IPageRepository repository)
        {
            _repository = repository;
        }


        public ActionResult Index(String id)
        {
            // Root Site  http://MainSite.Com/p
            if (String.IsNullOrEmpty(id))
            {
                return Redirect("/Page/List"); 
            }

            // PageName is Not Empty, Lets see if it exists in database
            if (!String.IsNullOrEmpty(id))
            {
                //Only Load up if PageName is not Empty
                PageItem FindPageName =  _repository.GetPageByURL(id);

                // PageName  Does not Exist in Database
                if (FindPageName == null)
                {
                    //ToDo: Add Page Not Found
                    return Content("Page Not Found");
                }

                // PageName Does Exist in Database
                if (FindPageName != null)
                {
                    return View(FindPageName);
                }

            }

            // Something went wrong
            return View("");
        }


        public ActionResult SaveContent(string editor, string content)
        {
            //save content to db here
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }



    }
}
