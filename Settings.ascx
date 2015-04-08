<%@ Control Language="vb" AutoEventWireup="false" Inherits="NguyenTech.Modules.AutoLogin.Settings" Codebehind="Settings.ascx.vb" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<asp:panel id="pnlAccountSettings" runat="server" Visible="True" GroupingText="Auto Login Accounts" Width="100%" CssClass="ControlPanel">

<table cellspacing="0" cellpadding="2" border="0" summary="AutoLogin Settings Design Table">
    <tr>
        <td class="SubHead" width="160">
            <dnn:Label ID="plRolename" runat="server" ControlName="cboRolename" Suffix=":"></dnn:Label>
        </td>
        <td width="365">
            <asp:DropDownList ID="cboRolename" runat="server" CssClass="NormalTextBox" AutoPostBack="true">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvRolename" runat="server" ControlToValidate="cboRolename"
                ErrorMessage="Required Field" resourcekey="rfvRolename" CssClass="NormalRed"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="SubHead" width="160">
            <dnn:Label ID="plDefaultUsername" runat="server" Suffix=":" ControlName="cboUsername">
            </dnn:Label>
        </td>
        <td>
            <asp:DropDownList ID="cboUsername" runat="server">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="cboUsername"
                ErrorMessage="Required Field" resourcekey="rfvUsername" CssClass="NormalRed"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="SubHead" width="150">
            <dnn:Label ID="plAutoLoginDefaultEnable" runat="server" ControlName="chkAutoLoginDefaultEnable"
                Suffix=":"></dnn:Label>
        </td>
        <td>
            <asp:CheckBox ID="chkAutoLoginDefaultEnable" runat="server"></asp:CheckBox>
        </td>
    </tr>
    <tr>
        <td class="SubHead" width="150">
            <dnn:Label ID="plAccountSwitchEnable" runat="server" ControlName="chkAccountSwitchEnable"
                Suffix=":"></dnn:Label>
        </td>
        <td>
            <asp:CheckBox ID="chkAccountSwitchEnable" runat="server"></asp:CheckBox>
        </td>
    </tr>
    <tr>
        <td class="SubHead" width="150">
            <dnn:Label ID="plForceLoginDefaultEnable" runat="server" ControlName="chkForceLoginDefaultEnable"
                Suffix=":"></dnn:Label>
        </td>
        <td>
            <asp:CheckBox ID="chkForceLoginDefaultEnable" runat="server"></asp:CheckBox>
        </td>
    </tr>    
</table>    
</asp:panel>    
<br />
<asp:panel id="pnlUrlLogin" runat="server" Visible="True" GroupingText="URL Login" Width="100%" CssClass="ControlPanel">
<table cellspacing="0" cellpadding="2" border="0" summary="AutoLogin Settings Design Table">

    <tr>
        <td class="SubHead" width="150">
            <dnn:Label ID="plUrlLoginEnable" runat="server" ControlName="chkUrlLoginEnable"
                Suffix=":"></dnn:Label>
        </td>
        <td>
            <asp:CheckBox ID="chkUrlLoginEnable" runat="server"></asp:CheckBox>
        </td>
    </tr>
</table>   
</asp:panel>    
<br />

<asp:panel id="pnlVisibility" runat="server" Visible="True" GroupingText="Visibility" Width="100%" CssClass="ControlPanel">
<table cellspacing="0" cellpadding="2" border="0" summary="AutoLogin Settings Design Table">
    <tr>
        <td class="SubHead" width="150">
            <dnn:Label ID="plIsModuleVisible" runat="server" ControlName="chkIsModuleVisible"
                Suffix=":"></dnn:Label>
        </td>
        <td>
            <asp:CheckBox ID="chkIsModuleVisible" runat="server"></asp:CheckBox>
        </td>
    </tr>
</table>    
</asp:panel>    
<br />

<asp:panel id="pnlControlAccessByIP" runat="server" Visible="True" GroupingText="Control Access By IP" Width="100%" CssClass="ControlPanel">

<table cellspacing="0" cellpadding="2" border="0" summary="AutoLogin Settings Design Table">
    <tr>
        <td class="SubHead" width="150">
            <dnn:Label ID="plIPRestrictionMode" runat="server" ControlName="cboIPRestrictionMode"
                Suffix=":"></dnn:Label>
        </td>
        <td>
				<asp:dropdownlist id="cboIPRestrictionMode" AutoPostBack="True" Runat="server">
					<asp:ListItem Value="Allowed" ResourceKey="IPRestrictionModeAllowed">Allowed</asp:ListItem>
					<asp:ListItem Value="Denied" ResourceKey="IPRestrictionModeDenied">Denied</asp:ListItem>
				</asp:dropdownlist>
        </td>
    </tr>     
    <tr>
        <td class="SubHead" width="150">
            <dnn:Label ID="plIPAddressList" runat="server" ControlName="txtIPAddressList" Suffix=":">
            </dnn:Label>
        </td>
        <td valign="bottom">
            <asp:TextBox ID="txtIPAddressList" CssClass="NormalTextBox" Columns="50"
                TextMode="MultiLine" Rows="10" MaxLength="2000" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="SubHead" width="150">
            <dnn:Label ID="plIPRestrictionEnable" runat="server" ControlName="chkIPRestrictionEnable"
                Suffix=":"></dnn:Label>
        </td>
        <td>
            <asp:CheckBox ID="chkIPRestrictionEnable" runat="server"></asp:CheckBox>
        </td>
    </tr>     
    <tr>
        <td class="SubHead" width="150">
            <dnn:Label ID="plIPDisplayEnable" runat="server" ControlName="chkIPDisplayEnable"
                Suffix=":"></dnn:Label>
        </td>
        <td>
            <asp:CheckBox ID="chkIPDisplayEnable" runat="server"></asp:CheckBox>
        </td>
    </tr> 
</table>
</asp:panel>    
<br />

<asp:panel id="pnlRecordKeeping" runat="server" Visible="True" GroupingText="Record Keeping" Width="100%" CssClass="ControlPanel">
<table cellspacing="0" cellpadding="2" border="0" summary="AutoLogin Settings Design Table">
    <tr>
        <td class="SubHead" width="150">
            <dnn:Label ID="lblSetupNote" runat="server" ControlName="txtSetupNote" Suffix=":">
            </dnn:Label>
        </td>
        <td valign="bottom">
            <asp:TextBox ID="txtSetupNote" CssClass="NormalTextBox" Columns="50"
                TextMode="MultiLine" Rows="10" MaxLength="2000" runat="server" />
        </td>
    </tr>

    <tr>
        <td class="SubHead" width="150">
            <dnn:Label ID="lblLastUpdate" runat="server" ControlName="lblLastUpdateDisplay" Suffix=":">
            </dnn:Label>
        </td>
        <td valign="bottom">
            <asp:Label ID="lblLastUpdateDisplay" CssClass="Normal" runat="server" />
        </td>
    </tr>
</table>
</asp:panel>  