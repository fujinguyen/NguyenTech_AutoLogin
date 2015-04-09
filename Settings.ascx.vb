'
' Nguyen Tech LLC - http://www.nguyentech.com
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



''' -----------------------------------------------------------------------------
''' <summary>
''' The Settings class manages Module Settings
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' </history>
''' -----------------------------------------------------------------------------
Partial Class Settings
    Inherits AutoLoginSettingsBase

#Region "Base Method Implementations"

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' LoadSettings loads the settings from the Database and displays them
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Overrides Sub LoadSettings()
        Try
            If (Page.IsPostBack = False) Then
                Dim objModuleSettingInfo As New ModuleSettingInfo(TabModuleId)

                'Load role
                Dim strSelectText As String = String.Empty
                strSelectText = DotNetNuke.Services.Localization.Localization.GetString("SelectRole", Me.LocalResourceFile)
                Utility.LoadRoles(cboRolename, PortalId, strSelectText)

                'Update field with data from tablmodule settings
                With objModuleSettingInfo
                    Utility.SelectItemByValue(cboRolename, .SelectLoginRole)
                    'Load user
                    strSelectText = DotNetNuke.Services.Localization.Localization.GetString("SelectUser", Me.LocalResourceFile)
                    Utility.LoadRoleUsers(cboUsername, PortalId, cboRolename.SelectedValue, strSelectText)
                    Utility.SelectItemByValue(cboUsername, .DefaultLoginAccount)

                    chkAutoLoginDefaultEnable.Checked = .AutoLoginDefaultEnable
                    chkForceLoginDefaultEnable.Checked = .ForceLoginDefaultEnable
                    chkAccountSwitchEnable.Checked = .AccountSwitchEnable
                    chkIsModuleVisible.Checked = .IsModuleVisible
                    chkUrlLoginEnable.Checked = .UrlLoginEnable
                    txtIPAddressList.Text = .IPAddressList

                    Utility.SelectItemByValue(cboIPRestrictionMode, .IPRestrictionMode)

                    chkIPRestrictionEnable.Checked = .IPRestrictionEnable
                    chkIPDisplayEnable.Checked = .IPDisplayEnable
                    txtSetupNote.Text = .SetupNote
                    lblLastUpdateDisplay.Text = .LastUpdateBy & ";" & .LastUpdateDate
                End With

            End If
        Catch exc As Exception           'Module failed to load
            ProcessModuleLoadException(Me, exc)
        End Try
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' UpdateSettings saves the modified settings to the Database
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Overrides Sub UpdateSettings()
        Try


            Dim objModuleSettingInfo As New ModuleSettingInfo(TabModuleId)
            objModuleSettingInfo.IsModuleInit = True

            With objModuleSettingInfo
                .SelectLoginRole = cboRolename.SelectedValue
                .DefaultLoginAccount = cboUsername.SelectedValue
                .AutoLoginDefaultEnable = chkAutoLoginDefaultEnable.Checked
                .ForceLoginDefaultEnable = chkForceLoginDefaultEnable.Checked
                .AccountSwitchEnable = chkAccountSwitchEnable.Checked
                .IsModuleVisible = chkIsModuleVisible.Checked
                .UrlLoginEnable = chkUrlLoginEnable.Checked
                .IPAddressList = txtIPAddressList.Text
                .IPRestrictionMode = cboIPRestrictionMode.SelectedValue
                .IPRestrictionEnable = chkIPRestrictionEnable.Checked
                .IPDisplayEnable = chkIPDisplayEnable.Checked

                .SetupNote = txtSetupNote.Text
                .LastUpdateBy = UserInfo.Username
                .LastUpdateDate = DateTime.Now.ToString
            End With

            objModuleSettingInfo.SaveSettings(TabModuleId)
        Catch exc As Exception           'Module failed to load
            ProcessModuleLoadException(Me, exc)
        End Try
    End Sub

#End Region

    Protected Sub cboRolename_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRolename.SelectedIndexChanged
        Dim strSelectText As String = String.Empty
        strSelectText = DotNetNuke.Services.Localization.Localization.GetString("SelectUser", Me.LocalResourceFile)
        Utility.LoadRoleUsers(cboUsername, PortalId, cboRolename.SelectedValue, strSelectText)
    End Sub
End Class



