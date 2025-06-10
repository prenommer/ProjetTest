Imports System.Runtime.InteropServices

Public Class SimulationInput
    <DllImport("user32.dll", SetLastError:=True)>
    Public Shared Function SendInput(nInputs As UInteger, pInputs As INPUT(), cbSize As Integer) As UInteger
    End Function

    Public Structure INPUT
        Public type As Integer
        Public mkhi As MOUSEKEYBDHARDWAREINPUT
    End Structure

    <StructLayout(LayoutKind.Explicit)>
    Public Structure MOUSEKEYBDHARDWAREINPUT
        <FieldOffset(0)> Public mi As MOUSEINPUT
    End Structure

    Public Structure MOUSEINPUT
        Public dx As Integer
        Public dy As Integer
        Public mouseData As Integer
        Public dwFlags As Integer
        Public time As Integer
        Public dwExtraInfo As IntPtr
    End Structure

    Public Const INPUT_MOUSE As Integer = 0
    Public Const MOUSEEVENTF_LEFTDOWN As Integer = &H2
    Public Const MOUSEEVENTF_LEFTUP As Integer = &H4

    ' ✅ Définition correcte de SimulerClic
    Public Shared Sub SimulerClic(X As Integer, Y As Integer)
        Dim inputData(2) As INPUT ' Déclaration avec 3 éléments

        ' Déplacement du curseur (si nécessaire)
        inputData(0).type = INPUT_MOUSE
        inputData(0).mkhi.mi.dx = X
        inputData(0).mkhi.mi.dy = Y
        inputData(0).mkhi.mi.mouseData = 0
        inputData(0).mkhi.mi.dwFlags = &H1 ' MOUSEEVENTF_MOVE

        ' Clic gauche enfoncé
        inputData(1).type = INPUT_MOUSE
        inputData(1).mkhi.mi.dwFlags = MOUSEEVENTF_LEFTDOWN

        ' Clic gauche relâché
        inputData(2).type = INPUT_MOUSE
        inputData(2).mkhi.mi.dwFlags = MOUSEEVENTF_LEFTUP

        ' Envoi des événements
        Dim unused = SendInput(3, inputData, Marshal.SizeOf(GetType(INPUT)))

        ' Ajout d'une pause pour observer le comportement
        Threading.Thread.Sleep(100)
    End Sub

End Class