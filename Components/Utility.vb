Imports DotNetNuke
Imports System.Text
Imports System.Web
Imports DotNetNuke.Entities.Portals
Imports System.Security.Cryptography
Imports System.IO
Imports System.Net



Public Class Utility

    Public Shared Sub LoadRoles(ByRef cboControl As DropDownList, ByVal PortalID As Integer, ByVal DefaulText As String)

        Dim objRoleCtrl As New DotNetNuke.Security.Roles.RoleController

        With cboControl
            .DataSource = objRoleCtrl.GetPortalRoles(PortalID)
            .DataTextField = "RoleName"
            .DataValueField = "RoleName"
            .DataBind()
            .Items.Insert(0, New ListItem(DefaulText, Null.NullString.ToString))
        End With
    End Sub
    Public Shared Sub LoadRoleUsers(ByRef cboControl As DropDownList, ByVal PortalID As Integer, ByVal Rolename As String, ByVal DefaulText As String)
        Dim objRoleCtrl As New DotNetNuke.Security.Roles.RoleController

        With cboControl
            .DataSource = objRoleCtrl.GetUsersByRoleName(PortalID, Rolename)
            .DataTextField = "UserName"
            .DataValueField = "UserName"
            .DataBind()
            .Items.Insert(0, New ListItem(DefaulText, Null.NullString.ToString))
        End With

    End Sub

    Public Shared Function UsernameExistsInPortal(ByVal PortalID As Integer, ByVal Username As String) As Boolean
        Try
            Dim objUser As UserInfo = UserController.GetUserByName(PortalID, Username)

            If objUser Is Nothing Then
                Return False
            Else
                Return True
            End If

        Catch exc As Exception
            Return False
        End Try
    End Function

    Public Shared Function HasAdminPermissions(ByVal ModuleConfiguration As DotNetNuke.Entities.Modules.ModuleInfo) As Boolean
        Dim PortalSettings As Entities.Portals.PortalSettings = PortalController.GetCurrentPortalSettings
        Dim isAdmin As Boolean = DotNetNuke.Security.PortalSecurity.IsInRole(PortalSettings.AdministratorRoleName.ToString)
        If isAdmin OrElse DotNetNuke.Security.PortalSecurity.HasNecessaryPermission(DotNetNuke.Security.SecurityAccessLevel.Host, PortalSettings, ModuleConfiguration) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function SetLoginAccount(ByVal PortalID As Integer, ByVal TabModuleID As Integer, ByVal UrlUsername As String, ByVal IsAuthenticated As Boolean, ByVal ModuleConfiguration As DotNetNuke.Entities.Modules.ModuleInfo) As String
        Dim TabModuleSettingInfo As ModuleSettingInfo = New ModuleSettingInfo(TabModuleID)
        Dim objLoginUserInfo As UserInfo = UserController.GetCurrentUserInfo
        Dim IsAdmin As Boolean = Utility.HasAdminPermissions(ModuleConfiguration)
        Dim LoginAccount As String = String.Empty

        If IsAuthenticated Then
            'process force login using defaul user
            If TabModuleSettingInfo.ForceLoginDefaultEnable Then
                If Not IsAdmin Then
                    LoginAccount = TabModuleSettingInfo.DefaultLoginAccount
                End If
            End If
        Else
            'set default user
            If TabModuleSettingInfo.AutoLoginDefaultEnable Then
                If Not String.IsNullOrEmpty(TabModuleSettingInfo.DefaultLoginAccount) Then
                    LoginAccount = TabModuleSettingInfo.DefaultLoginAccount
                End If
            End If
        End If

        'set to URL user name
        If TabModuleSettingInfo.UrlLoginEnable And Not UrlUsername = String.Empty Then
            LoginAccount = UrlUsername
        End If

        Return LoginAccount
    End Function

    Public Shared Function IsModuleOnHomepage()
        'Prevent login if AutoLogin module is on the same page as home
        Dim intDefaultTabID As Integer = Null.NullInteger
        Dim PortalSettings As Entities.Portals.PortalSettings = PortalController.GetCurrentPortalSettings
        If PortalSettings.HomeTabId = intDefaultTabID Then
            Dim objTabs As DotNetNuke.Entities.Tabs.TabController = New DotNetNuke.Entities.Tabs.TabController()
            Dim objTab As DotNetNuke.Entities.Tabs.TabInfo = CType(objTabs.GetAllTabs()(0), DotNetNuke.Entities.Tabs.TabInfo)
            intDefaultTabID = objTab.TabID

        Else
            'set to homepage 
            intDefaultTabID = PortalSettings.HomeTabId
        End If
        If PortalSettings.ActiveTab.TabID = intDefaultTabID Then
            'prevent autologin if module is place on Home page
            Return True
        Else
            Return False
        End If

    End Function

    Public Shared Sub SelectItemByValue(ByRef cboName As DropDownList, ByVal FindValue As String)
        'Load role check list

        Dim liItem As ListItem

        liItem = cboName.Items.FindByValue(FindValue)

        If liItem IsNot Nothing Then
            cboName.ClearSelection()
            liItem.Selected = True
        End If
    End Sub

    Public Shared Function IsIPMatch(ByVal TabModuleID As Integer) As Boolean
        Dim TabModuleSettingInfo As ModuleSettingInfo = New ModuleSettingInfo(TabModuleID)
        Dim IPAddress As String = GetIP4Address()
        If Not String.IsNullOrEmpty(TabModuleSettingInfo.IPAddressList) Then
            'Dim context As HttpContext = HttpContext.Current
            'Dim objUserInfo As UserInfo = UserController.GetCurrentUserInfo
            Dim ipPattern As String

            For Each ipPattern In TabModuleSettingInfo.IPAddressList.Split(New Char() {";"c})
                If IPAddress.IndexOf(ipPattern, 0) <> -1 Then
                    Return True
                End If
            Next ipPattern

        End If

        Return False

    End Function
    'Public Shared Function GetIPAddress() As String
    '    Dim _IPAddress As String = Null.NullString
    '    If Not HttpContext.Current.Request.UserHostAddress Is Nothing Then
    '        _IPAddress = HttpContext.Current.Request.UserHostAddress
    '    End If
    '    Return _IPAddress
    'End Function
    Public Shared Function GetIP4Address() As String
        Dim IP4Address As String = String.Empty

        For Each IPA As IPAddress In Dns.GetHostAddresses(HttpContext.Current.Request.UserHostAddress)
            If IPA.AddressFamily.ToString() = "InterNetwork" Then
                IP4Address = IPA.ToString()
                Exit For
            End If
        Next

        If IP4Address <> String.Empty Then
            Return IP4Address
        End If

        For Each IPA As IPAddress In Dns.GetHostAddresses(Dns.GetHostName())
            If IPA.AddressFamily.ToString() = "InterNetwork" Then
                IP4Address = IPA.ToString()
                Exit For
            End If
        Next

        Return IP4Address
    End Function
End Class

