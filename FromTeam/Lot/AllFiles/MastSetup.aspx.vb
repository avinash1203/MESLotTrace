Imports System.Data.SqlClient

Public Class MastSetup
    Inherits System.Web.UI.Page

    Public connstr As String
    Public Logonid As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Logonid = Request.QueryString("LogonID")
        ' Logonid = "9900"
        DataEntryScr.Visible = False

        connstr = System.Configuration.ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString


    End Sub


    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Call SaveData()
    End Sub
    Protected Sub SaveData()
        Dim sqlstr As String
        Dim cmd As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)
        sqlstr = "SELECT COUNT(*) FROM MAST_STEP WHERE proc_flow_id = @proc_flow_id AND line_id = @line_id AND step_cd =@step_cd"
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@proc_flow_id", ddlLprocId.SelectedValue)
        cmd.Parameters.AddWithValue("@line_id", ddlLineId.SelectedValue)
        cmd.Parameters.AddWithValue("@step_cd", txtSC.Text.Trim)
        myconnection.Open()
        Dim ANS As Integer = cmd.ExecuteScalar
        myconnection.Close()

        If ANS > 0 And hfPopUpType.Value = "New" Then
            Class1.ShowMsg("Duplicate Process ID,Line ID, Step code .Please Check!", "Continue", "warning")
            Exit Sub
        End If

        If ANS > 0 Then
            Call UpdateMastSetup()
        Else
            Call InsertMastSetup()
        End If
        gvContent.DataBind()
    End Sub


    Private Sub InsertMastSetup()
        Dim sqlstr As String
        Dim cmd As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "INSERT INTO MAST_STEP" +
                        "(cmp_cd,
                          plnt_cd,
                          line_id,
                          proc_flow_id,
                          step_cd,
                          in_process_order,
                          step_name,
                          se_step_flg,
                          serial_no_div,
                          cncl_flg,
                          regr_utc,
                          regr_id,
                          notes)" +
                          "VALUES(" +
                            "@cmp_cd,@plnt_cd,@line_id,@proc_flow_id,@step_cd,@in_process_order,@step_name," +
                            "@se_step_flg,@serial_no_div,@CNCL_FLG,@regr_utc,@regr_id,@notes)"

        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@cmp_cd", ddlCC.SelectedValue)
        cmd.Parameters.AddWithValue("@plnt_cd", ddlPC.SelectedValue)
        cmd.Parameters.AddWithValue("@line_id", ddlLineId.SelectedValue)
        cmd.Parameters.AddWithValue("@proc_flow_id", ddlLprocId.SelectedValue)
        cmd.Parameters.AddWithValue("@step_cd", txtSC.Text)
        cmd.Parameters.AddWithValue("@in_process_order", Val(txtPON.Text))
        cmd.Parameters.AddWithValue("@step_name", txtSD.Text)
        cmd.Parameters.AddWithValue("@se_step_flg", Val(txtISE.Text))
        cmd.Parameters.AddWithValue("@serial_no_div", Val(txtSCT.Text))
        cmd.Parameters.AddWithValue("@CNCL_FLG", 0)
        cmd.Parameters.AddWithValue("@regr_utc", Format(Now, "yyyy-MM-dd HH:mm:ss"))
        cmd.Parameters.AddWithValue("@regr_id", Logonid)
        cmd.Parameters.AddWithValue("@notes", txtRe.Text)
        Try
            cmd.ExecuteNonQuery()
            Class1.ShowMsg("Saved Successfully", "Ok", "success")
            DataEntryScr.Visible = False
        Catch ex As Exception
            Class1.ShowMsg("Error during Save!", "Continue", "warning")
            Exit Sub
        End Try
    End Sub
    Protected Sub UpdateMastSetup()

        Dim sqlstr As String
        Dim cmd As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "UPDATE MAST_STEP" +
                        "SET 
                          cmp_cd=@cmp_cd,
                          plnt_cd=@plnt_cd
                          line_id=@line_id,
                          proc_flow_id=@proc_flow_id,
                          step_cd=@step_cd,
                          in_process_order=@in_process_order,
                          step_name=@step_name,
                          se_step_flg=@se_step_flg,
                          serial_no_div=@serial_no_div,
                          cncl_flg=@cncl_flg,
                          upd_utc=@upd_utc,
                          updr_id=@updr_id,
                          notes=@notes Where proc_flow_id = @proc_flow_id AND line_id = @line_id AND step_cd =@step_cd"

        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@cmp_cd", ddlCC.SelectedValue)
        cmd.Parameters.AddWithValue("@plnt_cd", ddlPC.SelectedValue)
        cmd.Parameters.AddWithValue("@line_id", ddlLineId.SelectedValue)
        cmd.Parameters.AddWithValue("@proc_flow_id", ddlLprocId.SelectedValue)
        cmd.Parameters.AddWithValue("@step_cd", txtSC.Text)
        cmd.Parameters.AddWithValue("@in_process_order", Val(txtPON.Text))
        cmd.Parameters.AddWithValue("@step_name", txtSD.Text)
        cmd.Parameters.AddWithValue("@se_step_flg", Val(txtISE.Text))
        cmd.Parameters.AddWithValue("@serial_no_div", Val(txtSCT.Text))
        cmd.Parameters.AddWithValue("@CNCL_FLG", 0)
        cmd.Parameters.AddWithValue("@upd_utc", Format(Now, "yyyy-MM-dd HH:mm:ss"))
        cmd.Parameters.AddWithValue("@updr_id", Logonid)
        cmd.Parameters.AddWithValue("@notes", txtRe.Text)
        Try
            cmd.ExecuteNonQuery()
            Class1.ShowMsg("Updated Successfully", "Ok", "success")
            DataEntryScr.Visible = False
        Catch ex As Exception
            Class1.ShowMsg("Error during Update!", "Continue", "warning")
            Exit Sub
        End Try

    End Sub


    Private Sub DataEntryScr_Clear()
        txtSC.Text = String.Empty
        txtPON.Text = String.Empty
        txtSD.Text = String.Empty
        txtISE.Text = String.Empty
        txtSCT.Text = String.Empty
        txtRe.Text = String.Empty
        ddlCC.ClearSelection()
        ddlPC.ClearSelection()
        ddlLineId.ClearSelection()
        ddlLprocId.ClearSelection()
        hfPopUpType.Value = ""
        ddlLineId.Enabled = True
        ddlLprocId.Enabled = True
        txtSC.ReadOnly = False
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DataEntryScr_Clear()
        DataEntryScr.Visible = False
    End Sub
    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        DataEntryScr_Clear()
        DataEntryScr.Visible = True
        hfPopUpType.Value = "New"
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        SoftDeleteReason()
        DataEntryScr_Clear()
        gvContent.DataBind()
    End Sub

    Protected Sub gvContent_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) Handles gvContent.RowCommand
        If e.CommandName = "Select" Then
            hfPopUpType.Value = "Edit"
            ddlLineId.Enabled = False
            ddlLprocId.Enabled = False
            txtSC.ReadOnly = True
            Dim resultArray() As String = e.CommandArgument.Split("_")
            GetSelected(resultArray(0), resultArray(1), resultArray(2))

        End If
    End Sub

    Protected Sub GetSelected(proc_flow_id As String, line_id As String, step_cd As String)
        connstr = System.Configuration.ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
        Dim sqlstr As String
        Dim myConnection As SqlConnection

        sqlstr = "SELECT cmp_cd,
                          plnt_cd,
                          line_id,
                          proc_flow_id,
                          step_cd,
                          in_process_order,
                          step_name,
                          se_step_flg,
                          serial_no_div,
                          cncl_flg,
                          regr_utc,
                          regr_id,
                          notes from MAST_STEP " +
             "WHERE proc_flow_id = @proc_flow_id AND line_id = @line_id AND step_cd =@step_cd"

        Dim cmd As SqlCommand

        myConnection = New SqlConnection(connstr)
        myConnection.Open()
        cmd = New SqlCommand(sqlstr, myConnection)

        cmd.Parameters.AddWithValue("@proc_flow_id", proc_flow_id)
        cmd.Parameters.AddWithValue("@line_id", line_id)
        cmd.Parameters.AddWithValue("@step_cd", step_cd)

        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)

        If dt.Rows.Count > 0 Then
            fillDetails(dt)
        Else
            Class1.ShowMsg("Error during Fetching!", "Continue", "warning")

        End If
        myConnection.Close()

    End Sub


    Protected Sub fillDetails(value As DataTable)
        DataEntryScr.Visible = True

        Dim firstCC = DirectCast(DataEntryScr.FindControl("ddlCC"), DropDownList).Items(0)
        DirectCast(DataEntryScr.FindControl("ddlCC"), DropDownList).Items.Clear()
        DirectCast(DataEntryScr.FindControl("ddlCC"), DropDownList).Items.Add(firstCC)
        DirectCast(DataEntryScr.FindControl("ddlCC"), DropDownList).DataBind()


        Dim firstPC = DirectCast(DataEntryScr.FindControl("ddlPC"), DropDownList).Items(0)
        DirectCast(DataEntryScr.FindControl("ddlPC"), DropDownList).Items.Clear()
        DirectCast(DataEntryScr.FindControl("ddlPC"), DropDownList).Items.Add(firstPC)
        DirectCast(DataEntryScr.FindControl("ddlPC"), DropDownList).DataBind()



        Dim firstLineId = DirectCast(DataEntryScr.FindControl("ddlLineId"), DropDownList).Items(0)
        DirectCast(DataEntryScr.FindControl("ddlLineId"), DropDownList).Items.Clear()
        DirectCast(DataEntryScr.FindControl("ddlLineId"), DropDownList).Items.Add(firstLineId)
        DirectCast(DataEntryScr.FindControl("ddlLineId"), DropDownList).DataBind()

        Dim firstLprocId = DirectCast(DataEntryScr.FindControl("ddlLprocId"), DropDownList).Items(0)
        DirectCast(DataEntryScr.FindControl("ddlLprocId"), DropDownList).Items.Clear()
        DirectCast(DataEntryScr.FindControl("ddlLprocId"), DropDownList).Items.Add(firstLineId)
        DirectCast(DataEntryScr.FindControl("ddlLprocId"), DropDownList).DataBind()


        If value.Rows(0).Item(0) Is String.Empty Then
            DirectCast(DataEntryScr.FindControl("ddlCC"), DropDownList).SelectedIndex = 0
        Else
            DirectCast(DataEntryScr.FindControl("ddlCC"), DropDownList).SelectedValue = value.Rows(0).Item(0)
        End If
        If value.Rows(0).Item(1) Is String.Empty Then
            DirectCast(DataEntryScr.FindControl("ddlPC"), DropDownList).SelectedIndex = 0
        Else
            DirectCast(DataEntryScr.FindControl("ddlPC"), DropDownList).SelectedValue = value.Rows(0).Item(1)
        End If

        If value.Rows(0).Item(2) Is String.Empty Then
            DirectCast(DataEntryScr.FindControl("ddlLineId"), DropDownList).SelectedIndex = 0
        Else
            DirectCast(DataEntryScr.FindControl("ddlLineId"), DropDownList).SelectedValue = value.Rows(0).Item(2)
        End If

        If value.Rows(0).Item(3) Is String.Empty Then
            DirectCast(DataEntryScr.FindControl("ddlLprocId"), DropDownList).SelectedIndex = 0
        Else
            DirectCast(DataEntryScr.FindControl("ddlLprocId"), DropDownList).SelectedValue = value.Rows(0).Item(3)
        End If


        DirectCast(DataEntryScr.FindControl("txtSC"), TextBox).Text = value.Rows(0).Item(4)
        DirectCast(DataEntryScr.FindControl("txtPON"), TextBox).Text = value.Rows(0).Item(5)
        DirectCast(DataEntryScr.FindControl("txtSD"), TextBox).Text = value.Rows(0).Item(6)
        DirectCast(DataEntryScr.FindControl("txtISE"), TextBox).Text = value.Rows(0).Item(7)
        DirectCast(DataEntryScr.FindControl("txtSCT"), TextBox).Text = value.Rows(0).Item(8)
        DirectCast(DataEntryScr.FindControl("txtRe"), TextBox).Text = value.Rows(0).Item(12)


    End Sub
    Protected Sub SoftDeleteReason()
        Dim sqlstr As String
        Dim cmd As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "UPDATE MAST_STEP" +
                        " SET CNCL_FLG = 1  WHERE proc_flow_id = @proc_flow_id AND line_id = @line_id AND step_cd =@step_cd"
        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@proc_flow_id", ddlLprocId.SelectedValue)
        cmd.Parameters.AddWithValue("@line_id", ddlLineId.SelectedValue)
        cmd.Parameters.AddWithValue("@step_cd", txtSC.Text)
        Try
            cmd.ExecuteNonQuery()
            Class1.ShowMsg("Deleted Successfully", "Ok", "success")
            DataEntryScr.Visible = False
        Catch ex As Exception
            Class1.ShowMsg("Error during Delete!", "Continue", "warning")
            Exit Sub
        End Try
    End Sub


End Class