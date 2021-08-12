<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FileAttachment.aspx.vb" Inherits="IAccessHomeTest.FileAttachment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Test Fujiwati</title>
    <style>    
    #GV td{  
     
    word-break:break-all;
    width:300px;
    text-align:center;

        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblMessage" runat="server" ForeColor="red" font-name="Verdana" Font-Size="11px"></asp:Label>
        <asp:Panel runat="server" ID="pnlInsert" Visible="true">
            <asp:Button runat="server" ID="btnInsertData" Text="Insert Data" OnClick="btnInsertData_Click" />
        </asp:Panel>  
        <br />
        <br />
        <asp:Panel runat="server" ID="PnlSearch" Visible="true">
            <asp:TextBox runat="server" ID="txtSearch" ></asp:TextBox>&nbsp;
            <asp:Button runat="server" ID="btnSearch" Text="Search Data" OnClick="btnSearch_Click" />
            <br />
            <br />
            <asp:GridView runat="server" ID="GV"></asp:GridView>
            
        </asp:Panel>
    </div>
    </form>
</body>
</html>
