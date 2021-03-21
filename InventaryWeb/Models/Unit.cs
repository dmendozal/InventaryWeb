using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace InventaryWeb.Models
{
    public class Unit
    {
        public int Id { get; set; }
        [DisplayName("Descripcion")]
        public string Description { get; set; }
        [DisplayName("Abreviacion")]
        public string Abbreviation { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}