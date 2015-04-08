<%@ Control Language="vb" Inherits="NguyenTech.Modules.AutoLogin.View" AutoEventWireup="false" Explicit="True" CodeBehind="View.ascx.vb" %>

<asp:Panel ID="pnlAutoLogin" runat="server" Visible="true">


    <div class="dnnForm dnnLoginService dnnClear">
        <div class="dnnFormItem">
            <div class="dnnLabel">
                <asp:Label ID="lblLoginAs" runat="server" Text="Login As" resourcekey="lblLoginAs" CssClass="dnnFormLabel"></asp:Label>
            </div>
            <asp:DropDownList ID="cboUsername" runat="server" AutoPostBack="True"></asp:DropDownList>
        </div>

</asp:Panel>

<asp:Panel ID="pnlShowIP" runat="server" Visible="true">
    <div class="dnnForm dnnLoginService dnnClear">
        <div class="dnnFormItem">
            <div class="dnnLabel">
                <asp:Label ID="lblIP" runat="server" CssClass="subhead" Text="IP:" resourcekey="lblIP"></asp:Label>
            </div>
                <asp:Label ID="lblIPAddress" runat="server" CssClass="normal"></asp:Label>
        </div>

    </div>
</asp:Panel>

