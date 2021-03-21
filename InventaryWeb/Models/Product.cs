using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventaryWeb.Models
{
    public class Product
    {
        public int Id { get; set; }
        [DisplayName("Código")]
        public string Code { get; set; }
        [DisplayName("Nombre")]
        public string Name { get; set; }
        [DisplayName("Descripción")]
        public string Description { get; set; }
        [DisplayName("Cantidad")]
        public int Stock { get; set; }
        [DisplayName("Precio de Compra")]
        public double PurchasePrice { get; set; }
        [DisplayName("Precio de Venta")]
        public double SalePrice { get; set; }
        [DisplayName("Código QR")]
        public string CodeQR { get; set; }
        [DisplayName("Imagen")]
        public string MainImage { get; set; }
        [DisplayName("Fecha de Vencimiento")]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}",ApplyFormatInEditMode =true)]
        public DateTime ExpirationTime { get; set; }
        public int UnitID { get; set; }
        public virtual Unit Unit { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public int ProviderID { get; set; }
        public virtual Provider Provider { get; set; }
        public virtual ICollection<ExitDetails> ExitDetails { get; set; }
        public virtual ICollection<EntryDetails> EntryDetails { get; set; }
    }
}