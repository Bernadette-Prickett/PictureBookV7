using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PictureBookV7.Models.Data
{
    [Table("tbl_Roles")]
    public class RoleDTO
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }        
    }
}