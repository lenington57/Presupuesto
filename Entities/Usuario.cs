using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        public DateTime Fecha { get; set; }

        public string Nombres { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string CPassword { get; set; }

        public int MontoPresupuesto { get; set; }


        public Usuario()
        {
            UsuarioId = 0;
            Fecha = DateTime.Now;
            Nombres = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            CPassword = string.Empty;
            MontoPresupuesto = 0;
        }

        public Usuario(int usuarioId, DateTime fecha, string nombres, string email, string password, string cpassword, int montopresupuesto)
        {
            UsuarioId = usuarioId;
            Fecha = fecha;
            Nombres = nombres;
            Email = email;
            Password = password;
            CPassword = cpassword;
            MontoPresupuesto = montopresupuesto;
        }
    }
}
