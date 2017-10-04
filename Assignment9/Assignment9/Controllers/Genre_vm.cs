using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace Assignment9.Controllers
{
    public class GenreBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}