using Core.interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Dominio.Entidades
{
    public class Facturas:IidentidaID
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int propietarioId { get; private set; }
        [ForeignKey("propietarioId")]
        public virtual Propietarios propietario { get; private set; } = null!;

        public int clienteId { get; private set; }
        [ForeignKey("clienteId")]
        public Clientes cliente { get; private set; } = null!;
        public DateTime fecha { get; private set; }
        public float total { get; private set; }

        private Facturas()
        {
        }

        public Facturas(int propietarioId, int clienteId, DateTime fecha, float total)
        {
            this.propietarioId = propietarioId;
            this.clienteId = clienteId;
            this.fecha = fecha;
            this.total = total;
        }

        public void UpdateDetails(int propietarioId, int clienteId, DateTime fecha, float total)
        {
            this.propietarioId = propietarioId;
            this.clienteId = clienteId;
            this.fecha = fecha;
            this.total = total;
        }
    }
}
