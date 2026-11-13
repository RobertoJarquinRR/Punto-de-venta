using Core.interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Dominio.Entidades
{
    public class Ventas: IidentidaID
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        public int facturaId { get; private set; }
        [ForeignKey("facturaId")]
        public virtual Facturas factura { get; private set; } = null!;
        public int productoId { get; private set; }
        [ForeignKey("productoId")]
        public virtual Productos producto { get; private set; } = null!;
        
        public int cantidad { get; private set; }
        public decimal precioUnitario { get; private set; }
        public decimal total { get; private set; }

        private Ventas()
        {
        }
        public Ventas(int facturaId, int productoId, int cantidad, decimal precioUnitario, decimal total)
        {
            this.facturaId = facturaId;
            this.productoId = productoId;
            this.cantidad = cantidad;
            this.precioUnitario = precioUnitario;
            this.total = total;
        }
        public void UpdateDetails(int facturaId, int productoId,  int cantidad, decimal precioUnitario, decimal total)
        {
            this.facturaId = facturaId;
            this.productoId = productoId;
            this.cantidad = cantidad;
            this.precioUnitario = precioUnitario;
            this.total = total;
        }
    }
}
