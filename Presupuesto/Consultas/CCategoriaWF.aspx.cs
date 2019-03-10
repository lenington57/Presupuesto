using Entities;
using Presupuesto.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presupuesto.Consultas
{
    public partial class CCategoriaWF : System.Web.UI.Page
    {
        public static List<Categoria> listCategorias { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        protected void ImprimirLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Reportes/ViewerCategorias.aspx");
        }

        private int ToInt(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);

            return retorno;
        }

        protected void buscarLinkButton_Click(object sender, EventArgs e)
        {
            int id = Utils.ToInt(CriterioTextBox.Text);
            int index = ToInt(FiltroDropDownList.SelectedIndex);
            DateTime desde = Utils.ToDateTime(DesdeTextBox.Text);
            DateTime hasta = Utils.ToDateTime(HastaTextBox.Text);
            categoriaGridView.DataSource = BLL.Metodos.FiltrarCategorias(index, CriterioTextBox.Text, desde, hasta);
            categoriaGridView.DataBind();
            listCategorias = BLL.Metodos.FiltrarCategorias(index, CriterioTextBox.Text, desde, hasta);
        }

        public static List<Categoria> DameCategorias()
        {
            return listCategorias;
        }
    }
}