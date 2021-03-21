using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace InventaryWeb.Models
{
    public class EntryDetails
    {
        public int Id { get; set; }
        [DisplayName("Cantidad")]
        public int Amount { get; set; } // cantidad
        [DisplayName("Precio")]
        public double Price { get; set; }
        public double Subtotal { get; set; }
        public int ProductID { get; set; }
        public int EntryNoteID { get; set; }
        public virtual Product Product { get; set; }
        public virtual EntryNote EntryNote { get; set; }

    }
}