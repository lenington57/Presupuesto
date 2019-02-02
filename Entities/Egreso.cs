using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Egreso
    {
        [Key]

        public int EgresoId { get; set; }

        public DateTime Fecha { get; set; }

        public int MontoGastado { get; set; }

        public virtual List<EgresoDetalle> Detalle { get; set; }


        public Egreso()
        {
            this.Detalle = new List<EgresoDetalle>();
        }
        
        public void AgregarDetalle(int Id, int EgresoId, int CategoriaId, string Concepto, int MontoEgresado)
        {
            this.Detalle.Add(new EgresoDetalle(Id, EgresoId, CategoriaId, Concepto, MontoEgresado));
        }
        
    }
}
