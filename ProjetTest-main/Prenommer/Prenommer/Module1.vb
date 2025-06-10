Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text

Public Module CueBannerText

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Function SendMessage(hWnd As IntPtr, msg As Integer, wParam As Integer, <MarshalAs(UnmanagedType.LPWStr)> lParam As String) As Integer
    End Function
    Private Declare Function FindWindowEx Lib "user32" Alias "FindWindowExA" (hWnd1 As IntPtr, hWnd2 As IntPtr, lpsz1 As String, lpsz2 As String) As IntPtr
    Private Const EM_SETCUEBANNER As Integer = &H1501

    Public Sub SetCueText(cntrl As Control, text As String)
        If TypeOf cntrl Is ComboBox Then
            Dim Edit_hWnd As IntPtr = FindWindowEx(cntrl.Handle, IntPtr.Zero, "Edit", Nothing)
            If Not Edit_hWnd = IntPtr.Zero Then
                Dim unused = SendMessage(Edit_hWnd, EM_SETCUEBANNER, 0, text)
            End If
        ElseIf TypeOf cntrl Is TextBox Then
            Dim unused1 = SendMessage(cntrl.Handle, EM_SETCUEBANNER, 0, text)
        End If
    End Sub

End Module

Friend Module Module3

    Private Declare Function LoadLibrary Lib "kernel32" Alias "LoadLibraryA" (lpLibFileName As String) As Long
    Private Declare Function FreeLibrary Lib "kernel32" (hLibModule As Long) As Long
    Private Declare Function SendMessageByString Lib "user32" Alias "SendMessageA" (hWnd As Long, wMsg As Long, wParam As Long, lParam As String) As Long

    Public Declare Function GetTickCount Lib "kernel32" () As Long
    Public Declare Function GetPixel Lib "gdi32" (
    hDC As Long,
    X As Long,
    Y As Long
    ) As Long

    Declare Function GetDefaultPrinter Lib "winspool.drv" Alias "GetDefaultPrinterA" (szPrinter As StringBuilder, ByRef bufferSize As Integer) As Boolean
    Declare Function SetDefaultPrinter Lib "winspool.drv" Alias "SetDefaultPrinterA" (szPrinter As String) As Boolean

    Public I, sauvé, modifié, ajouté, quitté, lit, supprimé, itemprevious, progress, Level As Integer
    Public enregistré, cboInit As Boolean
    Public locationprevious, FileSize, FileLength As Long
    Public preceding, selectionné As String

    Public FileNameQ As New List(Of String)
    Public ListeModules As List(Of String)
    Public Property ChercheItem As String
    Public Property StartFolder As String
    Public Property SpecialFolder As Long
    Public Property SzDisplay As String
    Public Property Dialogue As Boolean
    Public Property IndexEnreg As Integer

    <StructLayout(LayoutKind.Sequential, Pack:=4)>
    Public Structure WIN32_FIND_DATA
        Public dwFileAttributes As Integer
        Public ftCreationTime As Long
        Public ftLastAccessTime As Long
        Public ftLastWriteTime As Long
        Public nFileSizeHigh As UInteger
        Public nFileSizeLow As UInteger
        Public dwReserved0 As Integer
        Public dwReserved1 As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> Public cFileName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=14)> Public cAlternate As String
    End Structure

    Public Const INVALID_HANDLE_VALUE As Long = -1

    ' Constantes pour la clé et le vecteur d'initialisation
    'Public Const MyEncryptionKey As String = "VotreCléIci" ' Remplacer par GenerateRandomKey()
    'Public Const MyInitializationVector As String = "VotreVecteurIci" ' Remplacer par GenerateRandomIV()

    Public Structure FILETIME
        Public dwLowDateTime As Long
        Public dwHighDateTime As Long
    End Structure

    Declare Function FindFirstFile Lib "kernel32" Alias "FindFirstFileA" (lpFileName As String, lpFindFileData As WIN32_FIND_DATA) As Long
    Public Declare Function FindClose Lib "kernel32" (hFindFile As Long) As Long
    Public Declare Function PathFileExists Lib "shlwapi.dll" Alias "PathFileExistsA" (pszPath As String) As Long

    Public Structure Article
        <VBFixedString(18)> Public Title As String
        <VBFixedString(90)> Public Name As String
        <VBFixedString(120)> Public Charge As String
        <VBFixedString(120)> Public Institute As String
        <VBFixedString(120)> Public Celebration As String
        <VBFixedString(120)> Public Birth As String
        <VBFixedString(120)> Public Death As String
        <VBFixedString(120)> Public Otherparties As String
        <VBFixedString(120)> Public Othernames As String
        <VBFixedString(120)> Public Venerable As String
        <VBFixedString(120)> Public Beatified As String
        <VBFixedString(120)> Public Canonized As String
        <VBFixedString(120)> Public Heading As String
        <VBFixedString(120)> Public Patron As String
        <VBFixedString(120)> Public Link As String
        <VBFixedString(1200)> Public Biography As String
        <VBFixedString(120)> Public Image As String
        <VBFixedString(200)> Public Origin As String
    End Structure

    ' -------------------------------------------------------
    ' Déclaration de la fonction SHGetFileInfo dans la bibliothèque shell32.dll
    Public Const SHGFI_ICON As UInteger = &H100
    Public Const SHGFI_SMALLICON As UInteger = &H1
    Public Const SHGFI_USEFILEATTRIBUTES As UInteger = &H10

    <StructLayout(LayoutKind.Sequential)>
    Public Structure SHFILEINFO
        Public hIcon As IntPtr
        Public iIcon As Integer
        Public dwAttributes As UInteger
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)>
        Public szDisplayName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)>
        Public szTypeName As String
    End Structure

    <DllImport("Shell32.dll", CharSet:=CharSet.Unicode)>
    Public Function SHGetFileInfo(pszPath As String, dwFileAttributes As UInteger, ByRef psfi As SHFILEINFO, cbFileInfo As UInteger, uFlags As UInteger) As IntPtr
    End Function

    Public Property ID As Long
    Public Property Position As Integer
    Public Property Pointer As Long
    Public Property Changed As Boolean
    Public Property FileNameImage As String
    Public Property Bloqué As Boolean

    Public bIsModified As Boolean = False
    Public bNeedsFurtherProcessing As Boolean = False

    Public CurrentNode As TreeNode
    Public userInput As String

    Public Function GetImgOFD(Frm As Form, PicBx As PictureBox) As Bitmap

        Dim _ErrBitmap As Bitmap = DocumentError_16x
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

    Public Sub FileListManager()

        ' Liste des fichiers créés avec leurs chemins
        Dim CreatedFiles As New List(Of String)

    End Sub

    ' Ajouter un fichier à la liste
    Public Sub AddFile(filePath As String)

        CreatedFiles.Add(filePath)

    End Sub

    ' Tableau des longueurs fixes des champs dans la structure Article
    Public ReadOnly LongueursChamps As Integer() = {
        18,   ' Title
        90,   ' Name
        120,  ' Charge
        120,  ' Institute
        120,  ' Celebration
        120,  ' Birth
        120,  ' Death
        120,  ' Otherparties
        120,  ' Othernames
        120,  ' Venerable
        120,  ' Beatified
        120,  ' Canonized
        120,  ' Heading
        120,  ' Patron
        120,  ' Link
        1200, ' Biography
        120,  ' Image
        200   ' Origin
    }

End Module
