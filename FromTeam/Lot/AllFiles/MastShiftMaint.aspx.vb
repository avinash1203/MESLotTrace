﻿Imports System.Data.SqlClient

Public Class MastShiftMaint
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
        sqlstr = "SELECT COUNT(*) FROM MAST_SHIFT WHERE shift_ptrn_id = @SPID"
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@SPID", txtSPID.Text.Trim)
        myconnection.Open()
        Dim ANS As Integer = cmd.ExecuteScalar
        myconnection.Close()

        If ANS > 0 And hfPopUpType.Value = "New" Then
            Class1.ShowMsg("Duplicate Shift pattern description..Please Check!", "Continue", "warning")
            Exit Sub
        End If

        If ANS > 0 Then
            Call UpdateMastShift()
        Else
            Call InsertMastShift()
        End If
        gvContent.DataBind()
    End Sub


    Private Sub InsertMastShift()
        Dim sqlstr As String
        Dim sqlstr2 As String
        Dim cmd As SqlCommand
        Dim cmd2 As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "INSERT INTO MAST_SHIFT" +
                            "(cmp_cd,plnt_cd,shift_ptrn_id,wrk_shift_seq,strt_time_utc,end_time_utc,shift_cd," +
                               "shift_nm,CNCL_FLG)" +
                            "VALUES(" +
                            "@cmp_cd,@plnt_cd,@shift_ptrn_id,@wrk_shift_seq,@strt_time_utc,@end_time_utc,@shift_cd," +
                            "@shift_nm,@CNCL_FLG)"

        sqlstr2 = "INSERT INTO MAST_SHIFT2" +
                            "(cmp_cd,plnt_cd,shift_ptrn_id,wrk_shift_seq,strt_time_utc,end_time_utc,shift_cd," +
                               "shift_nm,CNCL_FLG)" +
                            "VALUES(" +
                            "@cmp_cd,@plnt_cd,@shift_ptrn_id,@wrk_shift_seq,@strt_time_utc,@end_time_utc,@shift_cd," +
                            "@shift_nm,@CNCL_FLG)"

        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@cmp_cd", ddlCC.SelectedValue)
        cmd.Parameters.AddWithValue("@plnt_cd", ddlPC.SelectedValue)
        cmd.Parameters.AddWithValue("@shift_ptrn_id", txtSPID.Text.Trim)
        cmd.Parameters.AddWithValue("@wrk_shift_seq", txtWSS.Text.Trim)
        cmd.Parameters.AddWithValue("@strt_time_utc", txtST.Text.Trim)
        cmd.Parameters.AddWithValue("@end_time_utc", txtET.Text)
        cmd.Parameters.AddWithValue("@shift_cd", txtSC.Text)
        cmd.Parameters.AddWithValue("@shift_nm", txtSDN.Text)
        cmd.Parameters.AddWithValue("@CNCL_FLG", 0)


        cmd2 = New SqlCommand(sqlstr2, myconnection)
        cmd2.Parameters.AddWithValue("@cmp_cd", ddlCC.SelectedValue)
        cmd2.Parameters.AddWithValue("@plnt_cd", ddlPC.SelectedValue)
        cmd2.Parameters.AddWithValue("@shift_ptrn_id", txtSPID.Text.Trim)
        cmd2.Parameters.AddWithValue("@wrk_shift_seq", txtWSS.Text.Trim)
        cmd2.Parameters.AddWithValue("@strt_time_utc", txtST.Text.Trim)
        cmd2.Parameters.AddWithValue("@end_time_utc", txtET.Text)
        cmd2.Parameters.AddWithValue("@shift_cd", txtSC.Text)
        cmd2.Parameters.AddWithValue("@shift_nm", txtSDN.Text)
        cmd2.Parameters.AddWithValue("@CNCL_FLG", 0)
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
    Protected Sub UpdateMastShift()

        Dim sqlstr As String
        Dim sqlstr2 As String
        Dim cmd As SqlCommand
        Dim cmd2 As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "UPDATE MAST_SHIFT" +
                            " SET 
                                           cmp_cd=@cmp_cd,
                                           plnt_cd=@plnt_cd,
                                           shift_ptrn_id=@shift_ptrn_id,
                                           wrk_shift_seq=@wrk_shift_seq,
                                           strt_time_utc=@strt_time_utc,
                                           end_time_utc=@end_time_utc,
                                           shift_cd=@shift_cd,
                                           shift_nm=@shift_nm,
                                           CNCL_FLG=@CNCL_FLG
                                           WHERE 
                                           shift_ptrn_id=@shift_ptrn_id"

        sqlstr2 = "UPDATE MAST_SHIFT2" +
                            " SET 
                                           cmp_cd=@cmp_cd,
                                           plnt_cd=@plnt_cd,
                                           shift_ptrn_id=@shift_ptrn_id,
                                           wrk_shift_seq=@wrk_shift_seq,
                                           strt_time_utc=@strt_time_utc,
                                           end_time_utc=@end_time_utc,
                                           shift_cd=@shift_cd,
                                           shift_nm=@shift_nm,
                                           CNCL_FLG=@CNCL_FLG
                                           WHERE 
                                           shift_ptrn_id=@shift_ptrn_id"

        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@cmp_cd", ddlCC.SelectedValue)
        cmd.Parameters.AddWithValue("@plnt_cd", ddlPC.SelectedValue)
        cmd.Parameters.AddWithValue("@shift_ptrn_id", txtSPID.Text.Trim)
        cmd.Parameters.AddWithValue("@wrk_shift_seq", txtWSS.Text.Trim)
        cmd.Parameters.AddWithValue("@strt_time_utc", txtST.Text.Trim)
        cmd.Parameters.AddWithValue("@end_time_utc", txtET.Text)
        cmd.Parameters.AddWithValue("@shift_cd", txtSC.Text)
        cmd.Parameters.AddWithValue("@shift_nm", txtSDN.Text)
        cmd.Parameters.AddWithValue("@CNCL_FLG", 0)



        cmd2 = New SqlCommand(sqlstr2, myconnection)
        cmd2.Parameters.AddWithValue("@cmp_cd", ddlCC.SelectedValue)
        cmd2.Parameters.AddWithValue("@plnt_cd", ddlPC.SelectedValue)
        cmd2.Parameters.AddWithValue("@shift_ptrn_id", txtSPID.Text.Trim)
        cmd2.Parameters.AddWithValue("@wrk_shift_seq", txtWSS.Text.Trim)
        cmd2.Parameters.AddWithValue("@strt_time_utc", txtST.Text.Trim)
        cmd2.Parameters.AddWithValue("@end_time_utc", txtET.Text)
        cmd2.Parameters.AddWithValue("@shift_cd", txtSC.Text)
        cmd2.Parameters.AddWithValue("@shift_nm", txtSDN.Text)
        cmd2.Parameters.AddWithValue("@CNCL_FLG", 0)
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
        txtSPID.Text = String.Empty
        txtWSS.Text = String.Empty
        txtST.Text = String.Empty
        txtET.Text = String.Empty
        txtSC.Text = String.Empty
        txtSDN.Text = String.Empty
        ddlCC.ClearSelection()
        ddlPC.ClearSelection()
        hfPopUpType.Value = ""
        txtSPID.ReadOnly = False
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

            Dim SPD As String = e.CommandArgument
            hfPopUpType.Value = "Edit"
            txtSPID.ReadOnly = True
            GetSelected(SPD)

        End If
    End Sub

    Protected Sub GetSelected(SPD As String)
        connstr = System.Configuration.ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
        Dim sqlstr As String
        Dim sqlstr2 As String
        Dim myConnection As SqlConnection

        sqlstr = "SELECT [cmp_cd]
                  ,[plnt_cd]
                  ,[shift_ptrn_id]
                  ,[wrk_shift_seq]
                  ,[strt_time_utc]
                  ,[end_time_utc]
                  ,[shift_cd]
                  ,[shift_nm]
                  ,[cncl_flg] from MAST_SHIFT " +
                 "WHERE shift_ptrn_id='" & Trim(SPD) & "'"


        sqlstr2 = "SELECT [cmp_cd]
                  ,[plnt_cd]
                  ,[shift_ptrn_id]
                  ,[wrk_shift_seq]
                  ,[strt_time_utc]
                  ,[end_time_utc]
                  ,[shift_cd]
                  ,[shift_nm]
                  ,[cncl_flg] from MAST_SHIFT2 " +
                 "WHERE shift_ptrn_id='" & Trim(SPD) & "'"

        Dim cmd As SqlCommand

        Dim cmd2 As SqlCommand

        myConnection = New SqlConnection(connstr)
        myConnection.Open()
        cmd = New SqlCommand(sqlstr, myConnection)

        cmd2 = New SqlCommand(sqlstr2, myConnection)
        Dim da As New SqlDataAdapter(cmd)

        Dim da2 As New SqlDataAdapter(cmd2)
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


        DirectCast(DataEntryScr.FindControl("txtSPID"), TextBox).Text = value.Rows(0).Item(2)
        DirectCast(DataEntryScr.FindControl("txtWSS"), TextBox).Text = value.Rows(0).Item(3)
        DirectCast(DataEntryScr.FindControl("txtST"), TextBox).Text = value.Rows(0).Item(4)
        DirectCast(DataEntryScr.FindControl("txtET"), TextBox).Text = value.Rows(0).Item(5)
        DirectCast(DataEntryScr.FindControl("txtSC"), TextBox).Text = value.Rows(0).Item(6)
        DirectCast(DataEntryScr.FindControl("txtSDN"), TextBox).Text = value.Rows(0).Item(7)


    End Sub
    Protected Sub SoftDeleteReason()
        Dim sqlstr As String
        Dim sqlstr2 As String
        Dim cmd As SqlCommand
        Dim cmd2 As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "UPDATE MAST_SHIFT" +
                            " SET CNCL_FLG = 1  WHERE shift_ptrn_id=@shift_ptrn_id"

        sqlstr2 = "UPDATE MAST_SHIFT2" +
                            " SET CNCL_FLG = 1  WHERE shift_ptrn_id=@shift_ptrn_id"
        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)

        cmd2 = New SqlCommand(sqlstr2, myconnection)

        cmd.Parameters.AddWithValue("@shift_ptrn_id", txtSPID.Text)
        cmd2.Parameters.AddWithValue("@shift_ptrn_id", txtSPID.Text)
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