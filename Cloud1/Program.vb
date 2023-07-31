Imports System

Module Program

    Sub Main(args As String())
        Console.WriteLine("Application start")
        Do
            Console.WriteLine("Hello World davide3!")
            Threading.Thread.Sleep(1000)
        Loop Until False
        Console.WriteLine("Application end")
    End Sub

End Module
