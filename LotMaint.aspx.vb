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
                    'Call FillddlProcID()
                    'If Not IsPostBack Then
                    '          Call FillgvMlot("")
                    'End If
                    'SuspendLotList.Visible = False
          End Sub

    Protected Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Response.Redirect("AppMainpage.aspx?LogonID=" & LogonID & "&Op=3")
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

          Protected Sub btnGenLot_Click(sender As Object, e As EventArgs) Handles btnGenLot.Click
                    Class1.ShowMsg("In progress", "Continue", "warning")
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
                    Dim wtime As String = sft(2)
                    Dim td As String
                    td = Format(CDate(txtProdDt.Text), "yyyy-MM-dd") & " " & wtime
                    Dim sqlstr1 As String = "INSERT INTO TRX_LINE (line_id,proc_flow_id,manu_lot_no,shift_ptrn_id,wrk_shift_seq,strt_dt_utc,end_dt_utc) " +
                                                    "VALUES ('" & hfLineID.Value & "','" & txtProcFlowID.Text & "','" & txtMfgLotNo.Text & "','" & sftcd & "','" & wss & "','" & td & "',' ')"

                    Dim sqlstr2 As String = "UPDATE MAST_MFGLOT set lot_sts_div='1', plod_strt_actl_dt_utc='" & td & "' " +
                                                     "WHERE MANU_LOT_NO='" & txtMfgLotNo.Text & "' "

                    Dim sqlstr3 As String = "UPDATE MAST_MFGLOT2 set LTST_OPR_ACT_DIV='1',OPR_STRT_ACTL_DT_UTC='" & td & "'," +
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
          Protected Sub btnSuspendLot_Click(sender As Object, e As EventArgs) Handles btnSuspendLot.Click
                    ' \CHECK the current status of the Lot
                    ' 
                    If GetLotStatus() = "00" Then
                              Class1.ShowMsg("Lot has not been started", "Ok", "warning")
                    Else

                              Dim connstr As String = ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
                              Dim myconnection As New SqlConnection(connstr)
                              Dim cmd1, cmd3 As New SqlCommand
                              Dim sqlstr1 As String = "UPDATE TRX_LINE SET manu_lot_no='',shift_ptrn_id='',wrk_shift_seq='',strt_dt_utc='',end_dt_utc='' " +
                                                                            "WHERE  line_id='" & hfLineID.Value & "' and proc_flow_id='" & txtProcFlowID.Text & "' and manu_lot_no='" & txtMfgLotNo.Text & "' "
                              Dim sqlstr3 As String = "UPDATE MAST_MFGLOT2 set LTST_OPR_ACT_DIV='2' WHERE MANU_LOT_NO='" & txtMfgLotNo.Text & "' "
                              myconnection.Open()
                              cmd1 = New SqlCommand(sqlstr1, myconnection)
                              cmd3 = New SqlCommand(sqlstr3, myconnection)
                              Try
                                        cmd1.ExecuteNonQuery()
                                        cmd3.ExecuteNonQuery()
                                        Class1.ShowMsg("Lot Suspended", "Ok", "success")
                              Catch ex As Exception
                                        Class1.ShowMsg("Lot Suspend Error:" & Mid(ex.Message, 1, 50), "Continue", "warning")
                              Finally
                                        myconnection.Close()
                              End Try
                    End If


          End Sub
          Protected Function GetLotStatus() As String
                    Dim sqlstr As String = "Select lot_sts_div from MAST_MFGLOT WHERE manu_lot_no='" & txtMfgLotNo.Text & "' "
                    Dim connstr As String = ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
                    Dim myConnection As New SqlConnection(connstr)
                    Dim cmd As New SqlCommand(sqlstr, myConnection)
                    Dim ans As String
                    myConnection.Open()
                    ans = cmd.ExecuteScalar
                    myConnection.Close()
                    Return ans
          End Function

          Protected Sub btnCloseLot_Click(sender As Object, e As EventArgs) Handles btnCloseLot.Click
                    Dim connstr As String = ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
                    Dim myconnection As New SqlConnection(connstr)
                    Dim cmd1, cmd3 As New SqlCommand
                    Dim td As String
                    td = Format(Now, "yyyy-MM-dd HH:mm:ss")

                    Dim sqlstr1 As String = "UPDATE TRX_LINE SET manu_lot_no='',shift_ptrn_id='',wrk_shift_seq='',strt_dt_utc='',end_dt_utc='' " +
                                                                  "WHERE  line_id='" & hfLineID.Value & "' and proc_flow_id='" & txtProcFlowID.Text & "' and manu_lot_no='" & txtMfgLotNo.Text & "' "
                    Dim sqlstr2 As String = "UPDATE MAST_MFGLOT set lot_sts_div='4', plod_strt_actl_dt_utc='" & td & "' " +
                                                                  "WHERE MANU_LOT_NO='" & txtMfgLotNo.Text & "' "
                    Dim sqlstr3 As String = "UPDATE MAST_MFGLOT2 set LTST_OPR_ACT_DIV='4' WHERE MANU_LOT_NO='" & txtMfgLotNo.Text & "' "
                    myconnection.Open()
                    cmd1 = New SqlCommand(sqlstr1, myconnection)
                    cmd3 = New SqlCommand(sqlstr3, myconnection)
                    Try
                              cmd1.ExecuteNonQuery()
                              cmd3.ExecuteNonQuery()
                              Class1.ShowMsg("Lot Suspended", "Ok", "success")
                    Catch ex As Exception
                              Class1.ShowMsg("Lot Suspend Error:" & Mid(ex.Message, 1, 50), "Continue", "warning")
                    Finally
                              myconnection.Close()
                    End Try
          End Sub
          Protected Function TxRows() As Boolean

                    Dim connstr As String = ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
                    Dim myconnection As New SqlConnection(connstr)
                    Dim cmd1, cmd2, cmd3 As New SqlCommand
                    Dim td As String
                    td = Format(Now, "yyyy-MM-dd HH:mm:ss")

                    Dim sqlstr1 As String = "INSERT INTO TRX_SERIAL_CLS SELECT * FROM TRX_SERIAL_OPEN WHERE MANU_LOT_NO='" & txtMfgLotNo.Text & "' "
                    Dim sqlstr2 As String = "DELETE FROM TRX_SERIAL_OPEN where MANU_LOT_NO='" & txtMfgLotNo.Text & "' "
                    Dim sqlstr3 As String = "UPDATE TRX_SERIAL_CLS SET CMP_STATUS=2 where MANU_LOT_NO='" & txtMfgLotNo.Text & "' "
                    cmd1 = New SqlCommand(sqlstr1, myconnection)
                    cmd2 = New SqlCommand(sqlstr2, myconnection)
                    cmd3 = New SqlCommand(sqlstr3, myconnection)
                    Dim ans As Boolean = True
                    Try
                              myconnection.Open()
                              cmd1.ExecuteNonQuery()
                              cmd2.ExecuteNonQuery()
                              cmd3.ExecuteNonQuery()
                              ans = True
                              'Class1.ShowMsg("Lot Suspended", "Ok", "success")
                    Catch ex As Exception
                              Class1.ShowMsg("Lot Close Error(TX):" & Mid(ex.Message, 1, 50), "Continue", "warning")
                              ans = False
                    Finally
                              myconnection.Close()
                    End Try
                    Return ans
          End Function

          Protected Sub Button1_Click1(sender As Object, e As EventArgs) Handles Button1.Click
                    Dim ans As Boolean
                    ans = TxRows()
                    If ans = True Then
                              Class1.ShowMsg("TX done", "Ok", "success")
                    Else
                              Class1.ShowMsg("TX Fail", "Ok", "critical")
                    End If

          End Sub
End Class