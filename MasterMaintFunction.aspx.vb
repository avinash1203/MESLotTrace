Public Class MasterMaintFunction
          Inherits System.Web.UI.Page

          Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

          End Sub

          Protected Sub btnMReason_Click(sender As Object, e As EventArgs) Handles btnMReason.Click
                    Response.Redirect("MastReasonMaint.aspx?Logonid=99001")
          End Sub
End Class