Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Public Class Class5

    Public Sub SauveTreeView(treeView As TreeView, filnavn As String)

        Bloqué = False
        Dialogue = True

        Try

            Bloqué = True
            Dim ListeNoeuds As New ArrayList() ' Instanciation de la liste.
            Dim fichier As FileStream = File.OpenWrite(filnavn) ' Ouverture du fichier en écriture.

            Dim serializer As New BinaryFormatter() ' Instanciation du serializeur binaire.

            For Each noeud In treeView.Nodes
                Dim unused = ListeNoeuds.Add(noeud)
            Next noeud

            serializer.Serialize(fichier, ListeNoeuds)
            fichier.Close()

        Catch exc As IOException
            Dim dialogResult = MessageBox.Show(exc.ToString())
            Dim dialogResult1 = MessageBox.Show("Stack Trace : " & vbCrLf & exc.StackTrace)
            Throw

        Finally
            Dim dialogResult1 = MessageBox.Show("L'exécution du processus est terminée.")

        End Try

    End Sub

    Public Sub ChargeTreeView(treeView As TreeView, filnavn As String)

        Dim fichier As FileStream = File.OpenRead(filnavn) ' Ouverture du fichier à charger.
        Dim serializer As New BinaryFormatter() ' Instanciation du serializeur binaire.

        treeView.Nodes.Clear() ' Efface tous les noeuds de l'arborescence.
        treeView.BeginUpdate() ' À mettre avant l'ajout de beaucoup de noeuds.

        Dim ListeNoeuds As ArrayList =
     CType(serializer.Deserialize(fichier), ArrayList) ' Deserialisation dans la liste.

        Dim node As TreeNode
        For Each node In ListeNoeuds ' Ajout de chaque noeud dans l'arborescence.
            Dim v = treeView.Nodes.Add(node)
        Next node

        treeView.EndUpdate()
        fichier.Close()

    End Sub

End Class