<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OperationFunction.aspx.vb" Inherits="MESLotTrace.OperationFunction" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Operations Function</title>
    <link href="dndod-popup.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="dndod-popup.min.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link href="Styles/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="Operation" runat="server" style="z-index: 1; position: absolute; width: 528px; height: 615px; top: 10px; left: 250px;">
            <asp:Label ID="Label3" runat="server" Style="z-index: 1; left: 10px; top: 10px; position: absolute; width: 340px" Text="Operation Function" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            <asp:Button ID="btnLotOp1" runat="server" Style="z-index: 1; left: 10px; top: 60px; position: absolute; width: 242px" Text="Lot Management" CssClass="cmdbtn" />
            <asp:Button ID="btnLotOp2" runat="server" Style="z-index: 1; left: 10px; top: 100px; position: absolute; width: 242px" Text="Lot Rework/Scrap" CssClass="cmdbtn" />
            <asp:Button ID="btnPartMgmt" runat="server" Style="z-index: 1; left: 10px; top: 140px; position: absolute; width: 242px" Text="Part Management" CssClass="cmdbtn" />
            <asp:Button ID="btnPrintTag" runat="server" Style="z-index: 1; left: 10px; top: 180px; position: absolute; width: 242px" Text="Print Tag" CssClass="cmdbtn" />
            <asp:Button ID="Button15" runat="server" Style="z-index: 1; left: 10px; top: 220px; position: absolute; width: 242px" Text="PLC Trace data Amendment" CssClass="cmdbtn" />
        </div>
    </form>
</body>
</html>
