<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ImportFunction.aspx.vb" Inherits="MESLotTrace.ImportFunction" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Import Data from SAP</title>
        <link href="dndod-popup.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="dndod-popup.min.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link href="Styles/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
       <div id="ImportData" runat="server" style="z-index: 1; position: absolute; width: 263px; height: 215px; top: 5px; left: 250px;">
            <asp:Label ID="Label1" runat="server" Style="z-index: 1; left: 10px; top: 10px; position: absolute; width: 242px" Text="Import from SAP" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            <asp:Button ID="btnImpMaterialMaster" runat="server" Style="z-index: 1; left: 10px; top: 60px; position: absolute; width: 242px" Text="Import Material Master" CssClass="cmdbtn" />
            <asp:Button ID="btnImpProdOrder" runat="server" Style="z-index: 1; left: 10px; top: 100px; position: absolute; width: 242px" Text="Import Production Order" CssClass="cmdbtn" />
            <asp:Button ID="btnImpProdOrderCom" runat="server" Style="z-index: 1; left: 10px; top: 140px; position: absolute; width: 242px" Text="Import Prod. Order Component" CssClass="cmdbtn" />
            <asp:Button ID="btnVendBom" runat="server" Style="z-index: 1; left: 10px; top: 180px; position: absolute; width: 242px" Text="Import Vendor UOM" CssClass="cmdbtn" />
        </div>
    </form>
</body>
</html>
