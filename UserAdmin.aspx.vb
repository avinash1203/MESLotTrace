Imports System.Configuration
Imports System.Data.SqlClient
'Imports class1
Public Class UserAdmin
    Inherits System.Web.UI.Page
    Public connstr As String
    Public LogonId As String
    Public newflg As Integer
    Dim adminDataKeys() As String = {"User_Administration", "Access_Control"}
    Dim masterMaintenanceDataKeys() As String = {"Maintenance_Line_State", "Standard_UOM", "Shift", "Prod_Capa_shift", "Line", "Process", "Company_Code", "Equipment", "Step_Equipment", "Trace_Master", "Comp_Cons_Step", "Reason_Master", "Worker_Registration", "Plant_Code"}
    Dim operationsDataKeys() As String = {"Lot_Management", "Rework", "Scrap_Item", "Print_Tag", "PLC_Data_Amend"}
    Dim reportingDataKeys() As String = {"Reporting_Line_State", "SNO_Current", "SNO_History", "Skip_NG", "Parts_Consumption", "Lot_Traceability", "Motor_docking_Comp", "Part_Balance", "Worker_Log_Information", "Manu_Lot_Info_History", "Parts_Scrap_History"}
    Dim sAPdataKeys As New List(Of String) From {"Material_Master", "Production_Order", "Prod_Order_Comp", "Vendor_UOM"}
    Dim exportdataKeys As New List(Of String) From {"Work_Result", "Parts_Consumed", "Scrap_Informationt"}

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoginUser.Text = "User ID : " & Class1.GetuserName(LogonId)
        connstr = System.Configuration.ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
        LogonId = Request.QueryString("LogonID")
        If Not IsPostBack Then
            DataEntryScr.Visible = False
            AccessDataEntryScr.Visible = False
            gvContent.DataBind()
        End If


    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Call SaveData()
        gvContent.DataBind()

    End Sub
    Protected Sub SaveData()
        Dim sqlstr As String
        Dim cmd As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)
        sqlstr = "SELECT COUNT(*) FROM USERMASTER  WHERE EMPNO = @EMPNO"
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@EMPNO", txtEmpno.Text)
        myconnection.Open()
        Dim ANS As Integer = cmd.ExecuteScalar
        myconnection.Close()

        If ANS > 0 And hfNewFlg.Value = 1 Then
            Class1.ShowMsg("Duplicate EMPLOYEE Number....Please Check!", "Continue", "warning")
            Exit Sub
        End If


        If ANS > 0 Then
            Call UpdateUserMaster()
        Else
            Call InsertUserMaster()
        End If
    End Sub
    Private Sub InsertUserMaster()
        Dim sqlstr As String
        Dim cmd As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "INSERT INTO USERMASTER " +
                            "(EMPNO,LOGINID,USERNAME,PASSWORD,USERROLE,USERSTATUS,PRINTIP)" +
                            "VALUES(" +
                            "@EMPNO,@EMPNO,@USERNAME,@PASSWORD,@USERROLE,@USERSTATUS,@PRINTIP)"

        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@EMPNO", txtEmpno.Text.Trim)
        cmd.Parameters.AddWithValue("@USERNAME", txtEmpNm.Text.Trim)
        cmd.Parameters.AddWithValue("@PASSWORD", txtPwd.Text.Trim)
        cmd.Parameters.AddWithValue("@USERROLE", ddUserRole.SelectedValue)
        cmd.Parameters.AddWithValue("@USERSTATUS", ddUserStatus.SelectedValue)
        cmd.Parameters.AddWithValue("@PRINTIP", txtAssignedIP.Text.Trim)

        Try
            cmd.ExecuteNonQuery()

            Class1.ShowMsg("Saved Successfully", "Ok", "success")
            DataEntryScr.Visible = False

        Catch ex As Exception
            Class1.ShowMsg("Error during Save!", "Continue", "warning")
            Exit Sub
        End Try
    End Sub
    Protected Sub UpdateUserMaster()

        Dim sqlstr As String
        Dim cmd As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "UPDATE USERMASTER  
                                      SET 
                                      USERNAME=@USERNAME,
                                      PASSWORD=@PASSWORD,
                                      USERROLE=@USERROLE,
                                      USERSTATUS=@USERSTATUS,
                                      PRINTIP=@PRINTIP 
                                      WHERE EMPNO = @EMPNO"

        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@EMPNO", txtEmpno.Text.Trim)
        cmd.Parameters.AddWithValue("@USERNAME", txtEmpNm.Text.Trim)
        cmd.Parameters.AddWithValue("@PASSWORD", txtPwd.Text.Trim)
        cmd.Parameters.AddWithValue("@USERROLE", ddUserRole.SelectedValue)
        cmd.Parameters.AddWithValue("@USERSTATUS", ddUserStatus.SelectedValue)
        cmd.Parameters.AddWithValue("@PRINTIP", txtAssignedIP.Text.Trim)
        Try
            cmd.ExecuteNonQuery()

            Class1.ShowMsg("Updated Successfully", "Ok", "success")
            DataEntryScr.Visible = False
        Catch ex As Exception
            Class1.ShowMsg("Error during Update!", "Continue", "warning")
            Exit Sub
        End Try

    End Sub
    Private Sub RetrieveEmpData(ByVal EMPNO As String)
        Dim sqlstr As String
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "SELECT " +
                            "USERNAME, PASSWORD,USERROLE,USERSTATUS,PRINTIP " +
                               "FROM USERMASTER " +
                               "WHERE EMPNO= '" & EMPNO & "'"

        myconnection.Open()
        'cmd = New SqlCommand(sqlstr, myconnection)
        Dim sda As New SqlDataAdapter
        Dim dt As New DataTable

        Try
            sda = New SqlDataAdapter(sqlstr, myconnection)
            sda.Fill(dt)
            txtEmpno.Text = EMPNO
            txtEmpno.Enabled = False
            txtEmpNm.Text = dt.Rows(0).Item(0)
            txtPwd.Text = dt.Rows(0).Item(1)
            ddUserRole.SelectedValue = dt.Rows(0).Item(2)
            ddUserStatus.SelectedValue = dt.Rows(0).Item(3)
            txtAssignedIP.Text = dt.Rows(0).Item(4)
            hfNewFlg.Value = 0
        Catch ex As Exception
            Class1.ShowMsg("Error during Retrieve!", "Continue", "warning")
            Exit Sub
        End Try
    End Sub

    Private Sub DataEntryScr_Clear()


    End Sub
    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DataEntryScr_Clear()
        DataEntryScr.Visible = False

    End Sub

    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        newflg = 1
        hfNewFlg.Value = 1
        DataEntryScr_Clear()
        DataEntryScr.Visible = True

    End Sub
    Protected Sub ImageButton3_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton3.Click
        Response.Redirect("AppMainpage.aspx?LogonID=" & LogonId & "&Op=1")
    End Sub

    Protected Sub gvContent_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvContent.RowCommand

        Dim empno As String = gvContent.Rows(Val(e.CommandArgument.ToString())).Cells(1).Text
        Dim empname As String = gvContent.Rows(Val(e.CommandArgument.ToString())).Cells(2).Text
        Dim cmd As String = e.CommandName
        Select Case cmd
            Case "Select"
                DataEntryScr.Visible = True
                hfNewFlg.Value = 0
                DataEntryScr_Clear()
                AccessDataEntryScr.Visible = False
                Call RetrieveEmpData(empno)
            Case "Access"
                '   Response.Redirect("AppAccessControl.aspx?LogonID=" & LogonId & "&Empno=" & empno)
                DataEntryScr.Visible = False
                DataEntryScr_Clear()
                txtEmpNoAcc.Text = empno
                txtEmpNameAcc.Text = empname
                AccessDataEntryScr.Visible = True
                ClearAllCheckBox(AccessDataEntryScr)
                RetrieveAccess()
        End Select
    End Sub
    Protected Sub RetrieveAccess()
        Dim sqlstr As String
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "SELECT " +
                            "Acc " +
                               "FROM UserAccess " +
                               "WHERE EmpNo = '" & txtEmpNoAcc.Text.Trim & "'"

        myconnection.Open()
        Dim sda As New SqlDataAdapter
        Dim dt As New DataTable
        Try
            sda = New SqlDataAdapter(sqlstr, myconnection)
            sda.Fill(dt)
            CheckCheckBoxes(dt)
        Catch ex As Exception
            Class1.ShowMsg("Error during Save!", "Continue", "warning")
            Exit Sub
        End Try
    End Sub
    Private Sub CheckCheckBoxes(dataTable As DataTable)
        ' Get all checkboxes on the page
        Dim checkBoxes As List(Of CheckBox) = GetAllCheckBoxes(Me)
        Dim keysToCheck As New HashSet(Of String)(dataTable.Rows.Cast(Of DataRow).Select(Function(row) row("Acc").ToString()))

        For Each cb As CheckBox In checkBoxes
            Dim dataKey As String = cb.Attributes("data-key")
            If Not String.IsNullOrEmpty(dataKey) AndAlso keysToCheck.Contains(dataKey) Then
                If adminDataKeys.Contains(dataKey) Then
                    cbAdministration.Checked = True
                End If

                If masterMaintenanceDataKeys.Contains(dataKey) Then
                    cbMasterMaintenance.Checked = True
                End If

                If operationsDataKeys.Contains(dataKey) Then
                    cb4.Checked = True
                End If

                If reportingDataKeys.Contains(dataKey) Then
                    cb5.Checked = True
                End If
                If sAPdataKeys.Contains(dataKey) Then
                    cb6.Checked = True
                End If
                If exportdataKeys.Contains(dataKey) Then
                    cbExporttoSAP.Checked = True
                End If


                cb.Checked = True
            End If
        Next
    End Sub
    Private Function GetAllCheckBoxes(parent As Control) As List(Of CheckBox)
        Dim checkBoxes As New List(Of CheckBox)()
        For Each control As Control In parent.Controls
            If TypeOf control Is CheckBox Then
                checkBoxes.Add(CType(control, CheckBox))
            ElseIf control.HasControls() Then
                checkBoxes.AddRange(GetAllCheckBoxes(control))
            End If
        Next
        Return checkBoxes
    End Function
    Protected Sub btnSaveAccess_Click(sender As Object, e As EventArgs) Handles btnSaveAccess.Click
        Call DelOldAccess(txtEmpNoAcc.Text.Trim)
        '
        Dim checkedCheckBoxes As List(Of CheckBox) = GetCheckedCheckBoxes(Me)
        If checkedCheckBoxes.Count = 0 Then
            Class1.ShowMsg("No checkboxes were checked.", "Continue", "warning")
            Return
        End If


        Dim values As New List(Of String)()
        For Each cb As CheckBox In checkedCheckBoxes

            Dim dataKey As String = If(cb.Attributes("data-key"), String.Empty)
            If Not String.IsNullOrEmpty(dataKey) Then
                values.Add($"('{txtEmpNoAcc.Text.Trim}', '{dataKey}')")
            End If
        Next

        Dim insertQuery As String = "INSERT INTO UserAccess (EmpNo,Acc) VALUES " & String.Join(",", values)
        Dim cmd As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)
        cmd = New SqlCommand(insertQuery, myconnection)
        myconnection.Open()
        cmd.ExecuteNonQuery()
        myconnection.Close()

        ClearAllCheckBox(AccessDataEntryScr)
        AccessDataEntryScr.Visible = False

    End Sub



    Private Sub ClearAllCheckBox(parent As Control)

        For Each control As Control In parent.Controls
            If TypeOf control Is CheckBox AndAlso CType(control, CheckBox).Checked Then
                CType(control, CheckBox).Checked = False
            End If
        Next
    End Sub

    Private Function GetCheckedCheckBoxes(parent As Control) As List(Of CheckBox)
        Dim checkedCheckBoxes As New List(Of CheckBox)()
        For Each control As Control In parent.Controls
            If TypeOf control Is CheckBox AndAlso CType(control, CheckBox).Checked Then
                checkedCheckBoxes.Add(CType(control, CheckBox))
            ElseIf control.HasControls() Then
                checkedCheckBoxes.AddRange(GetCheckedCheckBoxes(control))
            End If
        Next
        Return checkedCheckBoxes
    End Function
    Protected Sub DelOldAccess(ByVal Empno As String)
        Dim sqlstr As String
        Dim cmd As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)
        sqlstr = "DELETE FROM USERACCESS WHERE Empno ='" & Trim(Empno) & "' "
        cmd = New SqlCommand(sqlstr, myconnection)
        myconnection.Open()
        cmd.ExecuteNonQuery()
        myconnection.Close()
    End Sub

    Protected Sub cbAdministration_CheckedChanged(sender As Object, e As EventArgs) Handles cbAdministration.CheckedChanged
        Dim dataKeys As List(Of String) = New List(Of String)(adminDataKeys)
        CheckSpecificheckBox(GetAllCheckBoxes(Me), dataKeys, cbAdministration.Checked)
    End Sub


    Private Sub CheckSpecificheckBox(ByVal checkBoxs As List(Of CheckBox), ByVal dataKeys As List(Of String), ByVal checked As Boolean)
        For Each cb As CheckBox In checkBoxs
            Dim dataKey As String = cb.Attributes("data-key")
            If Not String.IsNullOrEmpty(dataKey) AndAlso dataKeys.Contains(dataKey) Then
                cb.Checked = checked
            End If
        Next
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        AccessDataEntryScr.Visible = False
        ClearAllCheckBox(AccessDataEntryScr)
    End Sub

    Protected Sub cbMasterMaintenance_CheckedChanged(sender As Object, e As EventArgs) Handles cbMasterMaintenance.CheckedChanged
        Dim dataKeys As List(Of String) = New List(Of String)(masterMaintenanceDataKeys)
        CheckSpecificheckBox(GetAllCheckBoxes(Me), dataKeys, cbMasterMaintenance.Checked)
    End Sub

    Protected Sub cbExporttoSAP_CheckedChanged(sender As Object, e As EventArgs) Handles cbExporttoSAP.CheckedChanged
        Dim dataKeys As List(Of String) = New List(Of String)(exportdataKeys)
        CheckSpecificheckBox(GetAllCheckBoxes(Me), dataKeys, cbExporttoSAP.Checked)
    End Sub

    Protected Sub cb6_CheckedChanged(sender As Object, e As EventArgs) Handles cb6.CheckedChanged
        Dim dataKeys As List(Of String) = New List(Of String)(sAPdataKeys)
        CheckSpecificheckBox(GetAllCheckBoxes(Me), dataKeys, cb6.Checked)
    End Sub

    Protected Sub cb5_CheckedChanged(sender As Object, e As EventArgs) Handles cb5.CheckedChanged
        Dim dataKeys As List(Of String) = New List(Of String)(reportingDataKeys)
        CheckSpecificheckBox(GetAllCheckBoxes(Me), dataKeys, cb5.Checked)
    End Sub

    Protected Sub cb4_CheckedChanged(sender As Object, e As EventArgs) Handles cb4.CheckedChanged
        Dim dataKeys As List(Of String) = New List(Of String)(operationsDataKeys)
        CheckSpecificheckBox(GetAllCheckBoxes(Me), dataKeys, cb4.Checked)
    End Sub
End Class