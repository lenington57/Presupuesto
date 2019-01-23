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
        public int id;
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
                id = item.UsuarioId;
                nombreLabel.Text = item.Nombres;
                presupuestoLabel.Text = item.MontoPresupuesto.ToString();
            }
        }

        protected void editarButton_Click(object sender, EventArgs e)
        {

        }

        private int ToInt(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);

            return retorno;
        }


        protected void editarButton_Click1(object sender, EventArgs e)
        {
            //bool HayErrores = false;
            if (String.IsNullOrWhiteSpace(nuevoPresuTextBox.Text))
            {
                Response.Write("<script>alert('Ingrese una Cantidad');</script>");               
            }
            else
            {
                int Id = id;
                int MontoPre = ToInt(nuevoPresuTextBox.Text);
                UsuarioBLL.ModificarPresupuesto(Id, MontoPre);
                nuevoPresuTextBox.Text = "";
                presupuestoLabel.Text = MontoPre.ToString();
            }
        }
    }
}