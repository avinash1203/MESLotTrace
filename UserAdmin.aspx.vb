Imports System.Configuration
Imports System.Data.SqlClient
'Imports class1
Public Class UserAdmin
    Inherits System.Web.UI.Page
    Public connstr As String
    Public LogonId As String
    Public newflg As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LogonId = Request.QueryString("LogonID")

        DataEntryScr.Visible = False
        AccessDataEntryScr.Visible = False

        connstr = System.Configuration.ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
        gvContent.DataBind()
        LoginUser.Text = "User ID : " & Class1.GetuserName(LogonId)

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
        sqlstr = "SELECT COUNT(*) FROM MAST_COMPANYCODE WHERE CMP_CD = @COMPCD"
        cmd = New SqlCommand(sqlstr, myconnection)
        'cmd.Parameters.AddWithValue("@COMPCD", txtCompCd.Text)
        myconnection.Open()
        Dim ANS As Integer = cmd.ExecuteScalar
        myconnection.Close()

        If ANS > 0 And hfNewFlg.Value = 1 Then
            Class1.ShowMsg("Duplicate Company ID..Please Check!", "Continue", "warning")
            Exit Sub
        End If


        If ANS > 0 Then
            Call UpdateMastCompCd()
        Else
            Call InsertMastCompCd()
        End If
    End Sub
    Private Sub InsertMastCompCd()
        Dim sqlstr As String
        Dim cmd As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "INSERT INTO MAST_COMPANYCODE" +
                            "(CMP_CD,CMP_NM,REGR_ID,REGR_DATE,CNCL_FLG,UPD_ID,UPD_DATE)" +
                            "VALUES(" +
                            "@COMPCD,@COMPNM,@REGR_ID,@REGR_DATE,@CNCL_FLG,@UPD_ID,@UPD_DATE)"

        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)
        'cmd.Parameters.AddWithValue("@COMPCD", txtCompCd.Text.Trim)
        'cmd.Parameters.AddWithValue("@COMPNM", txtCompNm.Text.Trim)
        cmd.Parameters.AddWithValue("@REGR_ID", LogonId)
        cmd.Parameters.AddWithValue("@REGR_DATE", Format(Now, "yyyy-MM-dd HH:mm:ss"))
        cmd.Parameters.AddWithValue("@CNCL_FLG", 0)
        cmd.Parameters.AddWithValue("@UPD_ID", "")
        cmd.Parameters.AddWithValue("@UPD_DATE", "1900-01-01")
        Try
            cmd.ExecuteNonQuery()

            Class1.ShowMsg("Saved Successfully", "Ok", "success")
            DataEntryScr.Visible = False

        Catch ex As Exception
            Class1.ShowMsg("Error during Save!", "Continue", "warning")
            Exit Sub
        End Try
    End Sub
    Protected Sub UpdateMastCompCd()

        Dim sqlstr As String
        Dim cmd As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "UPDATE MAST_COMPANYCODE 
                                      SET 
                                      CMP_NM=@COMPNM,
                                       UPD_ID=@UPD_ID,
                                       UPD_DATE= @UPD_DATE
                                       WHERE 
                                       CMP_CD=@COMPCD"

        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)
        'cmd.Parameters.AddWithValue("@COMPCD", txtCompCd.Text.Trim)
        'cmd.Parameters.AddWithValue("@COMPNM", txtCompNm.Text.Trim)
        cmd.Parameters.AddWithValue("@UPD_ID", LogonId)
        cmd.Parameters.AddWithValue("@UPD_DATE", Format(Now, "yyyy-MM-dd HH:mm:ss"))
        Try
            cmd.ExecuteNonQuery()

            Class1.ShowMsg("Updated Successfully", "Ok", "success")
            DataEntryScr.Visible = False
        Catch ex As Exception
            Class1.ShowMsg("Error during Update!", "Continue", "warning")
            Exit Sub
        End Try

    End Sub
    Private Sub Retrieve(ByVal compcd As String)
        Dim sqlstr As String
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "SELECT " +
                            "CMP_CD,CMP_NM " +
                               "FROM MAST_COMPANYCODE " +
                               "WHERE CMP_CD = '" & compcd & "'"

        myconnection.Open()
        'cmd = New SqlCommand(sqlstr, myconnection)
        Dim sda As New SqlDataAdapter
        Dim dt As New DataTable

        Try
            sda = New SqlDataAdapter(sqlstr, myconnection)
            sda.Fill(dt)


        Catch ex As Exception
            Class1.ShowMsg("Error during Save!", "Continue", "warning")
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

    Protected Sub gvContent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvContent.SelectedIndexChanged
        Dim rw As Integer = gvContent.SelectedIndex
        Dim compcd As String
        compcd = gvContent.Rows(rw).Cells(1).Text
        DataEntryScr_Clear()
        DataEntryScr.Visible = True
        newflg = 0
        hfNewFlg.Value = 0
        Call Retrieve(compcd)
    End Sub
    Protected Sub ImageButton3_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton3.Click
        Response.Redirect("AppMainpage.aspx?LogonID=" & LogonId & "&Op=1")
    End Sub

    Protected Sub gvContent_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvContent.RowCommand

        Dim empno As String = gvContent.Rows(Val(e.CommandArgument.ToString())).Cells(1).Text
        Dim empname As String = gvContent.Rows(Val(e.CommandArgument.ToString())).Cells(2).Text
        Dim cmd As String = e.CommandName
        Select Case cmd
            Case "Edit"
                DataEntryScr.Visible = True
                AccessDataEntryScr.Visible = False
            Case "Access"
                '   Response.Redirect("AppAccessControl.aspx?LogonID=" & LogonId & "&Empno=" & empno)
                DataEntryScr.Visible = False
                txtEmpNoAcc.Text = empno
                txtEmpNameAcc.Text = empname
                AccessDataEntryScr.Visible = True
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

        ClearAllCheckBox(Me)
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

End Class