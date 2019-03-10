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
    public partial class CUsuarioWF : System.Web.UI.Page
    {
        public static List<Usuario> listUsuarios { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
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
            usuarioGridView.DataSource = BLL.Metodos.FiltrarUsuarios(index, CriterioTextBox.Text, desde, hasta);
            usuarioGridView.DataBind();
            listUsuarios= BLL.Metodos.FiltrarUsuarios(index, CriterioTextBox.Text, desde, hasta);
        }

        public static List<Usuario> DameUsuarios()
        {
            return listUsuarios;
        }
    }
}