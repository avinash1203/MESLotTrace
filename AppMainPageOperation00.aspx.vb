﻿Imports System.Drawing
Imports MESLotTrace.Class1
Public Class AppMainPageOperation00
          Inherits System.Web.UI.Page
          Public LogonID As String
          Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
                    LogonID = Request.QueryString("LogonID")
                    txtLogonID.Text = LogonID
                    txtLogonName.Text = GetuserName(LogonID)
          End Sub

          Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click

          End Sub

          Protected Sub ImageButton12_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton12.Click
                    Response.Redirect("AppMainPage.aspx?LogonID=" & LogonID)
          End Sub

          Protected Sub ImageButton7_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton7.Click
                    Response.Redirect("LotMaint.aspx?LogonID=" & LogonID)
          End Sub
End Class