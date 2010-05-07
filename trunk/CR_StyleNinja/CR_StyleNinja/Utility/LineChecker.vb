Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.CodeRush.Core
Imports DevExpress.CodeRush.PlugInCore
Imports DevExpress.CodeRush.StructuralParser

Public Class Fred
    Inherits Checker
End Class
Public Class LineChecker
    Private mIssueMessage As String
    Private mQualifier As LineQualifiesDelegate
    Private mExitStrategy As Func(Of Boolean)

    Public Delegate Function LineQualifiesDelegate(ByVal Line As Integer) As Boolean
    Public Sub New(ByVal Qualifier As LineQualifiesDelegate, ByVal IssueMessage As String, Optional ByVal ExitStrategy As Func(Of Boolean) = Nothing)
        mIssueMessage = IssueMessage
        mQualifier = Qualifier
        mExitStrategy = ExitStrategy
    End Sub
    Public Sub CheckCodeIssues(ByVal sender As Object, ByVal ea As CheckCodeIssuesEventArgs)
        If mExitStrategy IsNot Nothing AndAlso mExitStrategy.Invoke() Then
            Exit Sub
        End If
        If ea.Scope.ToLE IsNot Nothing Then
            For Each Range As SourceRange In ea.Scope.Ranges
                For Line = Range.Top.Line To Range.Bottom.Line
                    If mQualifier.Invoke(Line) Then
                        ea.AddHint(New SourceRange(Line, 1, Line, 2), mIssueMessage)
                    End If
                Next
            Next

        End If
    End Sub
End Class