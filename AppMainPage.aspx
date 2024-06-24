<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AppMainPage.aspx.vb" Inherits="MESLotTrace.AppMainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Main Page</title>
    <link href="dndod-popup.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="dndod-popup.min.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1">
</head>
<body>
    <form id="form1" runat="server" style="font-family: Calibri;">


        <div id="topLogo" class="toplogo">
            <table id="mainlogo" class="mainlogo">
                <tr>
                    <td class="auto-style1">
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/MinebeaMit.JPG" />
                    </td>
                    <td class="auto-style2">
                        <asp:Image ID="Image2" runat="server"
                            ImageUrl="~/Images/SystemLogo2.png" Width="70%" ImageAlign="AbsMiddle" />
                    </td>
                </tr>
            </table>
            <asp:ImageButton ID="ImageButton12" runat="server"
                Style="z-index: 1; left: 92%; top: 66px; position: absolute; width: 50px; height: 50px;"
                ImageUrl="~/Images/BackBlue01v1.png" />
        </div>
        <asp:Label ID="Label6" runat="server" Style="z-index: 1; position: absolute; top: 87px; height: 20px; left: 24px; width: 151px; right: 1217px;"
            Text="Logged On As : " Font-Size="Small" Font-Names="Arial Rounded MT Bold" Font-Bold="True"></asp:Label>
        <asp:TextBox ID="txtLogonID" runat="server"
            Style="z-index: 1; top: 84px; height: 20px; width: 142px; border-radius: 5px; padding-left: 5px; position: absolute; left: 186px; right: 1184px;" Font-Size="Medium" ReadOnly="True"></asp:TextBox>
        <asp:TextBox ID="txtLogonName" runat="server"
            Style="z-index: 1; position: absolute; border-radius: 5px; height: 20px; top: 84px; left: 353px; width: 308px;" Font-Size="Medium" ReadOnly="True"></asp:TextBox>

        <asp:Button ID="btnLogout" runat="server" Style="z-index: 1; left: 707px; top: 84px; position: absolute; height: 28px; width: 96px" Text="Logout"
            Font-Size="Small" Font-Names="Arial Rounded MT Bold" Font-Bold="True" />
        <%--    <asp:LinkButton ID="lkLogout" runat="server" Style="z-index: 99; position: absolute; width: 6%; left: 92%; top: 86px;"
            Font-Bold="True" Font-Names="Calibri" Font-Size="Large">Logout</asp:LinkButton>--%>



        <div id="mainpage" runat="server" style="z-index: 1; width: 99%; height: auto;">

            <div id="mainmenu" runat="server" style="z-index: 1; position: absolute; left: 10px; top: 121px; height: 552px; width: 26%; left: 23px; background-color: aqua; border: solid 1px blue">
                <asp:Button ID="btnAdmin" runat="server" Style="z-index: 1; left: 10px; top: 19px; position: absolute; width: 91%; height: 61px; border-radius: 10px;" Text="Adminstration" Font-Names="Arial Rounded MT Bold" Font-Size="30px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnMastMain" runat="server" Style="z-index: 1; left: 9px; top: 107px; position: absolute; width: 91%; height: 61px; border-radius: 10px;" Text="Master Maintenance" Font-Names="Arial Rounded MT Bold" Font-Size="25px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnOper" runat="server" Style="z-index: 1; left: 9px; top: 196px; position: absolute; width: 91%; height: 61px; border-radius: 10px;" Text="Operations" Font-Names="Arial Rounded MT Bold" Font-Size="25px" BackColor="Blue" ForeColor="#FFFFFF" />
                <asp:Button ID="btnReport" runat="server" Style="z-index: 1; left: 9px; top: 286px; position: absolute; width: 91%; height: 61px; border-radius: 10px; bottom: 205px;" Text="Reporting" Font-Names="Arial Rounded MT Bold" Font-Size="25px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnImpSAP" runat="server" Style="z-index: 1; left: 9px; top: 376px; position: absolute; width: 91%; height: 61px; border-radius: 10px;" Text="Import From SAP" Font-Names="Arial Rounded MT Bold" Font-Size="25px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnExpSAP" runat="server" Style="z-index: 1; left: 9px; top: 467px; position: absolute; width: 91%; height: 61px; border-radius: 10px;" Text="Export To SAP" Font-Names="Arial Rounded MT Bold" Font-Size="25px" BackColor="#0000FF" ForeColor="#FFFFFF" />
            </div>
            <div id="Main" runat="server">
                <asp:Image ID="Image4" runat="server" Style="z-index: 1; position: absolute; left: 30%; top: 124px; width: 65%; height: 570px; border: solid 1px black;" ImageUrl="~/Images/SystemLogo3.png"  />

            </div>
            <div id="AdminFunc" runat="server" style="z-index: 1; position: absolute; align-content: center; left: 30%; top: 121px; border: solid 1px black; width: 65%; height: 551px; background-color: #CCFFFF;">
                <asp:Label ID="Label1" runat="server" BackColor="#99CCFF" Font-Bold="True" Font-Names="Arial Rounded MT Bold" Font-Size="X-Large" Style="z-index: 1; left: 8px; top: 5px; text-align: center; position: absolute; width: 99%; height: 51px" Text="Administration"></asp:Label>
                <asp:Button ID="btnAFUserAdmin" data-key="User_Administration" runat="server" Style="z-index: 1; top: 73px; position: absolute; width: 37%; left: 30%; height: 48px; border-radius: 10px;" Text="User Administration" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <%-- <asp:Button ID="btnAFAccessControl" data-key="Access_Control" runat="server" Style="z-index: 1; left: 30%; top: 136px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Access Control" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />--%>
            </div>

            <div id="OperFunc" runat="server" style="z-index: 1; position: absolute; align-content: center; left: 30%; top: 121px; border: solid 1px black; width: 65%; height: 551px; background-color: #CCFFFF;">
                <asp:Label ID="Label7" runat="server" BackColor="#99CCFF" Font-Bold="True" Font-Names="Arial Rounded MT Bold" Font-Size="X-Large" Style="z-index: 1; left: 8px; top: 5px; text-align: center; position: absolute; width: 99%; height: 51px" Text="Operations"></asp:Label>
                <asp:Button ID="btnOFLotMgt" data-key="Lot_Management" runat="server" Style="z-index: 1; top: 73px; position: absolute; width: 37%; left: 30%; height: 48px; border-radius: 10px;" Text="Lot Management" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnOFRework" data-key="Rework" runat="server" Style="z-index: 1; left: 30%; top: 136px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Rework" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnOFScrap" data-key="Scrap_Item" runat="server" Style="z-index: 1; left: 30%; top: 199px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Scrap item" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnOFPrintTag" data-key="Print_Tag" runat="server" Style="z-index: 1; left: 30%; top: 262px; position: absolute; width: 37%; height: 48px; border-radius: 10px; bottom: 156px;" Text="Print Tag" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnOFTraceAmend" data-key="PLC_Data_Amend" runat="server" Style="z-index: 1; left: 30%; top: 325px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Trace Data Amendment" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
            </div>

            <div id="ReportFunc" runat="server" style="z-index: 1; position: absolute; align-content: center; left: 30%; top: 121px; border: solid 1px black; width: 65%; height: 551px; background-color: #CCFFFF;">
                <asp:Label ID="Label2" runat="server" BackColor="#99CCFF" Font-Bold="True" Font-Names="Arial Rounded MT Bold" Font-Size="X-Large" Style="z-index: 1; left: 8px; top: 5px; text-align: center; position: absolute; width: 99%; height: 51px" Text="Reporting"></asp:Label>
                <asp:Button ID="btnRFLineState" data-key="Reporting_Line_State" runat="server" Style="z-index: 1; top: 73px; position: absolute; width: 37%; left: 2%; height: 48px; border-radius: 10px;" Text="Line State" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnRFSerialOpen" data-key="SNO_Current" runat="server" Style="z-index: 1; left: 2%; top: 136px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Serial No. Current" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnRFSerialHist" data-key="SNO_History" runat="server" Style="z-index: 1; left: 2%; top: 199px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Serial History" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnRFSerialSkip" data-key="Skip_NG" runat="server" Style="z-index: 1; left: 2%; top: 262px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Serial Skip &amp; NG" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnRFPartCons" data-key="Parts_Consumption" runat="server" Style="z-index: 1; left: 2%; top: 325px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Part Consumption" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnRFLotTrace" data-key="Lot_Traceability" runat="server" Style="z-index: 1; left: 2%; top: 388px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Lot Traceability" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnRFMotDock" data-key="Motor_docking_Comp" runat="server" Style="z-index: 1; left: 60%; top: 73px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Motor Docking Component" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnRFPartBal" data-key="Part_Balance" runat="server" Style="z-index: 1; left: 60%; top: 136px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Part Balance" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnRFWorkerLog" data-key="Worker_Log_Information" runat="server" Style="z-index: 1; left: 60%; top: 199px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Worker Log Information" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnRFManuLotHistory" data-key="Manu_Lot_Info_History" runat="server" Style="z-index: 1; left: 60%; top: 262px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Manu. Lot Info History" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnRFPartScrap" data-key="Parts_Scrap_History" runat="server" Style="z-index: 1; left: 60%; top: 325px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Parts Scrap Information" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
            </div>
            <div id="ImportSAP" runat="server" style="z-index: 1; position: absolute; align-content: center; left: 30%; top: 121px; border: solid 1px black; width: 65%; height: 551px; background-color: #CCFFFF;">
                <asp:Label ID="Label3" runat="server" BackColor="#99CCFF" Font-Bold="True" Font-Names="Arial Rounded MT Bold" Font-Size="X-Large" Style="z-index: 1; left: 8px; top: 5px; text-align: center; position: absolute; width: 99%; height: 51px" Text="Import from SAP"></asp:Label>
                <asp:Button ID="btnImpMaterialMaster" data-key="Material_Master" runat="server" Style="z-index: 1; top: 73px; position: absolute; width: 37%; left: 30%; height: 48px; border-radius: 10px;" Text="Material Master" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnImpProdOrder" data-key="Production_Order" runat="server" Style="z-index: 1; left: 30%; top: 136px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Production Order" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnImpProdOrderComp" data-key="Prod_Order_Comp" runat="server" Style="z-index: 1; left: 30%; top: 199px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Production Order Component" Font-Names="Arial Rounded MT Bold" Font-Size="16px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnImpVendUOM" data-key="Vendor_UOM" runat="server" Style="z-index: 1; left: 30%; top: 262px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Vendor UOM" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
            </div>
            <div id="ExportSAP" runat="server" style="z-index: 1; position: absolute; align-content: center; left: 30%; top: 121px; border: solid 1px black; width: 65%; height: 551px; background-color: #CCFFFF;">
                <asp:Label ID="Label4" runat="server" BackColor="#99CCFF" Font-Bold="True" Font-Names="Arial Rounded MT Bold" Font-Size="X-Large" Style="z-index: 1; left: 8px; top: 5px; text-align: center; position: absolute; width: 99%; height: 51px" Text="Export To SAP"></asp:Label>
                <asp:Button ID="btnExpWorkResult" data-key="Work_Result" runat="server" Style="z-index: 1; top: 73px; position: absolute; width: 37%; left: 30%; height: 48px; border-radius: 10px;" Text="Work Result" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnExpPartConsumption" data-key="Parts_Consumed" runat="server" Style="z-index: 1; left: 30%; top: 136px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Parts Consumed" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnExpScrapInfo" data-key="Scrap_Informationt" runat="server" Style="z-index: 1; left: 30%; top: 199px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Scrap Information" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
            </div>
            <div id="MastMaint" runat="server" style="z-index: 1; position: absolute; align-content: center; left: 30%; top: 121px; border: solid 1px black; width: 65%; height: 551px; background-color: #CCFFFF;">
                <asp:Label ID="Label5" runat="server" BackColor="#99CCFF" Font-Bold="True" Font-Names="Arial Rounded MT Bold" Font-Size="X-Large" Style="z-index: 1; left: 8px; top: 5px; text-align: center; position: absolute; width: 99%; height: 51px" Text="Master Maintenance"></asp:Label>
                <asp:Button ID="btnMMLine" data-key="Maintenance_Line_State" runat="server" Style="z-index: 1; top: 73px; position: absolute; width: 37%; left: 2%; height: 48px; border-radius: 10px;" Text="Line" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnMMStdUOM" data-key="Standard_UOM" runat="server" Style="z-index: 1; left: 2%; top: 136px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Standard UOM" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnMMShift" data-key="Shift" runat="server" Style="z-index: 1; left: 2%; top: 199px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Shift" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnMMProdCapa" data-key="Prod_Capa_shift" runat="server" Style="z-index: 1; left: 2%; top: 262px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Prod. Capa. By Shift" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnMMProcess" data-key="Process" runat="server" Style="z-index: 1; left: 2%; top: 325px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Process" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnMMCompCode" data-key="Company_Code" runat="server" Style="z-index: 1; left: 2%; top: 388px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Company code" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnMMPlantCode" data-key="Plant_Code" runat="server" Style="z-index: 1; left: 2%; top: 451px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Plant Code" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />

                <asp:Button ID="btnMMStep" data-key="Step_Equipment" runat="server" Style="z-index: 1; left: 60%; top: 73px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Step" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnMMEquip" data-key="Equipment" runat="server" Style="z-index: 1; left: 60%; top: 136px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Equipment" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnMMStepEquip" data-key="Step_Equipment" runat="server" Style="z-index: 1; left: 60%; top: 199px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Step and Equip. Link" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="BtnMMTraceMast" data-key="Trace_Master" runat="server" Style="z-index: 1; left: 60%; top: 262px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Trace Master" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnMMConspStep" data-key="Comp_Cons_Step" runat="server" Style="z-index: 1; left: 60%; top: 325px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Comp. Cons by Step" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnMMReason" data-key="Reason_Master" runat="server" Style="z-index: 1; left: 60%; top: 388px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Reason Master" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnMMWorkerReg" Visible="false" data-key="Worker_Registration" runat="server" Style="z-index: 1; left: 60%; top: 451px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Worker Registration" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
            </div>

        </div>

        <asp:HiddenField ID="hflogonid" runat="server" />
        <asp:HiddenField ID="hfSelItem" runat="server" />
    </form>

</body>
</html>
