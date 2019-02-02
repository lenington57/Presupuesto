using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presupuesto.Registros
{
    public partial class EgresoWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            Categoria categoria = new Categoria();

            if (!Page.IsPostBack)
            {
                Repositorio<Categoria> repositorio = new Repositorio<Categoria>();

                categoriaDropDownList.DataSource = repositorio.GetList(t => true);
                categoriaDropDownList.DataValueField = "CategoriaId";
                categoriaDropDownList.DataTextField = "Descripcion";
                categoriaDropDownList.DataBind();

                ViewState["Egreso"] = new Egreso();
            }
        }

        protected void BindGrid()
        {
            egresoGridView.DataSource = ((Egreso)ViewState["Egreso"]).Detalle;
            egresoGridView.DataBind();
        }

        private int ToInt(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);

            return retorno;
        }

        public Egreso LlenarClase()
        {
            Egreso egreso = new Egreso();

            egreso = (Egreso)ViewState["Egreso"];

            egreso.EgresoId = Utilitarios.Utils.ToInt(egresoIdTextBox.Text);
            egreso.Fecha = Convert.ToDateTime(fechaTextBox.Text).Date;
            egreso.MontoGastado = ToInt(totalTextBox.Text);

            return egreso;
        }

        public void LlenarCampos(Egreso egreso)
        {
            Limpiar();
            egresoIdTextBox.Text = egreso.EgresoId.ToString();
            fechaTextBox.Text = egreso.Fecha.ToString("yyyy-MM-dd");
            this.BindGrid();
            totalTextBox.Text = egreso.MontoGastado.ToString();
        }
        protected void Limpiar()
        {
            egresoIdTextBox.Text = "0";
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            totalTextBox.Text = "";
            ViewState["Egreso"] = new Egreso();
            this.BindGrid();
        }

        protected void LimpiarDos()
        {
            egresoIdTextBox.Text = "0";
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            conceptoTextBox.Text = "";
            categoriaDropDownList.SelectedIndex = 0;
            montoTextBox.Text = "";
        }

        private bool HayErrores()
        {
            bool paso = false;
            if (String.IsNullOrEmpty(conceptoTextBox.Text))
            {
                Response.Write("<script>alert('Ingrese una Concepto');</script>");
                paso = true;
            }
            if (String.IsNullOrEmpty(montoTextBox.Text))
            {
                Response.Write("<script>alert('Ingrese un Monto');</script>");
                paso = true;
            }
            if (egresoGridView.Columns.Count == 0)
            {
                Response.Write("<script>alert('el detalle está vacío');</script>");
                paso = true;
            }
            return paso;
        }

        private void LlenarValores()
        {
            List<EgresoDetalle> detalle = new List<EgresoDetalle>();

            if (egresoGridView.DataSource != null)
            {
                detalle = (List<EgresoDetalle>)egresoGridView.DataSource;
            }
            double Total = 0;
            foreach (var item in detalle)
            {
                Total += item.MontoEgresado;
            }
            totalTextBox.Text = Total.ToString();
        }

        private void RebajarValores()
        {
            List<EgresoDetalle> detalle = new List<EgresoDetalle>();

            if (egresoGridView.DataSource != null)
            {
                detalle = (List<EgresoDetalle>)egresoGridView.DataSource;
            }
            double Total = 0;
            foreach (var item in detalle)
            {
                Total -= item.MontoEgresado;
            }
            totalTextBox.Text = Total.ToString();
        }

        protected void agregarButton_Click(object sender, EventArgs e)
        {
            Egreso egreso = new Egreso();

            egreso = (Egreso)ViewState["Egreso"];
            egreso.AgregarDetalle(0, egreso.EgresoId,
                    ToInt(categoriaDropDownList.SelectedValue), conceptoTextBox.Text, ToInt(montoTextBox.Text));

            ViewState["Egreso"] = egreso;
            
            this.BindGrid();
            LlenarValores();
            //LimpiarDos();
        }

        protected void remoerButton_Click(object sender, EventArgs e)
        {
           
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioEgresos repositorio = new RepositorioEgresos();

            var egreso = repositorio.Buscar(Utilitarios.Utils.ToInt(egresoIdTextBox.Text));
            if (egreso != null)
            {
                LlenarCampos(egreso);
                Utilitarios.Utils.ShowToastr(this, "Busqueda exitosa", "Exito");
            }
            else
            {
                Limpiar();
                Utilitarios.Utils.ShowToastr(this,
                    "No se pudo encontrar el egreso especificado",
                    "Error", "error");
            }
        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void guadarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            RepositorioEgresos repositorio = new RepositorioEgresos();
            Egreso egreso = new Egreso();
            if (HayErrores())
                Response.Write("<script>alert('Revise estos campos');</script>");
            else
            {
                egreso = LlenarClase();

                if (egreso.EgresoId == 0)
                {
                    paso = repositorio.Guardar(egreso);
                    Response.Write("<script>alert('Guardado');</script>");
                    Limpiar();
                }
                else
                {
                    Egreso egre = new Egreso();
                    RepositorioEgresos repository = new RepositorioEgresos();
                    int id = ToInt(egresoIdTextBox.Text);
                    egre = repository.Buscar(id);

                    if (egre != null)
                    {
                        paso = repository.Modificar(LlenarClase());
                        Response.Write("<script>alert('Modificado');</script>");
                    }
                    else
                        Response.Write("<script>alert('Id no existe');</script>");
                }

                if (paso)
                {
                    Limpiar();
                }
                else
                    Response.Write("<script>alert('No se pudo guardar');</script>");
            }
        }

        protected void eliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioEgresos repositorio = new RepositorioEgresos();
            int id = ToInt(egresoIdTextBox.Text);

            var egreso = repositorio.Buscar(id);

            if (egreso != null)
            {
                if (repositorio.Eliminar(id))
                {
                    Response.Write("<script>alert('Eliminado');</script>");
                    Limpiar();
                }
                else
                    Response.Write("<script>alert('No se pudo eliminar');</script>");
            }
            else
                Response.Write("<script>alert('No existe');</script>");
        }
        
    }
}