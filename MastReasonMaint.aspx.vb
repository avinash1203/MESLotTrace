Imports System.Configuration
Imports System.Data.SqlClient
'Imports class1
Public Class MastReasonMaint
    Inherits System.Web.UI.Page
    Public connstr As String
    Public LoginId As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoginId = Class1.GetLoginId(Request)
        ConfirmDelete.Visible = False
        connstr = System.Configuration.ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
        gvContent.DataBind()
        LoginUser.Text = "User ID : " & Class1.GetuserName(LoginId)
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
        sqlstr = "SELECT COUNT(*) FROM MAST_REASON WHERE RSN_CD = @RSN_CD AND RSN_DIV = @RSN_DIV AND RSN_GRP_CD = @RSN_GRP_CD"
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@RSN_CD", Val(txtRSNcd.Text))
        cmd.Parameters.AddWithValue("@RSN_DIV", Val(txtRSNDiv.Text))
        cmd.Parameters.AddWithValue("@RSN_GRP_CD", Val(txtRSNGrpCd.Text))
        myconnection.Open()
        Dim ANS As Integer = cmd.ExecuteScalar
        myconnection.Close()

        If ANS > 0 Then
            Call UpdateMastReason()
        Else
            Call InsertMastReason()
        End If
    End Sub
    Private Sub InsertMastReason()
        Dim sqlstr As String
        Dim cmd As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "INSERT INTO MAST_REASON" +
                            "(RSN_CD,RSN_NM,RSN_DIV,RSN_GRP_CD,CAUSE_DIV,PROC_ID_CAUSE,DEPT_ID_CAUSE," +
                               "DATA_TRANSFER_FLG,DATA_TRANSFER_MOV_FLG,NOTES,CNCL_FLG,UPD_ID,UPD_DATE)" +
                            "VALUES(" +
                            "@RSN_CD,@RSN_NM,@RSN_DIV,@RSN_GRP_CD,@CAUSE_DIV,@PROC_ID_CAUSE,@DEPT_ID_CAUSE," +
                            "@DATA_TRANSFER_FLG,@DATA_TRANSFER_MOV_FLG,@NOTES,@CNCL_FLG,@UPD_ID,@UPD_DATE)"

        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@RSN_CD", Val(txtRSNcd.Text))
        cmd.Parameters.AddWithValue("@RSN_NM", txtRSNNM.Text.Trim)
        cmd.Parameters.AddWithValue("@RSN_DIV", Val(txtRSNDiv.Text))
        cmd.Parameters.AddWithValue("@RSN_GRP_CD", txtRSNGrpCd.Text.Trim)
        cmd.Parameters.AddWithValue("@CAUSE_DIV", String.Empty)
        cmd.Parameters.AddWithValue("@PROC_ID_CAUSE", String.Empty)
        cmd.Parameters.AddWithValue("@DEPT_ID_CAUSE", txtSAPCostCntr.Text.Trim)
        cmd.Parameters.AddWithValue("@DATA_TRANSFER_FLG", Val(txtSAPTrnCd.Text))
        cmd.Parameters.AddWithValue("@DATA_TRANSFER_MOV_FLG", Val(txtSAPMovCd.Text))
        cmd.Parameters.AddWithValue("@NOTES", txtRem.Text.Trim)
        cmd.Parameters.AddWithValue("CNCL_FLG", 0)
        cmd.Parameters.AddWithValue("@UPD_ID", LoginId)
        cmd.Parameters.AddWithValue("@UPD_DATE", Format(Now, "yyyy-MM-dd HH:mm:ss"))
        Try
            cmd.ExecuteNonQuery()

            Class1.ShowMsg("Saved Successfully", "Ok", "success")
            ' DataEntryScr.Visible = False

        Catch ex As Exception
            Class1.ShowMsg("Error during Save!", "Continue", "warning")
            Exit Sub
        End Try
        DataEntryScr.Visible = False
    End Sub
    Protected Sub UpdateMastReason()

        Dim sqlstr As String
        Dim cmd As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "UPDATE MAST_REASON" +
                            " SET 
                                           RSN_NM=@RSN_NM,
                                           RSN_DIV=@RSN_DIV,
                                           RSN_GRP_CD=@RSN_GRP_CD,
                                           CAUSE_DIV=@CAUSE_DIV,
                                           PROC_ID_CAUSE=@PROC_ID_CAUSE,
                                           DEPT_ID_CAUSE=@DEPT_ID_CAUSE,
                                           DATA_TRANSFER_FLG=@DATA_TRANSFER_FLG,
                                           DATA_TRANSFER_MOV_FLG=@DATA_TRANSFER_MOV_FLG,
                                           NOTES=@NOTES,
                                           CNCL_FLG=@CNCL_FLG,
                                           UPD_ID=@UPD_ID,
                                           UPD_DATE= @UPD_DATE
                                           WHERE 
                                           RSN_CD = @RSN_CD AND RSN_DIV = @RSN_DIV AND RSN_GRP_CD = @RSN_GRP_CD"

        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@RSN_CD", Val(txtRSNcd.Text))
        cmd.Parameters.AddWithValue("@RSN_NM", txtRSNNM.Text.Trim)
        cmd.Parameters.AddWithValue("@RSN_DIV", Val(txtRSNDiv.Text))
        cmd.Parameters.AddWithValue("@RSN_GRP_CD", txtRSNGrpCd.Text.Trim)
        cmd.Parameters.AddWithValue("@CAUSE_DIV", String.Empty)
        cmd.Parameters.AddWithValue("@PROC_ID_CAUSE", String.Empty)
        cmd.Parameters.AddWithValue("@DEPT_ID_CAUSE", txtSAPCostCntr.Text.Trim)
        cmd.Parameters.AddWithValue("@DATA_TRANSFER_FLG", Val(txtSAPTrnCd.Text))
        cmd.Parameters.AddWithValue("@DATA_TRANSFER_MOV_FLG", Val(txtSAPMovCd.Text))
        cmd.Parameters.AddWithValue("@NOTES", txtRem.Text.Trim)
        cmd.Parameters.AddWithValue("CNCL_FLG", 0)
        cmd.Parameters.AddWithValue("@UPD_ID", LoginId)
        cmd.Parameters.AddWithValue("@UPD_DATE", Format(Now, "yyyy-MM-dd HH:mm:ss"))
        Try
            cmd.ExecuteNonQuery()

            Class1.ShowMsg("Updated Successfully", "Ok", "success")
            'DataEntryScr.Visible = False
        Catch ex As Exception
            Class1.ShowMsg("Error during Update!", "Continue", "warning")
            Exit Sub
        End Try
        DataEntryScr.Visible = False

    End Sub
    Private Sub Retrieve(ByVal rsncd As String, ByVal rsnDiv As String, ByVal rsdGrp As String)
        Dim sqlstr As String

        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "SELECT " +
                            "RSN_CD,RSN_NM,RSN_DIV,RSN_GRP_CD,CAUSE_DIV,PROC_ID_CAUSE,DEPT_ID_CAUSE," +
                               "DATA_TRANSFER_FLG,DATA_TRANSFER_MOV_FLG,NOTES,CNCL_FLG,UPD_ID,UPD_DATE " +
                               "FROM MAST_REASON " +
                               "WHERE RSN_CD = '" & rsncd & "' AND RSN_DIV = '" & rsnDiv & "' AND RSN_GRP_CD = '" & rsdGrp & "'"
        '"VALUES(" +
        '"@RSN_CD,@RSN_NM,@RSN_DIV,@RSN_GRP_CD,@CAUSE_DIV,@PROC_ID_CAUSE,@DEPT_ID_CAUSE," +
        '"@DATA_TRANSFER_FLG,@DATA_TRANSFER_MOV_FLG,@NOTES,@CNCL_FLG,@UPD_ID,@UPD_DATE)"

        myconnection.Open()
        'cmd = New SqlCommand(sqlstr, myconnection)
        Dim sda As New SqlDataAdapter
        Dim dt As New DataTable

        Try
            sda = New SqlDataAdapter(sqlstr, myconnection)
            sda.Fill(dt)
            txtRSNcd.Text = dt.Rows(0).Item(0)
            txtRSNNM.Text = dt.Rows(0).Item(1)
            txtRSNDiv.Text = dt.Rows(0).Item(2)
            txtRSNGrpCd.Text = dt.Rows(0).Item(3)
            ' = dt.Rows(0).Item(4)
            'cmd.Parameters.AddWithValue("@PROC_ID_CAUSE", String.Empty)

            txtSAPCostCntr.Text = dt.Rows(0).Item(6)
            txtSAPTrnCd.Text = dt.Rows(0).Item(7)
            txtSAPMovCd.Text = dt.Rows(0).Item(8)
            txtRem.Text = dt.Rows(0).Item(9)
            'cmd.Parameters.AddWithValue("CNCL_FLG", 0)
            'cmd.Parameters.AddWithValue("@UPD_ID", Logonid)
            'cmd.Parameters.AddWithValue("@UPD_DATE", Format(Now, "yyyy-MM-dd HH:mm:ss"))

        Catch ex As Exception
            Class1.ShowMsg("Error during Save!", "Continue", "warning")
            Exit Sub
        End Try
    End Sub

    Private Sub DataEntryScr_Clear()
        txtRSNcd.Text = String.Empty
        txtRSNNM.Text = String.Empty
        txtRSNDiv.Text = String.Empty
        txtRSNGrpCd.Text = String.Empty
        txtSAPCostCntr.Text = String.Empty
        txtSAPTrnCd.Text = String.Empty
        txtSAPMovCd.Text = String.Empty
        txtRem.Text = String.Empty
    End Sub

    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        DataEntryScr_Clear()
        DataEntryScr.Visible = False
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DataEntryScr_Clear()
        DataEntryScr.Visible = False
    End Sub

    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        DataEntryScr_Clear()
        DataEntryScr.Visible = True
    End Sub

    'Protected Sub gvContent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvContent.SelectedIndexChanged
    '    Dim rw As Integer = gvContent.SelectedIndex
    '    Dim rsncd As String
    '    rsncd = gvContent.Rows(rw).Cells(1).Text
    '    DataEntryScr_Clear()
    '    DataEntryScr.Visible = True
    '    Dim resultArray() As String = e.CommandArgument.Split("_")
    '    GetSelected(resultArray(0), resultArray(1), resultArray(2), resultArray(3))
    '    Call Retrieve(rsncd)
    'End Sub

    Protected Sub gvContent_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) Handles gvContent.RowCommand
        If e.CommandName = "Select" Then
            Dim resultArray() As String = e.CommandArgument.Split("_")
            DataEntryScr.Visible = True
            DataEntryScr_Clear()
            Retrieve(resultArray(0), resultArray(1), resultArray(2))
        End If
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ConfirmDelete.Visible = True
    End Sub

    Protected Sub btnConfirmDelete_Click(sender As Object, e As EventArgs) Handles btnConfirmDelete.Click
        Dim sqlstr As String
        Dim cmd As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)
        Dim updt As String = Format(Now, "yyyy-MM-dd HH:mm")
        sqlstr = "UPDATE MAST_REASON SET CNCL_FLG = 1,UPD_DATE='" & updt & "',UPD_ID='" & LoginId & "' " &
                        "WHERE RSN_CD = '" & txtRSNcd.Text & "' AND RSN_DIV = '" & txtRSNDiv.Text & "' AND RSN_GRP_CD = '" & txtRSNGrpCd.Text & "'"
        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)
        Try
            cmd.ExecuteNonQuery()
            Class1.ShowMsg("Delete Completed!", "Continue", "warning")
            gvContent.DataBind()

        Catch ex As Exception
            Class1.ShowMsg("Error during Delete!", "Continue", "warning")
            Exit Sub
        End Try
        ConfirmDelete.Visible = False
        DataEntryScr.Visible = False
        gvContent.DataBind()
    End Sub

    Protected Sub btnCanceldelete_Click(sender As Object, e As EventArgs) Handles btnCanceldelete.Click
        ConfirmDelete.Visible = False
    End Sub

    Protected Sub ImageButton3_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton3.Click
        Response.Redirect("APPMainpage.aspx?LoginID=" & LoginId & "&Op=2")
    End Sub

    Protected Sub gvContent_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvContent.PageIndex = e.NewPageIndex
        gvContent.DataBind()
    End Sub
End Class