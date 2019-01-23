using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presupuesto
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarPrecio();
        }

        private void LlenarPrecio()
        {
            Repositorio<Usuario> repositorio = new Repositorio<Usuario>();
            List<Usuario> ListArticulos = repositorio.GetList(c => true);
            foreach (var item in ListArticulos)
            {
                nombreLabel.Text = item.Nombres;
                presupuestoLabel.Text = item.MontoPresupuesto.ToString();
            }
        }
    }
}