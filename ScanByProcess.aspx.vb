Public Class ScanByProcess
    Inherits System.Web.UI.Page
    Dim LogonID As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LogonID = Request.QueryString("LogonID")
        If Not IsPostBack Then
            Call ClrScr()
        End If
        ClientScript.GetPostBackEventReference(Me, "")
        If IsPostBack Then
            Dim eventTarget As String = Request("__EVENTTARGET")
            If eventTarget = "F1KeyPressed" Then
                HandleF1KeyPress()
            End If
        End If
    End Sub
    Private Sub HandleF1KeyPress()
        ' Your server-side method logic here
        Response.Write("<script>alert('F1 key was pressed!');</script>")
    End Sub

    Protected Sub ClrScr()
        txtLineID.Text = String.Empty
        txtProcCd.Text = String.Empty
        txtStepCd.Text = String.Empty
        txtShiftcd.Text = String.Empty
        txtStatus.Text = String.Empty
        txtManuLotNo.Text = String.Empty
        txtInTime.Text = String.Empty
        txtOprID.Focus()
        txtOprID.Text = String.Empty
    End Sub

    Protected Sub btnF4_Click(sender As Object, e As EventArgs) Handles btnF4.Click
        Call ClrScr()
        Response.Redirect("MainScr.aspx?LogonID=" & LogonID)
    End Sub
    Protected Sub btnF1_Click(sender As Object, e As EventArgs) Handles btnF1.Click
        Class1.ShowMsg("F1 was pressed", "OK", "success")

    End Sub

End Class