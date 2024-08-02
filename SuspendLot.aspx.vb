Imports System.Data.SqlClient
Imports System.Configuration
Public Class SuspendLot
          Inherits System.Web.UI.Page

          Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
                    Call FillddlProcID()
                    If Not IsPostBack Then
                              Call FillgvMlot("")
                    End If
          End Sub
          Protected Sub FillddlProcID()
                    Dim sqlstr As String = "Select proc_flow_id from MAST_PROC order by proc_flow_id"
                    Dim connstr As String = ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
                    Dim myConnection As New SqlConnection(connstr)
                    Dim cmd As New SqlCommand(sqlstr, myConnection)
                    Dim sda As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable
                    sda.Fill(dt)
                    'ddlProcID.DataSource = dt
                    'ddlProcID.DataTextField = "proc_flow_id"
                    'ddlProcID.DataBind().
                    ddlProcID.Items.Insert(0, "-- Select -- ")
                    For i = 0 To dt.Rows.Count() - 1
                              ddlProcID.Items.Insert(i + 1, dt.Rows(i).Item(0))
                    Next
          End Sub
          Protected Sub FillgvMlot(ByVal procid As String)

                    Dim sqlstr As String
                    If procid = "" Then
                              sqlstr = "Select manu_lot_no,item_cd,proc_flow_id " +
                                              "from MAST_MFGLOT WHERE LOT_STS_DIV = '01' " +
                                               "order by MANU_LOT_NO "

                    Else
                              sqlstr = "Select manu_lot_no,item_cd,proc_flow_id " +
                                               "from MAST_MFGLOT WHERE LOT_STS_DIV = '01'  and proc_flow_id='" & procid & "' " +
                                               "order by MANU_LOT_NO "
                    End If


                    Dim connstr As String = ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
                    Dim myConnection As New SqlConnection(connstr)
                    Dim cmd As New SqlCommand(sqlstr, myConnection)
                    Dim sda As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable
                    sda.Fill(dt)
                    gvMlot.DataSource = dt
                    gvMlot.DataBind()
          End Sub

          Protected Sub ddlProcID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProcID.SelectedIndexChanged

                    Dim procid As String
                    Dim rowindex As Integer = ddlProcID.SelectedIndex

                    If rowindex = 0 Then
                              procid = ""
                    Else
                              procid = ddlProcID.SelectedValue
                    End If

                    Call FillgvMlot(procid)

          End Sub
End Class