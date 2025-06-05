Imports System.Runtime.InteropServices

Friend Module Module1

    Public I, sauvé, modifié, ajouté, quitté, lit, supprimé, itemprevious, progress, Level As Integer
    Public enregistré, cboInit As Boolean
    Public locationprevious, FileSize, FileLength As Long
    Public preceding, selectionné As String

    Public filenames As New List(Of String)
    Public ListeModules As List(Of String)

    Public Const INVALID_HANDLE_VALUE As Long = -1

    Public bChanged As Boolean = False
    Public bFurther As Boolean = False

    Public Function GetImgOFD(Frm As Form, PicBx As PictureBox) As Bitmap

        Dim _ErrBitmap As Bitmap = My.Resources.DocumentError_16x
        Dim ChosenBitmap As Bitmap

        Using OFD As New OpenFileDialog
            With OFD
                .Title = "Veuillez sélectionner un fichier"
                .InitialDirectory = My.Application.Info.DirectoryPath & "\Images\"
                .Filter = "Fichiers Image (*.ico;*.jpg;*.bmp;*.gif;*.png)|*.jpg;*.bmp;*.gif;*.png;*.ico"
                .RestoreDirectory = True
                .Multiselect = False
                .CheckFileExists = True
                If .ShowDialog(Frm) = DialogResult.OK Then
                    ChosenBitmap = CType(Image.FromFile(.FileName), Bitmap)
                    FileNameImage = .FileName
                Else
                    ChosenBitmap = _ErrBitmap
                End If
            End With
        End Using
        Return ChosenBitmap

    End Function

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

End Module

