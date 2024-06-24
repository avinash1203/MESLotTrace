Imports System.Data.SqlClient

Public Class Mast_Trace
    Inherits System.Web.UI.Page

    Public connstr As String
    Public Logonid As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Logonid = Class1.GetLoginId(Request)
        DataEntryScr.Visible = False

        Me.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
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
        sqlstr = "SELECT COUNT(*) FROM MAST_TRACE WHERE proc_flow_id = @proc_flow_id AND line_id = @line_id"
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@proc_flow_id", ddlProcId.SelectedValue)
        cmd.Parameters.AddWithValue("@line_id", ddlLineId.SelectedValue)

        myconnection.Open()
        Dim ANS As Integer = cmd.ExecuteScalar
        myconnection.Close()

        If ANS > 0 And hfPopUpType.Value = "New" Then
            Class1.ShowMsg("Duplicate Process ID .Please Check!", "Continue", "warning")
            Exit Sub
        End If

        If ANS > 0 Then
            Call UpdateMastTrace()
        Else
            Call InsertMastTrace()
        End If
        gvContent.DataBind()
    End Sub


    Private Sub InsertMastTrace()
        Dim sqlstr As String
        Dim cmd As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "INSERT INTO MAST_TRACE" +
                        "([cmp_cd],[plnt_cd],[item_cd],[proc_flow_id],[step_cd],[equip_id],[trace_cd],[trace_name]
                           ,[equip_gp],[trace_div],[spec_min] ,[spec_max],[units],[rep_code_flg],[col_nm_1]
                           ,[data_type_1],[col_nm_2] ,[data_type_2],[col_nm_3],[data_type_3] ,[col_nm_4]
                           ,[data_type_4],[col_nm_5],[data_type_5],[col_nm_6] ,[data_type_6],[col_nm_7]
                           ,[data_type_7],[col_nm_8] ,[data_type_8] ,[col_nm_9],[data_type_9] ,[col_nm_10]
                           ,[data_type_10],[inf_flg],[cncl_flg] ,[regr_id],[regr_utc],[notes],[line_id])" +
                          "VALUES(" +
                            "@cmp_cd,@plnt_cd,@item_cd,@proc_flow_id,@step_cd,@equip_id,@trace_cd,@trace_name
                           ,@equip_gp,@trace_div,@spec_min ,@spec_max,@units,@rep_code_flg,@col_nm_1
                           ,@data_type_1,@col_nm_2 ,@data_type_2,@col_nm_3,@data_type_3 ,@col_nm_4
                           ,@data_type_4,@col_nm_5,@data_type_5,@col_nm_6 ,@data_type_6,@col_nm_7
                           ,@data_type_7,@col_nm_8 ,@data_type_8 ,@col_nm_9,@data_type_9 ,@col_nm_10
                           ,@data_type_10,@inf_flg,@cncl_flg ,@regr_id,@regr_utc,@notes,@line_id)"

        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@cmp_cd", ddlCC.SelectedValue)
        cmd.Parameters.AddWithValue("@plnt_cd", ddlPC.SelectedValue)
        cmd.Parameters.AddWithValue("@item_cd", ddlMC.SelectedValue)
        cmd.Parameters.AddWithValue("@proc_flow_id", ddlProcId.SelectedValue)
        cmd.Parameters.AddWithValue("@step_cd", txtSC.Text)
        cmd.Parameters.AddWithValue("@equip_id", txtEC.Text)
        cmd.Parameters.AddWithValue("@trace_cd", txtTC.Text)
        cmd.Parameters.AddWithValue("@trace_name", txtTN.Text)
        cmd.Parameters.AddWithValue("@equip_gp", txtEG.Text)

        cmd.Parameters.AddWithValue("@trace_div", txtTD.Text)
        cmd.Parameters.AddWithValue("@spec_min", Val(txtSMi.Text))
        cmd.Parameters.AddWithValue("@spec_max", Val(txtSMa.Text))
        cmd.Parameters.AddWithValue("@units", txtUnits.Text)

        cmd.Parameters.AddWithValue("@rep_code_flg", Val(txtRGF.Text))
        cmd.Parameters.AddWithValue("@col_nm_1", txtCN1.Text)
        cmd.Parameters.AddWithValue("@data_type_1", Val(txtDT1.Text))
        cmd.Parameters.AddWithValue("@col_nm_2", txtCN2.Text)
        cmd.Parameters.AddWithValue("@data_type_2", Val(txtDT2.Text))
        cmd.Parameters.AddWithValue("@col_nm_3", txtCN3.Text)
        cmd.Parameters.AddWithValue("@data_type_3", Val(txtDT3.Text))
        cmd.Parameters.AddWithValue("@col_nm_4", txtCN4.Text)
        cmd.Parameters.AddWithValue("@data_type_4", Val(txtDT4.Text))
        cmd.Parameters.AddWithValue("@col_nm_5", txtCN5.Text)
        cmd.Parameters.AddWithValue("@data_type_5", Val(txtDT5.Text))
        cmd.Parameters.AddWithValue("@col_nm_6", txtCN6.Text)
        cmd.Parameters.AddWithValue("@data_type_6", Val(txtDT6.Text))
        cmd.Parameters.AddWithValue("@col_nm_7", txtCN7.Text)
        cmd.Parameters.AddWithValue("@data_type_7", Val(txtDT7.Text))
        cmd.Parameters.AddWithValue("@col_nm_8", txtCN8.Text)
        cmd.Parameters.AddWithValue("@data_type_8", Val(txtDT8.Text))
        cmd.Parameters.AddWithValue("@col_nm_9", txtCN9.Text)
        cmd.Parameters.AddWithValue("@data_type_9", Val(txtDT9.Text))
        cmd.Parameters.AddWithValue("@col_nm_10", txtCN10.Text)
        cmd.Parameters.AddWithValue("@inf_flg", Convert.ToInt16(chkInf.Checked))
        cmd.Parameters.AddWithValue("@data_type_10", Val(txtDT10.Text))
        cmd.Parameters.AddWithValue("@CNCL_FLG", 0)
        cmd.Parameters.AddWithValue("@regr_utc", Format(Now, "yyyy-MM-dd HH:mm:ss"))
        cmd.Parameters.AddWithValue("@regr_id", Logonid)
        cmd.Parameters.AddWithValue("@notes", txtRe.Text)
        cmd.Parameters.AddWithValue("@line_id", ddlLineId.SelectedValue)
        Try
            cmd.ExecuteNonQuery()
            Class1.ShowMsg("Saved Successfully", "Ok", "success")
            DataEntryScr.Visible = False
        Catch ex As Exception
            Class1.ShowMsg("Error during Save!", "Continue", "warning")
            Exit Sub
        End Try
    End Sub
    Protected Sub UpdateMastTrace()

        Dim sqlstr As String
        Dim cmd As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "UPDATE MAST_TRACE " +
                        "SET  
                          [cmp_cd]=@cmp_cd,[plnt_cd]=@plnt_cd,[item_cd]=@item_cd,[proc_flow_id]=@proc_flow_id,[step_cd]=@step_cd,[equip_id]=@equip_id,[trace_cd]=@trace_cd,[trace_name]=@trace_name
                           ,[equip_gp]=@equip_gp,[trace_div]=@trace_div,[spec_min]=@spec_min ,[spec_max]=@spec_max,units=@units,[rep_code_flg]=@rep_code_flg,[col_nm_1]=@col_nm_1                           
                           ,[data_type_1]=@data_type_1,[col_nm_2]=@col_nm_2 ,[data_type_2]=@data_type_2,[col_nm_3]=@col_nm_3,[data_type_3]=@data_type_3 ,[col_nm_4]=@col_nm_4
                           ,[data_type_4]=@data_type_4,[col_nm_5]=@col_nm_5,[data_type_5]=@data_type_5,[col_nm_6]=@col_nm_6 ,[data_type_6]=@data_type_6,[col_nm_7]=@col_nm_7
                           ,[data_type_7]=@data_type_7,[col_nm_8]=@col_nm_8 ,[data_type_8]=@data_type_8 ,[col_nm_9]=@col_nm_9,[data_type_9]=@data_type_9 ,[col_nm_10]=@col_nm_10
                           ,[data_type_10]=@data_type_10,[inf_flg]=@inf_flg,[cncl_flg]=@cncl_flg ,[upd_id]=@upd_id,[upd_utc]=@upd_utc,[notes]=@notes,[line_id]=@line_id  Where proc_flow_id = @proc_flow_id AND line_id = @line_id"

        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@cmp_cd", ddlCC.SelectedValue)
        cmd.Parameters.AddWithValue("@plnt_cd", ddlPC.SelectedValue)
        cmd.Parameters.AddWithValue("@item_cd", ddlMC.SelectedValue)
        cmd.Parameters.AddWithValue("@proc_flow_id", ddlProcId.SelectedValue)
        cmd.Parameters.AddWithValue("@step_cd", txtSC.Text)
        cmd.Parameters.AddWithValue("@equip_id", txtEC.Text)
        cmd.Parameters.AddWithValue("@trace_cd", txtTC.Text)
        cmd.Parameters.AddWithValue("@trace_name", txtTN.Text)
        cmd.Parameters.AddWithValue("@equip_gp", txtEG.Text)

        cmd.Parameters.AddWithValue("@trace_div", txtTD.Text)
        cmd.Parameters.AddWithValue("@spec_min", txtSMi.Text)
        cmd.Parameters.AddWithValue("@spec_max", txtSMa.Text)
        cmd.Parameters.AddWithValue("@units", txtUnits.Text)

        cmd.Parameters.AddWithValue("@rep_code_flg", txtRGF.Text)
        cmd.Parameters.AddWithValue("@col_nm_1", txtCN1.Text)
        cmd.Parameters.AddWithValue("@data_type_1", txtDT1.Text)
        cmd.Parameters.AddWithValue("@col_nm_2", txtCN1.Text)
        cmd.Parameters.AddWithValue("@data_type_2", txtDT1.Text)
        cmd.Parameters.AddWithValue("@col_nm_3", txtCN1.Text)
        cmd.Parameters.AddWithValue("@data_type_3", txtDT1.Text)
        cmd.Parameters.AddWithValue("@col_nm_4", txtCN1.Text)
        cmd.Parameters.AddWithValue("@data_type_4", txtDT1.Text)
        cmd.Parameters.AddWithValue("@col_nm_5", txtCN1.Text)
        cmd.Parameters.AddWithValue("@data_type_5", txtDT1.Text)
        cmd.Parameters.AddWithValue("@col_nm_6", txtCN1.Text)
        cmd.Parameters.AddWithValue("@data_type_6", txtDT1.Text)
        cmd.Parameters.AddWithValue("@col_nm_7", txtCN1.Text)
        cmd.Parameters.AddWithValue("@data_type_7", txtDT1.Text)
        cmd.Parameters.AddWithValue("@col_nm_8", txtCN1.Text)
        cmd.Parameters.AddWithValue("@data_type_8", txtDT1.Text)
        cmd.Parameters.AddWithValue("@col_nm_9", txtCN1.Text)
        cmd.Parameters.AddWithValue("@data_type_9", txtDT1.Text)
        cmd.Parameters.AddWithValue("@col_nm_10", txtCN1.Text)
        cmd.Parameters.AddWithValue("@data_type_10", txtDT1.Text)
        cmd.Parameters.AddWithValue("@inf_flg", Convert.ToInt16(chkInf.Checked))
        cmd.Parameters.AddWithValue("@upd_utc", Format(Now, "yyyy-MM-dd HH:mm:ss"))
        cmd.Parameters.AddWithValue("@upd_id", Logonid)
        cmd.Parameters.AddWithValue("line_id", ddlLineId.SelectedValue)
        cmd.Parameters.AddWithValue("@notes", txtRe.Text)
        cmd.Parameters.AddWithValue("@CNCL_FLG", 0)
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
        ddlMC.ClearSelection()
        ddlLineId.ClearSelection()
        ddlProcId.ClearSelection()
        txtSC.Text = String.Empty
        txtEC.Text = String.Empty
        txtTC.Text = String.Empty
        txtTN.Text = String.Empty
        txtEG.Text = String.Empty

        txtTD.Text = String.Empty
        txtSMi.Text = String.Empty
        txtSMa.Text = String.Empty
        txtUnits.Text = String.Empty

        txtRGF.Text = String.Empty
        txtCN1.Text = String.Empty
        txtDT1.Text = String.Empty
        txtCN2.Text = String.Empty
        txtDT2.Text = String.Empty
        txtCN3.Text = String.Empty
        txtDT3.Text = String.Empty
        txtCN4.Text = String.Empty
        txtDT4.Text = String.Empty
        txtDT5.Text = String.Empty
        txtCN5.Text = String.Empty
        txtCN6.Text = String.Empty
        txtDT6.Text = String.Empty
        txtCN7.Text = String.Empty
        txtDT7.Text = String.Empty
        txtCN8.Text = String.Empty
        txtDT8.Text = String.Empty
        txtCN9.Text = String.Empty
        txtDT9.Text = String.Empty
        txtCN10.Text = String.Empty
        txtDT10.Text = String.Empty
        chkInf.Checked = False
        hfPopUpType.Value = ""
        ddlProcId.Enabled = True
        ddlLineId.Enabled = True
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
            ddlLineId.Enabled = False
            Dim resultArray() As String = e.CommandArgument.Split("_")
            GetSelected(resultArray(0), resultArray(1))

        End If
    End Sub

    Protected Sub GetSelected(proc_flow_id As String, line_id As String)
        connstr = System.Configuration.ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
        Dim sqlstr As String
        Dim myConnection As SqlConnection

        sqlstr = "SELECT [cmp_cd],[plnt_cd],[item_cd],[proc_flow_id],[step_cd],[equip_id],[trace_cd],[trace_name],[equip_gp],[trace_div]
                  ,[spec_min],[spec_max],[units],[rep_code_flg],[col_nm_1],[data_type_1],[col_nm_2],[data_type_2],[col_nm_3]
                  ,[data_type_3],[col_nm_4],[data_type_4],[col_nm_5],[data_type_5],[col_nm_6],[data_type_6],[col_nm_7],[data_type_7],[col_nm_8]
                  ,[data_type_8],[col_nm_9],[data_type_9],[col_nm_10]
                  ,[data_type_10],[inf_flg],[notes],[line_id]
                   FROM [dbo].[MAST_TRACE] " +
                   "WHERE proc_flow_id = @proc_flow_id AND line_id =@line_id"

        Dim cmd As SqlCommand

        myConnection = New SqlConnection(connstr)
        myConnection.Open()
        cmd = New SqlCommand(sqlstr, myConnection)
        cmd.Parameters.AddWithValue("@proc_flow_id", proc_flow_id)
        cmd.Parameters.AddWithValue("@line_id", line_id)

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

        Dim firstLprocId = DirectCast(DataEntryScr.FindControl("ddlMC"), DropDownList).Items(0)
        DirectCast(DataEntryScr.FindControl("ddlMC"), DropDownList).Items.Clear()
        DirectCast(DataEntryScr.FindControl("ddlMC"), DropDownList).Items.Add(firstLprocId)
        DirectCast(DataEntryScr.FindControl("ddlMC"), DropDownList).DataBind()


        Dim firstLineId = DirectCast(DataEntryScr.FindControl("ddlProcId"), DropDownList).Items(0)
        DirectCast(DataEntryScr.FindControl("ddlProcId"), DropDownList).Items.Clear()
        DirectCast(DataEntryScr.FindControl("ddlProcId"), DropDownList).Items.Add(firstLineId)
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
        '    DirectCast(DataEntryScr.FindControl("ddlMC"), DropDownList).SelectedIndex = 0
        'Else
        '    DirectCast(DataEntryScr.FindControl("ddlMC"), DropDownList).SelectedValue = value.Rows(0).Item(2)
        'End If
        Class1.SetDropDownVale(DataEntryScr, "ddlMC", value.Rows(0).Item(2))

        'If value.Rows(0).Item(3) Is String.Empty Then
        '    DirectCast(DataEntryScr.FindControl("ddlProcId"), DropDownList).SelectedIndex = 0
        'Else
        '    DirectCast(DataEntryScr.FindControl("ddlProcId"), DropDownList).SelectedValue = value.Rows(0).Item(3)
        'End If
        Class1.SetDropDownVale(DataEntryScr, "ddlProcId", value.Rows(0).Item(3))

        DirectCast(DataEntryScr.FindControl("txtSC"), TextBox).Text = value.Rows(0).Item(4)
        DirectCast(DataEntryScr.FindControl("txtEC"), TextBox).Text = value.Rows(0).Item(5)
        DirectCast(DataEntryScr.FindControl("txtTC"), TextBox).Text = value.Rows(0).Item(6)
        DirectCast(DataEntryScr.FindControl("txtTN"), TextBox).Text = value.Rows(0).Item(7)
        DirectCast(DataEntryScr.FindControl("txtEG"), TextBox).Text = value.Rows(0).Item(8)
        DirectCast(DataEntryScr.FindControl("txtTD"), TextBox).Text = value.Rows(0).Item(9)
        DirectCast(DataEntryScr.FindControl("txtSMi"), TextBox).Text = value.Rows(0).Item(10)
        DirectCast(DataEntryScr.FindControl("txtSMa"), TextBox).Text = value.Rows(0).Item(11)
        DirectCast(DataEntryScr.FindControl("txtUnits"), TextBox).Text = value.Rows(0).Item(12)
        DirectCast(DataEntryScr.FindControl("txtRGF"), TextBox).Text = value.Rows(0).Item(13)
        DirectCast(DataEntryScr.FindControl("txtCN1"), TextBox).Text = value.Rows(0).Item(14)
        DirectCast(DataEntryScr.FindControl("txtDT1"), TextBox).Text = value.Rows(0).Item(15)


        DirectCast(DataEntryScr.FindControl("txtCN2"), TextBox).Text = value.Rows(0).Item(16)
        DirectCast(DataEntryScr.FindControl("txtDT2"), TextBox).Text = value.Rows(0).Item(17)

        DirectCast(DataEntryScr.FindControl("txtCN3"), TextBox).Text = value.Rows(0).Item(18)
        DirectCast(DataEntryScr.FindControl("txtDT3"), TextBox).Text = value.Rows(0).Item(19)

        DirectCast(DataEntryScr.FindControl("txtCN4"), TextBox).Text = value.Rows(0).Item(20)
        DirectCast(DataEntryScr.FindControl("txtDT4"), TextBox).Text = value.Rows(0).Item(21)

        DirectCast(DataEntryScr.FindControl("txtCN5"), TextBox).Text = value.Rows(0).Item(22)
        DirectCast(DataEntryScr.FindControl("txtDT5"), TextBox).Text = value.Rows(0).Item(23)

        DirectCast(DataEntryScr.FindControl("txtCN6"), TextBox).Text = value.Rows(0).Item(24)
        DirectCast(DataEntryScr.FindControl("txtDT6"), TextBox).Text = value.Rows(0).Item(25)

        DirectCast(DataEntryScr.FindControl("txtCN7"), TextBox).Text = value.Rows(0).Item(26)
        DirectCast(DataEntryScr.FindControl("txtDT7"), TextBox).Text = value.Rows(0).Item(27)

        DirectCast(DataEntryScr.FindControl("txtCN8"), TextBox).Text = value.Rows(0).Item(28)
        DirectCast(DataEntryScr.FindControl("txtDT8"), TextBox).Text = value.Rows(0).Item(29)

        DirectCast(DataEntryScr.FindControl("txtCN9"), TextBox).Text = value.Rows(0).Item(30)
        DirectCast(DataEntryScr.FindControl("txtDT9"), TextBox).Text = value.Rows(0).Item(31)

        DirectCast(DataEntryScr.FindControl("txtCN10"), TextBox).Text = value.Rows(0).Item(32)
        DirectCast(DataEntryScr.FindControl("txtDT10"), TextBox).Text = value.Rows(0).Item(33)


        DirectCast(DataEntryScr.FindControl("chkInf"), CheckBox).Checked = Convert.ToBoolean(value.Rows(0).Item(34))
        DirectCast(DataEntryScr.FindControl("txtRe"), TextBox).Text = value.Rows(0).Item(35)
        DirectCast(DataEntryScr.FindControl("txtRe"), TextBox).Text = value.Rows(0).Item(35)


        Dim lineId = DirectCast(DataEntryScr.FindControl("ddlLineId"), DropDownList).Items(0)
        DirectCast(DataEntryScr.FindControl("ddlLineId"), DropDownList).Items.Clear()
        DirectCast(DataEntryScr.FindControl("ddlLineId"), DropDownList).Items.Add(lineId)
        DirectCast(DataEntryScr.FindControl("ddlLineId"), DropDownList).DataBind()

        'If value.Rows(0).Item(36) Is String.Empty Or value.Rows(0).Item(36) Is DBNull.Value Then
        '    DirectCast(DataEntryScr.FindControl("ddlLineId"), DropDownList).SelectedIndex = 0
        'Else
        '    DirectCast(DataEntryScr.FindControl("ddlLineId"), DropDownList).SelectedValue = value.Rows(0).Item(36)
        'End If
        Class1.SetDropDownVale(DataEntryScr, "ddlLineId", value.Rows(0).Item(36))



    End Sub
    Protected Sub SoftDeleteReason()
        Dim sqlstr As String
        Dim cmd As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "UPDATE MAST_TRACE" +
                        " SET CNCL_FLG = 1  WHERE proc_flow_id = @proc_flow_id AND line_id =@line_id"
        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@proc_flow_id", ddlProcId.SelectedValue)
        cmd.Parameters.AddWithValue("@line_id", ddlLineId.SelectedValue)

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
End Class