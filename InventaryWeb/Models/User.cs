using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace InventaryWeb.Models
{
    public class User
    {
        public int Id { get; set; }
        [DisplayName("Nombre")]
        public string Username { get; set; }
        public string Email { get; set; }
        [DisplayName("Contraseña")]
        public string Password { get; set; }
    }
}