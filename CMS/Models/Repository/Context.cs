using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using CMS.DAL.Models;

namespace CMS.Models.Repository
{
    public partial class PageItemContext : DbContext
    {
        public PageItemContext()
            : base("name=CMS")
        {
        }

        public virtual DbSet<PageItem> Pages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

    }

}