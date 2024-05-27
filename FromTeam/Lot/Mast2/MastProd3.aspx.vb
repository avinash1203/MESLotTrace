Imports System.Data.SqlClient

Public Class MastProd3
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
        sqlstr = "SELECT COUNT(*) FROM MAST_PROC3 WHERE proc_flow_id = @proc_flow_id"
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@proc_flow_id", txtPFID.Text)

        myconnection.Open()
        Dim ANS As Integer = cmd.ExecuteScalar
        myconnection.Close()

        If ANS > 0 And hfPopUpType.Value = "New" Then
            Class1.ShowMsg("Duplicate Process Flow ID,Associate Flow ID .Please Check!", "Continue", "warning")
            Exit Sub
        End If

        If ANS > 0 Then
            Call UpdateMastProcess()
        Else
            Call InsertMasttProcess()
        End If
        gvContent.DataBind()
    End Sub


    Private Sub InsertMasttProcess()
        Dim sqlstr As String
        Dim cmd As SqlCommand

        Dim sqlstr2 As String
        Dim cmd2 As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "INSERT INTO MAST_PROC3" +
                        "([line_id]
                           ,[item_cd]
                           ,[proc_flow_id]
                           ,[assoc_flow_id]
                           ,[cncl_flg]
                           ,[regr_id]
                           ,[regr_utc]
                           ,[notes])" +
                          "VALUES(" +
                            "@line_id,@item_cd,@proc_flow_id,@assoc_flow_id,@cncl_flg,@regr_id,@regr_utc," +
                            "@notes)"
        sqlstr2 = "INSERT INTO MAST_PROC32" +
                        "([line_id]
                           ,[item_cd]
                           ,[proc_flow_id]
                           ,[assoc_flow_id]
                           ,[cncl_flg]
                           ,[regr_id]
                           ,[regr_utc]
                           ,[notes])" +
                          "VALUES(" +
                            "@line_id,@item_cd,@proc_flow_id,@assoc_flow_id,@cncl_flg,@regr_id,@regr_utc," +
                            "@notes)"


        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@line_id", ddlLineId.SelectedValue)
        cmd.Parameters.AddWithValue("@item_cd", ddlIC.SelectedValue)
        cmd.Parameters.AddWithValue("@proc_flow_id", txtPFID.Text)
        cmd.Parameters.AddWithValue("@assoc_flow_id", txtAFID.Text)
        cmd.Parameters.AddWithValue("@CNCL_FLG", 0)
        cmd.Parameters.AddWithValue("@regr_utc", Format(Now, "yyyy-MM-dd HH:mm:ss"))
        cmd.Parameters.AddWithValue("@regr_id", Logonid)
        cmd.Parameters.AddWithValue("@notes", txtRe.Text)

        cmd2 = New SqlCommand(sqlstr2, myconnection)
        cmd2.Parameters.AddWithValue("@line_id", ddlLineId.SelectedValue)
        cmd2.Parameters.AddWithValue("@item_cd", ddlIC.SelectedValue)
        cmd2.Parameters.AddWithValue("@proc_flow_id", txtPFID.Text)
        cmd2.Parameters.AddWithValue("@assoc_flow_id", txtAFID.Text)
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
    Protected Sub UpdateMastProcess()

        Dim sqlstr As String
        Dim cmd As SqlCommand
        Dim sqlstr2 As String
        Dim cmd2 As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "UPDATE MAST_PROC3" +
                          "SET 
                          [line_id]=@line_id
                         ,[item_cd]=@item_cd
                         ,[proc_flow_id]=@proc_flow_id
                         ,[assoc_flow_id]=@assoc_flow_id
                          cncl_flg=@cncl_flg,
                          upd_utc=@upd_utc,
                          updr_id=@updr_id,
                          notes=@notes Where proc_flow_id = @proc_flow_id"

        sqlstr2 = "UPDATE MAST_PROC32" +
                          "SET 
                          [line_id]=@line_id
                         ,[item_cd]=@item_cd
                         ,[proc_flow_id]=@proc_flow_id
                         ,[assoc_flow_id]=@assoc_flow_id
                          cncl_flg=@cncl_flg,
                          upd_utc=@upd_utc,
                          updr_id=@updr_id,
                          notes=@notes Where proc_flow_id = @proc_flow_id"

        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)

        cmd.Parameters.AddWithValue("@line_id", ddlLineId.SelectedValue)
        cmd.Parameters.AddWithValue("@item_cd", ddlIC.SelectedValue)
        cmd.Parameters.AddWithValue("@proc_flow_id", txtPFID.Text)
        cmd.Parameters.AddWithValue("@assoc_flow_id", txtAFID.Text)

        cmd.Parameters.AddWithValue("@CNCL_FLG", 0)
        cmd.Parameters.AddWithValue("@upd_utc", Format(Now, "yyyy-MM-dd HH:mm:ss"))
        cmd.Parameters.AddWithValue("@updr_id", Logonid)
        cmd.Parameters.AddWithValue("@notes", txtRe.Text)

        cmd2 = New SqlCommand(sqlstr2, myconnection)

        cmd2.Parameters.AddWithValue("@line_id", ddlLineId.SelectedValue)
        cmd2.Parameters.AddWithValue("@item_cd", ddlIC.SelectedValue)
        cmd2.Parameters.AddWithValue("@proc_flow_id", txtPFID.Text)
        cmd2.Parameters.AddWithValue("@assoc_flow_id", txtAFID.Text)

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
        ddlLineId.ClearSelection()
        ddlIC.ClearSelection()
        txtPFID.Text = String.Empty
        txtAFID.Text = String.Empty
        txtRe.Text = String.Empty
        txtPFID.ReadOnly = False
        txtPFID.Enabled = True
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
            txtPFID.ReadOnly = True
            txtPFID.Enabled = False
            Dim resultArray() As String = e.CommandArgument.Split("_")
            GetSelected(resultArray(0), resultArray(1))

        End If
    End Sub

    Protected Sub GetSelected(proc_flow_id As String, assoc_flow_id As String)
        connstr = System.Configuration.ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
        Dim sqlstr As String
        Dim myConnection As SqlConnection

        sqlstr = "SELECT [line_id]
                           ,[item_cd]
                           ,[proc_flow_id]
                           ,[assoc_flow_id]
                           ,[notes] from MAST_PROC3 " +
             "WHERE proc_flow_id = @proc_flow_id "

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
        Dim firstLineId = DirectCast(DataEntryScr.FindControl("ddlLineId"), DropDownList).Items(0)
        DirectCast(DataEntryScr.FindControl("ddlLineId"), DropDownList).Items.Clear()
        DirectCast(DataEntryScr.FindControl("ddlLineId"), DropDownList).Items.Add(firstLineId)
        DirectCast(DataEntryScr.FindControl("ddlLineId"), DropDownList).DataBind()


        Dim firstIC = DirectCast(DataEntryScr.FindControl("ddlIC"), DropDownList).Items(0)
        DirectCast(DataEntryScr.FindControl("ddlIC"), DropDownList).Items.Clear()
        DirectCast(DataEntryScr.FindControl("ddlIC"), DropDownList).Items.Add(firstIC)
        DirectCast(DataEntryScr.FindControl("ddlIC"), DropDownList).DataBind()





        If value.Rows(0).Item(0) Is String.Empty Then
            DirectCast(DataEntryScr.FindControl("ddlLineId"), DropDownList).SelectedIndex = 0
        Else
            DirectCast(DataEntryScr.FindControl("ddlLineId"), DropDownList).SelectedValue = value.Rows(0).Item(0)
        End If

        If value.Rows(0).Item(1) Is String.Empty Then
            DirectCast(DataEntryScr.FindControl("ddlIC"), DropDownList).SelectedIndex = 0
        Else
            DirectCast(DataEntryScr.FindControl("ddlIC"), DropDownList).SelectedValue = value.Rows(0).Item(1)
        End If


        DirectCast(DataEntryScr.FindControl("txtPFID"), TextBox).Text = value.Rows(0).Item(2)
        DirectCast(DataEntryScr.FindControl("txtAFID"), TextBox).Text = value.Rows(0).Item(3)
        DirectCast(DataEntryScr.FindControl("txtRe"), TextBox).Text = value.Rows(0).Item(4)






    End Sub
    Protected Sub SoftDeleteReason()
        Dim sqlstr As String
        Dim cmd As SqlCommand

        Dim sqlstr2 As String
        Dim cmd2 As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "UPDATE MAST_PROC3" +
                        " SET CNCL_FLG = 1  WHERE proc_flow_id = @proc_flow_id"
        sqlstr2 = "UPDATE MAST_PROC32" +
                        " SET CNCL_FLG = 1  WHERE proc_flow_id = @proc_flow_id"
        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@proc_flow_id", txtPFID.Text)

        cmd2 = New SqlCommand(sqlstr2, myconnection)
        cmd2.Parameters.AddWithValue("@proc_flow_id", txtPFID.Text)

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