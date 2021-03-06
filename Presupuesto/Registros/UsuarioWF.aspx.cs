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
    public partial class UsuarioWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            presupuestoTextBox.Text = "0";
        }

        private void Limpiar()
        {
            usuarioIdTextBox.Text = "0";
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            nombreTextBox.Text = " ";
            emailTextBox.Text = "";
            passwordTextBox.Text = "";
            cpasswordTextBox.Text = "";
            presupuestoTextBox.Text = "0";
        }

        private Usuario LlenaClase()
        {
            Usuario usuario = new Usuario();

            usuario.UsuarioId = ToInt(usuarioIdTextBox.Text);
            usuario.Fecha = Convert.ToDateTime(fechaTextBox.Text).Date;
            usuario.Nombres = nombreTextBox.Text;
            usuario.Email = emailTextBox.Text;
            usuario.Password = passwordTextBox.Text;
            usuario.CPassword = cpasswordTextBox.Text;
            usuario.MontoPresupuesto = ToInt(presupuestoTextBox.Text);

            return usuario;

        }

        private int ToInt(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);

            return retorno;
        }

        private bool HayErrores()
        {
            bool HayErrores = false;

            string s = passwordTextBox.Text;
            string ss = cpasswordTextBox.Text;
            int comparacion = 0;
            comparacion = String.Compare(s, ss);
            if (comparacion != 0)
            {
                HayErrores = true;
            }

            return HayErrores;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Usuario> repositorio = new Repositorio<Usuario>();
            Usuario usuario = repositorio.Buscar(ToInt(usuarioIdTextBox.Text));
            if (usuario != null)
            {
                nombreTextBox.Text = usuario.Nombres;
                fechaTextBox.Text = usuario.Fecha.ToString();
                emailTextBox.Text = usuario.Email;
                passwordTextBox.Text = usuario.Password;
                cpasswordTextBox.Text = usuario.CPassword;
                presupuestoTextBox.Text = usuario.MontoPresupuesto.ToString();
            }
            else
            {
                Message.ShowToast(this, "success", "Success", "No encontrado");
            }
        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void guardarButton_Click(object sender, EventArgs e)
        {
            BLL.Repositorio<Usuario> repositorio = new BLL.Repositorio<Usuario>();
            Usuario usuario = new Usuario();
            bool paso = false;

            if (HayErrores())
                Response.Write("<script>alert('Contraseñas no concuerdan');</script>");
            else
            {
                //todo: validaciones adicionales
                usuario = LlenaClase();

                if (usuario.UsuarioId == 0)
                {
                    paso = repositorio.Guardar(usuario);
                    Response.Write("<script>alert('Guardado');</script>");
                    Limpiar();
                }
                else
                {
                    Usuario user = new Usuario();
                    int id = ToInt(usuarioIdTextBox.Text);
                    BLL.Repositorio<Usuario> repository = new BLL.Repositorio<Usuario>();
                    usuario = repository.Buscar(id);

                    if (user != null)
                    {
                        paso = repositorio.Modificar(LlenaClase());
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

        protected void eliminarutton_Click(object sender, EventArgs e)
        {
            BLL.Repositorio<Usuario> repositorio = new BLL.Repositorio<Usuario>();
            int id = ToInt(usuarioIdTextBox.Text);

            var usuario = repositorio.Buscar(id);

            if (usuario != null)
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