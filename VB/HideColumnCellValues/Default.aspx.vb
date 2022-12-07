Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Namespace HideColumnCellValues
	Partial Public Class _Default
		Inherits System.Web.UI.Page
		Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
			ASPxGridView1.DataSource = GetData()
			ASPxGridView1.KeyFieldName = "ID"
			ASPxGridView1.DataBind()
		End Sub

		Private Function GetData() As Object
			Dim table As New DataTable()
			table.Columns.Add("ID", GetType(Integer))
			table.Columns.Add("IsVisible", GetType(Boolean))
			table.Columns.Add("Value", GetType(Decimal))
			For i As Integer = 0 To 7
				table.Rows.Add(i, i Mod 2 = 0, i * 0.25)
			Next i
			Return table
		End Function

		Protected Sub ASPxGridView1_HtmlDataCellPrepared(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridViewTableDataCellEventArgs)
			If e.DataColumn.FieldName = "Value" Then
				Dim isVisible As Object = ASPxGridView1.GetRowValues(e.VisibleIndex, "IsVisible")
				If (Not True.Equals(isVisible)) Then
					e.Cell.Text = "&nbsp;" ' non-breaking space symbol
				End If
			End If
		End Sub
	End Class
End Namespace
