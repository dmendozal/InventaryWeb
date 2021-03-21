using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace InventaryWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Nombre")]
        public string Name { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}