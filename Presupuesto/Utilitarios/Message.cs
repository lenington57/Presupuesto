using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Presupuesto.Utilitarios
{
    public static class Message
    {
        public static void ShowToast(Page page, string tipo, string titulo, string mensaje)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastr_message", "toastr." + tipo + "('" + mensaje + "','" + titulo + "')", true);
        }
    }
}