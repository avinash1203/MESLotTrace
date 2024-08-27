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
                    sqlstr = "SELECT COUNT(*) FROM MAST_REASON WHERE RSN_CD = @RSN_CD AND RSN_DIV = @RSN_DIV "
                    cmd = New SqlCommand(sqlstr, myconnection)
                    cmd.Parameters.AddWithValue("@RSN_CD", Val(txtRSNcd.Text))
                    cmd.Parameters.AddWithValue("@RSN_DIV", Val(txtRSNDiv.Text))

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
                            "(RSN_DIV,RSN_CD,RESN_NM,DISP_SEQ,NOTES,CNCL_FLG)" +
                            "VALUES(" +
                            "@RSN_DIV,@RSN_CD,@RESN_NM,@DISPSEQ,@NOTES,@CNCL_FLG)"

                    myconnection.Open()
                    cmd = New SqlCommand(sqlstr, myconnection)
                    cmd.Parameters.AddWithValue("@RSN_DIV", Val(txtRSNDiv.Text))
                    cmd.Parameters.AddWithValue("@RSN_CD", Val(txtRSNcd.Text))
                    cmd.Parameters.AddWithValue("@RESN_NM", txtRSNNM.Text.Trim)
                    cmd.Parameters.AddWithValue("@DISPSEQ", txtDispSeq.Text)
                    cmd.Parameters.AddWithValue("@NOTES", txtRem.Text.Trim)
                    cmd.Parameters.AddWithValue("CNCL_FLG", 0)
                    Try
                              cmd.ExecuteNonQuery()
                              DataEntryScr.Visible = False
                              Class1.ShowMsg("Saved Successfully", "Ok", "success")

                    Catch ex As Exception
                              DataEntryScr.Visible = False
                              Class1.ShowMsg("Error: " & Mid(ex.Message, 1, 100), "Continue", "warning")
                              Exit Sub
                    End Try
                    DataEntryScr.Visible = False
                    gvContent.DataBind()
          End Sub
          Protected Sub UpdateMastReason()

                    Dim sqlstr As String
                    Dim cmd As SqlCommand
                    Dim myconnection As New SqlConnection
                    myconnection = New SqlConnection(connstr)

                    sqlstr = "UPDATE MAST_REASON" +
                                        " SET 
                                           RESN_NM=@RSN_NM,
                                           DISP_SEQ=@DISP_SEQ,
                                           NOTES=@NOTES,
                                           CNCL_FLG=@CNCL_FLG
                                           WHERE 
                                           RSN_CD = @RSN_CD AND RSN_DIV = @RSN_DIV "

                    myconnection.Open()
                    cmd = New SqlCommand(sqlstr, myconnection)
                    cmd.Parameters.AddWithValue("@RSN_DIV", Val(txtRSNDiv.Text))
                    cmd.Parameters.AddWithValue("@RSN_CD", Val(txtRSNcd.Text))
                    cmd.Parameters.AddWithValue("@RSN_NM", txtRSNNM.Text.Trim)
                    cmd.Parameters.AddWithValue("@DISP_SEQ", txtDispSeq.Text.Trim)
                    cmd.Parameters.AddWithValue("@NOTES", txtRem.Text.Trim)
                    cmd.Parameters.AddWithValue("CNCL_FLG", 0)

                    Try
                              cmd.ExecuteNonQuery()
                              DataEntryScr.Visible = False
                              Class1.ShowMsg("Updated Successfully", "Ok", "success")
                              'DataEntryScr.Visible = False
                    Catch ex As Exception
                              DataEntryScr.Visible = False
                              Class1.ShowMsg("Error: " & Mid(ex.Message, 1, 100), "Continue", "warning")
                              Exit Sub
                    End Try
                    DataEntryScr.Visible = False
                    gvContent.DataBind()

          End Sub
          Private Sub Retrieve(ByVal rsncd As String, ByVal rsnDiv As String)
                    Dim sqlstr As String

                    Dim myconnection As New SqlConnection
                    myconnection = New SqlConnection(connstr)

                    sqlstr = "SELECT " +
                            "RSN_DIV,RSN_CD,RESN_NM,NOTES,disp_seq,CNCL_FLG " +
                               "FROM MAST_REASON " +
                               "WHERE RSN_CD = '" & rsncd & "' AND RSN_DIV = '" & rsnDiv & "'"

                    myconnection.Open()
                    'cmd = New SqlCommand(sqlstr, myconnection)
                    Dim sda As New SqlDataAdapter
                    Dim dt As New DataTable

                    Try
                              sda = New SqlDataAdapter(sqlstr, myconnection)
                              sda.Fill(dt)
                              txtRSNDiv.Text = dt.Rows(0).Item(0)
                              txtRSNcd.Text = dt.Rows(0).Item(1)
                              txtRSNNM.Text = dt.Rows(0).Item(2)
                              txtRem.Text = dt.Rows(0).Item(3)
                              txtDispSeq.Text = dt.Rows(0).Item(4)
                    Catch ex As Exception
                              DataEntryScr.Visible = False ' Style.Add("z-index", "-99")
                              Class1.ShowMsg(Mid(ex.Message, 1, 100) & " ", "Continue", "warning")
                              Exit Sub
                    End Try
          End Sub

          Private Sub DataEntryScr_Clear()
                    txtRSNcd.Text = String.Empty
                    txtRSNNM.Text = String.Empty
                    txtRSNDiv.Text = String.Empty
                    txtDispSeq.Text = String.Empty
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
          Protected Sub gvContent_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) Handles gvContent.RowCommand
                    If e.CommandName = "Select" Then
                              Dim resultArray() As String = e.CommandArgument.Split("_")
                              DataEntryScr.Visible = True
                              DataEntryScr_Clear()
                              Retrieve(resultArray(0), resultArray(1))
                              txtRSNcd.Enabled = False
                              txtRSNDiv.Enabled = False
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
                    sqlstr = "UPDATE MAST_REASON SET CNCL_FLG = 1,UPD_UTC='" & updt & "',UPDR_ID='" & LoginId & "' " &
                        "WHERE RSN_CD = '" & txtRSNcd.Text & "' AND RSN_DIV = '" & txtRSNDiv.Text & "'"
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