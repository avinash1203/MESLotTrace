Imports System.Data.SqlClient

Public Class MastEquip
    Inherits System.Web.UI.Page


    Public connstr As String
    Public Logonid As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Logonid = Request.QueryString("LogonID")
        Logonid = "9900"
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
        sqlstr = "SELECT COUNT(*) FROM MAST_EQUIP WHERE equip_id = @equip_id"
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@equip_id", txtEID.Text)

        myconnection.Open()
        Dim ANS As Integer = cmd.ExecuteScalar
        myconnection.Close()

        If ANS > 0 And hfPopUpType.Value = "New" Then
            Class1.ShowMsg("Duplicate Equipment ID. Please Check!", "Continue", "warning")
            Exit Sub
        End If

        If ANS > 0 Then
            Call UpdateMastEquip()
        Else
            Call InsertMastEquip()
        End If
        gvContent.DataBind()
    End Sub


    Private Sub InsertMastEquip()
        Dim sqlstr As String
        Dim cmd As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "INSERT INTO MAST_EQUIP" +
                        "(  [cmp_cd],
	                        [plnt_cd],
	                        [equip_id],
	                        [equip_nm],
	                        [ine_id],
	                        [equip_nm_local],
	                        [equip_mgnt_strt_dt_utc],
	                        [cncl_flg],
	                        [regr_id] ,
	                        [regr_utc] ,
	                        [notes] )" +
                          "VALUES(" +
                            "@cmp_cd,@plnt_cd,@equip_id,@equip_nm,@ine_id,@equip_nm_local,@equip_mgnt_strt_dt_utc," +
                            "@cncl_flg,@regr_id,@regr_utc,@notes)"

        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@cmp_cd", ddlCC.SelectedValue)
        cmd.Parameters.AddWithValue("@plnt_cd", ddlPC.SelectedValue)
        cmd.Parameters.AddWithValue("@equip_id", txtEID.Text)
        cmd.Parameters.AddWithValue("@equip_nm", txtED.Text)
        cmd.Parameters.AddWithValue("@ine_id", ddlLineId.SelectedValue)
        cmd.Parameters.AddWithValue("@equip_nm_local", txtEIN.Text)
        cmd.Parameters.AddWithValue("@equip_mgnt_strt_dt_utc", txtESD.Text)
        cmd.Parameters.AddWithValue("@cncl_flg", 0)
        cmd.Parameters.AddWithValue("@regr_id", Logonid)
        cmd.Parameters.AddWithValue("@regr_utc", Format(Now, "yyyy-MM-dd HH:mm:ss"))
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
    Protected Sub UpdateMastEquip()

        Dim sqlstr As String
        Dim cmd As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "UPDATE MAST_EQUIP " +
                        "SET [cmp_cd]=@cmp_cd,
	                        [plnt_cd]=@plnt_cd,
	                        [equip_id]=@equip_id,
	                        [equip_nm]=@equip_nm,
	                        [ine_id]=@ine_id,
	                        [equip_nm_local]=@equip_nm_local,
	                        [equip_mgnt_strt_dt_utc]=@equip_mgnt_strt_dt_utc,
	                        [cncl_flg]=@cncl_flg,
	                        [upd_id]=@upd_id ,
	                        [upd_utc] =@upd_utc,
	                        [notes]=@notes
                            Where  equip_id = @equip_id"

        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@cmp_cd", ddlCC.SelectedValue)
        cmd.Parameters.AddWithValue("@plnt_cd", ddlPC.SelectedValue)
        cmd.Parameters.AddWithValue("@equip_id", txtEID.Text)
        cmd.Parameters.AddWithValue("@equip_nm", txtED.Text)
        cmd.Parameters.AddWithValue("@ine_id", ddlLineId.SelectedValue)
        cmd.Parameters.AddWithValue("@equip_nm_local", txtEIN.Text)
        cmd.Parameters.AddWithValue("@equip_mgnt_strt_dt_utc", txtESD.Text)
        cmd.Parameters.AddWithValue("@cncl_flg", 0)
        cmd.Parameters.AddWithValue("@upd_id", Logonid)
        cmd.Parameters.AddWithValue("@upd_utc", Format(Now, "yyyy-MM-dd HH:mm:ss"))
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
        ddlCC.ClearSelection()
        ddlPC.ClearSelection()
        ddlLineId.ClearSelection()
        txtEID.Text = String.Empty
        txtED.Text = String.Empty
        txtEIN.Text = String.Empty
        txtESD.Text = String.Empty
        txtRe.Text = String.Empty
        txtEID.ReadOnly = False
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
            txtEID.ReadOnly = True
            GetSelected(e.CommandArgument)
        End If
    End Sub

    Protected Sub GetSelected(EID As String)
        connstr = System.Configuration.ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
        Dim sqlstr As String
        Dim myConnection As SqlConnection

        sqlstr = "SELECT [cmp_cd],
	                        [plnt_cd],
                            [ine_id],
	                        [equip_id],
	                        [equip_nm],
	                        [equip_nm_local],
	                        [equip_mgnt_strt_dt_utc],
	                        [cncl_flg],
	                        [regr_id] ,
	                        [regr_utc] ,
	                        [notes]
                           from MAST_EQUIP " +
             "WHERE equip_id = @equip_id"

        Dim cmd As SqlCommand

        myConnection = New SqlConnection(connstr)
        myConnection.Open()
        cmd = New SqlCommand(sqlstr, myConnection)
        cmd.Parameters.AddWithValue("@equip_id", EID)

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

        DirectCast(DataEntryScr.FindControl("txtEID"), TextBox).Text = value.Rows(0).Item(3)
        DirectCast(DataEntryScr.FindControl("txtED"), TextBox).Text = value.Rows(0).Item(4)
        DirectCast(DataEntryScr.FindControl("txtEIN"), TextBox).Text = value.Rows(0).Item(5)
        DirectCast(DataEntryScr.FindControl("txtESD"), TextBox).Text = DateTime.Parse(value.Rows(0).Item(6)).ToString("yyyy-MM-dd")
        DirectCast(DataEntryScr.FindControl("txtRe"), TextBox).Text = value.Rows(0).Item(10)
    End Sub
    Protected Sub SoftDeleteReason()
        Dim sqlstr As String
        Dim cmd As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "UPDATE MAST_EQUIP" +
                        " SET CNCL_FLG = 1  WHERE equip_id = @equip_id"
        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@equip_id", txtEID.Text)
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