using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.DAL.Models
{
    /// <summary>
    /// Page Class, Name PageItem not to get confused with Page from System.Web
    /// </summary>
    public partial class PageItem
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string MetaTitle { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        public string Content { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Keywords { get; set; }

        [Required]
        public string PageName { get; set; }

        public bool Live { get; set; }

        public string Author { get; set; }

        public string DateCreated { get; set; }

        public string LastUpdate { get; set; }

        public string ControllerName { get; set; }

    }

}