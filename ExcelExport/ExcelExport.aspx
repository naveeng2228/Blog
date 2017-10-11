<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExcelExport.aspx.cs" Inherits="ExcelExport.ExcelExport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
        <div>
            <asp:Button ID="btn_Excel" runat="server" Text="Excel"
                OnClick="btn_Excel_Click" />
            <br />
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <br />
            <div id="downloadpath" runat="server" visible="false"><asp:HyperLink ID="hfDownloadPath" runat="server" Text="Click here"></asp:HyperLink> to download now.</div>
        </div>
    </form>
</body>
</html>
