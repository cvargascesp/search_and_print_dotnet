Imports System
Imports System.IO

Module Program
    Sub Main(args As String())
        Dim RUTA As String = String.Empty
        Dim IMPRESORA As String = String.Empty
        Dim ACROBAT_EXE_PATH As String = String.Empty
        Dim clArgs() As String = Environment.GetCommandLineArgs()
        For i As Integer = 1 To clArgs.Length - 1
            'Console.WriteLine("revisando parametro :" + i.ToString() + "  VALOR:" + clArgs(i).ToString)
            If i = 1 Then
                RUTA = clArgs(i).ToString
            End If
            If i = 2 Then
                IMPRESORA = clArgs(i).ToString
            End If

            If i = 3 Then
                ACROBAT_EXE_PATH = clArgs(i).ToString
            End If
        Next

        Console.WriteLine("RUTA a revisar: " + RUTA)
        Dim fileEntries As String() = Directory.GetFiles(RUTA, "*.pdf")
        Dim fileName As String
        Dim Process1 As New Process
        For Each fileName In fileEntries
            If (System.IO.File.Exists(fileName)) Then
                Console.WriteLine(fileName)


                Dim psi As New ProcessStartInfo(ACROBAT_EXE_PATH, "/t " + fileName + "  " + IMPRESORA + " ")
                psi.CreateNoWindow = True
                Process1.Start(psi)
                Threading.Thread.Sleep(5000)


            End If
        Next
        Process1.Kill()


    End Sub
End Module
