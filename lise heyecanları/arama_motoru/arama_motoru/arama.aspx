<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="arama.aspx.vb" Inherits="arama_motoru.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//TR" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" lang = "TR"  >
<head runat="server">
    <title>Untitled Page</title>

	<style type="text/css">
		#detay
		{
	width:100%;
	color:#000000;
	border-top-color: #FFFFFF;
	border-top-width: 3px;
	border-top-style: solid;
		}
	</style>
    
<script language="javascript" type="text/javascript">
// <!CDATA[

// ]]>
</script>
</head>
<body>
    <form id="form1" runat="server">
     <div style="left: -1px; width: 100%; position: absolute; top: 26px; height: 76px; background-color: #00CCFF;">
     <center>
<asp:TextBox ID="kelime" runat="server" Height="19px" Width="421px"></asp:TextBox><asp:Button ID="ARA" runat="server" Text="ARA" />
            &nbsp; &nbsp; &nbsp;
            <asp:HyperLink ID="Ayarlar" runat="server" Enabled="False">Arama Ayarları</asp:HyperLink><br />
            <br />
     </center>

         <asp:Label ID="detay" runat="server" Text="Label" BackColor="Transparent" Width="100%"></asp:Label>
      </div>
       
        <div
            id="DIV1" style="width: 50%; height: 389px; left: 255px; position: absolute; top: 131px;">
<asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink><br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" BorderColor="Green" ForeColor="Green" Text="Label"></asp:Label><br />
            <br />
            <asp:HyperLink ID="HyperLink2" runat="server">HyperLink</asp:HyperLink><br />
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label4" runat="server" BorderColor="Green" ForeColor="Green" Text="Label"></asp:Label><br />
            <br />
            <asp:HyperLink ID="HyperLink3" runat="server">HyperLink</asp:HyperLink><br />
            <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label6" runat="server" BorderColor="Green" ForeColor="Green" Text="Label"></asp:Label><br />
            <br />
            <asp:HyperLink ID="HyperLink4" runat="server">HyperLink</asp:HyperLink><br />
            <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label8" runat="server" BorderColor="Green" ForeColor="Green" Text="Label"></asp:Label><br />
            <br />
            <asp:HyperLink ID="HyperLink5" runat="server">HyperLink</asp:HyperLink><br />
            <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label10" runat="server" BorderColor="Green" ForeColor="Green" Text="Label"></asp:Label><br />
            <br />
            &nbsp; &nbsp;<asp:ImageButton ID="geri" runat="server" ImageUrl="geri.png" />
            &nbsp; &nbsp;
            <asp:Button ID="Button1" runat="server" Text="Şu Sayfaya Git" />
            <asp:TextBox ID="syf" runat="server" Width="54px"></asp:TextBox>
            &nbsp; &nbsp; &nbsp; &nbsp;<asp:ImageButton ID="ileri" runat="server" ImageUrl="ileri.png" /></div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        &nbsp;
</form>
</body>
</html>
