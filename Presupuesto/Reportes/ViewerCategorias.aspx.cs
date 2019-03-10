using BLL;
using Entities;
using Microsoft.Reporting.WebForms;
using Presupuesto.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presupuesto.Reportes
{
    public partial class ViewerCategorias : System.Web.UI.Page
    {
        public static List<Categoria> listCategorias { get; set; }
        Expression<Func<Categoria, bool>> filtro = p => true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MyReportViewer.ProcessingMode = ProcessingMode.Local;
                MyReportViewer.Reset();
                MyReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ListaCategorias.rdlc");
                MyReportViewer.LocalReport.DataSources.Clear();
                MyReportViewer.LocalReport.DataSources.Add(new ReportDataSource("CategoriasDataSet", FCategorias(filtro)));
                MyReportViewer.LocalReport.Refresh();
            }

        }

        public List<Categoria> FCategorias(Expression<Func<Categoria, bool>> filtro)
        {
            filtro = p => true;
            Repositorio<Categoria> repositorio = new Repositorio<Categoria>();
            List<Categoria> list = new List<Categoria>();            

            list = repositorio.GetList(filtro);

            return list;
        }
    }
}