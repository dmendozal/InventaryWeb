using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace InventaryWeb.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [DisplayName("Nombre")]
        public string Name { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Mensaje")]
        public string Message { get; set; }
    }
}