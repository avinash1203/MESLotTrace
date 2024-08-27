Imports System.Data.SqlClient

Public Class LotMainSel
          Inherits System.Web.UI.Page

          Public connstr As String
          Public Logonid As String
          Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
                    Logonid = Request.QueryString("LogonID")
                    connstr = System.Configuration.ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
                    If Not IsPostBack Then
                              Calendar1.Visible = False
                              fillLineid()
                              fillProcFlowID()
                              fillItemCd()
                              FillGrid()
                    End If
          End Sub
          Protected Sub fillLineid()
                    Dim sqlstr As String = "SELECT LINE_ID, LINE_NM  FROM MAST_LINE ORDER BY LINE_ID"
                    Dim myConnection As New SqlConnection(connstr)
                    Dim cmd As New SqlCommand(sqlstr, myConnection)
                    Dim sda As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable
                    sda.Fill(dt)
                    dt.Rows.Add(" ", "-SELECT-")
                    dt.DefaultView.Sort = "LINE_ID"
                    ddlLineID.DataSource = dt
                    ddlLineID.DataTextField = "LINE_ID"
                    ddlLineID.DataValueField = "LINE_ID"
                    ddlLineID.DataBind()
          End Sub
          Protected Sub fillProcFlowID()
                    Dim sqlstr As String = "select proc_flow_id,proc_flow_nm from mast_proc"
                    Dim myConnection As New SqlConnection(connstr)
                    Dim cmd As New SqlCommand(sqlstr, myConnection)
                    Dim sda As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable
                    sda.Fill(dt)
                    dt.Rows.Add(" ", "-SELECT-")
                    dt.DefaultView.Sort = "proc_flow_id"
                    ddlProcFlowID.DataSource = dt
                    ddlProcFlowID.DataTextField = "proc_flow_id"
                    ddlProcFlowID.DataValueField = "proc_flow_id"
                    ddlProcFlowID.DataBind()
          End Sub

          Protected Sub fillItemCd()
                    Dim sqlstr As String = "select distinct item_cd,item_cd as aa from mast_trace order by item_cd"
                    Dim myConnection As New SqlConnection(connstr)
                    Dim cmd As New SqlCommand(sqlstr, myConnection)
                    Dim sda As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable
                    sda.Fill(dt)
                    dt.Rows.Add(" ", "-SELECT-")
                    dt.DefaultView.Sort = "item_cd"
                    ddlItemCd.DataSource = dt
                    ddlItemCd.DataTextField = "item_cd"
                    ddlItemCd.DataValueField = "item_cd"
                    ddlItemCd.DataBind()
          End Sub
          Protected Sub gvContent_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvContent.RowCommand

          End Sub

          Protected Sub gvContent_OnPageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvContent.PageIndexChanging
                    gvContent.PageIndex = e.NewPageIndex
                    FillGrid()
                    '      gvContent.DataBind()
          End Sub
          Protected Sub gvContent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvContent.SelectedIndexChanged
                    Dim rowindex As Integer = gvContent.SelectedIndex
                    Dim mlotno As String = gvContent.Rows(rowindex).Cells(3).Text
                    Response.Redirect("LotMaint.aspx?LogonID=" & Logonid & "&MLotno=" & mlotno)
          End Sub
          Protected Sub ImageButton3_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton3.Click
                    Response.Redirect("AppMainpage.aspx?LogonID=" & Logonid & "&Op=3")
          End Sub
          Protected Sub ImageButton4_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton4.Click
                    If Calendar1.Visible = True Then
                              Calendar1.Visible = False
                    Else
                              Calendar1.Visible = True
                    End If

          End Sub
          Protected Sub Calendar1_SelectionChanged(sender As Object, e As EventArgs) Handles Calendar1.SelectionChanged
                    txtStartDt.Text = Calendar1.SelectedDate
                    Calendar1.Visible = False
          End Sub

          Protected Sub btnfilter_Click(sender As Object, e As EventArgs) Handles btnfilter.Click
                    Call FillGrid()
          End Sub
          Protected Sub FillGrid()
                    Dim sqlstr As String = "Select A.manu_lot_no,A.prod_order_no,a.plan_manu_line_id,a.proc_flow_id,A.item_cd," +
                                                             "A.plan_manu_line_id,A.proc_flow_id," +
                                                             "Case " +
                                                                    "WHEN CONVERT(INTEGER,B.LTST_OPR_ACT_DIV) = 0 THEN 'NOT STARTED' " +
                                                                    "WHEN CONVERT(INTEGER,B.LTST_OPR_ACT_DIV) = 1 THEN 'FIRST START' " +
                                                                     "WHEN CONVERT(INTEGER,B.LTST_OPR_ACT_DIV) = 2 THEN 'SUSPEND' " +
                                                                      "WHEN CONVERT(INTEGER,B.LTST_OPR_ACT_DIV) = 3 THEN 'PROGRESS' " +
                                                                    "WHEN CONVERT(INTEGER,B.LTST_OPR_ACT_DIV) = 6 THEN 'CLOSED' " +
                                                                    "End As LOTSTATUS, plod_strt_actl_dt_utc " +
                                                                    "From MAST_MFGLOT a " +
                                                                     "Left Join mast_mfglot2 b ON A.manu_lot_no = B.manu_lot_no "
                    Dim sel As String = String.Empty
                    If ddlLineID.SelectedValue <> " " Then
                              If sel = String.Empty Then
                                        sel = "WHERE a.plan_manu_line_id='" & ddlLineID.SelectedValue & "' "
                              Else
                                        sel = sel + " and  a.plan_manu_line_id='" & ddlLineID.SelectedValue & "' "
                              End If
                    End If
                    If ddlProcFlowID.SelectedValue <> " " Then
                              If sel = String.Empty Then
                                        sel = "WHERE a.proc_flow_id='" & ddlProcFlowID.SelectedValue & "' "
                              Else
                                        sel = sel + "  and a.proc_flow_id ='" & ddlProcFlowID.SelectedValue & "' "
                              End If
                    End If
                    If ddlItemCd.SelectedValue <> " " Then
                              If sel = String.Empty Then
                                        sel = "WHERE a.item_cd='" & ddlItemCd.SelectedValue & "' "
                              Else
                                        sel = sel + "  and a.item_cd ='" & ddlItemCd.SelectedValue & "' "
                              End If
                    End If
                    Dim stdt As String = String.Empty
                    If txtStartDt.Text <> String.Empty Then
                              stdt = Format(CDate(txtStartDt.Text), "yyyy-MM-dd")
                              If sel = String.Empty Then
                                        sel = "where substring(plod_strt_actl_dt_utc,1,10) = '" & stdt & "'"
                              Else
                                        sel = sel + " and  substring(plod_strt_actl_dt_utc,1,10) = '" & stdt & "'"
                              End If


                    End If




                    If sel <> String.Empty Then
                              sqlstr = sqlstr + sel
                    End If


                    Dim myConnection As New SqlConnection(connstr)
                    Dim cmd As New SqlCommand(sqlstr, myConnection)
                    Dim sda As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable
                    sda.Fill(dt)
                    gvContent.DataSourceID = Nothing
                    gvContent.DataSource = dt

                    gvContent.DataBind()
          End Sub
End Class