using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CMS.DAL.Models;
using CMS.Models;
using SharpRepository.Repository;
using SharpRepository;
using SharpRepository.InMemoryRepository;
using CMS.Models.Repository;
using System.Data;
using System.Text;
using System.Data.Entity;

namespace CMS.Models.Repository
{ 
    /// <summary>
    ///  Repository for Website Pages
    /// </summary>
   
  public class PageRepository : IPageRepository, IDisposable
    {
       
      private PageItemContext db = new PageItemContext();

      
       public PageRepository()
        {
            db = new PageItemContext();
        }

      /// <summary>
      /// Gets the Most Recent Updated or New Pages
      /// </summary>
      /// <param name="NumberOfPages"> Pass Number of pages to list</param>
      /// <returns>Returns Sorted List Of Pages in Order of LastUpdate</returns>
       public IList<PageItem> GetMostRecentPages(int NumberOfPages)
       {
           return (from page in db.Pages
                   orderby page.LastUpdate descending
                   select page).Take(NumberOfPages).ToList();
       }

        public List<PageItem> GetAllPages()
        {
            return db.Pages.ToList();
        }

        public PageItem GetPageById(Guid id)
        {
            return db.Pages.SingleOrDefault(page => page.Id.Equals(id));
        }

        public PageItem GetPageByURL(string PageName)
        {
           return db.Pages.SingleOrDefault(url => url.PageName.Equals(PageName));
        }

        public void AddPage(PageItem pageItem)
        {
            pageItem.Id = Guid.NewGuid();
            pageItem.DateCreated = (DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
            pageItem.LastUpdate = (DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
            db.Pages.Add(pageItem);
            db.SaveChanges();
        }

        /// <summary>
        /// Used when updating All of the Fields of a Page
        /// </summary>
        /// <param name="pageItem"></param>
        public void UpdatePage(PageItem pageItem)
        {
            pageItem.LastUpdate = (DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
            db.Entry(pageItem).State = EntityState.Modified;
            db.SaveChanges();
        }

        /// <summary>
        /// Only Updates the Content of a Page, Called when editing with Text Editor
        /// </summary>
        /// <param name="id">Guid Id of Page</param>
        /// <param name="content">The content that was saved</param>
        public void EditContent(Guid id, string content)
        {
            PageItem page = GetPageById(id);
            page.Content = content;
            UpdatePage(page);
        }

        public void DeletePage(Guid id)
        {
            PageItem pageItem = db.Pages.Find(id);
            db.Pages.Remove(pageItem);
            db.SaveChanges();
        }

        public void Save()
        {
            db.SaveChanges();
        }


        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing == true)
            {
                db = null;
            }
        }

        ~PageRepository()
        {
            Dispose(false);
        }


    }


}