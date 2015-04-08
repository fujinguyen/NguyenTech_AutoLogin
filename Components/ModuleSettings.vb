

Public Class ModuleSettingInfo
    '---------------------------------------------------------------------
    ' TODO Declare BLL Class Info fields and property accessors
    ' You can use CodeSmith templates to generate this code
    '---------------------------------------------------------------------

#Region "Private Members"
    Private _IsModuleInit As String
    'SelectLoginRole
    Private _SelectLoginRole As String
    'DefaultLoginAccount
    Private _DefaultLoginAccount As String
    Private _AutoLoginDefaultEnable As String
    Private _ForceLoginDefaultEnable As String
    Private _AccountSwitchEnable As String
    Private _IsModuleVisible As String
    Private _UrlLoginEnable As String
    Private _IPRestrictionMode As String
    Private _IPAddressList As String
    Private _IPRestrictionEnable As String
    Private _IPDisplayEnable As String
    Private _SetupNote As String
    Private _LastUpdateBy As String
    Private _LastUpdateDate As String

#End Region

    Public Enum SettingParameter
        IsModuleInit
        SelectLoginRole
        DefaultLoginAccount
        AutoLoginDefaultEnable
        ForceLoginDefaultEnable
        IsModuleVisible
        AccountSwitchEnable
        UrlLoginEnable
        IPRestrictionMode
        IPAddressList
        IPRestrictionEnable
        IPDisplayEnable
        SetupNote
        LastUpdateBy
        LastUpdateDate
    End Enum


#Region "Constructors"
    Public Sub New()
    End Sub

    Public Sub New(ByVal TabModuleId As Integer)

        Dim objModules As New DotNetNuke.Entities.Modules.ModuleController
        Dim Settings As Hashtable = objModules.GetTabModuleSettings(TabModuleId)

        _IsModuleInit = CType(Settings(SettingParameter.IsModuleInit.ToString), String)
        _SelectLoginRole = CType(Settings(SettingParameter.SelectLoginRole.ToString), String)
        _DefaultLoginAccount = CType(Settings(SettingParameter.DefaultLoginAccount.ToString), String)
        _AutoLoginDefaultEnable = CType(Settings(SettingParameter.AutoLoginDefaultEnable.ToString), String)
        _ForceLoginDefaultEnable = CType(Settings(SettingParameter.ForceLoginDefaultEnable.ToString), String)
        _AccountSwitchEnable = CType(Settings(SettingParameter.AccountSwitchEnable.ToString), String)
        _IsModuleVisible = CType(Settings(SettingParameter.IsModuleVisible.ToString), String)
        _UrlLoginEnable = CType(Settings(SettingParameter.UrlLoginEnable.ToString), String)
        _IPRestrictionMode = CType(Settings(SettingParameter.IPRestrictionMode.ToString), String)
        _IPAddressList = CType(Settings(SettingParameter.IPAddressList.ToString), String)
        _IPRestrictionEnable = CType(Settings(SettingParameter.IPRestrictionEnable.ToString), String)
        _IPDisplayEnable = CType(Settings(SettingParameter.IPDisplayEnable.ToString), String)
        _SetupNote = CType(Settings(SettingParameter.SetupNote.ToString), String)
        _LastUpdateBy = CType(Settings(SettingParameter.LastUpdateBy.ToString), String)
        _LastUpdateDate = CType(Settings(SettingParameter.LastUpdateDate.ToString), String)


    End Sub
    Public Sub SaveSettings(ByVal TabModuleId As Integer)

        Dim objModules As New DotNetNuke.Entities.Modules.ModuleController
        objModules.UpdateTabModuleSetting(TabModuleId, SettingParameter.IsModuleInit.ToString, IsModuleInit.ToString)


        'SelectLoginRole
        objModules.UpdateTabModuleSetting(TabModuleId, SettingParameter.SelectLoginRole.ToString, SelectLoginRole.ToString)
        'DefaultLoginAccount
        objModules.UpdateTabModuleSetting(TabModuleId, SettingParameter.DefaultLoginAccount.ToString, DefaultLoginAccount.ToString)
        'AutoLoginDefaultEnable
        objModules.UpdateTabModuleSetting(TabModuleId, SettingParameter.AutoLoginDefaultEnable.ToString, AutoLoginDefaultEnable.ToString)
        'ForceLoginDefaultEnable
        objModules.UpdateTabModuleSetting(TabModuleId, SettingParameter.ForceLoginDefaultEnable.ToString, ForceLoginDefaultEnable.ToString)
        'AccountSwitchEnable
        objModules.UpdateTabModuleSetting(TabModuleId, SettingParameter.AccountSwitchEnable.ToString, AccountSwitchEnable.ToString)
        'IsModuleVisible
        objModules.UpdateTabModuleSetting(TabModuleId, SettingParameter.IsModuleVisible.ToString, IsModuleVisible.ToString)
        'UrlLoginEnable
        objModules.UpdateTabModuleSetting(TabModuleId, SettingParameter.UrlLoginEnable.ToString, UrlLoginEnable.ToString)
        'IPRestrictionMode
        objModules.UpdateTabModuleSetting(TabModuleId, SettingParameter.IPRestrictionMode.ToString, IPRestrictionMode.ToString)
        'IPAddressList
        objModules.UpdateTabModuleSetting(TabModuleId, SettingParameter.IPAddressList.ToString, IPAddressList.ToString)
        'IPRestrictionEnable
        objModules.UpdateTabModuleSetting(TabModuleId, SettingParameter.IPRestrictionEnable.ToString, IPRestrictionEnable.ToString)
        'IPDisplayEnable
        objModules.UpdateTabModuleSetting(TabModuleId, SettingParameter.IPDisplayEnable.ToString, IPDisplayEnable.ToString)

        'SetupNote
        objModules.UpdateTabModuleSetting(TabModuleId, SettingParameter.SetupNote.ToString, SetupNote.ToString)
        'LastUpdateBy
        objModules.UpdateTabModuleSetting(TabModuleId, SettingParameter.LastUpdateBy.ToString, LastUpdateBy.ToString)
        'LastUpdateDate
        objModules.UpdateTabModuleSetting(TabModuleId, SettingParameter.LastUpdateDate.ToString, LastUpdateDate.ToString)
    End Sub

#End Region

#Region "Public Properties"
    Public Property IsModuleInit() As Boolean
        Get
            If String.IsNullOrEmpty(_IsModuleInit) Then
                Return False
            Else
                Return _IsModuleInit
            End If
        End Get
        Set(ByVal Value As Boolean)
            _IsModuleInit = Value
        End Set
    End Property

    Public Property SelectLoginRole() As String
        Get
            Return _SelectLoginRole
        End Get
        Set(ByVal Value As String)
            _SelectLoginRole = Value
        End Set
    End Property

    Public Property DefaultLoginAccount() As String
        Get
            Return _DefaultLoginAccount
        End Get
        Set(ByVal Value As String)
            _DefaultLoginAccount = Value
        End Set
    End Property

    Public Property AutoLoginDefaultEnable() As Boolean
        Get
            If String.IsNullOrEmpty(_AutoLoginDefaultEnable) Then
                Return True
            Else
                Return _AutoLoginDefaultEnable
            End If
        End Get
        Set(ByVal Value As Boolean)
            _AutoLoginDefaultEnable = Value
        End Set
    End Property
    Public Property ForceLoginDefaultEnable() As Boolean
        Get
            If String.IsNullOrEmpty(_ForceLoginDefaultEnable) Then
                Return False
            Else
                Return _ForceLoginDefaultEnable
            End If
        End Get
        Set(ByVal Value As Boolean)
            _ForceLoginDefaultEnable = Value
        End Set
    End Property
    Public Property IsModuleVisible() As Boolean
        Get
            If String.IsNullOrEmpty(_IsModuleVisible) Then
                Return True
            Else
                Return _IsModuleVisible
            End If
        End Get
        Set(ByVal Value As Boolean)
            _IsModuleVisible = Value
        End Set
    End Property


    Public Property AccountSwitchEnable() As Boolean
        Get
            If String.IsNullOrEmpty(_AccountSwitchEnable) Then
                Return True
            Else
                Return _AccountSwitchEnable
            End If
        End Get
        Set(ByVal Value As Boolean)
            _AccountSwitchEnable = Value
        End Set
    End Property

    Public Property UrlLoginEnable() As Boolean
        Get
            If String.IsNullOrEmpty(_UrlLoginEnable) Then
                Return False
            Else
                Return _UrlLoginEnable
            End If
        End Get
        Set(ByVal Value As Boolean)
            _UrlLoginEnable = Value
        End Set
    End Property

    Public Property IPRestrictionMode() As String
        Get
            If String.IsNullOrEmpty(_IPRestrictionMode) Then
                Return "Allowed"
            Else
                Return _IPRestrictionMode
            End If
        End Get
        Set(ByVal Value As String)
            _IPRestrictionMode = Value
        End Set
    End Property

    Public Property IPAddressList() As String
        Get
            Return _IPAddressList
        End Get
        Set(ByVal Value As String)
            _IPAddressList = Value
        End Set
    End Property

    Public Property IPRestrictionEnable() As Boolean
        Get
            If String.IsNullOrEmpty(_IPRestrictionEnable) Then
                Return False
            Else
                Return _IPRestrictionEnable
            End If
        End Get
        Set(ByVal Value As Boolean)
            _IPRestrictionEnable = Value
        End Set
    End Property
    Public Property IPDisplayEnable() As Boolean
        Get
            If String.IsNullOrEmpty(_IPDisplayEnable) Then
                Return False
            Else
                Return _IPDisplayEnable
            End If
        End Get
        Set(ByVal Value As Boolean)
            _IPDisplayEnable = Value
        End Set
    End Property
    Public Property SetupNote() As String
        Get

            Return _SetupNote
        End Get
        Set(ByVal Value As String)
            _SetupNote = Value
        End Set
    End Property


    Public Property LastUpdateBy() As String
        Get
            Return _LastUpdateBy
        End Get
        Set(ByVal Value As String)
            _LastUpdateBy = Value
        End Set
    End Property

    Public Property LastUpdateDate() As String
        Get
            Return _LastUpdateDate
        End Get
        Set(ByVal Value As String)
            _LastUpdateDate = Value
        End Set
    End Property

#End Region

End Class

