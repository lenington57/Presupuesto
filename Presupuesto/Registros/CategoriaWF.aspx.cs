﻿using BLL;
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
                Response.Write("<script>alert('Ingrese una Descripción');</script>");
                paso = true;
            }
            if (String.IsNullOrWhiteSpace(montoMensualTextBox.Text))
            {
                Response.Write("<script>alert('Ingrese un Monto');</script>");
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
                    Response.Write("<script>alert('Guardado');</script>");
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
            BLL.Repositorio<Categoria> repositorio = new BLL.Repositorio<Categoria>();
            int id = ToInt(categoriaIdTextBox.Text);

            var categoria = repositorio.Buscar(id);

            if (categoria != null)
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