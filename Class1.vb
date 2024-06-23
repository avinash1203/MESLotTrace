Imports Microsoft.VisualBasic
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
Imports System.IO
Public Class Class1
    Public Shared cp As Class1
    Public Shared Sub ShowMsg(ByVal Msg As String, msgbtn As String, msgtype As String)
        Dim sMessage As String = ShowMsgSetup(Msg, msgbtn, msgtype)

        If TypeOf HttpContext.Current.CurrentHandler Is Page Then
            Dim p As Page = CType(HttpContext.Current.CurrentHandler, Page)

            If ScriptManager.GetCurrent(p) IsNot Nothing Then
                ScriptManager.RegisterStartupScript(p, GetType(Page), "Message", sMessage, True)
            Else
                p.ClientScript.RegisterStartupScript(GetType(Page), "Message", sMessage, True)
            End If
        End If
    End Sub


    Public Shared Function DropDownHasVale(ByVal ddl As DropDownList, ByVal value As String) As Boolean
        Dim valueExists As Boolean = ddl.Items.Cast(Of ListItem)().Any(Function(item) item.Value = value)
        Return valueExists
    End Function

    Public Shared Sub SetDropDownVale(ByVal htmlgen As HtmlGenericControl, ByVal ddlId As String, ByVal value As Object)
        Dim ddl = DirectCast(htmlgen.FindControl(ddlId), DropDownList)
        ddl.ClearSelection()
        If value Is String.Empty Or value Is DBNull.Value Then
            ddl.SelectedIndex = 0
            Return
        Else
            If DropDownHasVale(ddl, value) Then
                ddl.SelectedValue = value
            Else
                'ddl.Enabled = True
                ddl.SelectedIndex = 0
            End If
            Return
        End If
    End Sub




    Public Shared Function GetLoginId(ByVal request As HttpRequest) As String
        Dim LogonID As String = request.QueryString("LogonID")
        If LogonID Is Nothing Then
            LogonID = request.QueryString("LoginID")
        End If
        Return LogonID
    End Function

    Public Shared Sub ConvertDbNullToEmptyString(ByRef dt As DataTable)
        For Each row As DataRow In dt.Rows
            For Each column As DataColumn In dt.Columns
                If IsDBNull(row(column)) Then
                    row(column) = String.Empty
                End If
            Next
        Next
    End Sub
    Public Shared Sub ShowMsgURL(ByVal Msg As String, msgbtn As String, msgtype As String, url As String)
        Dim sMessage As String = ShowMsgURLSetup(Msg, msgbtn, msgtype, url)

        If TypeOf HttpContext.Current.CurrentHandler Is Page Then
            Dim p As Page = CType(HttpContext.Current.CurrentHandler, Page)

            If ScriptManager.GetCurrent(p) IsNot Nothing Then
                ScriptManager.RegisterStartupScript(p, GetType(Page), "Message", sMessage, True)
            Else
                p.ClientScript.RegisterStartupScript(GetType(Page), "Message", sMessage, True)
            End If
        End If
    End Sub
    Public Shared Function ShowMsgSetup(msg As String, btnmsg As String, msgtype As String) As String
        Dim jmsg As String

        If btnmsg = String.Empty Then
            btnmsg = "OK"
        End If
        msgtype = msgtype.Trim
        ' "default", "primary", "info", "success", "warning", "danger" (Default: "default")
        Select Case msgtype
            Case "warning"
            Case "success"
            Case "danger"
            Case "info"
            Case "primary"
            Case Else
                msgtype = "default"
        End Select
        jmsg = "javascript:dndod.popup({" +
               "msg : " & Chr(34) & msg & Chr(34) &
               ", enableHTML : true" &
               ", buttons: [" &
               "{" &
               "type: " & Chr(34) & msgtype & Chr(34) &
               ",text: " & Chr(34) & btnmsg & Chr(34) &
               ",handler: function(e, popup) " &
               "{" &
               "popup.close()" &
               "}" &
               "}" &
               "]" &
               "});"

        Return jmsg
    End Function
    Public Shared Function ShowMsgURLSetup(msg As String, btnmsg As String, msgtype As String, url As String) As String
        Dim jmsg As String

        If btnmsg = String.Empty Then
            btnmsg = "OK"
        End If
        msgtype = msgtype.Trim
        ' "default", "primary", "info", "success", "warning", "danger" (Default: "default")
        Select Case msgtype
            Case "warning"
            Case "success"
            Case "danger"
            Case "info"
            Case "primary"
            Case Else
                msgtype = "default"
        End Select
        '"javascript:dndod.popup({msg : " & Chr(34) & msg1 & Chr(34) & ",enableHTML: true, buttons: [{text:" & Chr(34) & "OK" & Chr(34) & ", type: " & Chr(34) & "warning" & Chr(34) & ",handler: function (e,popup) {window.location.href=" & Chr(34) & url & Chr(34) & ";}}]});", True)
        jmsg = "javascript:dndod.popup({" +
               "msg : " & Chr(34) & msg & Chr(34) &
               ", enableHTML : true" &
               ", buttons: [" &
               "{" &
               "type: " & Chr(34) & msgtype & Chr(34) &
               ",text: " & Chr(34) & btnmsg & Chr(34) &
               ",handler: function(e, popup) " &
               "{" &
               "window.location.href=" & Chr(34) & url & Chr(34) & ";" &
               "}" &
               "}" &
               "]" &
               "});"

        Return jmsg
    End Function

    Public Shared Function HasPermissions(empNo As String, permission As String) As Boolean
        Dim sqlstr As String
        Dim myConnection As SqlConnection
        Dim connstr As String = ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
        sqlstr = "SELECT 1 FROM UserAccess a 
            WHERE a.EmpNo ='" & empNo & "' AND a.Acc = '" & permission & "'"
        Dim cmd As SqlCommand
        '    Dim i As Integer
        myConnection = New SqlConnection(connstr)
        myConnection.Open()
        cmd = New SqlCommand(sqlstr, myConnection)
        Dim result As Object = cmd.ExecuteScalar
        myConnection.Close()
        Return If(result IsNot Nothing AndAlso result IsNot DBNull.Value, True, False)
    End Function

    Public Shared Function GetuserName(loginid As String) As String
        Dim sqlstr As String
        Dim myConnection As SqlConnection
        Dim connstr As String = ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
        sqlstr = "SELECT USERNAME from UserMaster " +
                             "WHERE LoginID = '" & loginid & "'"



        Dim cmd As SqlCommand
        '    Dim i As Integer
        myConnection = New SqlConnection(connstr)
        myConnection.Open()
        cmd = New SqlCommand(sqlstr, myConnection)
        Dim ans As String = cmd.ExecuteScalar
        myConnection.Close()
        Return ans
    End Function
    Function GetEmailID(UserID As String) As String
        Dim connstr As String = ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
        Dim tr As String
        Dim sqlstr As String
        Dim myConnection As SqlConnection
        Dim cmd As SqlCommand

        sqlstr = "SELECT Email FROM Usermanager WHERE userid ='" & UserID & "'"
        myConnection = New SqlConnection(connstr)
        myConnection.Open()

        cmd = New SqlCommand(sqlstr, myConnection)
        Try
            tr = cmd.ExecuteScalar()
        Catch ex As Exception
            tr = ""
        End Try
        myConnection.Close()
        Return tr
    End Function
    Function URLPopupmsg() As String
        'Dim url As String = "ProtocolEditor.aspx?Docno=" & Trim(txtNewProtocolNo.Text) & "&Loginid=" & loginid & "&Uid=" & userid & " "
        'Dim msg1 As String = "<h2>Protocol Document Created <br><br><h1>Successfully</h1>"
        'Page.ClientScript.RegisterStartupScript(Me.GetType(), "test02", "javascript:dndod.popup({msg : " & Chr(34) & msg1 & Chr(34) & ",enableHTML: true, buttons: [{text:" & Chr(34) & "OK" & Chr(34) & ", type: " & Chr(34) & "success" & Chr(34) & ",handler: function (e,popup) {window.location.href=" & Chr(34) & url & Chr(34) & ";}}]});", True)
        Return True
    End Function
    Function PopupMsg(msg As String, btnmsg As String, msgtype As String) As String
        Dim jmsg As String

        If btnmsg = String.Empty Then
            btnmsg = "OK"
        End If
        msgtype = msgtype.Trim
        ' "default", "primary", "info", "success", "warning", "danger" (Default: "default")
        Select Case msgtype
            Case "warning"
            Case "success"
            Case "danger"
            Case "info"
            Case "primary"
            Case Else
                msgtype = "default"
        End Select
        jmsg = "javascript:dndod.popup({" +
               "msg : " & Chr(34) & msg & Chr(34) &
               ", enableHTML : true" &
               ", buttons: [" &
               "{" &
               "type: " & Chr(34) & msgtype & Chr(34) &
               ",text: " & Chr(34) & btnmsg & Chr(34) &
               ",handler: function(e, popup) " &
               "{" &
               "popup.close()" &
               "}" &
               "}" &
               "]" &
               "});"

        Return jmsg
    End Function
    Function PopUpMsgUrl(msg As String, btnmsg As String, msgtype As String, url As String) As String
        Dim jmsg As String

        If btnmsg = String.Empty Then
            btnmsg = "OK"
        End If
        msgtype = msgtype.Trim
        ' "default", "primary", "info", "success", "warning", "danger" (Default: "default")
        Select Case msgtype
            Case "warning"
            Case "success"
            Case "danger"
            Case "info"
            Case "primary"
            Case Else
                msgtype = "default"
        End Select
        '"javascript:dndod.popup({msg : " & Chr(34) & msg1 & Chr(34) & ",enableHTML: true, buttons: [{text:" & Chr(34) & "OK" & Chr(34) & ", type: " & Chr(34) & "warning" & Chr(34) & ",handler: function (e,popup) {window.location.href=" & Chr(34) & url & Chr(34) & ";}}]});", True)
        jmsg = "javascript:dndod.popup({" +
               "msg : " & Chr(34) & msg & Chr(34) &
               ", enableHTML : true" &
               ", buttons: [" &
               "{" &
               "type: " & Chr(34) & msgtype & Chr(34) &
               ",text: " & Chr(34) & btnmsg & Chr(34) &
               ",handler: function(e, popup) " &
               "{" &
               "window.location.href=" & Chr(34) & url & Chr(34) & ";" &
               "}" &
               "}" &
               "]" &
               "});"

        Return jmsg
    End Function
    Function GetUserRole(ByVal LoginID As String) As String
        Dim sqlstr As String
        Dim myConnection As SqlConnection
        Dim connstr As String = ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
        Dim cmd As SqlCommand
        myConnection = New SqlConnection(connstr)
        sqlstr = "select UserRole from UserManager where Userid = '" & Trim(LoginID) & "'"
        myConnection.Open()
        cmd = New SqlCommand(sqlstr, myConnection)
        Dim ans As String = Trim(cmd.ExecuteScalar)
        myConnection.Close()
        Return ans
    End Function
    Function CheckUser(ByVal Userid As String, ByVal Pwd As String) As Boolean
        Dim connstr As String = System.Configuration.ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
        Dim sqlstr As String
        Dim myConnection As SqlConnection

        sqlstr = "SELECT count(*)  from UserManager " +
                 "WHERE UserId='" & Userid & "' and Pwd='" & Pwd & "' and Userstatus = 9"

        Dim cmd As SqlCommand
        Dim ans As Integer

        myConnection = New SqlConnection(connstr)
        myConnection.Open()

        cmd = New SqlCommand(sqlstr, myConnection)
        ans = cmd.ExecuteScalar()
        myConnection.Close()

        If ans > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

End Class
