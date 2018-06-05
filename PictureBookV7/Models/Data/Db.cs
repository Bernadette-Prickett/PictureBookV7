using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PictureBookV7.Models.Data
{
    public class Db : DbContext
    {
        //This will allow me to access tables through EntityFramework
        public DbSet<PageDTO> Pages { get; set; }
        public DbSet<SidebarDTO> Sidebar { get; set; }
    }
}