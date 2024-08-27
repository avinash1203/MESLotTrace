Imports System.Data.SqlClient
Imports System
Imports System.Web
Imports System.Configuration
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Text

Public Class ScrapMaint
          Inherits System.Web.UI.Page
          Public LogonID As String
          Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
                    LogonID = Request.QueryString("LogonID")
                    If Not IsPostBack Then
                              Fillddl()
                    End If
          End Sub

          Protected Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
                    Response.Redirect("Mainpage.aspx?LoginID=" & LogonID)
          End Sub

          Protected Sub ImageButton3_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton3.Click
                    Response.Redirect("AppMainpage.aspx?LogonID=" & LogonID & "&Op=3")
          End Sub
          Protected Sub Fillddl()
                    Dim sqlstr As String = "SELECT convert(integer,RSN_CD) as rsncd,RESN_NM FROM MAST_REASON "
                    Dim connstr As String = ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
                    Dim myConnection As New SqlConnection(connstr)
                    Dim sel As String
                    If rbRework.Checked = True Then
                              sel = "WHERE RSN_DIV = '100' "
                    Else
                              sel = "WHERE RSN_DIV = '103' "
                    End If



                    sqlstr = sqlstr + sel + " ORDER BY RSN_CD"
                    Dim sda As New SqlDataAdapter(sqlstr, myConnection)
                    Dim dt As New DataTable
                    sda.Fill(dt)
                    ddReasonCode.Items.Clear()
                    ddReasonCode.DataSource = dt
                    ddReasonCode.DataTextField = "resn_nm"
                    ddReasonCode.DataValueField = "rsncd"
                    ddReasonCode.DataBind()

          End Sub

          Protected Sub btnProcess_Click(sender As Object, e As EventArgs) Handles btnProcess.Click
                    Dim fileName As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
                    Call ProcessData(fileName)
                    Dim url As String = "AppMainpage.aspx?LogonID=" & LogonID & "&Op=3"

                    Class1.ShowMsgURL("Process Completed", "Ok", "success", url)

          End Sub
          Protected Sub ProcessData(ByVal FileName As String)
                    Dim connstr As String = ConfigurationManager.ConnectionStrings("Mydatabase").ConnectionString
                    Dim sqlstr, sqlstr2 As String
                    Dim myConnection As SqlConnection

                    Dim ST As String
                    If rbRework.Checked = True Then
                              ST = "2"
                    Else
                              ST = "1"
                    End If
                    Dim rsncd As String = ddReasonCode.SelectedValue
                    Dim upddte As String = Format(Now, "yyyy-MM-dd HH:mm:ss.fff")

                    sqlstr = "UPDATE TRX_SERIAL_OPEN " +
                                    "SET REJECTE_STATUS = @st, update_date =@upddte,rs_rsn_cd=@rsncd   where l_serial_no = @lsno "

                    sqlstr2 = "INSERT INTO TRX_SCRAPLOG (l_serial_no, update_date,rs_rsn_cd,status,err) values(@lsno,@upddte,@rsncd,@st,@err)"
                    Dim cmd As SqlCommand
                    myConnection = New SqlConnection(connstr)
                    myConnection.Open()
                    Dim ct As Integer = 0
                    Dim lsno As String
                    Dim ans As Integer
                    Dim errmsg As String
                    If Not Directory.Exists(Server.MapPath("~/Files")) Then
                              Directory.CreateDirectory(Server.MapPath("~/Files"))
                    End If
                    Dim path As String = Server.MapPath("~/Files/" & FileName)
                    FileUpload1.SaveAs(path)
                    If File.Exists(path) Then
                              Dim texts As String() = File.ReadAllLines(path)
                              For i = 0 To texts.Length - 1
                                        lsno = texts(i)
                                        upddte = Format(Now, "yyyy-MM-dd HH:mm:ss.fff")
                                        ct = ct + 1
                                        Try
                                                  cmd = New SqlCommand(sqlstr, myConnection)
                                                  cmd.Parameters.AddWithValue("@lsno", lsno)
                                                  cmd.Parameters.AddWithValue("@st", ST)
                                                  cmd.Parameters.AddWithValue("@upddte", upddte)
                                                  cmd.Parameters.AddWithValue("@rsncd", rsncd)
                                                  ans = cmd.ExecuteScalar
                                                  If ans = 0 Then
                                                            cmd = New SqlCommand(sqlstr2, myConnection)
                                                            cmd.Parameters.AddWithValue("@lsno", lsno)
                                                            cmd.Parameters.AddWithValue("@st", ST)
                                                            cmd.Parameters.AddWithValue("@upddte", upddte)
                                                            cmd.Parameters.AddWithValue("@rsncd", rsncd)
                                                            cmd.Parameters.AddWithValue("@err", "Not found")
                                                            cmd.ExecuteNonQuery()
                                                  End If
                                        Catch ex As Exception
                                                  cmd = New SqlCommand(sqlstr2, myConnection)
                                                  cmd.Parameters.AddWithValue("@lsno", lsno)
                                                  cmd.Parameters.AddWithValue("@st", ST)
                                                  cmd.Parameters.AddWithValue("@upddte", upddte)
                                                  cmd.Parameters.AddWithValue("@rsncd", rsncd)
                                                  errmsg = Trim(ex.Message)
                                                  If Len(ex.Message) > 201 Then
                                                            cmd.Parameters.AddWithValue("@err", Mid(errmsg, 1, 200))
                                                  Else
                                                            cmd.Parameters.AddWithValue("@err", errmsg)
                                                  End If

                                                  cmd.ExecuteNonQuery()
                                        End Try

                              Next
                    End If

                    myConnection.Close()

          End Sub

          Protected Sub rbRework_checked(sender As Object, e As EventArgs) Handles rbRework.CheckedChanged
                    If rbRework.Checked = True Then
                              Fillddl()
                    End If
          End Sub

          Protected Sub rbScrap_checked(sender As Object, e As EventArgs) Handles rbScrap.CheckedChanged
                    If rbScrap.Checked = True Then
                              Fillddl()
                    End If
          End Sub
End Class