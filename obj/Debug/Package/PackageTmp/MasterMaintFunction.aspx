<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MasterMaintFunction.aspx.vb" Inherits="MESLotTrace.MasterMaintFunction" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Master Maintenance</title>
    <link href="dndod-popup.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="dndod-popup.min.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link href="Styles/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="MasterMaint" runat="server" style="z-index: 1; position: absolute; width: 541px; height: 615px; top: 10px; left: 250px;">
            <asp:Label ID="Label2" runat="server" Style="z-index: 1; left: 10px; top: 10px; position: absolute; width: 334px; height: 38px;" Text="Master Maintenance" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            <asp:Button ID="btnMStdUOM" runat="server" Style="z-index: 1; left: 10px; top: 60px; position: absolute; width: 242px" Text="Standard UOM" CssClass="cmdbtn" />
            <asp:Button ID="btnMShift" runat="server" Style="z-index: 1; left: 10px; top: 100px; position: absolute; width: 242px" Text="Shift Master" CssClass="cmdbtn" />
            <asp:Button ID="btnMProdCapa" runat="server" Style="z-index: 1; left: 10px; top: 140px; position: absolute; width: 242px" Text="Prod. Capacity Master by Shift" CssClass="cmdbtn" />
            <asp:Button ID="btnMLine" runat="server" Style="z-index: 1; left: 10px; top: 180px; position: absolute; width: 242px" Text="Line Master" CssClass="cmdbtn" />
            <asp:Button ID="btnMProcess" runat="server" Style="z-index: 1; left: 10px; top: 220px; position: absolute; width: 242px" Text="Process Master" CssClass="cmdbtn" />
            <asp:Button ID="btnMStep" runat="server" Style="z-index: 1; left: 10px; top: 260px; position: absolute; width: 242px" Text="Step Master" CssClass="cmdbtn" />
            <asp:Button ID="btnMTrace" runat="server" Style="z-index: 1; left: 10px; top: 300px; position: absolute; width: 242px" Text="Traceability Collection Master" CssClass="cmdbtn" />
            <asp:Button ID="btnMBOM" runat="server" Style="z-index: 1; left: 10px; top: 340px; position: absolute; width: 242px" Text="Comp. Cons. By Step" CssClass="cmdbtn" />
            <asp:Button ID="btnMReason" runat="server" Style="z-index: 1; left: 10px; top: 380px; position: absolute; width: 242px" Text="Reason and Mapping Master" CssClass="cmdbtn" />
            <asp:Button ID="btnWorkerReg" runat="server" Style="z-index: 1; left: 10px; top: 420px; position: absolute; width: 242px" Text="Work Registration" CssClass="cmdbtn" />
        </div>
    </form>
</body>
</html>
