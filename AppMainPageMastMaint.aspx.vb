Imports MESLotTrace.Class1
Public Class AppMainPageMastMaint
          Inherits System.Web.UI.Page
          Public LogonID As String
          Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
                    LogonID = Request.QueryString("LogonID")
                    txtLogonID.Text = LogonID
                    txtLogonName.Text = GetuserName(LogonID)
          End Sub

          Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click

          End Sub
End Class