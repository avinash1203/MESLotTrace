<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MainPage.aspx.vb" Inherits="MESLotTrace.MainPage" %>

<%--<!DOCTYPE html>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>System Functions</title>
    <link href="dndod-popup.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="dndod-popup.min.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
</head>
<body>
    <form id="form1" runat="server">
        <asp:Image ID="Image3" runat="server"
            ImageUrl="~/Images/MinebeaMit.JPG"
            Height="67px"
            ImageAlign="Left"
            Width="278px" />
        <div id="ImportData" runat="server" style="z-index: 1; position: absolute; width: 263px; height: 215px; top: 118px; left: 26px;">
            <asp:Label ID="Label1" runat="server" Style="z-index: 1; left: 10px; top: 10px; position: absolute; width: 242px" Text="Import from SAP"></asp:Label>
            <asp:Button ID="btnImpMaterialMaster" runat="server" Style="z-index: 1; left: 10px; top: 40px; position: absolute; width: 242px" Text="Import Material Master" />
            <asp:Button ID="btnImpProdOrder" runat="server" Style="z-index: 1; left: 10px; top: 80px; position: absolute; width: 242px" Text="Import Production Order" />
            <asp:Button ID="btnImpProdOrderCom" runat="server" Style="z-index: 1; left: 10px; top: 120px; position: absolute; width: 242px" Text="Import Prod. Order Component" />
            <asp:Button ID="btnVendBom" runat="server" Style="z-index: 1; left: 10px; top: 160px; position: absolute; width: 242px" Text="Import Vendor UOM" />
        </div>
        <div id="MasterMaint" runat="server" style="z-index: 1; position: absolute; width: 266px; height: 615px; top: 118px; left: 308px;">
            <asp:Label ID="Label2" runat="server" Style="z-index: 1; left: 10px; top: 10px; position: absolute; width: 242px" Text="Master Maintenance"></asp:Label>
            <asp:Button ID="btnMStdUOM" runat="server" Style="z-index: 1; left: 10px; top: 40px; position: absolute; width: 242px" Text="Standard UOM" />
            <asp:Button ID="btnMShift" runat="server" Style="z-index: 1; left: 10px; top: 80px; position: absolute; width: 242px" Text="Shift" />
            <asp:Button ID="btnMProdCapa" runat="server" Style="z-index: 1; left: 10px; top: 120px; position: absolute; width: 242px" Text="Prod. Capacity by Shift" />
            <asp:Button ID="btnMLine" runat="server" Style="z-index: 1; left: 10px; top: 160px; position: absolute; width: 242px" Text="Line" />
            <asp:Button ID="btnMProcess" runat="server" Style="z-index: 1; left: 10px; top: 200px; position: absolute; width: 242px" Text="Process" />
            <asp:Button ID="btnMStep" runat="server" Style="z-index: 1; left: 10px; top: 240px; position: absolute; width: 242px" Text="Step" />
            <asp:Button ID="btnMEquip" runat="server" Style="z-index: 1; left: 10px; top: 280px; position: absolute; width: 242px" Text="Equipment" />
            <asp:Button ID="btnStepEquip" runat="server" Style="z-index: 1; left: 10px; top: 320px; position: absolute; width: 242px" Text="Step and Equipment Link" />
            <asp:Button ID="btnMTrace" runat="server" Style="z-index: 1; left: 10px; top: 360px; position: absolute; width: 242px" Text="Traceability Collection Master" />
            <asp:Button ID="btnMBOM" runat="server" Style="z-index: 1; left: 10px; top: 400px; position: absolute; width: 242px" Text="Comp. Cons. By Step" />
            <asp:Button ID="btnMReason" runat="server" Style="z-index: 1; left: 10px; top: 440px; position: absolute; width: 242px" Text="Reason and Mapping" />
            <asp:Button ID="btnWorkerReg" runat="server" Style="z-index: 1; left: 10px; top: 480px; position: absolute; width: 242px" Text="Worker Registration" />
            <asp:Button ID="btnMCompCd" runat="server" Style="z-index: 1; left: 10px; top: 520px; position: absolute; width: 242px" Text="Company Code" />
            <asp:Button ID="btnPltCd" runat="server" Style="z-index: 1; left: 10px; top: 560px; position: absolute; width: 242px" Text="Plant Code" />
        </div>
        <div id="Operation" runat="server" style="z-index: 1; position: absolute; width: 269px; height: 615px; top: 118px; left: 590px;">
            <asp:Label ID="Label3" runat="server" Style="z-index: 1; left: 10px; top: 10px; position: absolute; width: 242px" Text="Operation Function"></asp:Label>
            <asp:Button ID="btnLotOp1" runat="server" Style="z-index: 1; left: 10px; top: 40px; position: absolute; width: 242px" Text="Lot Management" />
            <asp:Button ID="btnLotOp2" runat="server" Style="z-index: 1; left: 10px; top: 80px; position: absolute; width: 242px" Text="Lot Rework/Scrap" />
            <asp:Button ID="btnPartMgmt" runat="server" Style="z-index: 1; left: 10px; top: 120px; position: absolute; width: 242px" Text="Part Management" />
            <asp:Button ID="btnPrintTag" runat="server" Style="z-index: 1; left: 10px; top: 160px; position: absolute; width: 242px" Text="Print Tag" />
            <asp:Button ID="Button15" runat="server" Style="z-index: 1; left: 10px; top: 200px; position: absolute; width: 242px" Text="PLC Trace data Amendment" />
        </div>
        <div id="Report" runat="server" style="z-index: 1; position: absolute; width: 269px; height: 615px; top: 118px; left: 874px;">
            <asp:Label ID="Label4" runat="server" Style="z-index: 1; left: 10px; top: 10px; position: absolute; width: 242px" Text="Reporting"></asp:Label>
            <asp:Button ID="Button1" runat="server" Style="z-index: 1; left: 10px; top: 40px; position: absolute; width: 242px" Text="Line State Master" />
            <asp:Button ID="Button2" runat="server" Style="z-index: 1; left: 10px; top: 80px; position: absolute; width: 242px" Text="Serial Summ(Curr & Incomplete" />
            <asp:Button ID="Button3" runat="server" Style="z-index: 1; left: 10px; top: 120px; position: absolute; width: 242px" Text="Serial Summary (History)" />
            <asp:Button ID="Button4" runat="server" Style="z-index: 1; left: 10px; top: 160px; position: absolute; width: 242px" Text="Serial Skip & NG Insp. Log" />
            <asp:Button ID="Button5" runat="server" Style="z-index: 1; left: 10px; top: 200px; position: absolute; width: 242px" Text="Parts Traceability Data" />
            <asp:Button ID="Button6" runat="server" Style="z-index: 1; left: 10px; top: 240px; position: absolute; width: 242px" Text="MotorComponent Docking Data" />
            <asp:Button ID="Button7" runat="server" Style="z-index: 1; left: 10px; top: 280px; position: absolute; width: 242px" Text="Part's Input and Bal. Qty Data" />
            <asp:Button ID="Button8" runat="server" Style="z-index: 1; left: 10px; top: 320px; position: absolute; width: 242px" Text="Worker Log Information" />
            <asp:Button ID="Button9" runat="server" Style="z-index: 1; left: 10px; top: 360px; position: absolute; width: 242px" Text="Manu. Lot Info && History" />
            <asp:Button ID="Button10" runat="server" Style="z-index: 1; left: 10px; top: 400px; position: absolute; width: 242px" Text="Parts Scrap Information" />
            <asp:Button ID="Button14" runat="server" Style="z-index: 1; left: 10px; top: 440px; position: absolute; width: 242px" Text="Lot Traceability Analysis" />
        </div>
        <div id="ExportData" runat="server" style="z-index: 1; position: absolute; width: 266px; height: 615px; top: 118px; left: 1153px;">
            <asp:Label ID="Label5" runat="server" Style="z-index: 1; left: 10px; top: 10px; position: absolute; width: 242px" Text="Export to SAP"></asp:Label>
            <asp:Button ID="Button11" runat="server" Style="z-index: 1; left: 10px; top: 40px; position: absolute; width: 242px" Text="Work Result" />
            <asp:Button ID="Button12" runat="server" Style="z-index: 1; left: 10px; top: 80px; position: absolute; width: 242px" Text="Part Consumed" />
            <asp:Button ID="Button13" runat="server" Style="z-index: 1; left: 10px; top: 120px; position: absolute; width: 242px" Text="Scrap Information" />
        </div>

    </form>
</body>
</html>
