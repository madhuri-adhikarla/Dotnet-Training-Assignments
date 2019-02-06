<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="demo.aspx.cs" Inherits="ConsumeWebServicesDemo.demo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td>enter code :</td>
                <td>
                    <asp:TextBox ID="tb1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="submitData" runat="server" Text="submit" OnClick="submitData_Click" /></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl1" runat="server"></asp:Label> 
                    <br /><div runat="server" id="output">

                                                                     </div>  </td>
            </tr>
        </table>
    </form>
</body>
</html>
