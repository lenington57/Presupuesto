using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class EgresoDetalle
    {
        [Key]

        public int Id { get; set; }

        public int EgresoId { get; set; }

        public int CategoriaId { get; set; }

        public string Concepto { get; set; }

        public int MontoEgresado { get; set; }

        [ForeignKey("CategoriaId")]
        //Permite indicar por cual campo se usara
        //la NAVIGATION PROPERTY
        public virtual Categoria Categoria { get; set; }

        public EgresoDetalle()
        {
            Id = 0;
            EgresoId = 0;
            CategoriaId = 0;
            Concepto = string.Empty;
            MontoEgresado = 0;
        }

        public EgresoDetalle(int id, int egresoId, int categoriaId, string concepto, int montoEgresado)
        {
            Id = id;
            CategoriaId = categoriaId;
            EgresoId = egresoId;
            Concepto = concepto;
            MontoEgresado = montoEgresado;
        }

        public override string ToString()
        {
            return "Categoria: " + this.CategoriaId.ToString() + " Monto: " + this.MontoEgresado;
        }

    }
}
