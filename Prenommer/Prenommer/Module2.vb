
' Module partagé pour stocker la liste des fichiers créés
Public Module FileListManager

    ' Liste des fichiers créés avec leurs chemins
    Public CreatedFiles As New List(Of String)

    Friend Sub AddFile(filePath As String)
        Throw New NotImplementedException()
    End Sub
End Module

Public Module ListViewItemExtensions
    <Runtime.CompilerServices.Extension>
    Public Function Clone(item As ListViewItem) As ListViewItem
        Dim cloneItem As New ListViewItem(item.Text) With {
            .Tag = item.Tag
        }

        For Each subItem As ListViewItem.ListViewSubItem In item.SubItems
            Dim unused = cloneItem.SubItems.Add(subItem.Text)
        Next

        Return cloneItem
    End Function

End Module