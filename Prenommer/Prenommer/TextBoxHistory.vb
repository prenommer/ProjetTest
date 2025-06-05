Public Class TextBoxHistory

    Private ReadOnly history As New Stack(Of String)()
    Private ReadOnly redoStack As New Stack(Of String)()
    Private ignoreChange As Boolean

    Public Sub New(textBox As TextBox)

        AddHandler textBox.TextChanged, AddressOf TextBox_TextChanged
        Me.TextBox = textBox
        history.Push(textBox.Text)

    End Sub

    Private Sub TextBox_TextChanged(sender As Object, e As EventArgs)

        If Not ignoreChange Then
            history.Push(TextBox.Text)
            redoStack.Clear()
        End If

    End Sub

    Private Property TextBox As TextBox

    Public Sub Undo()

        If history.Count > 1 Then
            ignoreChange = True
            redoStack.Push(history.Pop())
            TextBox.Text = history.Peek()
            TextBox.SelectionStart = TextBox.Text.Length
            ignoreChange = False
        End If

    End Sub

    Public Sub Redo()

        If redoStack.Count > 0 Then
            ignoreChange = True
            history.Push(redoStack.Pop())
            TextBox.Text = history.Peek()
            TextBox.SelectionStart = TextBox.Text.Length
            ignoreChange = False
        End If

    End Sub

End Class