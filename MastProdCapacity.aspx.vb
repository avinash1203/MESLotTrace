Imports System.Data.SqlClient

Public Class MastProdCapacity
    Inherits System.Web.UI.Page

    Public connstr As String
    Public Logonid As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Logonid = Request.QueryString("LogonID")
        connstr = System.Configuration.ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString

        If Not Page.IsPostBack Then
            DataEntryScr.Visible = False
            SearchScr.Visible = False

            Me.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
        End If



    End Sub


    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Call SaveData()
    End Sub
    Protected Sub SaveData()
        Dim sqlstr As String
        Dim cmd As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)
        sqlstr = "SELECT COUNT(*) FROM MAST_PROD_CAPACITY WHERE proc_flow_id = @proc_flow_id AND CNCL_FLG = 0"
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@proc_flow_id", ddlPC.SelectedValue)
        myconnection.Open()
        Dim ANS As Integer = cmd.ExecuteScalar
        myconnection.Close()

        If ANS > 0 And hfPopUpType.Value = "New" Then
            Class1.ShowMsg("Duplicate Procduction Flow Id .Please Check!", "Continue", "warning")
            Exit Sub
        End If

        If ANS > 0 Then
            Call UpdateProdCap()
        Else
            Call InsertProdCap()
        End If
        gvContent.DataBind()
    End Sub


    Private Sub InsertProdCap()
        Dim sqlstr As String
        Dim cmd As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "INSERT INTO [dbo].[MAST_PROD_CAPACITY] 
                   ([cmp_cd]
                   ,[plnt_cd]                                        
                   ,[item_cd]
                   ,[proc_flow_id]
                   ,[line_id]
                   ,[shift_nm]
                   ,[production_capacity]
                   ,[proc_seq]
                   ,[priority_order]
                   ,[line_sym]
                   ,[proc_sym]
                   ,[cncl_flg]
                   ,[regr_id]
                   ,[regr_utc]
                   ,[notes])" +
                          " VALUES(" +
                            "@cmp_cd,@plnt_cd,@item_cd,@proc_flow_id,@line_id,@shift_nm,@production_capacity,@proc_seq," +
                            "@priority_order,@line_sym,@proc_sym,@cncl_flg,@regr_id,@regr_utc,@notes)"

        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@cmp_cd", ddlCC.SelectedValue)
        cmd.Parameters.AddWithValue("@plnt_cd", ddlPC.SelectedValue)
        cmd.Parameters.AddWithValue("@item_cd", ddlIC.SelectedValue)
        cmd.Parameters.AddWithValue("@proc_flow_id", ddlPFID.SelectedValue)
        cmd.Parameters.AddWithValue("@line_id", ddlLineId.SelectedValue)
        cmd.Parameters.AddWithValue("@shift_nm", txtNS.Text)
        cmd.Parameters.AddWithValue("@production_capacity", txtProdCap.Text)
        cmd.Parameters.AddWithValue("@proc_seq", txtPO.Text)
        cmd.Parameters.AddWithValue("@priority_order", txtPO.Text)
        cmd.Parameters.AddWithValue("@line_sym", ddlLS.SelectedValue)
        cmd.Parameters.AddWithValue("@proc_sym", txtPS.Text)
        cmd.Parameters.AddWithValue("@CNCL_FLG", 0)
        cmd.Parameters.AddWithValue("@regr_utc", Format(Now, "yyyy-MM-dd HH:mm:ss"))
        cmd.Parameters.AddWithValue("@regr_id", Logonid)
        cmd.Parameters.AddWithValue("@notes", txtRe.Text)
        Try
            cmd.ExecuteNonQuery()
            Class1.ShowMsg("Saved Successfully", "Ok", "success")

        Catch ex As Exception
            Class1.ShowMsg("Error during Save!", "Continue", "warning")
        End Try
        DataEntryScr.Visible = False
    End Sub
    Protected Sub UpdateProdCap()

        Dim sqlstr As String
        Dim cmd As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "UPDATE MAST_PROD_CAPACITY" +
                        "SET 
                        [cmp_cd]=@cmp_cd
                       ,[plnt_cd]=@plnt_cd                                        
                       ,[item_cd]=@item_cd
                       ,[proc_flow_id]=@proc_flow_id
                       ,[line_id]=@line_id
                       ,[shift_nm]=@shift_nm
                       ,[production_capacity]=@production_capacity
                       ,[proc_seq]=@proc_seq
                       ,[priority_order]=@priority_order
                       ,[line_sym]=@line_sym
                       ,[proc_sym]=@proc_sym
                       ,[cncl_flg]=@cncl_flg
                       ,[upd_id]=@upd_id
                       ,[upd_utc]=@upd_utc
                       ,[notes]=@cmp_cd Where proc_flow_id = @proc_flow_id"

        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@cmp_cd", ddlCC.SelectedValue)
        cmd.Parameters.AddWithValue("@plnt_cd", ddlPC.SelectedValue)
        cmd.Parameters.AddWithValue("@item_cd", ddlIC.SelectedValue)
        cmd.Parameters.AddWithValue("@proc_flow_id", ddlPFID.SelectedValue)
        cmd.Parameters.AddWithValue("@line_id", ddlLineId.SelectedValue)
        cmd.Parameters.AddWithValue("@shift_nm", txtNS.Text)
        cmd.Parameters.AddWithValue("@production_capacity", txtProdCap.Text)
        cmd.Parameters.AddWithValue("@proc_seq", txtPO.Text)
        cmd.Parameters.AddWithValue("@priority_order", txtPO.Text)
        cmd.Parameters.AddWithValue("@line_sym", ddlLS.SelectedValue)
        cmd.Parameters.AddWithValue("@proc_sym", txtPS.Text)
        cmd.Parameters.AddWithValue("@CNCL_FLG", 0)
        cmd.Parameters.AddWithValue("@upd_utc", Format(Now, "yyyy-MM-dd HH:mm:ss"))
        cmd.Parameters.AddWithValue("@updr_id", Logonid)
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
        txtNS.Text = String.Empty
        txtProdCap.Text = String.Empty
        txtPO.Text = String.Empty
        txtPS.Text = String.Empty

        txtRe.Text = String.Empty
        ddlCC.ClearSelection()
        ddlPC.ClearSelection()
        ddlLineId.ClearSelection()
        ddlIC.ClearSelection()
        ddlLS.ClearSelection()
        ddlPFID.ClearSelection()
        hfPopUpType.Value = ""
        ddlPFID.Enabled = True
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
            ddlPFID.Enabled = False
            GetSelected(e.CommandArgument)

        End If
    End Sub

    Protected Sub GetSelected(proc_flow_id As String)
        connstr = System.Configuration.ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
        Dim sqlstr As String
        Dim myConnection As SqlConnection

        sqlstr = "SELECT [cmp_cd]
                       ,[plnt_cd]
                       ,[item_cd]
                       ,[line_id]
                       ,[proc_flow_id]
                       ,[shift_nm]
                       ,[production_capacity]
                       ,[proc_seq]
                       ,[priority_order]
                       ,[line_sym]
                       ,[proc_sym]
                       ,[notes]
                        from [MAST_PROD_CAPACITY] " +
             "WHERE proc_flow_id = @proc_flow_id AND CNCL_FLG = 0"

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
            DirectCast(DataEntryScr.FindControl("ddlIC"), DropDownList).SelectedIndex = 0
        Else
            GetItemCode(value.Rows(0).Item(2))
            DirectCast(DataEntryScr.FindControl("ddlIC"), DropDownList).SelectedValue = value.Rows(0).Item(2)
        End If

        If value.Rows(0).Item(3) Is String.Empty Then
            DirectCast(DataEntryScr.FindControl("ddlLineId"), DropDownList).SelectedIndex = 0
        Else
            DirectCast(DataEntryScr.FindControl("ddlLineId"), DropDownList).SelectedValue = value.Rows(0).Item(3)
        End If



        Dim ddlPFIDId = DirectCast(DataEntryScr.FindControl("ddlPFID"), DropDownList).Items(0)
        DirectCast(DataEntryScr.FindControl("ddlPFID"), DropDownList).Items.Clear()
        DirectCast(DataEntryScr.FindControl("ddlPFID"), DropDownList).Items.Add(ddlPFIDId)
        DirectCast(DataEntryScr.FindControl("ddlPFID"), DropDownList).DataBind()



        If value.Rows(0).Item(4) Is String.Empty Then
            DirectCast(DataEntryScr.FindControl("ddlPFID"), DropDownList).SelectedIndex = 0
        Else
            DirectCast(DataEntryScr.FindControl("ddlPFID"), DropDownList).SelectedValue = value.Rows(0).Item(4)
        End If


        DirectCast(DataEntryScr.FindControl("txtNS"), TextBox).Text = value.Rows(0).Item(5)
        DirectCast(DataEntryScr.FindControl("txtProdCap"), TextBox).Text = value.Rows(0).Item(6)
        DirectCast(DataEntryScr.FindControl("txtPO"), TextBox).Text = value.Rows(0).Item(7)

        If value.Rows(0).Item(8) Is String.Empty Then
            DirectCast(DataEntryScr.FindControl("ddlLS"), DropDownList).SelectedIndex = 0
        Else
            DirectCast(DataEntryScr.FindControl("ddlLS"), DropDownList).SelectedValue = value.Rows(0).Item(8)
        End If


        DirectCast(DataEntryScr.FindControl("txtPS"), TextBox).Text = value.Rows(0).Item(9)

        DirectCast(DataEntryScr.FindControl("txtRe"), TextBox).Text = value.Rows(0).Item(10)


    End Sub
    Protected Sub SoftDeleteReason()
        Dim sqlstr As String
        Dim cmd As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "UPDATE MAST_PROD_CAPACITY" +
                        " SET CNCL_FLG = 1  WHERE proc_flow_id = @proc_flow_id"
        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@proc_flow_id", ddlPFID.SelectedValue)
        Try
            cmd.ExecuteNonQuery()
            Class1.ShowMsg("Deleted Successfully", "Ok", "success")
            DataEntryScr.Visible = False
        Catch ex As Exception
            Class1.ShowMsg("Error during Delete!", "Continue", "warning")
            Exit Sub
        End Try
    End Sub

    Protected Sub imgSearchIC_Click(sender As Object, e As ImageClickEventArgs) Handles imgSearchIC.Click
        SearchScr.Visible = True
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        GetItemCode(txtSearchIC.Text)
        SearchScr.Visible = False
    End Sub

    Protected Sub GetItemCode(item As String)
        connstr = System.Configuration.ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
        Dim sqlstr As String
        Dim myConnection As SqlConnection

        sqlstr = "SELECT item_cd, item_nm FROM [MAST_ITEM] WHERE item_cd Like '" + item.Replace("*", "%") + "' And CNCL_FLG = 0 ORDER BY [item_nm]"

        Dim cmd As SqlCommand

        myConnection = New SqlConnection(connstr)
        myConnection.Open()
        cmd = New SqlCommand(sqlstr, myConnection)
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)

        If dt.Rows.Count > 0 Then
            ddlIC.DataSource = Nothing
            ddlIC.DataSource = dt
            ddlIC.DataBind()
        Else
            Class1.ShowMsg("No Matching Item Codes Found", "Continue", "warning")

        End If
        myConnection.Close()

    End Sub

    Protected Sub btnSearchCancel_Click(sender As Object, e As EventArgs) Handles btnSearchCancel.Click
        SearchScr.Visible = False
        txtSearchIC.Text = String.Empty
    End Sub

    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        DataEntryScr_Clear()
        DataEntryScr.Visible = False
    End Sub

    Protected Sub ImageButton3_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton3.Click
        Response.Redirect("appMainpage.aspx?LoginID=" & Logonid & "&Op=2")
    End Sub
End Class