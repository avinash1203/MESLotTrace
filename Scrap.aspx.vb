Imports System.Data.SqlClient
Imports System.Runtime.InteropServices.ComTypes
Imports System.Security.Cryptography

Public Class Scrap
          Inherits System.Web.UI.Page
          Public LogonID As String
          Public connstr As String
          Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
                    LogonID = Class1.GetLoginId(Request)
                    connstr = System.Configuration.ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
          End Sub
          Protected Sub btnFilter_Click(sender As Object, e As EventArgs)
                    BindGrid()
          End Sub
          Private Sub BindGrid()
                    Dim lineId As String = ttLineID.Text
                    Dim procFlowId As String = txtProcess.Text
                    Dim stepCd As String = txtStepCode.Text
                    Dim itemCd As String = txtModel.Text
                    Dim isCompRej As Boolean = RBYes.Checked
                    Dim sqlQuery As String = Class1.GenerateScrapSqlQuery(lineId, procFlowId, stepCd, itemCd, isCompRej)
                    Dim parameters As New Dictionary(Of String, Object) From {
                            {"@lineId", lineId},
                            {"@procFlowId", procFlowId},
                            {"@stepCd", stepCd},
                            {"@itemCd", itemCd}
                   }

                    ' Remove parameters that are empty
                    For Each key In parameters.Keys.ToList()
                              If String.IsNullOrEmpty(parameters(key).ToString()) Then
                                        parameters.Remove(key)
                              End If
                    Next

                    Dim dbHelper As New DatabaseHelper()
                    Dim dataTable As DataTable = dbHelper.GetData(sqlQuery, parameters)

                    GVContent.DataSource = dataTable
                    GVContent.DataBind()
          End Sub
          Protected Sub gvContent_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) Handles GVContent.RowCommand
                    If e.CommandName = "Scrap" Then
                              DEScrap.Visible = True
                              LblHdr.Text = "Scrap of Item"
                              ddlReason.DataSource = ddlReasonSdaScrap
                    End If
                    If e.CommandName = "Reject" Then
                              DEScrap.Visible = True
                              LblHdr.Text = "Reject of Item"
                              ddlReason.DataSource = ddlReasonSdaReject
                    End If
          End Sub
          Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
                    DataEntryScr_Clear()
                    DEScrap.Visible = False
          End Sub

          Private Sub DataEntryScr_Clear()
                    txtItemCd.Text = String.Empty
                    txtSNo.Text = String.Empty
                    '
          End Sub
          Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
                    '  Call CopyRowAndAdjustQty(hfTagSeq.Value, txtItemCd.Text)
          End Sub
          Protected Sub CopyRowAndAdjustQty(tag_seq As String, adj_qty As String)
                    ' Define the connection string and SQL queries
                    Dim connstr As String = System.Configuration.ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
                    Dim selectSql As String = "SELECT [tenant_id]
                                    ,[cmp_cd]
                                    ,[plnt_cd]
                                    ,[line_id]
                                    ,[proc_flow_id]
                                    ,[step_cd]
                                    ,[equip_id]
                                    ,[update_date]
                                    ,[item_cd]
                                    ,[vendor_cd]
                                    ,[mamm_lot_no]
                                    ,[vendor_lot_no]
                                    ,[input_qty]
                                    ,[current_qty]
                                    ,[plnt_cd_s]
                                    ,[str_location]
                                    ,[uom]
                                    ,[tag_seq]
                                    ,[upd_utc]
                                    ,[updr_id]
                                    ,[upd_pg_id]
                                    ,[admin_mnt_notes]
                               FROM [dbo].[TRX_PART_INPUT] 
                               WHERE tag_seq = @tag_seq"

                    Dim insertSql As String = "INSERT INTO [dbo].[TRX_PART_ADJ] 
                                ([tenant_id]
                                ,[cmp_cd]
                                ,[plnt_cd]
                                ,[line_id]
                                ,[proc_flow_id]
                                ,[step_cd]
                                ,[equip_id]
                                ,[update_date]
                                ,[item_cd]
                                ,[vendor_cd]
                                ,[mamm_lot_no]
                                ,[vendor_lot_no]
                                ,[input_qty]
                                ,[current_qty]
                                ,[adj_qty]
                                ,[plnt_cd_s]
                                ,[str_location]
                                ,[uom]
                                ,[tag_seq]
                                ,[rsn_div]
                                ,[rsn_cd]
                                ,[upd_utc]
                                ,[updr_id]
                                ,[upd_pg_id]
                                ,[admin_mnt_notes])
                               VALUES
                                (@tenant_id
                                ,@cmp_cd
                                ,@plnt_cd
                                ,@line_id
                                ,@proc_flow_id
                                ,@step_cd
                                ,@equip_id
                                ,@update_date
                                ,@item_cd
                                ,@vendor_cd
                                ,@mamm_lot_no
                                ,@vendor_lot_no
                                ,@input_qty
                                ,@current_qty
                                ,@adj_qty
                                ,@plnt_cd_s
                                ,@str_location
                                ,@uom
                                ,@tag_seq
                                ,@rsn_div
                                ,@rsn_cd
                                ,@upd_utc
                                ,@updr_id
                                ,@upd_pg_id
                                ,@admin_mnt_notes)"

                    Dim updateSql As String = "UPDATE [dbo].[TRX_PART_INPUT]
                               SET [current_qty] = @adj_qty,[updr_id]=@updr_id, [upd_utc] =@upd_utc
                               WHERE [tag_seq] = @tag_seq"

                    ' Initialize the connection and command
                    Using myConnection As New SqlConnection(connstr)
                              myConnection.Open()

                              ' Retrieve the row from TRX_PART_INPUT
                              Using selectCmd As New SqlCommand(selectSql, myConnection)
                                        selectCmd.Parameters.AddWithValue("@tag_seq", tag_seq)
                                        Dim dt As New DataTable()
                                        Using da As New SqlDataAdapter(selectCmd)
                                                  da.Fill(dt)
                                        End Using

                                        If dt.Rows.Count > 0 Then
                                                  Dim row As DataRow = dt.Rows(0)

                                                  ' Insert the row into TRX_PART_ADJ
                                                  Using insertCmd As New SqlCommand(insertSql, myConnection)
                                                            insertCmd.Parameters.AddWithValue("@tenant_id", row("tenant_id"))
                                                            insertCmd.Parameters.AddWithValue("@cmp_cd", row("cmp_cd"))
                                                            insertCmd.Parameters.AddWithValue("@plnt_cd", row("plnt_cd"))
                                                            insertCmd.Parameters.AddWithValue("@line_id", row("line_id"))
                                                            insertCmd.Parameters.AddWithValue("@proc_flow_id", row("proc_flow_id"))
                                                            insertCmd.Parameters.AddWithValue("@step_cd", row("step_cd"))
                                                            insertCmd.Parameters.AddWithValue("@equip_id", row("equip_id"))
                                                            insertCmd.Parameters.AddWithValue("@update_date", row("update_date"))
                                                            insertCmd.Parameters.AddWithValue("@item_cd", row("item_cd"))
                                                            insertCmd.Parameters.AddWithValue("@vendor_cd", row("vendor_cd"))
                                                            insertCmd.Parameters.AddWithValue("@mamm_lot_no", row("mamm_lot_no"))
                                                            insertCmd.Parameters.AddWithValue("@vendor_lot_no", row("vendor_lot_no"))
                                                            insertCmd.Parameters.AddWithValue("@input_qty", row("input_qty"))
                                                            insertCmd.Parameters.AddWithValue("@current_qty", row("current_qty"))
                                                            insertCmd.Parameters.AddWithValue("@adj_qty", adj_qty)
                                                            insertCmd.Parameters.AddWithValue("@plnt_cd_s", row("plnt_cd_s"))
                                                            insertCmd.Parameters.AddWithValue("@str_location", row("str_location"))
                                                            insertCmd.Parameters.AddWithValue("@uom", row("uom"))
                                                            insertCmd.Parameters.AddWithValue("@tag_seq", row("tag_seq"))
                                                            insertCmd.Parameters.AddWithValue("@rsn_div", 103) ' Adjust as necessary
                                                            insertCmd.Parameters.AddWithValue("@rsn_cd", ddlReason.SelectedValue) ' Adjust as necessary
                                                            insertCmd.Parameters.AddWithValue("@upd_utc", row("upd_utc"))
                                                            insertCmd.Parameters.AddWithValue("@updr_id", row("updr_id"))
                                                            insertCmd.Parameters.AddWithValue("@upd_pg_id", row("upd_pg_id"))
                                                            insertCmd.Parameters.AddWithValue("@admin_mnt_notes", row("admin_mnt_notes"))

                                                            insertCmd.ExecuteNonQuery()
                                                  End Using

                                                  ' Update the current_qty in TRX_PART_INPUT
                                                  Using updateCmd As New SqlCommand(updateSql, myConnection)
                                                            updateCmd.Parameters.AddWithValue("@adj_qty", adj_qty)
                                                            updateCmd.Parameters.AddWithValue("@tag_seq", tag_seq)
                                                            updateCmd.Parameters.AddWithValue("@updr_id", LogonID)
                                                            updateCmd.Parameters.AddWithValue("@upd_utc", Format(Now, "yyyy-MM-dd HH:mm:ss"))
                                                            updateCmd.ExecuteNonQuery()
                                                  End Using
                                        End If
                              End Using
                    End Using

                    BindGrid()
                    DataEntryScr_Clear()
          End Sub


          Protected Sub gvContent_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
                    GVContent.PageIndex = e.NewPageIndex
                    BindGrid()
          End Sub
          Protected Sub ImageButton3_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton3.Click
                    Response.Redirect("AppMainpage.aspx?LogonID=" & LogonID & "&Op=3")
          End Sub


End Class