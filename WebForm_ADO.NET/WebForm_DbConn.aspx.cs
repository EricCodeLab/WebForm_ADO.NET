using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebSockets;

namespace WebForm_ADO.NET
{
    public partial class WebForm_DbConn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable queryResult = FindAll();
                BindGrid(GridView1,queryResult);
            }
        }

        protected DataTable FindAll()
        {
            string query = "SELECT TOP(100) * FROM dbo.Customers";
            DatabaseHelper dbHelper = new DatabaseHelper();
            DataTable dataTable = dbHelper.ExecuteQuery(query);

            return dataTable;
        }

        private void BindGrid(GridView gridView,object data)
        {
            gridView.DataSource = data;
            gridView.DataBind();
        }
    }
}