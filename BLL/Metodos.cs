using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class Metodos
    {
        public static int ToInt(string valor)
        {
            int retorno = 0;
            int.TryParse(valor, out retorno);

            return retorno;
        }

        public static List<Categoria> RetornarCategorias(List<Categoria> listCategorias)
        {
            return listCategorias;
        }

        public static List<Categoria> FiltrarCategorias(int index, string criterio, DateTime desde, DateTime hasta)
        {
            Expression<Func<Categoria, bool>> filtro = p => true;
            Repositorio<Categoria> repositorio = new Repositorio<Categoria>();
            List<Categoria> list = new List<Categoria>();

            int id = ToInt(criterio);
            switch (index)
            {
                case 0://Todo
                    break;

                case 1://Todo por fecha
                    filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2://CategoriaId
                    filtro = p => p.CategoriaId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 3://Descripcion
                    filtro = p => p.Descripcion.Contains(criterio) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
            }

            list = repositorio.GetList(filtro);

            return list;
        }

        public static List<Usuario> FiltrarUsuarios(int index, string criterio, DateTime desde, DateTime hasta)
        {
            Expression<Func<Usuario, bool>> filtro = p => true;
            Repositorio<Usuario> repositorio = new Repositorio<Usuario>();
            List<Usuario> list = new List<Usuario>();

            int id = ToInt(criterio);
            switch (index)
            {
                case 0://Todo
                    break;

                case 1://Todo por fecha
                    filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2://UsuarioId
                    filtro = p => p.UsuarioId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 3://Descripcion
                    filtro = p => p.Nombres.Contains(criterio) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
            }

            list = repositorio.GetList(filtro);

            return list;
        }
    }
}
