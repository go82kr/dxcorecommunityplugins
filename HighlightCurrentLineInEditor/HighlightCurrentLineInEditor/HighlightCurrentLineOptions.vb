Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.CodeRush.Core
Imports HighlightCurrentLineInEditor.Painting

Public Structure HighlightSettings
    Public InnerColor As PaintColor
    Public OuterColor As PaintColor
End Structure
<UserLevel(UserLevel.NewUser)> _
Public Class HighlightCurrentLineOptions
    Public Const SECTION As String = "HighlightCurrentLine"

    'DXCore-generated code...
    Public Const KEY_InnerBaseColor As String = "InnerBaseColor"
    Public Const KEY_InnerOpacity As String = "InnerOpacity"
    Public Const KEY_OuterBaseColor As String = "OuterBaseColor"
    Public Const KEY_OuterOpacity As String = "OuterOpacity"
    Public Const KEY_TextBaseColor As String = "TextBaseColor"
    Public Const KEY_Enabled As String = "Enabled"
#Region " Initialize "
    Public Shared DEFAULT_COLOR_INNER As PaintColor = New PaintColor(Defaults.SelectedBackColor, 255)
    Public Shared DEFAULT_COLOR_OUTER As PaintColor = New PaintColor(Defaults.SelectedBackColor, 255)
    Public Shared DEFAULT_COLOR_TEXT As PaintColor = New PaintColor(Defaults.SelectedForeColor, 255)
    Protected Overrides Sub Initialize()
        MyBase.Initialize()

        'TODO: Add your initialization code here.
    End Sub
#End Region

#Region " GetCategory "
    Public Shared Function GetCategory() As String
        Return "Editor\Painting"
    End Function
#End Region
#Region " GetPageName "
    Public Shared Function GetPageName() As String
        Return "CurrentLine"
    End Function
#End Region
    Private Sub HighlightCurrentLineOptions_RestoreDefaults(ByVal sender As Object, ByVal ea As DevExpress.CodeRush.Core.OptionsPageEventArgs) Handles Me.RestoreDefaults
        ' Setup default options
        chkEnabled.Checked = True
        InnerColor.ColorBase = DEFAULT_COLOR_INNER.Base
        InnerColor.Opacity = DEFAULT_COLOR_INNER.Opacity
        OuterColor.ColorBase = DEFAULT_COLOR_OUTER.Base
        OuterColor.Opacity = DEFAULT_COLOR_OUTER.Opacity
        TextColor.ColorBase = DEFAULT_COLOR_TEXT.Base
        TextColor.Opacity = 255
    End Sub

    Private Sub HighlightCurrentLineOptions_PreparePage(ByVal sender As Object, ByVal ea As DevExpress.CodeRush.Core.OptionsPageStorageEventArgs) Handles Me.PreparePage
        ' Load Options
        chkEnabled.Checked = ea.Storage.ReadBoolean(SECTION, KEY_Enabled)
        InnerColor.ColorBase = ea.Storage.ReadColor(SECTION, KEY_InnerBaseColor, DEFAULT_COLOR_INNER.Base)
        InnerColor.Opacity = ea.Storage.ReadInt32(SECTION, KEY_InnerOpacity, DEFAULT_COLOR_INNER.Opacity)
        OuterColor.ColorBase = ea.Storage.ReadColor(SECTION, KEY_OuterBaseColor, DEFAULT_COLOR_OUTER.Base)
        OuterColor.Opacity = ea.Storage.ReadInt32(SECTION, KEY_OuterOpacity, DEFAULT_COLOR_OUTER.Opacity)
        TextColor.ColorBase = ea.Storage.ReadColor(SECTION, KEY_TextBaseColor, DEFAULT_COLOR_TEXT.Base)
        TextColor.Opacity = 255
    End Sub

    Private Sub HighlightCurrentLineOptions_CommitChanges(ByVal sender As Object, ByVal ea As DevExpress.CodeRush.Core.OptionsPageStorageEventArgs) Handles Me.CommitChanges
        ' Save Options
        ea.Storage.WriteColor(SECTION, KEY_InnerBaseColor, InnerColor.ColorBase)
        ea.Storage.WriteInt32(SECTION, KEY_InnerOpacity, InnerColor.Opacity)
        ea.Storage.WriteColor(SECTION, KEY_OuterBaseColor, OuterColor.ColorBase)
        ea.Storage.WriteInt32(SECTION, KEY_OuterOpacity, OuterColor.Opacity)
        ea.Storage.WriteColor(SECTION, KEY_TextBaseColor, TextColor.ColorBase)
        ea.Storage.WriteBoolean(SECTION, KEY_Enabled, chkEnabled.Checked)
        ea.Storage.UpdateStorage()
    End Sub

End Class
