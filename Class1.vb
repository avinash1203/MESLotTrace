Imports System.Data.SqlClient
Public Class DatabaseHelper
    Private connectionString As String = String.Empty
    Sub New()
        connectionString = System.Configuration.ConfigurationManager.ConnectionStrings("MESLotTraceConnectionString").ConnectionString
    End Sub
    Public Function GetData(sqlQuery As String, parameters As Dictionary(Of String, Object)) As DataTable
        Dim dataTable As New DataTable()
        Try
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(sqlQuery, connection)
                    connection.Open()

                    ' Add parameters to the command
                    For Each param In parameters
                        command.Parameters.AddWithValue(param.Key, param.Value)
                    Next

                    Using adapter As New SqlDataAdapter(command)
                        adapter.Fill(dataTable)
                        Class1.ConvertDbNullToEmptyString(dataTable)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Class1.ShowMsg(ex.Message, "Continue", "warning")
        End Try
        Return dataTable
    End Function
End Class
Public Class Class1
    Public Shared cp As Class1

    Public Shared conString As String = String.Empty
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

    Shared Sub New()
        conString = System.Configuration.ConfigurationManager.ConnectionStrings("MESLotTraceConnectionString").ConnectionString
    End Sub

    'Public Sub New()
    '    conString = System.Configuration.ConfigurationManager.ConnectionStrings("MESLotTraceConnectionString").ConnectionString
    'End Sub

    Public Shared Sub ConvertDbNullToEmptyString(ByRef dt As DataTable)
        For Each row As DataRow In dt.Rows
            For Each column As DataColumn In dt.Columns
                If IsDBNull(row(column)) Then
                    row(column) = GetDefaultValue(column)
                End If
            Next
        Next
    End Sub

    Private Shared Function GetDefaultValue(ByVal column As DataColumn) As Object
        Select Case column.DataType
            Case GetType(String)
                Return String.Empty
            Case GetType(Integer)
                Return 0
            Case GetType(Double)
                Return 0.0
            Case GetType(Boolean)
                Return False
            Case GetType(DateTime)
                Return DateTime.MinValue
            Case Else
                Return DBNull.Value ' Use DBNull for unsupported data types
        End Select
    End Function

    Public Shared Function GetMenuNameByTable(tabelName As String) As String
        Dim result As String = String.Empty
        Dim tabelWithMenu As New List(Of (String, String)) From {
        ("MAST_BOM", "Component Consumption By Step"),
        ("MAST_EQUIP", "Master Equipment"),
        ("MAST_ITEM", "Master Item"),
        ("MAST_LINE", "Master Line"),
        ("MAST_LINE01", "Master Line"),
        ("MAST_LINE2", "Master Line"),
        ("MAST_MFGLOT", "Master Lot"),
        ("MAST_MFGLOT_BOM", "Master Lot"),
        ("MAST_MFGLOT2", "Master Lot"),
        ("MAST_PROC", "Master Lot"),
        ("MAST_PROC2", "Master Process"),
        ("MAST_PROD_CAPACITY", "Master Process Capacity"),
        ("MAST_SHIFT", "Master Shift"),
        ("MAST_SHIFT2", "Master Shift"),
        ("MAST_STEP", "Master Step"),
        ("MAST_STEP_EQUIPLINK", "Master Step Equipment Link"),
        ("MAST_TRACE", "Master Trace"),
        ("MAST_VEND_UOM", "Master Uom"),
        ("MAST_PROC3", "Master Production")
    }
        Dim rec = tabelWithMenu.FirstOrDefault(Function(record) record.Item1 = tabelName)

        If rec.Equals(Nothing) Then
            Return String.Empty
        End If
        Return rec.Item2
    End Function

    Public Shared Function ValuesExistInTables(tablesColumnsValues As List(Of (String, String)), value As String) As List(Of (String, Boolean))
        Dim results As New List(Of (String, Boolean))

        Using connection As New SqlConnection(conString)
            connection.Open()
            For Each tableColumnValue In tablesColumnsValues
                Try
                    Dim tableName As String = tableColumnValue.Item1
                    Dim columnName As String = tableColumnValue.Item2
                    Dim formName As String = GetMenuNameByTable(tableName)
                    If results.Any(Function(result) result.Item1 = formName) Then Continue For

                    Dim query As String = $"SELECT COUNT(*) FROM {tableName} WHERE {columnName} = @value AND cncl_flg = 0"
                    Using command As New SqlCommand(query, connection)
                        command.Parameters.AddWithValue("@value", value)
                        Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                        results.Add((formName, count > 0))
                    End Using
                Catch ex As Exception

                End Try

            Next
        End Using

        Return results
    End Function
    Public Shared Sub GetDeletedRecord(ByVal dropdown As DropDownList, ByVal text As String, ByVal value As String)
        Dim first = dropdown.Items(0)
        dropdown.Items.Clear()
        dropdown.DataBind()
        dropdown.Items.Add(first)
        ' Check if the previously selected value is not already in the dropdown
        Dim valueExists As Boolean = dropdown.Items.Cast(Of ListItem)().Any(Function(item) item.Value = value)

        ' Add the previously selected value to the dropdown if it doesn't exist
        If Not valueExists Then
            dropdown.Items.Add(New ListItem(text & " (Deleted)", value))
        End If

        ' Set the previously selected value as selected
        dropdown.SelectedValue = value
        'dropdown.DataBind()

    End Sub

    Public Shared Function DropDownHasVale(ByVal ddl As DropDownList, ByVal value As String) As Boolean
        Dim valueExists As Boolean = ddl.Items.Cast(Of ListItem)().Any(Function(item) item.Value = value)
        Return valueExists
    End Function

    Public Shared Sub SetDropDownVale(ByVal htmlgen As HtmlGenericControl, ByVal ddlId As String, ByVal value As Object)
        Dim ddl = DirectCast(htmlgen.FindControl(ddlId), DropDownList)
        ddl.ClearSelection()
        If ddl Is Nothing Then
            Return
        End If
        If ddl.Items.Count = 0 Then
            Return
        End If

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

    Public Shared Function GeneratePartAdjSqlQuery(lineId As String, procFlowId As String, stepCd As String, equipId As String, itemCd As String, vendorCd As String, isZeroQty As Boolean) As String
        Dim query As String = "SELECT tag_seq,line_id, proc_flow_id, step_cd, equip_id, item_cd, vendor_cd, input_date, input_qty, current_qty FROM TRX_PART_INPUT"
        Dim parameters As New List(Of String)()

        If Not String.IsNullOrEmpty(lineId) Then
            parameters.Add("line_id = @lineId")
        End If
        If Not String.IsNullOrEmpty(procFlowId) Then
            parameters.Add("proc_flow_id = @procFlowId")
        End If
        If Not String.IsNullOrEmpty(stepCd) Then
            parameters.Add("step_cd = @stepCd")
        End If
        If Not String.IsNullOrEmpty(equipId) Then
            parameters.Add("equip_id = @equipId")
        End If
        If Not String.IsNullOrEmpty(itemCd) Then
            parameters.Add("item_cd = @itemCd")
        End If
        If Not String.IsNullOrEmpty(vendorCd) Then
            parameters.Add("vendor_cd = @vendorCd")
        End If

        ' Add condition for current_qty based on isZeroQty
        If isZeroQty Then
            parameters.Add("current_qty = 0")
        Else
            parameters.Add("current_qty > 0")
        End If

        If parameters.Count > 0 Then
            query &= " WHERE " & String.Join(" AND ", parameters)
        End If

        Return query
    End Function



    Public Shared Function GetLoginId(ByVal request As HttpRequest) As String
        Dim LogonID As String = request.QueryString("LogonID")
        If LogonID Is Nothing Then
            LogonID = request.QueryString("LoginID")
        End If
        Return LogonID
    End Function



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
