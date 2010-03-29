Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.CodeRush.Core
Imports DevExpress.CodeRush.PlugInCore
Imports DevExpress.CodeRush.StructuralParser

Public Class XPO_EasyFields

    'DXCore-generated code...
#Region " InitializePlugIn "
    Public Overrides Sub InitializePlugIn()
        MyBase.InitializePlugIn()

        'TODO: Add your initialization code here.
        CreateXPO_EasyFields()
        CreateXPO_EasyFields_Shortcut()
    End Sub
#End Region
#Region " FinalizePlugIn "
    Public Overrides Sub FinalizePlugIn()
        'TODO: Add your finalization code here.

        MyBase.FinalizePlugIn()
    End Sub
#End Region

    ' Please ensure the following line is not missing from your plugin's InitializeComponent
    ' components = New System.ComponentModel.Container()
    Dim NormalFeedbackColor As Color = CodeRush.Hints.Settings.FeedbackFillColor
    Dim NormalFeedbackBorderColor As Color = CodeRush.Hints.Settings.FeedbackBorderColor
    ' Please ensure the following line is not missing from your plugin's InitializeComponent
    ' components = New System.ComponentModel.Container()
    Public Sub CreateXPO_EasyFields()
        Dim XPO_EasyFields As New DevExpress.CodeRush.Core.CodeProvider(components)
        CType(XPO_EasyFields, System.ComponentModel.ISupportInitialize).BeginInit()
        XPO_EasyFields.ProviderName = "XPO_EasyFields" ' Should be Unique
        XPO_EasyFields.DisplayName = "Update XPO FieldsClass"
        AddHandler XPO_EasyFields.CheckAvailability, AddressOf XPO_EasyFields_CheckAvailability
        AddHandler XPO_EasyFields.Apply, AddressOf XPO_EasyFields_Execute
        CType(XPO_EasyFields, System.ComponentModel.ISupportInitialize).EndInit()
    End Sub
    Private Sub XPO_EasyFields_CheckAvailability(ByVal sender As Object, ByVal ea As CheckContentAvailabilityEventArgs)
        ' This method is executed when the system checks the availability of your Code.
        If CodeRush.Source.ActiveClass IsNot Nothing AndAlso DXCoreXPOHelper.XPOElement.Check("DevExpress.Xpo.PersistentBase", CodeRush.Source.ActiveClass.GetDeclaration) Then
            If Not UseClassNameOnly Or (UseClassNameOnly And TypeOf ea.CodeActive Is [Class]) Then
                ea.Available = True
                Return
            End If
        End If
        ea.Available = False
        ' Change this to return true, only when your Code should be available.
    End Sub

    ' Please ensure the following line is not missing from your plugin's InitializeComponent
    ' components = New System.ComponentModel.Container()
    Public Sub CreateXPO_EasyFields_Shortcut()
        Dim XPO_EasyFields_Shortcut As New DevExpress.CodeRush.Core.Action(components)
        CType(XPO_EasyFields_Shortcut, System.ComponentModel.ISupportInitialize).BeginInit()
        XPO_EasyFields_Shortcut.ActionName = "XPO Update FieldsClass"
        XPO_EasyFields_Shortcut.ButtonText = "XPO Update FieldsClass" ' Used if button is placed on a menu.
        XPO_EasyFields_Shortcut.RegisterInCR = True
        AddHandler XPO_EasyFields_Shortcut.Execute, AddressOf XPO_EasyFields_Shortcut_Execute
        CType(XPO_EasyFields_Shortcut, System.ComponentModel.ISupportInitialize).EndInit()
    End Sub
    Private Sub XPO_EasyFields_Shortcut_Execute(ByVal ea As ExecuteEventArgs)
        ' This method is executed when your action is called.
        ' Remember you must bind your action to a shortcut in order to use it.
        ' Shortcuts are created\altered using the IDE\Shortcuts option page 
        PerformUpdateFieldsClass(CodeRush.Source.ActiveClass, CodeRush.Documents.ActiveTextDocument)
        ApplyChanges(CodeRush.Documents.ActiveTextDocument)
    End Sub

    Private Sub XPO_EasyFields_Execute(ByVal Sender As Object, ByVal ea As ApplyContentEventArgs)

        ' This method is executed when the system executes your Code 

        PerformUpdateFieldsClass(CodeRush.Source.ActiveClass, CodeRush.Documents.ActiveTextDocument)
        ApplyChanges(CodeRush.Documents.ActiveTextDocument)
    End Sub

    Private Sub PerformUpdateFieldsClass(ByVal clsXPO As [Class], ByVal docXPO As TextDocument)
        Try
            If clsXPO IsNot Nothing AndAlso DXCoreXPOHelper.XPOElement.Check("DevExpress.Xpo.PersistentBase", clsXPO.GetDeclaration) Then
                'Bob the CodeRush Builder ;)
                Dim BobClass As ElementBuilder = New ElementBuilder
                Dim BobProperty As ElementBuilder = New ElementBuilder
                Dim BobVariable As ElementBuilder = New ElementBuilder

                Dim nameClass As String = "FieldsClass"
                Dim nameVariable As String = "_fields"
                Dim nameProperty As String = "Fields"

                'TODO: Need to work out how to ensure there is firstly an Import of the DevExpress.Xpo and DevExpress.Data.Filtering namespace



                Dim ExistingFieldsClass As [Class] = FindElement(clsXPO, LanguageElementType.Class, nameClass)

                'Check whether we already have the FieldsClass declared


                'Create the new FieldsClass class
                Dim NewFieldsClass As [Class] = BobClass.AddClass(Nothing, nameClass)
                NewFieldsClass.Visibility = MemberVisibility.Public
                NewFieldsClass.IsNew = True 'This seems to do the "Shadows" keyword
                NewFieldsClass.PrimaryAncestorType = New TypeReferenceExpression(clsXPO.PrimaryAncestorType.Name & "." & nameClass) 'Couldn't find easier way, needs to "shadow" the persistentbase FieldsClass
                Dim CommentStart As String = "Created/Updated:"
                BobClass.AddComment(NewFieldsClass, CommentStart & " " & Now.ToString("ddd dd-MMM-yyyy HH:mm:ss"), CommentType.SingleLine) 'date format should use local culture, but then again Aussie way is best

                Dim constructor As Method = BobClass.AddConstructor(NewFieldsClass)
                constructor.Visibility = MemberVisibility.Public
                BobClass.AddBaseConstructorInitializer(constructor, New ExpressionCollection())

                Dim constructorwithproperty As Method = BobClass.AddConstructor(NewFieldsClass)
                constructorwithproperty.Visibility = MemberVisibility.Public
                Dim constructorArgument As String = "propertyName"
                Dim inParam As Param = BobClass.AddInParam(constructorwithproperty, CodeRush.Language.GetBaseTypeName("System.String"), constructorArgument)
                Dim ConstructorWithPropertyArguments = New ExpressionCollection
                ConstructorWithPropertyArguments.Add(BobClass.BuildElementReference(constructorArgument))
                BobClass.AddBaseConstructorInitializer(constructorwithproperty, ConstructorWithPropertyArguments)




                'Go through all the possible persistent members of the class (Variables and Properties)
                Dim Searcher As ElementEnumerable
                Dim element As IEnumerator
                Searcher = New ElementEnumerable(clsXPO, New LanguageElementType() {LanguageElementType.Property, LanguageElementType.Variable})
                element = Searcher.GetEnumerator
                element.Reset()
                While element.MoveNext
                    Dim FoundMember As MemberWithParameters = TryCast(element.Current, MemberWithParameters)
                    If FoundMember IsNot Nothing Then
                        If DXCoreXPOHelper.IsPersistentMember(FoundMember) Then

                            Dim XPOType As New DXCoreXPOHelper.XPOElement(FoundMember.MemberTypeReference.GetDeclaration)
                            Dim newPropertyType As String
                            If XPOType.IsPersistentClass And Not XPOType.IsXPCollection Then
                                newPropertyType = XPOType.Element.FullName & ".FieldsClass"
                            ElseIf XPOType.IsXPCollection Then
                                newPropertyType = "DevExpress.Data.Filtering.OperandProperty"
                            Else
                                newPropertyType = "DevExpress.Data.Filtering.OperandProperty"
                            End If

                            Dim newProperty As [Property] = BobClass.AddProperty(NewFieldsClass, newPropertyType, FoundMember.Name)
                            Dim newPropertyGetter As [Get] = BobClass.AddGetter(newProperty)
                            'newProperty.IsReadOnly = True
                            newProperty.Visibility = MemberVisibility.Public
                            Dim ReturnArguments As New ExpressionCollection
                            Dim GetNestedNameArguments As New ExpressionCollection
                            GetNestedNameArguments.Add(BobClass.BuildPrimitiveFromObject(FoundMember.Name))
                            'GetNestedName("Test")
                            ReturnArguments.Add(BobClass.BuildMethodCallExpression("GetNestedName", GetNestedNameArguments))
                            'Dim returnExpression = BobClass.BuildObjectCreationExpression(newPropertyType, ReturnArguments)
                            'Dim ReturnExpression = BobClass.BuildExpressionConstructorInitializer(BobClass.va(BobClass.BuildElementReference(newPropertyType), ReturnArguments)
                            BobClass.AddReturn(newPropertyGetter, BobClass.BuildObjectCreationExpression(newPropertyType, ReturnArguments))
                        End If
                    End If
                End While

                If ExistingFieldsClass IsNot Nothing Then
                    Dim ClassRange As SourceRange = ExistingFieldsClass.Range
                    If docXPO.GetLine(ExistingFieldsClass.StartLine - 1).TrimStart(" ").StartsWith(CodeRush.Language.GetComment(CommentStart).TrimEnd) Then
                        ClassRange.Set(New SourcePoint(ClassRange.Start.Line - 1, ClassRange.Start.Offset), ClassRange.End)
                    End If
                    docXPO.QueueReplace(ClassRange, BobClass.GenerateCode(docXPO.Language).TrimEnd)
                Else
                    docXPO.QueueInsert(New SourcePoint(clsXPO.EndLine, 1), BobClass.GenerateCode(docXPO.Language))
                End If


                Dim ExistingFieldsClassProperty As [Property] = FindElement(clsXPO, LanguageElementType.Property, nameProperty)
                If ExistingFieldsClass Is Nothing Or Not ReplaceClassOnly Then
                    Dim NewFieldsClassProperty As [Property] = BobProperty.AddProperty(Nothing, nameClass, nameProperty)
                    Dim NewFieldsClassPropertyGet As [Get] = BobProperty.AddGetter(NewFieldsClassProperty)
                    NewFieldsClassProperty.IsNew = True
                    NewFieldsClassProperty.IsStatic = True
                    'NewFieldsClassProperty.IsReadOnly = True
                    NewFieldsClassProperty.Visibility = MemberVisibility.Public
                    Dim NewFieldsClassPropertyGetIf As [If] = BobProperty.AddIf(NewFieldsClassPropertyGet, "ReferenceEquals(" & nameVariable & "," & CodeRush.Language.GenerateExpressionCode(CodeRush.Language.GetNullReferenceExpression) & ")")
                    BobProperty.AddAssignment(NewFieldsClassPropertyGetIf, nameVariable, BobProperty.BuildObjectCreationExpression(nameClass, New ExpressionCollection))
                    BobProperty.AddReturn(NewFieldsClassPropertyGet, nameVariable)

                    If ExistingFieldsClassProperty IsNot Nothing Then
                        docXPO.QueueReplace(ExistingFieldsClassProperty.Range, BobProperty.GenerateCode(docXPO.Language).TrimEnd)
                    Else
                        docXPO.QueueInsert(New SourcePoint(clsXPO.EndLine, 1), BobProperty.GenerateCode(docXPO.Language))
                    End If
                End If
                

                Dim ExistingFieldsClassVariable As Variable = FindElement(clsXPO, LanguageElementType.Variable, nameVariable)
                If ExistingFieldsClassVariable Is Nothing Or Not ReplaceClassOnly Then
                    Dim NewFieldsClassVariable As Variable = BobVariable.AddVariable(Nothing, nameClass, nameVariable)
                    NewFieldsClassVariable.IsStatic = True
                    NewFieldsClassVariable.Visibility = MemberVisibility.Private
                    If ExistingFieldsClassVariable IsNot Nothing Then
                        docXPO.QueueReplace(ExistingFieldsClassVariable.Range, BobVariable.GenerateCode(docXPO.Language).TrimEnd)
                    Else
                        docXPO.QueueInsert(New SourcePoint(clsXPO.EndLine, 1), BobVariable.GenerateCode(docXPO.Language))
                    End If
                End If
            End If

        Catch ex As Exception
            CodeRush.Hints.Settings.FeedbackFillColor = Color.Red
            CodeRush.Hints.Settings.FeedbackBorderColor = Color.DarkRed
            BigFeedback1.Text = "XPO FieldsClass Failed"
        End Try
    End Sub

    Private Sub ApplyChanges(ByVal docXPO As TextDocument)
        If docXPO.QueuedEdits.Count > 0 Then
            'Dim EditedAreas As New List(Of SourceRange)
            'For Each edit As LanguageElement In docXPO.QueuedEdits
            '    EditedAreas.Add(edit.Range.Clone)
            'Next
            docXPO.ApplyQueuedEdits("XPO Update FieldsClass", True)
            'For Each EditedArea As SourceRange In EditedAreas
            '    docXPO.Format(EditedArea)
            'Next

            docXPO.RefreshViews()

            CodeRush.Hints.Settings.FeedbackFillColor = NormalFeedbackColor
            CodeRush.Hints.Settings.FeedbackBorderColor = NormalFeedbackBorderColor
            BigFeedback1.Text = "XPO FieldsClass Updated"
            BigFeedback1.Show()
        Else
            CodeRush.Hints.Settings.FeedbackFillColor = NormalFeedbackColor
            CodeRush.Hints.Settings.FeedbackBorderColor = NormalFeedbackBorderColor
            BigFeedback1.Text = "Nothing to do"
            BigFeedback1.Show()
        End If
    End Sub

    Private Function FindElement(ByVal clsSearch As [Class], ByVal elementType As LanguageElementType, ByVal elementName As String) As LanguageElement
        Dim Searcher As ElementEnumerable
        Dim element As IEnumerator
        Searcher = New ElementEnumerable(clsSearch, elementType)
        element = Searcher.GetEnumerator
        element.Reset()
        While element.MoveNext
            Dim FoundElement As LanguageElement = TryCast(element.Current, LanguageElement)
            If FoundElement IsNot Nothing AndAlso FoundElement.Name.ToLower = elementName.ToLower Then
                Return element.Current() 'Found it, keep a reference so we can "override" it later
                Exit While
            End If
        End While
        Return Nothing
    End Function

    Private UseClassNameOnly As Boolean = False
    Private ReplaceClassOnly As Boolean = False
    Private UpdateOnSave As Boolean = False
    Private Sub LoadSettings()
        Using optionStorage As DecoupledStorage = XPO_EasyFields_Options.Storage
            UseClassNameOnly = optionStorage.ReadBoolean(XPO_EasyFields_Options.STR_Setting, XPO_EasyFields_Options.STR_AvailableClassNameOnly)
            ReplaceClassOnly = optionStorage.ReadBoolean(XPO_EasyFields_Options.STR_Setting, XPO_EasyFields_Options.STR_ReplaceClassOnly)
            UpdateOnSave = optionStorage.ReadBoolean(XPO_EasyFields_Options.STR_Setting, XPO_EasyFields_Options.STR_UpdateOnSave)
        End Using
    End Sub

    Public Shared XPOSyncSaveInProgress As New Dictionary(Of TextDocument, Boolean)
    Private Sub XPO_EasyFields_DocumentSaved(ByVal ea As DevExpress.CodeRush.Core.DocumentEventArgs) Handles Me.DocumentSaved
        If Not UpdateOnSave Then
            Return
        End If
        If TypeOf ea.Document Is TextDocument Then
            Dim doc As TextDocument = ea.Document
            If XPOSyncSaveInProgress.ContainsKey(doc) Then
                XPOSyncSaveInProgress.Remove(doc)
            Else
                Dim Searcher As ElementEnumerable
                Dim element As IEnumerator
                Searcher = New ElementEnumerable(doc.FileNode, LanguageElementType.Class, True)
                element = Searcher.GetEnumerator
                element.Reset()
                While element.MoveNext
                    Dim FoundElement As LanguageElement = TryCast(element.Current, LanguageElement)
                    If FoundElement IsNot Nothing Then
                        PerformUpdateFieldsClass(element.Current, doc)
                    End If
                End While

                ApplyChanges(doc)

                XPOSyncSaveInProgress.Add(doc, True)
                doc.Save()
            End If
        End If
    End Sub
    '{
    '  using (DecoupledStorage lStorage = OptMySuperPlugIn.Storage)
    '  {
    '    _MySuperFeatureIsEnabled = lStorage.ReadBoolean("Preferences",
    '"Enabled", true);
    '    ...
    '  }
    '}

    Private Sub XPO_EasyFields_OptionsChanged(ByVal ea As DevExpress.CodeRush.Core.OptionsChangedEventArgs) Handles Me.OptionsChanged
        If ea.OptionsPages.Contains(GetType(XPO_EasyFields_Options)) Then
            LoadSettings()
        End If

    End Sub
End Class