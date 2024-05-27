<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ExportFunction.aspx.vb" Inherits="MESLotTrace.ExportFunction" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Export Funtions</title>
    <link href="dndod-popup.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="dndod-popup.min.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link href="Styles/StyleSheet.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div id="ExportData" runat="server" style="z-index: 1; position: absolute; width: 266px; height: 615px; top: 10px; left: 250px;">
            <asp:Label ID="Label5" runat="server" Style="z-index: 1; left: 10px; top: 10px; position: absolute; width: 242px" Text="Export to SAP" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            <asp:Button ID="Button11" runat="server" Style="z-index: 1; left: 10px; top: 60px; position: absolute; width: 242px" Text="Work Result" CssClass="cmdbtn" />
            <asp:Button ID="Button12" runat="server" Style="z-index: 1; left: 10px; top: 100px; position: absolute; width: 242px" Text="Part Consumed" CssClass="cmdbtn" />
            <asp:Button ID="Button13" runat="server" Style="z-index: 1; left: 10px; top: 140px; position: absolute; width: 242px" Text="Scrap Information" CssClass="cmdbtn" />
        </div>
    </form>
</body>
</html>
