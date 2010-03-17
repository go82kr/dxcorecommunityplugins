Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.CodeRush.Core
Imports DevExpress.CodeRush.PlugInCore
Imports DevExpress.CodeRush.StructuralParser
Imports System.Runtime.CompilerServices

Friend Module Enumerators
    Friend NamespacesClassesEnumsStructsDelegatesEventsMethodsPropertiesTypes As LanguageElementType() = {LanguageElementType.Class, LanguageElementType.Struct, LanguageElementType.Enum, LanguageElementType.Namespace, LanguageElementType.Property, LanguageElementType.Method, LanguageElementType.Event, LanguageElementType.Delegate}

    Friend Function Elements(ByVal Scope As LanguageElement) As IEnumerable(Of LanguageElement)
        Return New ElementEnumerable(Scope, True).OfType(Of LanguageElement)()
    End Function


#Region "Classes"
    Friend Function Classes(ByVal Scope As LanguageElement) As IEnumerable(Of LanguageElement)
        Return New ElementEnumerable(Scope, GetType([Class]), True).OfType(Of LanguageElement)()
    End Function
#End Region
#Region "Structs"
    Friend Function Structs(ByVal Scope As LanguageElement) As IEnumerable(Of LanguageElement)
        Return New ElementEnumerable(Scope, GetType(Struct), True).OfType(Of LanguageElement)()
    End Function
#End Region
#Region "Types"
    Friend Function Types(ByVal Scope As LanguageElement) As IEnumerable(Of LanguageElement)
        Return New ElementEnumerable(Scope, GetType(Type), True).OfType(Of LanguageElement)()
    End Function
#End Region
#Region "Interfaces"
    Friend Function Interfaces(ByVal Scope As LanguageElement) As IEnumerable(Of LanguageElement)
        Return New ElementEnumerable(Scope, GetType([Interface]), True).OfType(Of LanguageElement)()
    End Function
#End Region
#Region "MainElements"
    Friend Function MainElements(ByVal Scope As LanguageElement) As IEnumerable(Of LanguageElement)
        Return New ElementEnumerable(Scope, NamespacesClassesEnumsStructsDelegatesEventsMethodsPropertiesTypes, True).OfType(Of LanguageElement)()
    End Function
#End Region
#Region "Members"
    Public Function Members(ByVal Scope As LanguageElement) As IEnumerable(Of LanguageElement)
        Return New ElementEnumerable(Scope, GetType(Member), True).OfType(Of LanguageElement)()
    End Function
#End Region
#Region "Methods"
    Public Function Methods(ByVal Scope As LanguageElement) As IEnumerable(Of LanguageElement)
        Return New ElementEnumerable(Scope, GetType(Method), True).OfType(Of LanguageElement)()
    End Function
#End Region

#Region "Params"
    Friend Function Params(ByVal Scope As LanguageElement) As IEnumerable(Of LanguageElement)
        Return New ElementEnumerable(Scope, GetType(Param), True).OfType(Of LanguageElement)()
    End Function
#End Region
#Region "Variables"
    Friend Function Variables(ByVal Scope As LanguageElement) As IEnumerable(Of LanguageElement)
        Return New ElementEnumerable(Scope, GetType(Variable), True).OfType(Of LanguageElement)()
    End Function
#End Region
#Region "Fields"
    Friend Function Fields(ByVal Scope As LanguageElement) As IEnumerable(Of LanguageElement)
        Return Variables(Scope).Where(Function(v) TryCast(v, Variable).IsField)
    End Function
#End Region
#Region "Locals"
    Friend Function Locals(ByVal Scope As LanguageElement) As IEnumerable(Of LanguageElement)
        Return Variables(Scope).Where(Function(v) TryCast(v, Variable).IsLocal)
    End Function
#End Region
#Region "FieldsAndLocals"
    Friend Function FieldsAndLocals(ByVal Scope As LanguageElement) As IEnumerable(Of LanguageElement)
        Return Fields(Scope).Concat(Locals(Scope))
    End Function
#End Region
    '#Region "ConstantFields"
    '    'Friend Function ConstantFields(ByVal Scope As LanguageElement) As IEnumerable(Of [Const])
    '    '    Return Fields(Scope).Where(Function(v) v.IsConst).OfType(Of [Const])()
    '    'End Function
    '#End Region

End Module