Imports System.Security.Cryptography

Friend Module CryptoConstants

    ' Générer une clé de chiffrement AES de 256 bits (32 octets)
    Public Function GenerateRandomKey() As String

        Dim keyBytes(31) As Byte
        Using rng As New RNGCryptoServiceProvider()
            rng.GetBytes(keyBytes)
        End Using
        Return BitConverter.ToString(keyBytes).Replace("-", "")

    End Function

    ' Générer un vecteur d'initialisation AES de 128 bits (16 octets)
    Public Function GenerateRandomIV() As String

        Dim ivBytes(15) As Byte
        Using rng As New RNGCryptoServiceProvider()
            rng.GetBytes(ivBytes)
        End Using
        Return BitConverter.ToString(ivBytes).Replace("-", "")

    End Function

    ' Constantes pour la clé et le vecteur d'initialisation
    Public Const MyEncryptionKey As String = "360F546179B41CF9E0565C9FCC66DDDC8A109C0060F112A0704A960DDF414DBC" ' Remplacer par GenerateRandomKey()
    Public Const MyInitializationVector As String = "42FF8795E76318A476A78B80378C6364" ' Remplacer par GenerateRandomIV()

End Module
