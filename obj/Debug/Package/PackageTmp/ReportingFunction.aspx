<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReportingFunction.aspx.vb" Inherits="MESLotTrace.ReportingFunction" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reporting</title>
    <link href="dndod-popup.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="dndod-popup.min.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link href="Styles/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="Report" runat="server" style="z-index: 1; position: absolute; width: 300px; height: 615px; top: 10px; left: 250px;">
            <asp:Label ID="Label4" runat="server" Style="z-index: 1; left: 10px; top: 10px; position: absolute; width: 242px" Text="Reporting" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            <asp:Button ID="Button1" runat="server" Style="z-index: 1; left: 10px; top: 60px; position: absolute; width: 242px" Text="Line State Master" CssClass="cmdbtn" />
            <asp:Button ID="Button2" runat="server" Style="z-index: 1; left: 10px; top: 100px; position: absolute; width: 242px" Text="Serial Summ(Curr & Incomplete" CssClass="cmdbtn" />
            <asp:Button ID="Button3" runat="server" Style="z-index: 1; left: 10px; top: 140px; position: absolute; width: 242px; bottom: 445px;" Text="Serial Summary (History)" CssClass="cmdbtn" />
            <asp:Button ID="Button4" runat="server" Style="z-index: 1; left: 10px; top: 180px; position: absolute; width: 242px" Text="Serial Skip & NG Insp. Log" CssClass="cmdbtn" />
            <asp:Button ID="Button5" runat="server" Style="z-index: 1; left: 10px; top: 220px; position: absolute; width: 242px" Text="Parts Traceability Data" CssClass="cmdbtn" />
            <asp:Button ID="Button6" runat="server" Style="z-index: 1; left: 10px; top: 260px; position: absolute; width: 242px" Text="MotorComponent Docking Data" CssClass="cmdbtn" />
            <asp:Button ID="Button7" runat="server" Style="z-index: 1; left: 10px; top: 300px; position: absolute; width: 242px" Text="Part's Input and Bal. Qty Data" CssClass="cmdbtn" />
            <asp:Button ID="Button8" runat="server" Style="z-index: 1; left: 10px; top: 340px; position: absolute; width: 242px" Text="Worker Log Information" CssClass="cmdbtn" />
            <asp:Button ID="Button9" runat="server" Style="z-index: 1; left: 10px; top: 380px; position: absolute; width: 242px" Text="Manu. Lot Info && History" CssClass="cmdbtn" />
            <asp:Button ID="Button10" runat="server" Style="z-index: 1; left: 10px; top: 420px; position: absolute; width: 242px" Text="Parts Scrap Information" CssClass="cmdbtn" />
            <asp:Button ID="Button14" runat="server" Style="z-index: 1; left: 10px; top: 460px; position: absolute; width: 242px" Text="Lot Traceability Analysis" CssClass="cmdbtn" />
        </div>
    </form>
</body>
</html>
