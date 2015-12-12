using CMS.DAL.Models;
using SharpRepository.InMemoryRepository;
using SharpRepository.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace CMS.Models
{
    /// <summary>
    /// Interface for Website Pages Repository
    /// </summary>
    public interface IPageRepository 
    {
        IList<PageItem> GetMostRecentPages(int NumberOfPages);
        List<PageItem> GetAllPages();
        PageItem GetPageById(Guid id);
        PageItem GetPageByURL(string URL);
        void AddPage(PageItem pageItem);
        void UpdatePage(PageItem pageItem);
        void EditContent(Guid id, string content);
        void DeletePage(Guid id);
        void Save();
        void Dispose();
    }


}