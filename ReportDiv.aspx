<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReportDiv.aspx.vb" Inherits="MESLotTrace.ReportDiv" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="ReportFunc" runat="server" style="z-index: 1; position: absolute; align-content: center; left: 30%; top: 121px; border: solid 1px black; width: 65%; height: 551px; background-color: #CCFFFF;">
                <asp:Label ID="Label2" runat="server" BackColor="#99CCFF" Font-Bold="True" Font-Names="Arial Rounded MT Bold" Font-Size="X-Large" Style="z-index: 1; left: 8px; top: 5px; text-align: center; position: absolute; width: 99%; height: 51px" Text="Reporting"></asp:Label>
                <asp:Button ID="btnLineState" runat="server" Style="z-index: 1; top: 73px; position: absolute; width: 37%; left: 2%; height: 48px; border-radius: 10px; " Text="Line State" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnSerialOpen" runat="server" Style="z-index: 1; left: 2%; top: 136px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Serial No. Current" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnSerialHist" runat="server" Style="z-index: 1; left: 2%; top: 199px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Serial History" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnSerialSkip" runat="server" Style="z-index: 1; left: 2%; top: 262px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Serial Skip &amp; NG" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnPartCons" runat="server" Style="z-index: 1; left: 2%; top: 325px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Part Consumption" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnLotTrace" runat="server" Style="z-index: 1; left: 2%; top: 388px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Lot Traceability" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnMotDock" runat="server" Style="z-index: 1; left: 60%; top: 73px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Motor Docking Component" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnPartBal" runat="server" Style="z-index: 1; left: 60%; top: 136px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Part Balance" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnWorkerLog" runat="server" Style="z-index: 1; left: 60%; top: 199px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Worker Log Information" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnManuLotHistory" runat="server" Style="z-index: 1; left: 60%; top: 262px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Manu. Lot Info History" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
                <asp:Button ID="btnPartScrap" runat="server" Style="z-index: 1; left: 60%; top: 325px; position: absolute; width: 37%; height: 48px; border-radius: 10px;" Text="Parts Scrap Information" Font-Names="Arial Rounded MT Bold" Font-Size="20px" BackColor="#0000FF" ForeColor="#FFFFFF" />
            </div>
    </form>
</body>
</html>
