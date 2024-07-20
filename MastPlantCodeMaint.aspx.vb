Imports System.Configuration
Imports System.Data.SqlClient
'Imports class1
Public Class MastPlantCodeMaint
    Inherits System.Web.UI.Page
    Public connstr As String
    Public LogonId As String
    Public newflg As Integer

    Dim deleteChecking As New List(Of (String, String)) From {
    ("MAST_BOM", "plnt_cd"),
    ("MAST_EQUIP", "plnt_cd"),
    ("MAST_ITEM", "plnt_cd"),
    ("MAST_LINE", "plnt_cd"),
    ("MAST_LINE01", "plnt_cd"),
    ("MAST_LINE2", "plnt_cd"),
    ("MAST_MFGLOT", "plnt_cd"),
    ("MAST_MFGLOT_BOM", "plnt_cd"),
    ("MAST_MFGLOT2", "plnt_cd"),
    ("MAST_PROC", "plnt_cd"),
    ("MAST_PROC2", "plnt_cd"),
    ("MAST_PROD_CAPACITY", "plnt_cd"),
    ("MAST_SHIFT", "plnt_cd"),
    ("MAST_SHIFT2", "plnt_cd"),
    ("MAST_STEP", "plnt_cd"),
    ("MAST_STEP_EQUIPLINK", "plnt_cd"),
    ("MAST_TRACE", "plnt_cd"),
    ("MAST_VEND_UOM", "plnt_cd")
}


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LogonId = Request.QueryString("LogonID")

        DataEntryScr.Visible = False
        ConfirmDelete.Visible = False
        connstr = System.Configuration.ConfigurationManager.ConnectionStrings("MyDatabase").ConnectionString
        gvContent.DataBind()
        LoginUser.Text = "User ID : " & Class1.GetuserName(LogonId)



    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Call SaveData()
        gvContent.DataBind()

    End Sub
    Protected Sub SaveData()
        Dim sqlstr As String
        Dim cmd As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)
        sqlstr = "SELECT COUNT(*) FROM MAST_PLANTCODE WHERE PLTN_CD = @PLTNCD"
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@PLTNCD", txtPlantCd.Text)
        myconnection.Open()
        Dim ANS As Integer = cmd.ExecuteScalar
        myconnection.Close()

        If ANS > 0 And hfNewFlg.Value = 1 Then
            Class1.ShowMsg("Duplicate Plant ID..Please Check!", "Continue", "warning")
            Exit Sub
        End If


        If ANS > 0 Then
            Call UpdateMastCompCd()
        Else
            Call InsertMastCompCd()
        End If
    End Sub
    Private Sub InsertMastCompCd()
        Dim sqlstr As String
        Dim cmd As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "INSERT INTO MAST_PLANTCODE" +
                            "(PLTN_CD,PLTN_NM,REGR_ID,REGR_DATE,CNCL_FLG,UPD_ID,UPD_DATE)" +
                            "VALUES(" +
                            "@PLTNCD,@PLTNNM,@REGR_ID,@REGR_DATE,@CNCL_FLG,@UPD_ID,@UPD_DATE)"

        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@PLTNCD", txtPlantCd.Text.Trim)
        cmd.Parameters.AddWithValue("@PLTNNM", txtPlantNm.Text.Trim)
        cmd.Parameters.AddWithValue("@REGR_ID", LogonId)
        cmd.Parameters.AddWithValue("@REGR_DATE", Format(Now, "yyyy-MM-dd HH:mm:ss"))
        cmd.Parameters.AddWithValue("@CNCL_FLG", 0)
        cmd.Parameters.AddWithValue("@UPD_ID", "")
        cmd.Parameters.AddWithValue("@UPD_DATE", "1900-01-01")
        Try
            cmd.ExecuteNonQuery()

            Class1.ShowMsg("Saved Successfully", "Ok", "success")
            DataEntryScr.Visible = False

        Catch ex As Exception
            Class1.ShowMsg("Error during Save!", "Continue", "warning")
            Exit Sub
        End Try
    End Sub
    Protected Sub UpdateMastCompCd()

        Dim sqlstr As String
        Dim cmd As SqlCommand
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "UPDATE MAST_PLANTCODE 
                                      SET 
                                      PLTN_NM=@PLTNNM,
                                       UPD_ID=@UPD_ID,
                                       UPD_DATE= @UPD_DATE
                                       WHERE 
                                       PLTN_CD=@PLTNCD"

        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)
        cmd.Parameters.AddWithValue("@PLTNCD", txtPlantCd.Text.Trim)
        cmd.Parameters.AddWithValue("@PLTNNM", txtPlantNm.Text.Trim)
        cmd.Parameters.AddWithValue("@UPD_ID", LogonId)
        cmd.Parameters.AddWithValue("@UPD_DATE", Format(Now, "yyyy-MM-dd HH:mm:ss"))
        Try
            cmd.ExecuteNonQuery()

            Class1.ShowMsg("Updated Successfully", "Ok", "success")
            DataEntryScr.Visible = False
        Catch ex As Exception
            Class1.ShowMsg("Error during Update!", "Continue", "warning")
            Exit Sub
        End Try

    End Sub
    Private Sub Retrieve(ByVal pltncd As String)
        Dim sqlstr As String
        Dim myconnection As New SqlConnection
        myconnection = New SqlConnection(connstr)

        sqlstr = "SELECT " +
                            "PLTN_CD,PLTN_NM " +
                               "FROM MAST_PLANTCODE " +
                               "WHERE PLTN_CD = '" & pltncd & "'"

        myconnection.Open()
        'cmd = New SqlCommand(sqlstr, myconnection)
        Dim sda As New SqlDataAdapter
        Dim dt As New DataTable

        Try
            sda = New SqlDataAdapter(sqlstr, myconnection)
            sda.Fill(dt)
            txtPlantCd.Text = dt.Rows(0).Item(0)
            txtPlantNm.Text = dt.Rows(0).Item(1)

        Catch ex As Exception
            Class1.ShowMsg("Error during Save!", "Continue", "warning")
            Exit Sub
        End Try
    End Sub

    Private Sub DataEntryScr_Clear()
        txtPlantCd.Text = String.Empty
        txtPlantNm.Text = String.Empty

    End Sub
    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DataEntryScr_Clear()
        DataEntryScr.Visible = False
    End Sub

    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        newflg = 1
        hfNewFlg.Value = 1
        DataEntryScr_Clear()
        DataEntryScr.Visible = True

    End Sub

    Protected Sub gvContent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvContent.SelectedIndexChanged
        Dim rw As Integer = gvContent.SelectedIndex
        Dim compcd As String
        compcd = gvContent.Rows(rw).Cells(1).Text
        DataEntryScr_Clear()
        DataEntryScr.Visible = True
        newflg = 0
        hfNewFlg.Value = 0
        Call Retrieve(compcd)
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ConfirmDelete.Visible = True
    End Sub

    Protected Sub btnConfirmDelete_Click(sender As Object, e As EventArgs) Handles btnConfirmDelete.Click
        Dim sqlstr As String
        Dim cmd As SqlCommand
        Dim myconnection As New SqlConnection



        Dim result = Class1.ValuesExistInTables(deleteChecking, txtPlantCd.Text)
        Dim output As String = "Plant " & txtPlantCd.Text & " is getting used in forms :"
        If result IsNot Nothing AndAlso result.Count > 0 Then
            For Each kvp In result
                If kvp.Item2 Then
                    output += kvp.Item1 & " , "
                End If
            Next
        End If
        If result.Any(Function(x) x.Item2) Then
            Class1.ShowMsg(output, "Continue", "warning")
            Exit Sub
        End If





        myconnection = New SqlConnection(connstr)
        Dim updt As String = Format(Now, "yyyy-MM-dd HH:mm")
        sqlstr = "UPDATE MAST_PLANTCODE SET CNCL_FLG = 9,UPD_DATE='" & updt & "',UPD_ID='" & LogonId & "' " +
                       "WHERE PLTN_CD = '" & txtPlantCd.Text & "'"
        myconnection.Open()
        cmd = New SqlCommand(sqlstr, myconnection)
        Try
            cmd.ExecuteNonQuery()
            Class1.ShowMsg("Delete Completed!", "Continue", "warning")
            gvContent.DataBind()

        Catch ex As Exception
            Class1.ShowMsg("Error during Delete!", "Continue", "warning")
            Exit Sub
        End Try
        ConfirmDelete.Visible = False
    End Sub

    Protected Sub btnCanceldelete_Click(sender As Object, e As EventArgs) Handles btnCanceldelete.Click
        ConfirmDelete.Visible = False
    End Sub

    Protected Sub ImageButton3_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton3.Click
        Response.Redirect("APPMainpage.aspx?LogonID=" & LogonId & "&Op=2")
    End Sub

    Protected Sub gvContent_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvContent.PageIndex = e.NewPageIndex
        gvContent.DataBind()
    End Sub
End Class