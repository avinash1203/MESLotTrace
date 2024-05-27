Imports System.Configuration
Imports System.Data.SqlClient
'Imports class1
Public Class DECompanyCode

          Inherits System.Web.UI.Page
          Public connstr As String
          Public Logonid As String
          Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
                    '    Logonid = Request.QueryString("LogonID")
                    Logonid = "9900"
                    connstr = System.Configuration.ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
          End Sub
          'Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
          '          Call SaveData()
          'End Sub
          'Protected Sub SaveData()
          '          Dim sqlstr As String
          '          Dim cmd As SqlCommand
          '          Dim myconnection As New SqlConnection
          '          myconnection = New SqlConnection(connstr)
          '          sqlstr = "SELECT COUNT(*) FROM MAST_REASON WHERE RSN_CD = @RSN_CD"
          '          cmd = New SqlCommand(sqlstr, myconnection)
          '          cmd.Parameters.AddWithValue("@RSN_CD", Val(txtRSNcd.Text))
          '          myconnection.Open()
          '          Dim ANS As Integer = cmd.ExecuteScalar
          '          myconnection.Close()

          '          If ANS > 0 Then
          '                    Call UpdateMastReason()
          '          Else
          '                    Call InsertMastReason()
          '          End If
          'End Sub
          'Private Sub InsertMastReason()
          '          Dim sqlstr As String
          '          Dim cmd As SqlCommand
          '          Dim myconnection As New SqlConnection
          '          myconnection = New SqlConnection(connstr)

          '          sqlstr = "INSERT INTO MAST_REASON" +
          '                              "(RSN_CD,RSN_NM,RSN_DIV,RSN_GRP_CD,CAUSE_DIV,PROC_ID_CAUSE,DEPT_ID_CAUSE," +
          '                                 "DATA_TRANSFER_FLG,DATA_TRANSFER_MOV_FLG,NOTES,CNCL_FLG,UPD_ID,UPD_DATE)" +
          '                              "VALUES(" +
          '                              "@RSN_CD,@RSN_NM,@RSN_DIV,@RSN_GRP_CD,@CAUSE_DIV,@PROC_ID_CAUSE,@DEPT_ID_CAUSE," +
          '                              "@DATA_TRANSFER_FLG,@DATA_TRANSFER_MOV_FLG,@NOTES,@CNCL_FLG,@UPD_ID,@UPD_DATE)"

          '          myconnection.Open()
          '          cmd = New SqlCommand(sqlstr, myconnection)
          '          cmd.Parameters.AddWithValue("@RSN_CD", Val(txtRSNcd.Text))
          '          cmd.Parameters.AddWithValue("@RSN_NM", txtRSNNM.Text.Trim)
          '          cmd.Parameters.AddWithValue("@RSN_DIV", Val(txtRSNDiv.Text))
          '          cmd.Parameters.AddWithValue("@RSN_GRP_CD", txtRSNGrpCd.Text.Trim)
          '          cmd.Parameters.AddWithValue("@CAUSE_DIV", String.Empty)
          '          cmd.Parameters.AddWithValue("@PROC_ID_CAUSE", String.Empty)
          '          cmd.Parameters.AddWithValue("@DEPT_ID_CAUSE", txtSAPCostCntr.Text.Trim)
          '          cmd.Parameters.AddWithValue(" @DATA_TRANSFER_FLG", Val(txtSAPTrnCd.Text))
          '          cmd.Parameters.AddWithValue("@DATA_TRANSFER_MOV_FLG", Val(txtSAPMovCd.Text))
          '          cmd.Parameters.AddWithValue("@NOTES", txtRem.Text.Trim)
          '          cmd.Parameters.AddWithValue("CNCL_FLG", 0)
          '          cmd.Parameters.AddWithValue("@UPD_ID", Logonid)
          '          cmd.Parameters.AddWithValue("@UPD_DATE", Format(Now, "yyyy-MM-dd HH:mm:ss"))
          '          Try
          '                    cmd.ExecuteNonQuery()

          '                    Class1.ShowMsg("Data Saved Successfully", "Ok", "success")
          '                    Me.Visible = False
          '          Catch ex As Exception
          '                    Class1.ShowMsg("Error during save", "Continue", "warning")
          '                    Exit Sub
          '          End Try
          'End Sub
          'Protected Sub UpdateMastReason()
          '          '                Dim sqlstr2, sqlstr3 As String
          '          '                Dim myConnection As SqlConnection
          '          '                Dim RevNo As Integer = 0
          '          '                Dim InspStatus As String = String.Empty

          '          '                sqlstr2 = "UPDATE MISCINSPA " +
          '          '"SET " +
          '          '"cbYes1='" & cbYes1.Checked & "'" +
          '          '",cbNo1='" & cbNo1.Checked & "'" +
          '          '",cbNA1 = '" & cbNA1.Checked & "'" +
          '          '",Rem1='" & txtRem1.Text & "'" +
          '          '",cbYes2='" & cbYes2.Checked & "'" +
          '          '",cbNo2='" & cbNo2.Checked & "'" +
          '          '",cbNA2='" & cbNA2.Checked & "'" +
          '          '",Rem2='" & txtRem2.Text & "'" +
          '          '",cbYes3='" & cbYes3.Checked & "'" +
          '          '",cbNo3='" & cbNo3.Checked & "'" +
          '          '",cbNA3='" & cbNA3.Checked & "'" +
          '          '",Rem3='" & txtRem3.Text & "'" +
          '          '",cbYes4='" & cbYes4.Checked & "'" +
          '          '",cbNo4='" & cbNo4.Checked & "'" +
          '          '",cbNA4='" & cbNA4.Checked & "'" +
          '          '",Rem4='" & txtRem4.Text & "'" +
          '          '",cbYes5='" & cbYes5.Checked & "'" +
          '          '",cbNo5='" & cbNo5.Checked & "'" +
          '          '",cbNA5='" & cbNA5.Checked & "'" +
          '          '",Rem5='" & txtRem5.Text & "'" +
          '          '",cbYes6='" & cbYes6.Checked & "'" +
          '          '",cbNo6='" & cbNo6.Checked & "'" +
          '          '",cbNA6='" & cbNA6.Checked & "'" +
          '          '",Rem6='" & txtRem6.Text & "'" +
          '          '",cbYes7='" & cbYes7.Checked & "'" +
          '          '",cbNo7='" & cbNo7.Checked & "'" +
          '          '",cbNA7='" & cbNA7.Checked & "'" +
          '          '",Rem7='" & txtRem7.Text & "'" +
          '          '",cbYes16='" & cbyes16.Checked & "'" +
          '          '",cbNo16='" & cbno16.Checked & "'" +
          '          '",cbNA16='" & cbna16.Checked & "'" +
          '          '",Rem16='" & txtrem16.Text & "'" +
          '          '",cbYes17='" & cbyes17.Checked & "'" +
          '          '",cbNo17='" & cbno17.Checked & "'" +
          '          '",cbNA17='" & cbna17.Checked & "'" +
          '          '",Rem17='" & txtrem17.Text & "'" +
          '          '",cbYes18='" & cbyes18.Checked & "'" +
          '          '",cbNo18='" & cbno18.Checked & "'" +
          '          '",cbNA18='" & cbna18.Checked & "'" +
          '          '",Rem18='" & txtrem18.Text & "' " +
          '          ' " Where Docno=" & Val(txtDocNo.Text) & " and ProjID ='" & txtProjID.Text & "'"


          '          '                sqlstr3 = "UPDATE MISCINSPB " +
          '          '                   "SET " +
          '          '                   "NOTES ='" & Replace(txtNotes.Text, "'", "''") & "'   " +
          '          '                   " Where Docno=" & Val(txtDocNo.Text) & " And ProjID ='" & txtProjID.Text & "'"

          '          '                Dim cmd As SqlCommand

          '          '                myConnection = New SqlConnection(connstr)
          '          '                myConnection.Open()

          '          '                cmd = New SqlCommand(sqlstr2, myConnection)

          '          '                Try
          '          '                          cmd.ExecuteNonQuery()
          '          '                Catch ex As Exception
          '          '                End Try

          '          '                cmd = New SqlCommand(sqlstr3, myConnection)
          '          '                Dim url As String
          '          '                Dim msg As String
          '          '                Try
          '          '                          cmd.ExecuteNonQuery()
          '          '                Catch ex As Exception
          '          '                          url = "MiscInspByProject.aspx?LogonID=" & Logonid & "&ProjID=" & txtProjID.Text & ""
          '          '                          msg = CP.PopUpMsgUrl("Checklist Update Error:<br>" & Mid(ex.Message, 1, 100), "OK", "success", url)
          '          '                          Page.ClientScript.RegisterStartupScript(Me.GetType(), "test02", msg, True)


          '          '                End Try

          '          '                myConnection.Close()


          '          '                url = "MiscInspByProject.aspx?LogonID=" & Logonid & "&ProjID=" & txtProjID.Text & ""
          '          '                msg = CP.PopUpMsgUrl("Checklist Updated.", "OK", "success", url)
          '          '                Page.ClientScript.RegisterStartupScript(Me.GetType(), "test02", msg, True)
          'End Sub


End Class