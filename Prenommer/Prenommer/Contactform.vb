
Public Class Contactform

    Private Sub Contactform_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TxtUsername.Text = ""
        'TxtPassword.Text = ""

    End Sub

    Private Sub TxtUsername_MouseEnter(sender As Object, e As EventArgs) Handles TxtUsername.MouseEnter

        If TxtUsername.Text = "Tapez votre nom" Then
            TxtUsername.Text = ""
            TxtUsername.ForeColor = Color.Black
        End If

    End Sub

    Private Sub TxtUsername_MouseLeave(sender As Object, e As EventArgs) Handles TxtUsername.MouseLeave

        If TxtUsername.Text = "" Then
            TxtUsername.Text = "Tapez votre nom"
            TxtUsername.ForeColor = Color.Gray
        End If

    End Sub

    Private Sub TxtPassword_MouseEnter(sender As Object, e As EventArgs) Handles TxtPassword.MouseEnter

        If TxtPassword.Text = "Tapez votre prénom" Then
            TxtPassword.Text = ""
            TxtPassword.PasswordChar = CChar("*")
            TxtPassword.ForeColor = Color.Black
        End If

    End Sub

    Private Sub TxtPassword_MouseLeave(sender As Object, e As EventArgs) Handles TxtPassword.MouseLeave

        If TxtPassword.Text = "" Then
            If TxtPassword.Text = "" Then
                TxtPassword.Text = "Tapez votre prénom"
                TxtPassword.PasswordChar = CChar("")
                TxtPassword.ForeColor = Color.Gray
            End If
        End If

    End Sub

End Class