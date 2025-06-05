Public Class Popup

    Private IsFormBeingDragged As Boolean = False
    Private MouseDownX As Integer
    Private MouseDownY As Integer

    Private Sub Popup_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

        If Asc(e.KeyChar) = Keys.Escape Then

            Dispose()

        End If

    End Sub

    Private Sub Popup_Load(sender As Object, e As EventArgs) Handles Me.Load

        Height = PictureBox1.Image.Height
        Width = PictureBox1.Image.Width

    End Sub

    Private Sub Popup_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove

        If IsFormBeingDragged Then
            Dim temp As New Drawing.Point With {
                .X = Location.X + (e.X - MouseDownX),
                .Y = Location.Y + (e.Y - MouseDownY)
            }
            Location = temp
        End If

    End Sub

    Private Sub Popup_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp

        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = False
        End If

    End Sub

    Private Sub Popup_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown

        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = True
            MouseDownX = e.X
            MouseDownY = e.Y
        End If

    End Sub

End Class