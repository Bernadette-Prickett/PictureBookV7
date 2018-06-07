﻿using System;
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
        public DbSet<CategoryDTO> Categories { get; set; }
        public DbSet<ProductDTO> Products { get; set; }
        public DbSet<UserDTO> Users { get; set; }
        public DbSet<RoleDTO> Roles { get; set; }
        public DbSet<UserRoleDTO> UserRoles { get; set; }
    }
}