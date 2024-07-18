Imports System.Data.SqlClient
Imports System.Configuration
Public Class LotMaint
    Inherits System.Web.UI.Page
    Public LogonID As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LogonID = Request.QueryString("LogonID")
        If Not IsPostBack Then
            hfLineID.Value = " "
            CalProdDt.Visible = False
        End If
    End Sub

    Protected Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Response.Redirect("AppMainpage.aspx?LogonID=" & LogonID & "&Op=3")
    End Sub

    Protected Sub btnStartLot_Click(sender As Object, e As EventArgs) Handles btnStartLot.Click
        Dim connstr As String = ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
        Dim myconnection As New SqlConnection(connstr)
        Dim cmd As New SqlCommand
        Dim selval As String = Ddlshift.SelectedValue
        Dim sft() As String
        Dim p1 As String = "#"
        sft = selval.Split(p1)
        Dim sftcd As String = sft(0)
        Dim wss As Integer = Val(sft(1))

        '   Class1.ShowMsg("Shift cd : " & sftcd, "OK", "success")
        Dim td As String ' = Format(Now, "yyyy-MM-dd HH:mm:ss")
        td = Format(CDate(txtProdDt.Text), "yyyy-MM-dd")
        Dim sqlstr1 As String = "INSERT INTO TRX_LINE (line_id,proc_flow_id,manu_lot_no,shift_ptrn_id,wrk_shift_seq,strt_dt_utc,end_dt_utc) " +
                                                    "VALUES ('" & hfLineID.Value & "','" & txtProcFlowID.Text & "','" & txtMfgLotNo.Text & "','" & sftcd & "','" & wss & "','" & td & "',' ')"

        'Dim sqlstr1 

        Dim sqlstr2 As String = "UPDATE MAST_MFGLOT set lot_sts_div='0', plod_strt_actl_dt_utc='" & td & "' " +
                                                     "WHERE MANU_LOT_NO='" & txtMfgLotNo.Text & "' "

        Dim sqlstr3 As String = "UPDATE MAST_MFGLOT2 set LTST_OPR_ACT_DIV='00',OPR_STRT_ACTL_DT_UTC='" & td & "'," +
                                                     "shift_ptrn_id='" & sftcd & "',wrk_shift_seq=" & wss & " " +
                                                     "WHERE MANU_LOT_NO='" & txtMfgLotNo.Text & "' "
        myconnection.Open()
        'insert into TRX LINE
        cmd = New SqlCommand(sqlstr1, myconnection)
        cmd.ExecuteNonQuery()
        'update MAST MFGLOT
        cmd = New SqlCommand(sqlstr2, myconnection)
        cmd.ExecuteNonQuery()
        'update MAST MFGLOT2
        cmd = New SqlCommand(sqlstr3, myconnection)
        cmd.ExecuteNonQuery()
        myconnection.Close()





    End Sub

    Protected Function CheckLotStartStatus() As Integer
        Dim connstr As String = System.Configuration.ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
        Dim sqlstr As String
        Dim cmd As SqlCommand
        Dim myconnection As New SqlConnection
        Dim ans As Integer
        myconnection = New SqlConnection(connstr)

        sqlstr = "SELECT COUNT(*) FROM TRX_LINE WHERE MANU_LOT_NO ='" & txtMfgLotNo.Text & "'"
        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)
        Try
            ans = cmd.ExecuteScalar()
        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try
        Return ans
    End Function
    Protected Function CheckLineStatus() As Integer
        Dim connstr As String = System.Configuration.ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
        Dim sqlstr As String
        Dim cmd As SqlCommand
        Dim myconnection As New SqlConnection
        Dim ans As Integer
        myconnection = New SqlConnection(connstr)

        sqlstr = "SELECT COUNT(*) FROM TRX_LINE WHERE PROC_FLOW_ID ='" & txtProcFlowID.Text & "'"
        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)
        Try
            ans = cmd.ExecuteScalar()
        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try
        Return ans

    End Function

    Protected Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Dim connstr As String = System.Configuration.ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
        Dim sqlstr As String
        Dim cmd As SqlCommand
        Dim myconnection As New SqlConnection

        Dim da As New SqlDataAdapter
        Dim dt As New DataTable
        Dim wst As Integer
        myconnection = New SqlConnection(connstr)
        sqlstr = "SELECT proc_flow_id,prod_plan_qty,item_cd,ltst_opr_act_div, plan_manu_line_id FROM MAST_MFGLOT2 WHERE MANU_LOT_NO = '" & txtMfgLotNo.Text & "'"
        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)
        da = New SqlDataAdapter(cmd)
        da.Fill(dt)
        myconnection.Close()
        If dt.Rows.Count() > 0 Then
            txtProcFlowID.Text = dt.Rows(0).Item(0)
            txtProdSchQty.Text = dt.Rows(0).Item(1)
            txtModelNo.Text = dt.Rows(0).Item(2)
            wst = Val(dt.Rows(0).Item(3))
            Select Case wst
                Case 0
                    txtWorkSt.Text = "Not Started"
                    btnStartLot.Enabled = True
                Case 1
                    txtWorkSt.Text = "First Start"
                    btnStartLot.Enabled = False
                Case 2
                    txtWorkSt.Text = "Suspend"
                    btnStartLot.Enabled = True
                Case 3
                    txtWorkSt.Text = "Progress"
                    txtWorkSt.Enabled = False
                Case 6
                    txtWorkSt.Text = "Complete"
                    txtWorkSt.Enabled = False
                Case 7
                    txtWorkSt.Text = "Force Close"
                Case Else
                    txtWorkSt.Text = "Not defined"
            End Select

            hfLineID.Value = dt.Rows(0).Item(4)
        Else
            Class1.ShowMsg("Manufacturing Lot Not found", "Ok", "success")
        End If

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCal.Click
        CalProdDt.Visible = True
    End Sub

    Protected Sub CalProdDt_SelectionChanged(sender As Object, e As EventArgs) Handles CalProdDt.SelectionChanged
        txtProdDt.Text = CalProdDt.SelectedDate
        CalProdDt.Visible = False
    End Sub
End Class