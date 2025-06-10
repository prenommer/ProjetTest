Imports System.Runtime.InteropServices

Public Class IconExtractor

    <DllImport("shell32.dll", CharSet:=CharSet.Unicode)>
    Private Shared Function ExtractIconEx(lpszFile As String, nIconIndex As Integer, ByRef phiconLarge As IntPtr, ByRef phiconSmall As IntPtr, nIcons As UInteger) As UInteger
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function DestroyIcon(hIcon As IntPtr) As Boolean
    End Function

    Public Shared Function ExtractIconFromFile(filePath As String) As Icon

        Try
            Dim largeIcon As IntPtr
            Dim smallIcon As IntPtr

            ' Extract the first icon (index 0) from the file
            Dim unused = ExtractIconEx(filePath, 0, largeIcon, smallIcon, 1)

            ' Check if the small icon is available, otherwise use the large icon
            Dim iconHandle As IntPtr = If(smallIcon <> IntPtr.Zero, smallIcon, largeIcon)

            Return If(iconHandle <> IntPtr.Zero, Icon.FromHandle(iconHandle), Nothing)

        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Shared Function GetDefaultIcon() As Icon

        Try
            Dim defaultIconPath As String = "C:\Prenommer\librairie.ico" ' Chemin vers votre icône par défaut

            Return If(IO.File.Exists(defaultIconPath), New Icon(defaultIconPath), Nothing)

        Catch ex As Exception
            Return Nothing
        End Try

    End Function

End Class


