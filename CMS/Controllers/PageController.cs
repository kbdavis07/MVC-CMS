using CMS.DAL.Models;
using CMS.Models;
using CMS.Models.Repository;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CMS.Controllers
{
    [RoutePrefix("Page")]
    [Route("{action}/{id}")]
    public class PageController : Controller
    {
        //Stores repository in field
        private IPageRepository _repository;
    
        /// <summary>
        /// The controller’s default constructor [PageController()] 
        /// Invoked by the MVC framework when application runs will populate the [ _repository ] field with the
        /// default implementation of the repository.
        /// </summary>
        public PageController() 
        {
            _repository = new PageRepository();  //Creates Default Repository
        }

       
        /// <summary>
        /// Allows repository to be injected by passing in a repository 
        /// [ PageController(repository) of Type IpageRepository]
        /// </summary>
        /// <param name="repository"> PageController(repository) of Type IPageRepository</param>
        /// <remarks>This allows for the controller to use any datasource.</remarks>
        public PageController(IPageRepository repository)
        {
            _repository = repository;
        }



        // GET: Page
        [Route]
        public ActionResult Index()
        {
           return View(_repository.GetAllPages());
        }

        // GET: Page/Details/5
        public ActionResult Details(Guid id)
        {
            PageItem pageItem = _repository.GetPageById(id);
            if (pageItem == null)
            {
                return HttpNotFound();
            }
            return View(pageItem);
        }

        // GET: Page/Create
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Page/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,MetaTitle,Title,Content,Description,Keywords,PageName,Live,Author,ControllerName")] PageItem pageItem)
        {
            if (ModelState.IsValid)
            {
                _repository.AddPage(pageItem);
                return RedirectToAction("Index");
            }

            return View(pageItem);
        }

        // GET: Page/Edit/5
        public ActionResult Edit(Guid id)
        {
            PageItem pageItem = _repository.GetPageById(id);
            if (pageItem == null)
            {
                return HttpNotFound();
            }
            return View(pageItem);
        }

        // POST: Page/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,MetaTitle,Title,Content,Description,Keywords,PageName,Live,Author,DateCreated,LastUpdate,ControllerName")] PageItem pageItem)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdatePage(pageItem);
                return RedirectToAction("Index");
            }
            return View(pageItem);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditContent(Guid id, string content)
        {
            _repository.EditContent(id,content);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }



        // GET: Page/Delete/5
        public ActionResult Delete(Guid id)
        {
            PageItem pageItem = _repository.GetPageById(id);
            if (pageItem == null)
            {
                return HttpNotFound();
            }
            return View(pageItem);
        }

        // POST: Page/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _repository.DeletePage(id);
            return RedirectToAction("Index");
        }

        public ActionResult List()
        {
            return View(_repository.GetMostRecentPages(10));
        }

        public ActionResult Page()
        {
            return View();
        }

        public ActionResult Page2()
        {
            return View();
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();  
            }
            base.Dispose(disposing);
        }
    }
}
