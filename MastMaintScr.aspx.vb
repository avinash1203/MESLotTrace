Public Class MastMaintScr
          Inherits System.Web.UI.Page

          Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

          End Sub

    Protected Sub gvContent_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvContent.PageIndex = e.NewPageIndex
        gvContent.DataBind()
    End Sub
End Class