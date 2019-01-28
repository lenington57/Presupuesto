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
    public class RepositorioEgresos : Repositorio<Egreso>
    {
        public override Egreso Buscar(int id)
        {
            Egreso egreso = new Egreso();
            try
            {
                egreso = _contexto.Egreso.Find(id);
                egreso.Detalle.Count();

                foreach (var item in egreso.Detalle)        
                {
                    string s = item.Categoria.Descripcion;
                }
                
            }
            catch (Exception)
            {

                throw;
            }
            return egreso;
        }

        public override bool Modificar(Egreso egreso)
        {
            bool paso = false;
            try
            {
                foreach (var item in egreso.Detalle)
                {
                    var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added; //Muy importante indicar que pasara con la entidad del detalle
                    _contexto.Entry(item).State = estado;
                }
                
                _contexto.Entry(egreso).State = EntityState.Modified;

                if (_contexto.SaveChanges() > 0)
                    paso = true;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

    }
}
