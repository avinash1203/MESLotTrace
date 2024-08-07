﻿Imports System.Data.SqlClient

Public Class MastProcess
    Inherits System.Web.UI.Page
    Public connstr As String
    Public Logonid As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Logonid = Class1.GetLoginId(Request)

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
        cmd.Parameters.AddWithValue("@proc_flow_id", txtPflowID.Text.Trim)

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
        Dim sqlstr1, sqlstr2 As String
        Dim cmd1, cmd2 As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr1 = "INSERT INTO MAST_PROC" +
                          "([cmp_cd]
                                       ,[plnt_cd]
                                       ,[proc_flow_id]
                                       ,[lproc_id]
                                       ,[proc_flow_nm]
                                       ,[Parts_bind]
                                       ,[cncl_flg]
                                       ,[regr_id]
                                       ,[regr_utc]
                                       ,[notes])" +
              "VALUES(" +
                "@cmp_cd,@plnt_cd,@proc_flow_id,@lproc_id,@proc_flow_nm," +
                "@Parts_bind,@cncl_flg,@regr_id,@regr_utc,@notes)"

        cmd1 = New SqlCommand(sqlstr1, myconnection)
        cmd1.Parameters.AddWithValue("@cmp_cd", ddlCC.SelectedValue)
        cmd1.Parameters.AddWithValue("@plnt_cd", ddlPC.SelectedValue)
        cmd1.Parameters.AddWithValue("@proc_flow_id", txtPflowID.Text.Trim)
        cmd1.Parameters.AddWithValue("@lproc_id", txtPGID.Text)
        cmd1.Parameters.AddWithValue("@proc_flow_nm", txtPFN.Text)
        cmd1.Parameters.AddWithValue("@Parts_bind", txtPTI.Text)
        cmd1.Parameters.AddWithValue("@CNCL_FLG", 0)
        cmd1.Parameters.AddWithValue("@regr_utc", Format(Now, "yyyy-MM-dd HH:mm:ss"))
        cmd1.Parameters.AddWithValue("@regr_id", Logonid)
        cmd1.Parameters.AddWithValue("@notes", txtRe.Text)

        sqlstr2 = "INSERT INTO MAST_PROC2" +
            "([cmp_cd]
                         ,[plnt_cd]
                         ,[proc_flow_id]
                         ,[proc_seq]
                         ,[lproc_id]
                         ,[proc_yield_rate]
                         ,[unit_qty]
                         ,[manu_batch_cd]
                         ,[equip_grp_id]
                         ,[cncl_flg]
                         ,[regr_id]
                         ,[regr_utc]
                         ,[notes])" +
              "VALUES(" +
                "@cmp_cd,@plnt_cd,@proc_flow_id, @proc_seq,@lproc_id,@proc_yield_rate," +
                "@unit_qty,@manu_batch_cd,@equip_grp_id,@cncl_flg,@regr_id,@regr_utc,@notes)"

        cmd2 = New SqlCommand(sqlstr2, myconnection)
        cmd2.Parameters.AddWithValue("@cmp_cd", ddlCC.SelectedValue)
        cmd2.Parameters.AddWithValue("@plnt_cd", ddlPC.SelectedValue)
        cmd2.Parameters.AddWithValue("@proc_flow_id", txtPflowID.Text)
        cmd2.Parameters.AddWithValue("@proc_seq", txtPSN.Text)
        cmd2.Parameters.AddWithValue("@lproc_id", txtPGID.Text)
        cmd2.Parameters.AddWithValue("@proc_yield_rate", txtPYR.Text)
        cmd2.Parameters.AddWithValue("@unit_qty", txtUR.Text)
        cmd2.Parameters.AddWithValue("@manu_batch_cd", txtMBC.Text)
        cmd2.Parameters.AddWithValue("@equip_grp_id", txtEGID.Text)
        cmd2.Parameters.AddWithValue("@CNCL_FLG", 0)
        cmd2.Parameters.AddWithValue("@regr_utc", Format(Now, "yyyy-MM-dd HH:mm:ss"))
        cmd2.Parameters.AddWithValue("@regr_id", Logonid)
        cmd2.Parameters.AddWithValue("@notes", txtRe.Text)

        myconnection.Open()

        Try
            cmd1.ExecuteNonQuery()
            cmd2.ExecuteNonQuery()
            Class1.ShowMsg("Saved Successfully", "Ok", "success")
            DataEntryScr.Visible = False
        Catch ex As Exception
            Class1.ShowMsg("Error during Save!", "Continue", "warning")
        Finally
            myconnection.Close()
        End Try

    End Sub
    Protected Sub UpdateMastProd()

        Dim sqlstr1, sqlstr2 As String
        Dim cmd1, cmd2 As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr1 = "UPDATE MAST_PROC " +
                "SET [cmp_cd]=@cmp_cd
                              ,[plnt_cd]=@plnt_cd
                              ,[proc_flow_id]=@proc_flow_id
                              ,[lproc_id]=@lproc_id
                              ,[proc_flow_nm]=@proc_flow_nm
                              ,[Parts_bind]=@Parts_bind
                              ,[cncl_flg]=@cncl_flg
                              ,[upd_utc]=@upd_utc
                              ,[upd_id]=@updr_id
                              ,[notes]=@notes Where proc_flow_id = @proc_flow_id"


        cmd1 = New SqlCommand(sqlstr1, myconnection)
        cmd1.Parameters.AddWithValue("@cmp_cd", ddlCC.SelectedValue)
        cmd1.Parameters.AddWithValue("@plnt_cd", ddlPC.SelectedValue)
        cmd1.Parameters.AddWithValue("@proc_flow_id", txtPflowID.Text)
        cmd1.Parameters.AddWithValue("@lproc_id", txtPGID.Text)
        cmd1.Parameters.AddWithValue("@proc_flow_nm", txtPFN.Text)
        cmd1.Parameters.AddWithValue("@Parts_bind", txtPTI.Text)
        cmd1.Parameters.AddWithValue("@CNCL_FLG", 0)
        cmd1.Parameters.AddWithValue("@upd_utc", Format(Now, "yyyy-MM-dd HH:mm:ss"))
        cmd1.Parameters.AddWithValue("@updr_id", Logonid)
        cmd1.Parameters.AddWithValue("@notes", txtRe.Text)


        sqlstr2 = "UPDATE MAST_PROC2 " +
                "SET [cmp_cd]=@cmp_cd
                              ,[plnt_cd]=@plnt_cd
                              ,[proc_flow_id]=@proc_flow_id
                              ,[lproc_id]=@lproc_id
                              ,[proc_seq]=@proc_seq
                              ,[proc_yield_rate]=@proc_yield_rate
                              ,[unit_qty]=@unit_qty
                              ,[manu_batch_cd]=@manu_batch_cd
                              ,[equip_grp_id]=@equip_grp_id
                              ,[cncl_flg]=@cncl_flg
                              ,[upd_utc]=@upd_utc
                              ,[upd_id]=@updr_id
                              ,[notes]=@notes Where proc_flow_id = @proc_flow_id"


        cmd2 = New SqlCommand(sqlstr2, myconnection)
        cmd2.Parameters.AddWithValue("@cmp_cd", ddlCC.SelectedValue)
        cmd2.Parameters.AddWithValue("@plnt_cd", ddlPC.SelectedValue)
        cmd2.Parameters.AddWithValue("@proc_flow_id", txtPflowID.Text)
        cmd2.Parameters.AddWithValue("@proc_seq", txtPSN.Text)
        cmd2.Parameters.AddWithValue("@lproc_id", txtPGID.Text)
        cmd2.Parameters.AddWithValue("@proc_yield_rate", txtPYR.Text)
        cmd2.Parameters.AddWithValue("@unit_qty", txtUR.Text)
        cmd2.Parameters.AddWithValue("@manu_batch_cd", txtMBC.Text)
        cmd2.Parameters.AddWithValue("@equip_grp_id", txtEGID.Text)
        cmd2.Parameters.AddWithValue("@CNCL_FLG", 0)
        cmd2.Parameters.AddWithValue("@upd_utc", Format(Now, "yyyy-MM-dd HH:mm:ss"))
        cmd2.Parameters.AddWithValue("@updr_id", Logonid)
        cmd2.Parameters.AddWithValue("@notes", txtRe.Text)

        myconnection.Open()
        Try
            cmd1.ExecuteNonQuery()
            cmd2.ExecuteNonQuery()
            Class1.ShowMsg("Updated Successfully", "Ok", "success")
            DataEntryScr.Visible = False
        Catch ex As Exception
            Class1.ShowMsg("Error during Update!", "Continue", "warning")
        Finally
            myconnection.Close()
        End Try

    End Sub
    Private Sub DataEntryScr_Clear()
        ddlCC.ClearSelection()
        ddlPC.ClearSelection()
        txtPflowID.Text = String.Empty
        txtPGID.Text = String.Empty
        txtPFN.Text = String.Empty
        txtPSN.Text = String.Empty
        txtPYR.Text = String.Empty
        txtUR.Text = String.Empty
        txtMBC.Text = String.Empty
        txtEGID.Text = String.Empty
        txtPTI.Text = String.Empty
        txtRe.Text = String.Empty

    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DataEntryScr_Clear()
        DataEntryScr.Visible = False
    End Sub
    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        DataEntryScr_Clear()
        DataEntryScr.Visible = True
        txtPflowID.Enabled = True
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
            txtPflowID.Enabled = False

            GetSelected(e.CommandArgument)

        End If
    End Sub

    Protected Sub GetSelected(proc_flow_id As String)
        connstr = System.Configuration.ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
        Dim sqlstr As String
        Dim myConnection As SqlConnection

        '       sqlstr = "SELECT [cmp_cd]
        '             ,[plnt_cd]
        '             ,[proc_flow_id]
        '             ,[lproc_id]
        '             ,[proc_flow_nm]
        '             ,[proc_seq]
        '             ,[proc_yield_rate]
        '             ,[unit_qty]
        '             ,[manu_batch_cd]
        '             ,[equip_grp_id]
        '             ,[Parts_bind]
        '             ,[notes] from MAST_PROC " +
        '"WHERE proc_flow_id = @proc_flow_id"

        sqlstr = "SELECT A.CMP_CD,A.PLNT_CD,A.PROC_FLOW_ID,A.LPROC_ID,A.PROC_FLOW_NM,B.PROC_SEQ,
                                     B.PROC_YIELD_RATE,B.UNIT_QTY,B.MANU_BATCH_CD,B.EQUIP_GRP_ID,A.PARTS_BINd,A.NOTES 
                                     FROM MAST_PROC A
                                     LEFT JOIN MAST_PROC2 B ON A.PROC_FLOW_ID = B.PROC_FLOW_ID
                                     WHERE A.PROC_FLOW_ID = @proc_flow_id"

        Dim cmd As SqlCommand

        myConnection = New SqlConnection(connstr)
        myConnection.Open()
        cmd = New SqlCommand(sqlstr, myConnection)

        cmd.Parameters.AddWithValue("@proc_flow_id", proc_flow_id)


        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)
        Class1.ConvertDbNullToEmptyString(dt)
        If dt.Rows.Count > 0 Then
            fillDetails(dt)
            txtPflowID.Enabled = False
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

        'If value.Rows(0).Item(0) Is String.Empty Then
        '    DirectCast(DataEntryScr.FindControl("ddlCC"), DropDownList).SelectedIndex = 0
        'Else
        '    DirectCast(DataEntryScr.FindControl("ddlCC"), DropDownList).SelectedValue = value.Rows(0).Item(0)
        'End If

        Class1.SetDropDownVale(DataEntryScr, "ddlCC", value.Rows(0).Item(0))

        'If value.Rows(0).Item(1) Is String.Empty Then
        '    DirectCast(DataEntryScr.FindControl("ddlPC"), DropDownList).SelectedIndex = 0
        'Else
        '    DirectCast(DataEntryScr.FindControl("ddlPC"), DropDownList).SelectedValue = value.Rows(0).Item(1)
        'End If
        Class1.SetDropDownVale(DataEntryScr, "ddlPC", value.Rows(0).Item(1))

        'Dim firstPFID = DirectCast(DataEntryScr.FindControl("ddlPFID"), DropDownList).Items(0)
        'DirectCast(DataEntryScr.FindControl("ddlPFID"), DropDownList).Items.Clear()
        'DirectCast(DataEntryScr.FindControl("ddlPFID"), DropDownList).Items.Add(firstPFID)
        'DirectCast(DataEntryScr.FindControl("ddlPFID"), DropDownList).DataBind()
        'Class1.SetDropDownVale(DataEntryScr, "ddlPFID", value.Rows(0).Item(2))

        DirectCast(DataEntryScr.FindControl("txtpflowid"), TextBox).Text = value.Rows(0).Item(2)
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
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "UPDATE MAST_PROC" +
            " SET CNCL_FLG = 1  WHERE proc_flow_id = @proc_flow_id"
        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@proc_flow_id", txtPflowID.Text)
        Try
            cmd.ExecuteNonQuery()
            Class1.ShowMsg("Deleted Successfully", "Ok", "success")
            DataEntryScr.Visible = False
        Catch ex As Exception
            Class1.ShowMsg("Error during Delete!", "Continue", "warning")
            Exit Sub
        End Try
    End Sub

    Protected Sub ImageButton3_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton3.Click
        Response.Redirect("AppMainpage.aspx?LogonID=" & Logonid & "&Op=2")
    End Sub

    Protected Sub gvContent_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvContent.PageIndex = e.NewPageIndex
        gvContent.DataBind()
    End Sub
End Class