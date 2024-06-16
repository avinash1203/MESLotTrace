Imports System.Data.SqlClient
Public Class MastUOM
    Inherits System.Web.UI.Page

    Public connstr As String
    Public Logonid As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Logonid = Class1.GetLoginId(Request)
        ''Logonid = "9900"
        DataEntryScr.Visible = False

        connstr = System.Configuration.ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Call SaveData()
    End Sub

    Protected Sub SaveData()
        Dim sqlstr As String
        Dim cmd As SqlCommand
        Dim myconnection As New SqlConnection(connstr)
        myconnection.Open()

        ' Check if the record already exists
        sqlstr = "SELECT COUNT(*) FROM MAST_CONV_UOM WHERE conv_unit_bf_cd = @conv_unit_bf_cd"
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@conv_unit_bf_cd", txtUF.Text)

        Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
        If count > 0 Then
            Class1.ShowMsg("Duplicate Conversion Unit Code. Please Check!", "Continue", "warning")
            myconnection.Close()
            Exit Sub
        End If

        If hfPopUpType.Value = "New" Then
            InsertMastUOM(myconnection)
        ElseIf hfPopUpType.Value = "Edit" Then
            UpdateMastUOM(myconnection)
        End If

        myconnection.Close()
        gvContent.DataBind()
    End Sub

    Private Sub InsertMastUOM(ByVal connection As SqlConnection)
        Dim sqlstr As String = "INSERT INTO MAST_CONV_UOM (conv_unit_bf_cd, conv_unit_aft_cd, conv_nmrt, conv_dnmn, cncl_flg, reg_utc, regr_id, upd_utc, updr_id, admin_mnt_notes) " +
                               "VALUES (@conv_unit_bf_cd, @conv_unit_aft_cd, @conv_nmrt, @conv_dnmn, @cncl_flg, @reg_utc, @regr_id, @upd_utc, @updr_id, @admin_mnt_notes)"
        Dim cmd As New SqlCommand(sqlstr, connection)
        cmd.Parameters.AddWithValue("@conv_unit_bf_cd", txtUF.Text)
        cmd.Parameters.AddWithValue("@conv_unit_aft_cd", txtUT.Text)
        cmd.Parameters.AddWithValue("@conv_nmrt", Convert.ToInt32(txtCN.Text))
        cmd.Parameters.AddWithValue("@conv_dnmn", Convert.ToInt32(txtCD.Text))
        cmd.Parameters.AddWithValue("@cncl_flg", "0")
        cmd.Parameters.AddWithValue("@reg_utc", DateTime.Now)
        cmd.Parameters.AddWithValue("@regr_id", Logonid)
        cmd.Parameters.AddWithValue("@upd_utc", DBNull.Value) ' Set to DBNull because it's a new record
        cmd.Parameters.AddWithValue("@updr_id", DBNull.Value) ' Set to DBNull because it's a new record
        cmd.Parameters.AddWithValue("@admin_mnt_notes", txtNotes.Text)

        Try
            cmd.ExecuteNonQuery()
            Class1.ShowMsg("Saved Successfully", "Ok", "success")
            DataEntryScr.Visible = False
        Catch ex As Exception
            Class1.ShowMsg("Error during Save!", "Continue", "warning")
            Exit Sub
        End Try
    End Sub

    Private Sub UpdateMastUOM(ByVal connection As SqlConnection)
        Dim sqlstr As String = "UPDATE MAST_CONV_UOM SET conv_unit_aft_cd = @conv_unit_aft_cd, conv_nmrt = @conv_nmrt, conv_dnmn = @conv_dnmn, cncl_flg = @cncl_flg, " +
                               " upd_utc = @upd_utc, updr_id = @updr_id, admin_mnt_notes = @admin_mnt_notes " +
                               "WHERE conv_unit_bf_cd = @conv_unit_bf_cd"
        Dim cmd As New SqlCommand(sqlstr, connection)
        cmd.Parameters.AddWithValue("@conv_unit_bf_cd", txtUF.Text)
        cmd.Parameters.AddWithValue("@conv_unit_aft_cd", txtUT.Text)
        cmd.Parameters.AddWithValue("@conv_nmrt", Convert.ToInt32(txtCN.Text))
        cmd.Parameters.AddWithValue("@conv_dnmn", Convert.ToInt32(txtCD.Text))
        cmd.Parameters.AddWithValue("@cncl_flg", "0")
        cmd.Parameters.AddWithValue("@upd_utc", DateTime.Now)
        cmd.Parameters.AddWithValue("@updr_id", Logonid)
        cmd.Parameters.AddWithValue("@admin_mnt_notes", txtNotes.Text)

        Try
            cmd.ExecuteNonQuery()
            Class1.ShowMsg("Updated Successfully", "Ok", "success")
            DataEntryScr.Visible = False
        Catch ex As Exception
            Class1.ShowMsg("Error during Update!", "Continue", "warning")
            Exit Sub
        End Try
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        DeleteMastUOM()
        DataEntryScr.Visible = False
        gvContent.DataBind()
    End Sub

    Private Sub DeleteMastUOM()
        Dim sqlstr As String = "DELETE FROM MAST_CONV_UOM WHERE conv_unit_bf_cd = @conv_unit_bf_cd"
        Dim cmd As New SqlCommand(sqlstr, New SqlConnection(connstr))
        cmd.Parameters.AddWithValue("@conv_unit_bf_cd", txtUF.Text)

        Try
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            Class1.ShowMsg("Deleted Successfully", "Ok", "success")
        Catch ex As Exception
            Class1.ShowMsg("Error during Delete!", "Continue", "warning")
        Finally
            cmd.Connection.Close()
        End Try
    End Sub

    Protected Sub gvContent_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) Handles gvContent.RowCommand
        If e.CommandName = "Select" Then
            hfPopUpType.Value = "Edit"
            GetSelected(e.CommandArgument)
        End If
    End Sub

    Protected Sub GetSelected(ByVal conv_unit_bf_cd As String)
        Dim sqlstr As String = "SELECT conv_unit_bf_cd, conv_unit_aft_cd, conv_nmrt, conv_dnmn, cncl_flg, reg_utc, regr_id, upd_utc, updr_id, admin_mnt_notes " +
                               "FROM MAST_CONV_UOM WHERE conv_unit_bf_cd = @conv_unit_bf_cd"
        Dim cmd As New SqlCommand(sqlstr, New SqlConnection(connstr))
        cmd.Parameters.AddWithValue("@conv_unit_bf_cd", conv_unit_bf_cd)

        Try
            cmd.Connection.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                txtUF.Text = reader("conv_unit_bf_cd").ToString()
                txtUT.Text = reader("conv_unit_aft_cd").ToString()
                txtCN.Text = reader("conv_nmrt").ToString()
                txtCD.Text = reader("conv_dnmn").ToString()
                txtNotes.Text = reader("admin_mnt_notes").ToString()
                DataEntryScr.Visible = True
            Else
                Class1.ShowMsg("Record not found!", "Continue", "warning")
            End If
        Catch ex As Exception
            Class1.ShowMsg("Error during Fetching!", "Continue", "warning")
        Finally
            cmd.Connection.Close()
        End Try
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DataEntryScr.Visible = False
    End Sub

    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearData()
        DataEntryScr.Visible = True
        hfPopUpType.Value = "New"
    End Sub

    Private Sub ClearData()
        txtCD.Text = ""
        txtCN.Text = ""
        txtNotes.Text = ""
        txtUF.Text = ""
        txtUT.Text = ""
    End Sub

    Protected Sub ImageButton3_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton3.Click
        Response.Redirect("appMainpage.aspx?LoginID=" & Logonid & "&Op=2")
    End Sub
End Class
