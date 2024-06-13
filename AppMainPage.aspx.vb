Imports System.Data.SqlClient
Imports System.Drawing
Imports MESLotTrace.Class1
Public Class AppMainPage
    Inherits System.Web.UI.Page
    Public LogonID As String
    Public Op As Integer
    Public connstr As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'LogonID = Request.QueryString("LogonID")
        'If LogonID Is Nothing Then
        '    LogonID = Request.QueryString("LoginID")
        'End If
        LogonID = Class1.GetLoginId(Request)

        txtLogonID.Text = LogonID
        txtLogonName.Text = GetuserName(LogonID)
        Op = Request.QueryString("Op")

        connstr = System.Configuration.ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
        '#FF9933 color for selected item
        If Not IsPostBack Then
            RetrieveAccess()

            Main.Visible = True
            AdminFunc.Visible = False
            OperFunc.Visible = False
            ReportFunc.Visible = False
            ImportSAP.Visible = False
            ExportSAP.Visible = False
            MastMaint.Visible = False

            Select Case Op
                Case 1
                    Main.Visible = False
                    AdminFunc.Visible = True
                    MastMaint.Visible = False
                    OperFunc.Visible = False
                    ReportFunc.Visible = False
                    ImportSAP.Visible = False
                    ExportSAP.Visible = False
                Case 2
                    Main.Visible = False
                    AdminFunc.Visible = False
                    MastMaint.Visible = True
                    OperFunc.Visible = False
                    ReportFunc.Visible = False
                    ImportSAP.Visible = False
                    ExportSAP.Visible = False
                Case 3
                    Main.Visible = False
                    AdminFunc.Visible = False
                    MastMaint.Visible = False
                    OperFunc.Visible = True
                    ReportFunc.Visible = False
                    ImportSAP.Visible = False
                    ExportSAP.Visible = False
                Case 4
                    Main.Visible = False
                    AdminFunc.Visible = False
                    MastMaint.Visible = False
                    OperFunc.Visible = False
                    ReportFunc.Visible = True
                    ImportSAP.Visible = False
                    ExportSAP.Visible = False
                Case 5
                    Main.Visible = False
                    AdminFunc.Visible = False
                    MastMaint.Visible = False
                    OperFunc.Visible = False
                    ReportFunc.Visible = False
                    ImportSAP.Visible = True
                    ExportSAP.Visible = False
                Case 6
                    Main.Visible = False
                    AdminFunc.Visible = False
                    MastMaint.Visible = False
                    OperFunc.Visible = False
                    ReportFunc.Visible = False
                    ImportSAP.Visible = False
                    ExportSAP.Visible = True

            End Select
        End If
        btnLogout.Visible = True
    End Sub
    Protected Sub ImageButton12_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton12.Click
        Main.Visible = True
        AdminFunc.Visible = False
        OperFunc.Visible = False
        ReportFunc.Visible = False
        ImportSAP.Visible = False
        ExportSAP.Visible = False
        MastMaint.Visible = False
    End Sub

    Protected Sub RetrieveAccess()
        Dim sqlstr As String
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "SELECT " +
                            "Acc " +
                               "FROM UserAccess " +
                               "WHERE EmpNo = '" & txtLogonID.Text.Trim & "'"

        myconnection.Open()
        Dim sda As New SqlDataAdapter
        Dim dt As New DataTable
        Try
            sda = New SqlDataAdapter(sqlstr, myconnection)
            sda.Fill(dt)
            DisableButtons(dt)

        Catch ex As Exception
            Class1.ShowMsg("Error during Save!", "Continue", "warning")
            Exit Sub
        End Try
    End Sub

    Private Sub DisableButtons(dataTable As DataTable)
        ' Get all buttons on the page
        Dim buttons As List(Of Button) = GetAllButtons(Me)

        ' Iterate through each button
        For Each btn As Button In buttons
            Dim dataKey As String = btn.Attributes("data-key")

            ' If the button has a data-key attribute
            If Not String.IsNullOrEmpty(dataKey) Then
                ' Check if the DataTable contains the key
                If dataTable.Rows.Cast(Of DataRow)().Any(Function(row) row("ACC").ToString() = dataKey) Then
                    ' Enable the button
                    btn.Enabled = True
                    btn.ToolTip = ""
                Else
                    ' Disable the button
                    btn.Enabled = False
                    btn.ToolTip = "You dont have permission to acesses this menu"
                    btn.BackColor = System.Drawing.Color.Gray
                    ' Optionally, change the text color
                    btn.ForeColor = System.Drawing.Color.White
                End If
            Else
                ' Enabled the button if it does not have a data-key attribute
                btn.Enabled = True
                btn.ToolTip = ""
            End If
        Next
    End Sub
    Private Function GetAllButtons(parent As Control) As List(Of Button)
        Dim buttons As New List(Of Button)()
        For Each control As Control In parent.Controls
            If TypeOf control Is Button Then
                buttons.Add(CType(control, Button))
            ElseIf control.HasControls() Then
                buttons.AddRange(GetAllButtons(control))
            End If
        Next
        Return buttons
    End Function
    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles btnAdmin.Click
        Main.Visible = False
        AdminFunc.Visible = True
        OperFunc.Visible = False
        ReportFunc.Visible = False
        ImportSAP.Visible = False
        ExportSAP.Visible = False
        MastMaint.Visible = False
        hfSelItem.Value = 1
    End Sub

    Protected Sub btnOper_Click(sender As Object, e As EventArgs) Handles btnOper.Click
        Main.Visible = False
        AdminFunc.Visible = False
        OperFunc.Visible = True
        ReportFunc.Visible = False
        ImportSAP.Visible = False
        ExportSAP.Visible = False
        MastMaint.Visible = False
        hfSelItem.Value = 3
    End Sub

    Protected Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Main.Visible = False
        AdminFunc.Visible = False
        OperFunc.Visible = False
        ReportFunc.Visible = True
        ImportSAP.Visible = False
        ExportSAP.Visible = False
        MastMaint.Visible = False
        hfSelItem.Value = 4
    End Sub

    Protected Sub btnImpSAP_Click(sender As Object, e As EventArgs) Handles btnImpSAP.Click
        Main.Visible = False
        AdminFunc.Visible = False
        OperFunc.Visible = False
        ReportFunc.Visible = False
        ImportSAP.Visible = True
        ExportSAP.Visible = False
        MastMaint.Visible = False
        hfSelItem.Value = 5
    End Sub

    Protected Sub btnExpSAP_Click(sender As Object, e As EventArgs) Handles btnExpSAP.Click
        Main.Visible = False
        AdminFunc.Visible = False
        OperFunc.Visible = False
        ReportFunc.Visible = False
        ImportSAP.Visible = False
        ExportSAP.Visible = True
        MastMaint.Visible = False
        hfSelItem.Value = 6
    End Sub

    Protected Sub btnMastMain_Click(sender As Object, e As EventArgs) Handles btnMastMain.Click
        Main.Visible = False
        AdminFunc.Visible = False
        OperFunc.Visible = False
        ReportFunc.Visible = False
        ImportSAP.Visible = False
        ExportSAP.Visible = False
        MastMaint.Visible = True
        hfSelItem.Value = 2
    End Sub
    Protected Sub btnLotMgt_Click(sender As Object, e As EventArgs) Handles btnOFLotMgt.Click
        Response.Redirect("LotMaint.aspx?LogonID=" & LogonID)
    End Sub
    Protected Sub btnUserAdmin_Click(sender As Object, e As EventArgs) Handles btnAFUserAdmin.Click
        Response.Redirect("UserAdmin.aspx?LogonID=" & LogonID)
    End Sub

    Protected Sub Button19_Click(sender As Object, e As EventArgs) Handles btnMMLine.Click
        Response.Redirect("MastLineMaint.aspx?LogonID=" & LogonID)
    End Sub
    Protected Sub btnMMStdUOM_Click(sender As Object, e As EventArgs) Handles btnMMStdUOM.Click
        'Response.Redirect("MastVendUOM.aspx?LogonID=" & LogonID)
    End Sub
    Protected Sub btnMMShift_Click(sender As Object, e As EventArgs) Handles btnMMShift.Click
        Response.Redirect("MastShiftMaint.aspx?LogonID=" & LogonID)
    End Sub
    Protected Sub btnMMProdCapa_Command(sender As Object, e As CommandEventArgs) Handles btnMMProdCapa.Command
        Response.Redirect("MastProdCapacity.aspx?LogonID=" & LogonID)
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnMMCompCode.Click
        Response.Redirect("MastCompanyCodeMaint.aspx?LogonID=" & LogonID)
    End Sub
    Protected Sub Button32_Click(sender As Object, e As EventArgs) Handles btnMMPlantCode.Click
        Response.Redirect("MastPlantCodeMaint.aspx?LogonID=" & LogonID)
    End Sub
    Protected Sub btnMMStep_Click(sender As Object, e As EventArgs) Handles btnMMStep.Click
        Response.Redirect("MastStep.aspx?LogonID=" & LogonID)
    End Sub
    Protected Sub Button26_Click(sender As Object, e As EventArgs) Handles btnMMEquip.Click
        Response.Redirect("MastEquip.aspx?LogonID=" & LogonID)
    End Sub
    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles btnMMStepEquip.Click
        Response.Redirect("MastEquipLink.aspx?LogonID=" & LogonID)
    End Sub
    Protected Sub Button10_Click(sender As Object, e As EventArgs) Handles BtnMMTraceMast.Click
        Response.Redirect("MastTrace.aspx?LogonID=" & LogonID)
    End Sub

    Protected Sub btnMMConspStep_Click(sender As Object, e As EventArgs) Handles btnMMConspStep.Click
        Response.Redirect("MastBOM.aspx?LogonID=" & LogonID)
    End Sub

    Protected Sub btnMMReason_Click(sender As Object, e As EventArgs) Handles btnMMReason.Click
        Response.Redirect("MastReasonMAINT.aspx?LogonID=" & LogonID)
    End Sub

    Protected Sub btnMMProcess_Click(sender As Object, e As EventArgs) Handles btnMMProcess.Click
        Response.Redirect("MastProcess.aspx?LogonID=" & LogonID)
    End Sub

    Protected Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Response.Redirect("AppLogin.aspx")
    End Sub
End Class