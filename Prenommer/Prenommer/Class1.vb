Imports System.IO
Imports System.Xml.Serialization
Imports System.Runtime.Serialization.Formatters.Binary

Public Class TreeNodeData

    Public Property Text As String
    Public Property Tag As Object ' Ajoutez d'autres propriétés nécessaires
    Public Property Nodes As List(Of TreeNodeData)

End Class

Public Class Class1
    Public Function CreateXmlSerializer() As XmlSerializer

        Return New XmlSerializer(GetType(TreeNode)) ' Remplacez par le type que vous souhaitez sérialiser

    End Function

    Public Sub SauveTreeView(treeView As TreeView, filePath As String)

        Bloqué = False
        Dialogue = True

        Dim ListeNoeuds As New List(Of TreeNodeData)()

        For Each node As TreeNode In treeView.Nodes
            ListeNoeuds.Add(CreateTreeNodeData(node))
        Next

        Try

            Bloqué = True

            ' Utiliser Using pour s'assurer que le fichier est correctement fermé
            Using fichier As FileStream = File.OpenWrite(filePath)
                Dim serializer As New BinaryFormatter()
                serializer.Serialize(fichier, ListeNoeuds)
                serializer.Serialize(fichier, ListeNoeuds)
            End Using

        Catch ex As Exception
            ' Gérer l'exception (vous pouvez personnaliser cela en fonction de vos besoins)
            Dim dialogResult = MessageBox.Show($"Erreur lors de la sérialisation : {ex.Message}")
            'Catch exc As IOException
            'Dim dialogResult = MessageBox.Show(exc.ToString())
            'Dim dialogResult1 = MessageBox.Show("Stack Trace : " & vbCrLf & exc.StackTrace)
            'Throw

        Finally
            Dim dialogResult1 = MessageBox.Show("L'exécution du processus est terminée.")

        End Try

    End Sub

    Public Sub ChargeTreeView(treeView As TreeView, filePath As String)

        'Dim ListeNoeuds As List(Of TreeNodeData) =
        'CType(serializer.Deserialize(filePath), List(Of TreeNodeData))

        Try
            ' Utiliser Using pour s'assurer que le fichier est correctement fermé
            Using fichier As FileStream = File.OpenRead(filePath)
                Dim serializer As New BinaryFormatter()
                Dim ListeNoeuds As List(Of TreeNodeData) =
                    CType(serializer.Deserialize(fichier), List(Of TreeNodeData))

                For Each nodeData As TreeNodeData In ListeNoeuds
                    treeView.Nodes.Add(CreateTreeNode(nodeData))
                Next
            End Using

        Catch ex As Exception
            ' Gérer l'exception (vous pouvez personnaliser cela en fonction de vos besoins)
            Dim dialogResult = MessageBox.Show($"Erreur lors de la désérialisation : {ex.Message}")
        End Try

    End Sub

    Private Function CreateTreeNodeData(node As TreeNode) As TreeNodeData

        Dim nodeData As New TreeNodeData() With {
            .Text = node.Text,
            .Tag = node.Tag,
            .Nodes = New List(Of TreeNodeData)()
        }

        For Each childNode As TreeNode In node.Nodes
            nodeData.Nodes.Add(CreateTreeNodeData(childNode))
        Next

        Return nodeData

    End Function

    Private Function CreateTreeNode(nodeData As TreeNodeData) As TreeNode

        Dim node As New TreeNode() With {
            .Text = nodeData.Text,
            .Tag = nodeData.Tag
        }

        For Each childNodeData As TreeNodeData In nodeData.Nodes
            node.Nodes.Add(CreateTreeNode(childNodeData))
        Next

        Return node

    End Function

End Class
