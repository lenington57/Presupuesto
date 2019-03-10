using BLL;
using Entities;
using Presupuesto.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presupuesto.Registros
{
    public partial class CategoriaWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void Limpiar()
        {
            categoriaIdTextBox.Text = "0";
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            descripcionTextBox.Text = "";
            montoMensualTextBox.Text = "";
        }

        private Categoria LlenaClase()
        {
            Categoria categoria = new Categoria();

            categoria.CategoriaId = ToInt(categoriaIdTextBox.Text);
            categoria.Fecha = Convert.ToDateTime(fechaTextBox.Text).Date;
            categoria.Descripcion = descripcionTextBox.Text;
            categoria.MontoMensualidad = ToInt(montoMensualTextBox.Text);

            return categoria;

        }

        private int ToInt(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);

            return retorno;
        }

        private bool HayErrores()
        {
            bool paso = false;
            if (String.IsNullOrEmpty(descripcionTextBox.Text))
            {
                Utils.ShowToastr(this, "Ingrese una Descipción", "Error", "error");
                paso = true;
            }
            if (String.IsNullOrWhiteSpace(montoMensualTextBox.Text))
            {
                Utils.ShowToastr(this, "Ingrese un Monto", "Error", "error");
                paso = true;
            }
            
            return paso;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Categoria> repositorio = new Repositorio<Categoria>();
            Categoria categoria = repositorio.Buscar(ToInt(categoriaIdTextBox.Text));
            if (categoria != null)
            {
                fechaTextBox.Text = categoria.Fecha.ToString();
                descripcionTextBox.Text = categoria.Descripcion;
                montoMensualTextBox.Text = categoria.MontoMensualidad.ToString();
            }
            else
            {
                Utils.ShowToastr(this, "No Hay Resultado", "Error", "error");
            }
        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void guadarButton_Click(object sender, EventArgs e)
        {
            BLL.Repositorio<Categoria> repositorio = new BLL.Repositorio<Categoria>();
            Categoria categoria = new Categoria();
            bool paso = false;

            if (HayErrores())
                return;
            else
            {
                //todo: validaciones adicionales
                categoria = LlenaClase();

                if (categoria.CategoriaId == 0)
                {
                    paso = repositorio.Guardar(categoria);
                    Utils.ShowToastr(this, "Guardado", "Correcto", "success");
                    Limpiar();
                }
                else
                {
                    Categoria category = new Categoria();
                    BLL.Repositorio<Categoria> repository = new BLL.Repositorio<Categoria>();
                    int id = ToInt(categoriaIdTextBox.Text);
                    category = repository.Buscar(id);

                    if (category != null)
                    {
                        paso = repository.Modificar(LlenaClase());
                        Utils.ShowToastr(this, "Modificado", "Correcto", "success");
                    }
                    else
                        Utils.ShowToastr(this, "Id no existe", "Error", "error");
                }

                if (paso)
                {
                    Limpiar();
                }
                else
                    Utils.ShowToastr(this, "No se pudo guardar", "Error", "error");
            }
        }

        protected void eliminarButton_Click(object sender, EventArgs e)
        {
            BLL.Repositorio<Categoria> repositorio = new BLL.Repositorio<Categoria>();
            int id = ToInt(categoriaIdTextBox.Text);

            var categoria = repositorio.Buscar(id);

            if (categoria != null)
            {
                if (repositorio.Eliminar(id))
                {
                    Utils.ShowToastr(this, "Eliminado", "Correcto", "success");
                    Limpiar();
                }
                else
                    Utils.ShowToastr(this, "No se pudo eliminar", "Error", "error");
            }
            else
                Utils.ShowToastr(this, "No existe", "Error", "error");
        }

        protected void descripcionTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        protected void fechaTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}