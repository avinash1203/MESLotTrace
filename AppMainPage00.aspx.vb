Imports MESLotTrace.Class1
Public Class AppMainPage00
          Inherits System.Web.UI.Page
          Public LogonID As String
          Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
                    LogonID = Request.QueryString("LogonID")
                    txtLogonID.Text = LogonID
                    txtLogonName.Text = GetuserName(LogonID)

          End Sub

          Protected Sub LK1_Click(sender As Object, e As EventArgs) Handles LK1.Click
                    doc1.Src = "ImportFunction.aspx"
          End Sub

          Protected Sub LK2_Click(sender As Object, e As EventArgs) Handles LK2.Click
                    doc1.Src = "MasterMaintFunction.aspx"
          End Sub

          Protected Sub LK3_Click(sender As Object, e As EventArgs) Handles LK3.Click
                    doc1.Src = "OperationFunction.aspx"
          End Sub

          Protected Sub LK4_Click(sender As Object, e As EventArgs) Handles LK4.Click
                    doc1.Src = "ReportingFunction.aspx"
          End Sub

          Protected Sub LK5_Click(sender As Object, e As EventArgs) Handles LK5.Click
                    doc1.Src = "ExportFunction.aspx"
          End Sub
End Class