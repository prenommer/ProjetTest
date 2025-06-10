Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Class EncryptionExample

    ' Clé et vecteur d'initialisation (IV). Assurez-vous de les conserver de manière sécurisée.
    Private Shared ReadOnly key As Byte() = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16}
    Private Shared ReadOnly iv As Byte() = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16}

    Public Shared Sub EncryptAndWriteToFile(originalText As String, filePath As String)

        ' Convertir la chaîne en tableau de bytes.
        Dim plaintextBytes As Byte() = Encoding.UTF8.GetBytes(originalText)

        ' Initialiser le chiffreur symétrique.
        Using aesAlg As New AesCryptoServiceProvider()
            aesAlg.Key = key
            aesAlg.IV = iv

            ' Créer un flux de mémoire pour stocker les données chiffrées.
            Using msEncrypt As New MemoryStream()
                ' Créer un flux de chiffrement en utilisant le chiffreur symétrique.
                Using csEncrypt As New CryptoStream(msEncrypt, aesAlg.CreateEncryptor(), CryptoStreamMode.Write)
                    ' Écrire les données chiffrées dans le flux de chiffrement.
                    csEncrypt.Write(plaintextBytes, 0, plaintextBytes.Length)
                    csEncrypt.FlushFinalBlock()

                    ' Écrire les données chiffrées dans le fichier.
                    File.WriteAllBytes(filePath, msEncrypt.ToArray())
                End Using
            End Using
        End Using

    End Sub

    Public Shared Function DecryptFromFile(filePath As String) As String

        ' Lire les données chiffrées du fichier.
        Dim ciphertextBytes As Byte() = File.ReadAllBytes(filePath)

        ' Initialiser le chiffreur symétrique.
        Using aesAlg As New AesCryptoServiceProvider()
            aesAlg.Key = key
            aesAlg.IV = iv

            ' Créer un flux de mémoire pour stocker les données déchiffrées.
            Using msDecrypt As New MemoryStream(ciphertextBytes)
                ' Créer un flux de déchiffrement en utilisant le chiffreur symétrique.
                Using csDecrypt As New CryptoStream(msDecrypt, aesAlg.CreateDecryptor(), CryptoStreamMode.Read)
                    ' Lire les données déchiffrées depuis le flux de déchiffrement.
                    Using srDecrypt As New StreamReader(csDecrypt)
                        Return srDecrypt.ReadToEnd()
                    End Using
                End Using
            End Using
        End Using

    End Function

End Class