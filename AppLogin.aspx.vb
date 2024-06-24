Imports System.Data.SqlClient
Imports System
Imports System.Web
Imports System.Configuration
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Data
Imports System.Drawing
Imports MESLotTrace.Class1

Public Class AppLogin
          Inherits System.Web.UI.Page
          Public loginsuccess As Boolean = False
          Public connstr As String
          Public usrname As String = String.Empty
          Public usrid As String
          Public usrrole As Integer

          Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

                    If Not IsPostBack Then
                              txtLogonID.Enabled = True
                              txtLogonID.Text = ""
                              txtLogonID.Focus()
                              txtPwd.Text = String.Empty
                              ' txtLogonID.BackColor = Color.Beige
                    End If
          End Sub

          Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
                    ValidateLogin()
                    If usrname <> "" Then
            Response.Redirect("AppMainPage.aspx?LogonID=" & txtLogonID.Text)
            'Response.Redirect("MainPage.aspx?LoginID=" & txtLogonID.Text.Trim)
        End If
          End Sub
          Protected Sub ValidateLogin()
                    connstr = System.Configuration.ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
                    Dim sqlstr As String
                    Dim myConnection As SqlConnection

                    sqlstr = "SELECT Username,UserRole from UserMaster " +
                 "WHERE LoginID='" & Trim(txtLogonID.Text) & "' and Password='" & Trim(txtPwd.Text) & "' and Userstatus = 9"

                    Dim cmd As SqlCommand
                    Dim i As Integer
                    myConnection = New SqlConnection(connstr)
                    myConnection.Open()
                    cmd = New SqlCommand(sqlstr, myConnection)
                    Dim da As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable
                    da.Fill(dt)

                    If dt.Rows.Count > 0 Then
                              usrname = dt.Rows(i).Item(0)
                              usrrole = dt.Rows(i).Item(1)
                    Else
                              ShowMsg("Invalid User Credentials", "Retry", "warning")
                              'Page.ClientScript.RegisterStartupScript(Me.GetType(), "test01", "javascript:dndod.alert('Invalid Username or Password');", True)
                              txtLogonID.Enabled = True
                              txtLogonID.Text = ""
                              ' txtLogonID.BackColor = Color.Beige
                              txtLogonID.Focus()
                    End If
                    myConnection.Close()

          End Sub

End Class