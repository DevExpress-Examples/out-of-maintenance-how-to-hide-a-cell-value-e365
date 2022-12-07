using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace HideColumnCellValues {
    public partial class _Default : System.Web.UI.Page {
        protected void Page_Init(object sender, EventArgs e) {
            ASPxGridView1.DataSource = GetData();
            ASPxGridView1.KeyFieldName = "ID";
            ASPxGridView1.DataBind();
        }

        private object GetData() {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("IsVisible", typeof(bool));
            table.Columns.Add("Value", typeof(decimal));
            for(int i = 0; i < 8; i++) {
                table.Rows.Add(i, i % 2 == 0, i * 0.25);
            }
            return table;
        }

        protected void ASPxGridView1_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridViewTableDataCellEventArgs e) {
            if(e.DataColumn.FieldName == "Value") {
                object isVisible = ASPxGridView1.GetRowValues(e.VisibleIndex, "IsVisible");
                if(!true.Equals(isVisible))
                    e.Cell.Text = "&nbsp;"; // non-breaking space symbol
            }
        }
    }
}
