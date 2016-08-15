<%@  Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="arama_motoru._Default" aspcompat="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
<script language="vbscript" type="text/vbscript">

function b()
    msgbox("tmm")
end function

</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;<asp:Button ID="ara" runat="server" Text="ara" />&nbsp;
        <asp:TextBox ID="kelime" runat="server" Height="14px" Width="510px"></asp:TextBox>&nbsp;<br />
        <br />
        <br />
    </div>
    </form>
</body>
</html>

