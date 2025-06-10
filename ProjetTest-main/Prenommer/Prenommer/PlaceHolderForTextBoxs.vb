Public Class PlaceHolderForTextBoxs

    Private drag As Boolean

    Private Sub PlaceHolderForTextBoxs_Load(sender As Object, e As EventArgs) 'Handles MyBase.Load
        With Contact.TextBox1
            .SelectionStart = .TextLength
            .SelectionLength = 0
            .SelectionStart = 0
            .ScrollToCaret()
        End With
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) 'Handles txtSearch.KeyDown
        With Contact.TextBox1
            If .Text = "Search" And .ForeColor = Color.Gray Then
                If e.KeyCode = Keys.Right Or e.KeyCode = Keys.Left Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Home Or e.KeyCode = Keys.End Then
                    e.Handled = True
                End If
            End If
        End With
    End Sub

    Private Sub TextBox1_MouseDown(sender As Object, e As MouseEventArgs) 'Handles txtSearch.MouseDown
        drag = True
        With Contact.TextBox1
            If .Text = "Search" And .ForeColor = Color.Gray Then
                .SelectionStart = .TextLength
                .SelectionLength = 0
                .SelectionStart = 0
                .ScrollToCaret()
            End If
        End With
    End Sub

    Private Sub TextBox1_MouseMove(sender As Object, e As MouseEventArgs) 'Handles txtSearch.MouseMove
        If drag Then
            With Contact.TextBox1
                If .Text = "Search" And .ForeColor = Color.Gray Then
                    Contact.TextBox1.Select(0, 0)
                End If
            End With
        End If
    End Sub

    Private Sub TextBox1_MouseUp(sender As Object, e As MouseEventArgs) 'Handles txtSearch.MouseUp
        drag = False
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) 'Handles txtSearch.TextChanged
        With Contact.TextBox1
            If .Text = "" Then
                .Text = "Search"
                .ForeColor = Color.Gray
            End If
            If .Text = "Search" And .ForeColor = Color.Gray Then
                .ShortcutsEnabled = False
            Else
                .ShortcutsEnabled = True
            End If
            If .TextLength > 6 Then
                If StrReverse(StrReverse(.Text).Remove(6)) = "Search" Then
                    .Text = .Text.Remove(.TextLength - 6)
                    .ForeColor = Color.Black
                    .SelectionStart = .TextLength
                    .ScrollToCaret()
                End If
            End If
        End With
    End Sub

End Class