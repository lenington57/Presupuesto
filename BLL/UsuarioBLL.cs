using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioBLL
    {        
        public static bool ModificarPresupuesto(int id, int Monto)
        {
            bool paso = false;
            Repositorio<Usuario> repositorio = new Repositorio<Usuario>();
            Contexto contexto = new Contexto();
            try
            {
                Usuario usuario = new Usuario();
                
                usuario = contexto.Usuario.Find(id);
                usuario.MontoPresupuesto = Monto;
                repositorio.Modificar(usuario);

                contexto.Entry(usuario).State = EntityState.Modified;

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
    }
}
