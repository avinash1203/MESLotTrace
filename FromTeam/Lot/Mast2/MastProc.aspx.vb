Imports System.Data.SqlClient

Public Class MastProc
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
        sqlstr = "SELECT COUNT(*) FROM MAST_PROC WHERE proc_flow_id = @proc_flow_id AND CNCL_FLG = 0"
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@proc_flow_id", ddlPFID.SelectedValue)

        myconnection.Open()
        Dim ANS As Integer = cmd.ExecuteScalar
        myconnection.Close()

        If ANS > 0 And hfPopUpType.Value = "New" Then
            Class1.ShowMsg("Duplicate Process Flow ID.Please Check!", "Continue", "warning")
            Exit Sub
        End If

        If ANS > 0 Then
            Call UpdateMastProd()
        Else
            Call InsertMastProd()
        End If
        gvContent.DataBind()
    End Sub


    Private Sub InsertMastProd()
        Dim sqlstr As String
        Dim cmd As SqlCommand

        Dim sqlstr2 As String
        Dim cmd2 As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "INSERT INTO MAST_PROC" +
                        "([cmp_cd]
                          ,[plnt_cd]
                          ,[proc_flow_id]
                          ,[lproc_id]
                          ,[proc_flow_nm]
                          ,[proc_seq]
                          ,[proc_yield_rate]
                          ,[unit_qty]
                          ,[manu_batch_cd]
                          ,[equip_grp_id]
                          ,[Parts_bind]
                          ,[cncl_flg]
                          ,[regr_id]
                          ,[regr_utc]
                          ,[notes])" +
                          "VALUES(" +
                            "@cmp_cd,@plnt_cd,@proc_flow_id,@lproc_id,@proc_flow_nm,@proc_seq,@proc_yield_rate," +
                            "@unit_qty,@manu_batch_cd,@equip_grp_id,@Parts_bind,@cncl_flg,@regr_id,@regr_utc,@notes)"


        sqlstr2 = "INSERT INTO MAST_PROC2" +
                        "([cmp_cd]
                          ,[plnt_cd]
                          ,[proc_flow_id]
                          ,[lproc_id]
                          ,[proc_flow_nm]
                          ,[proc_seq]
                          ,[proc_yield_rate]
                          ,[unit_qty]
                          ,[manu_batch_cd]
                          ,[equip_grp_id]
                          ,[Parts_bind]
                          ,[cncl_flg]
                          ,[regr_id]
                          ,[regr_utc]
                          ,[notes])" +
                          "VALUES(" +
                            "@cmp_cd,@plnt_cd,@proc_flow_id,@lproc_id,@proc_flow_nm,@proc_seq,@proc_yield_rate," +
                            "@unit_qty,@manu_batch_cd,@equip_grp_id,@Parts_bind,@cncl_flg,@regr_id,@regr_utc,@notes)"


        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@cmp_cd", ddlCC.SelectedValue)
        cmd.Parameters.AddWithValue("@plnt_cd", ddlPC.SelectedValue)
        cmd.Parameters.AddWithValue("@proc_flow_id", ddlPFID.SelectedValue)
        cmd.Parameters.AddWithValue("@lproc_id", txtPGID.Text)
        cmd.Parameters.AddWithValue("@proc_flow_nm", txtPFN.Text)
        cmd.Parameters.AddWithValue("@proc_seq", txtPSN.Text)
        cmd.Parameters.AddWithValue("@proc_yield_rate", txtPYR.Text)
        cmd.Parameters.AddWithValue("@unit_qty", txtUR.Text)
        cmd.Parameters.AddWithValue("@manu_batch_cd", txtMBC.Text)
        cmd.Parameters.AddWithValue("@equip_grp_id", txtEGID.Text)
        cmd.Parameters.AddWithValue("@Parts_bind", txtPTI.Text)
        cmd.Parameters.AddWithValue("@CNCL_FLG", 0)
        cmd.Parameters.AddWithValue("@regr_utc", Format(Now, "yyyy-MM-dd HH:mm:ss"))
        cmd.Parameters.AddWithValue("@regr_id", Logonid)
        cmd.Parameters.AddWithValue("@notes", txtRe.Text)

        cmd2 = New SqlCommand(sqlstr2, myconnection)
        cmd2.Parameters.AddWithValue("@cmp_cd", ddlCC.SelectedValue)
        cmd2.Parameters.AddWithValue("@plnt_cd", ddlPC.SelectedValue)
        cmd2.Parameters.AddWithValue("@proc_flow_id", ddlPFID.SelectedValue)
        cmd2.Parameters.AddWithValue("@lproc_id", txtPGID.Text)
        cmd2.Parameters.AddWithValue("@proc_flow_nm", txtPFN.Text)
        cmd2.Parameters.AddWithValue("@proc_seq", txtPSN.Text)
        cmd2.Parameters.AddWithValue("@proc_yield_rate", txtPYR.Text)
        cmd2.Parameters.AddWithValue("@unit_qty", txtUR.Text)
        cmd2.Parameters.AddWithValue("@manu_batch_cd", txtMBC.Text)
        cmd2.Parameters.AddWithValue("@equip_grp_id", txtEGID.Text)
        cmd2.Parameters.AddWithValue("@Parts_bind", txtPTI.Text)
        cmd2.Parameters.AddWithValue("@CNCL_FLG", 0)
        cmd2.Parameters.AddWithValue("@regr_utc", Format(Now, "yyyy-MM-dd HH:mm:ss"))
        cmd2.Parameters.AddWithValue("@regr_id", Logonid)
        cmd2.Parameters.AddWithValue("@notes", txtRe.Text)
        Try
            cmd.ExecuteNonQuery()
            cmd2.ExecuteNonQuery()
            Class1.ShowMsg("Saved Successfully", "Ok", "success")
            DataEntryScr.Visible = False
        Catch ex As Exception
            Class1.ShowMsg("Error during Save!", "Continue", "warning")
            Exit Sub
        End Try
    End Sub
    Protected Sub UpdateMastProd()

        Dim sqlstr As String
        Dim cmd As SqlCommand

        Dim sqlstr2 As String
        Dim cmd2 As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "UPDATE MAST_PROC " +
                            "SET [cmp_cd]=@cmp_cd
                              ,[plnt_cd]=@plnt_cd
                              ,[proc_flow_id]=@proc_flow_id
                              ,[lproc_id]=@lproc_id
                              ,[proc_flow_nm]=@proc_flow_nm
                              ,[proc_seq]=@proc_seq
                              ,[proc_yield_rate]=@proc_yield_rate
                              ,[unit_qty]=@unit_qty
                              ,[manu_batch_cd]=@manu_batch_cd
                              ,[equip_grp_id]=@equip_grp_id
                              ,[Parts_bind]=@Parts_bind
                              ,[cncl_flg]=@cncl_flg
                              ,[upd_utc]=@upd_utc
                              ,[upd_id]=@updr_id
                              ,[notes]=@notes Where proc_flow_id = @proc_flow_id"

        sqlstr2 = "UPDATE MAST_PROC2 " +
                            "SET [cmp_cd]=@cmp_cd
                              ,[plnt_cd]=@plnt_cd
                              ,[proc_flow_id]=@proc_flow_id
                              ,[lproc_id]=@lproc_id
                              ,[proc_flow_nm]=@proc_flow_nm
                              ,[proc_seq]=@proc_seq
                              ,[proc_yield_rate]=@proc_yield_rate
                              ,[unit_qty]=@unit_qty
                              ,[manu_batch_cd]=@manu_batch_cd
                              ,[equip_grp_id]=@equip_grp_id
                              ,[Parts_bind]=@Parts_bind
                              ,[cncl_flg]=@cncl_flg
                              ,[upd_utc]=@upd_utc
                              ,[upd_id]=@updr_id
                              ,[notes]=@notes Where proc_flow_id = @proc_flow_id"

        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd2 = New SqlCommand(sqlstr2, myconnection)
        cmd.Parameters.AddWithValue("@cmp_cd", ddlCC.SelectedValue)
        cmd.Parameters.AddWithValue("@plnt_cd", ddlPC.SelectedValue)
        cmd.Parameters.AddWithValue("@proc_flow_id", ddlPFID.SelectedValue)
        cmd.Parameters.AddWithValue("@lproc_id", txtPGID.Text)
        cmd.Parameters.AddWithValue("@proc_flow_nm", txtPFN.Text)
        cmd.Parameters.AddWithValue("@proc_seq", txtPSN.Text)
        cmd.Parameters.AddWithValue("@proc_yield_rate", txtPYR.Text)
        cmd.Parameters.AddWithValue("@unit_qty", txtUR.Text)
        cmd.Parameters.AddWithValue("@manu_batch_cd", txtMBC.Text)
        cmd.Parameters.AddWithValue("@equip_grp_id", txtEGID.Text)
        cmd.Parameters.AddWithValue("@Parts_bind", txtPTI.Text)
        cmd.Parameters.AddWithValue("@CNCL_FLG", 0)
        cmd.Parameters.AddWithValue("@upd_utc", Format(Now, "yyyy-MM-dd HH:mm:ss"))
        cmd.Parameters.AddWithValue("@updr_id", Logonid)
        cmd.Parameters.AddWithValue("@notes", txtRe.Text)



        cmd2.Parameters.AddWithValue("@cmp_cd", ddlCC.SelectedValue)
        cmd2.Parameters.AddWithValue("@plnt_cd", ddlPC.SelectedValue)
        cmd2.Parameters.AddWithValue("@proc_flow_id", ddlPFID.SelectedValue)
        cmd2.Parameters.AddWithValue("@lproc_id", txtPGID.Text)
        cmd2.Parameters.AddWithValue("@proc_flow_nm", txtPFN.Text)
        cmd2.Parameters.AddWithValue("@proc_seq", txtPSN.Text)
        cmd2.Parameters.AddWithValue("@proc_yield_rate", txtPYR.Text)
        cmd2.Parameters.AddWithValue("@unit_qty", txtUR.Text)
        cmd2.Parameters.AddWithValue("@manu_batch_cd", txtMBC.Text)
        cmd2.Parameters.AddWithValue("@equip_grp_id", txtEGID.Text)
        cmd2.Parameters.AddWithValue("@Parts_bind", txtPTI.Text)
        cmd2.Parameters.AddWithValue("@CNCL_FLG", 0)
        cmd2.Parameters.AddWithValue("@upd_utc", Format(Now, "yyyy-MM-dd HH:mm:ss"))
        cmd2.Parameters.AddWithValue("@updr_id", Logonid)
        cmd2.Parameters.AddWithValue("@notes", txtRe.Text)
        Try
            cmd.ExecuteNonQuery()
            cmd2.ExecuteNonQuery()
            Class1.ShowMsg("Updated Successfully", "Ok", "success")
            DataEntryScr.Visible = False
        Catch ex As Exception
            Class1.ShowMsg("Error during Update!", "Continue", "warning")
            Exit Sub
        End Try

    End Sub


    Private Sub DataEntryScr_Clear()
        ddlCC.ClearSelection()
        ddlPC.ClearSelection()
        ddlPFID.Text = String.Empty
        txtPGID.Text = String.Empty
        txtPFN.Text = String.Empty
        txtPSN.Text = String.Empty
        txtPYR.Text = String.Empty
        txtUR.Text = String.Empty
        txtMBC.Text = String.Empty
        txtEGID.Text = String.Empty
        txtPTI.Text = String.Empty
        txtRe.Text = String.Empty
        ddlPFID.Enabled = True
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
            ddlPFID.Enabled = False

            GetSelected(e.CommandArgument)

        End If
    End Sub

    Protected Sub GetSelected(proc_flow_id As String)
        connstr = System.Configuration.ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
        Dim sqlstr As String
        Dim myConnection As SqlConnection

        sqlstr = "SELECT [cmp_cd]
                          ,[plnt_cd]
                          ,[proc_flow_id]
                          ,[lproc_id]
                          ,[proc_flow_nm]
                          ,[proc_seq]
                          ,[proc_yield_rate]
                          ,[unit_qty]
                          ,[manu_batch_cd]
                          ,[equip_grp_id]
                          ,[Parts_bind]
                          ,[notes] from MAST_PROC " +
             "WHERE proc_flow_id = @proc_flow_id"

        Dim cmd As SqlCommand

        myConnection = New SqlConnection(connstr)
        myConnection.Open()
        cmd = New SqlCommand(sqlstr, myConnection)

        cmd.Parameters.AddWithValue("@proc_flow_id", proc_flow_id)


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


        Dim firstPFID = DirectCast(DataEntryScr.FindControl("ddlPFID"), DropDownList).Items(0)
        DirectCast(DataEntryScr.FindControl("ddlPFID"), DropDownList).Items.Clear()
        DirectCast(DataEntryScr.FindControl("ddlPFID"), DropDownList).Items.Add(firstCC)
        DirectCast(DataEntryScr.FindControl("ddlPFID"), DropDownList).DataBind()


        If value.Rows(0).Item(2) Is String.Empty Then
            DirectCast(DataEntryScr.FindControl("ddlPFID"), DropDownList).SelectedIndex = 0
        Else
            DirectCast(DataEntryScr.FindControl("ddlPFID"), DropDownList).SelectedValue = value.Rows(0).Item(2)
        End If


        DirectCast(DataEntryScr.FindControl("txtPGID"), TextBox).Text = value.Rows(0).Item(3)
        DirectCast(DataEntryScr.FindControl("txtPFN"), TextBox).Text = value.Rows(0).Item(4)
        DirectCast(DataEntryScr.FindControl("txtPSN"), TextBox).Text = value.Rows(0).Item(5)
        DirectCast(DataEntryScr.FindControl("txtPYR"), TextBox).Text = value.Rows(0).Item(6)

        DirectCast(DataEntryScr.FindControl("txtUR"), TextBox).Text = value.Rows(0).Item(7)
        DirectCast(DataEntryScr.FindControl("txtMBC"), TextBox).Text = value.Rows(0).Item(8)
        DirectCast(DataEntryScr.FindControl("txtEGID"), TextBox).Text = value.Rows(0).Item(9)
        DirectCast(DataEntryScr.FindControl("txtPTI"), TextBox).Text = value.Rows(0).Item(10)

        DirectCast(DataEntryScr.FindControl("txtRe"), TextBox).Text = value.Rows(0).Item(11)


    End Sub
    Protected Sub SoftDeleteReason()
        Dim sqlstr As String
        Dim cmd As SqlCommand
        Dim sqlstr2 As String
        Dim cmd2 As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "UPDATE MAST_PROC" +
                        " SET CNCL_FLG = 1  WHERE proc_flow_id = @proc_flow_id"

        sqlstr2 = "UPDATE MAST_PROC2" +
                        " SET CNCL_FLG = 1  WHERE proc_flow_id = @proc_flow_id"
        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd2 = New SqlCommand(sqlstr2, myconnection)
        cmd.Parameters.AddWithValue("@proc_flow_id", ddlPFID.SelectedValue)
        cmd2.Parameters.AddWithValue("@proc_flow_id", ddlPFID.SelectedValue)
        Try
            cmd.ExecuteNonQuery()
            cmd2.ExecuteNonQuery()
            Class1.ShowMsg("Deleted Successfully", "Ok", "success")
            DataEntryScr.Visible = False
        Catch ex As Exception
            Class1.ShowMsg("Error during Delete!", "Continue", "warning")
            Exit Sub
        End Try
    End Sub


End Class