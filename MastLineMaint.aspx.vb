Imports System.Data.SqlClient

Public Class MastLineMaint
          Inherits System.Web.UI.Page

          Public connstr As String
          Public Logonid As String
          Public Op As Integer
          Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
                    Logonid = Request.QueryString("LogonID")
                    Op = Request.QueryString("Op")
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
                    sqlstr = "SELECT COUNT(*) FROM MAST_LINE WHERE line_id = @line_id"
                    cmd = New SqlCommand(sqlstr, myconnection)
                    cmd.Parameters.AddWithValue("@line_id", txtLID.Text.Trim)
                    myconnection.Open()
                    Dim ANS As Integer = cmd.ExecuteScalar
                    myconnection.Close()

                    If ANS > 0 And hfPopUpType.Value = "New" Then
                              Class1.ShowMsg("Duplicate Line ID..Please Check!", "Continue", "warning")
                              Exit Sub
                    End If

                    If ANS > 0 Then
                              Call UpdateMastLine()
                    Else
                              Call InsertMastLine()
                    End If
                    gvContent.DataBind()
          End Sub


          Private Sub InsertMastLine()
                    Dim sqlstr As String
                    Dim cmd As SqlCommand

                    Dim sqlstr2 As String
                    Dim cmd2 As SqlCommand
                    Dim myconnection As New SqlConnection
                    myconnection = New SqlConnection(connstr)

                    sqlstr = "INSERT INTO MAST_LINE" +
                                      "([cmp_cd]
                           ,[plnt_cd]
                           ,[line_id]
                           ,[line_nm]
                           ,[lproc_id]
                           ,[line_nm_local]
                           ,[shiftid]
                            ,[Notes]
                           ,[CNCL_FLG])" +
                            "VALUES(@cmp_cd,@plnt_cd,@line_id,@line_nm,@lproc_id,@line_nm_local,@shift_ptrn_id,@notes,@CNCL_FLG)"


                    sqlstr2 = "INSERT INTO MAST_LINE2" +
                                      "([cmp_cd]
                                        ,[plnt_cd]
                                        ,[line_id]
                                        ,[cost_center]
                                        ,[str_location]
                                        ,[CNCL_FLG])  " +
                                        "VALUES(" +
                                        "@cmp_cd,@plnt_cd,@line_id,@cost_center,@str_location,@CNCL_FLG)"

                    myconnection.Open()
                    cmd = New SqlCommand(sqlstr, myconnection)
                    cmd.Parameters.AddWithValue("@cmp_cd", ddlCC.SelectedValue)
                    cmd.Parameters.AddWithValue("@plnt_cd", ddlPC.SelectedValue)
                    cmd.Parameters.AddWithValue("@line_id", txtLID.Text.Trim)
                    cmd.Parameters.AddWithValue("@line_nm", Val(txtLD.Text.Trim))
                    cmd.Parameters.AddWithValue("@lproc_id", txtLprocId.Text.Trim)
                    cmd.Parameters.AddWithValue("@line_nm_local", txtLNL.Text)
                    cmd.Parameters.AddWithValue("@shift_ptrn_id", ddlShift.SelectedValue)
                    'cmd.Parameters.AddWithValue("@cost_center", txtCostCenter.Text)
                    'cmd.Parameters.AddWithValue("@str_location", txtSL.Text)
                    cmd.Parameters.AddWithValue("@CNCL_FLG", 0)
                    'cmd.Parameters.AddWithValue("@REGR_ID", Logonid)
                    'cmd.Parameters.AddWithValue("@REGR_DATE", Format(Now, "yyyy-MM-dd HH:mm:ss"))
                    cmd.Parameters.AddWithValue("@NOTES", txtNotes.Text)


                    cmd2 = New SqlCommand(sqlstr2, myconnection)
                    cmd2.Parameters.AddWithValue("@cmp_cd", ddlCC.SelectedValue)
                    cmd2.Parameters.AddWithValue("@plnt_cd", ddlPC.SelectedValue)
                    cmd2.Parameters.AddWithValue("@line_id", txtLID.Text.Trim)
                    'cmd2.Parameters.AddWithValue("@line_nm", Val(txtLD.Text.Trim))
                    'cmd2.Parameters.AddWithValue("@lproc_id", txtLprocId.Text.Trim)
                    'cmd2.Parameters.AddWithValue("@line_nm_local", txtLNL.Text)
                    'cmd2.Parameters.AddWithValue("@shift_ptrn_id", ddlShift.SelectedValue)
                    cmd2.Parameters.AddWithValue("@cost_center", txtCostCenter.Text)
                    cmd2.Parameters.AddWithValue("@str_location", txtSL.Text)
                    cmd2.Parameters.AddWithValue("@CNCL_FLG", 0)
                    'cmd2.Parameters.AddWithValue("@REGR_ID", Logonid)
                    'cmd2.Parameters.AddWithValue("@REGR_DATE", Format(Now, "yyyy-MM-dd HH:mm:ss"))
                    'cmd2.Parameters.AddWithValue("@NOTES", txtNotes.Text)
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
          Protected Sub UpdateMastLine()

                    Dim sqlstr As String
                    Dim cmd As SqlCommand

                    Dim sqlstr2 As String
                    Dim cmd2 As SqlCommand
                    Dim myconnection As New SqlConnection
                    myconnection = New SqlConnection(connstr)

                    sqlstr = "UPDATE MAST_LINE SET " +
                                       "[cmp_cd] =@cmp_cd
                                        ,[plnt_cd]=@plnt_cd
                                        ,[line_id]=@line_id
                                        ,[line_nm]=@line_nm
                                        ,[lproc_id]=@lproc_id
                                        ,[line_nm_local]=@line_nm_local
                                        ,[shiftid]=@shift_ptrn_id
                                        ,[notes]=@notes
                                        ,[CNCL_FLG]=@CNCL_FLG
                            WHERE 
                            [line_id]=@line_id"

                    sqlstr2 = "UPDATE MAST_LINE2 SET " +
                                       "[cmp_cd] =@cmp_cd
                                       ,[plnt_cd]=@plnt_cd
                                       ,[cost_center]=@cost_center
                                       ,[str_location]=@str_location
                                        WHERE 
                                       [line_id]=@line_id"

                    myconnection.Open()
                    cmd = New SqlCommand(sqlstr, myconnection)
                    cmd2 = New SqlCommand(sqlstr2, myconnection)

                    cmd.Parameters.AddWithValue("@cmp_cd", ddlCC.SelectedValue)
                    cmd.Parameters.AddWithValue("@plnt_cd", ddlPC.SelectedValue)
                    cmd.Parameters.AddWithValue("@line_id", txtLID.Text.Trim)
                    cmd.Parameters.AddWithValue("@line_nm", txtLD.Text.Trim)
                    cmd.Parameters.AddWithValue("@lproc_id", txtLprocId.Text.Trim)
                    cmd.Parameters.AddWithValue("@line_nm_local", txtLNL.Text)
                    cmd.Parameters.AddWithValue("@shift_ptrn_id", ddlShift.SelectedValue)
                    '   cmd.Parameters.AddWithValue("@cost_center", txtCostCenter.Text)
                    '    cmd.Parameters.AddWithValue("@str_location", txtSL.Text)
                    cmd.Parameters.AddWithValue("@CNCL_FLG", 0)
                    '  cmd.Parameters.AddWithValue("@UPD_ID", Logonid)
                    cmd.Parameters.AddWithValue("@NOTES", txtNotes.Text)
                    '  cmd.Parameters.AddWithValue("@UPD_DATE", Format(Now, "yyyy-MM-dd HH:mm:ss"))

                    cmd2.Parameters.AddWithValue("@cmp_cd", ddlCC.SelectedValue)
                    cmd2.Parameters.AddWithValue("@plnt_cd", ddlPC.SelectedValue)
                    cmd2.Parameters.AddWithValue("@line_id", txtLID.Text.Trim)
                    'cmd2.Parameters.AddWithValue("@line_nm", txtLD.Text.Trim)
                    'cmd2.Parameters.AddWithValue("@lproc_id", txtLprocId.Text.Trim)
                    'cmd2.Parameters.AddWithValue("@line_nm_local", txtLNL.Text)
                    'cmd2.Parameters.AddWithValue("@shift_ptrn_id", ddlShift.SelectedValue)
                    cmd2.Parameters.AddWithValue("@cost_center", txtCostCenter.Text)
                    cmd2.Parameters.AddWithValue("@str_location", txtSL.Text)
                    cmd2.Parameters.AddWithValue("@CNCL_FLG", 0)
                    'cmd2.Parameters.AddWithValue("@UPD_ID", Logonid)
                    'cmd2.Parameters.AddWithValue("@NOTES", txtNotes.Text)
                    'cmd2.Parameters.AddWithValue("@UPD_DATE", Format(Now, "yyyy-MM-dd HH:mm:ss"))
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
                    txtLID.Text = String.Empty
                    txtLD.Text = String.Empty
                    txtLprocId.Text = String.Empty
                    txtLNL.Text = String.Empty
                    txtCostCenter.Text = String.Empty
                    txtSL.Text = String.Empty
                    txtNotes.Text = String.Empty
                    ddlCC.ClearSelection()
                    ddlPC.ClearSelection()
                    ddlShift.ClearSelection()
                    hfPopUpType.Value = ""
                    txtLID.ReadOnly = False
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
                              Dim LID As String = e.CommandArgument
                              hfPopUpType.Value = "Edit"
                              txtLID.ReadOnly = True
                              GetSelected(LID)

                    End If
          End Sub

          Protected Sub GetSelected(LID As String)
                    connstr = System.Configuration.ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
                    Dim sqlstr As String
                    Dim myConnection As SqlConnection

                    ' sqlstr = "SELECT [cmp_cd]
                    ',[plnt_cd]
                    ',[line_id]
                    ',[line_nm]
                    ',[lproc_id]
                    ',[line_nm_local]
                    ',[shift_ptrn_id]
                    ',[cost_center]
                    ',[str_location]
                    ',[REGR_ID]
                    ',[REGR_DATE]
                    ',[UPD_ID]
                    ',[UPD_DATE]
                    ',[CNCL_FLG] from [MAST_LINE] " +
                    '          "WHERE line_id='" & Trim(LID) & "'"

                    sqlstr = "SELECT a.cmp_cd,a.plnt_cd,a.line_id,a.line_nm,a.lproc_id,a.line_nm_local,a.ShiftID,a.notes,b.cost_center,b.str_location 
                                      FROM MAST_LINE a
                                      LEFT JOIN MAST_LINE2 b on a.line_id = b.line_id 
                                      WHERE a.line_id='" & Trim(LID) & "'"

                    Dim cmd As SqlCommand

                    myConnection = New SqlConnection(connstr)
                    myConnection.Open()
                    cmd = New SqlCommand(sqlstr, myConnection)
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

                    DirectCast(DataEntryScr.FindControl("txtLID"), TextBox).Text = value.Rows(0).Item(2)
                    DirectCast(DataEntryScr.FindControl("txtLD"), TextBox).Text = value.Rows(0).Item(3)
                    DirectCast(DataEntryScr.FindControl("txtLprocId"), TextBox).Text = value.Rows(0).Item(4)
                    DirectCast(DataEntryScr.FindControl("txtLNL"), TextBox).Text = value.Rows(0).Item(5)

                    DirectCast(DataEntryScr.FindControl("ddlShift"), DropDownList).Items.Clear()
                    DirectCast(DataEntryScr.FindControl("ddlShift"), DropDownList).DataBind()
                    DirectCast(DataEntryScr.FindControl("ddlShift"), DropDownList).SelectedValue = value.Rows(0).Item(6)

                    DirectCast(DataEntryScr.FindControl("txtNotes"), TextBox).Text = value.Rows(0).Item(7)

                    DirectCast(DataEntryScr.FindControl("txtCostCenter"), TextBox).Text = value.Rows(0).Item(8)
                    DirectCast(DataEntryScr.FindControl("txtSL"), TextBox).Text = value.Rows(0).Item(9)
                    DataEntryScr.Attributes("transform") = "translate(-10%, -50%);"
          End Sub
          Protected Sub SoftDeleteReason()
                    Dim sqlstr As String
                    Dim cmd As SqlCommand
                    Dim sqlstr2 As String
                    Dim cmd2 As SqlCommand
                    Dim myconnection As New SqlConnection
                    myconnection = New SqlConnection(connstr)

                    sqlstr = "UPDATE [MAST_LINE]" +
                                        " SET CNCL_FLG = 1  WHERE line_id=@line_id"

                    sqlstr2 = "UPDATE [MAST_LINE2]" +
                                        " SET CNCL_FLG = 1  WHERE line_id=@line_id"
                    myconnection.Open()
                    cmd = New SqlCommand(sqlstr, myconnection)
                    cmd2 = New SqlCommand(sqlstr2, myconnection)
                    cmd.Parameters.AddWithValue("@line_id", txtLID.Text)
                    cmd2.Parameters.AddWithValue("@line_id", txtLID.Text)
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

          Protected Sub ImageButton3_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton3.Click
                    Response.Redirect("AppMainpage.aspx?LoginID=" & Logonid & "&Op=2")
          End Sub

End Class