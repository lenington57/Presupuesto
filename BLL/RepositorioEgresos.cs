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
        public override bool Guardar(Egreso egreso)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Egreso.Add(egreso) != null)

                    foreach (var item in egreso.Detalle)
                    {
                        contexto.Categoria.Find(item.CategoriaId).MontoMensualidad -= item.MontoEgresado;
                    }

                //contexto.Vehiculos.Find(mantenimiento.VehiculoId).TotalMantenimiento += mantenimiento.Total;

                contexto.SaveChanges();
                paso = true;

                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public override bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                Egreso egreso = contexto.Egreso.Find(id);

                foreach (var item in egreso.Detalle)
                {
                    var Eliminar = contexto.Categoria.Find(item.CategoriaId);
                    Eliminar.MontoMensualidad += item.MontoEgresado;
                }
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
