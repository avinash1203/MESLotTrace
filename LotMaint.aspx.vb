Public Class LotMaint
          Inherits System.Web.UI.Page
          Public LogonID As String
          Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
                    LogonID = Request.QueryString("LogonID")
          End Sub

          Protected Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Response.Redirect("AppMainpage.aspx?LogonID=" & LogonID & "&Op=3")
    End Sub
End Class