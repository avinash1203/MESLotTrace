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
Imports MESLotTrace.Class1
Public Class MainPage
          Inherits System.Web.UI.Page
          Public LogonID As String
          Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
                    LogonID = Request.QueryString("LogonID")
          End Sub

          Protected Sub btnLotOp1_Click(sender As Object, e As EventArgs) Handles btnLotOp1.Click
                    Response.Redirect("LotMaint.aspx?LogonID=" & LogonID)
          End Sub

          Protected Sub btnMReason_Click(sender As Object, e As EventArgs) Handles btnMReason.Click
                    Response.Redirect("MastReasonMaint.aspx?LogonID=" & LogonID)
          End Sub

          Protected Sub btnMCompCd_Click(sender As Object, e As EventArgs) Handles btnMCompCd.Click
                    Response.Redirect("MastCompanyCodeMaint.aspx?LogonID=" & LogonID)
          End Sub

          Protected Sub btnPltCd_Click(sender As Object, e As EventArgs) Handles btnPltCd.Click
                    Response.Redirect("MastPlantCodeMaint.aspx?LogonID=" & LogonID)
          End Sub

          Protected Sub btnMShift_Click(sender As Object, e As EventArgs) Handles btnMShift.Click
                    Response.Redirect("MastShiftMaint.aspx?LogonID=" & LogonID)
          End Sub

          Protected Sub btnMLine_Click(sender As Object, e As EventArgs) Handles btnMLine.Click
                    Response.Redirect("MastLineMaint.aspx?LogonID=" & LogonID)
          End Sub

          Protected Sub btnMProdCapa_Click(sender As Object, e As EventArgs) Handles btnMProdCapa.Click
                    Response.Redirect("MastProdCapacity.aspx?LogonID=" & LogonID)
          End Sub

          Protected Sub btnMProcess_Click(sender As Object, e As EventArgs) Handles btnMProcess.Click
                    Response.Redirect("MastProc.aspx?LogonID=" & LogonID)
          End Sub

          Protected Sub btnMStep_Click(sender As Object, e As EventArgs) Handles btnMStep.Click
                    Response.Redirect("MastStep.aspx?LogonID=" & LogonID)
          End Sub

          Protected Sub btnMEquip_Click(sender As Object, e As EventArgs) Handles btnMEquip.Click
                    Response.Redirect("MastEquip.aspx?LogonID=" & LogonID)
          End Sub

          Protected Sub btnStepEquip_Click(sender As Object, e As EventArgs) Handles btnStepEquip.Click
                    Response.Redirect("MastEquipLink.aspx?LogonID=" & LogonID)
          End Sub

          Protected Sub btnMTrace_Click(sender As Object, e As EventArgs) Handles btnMTrace.Click
                    Response.Redirect("MastTrace.aspx?LogonID=" & LogonID)
          End Sub

          Protected Sub btnMBOM_Click(sender As Object, e As EventArgs) Handles btnMBOM.Click
                    Response.Redirect("MastBom.aspx?LogonID=" & LogonID)
          End Sub
End Class