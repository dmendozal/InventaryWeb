using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventaryWeb.Models
{
    public class EntryNote
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int Orden { get; set; }
        [DisplayName("Fecha")]
        public DateTime Date { get; set; }
        public double Total { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<EntryDetails> EntryDetails { get; set; }
    }
}