Imports System.Data.SqlClient

Public Class Mast_Bom
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
        sqlstr = "SELECT COUNT(*) FROM MAST_BOM WHERE proc_flow_id = @proc_flow_id"
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@proc_flow_id", ddlProcId.SelectedValue)

        myconnection.Open()
        Dim ANS As Integer = cmd.ExecuteScalar
        myconnection.Close()

        If ANS > 0 And hfPopUpType.Value = "New" Then
            Class1.ShowMsg("Duplicate Process ID .Please Check!", "Continue", "warning")
            Exit Sub
        End If

        If ANS > 0 Then
            Call UpdateMastBom()
        Else
            Call InsertMastBom()
        End If
        gvContent.DataBind()
    End Sub


    Private Sub InsertMastBom()
        Dim sqlstr As String
        Dim cmd As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "INSERT INTO MAST_BOM" +
                        "([cmp_cd]
                           ,[plnt_cd]
                           ,[line_id]
                           ,[proc_flow_id]
                           ,[hhr_rnk_item]
                           ,[step_cd]
                           ,[equip_cd]
                           ,[item_cd]
                           ,[usage_qty]
                           ,[effective_Fr]
                           ,[effective_to]
                           ,[cncl_flg]
                           ,[regr_id]
                           ,[regr_utc]
                           ,[notes])" +
                          "VALUES(" +
                            "@cmp_cd,@plnt_cd,@line_id,@proc_flow_id,@hhr_rnk_item,@step_cd,@equip_cd," +
                            "@item_cd,@usage_qty,@effective_Fr,@effective_to,@CNCL_FLG,@regr_id,@regr_utc,@notes)"

        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@cmp_cd", ddlCC.SelectedValue)
        cmd.Parameters.AddWithValue("@plnt_cd", ddlPC.SelectedValue)
        cmd.Parameters.AddWithValue("@line_id", ddlLineId.SelectedValue)
        cmd.Parameters.AddWithValue("@proc_flow_id", ddlProcId.SelectedValue)
        cmd.Parameters.AddWithValue("@hhr_rnk_item", txtMC.Text)
        cmd.Parameters.AddWithValue("@step_cd", txtSC.Text)
        cmd.Parameters.AddWithValue("@equip_cd", txtEID.Text)
        cmd.Parameters.AddWithValue("@item_cd", ddlIC.SelectedValue)
        cmd.Parameters.AddWithValue("@usage_qty", txtUQ.Text)
        cmd.Parameters.AddWithValue("@effective_Fr", txtUSD.Text)
        cmd.Parameters.AddWithValue("@effective_to", txtUED.Text)
        cmd.Parameters.AddWithValue("@CNCL_FLG", 0)
        cmd.Parameters.AddWithValue("@regr_utc", Format(Now, "yyyy-MM-dd HH:mm:ss"))
        cmd.Parameters.AddWithValue("@regr_id", Logonid)
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
    Protected Sub UpdateMastBom()

        Dim sqlstr As String
        Dim cmd As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "UPDATE MAST_BOM " +
                        "SET  
                            [cmp_cd]=@cmp_cd
                           ,[plnt_cd]=@plnt_cd
                           ,[line_id]=@line_id
                           ,[proc_flow_id]=@proc_flow_id
                           ,[hhr_rnk_item]=@hhr_rnk_item
                           ,[step_cd]=@step_cd
                           ,[equip_cd]=@equip_cd
                           ,[item_cd]=@item_cd
                           ,[usage_qty]=@usage_qty
                           ,[effective_Fr]=@effective_Fr
                           ,[effective_to]=@effective_to
                           ,[cncl_flg]=@cncl_flg
                           ,[upd_id]=@upd_id
                           ,[upd_utc]=@upd_utc
                           ,[notes]=@notes
                            Where proc_flow_id = @proc_flow_id  "

        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)

        cmd.Parameters.AddWithValue("@cmp_cd", ddlCC.SelectedValue)
        cmd.Parameters.AddWithValue("@plnt_cd", ddlPC.SelectedValue)
        cmd.Parameters.AddWithValue("@line_id", ddlLineId.SelectedValue)
        cmd.Parameters.AddWithValue("@proc_flow_id", ddlProcId.SelectedValue)
        cmd.Parameters.AddWithValue("@hhr_rnk_item", txtMC.Text)
        cmd.Parameters.AddWithValue("@step_cd", txtSC.Text)
        cmd.Parameters.AddWithValue("@equip_cd", txtEID.Text)
        cmd.Parameters.AddWithValue("@item_cd", ddlIC.SelectedValue)
        cmd.Parameters.AddWithValue("@usage_qty", txtUQ.Text)
        cmd.Parameters.AddWithValue("@effective_Fr", txtUSD.Text)
        cmd.Parameters.AddWithValue("@effective_to", txtUED.Text)
        cmd.Parameters.AddWithValue("@CNCL_FLG", 0)
        cmd.Parameters.AddWithValue("@upd_utc", Format(Now, "yyyy-MM-dd HH:mm:ss"))
        cmd.Parameters.AddWithValue("@upd_id", Logonid)
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
        ddlProcId.ClearSelection()
        txtMC.Text = String.Empty
        txtSC.Text = String.Empty
        txtEID.Text = String.Empty
        ddlIC.ClearSelection()
        txtUQ.Text = String.Empty
        txtUSD.Text = String.Empty
        txtUED.Text = String.Empty
        txtRe.Text = String.Empty
        ddlProcId.Enabled = True
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
            ddlProcId.Enabled = False
            Dim resultArray() As String = e.CommandArgument.Split("_")
            GetSelected(resultArray(0))

        End If
    End Sub

    Protected Sub GetSelected(proc_flow_id As String)
        connstr = System.Configuration.ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
        Dim sqlstr As String
        Dim myConnection As SqlConnection

        sqlstr = "SELECT [cmp_cd]
                           ,[plnt_cd]
                           ,[line_id]
                           ,[proc_flow_id]
                           ,[hhr_rnk_item]
                           ,[step_cd]
                           ,[equip_cd]
                           ,[item_cd]
                           ,[usage_qty]
                           ,[effective_Fr]
                           ,[effective_to]
                           ,[cncl_flg]
                           ,[regr_id]
                           ,[regr_utc]
                           ,[notes] from MAST_BOM " +
             "WHERE proc_flow_id = @proc_flow_id"

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

        Dim firstLprocId = DirectCast(DataEntryScr.FindControl("ddlProcId"), DropDownList).Items(0)
        DirectCast(DataEntryScr.FindControl("ddlProcId"), DropDownList).Items.Clear()
        DirectCast(DataEntryScr.FindControl("ddlProcId"), DropDownList).Items.Add(firstLprocId)
        DirectCast(DataEntryScr.FindControl("ddlProcId"), DropDownList).DataBind()


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
        'If value.Rows(0).Item(2) Is String.Empty Then
        '    DirectCast(DataEntryScr.FindControl("ddlLineId"), DropDownList).SelectedIndex = 0
        'Else
        '    DirectCast(DataEntryScr.FindControl("ddlLineId"), DropDownList).SelectedValue = value.Rows(0).Item(2)
        'End If
        Class1.SetDropDownVale(DataEntryScr, "ddlLineId", value.Rows(0).Item(2))

        'If value.Rows(0).Item(3) Is String.Empty Then
        '    DirectCast(DataEntryScr.FindControl("ddlProcId"), DropDownList).SelectedIndex = 0
        'Else
        '    DirectCast(DataEntryScr.FindControl("ddlProcId"), DropDownList).SelectedValue = value.Rows(0).Item(3)
        'End If
        Class1.SetDropDownVale(DataEntryScr, "ddlLineId", value.Rows(0).Item(3))

        DirectCast(DataEntryScr.FindControl("txtMC"), TextBox).Text = value.Rows(0).Item(4)
        DirectCast(DataEntryScr.FindControl("txtSC"), TextBox).Text = value.Rows(0).Item(5)
        DirectCast(DataEntryScr.FindControl("txtEID"), TextBox).Text = value.Rows(0).Item(6)


        Dim icFirstItem = DirectCast(DataEntryScr.FindControl("ddlIC"), DropDownList).Items(0)
        DirectCast(DataEntryScr.FindControl("ddlIC"), DropDownList).Items.Clear()
        DirectCast(DataEntryScr.FindControl("ddlIC"), DropDownList).Items.Add(icFirstItem)
        DirectCast(DataEntryScr.FindControl("ddlIC"), DropDownList).DataBind()

        'If value.Rows(0).Item(4) Is String.Empty Then
        '    DirectCast(DataEntryScr.FindControl("ddlIC"), DropDownList).SelectedIndex = 0
        'Else
        '    DirectCast(DataEntryScr.FindControl("ddlIC"), DropDownList).SelectedValue = value.Rows(0).Item(7)
        'End If

        Class1.SetDropDownVale(DataEntryScr, "ddlIC", value.Rows(0).Item(7))

        DirectCast(DataEntryScr.FindControl("txtUQ"), TextBox).Text = value.Rows(0).Item(8)
        DirectCast(DataEntryScr.FindControl("txtUSD"), TextBox).Text = DateTime.Parse(value.Rows(0).Item(9)).ToString("yyyy-MM-dd")
        DirectCast(DataEntryScr.FindControl("txtUED"), TextBox).Text = DateTime.Parse(value.Rows(0).Item(10)).ToString("yyyy-MM-dd")
        DirectCast(DataEntryScr.FindControl("txtRe"), TextBox).Text = value.Rows(0).Item(14)



    End Sub
    Protected Sub SoftDeleteReason()
        Dim sqlstr As String
        Dim cmd As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "UPDATE MAST_BOM" +
                        " SET CNCL_FLG = 1  WHERE proc_flow_id = @proc_flow_id"
        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@proc_flow_id", ddlProcId.SelectedValue)

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
        Response.Redirect("appMainpage.aspx?LoginID=" & Logonid & "&Op=2")
    End Sub

    Protected Sub gvContent_OnPageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvContent.PageIndex = e.NewPageIndex
        gvContent.DataBind()
    End Sub
End Class