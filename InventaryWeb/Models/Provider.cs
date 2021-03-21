using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventaryWeb.Models
{
    public class Provider
    {
        public int Id { get; set; }
        [DisplayName("CI o NIT")]
        public string Ci { get; set; }
        [DisplayName("Nombre")]
        public string Name { get; set; }
        [DisplayName("Teléfono")]
        public string Telephone { get; set; }
        [DisplayName("Email")]
        public string Address { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}