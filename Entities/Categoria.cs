using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        public DateTime Fecha { get; set; }

        public string Descripcion { get; set; }

        public int MontoMensualidad { get; set; }


        public Categoria()
        {
            CategoriaId = 0;
            Fecha = DateTime.Now;
            Descripcion = string.Empty;
            MontoMensualidad = 0;
        }

        public Categoria(int categoriaId, DateTime fecha, string descripcion, int montoMensualidad)
        {
            CategoriaId = categoriaId;
            Fecha = fecha;
            Descripcion = descripcion;
            MontoMensualidad = montoMensualidad;
        }
    }
}
