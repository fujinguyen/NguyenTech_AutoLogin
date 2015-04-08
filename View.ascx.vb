'
' Work Control LLC - http://www.nguyentech.com
' Copyright (c) 2008
'
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
' DEALINGS IN THE SOFTWARE.
'
Imports DotNetNuke
Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection



''' -----------------------------------------------------------------------------
''' <summary>
''' The ViewDynamicModule class displays the content
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' </history>
''' -----------------------------------------------------------------------------
Partial Class View
    Inherits AutoLoginModuleBase

#Region "Private Members"

    Private _TabModuleSettingInfo As ModuleSettingInfo
    Private _LoginAccount As String

#End Region


    Protected Property TabModuleSettingInfo() As ModuleSettingInfo
        Get
            If _TabModuleSettingInfo Is Nothing Then
                _TabModuleSettingInfo = New ModuleSettingInfo(TabModuleId)
            End If
            Return _TabModuleSettingInfo
        End Get
        Set(ByVal Value As ModuleSettingInfo)
            _TabModuleSettingInfo = Value
        End Set
    End Property

    Public Property LoginAccount() As String
        Get
            Return _LoginAccount
        End Get
        Set(ByVal Value As String)
            _LoginAccount = Value
        End Set
    End Property


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' AddLocalizedModuleMessage adds a localized module message
    ''' </summary>
    ''' <param name="message">The localized message</param>
    ''' <param name="type">The type of message</param>
    ''' <param name="display">A flag that determines whether the message should be displayed</param>
    ''' <history>
    ''' 	[cnurse]	03/13/2006
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub AddLocalizedModuleMessage(ByVal message As String, ByVal type As DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType)

        DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, message, type)

    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' AddModuleMessage adds a module message
    ''' </summary>
    ''' <param name="message">The message</param>
    ''' <param name="type">The type of message</param>
    ''' <param name="display">A flag that determines whether the message should be displayed</param>
    ''' <history>
    ''' 	[cnurse]	03/13/2006
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub AddModuleMessage(ByVal message As String, ByVal type As DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType)

        AddLocalizedModuleMessage(Localization.GetString(message, LocalResourceFile), type)

    End Sub

#Region "Event Handlers"



    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Page_Load runs when the control is loaded
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not Page.IsPostBack Then

                If Utility.IsModuleOnHomepage() Then
                    'prevent autologin if module is place on Home page
                    AddModuleMessage("IsModuleOnHome", DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
                    Exit Sub
                End If

                lblIPAddress.Text = Utility.GetIP4Address

                'Dim IsAdmin As Boolean = Utility.HasAdminPermissions(ModuleConfiguration)
                Dim objUserInfo As UserInfo
                Dim UrlUsername As String = String.Empty

                Dim IsMatchedIP As Boolean = False
                Dim IsViolatedIP As Boolean = False



                Dim IsValidLogin As Boolean = False
                'show warning if the module setting has not been setup
                If Not TabModuleSettingInfo.IsModuleInit Then
                    AddModuleMessage("IsModuleInit", DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
                    Exit Sub
                End If

                If TabModuleSettingInfo.IPRestrictionEnable Then
                    If Not String.IsNullOrEmpty(TabModuleSettingInfo.IPAddressList) Then
                        IsMatchedIP = Utility.IsIPMatch(TabModuleId)
                        If TabModuleSettingInfo.IPRestrictionMode = "Allowed" Then
                            IsViolatedIP = Not IsMatchedIP
                        Else 'Denied
                            IsViolatedIP = IsMatchedIP
                        End If

                        If IsViolatedIP Then
                            AddModuleMessage("ViolateIPRestriction", DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
                            pnlAutoLogin.Visible = False
                            Exit Sub
                        End If

                    End If

                End If
                'check valid defaul user
                objUserInfo = UserController.GetUserByName(PortalId, TabModuleSettingInfo.DefaultLoginAccount, False)

                If objUserInfo Is Nothing Then
                    AddModuleMessage("DefaultUserDoesNotExist", DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
                    Exit Sub
                Else 'error account not in portal
                    'check user in authorize role
                    If Not objUserInfo.IsInRole(TabModuleSettingInfo.SelectLoginRole) Then
                        AddModuleMessage("DefaultUserIsNotInAuthorizeRole", DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
                        Exit Sub
                    End If
                End If


                'Check URL username
                If TabModuleSettingInfo.UrlLoginEnable Then

                    If Not (Request.QueryString("username") Is Nothing) Then
                        UrlUsername = Request.QueryString("username")

                        'check account in authorize role
                        objUserInfo = UserController.GetUserByName(PortalId, UrlUsername, False)

                        If Not objUserInfo Is Nothing Then
                            'check user in authorize role
                            If Not objUserInfo.IsInRole(TabModuleSettingInfo.SelectLoginRole) Then
                                AddModuleMessage("UrlUserIsNotInAuthorizeRole", DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
                                Exit Sub
                            End If
                        Else 'error account not in portal
                            AddModuleMessage("UrlUserIsNotExist", DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
                            Exit Sub
                        End If
                    End If
                End If



                'Load user
                Dim strSelectText As String = DotNetNuke.Services.Localization.Localization.GetString("SelectUser", Me.LocalResourceFile)
                Utility.LoadRoleUsers(cboUsername, PortalId, TabModuleSettingInfo.SelectLoginRole, strSelectText)
                'check authorize role has users
                If cboUsername.Items.Count < 1 Then
                    AddModuleMessage("AuthorizedRoleHasNoUser", DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
                    Exit Sub
                End If

                If Me.Request.IsAuthenticated Then
                    'Set login to select value
                    Utility.SelectItemByValue(cboUsername, UserInfo.Username)

                End If


                'Decide what login account to user
                LoginAccount = Utility.SetLoginAccount(PortalId, TabModuleId, UrlUsername, Me.Request.IsAuthenticated, Me.ModuleConfiguration)

                'exit sub if login account is same as intent login account
                If Me.Request.IsAuthenticated Then
                    If TabModuleSettingInfo.DefaultLoginAccount = Me.UserInfo.Username Then
                        Exit Sub
                    End If
                End If


                If Not (LoginAccount = String.Empty) Then
                    If Me.Request.IsAuthenticated Then
                        If LoginAccount <> UserInfo.Username Then
                            IsValidLogin = True
                        End If
                    Else
                        IsValidLogin = True
                    End If
                End If


                If TabModuleSettingInfo.IPRestrictionEnable Then
                    If Utility.IsIPMatch(TabModuleId) Then
                        If TabModuleSettingInfo.IPRestrictionMode = "Allowed" Then
                            IsValidLogin = True
                        Else
                            IsValidLogin = False
                        End If
                    Else
                        IsValidLogin = False
                    End If

                End If


                If IsValidLogin Then
                    LoginUsername(LoginAccount)
                End If


            End If
        Catch exc As Exception        'Module failed to load
            ProcessModuleLoadException(Me, exc)
        End Try
    End Sub


    ''' <summary>
    ''' performs logon for the selected user
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub cboUsername_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUsername.SelectedIndexChanged
        If (cboUsername.SelectedValue <> Me.UserInfo.Username) Then

            LoginUsername(cboUsername.SelectedValue)
        End If

    End Sub
    Protected Sub LoginUsername(ByVal Username As String)
        Dim objUserInfo As UserInfo = UserController.GetUserByName(PortalId, Username, False)
        If Not objUserInfo Is Nothing Then
            'Remove user from cache
            If Page.User IsNot Nothing Then
                DataCache.ClearUserCache(Me.PortalSettings.PortalId, Context.User.Identity.Name)
            End If

            ' sign current user out
            Dim objPortalSecurity As New PortalSecurity
            objPortalSecurity.SignOut()

            ' sign new user in
            UserController.UserLogin(PortalId, objUserInfo, PortalSettings.PortalName, Request.UserHostAddress, False)

            ' redirect to current url
            Dim ReturnUrl As String = HttpContext.Current.Request.RawUrl
            If ReturnUrl.IndexOf("?username=") <> -1 Then
                ReturnUrl = ReturnUrl.Substring(0, ReturnUrl.IndexOf("?username="))
                Response.Redirect(ReturnUrl, True)
            Else
                Response.Redirect(NavigateURL, True)
            End If

        End If

    End Sub
#End Region


    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender

        'Set container visibility
        If Me.Request.IsAuthenticated Then
            If Not TabModuleSettingInfo.IsModuleVisible Then
                Dim IsAdmin As Boolean = Utility.HasAdminPermissions(Me.ModuleConfiguration)
                If Not IsAdmin Then
                    Me.Visible = False
                    Me.ContainerControl.Visible = False
                End If
            End If
        End If

        Dim IsEnabled As Boolean = True
        If Me.Request.IsAuthenticated Then
            If TabModuleSettingInfo.DefaultLoginAccount = Me.UserInfo.Username And TabModuleSettingInfo.ForceLoginDefaultEnable Then
                IsEnabled = False
            End If

            IsEnabled = TabModuleSettingInfo.AccountSwitchEnable
        End If

        cboUsername.Enabled = IsEnabled

        pnlShowIP.Visible = TabModuleSettingInfo.IPDisplayEnable
    End Sub

End Class


