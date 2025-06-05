Imports System.Runtime.Serialization.Formatters.Binary

Partial Public Class Class1

    Public Sub SauveTreeView(treeView As TreeView, filnavn As String)

        Bloqué = False
        Reset()
        Dialogue = True

        Try

            Bloqué = True
            Dim ListeNoeuds As New ArrayList() 'Instanciation de la liste
            Dim fichier As IO.FileStream = IO.File.Open(filnavn, IO.FileMode.Create, IO.FileAccess.Write, IO.FileShare.Read) 'IO.File.OpenWrite(filnavn)
            'Ouverture du fichier en écriture
            Dim serializer As New BinaryFormatter() 'Instanciation du serializeur binaire
            Dim noeud As TreeNode
            For Each noeud In treeView.Nodes 'Ajout de chaque noeud dans la liste
                Dim v = ListeNoeuds.Add(noeud)
            Next noeud

            serializer.Serialize(fichier, ListeNoeuds) 'Serialization de la liste dans le fichier
            fichier.Close() 'Fermeture du fichier

        Catch ex As Exception

            Dim dialogResult = MessageBox.Show(ex.Message)

            Dim dialogResult1 = MessageBox.Show("Stack Trace : " & vbCrLf & ex.StackTrace)
        Finally
            Dim dialogResult = MessageBox.Show("L'exécution du processus est terminée.")
        End Try

    End Sub

    Public Sub ChargeTreeView(treeView As TreeView, filnavn As String)

        Dim fichier As IO.FileStream = IO.File.OpenRead(filnavn) 'Ouverture du fichier à charger
        Dim serializer As New BinaryFormatter() 'Instanciation du serializeur binaire
        treeView.Nodes.Clear() 'Efface tout les noeuds de l'arborescence
        treeView.BeginUpdate() 'À mettre avant l'ajout de beaucoup de noeuds
        Dim ListeNoeuds As ArrayList =
        CType(serializer.Deserialize(fichier), ArrayList) 'Deserialisation dans la liste

        Dim node As TreeNode
        For Each node In ListeNoeuds 'Ajout de chaque noeud dans l'arborescence
            Dim v = treeView.Nodes.Add(node)
        Next node
        treeView.EndUpdate()

    End Sub

    Public Module CueBannerText
        <DllImport("user32.dll", CharSet:=CharSet.Auto)>
        Private Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, <MarshalAs(UnmanagedType.LPWStr)> ByVal lParam As String) As Int32
        End Function
        Private Declare Function FindWindowEx Lib "user32" Alias "FindWindowExA" (ByVal hWnd1 As IntPtr, ByVal hWnd2 As IntPtr, ByVal lpsz1 As String, ByVal lpsz2 As String) As IntPtr
        Private Const EM_SETCUEBANNER As Integer = &H1501

        Public Sub SetCueText(cntrl As Control, text As String)
            If TypeOf cntrl Is ComboBox Then
                Dim Edit_hWnd As IntPtr = FindWindowEx(cntrl.Handle, IntPtr.Zero, "Edit", Nothing)
                If Not Edit_hWnd = IntPtr.Zero Then
                    SendMessage(Edit_hWnd, EM_SETCUEBANNER, 0, text)
                End If
            ElseIf TypeOf cntrl Is TextBox Then
                SendMessage(cntrl.Handle, EM_SETCUEBANNER, 0, text)
            End If
        End Sub
    End Module
End Class
