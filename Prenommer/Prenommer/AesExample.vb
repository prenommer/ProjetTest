Imports System.IO
Imports System.Security.Cryptography

Public Class AesExample

    Public Shared Sub Main()

        ' Chemin vers le fichier log à chiffrer.
        Dim logFilePath As String = $"{My.Application.Info.DirectoryPath}\Resources\logfile.txt"

        ' Vérifier si le fichier existe
        If File.Exists(logFilePath) Then
            ' Lire le contenu du fichier
            Dim logContent As String = File.ReadAllText(logFilePath)

            ' Vérifier si le contenu du fichier n'est pas vide
            If Not String.IsNullOrEmpty(logContent) Then
                ' Create a new instance of the Aes
                ' class.  This generates a new key and initialization 
                ' vector (IV).
                Using myAes As Aes = Aes.Create()
                    ' Assigner la clé (Key) et le vecteur d'initialisation (IV) aux variables déclarées
                    Dim aesKey As Byte() = myAes.Key
                    Dim iv As Byte() = myAes.IV

                    ' Appeler la fonction pour chiffrer le contenu
                    Dim encryptedBytes As Byte() = EncryptStringToBytes_Aes(logContent, aesKey, iv)

                    ' Decrypt the bytes to a string.
                    Dim decryptedContent As String = DecryptStringFromBytes_Aes(encryptedBytes, aesKey, iv)

                    'Display the original data and the decrypted data.
                    Dim unused = MessageBox.Show(String.Format("Contenu original : {0}", logContent))
                    Dim unused1 = MessageBox.Show(String.Format("Contenu déchiffré : {0}", decryptedContent))
                End Using
            Else
                ' Gérer le cas où le fichier est vide
                Dim unused2 = MessageBox.Show("Le fichier log est vide.")
            End If
        Else
            ' Gérer le cas où le fichier n'existe pas
            Dim unused3 = MessageBox.Show("Le fichier log n'existe pas.")
        End If

    End Sub

    Public Shared Function EncryptStringToBytes_Aes(plainText As String, Key() As Byte, IV() As Byte) As Byte()

        ' Check arguments.
        'If plainText Is Nothing OrElse plainText.Length <= 0 Then
        'Throw New ArgumentNullException("plainText")
        'End If
        If Key Is Nothing OrElse Key.Length <= 0 Then
            Throw New ArgumentNullException("Key")
        End If
        If IV Is Nothing OrElse IV.Length <= 0 Then
            Throw New ArgumentNullException("IV")
        End If
        Dim encrypted() As Byte

        ' Create an Aes object
        ' with the specified key and IV.
        Using aesAlg As Aes = Aes.Create()

            aesAlg.Key = Key
            aesAlg.IV = IV

            ' Create an encryptor to perform the stream transform.
            Dim encryptor As ICryptoTransform = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV)
            ' Create the streams used for encryption.
            Using msEncrypt As New MemoryStream()
                Using csEncrypt As New CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)
                    Using swEncrypt As New StreamWriter(csEncrypt)
                        'Write all data to the stream.
                        swEncrypt.Write(plainText)
                    End Using
                    encrypted = msEncrypt.ToArray()
                End Using
            End Using
        End Using

        ' Return the encrypted bytes from the memory stream.
        Return encrypted

    End Function

    Public Shared Function DecryptStringFromBytes_Aes(cipherText() As Byte, Key() As Byte, IV() As Byte) As String

        ' Check arguments.
        If cipherText Is Nothing OrElse cipherText.Length <= 0 Then
            Throw New ArgumentNullException("cipherText")
        End If
        If Key Is Nothing OrElse Key.Length <= 0 Then
            Throw New ArgumentNullException("Key")
        End If
        If IV Is Nothing OrElse IV.Length <= 0 Then
            Throw New ArgumentNullException("IV")
        End If
        ' Declare the string used to hold
        ' the decrypted text.
        Dim plaintext As String = Nothing

        ' Create an Aes object
        ' with the specified key and IV.
        Using aesAlg As Aes = Aes.Create()
            aesAlg.Key = Key
            aesAlg.IV = IV

            ' Create a decryptor to perform the stream transform.
            Dim decryptor As ICryptoTransform = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV)

            ' Create the streams used for decryption.
            Using msDecrypt As New MemoryStream(cipherText)

                Using csDecrypt As New CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)

                    Using srDecrypt As New StreamReader(csDecrypt)

                        ' Read the decrypted bytes from the decrypting stream
                        ' and place them in a string.
                        plaintext = srDecrypt.ReadToEnd()
                    End Using
                End Using
            End Using
        End Using

        Return plaintext

    End Function

End Class