' Was noch kommt:
' Gambling
' 
'
'
'
'
' 
'

Option Strict On
Option Explicit On
Imports System.ComponentModel.Design
Imports System.Console
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography.X509Certificates
Imports System.Threading

Module Module1

    Sub Main()


        ' Mode Variables
        Dim admin, user, relaunch As Boolean
        Dim userselect, encrypt1 As String
        ' Personal Variables
        Dim name As String
        ' Version Variables
        Dim version As String
        ' Auswahl Variables
        Dim auswahl As String
        Dim auswahlVWL, auswahlBWL As Boolean
        Dim auswahlVWLThema, auswahlELASThema As Byte

        ' Berechnung der Preiselastizität der Nachfrage Variables
        Dim ursprungsPreis, neuerPreis As Single
        Dim ursprungsMenge, neueMenge As Single
        Dim prozNachfÄnderung, prozEinkoÄnderung As Short
        Dim EE As Single
        Dim Elastizität, NormalInferior As String
        Dim EP As Integer

        version = "Beta 1.12.24"



        ' Launch Animation 1.0
        relaunch = True
        Do While relaunch = True
            relaunch = False
            Write("╠")
            For i = 1 To 25
                Thread.Sleep(125)
                Write("╤")
                i += 1
            Next
            Write("╣")

            Thread.Sleep(250)

            'Begrüßung
            Console.ForegroundColor = ConsoleColor.DarkYellow
            Write("INITIATING FreddyCalc")
            Console.ForegroundColor = ConsoleColor.Black
            Write(" ")
            Console.ForegroundColor = ConsoleColor.Cyan
            Write(version)
            Console.ForegroundColor = ConsoleColor.Gray
            Write(" ")

            Thread.Sleep(250)

            ' Launch Animation 1.1
            Write("╠")
            For i = 1 To 25
                Thread.Sleep(125)
                Write("╤")
                i += 1
            Next
            Write("╣")

            WriteLine()
            WriteLine()



            ' Abfrage Admin or User
            WriteLine("Gib etwas ein, um den Rechner zu starten!")
            userselect = ReadLine()
            encrypt1 = Left(userselect, 3) + Right(userselect, 3) + "barsch"
            Console.Clear()

            If userselect = encrypt1 Then
                admin = True
                user = False
            Else
                admin = False
                user = True
            End If



            ' Frage an Nutzer und Auswahl zwischen VWL / BWL etc.

            If user = True Then
                WriteLine("Um welches Oberthema handelt es sich? [VWL/BWL]")
                auswahl = ReadLine()
            ElseIf admin = True Then
                WriteLine("Welcome Freddy!")
                auswahl = ReadLine()
            End If

            Select Case auswahl
                Case "VWL", "Vwl", "vWl", "vwL", "vwl" ' Input.ToLower
                    auswahlVWL = True
                    Console.Clear()
                Case "BWL", "Bwl", "bWl", "bwL", "bwl"
                    auswahlBWL = True
                    Console.Clear()
            End Select




            ' Nutzer wählt VWL

            If auswahlVWL = True Then
                Console.ForegroundColor = ConsoleColor.DarkYellow
                WriteLine("Gewähltes Oberthema: VWL")
                WriteLine("Wähle eines der folgenden Themen:")
                WriteLine("1: Elastizitäten")
                WriteLine("2: Soon")
                Console.ForegroundColor = ConsoleColor.Gray
                auswahlVWLThema = CByte(ReadLine())
                Console.Clear()

                Select Case auswahlVWLThema
                    Case 1
                        Console.ForegroundColor = ConsoleColor.DarkYellow
                        WriteLine("Elastizitäten, welcher Art?")
                        WriteLine("1: Preiselastizität der Nachfrage")
                        WriteLine("2: Einkommenselastizität der Nachfrage")
                        Console.ForegroundColor = ConsoleColor.Gray
                        auswahlELASThema = CByte(ReadLine())
                        Console.Clear()

                        Select Case auswahlELASThema
                            Case 1
                                WriteLine("Preiselastizität der Nachfrage:")
                                WriteLine("Bitte gib den Ursprungspreis ein!")
                                ursprungsPreis = CSng(ReadLine())
                                Console.Clear()
                                WriteLine("Bitte gib den neuen Preis ein!")
                                neuerPreis = CSng(ReadLine())
                                Console.Clear()
                                WriteLine("Bitte gib die alte Menge ein!")
                                ursprungsMenge = CSng(ReadLine())
                                Console.Clear()
                                WriteLine("Bitte gib die neue Menge ein!")
                                neueMenge = CSng(ReadLine())
                                Console.Clear()

                                ' Falls Fehleingabe
                                If ursprungsMenge = neueMenge Or ursprungsPreis = neuerPreis Then
                                    WriteLine("Fehler: Sowohl Preis als auch Menge müssen sich verändert haben! Bitte starte den Rechner neu.")
                                    Thread.Sleep(10000)
                                    End
                                End If

                                EP = CInt(((((ursprungsMenge - neueMenge) / ursprungsMenge) * 100) / (((neuerPreis - ursprungsPreis) / ursprungsPreis) * 100)))

                                If EP > 0 And EP < 1 Then
                                    Elastizität = "UNELASTISCH"
                                ElseIf EP > 1 Then
                                    Elastizität = "ELASTISCH"
                                ElseIf EP <= 0 Then
                                    Elastizität = "VOLLKOMMEN UNELASTISCH"
                                End If

                                Console.ForegroundColor = ConsoleColor.DarkYellow
                                Write("Die Preiselastizität der Nachfrage ist in diesem Fall: " + Elastizität + " ")
                                Write("(Errechneter Wert: ")
                                Write(EP)
                                WriteLine(")")
                                Console.ForegroundColor = ConsoleColor.Gray
                                WriteLine("[anykey] zum fortfahren")
                                ReadLine()
                                Console.Clear()
                                relaunch = True


                            Case 2
                                WriteLine("Einkommenselastizität der Nachfrage:")
                                WriteLine("Bitte gib die prozentuale Nachfrageänderung ein:")
                                prozNachfÄnderung = CShort(ReadLine())
                                ' Falls Fehleingabe
                                Do Until prozNachfÄnderung <> 0
                                    WriteLine("Sie darf nicht 0 sein! Bitte gib eine andere Zahl ein.")
                                    prozNachfÄnderung = CShort(ReadLine())
                                Loop
                                Console.Clear()
                                WriteLine("Bitte gib die prozentuale Einkommensänderung ein:")
                                prozEinkoÄnderung = CShort(ReadLine())
                                Console.Clear()

                                EE = CSng(prozNachfÄnderung / prozEinkoÄnderung)

                                If EE > 0 Then
                                    Write("Das Gut ist ein NORMALES Gut")
                                    Write(" (")
                                    Write(EE)
                                    WriteLine(") ")
                                    WriteLine("[anykey] zum fortfahren")
                                    ReadLine()
                                    Console.Clear()
                                    relaunch = True
                                ElseIf EE < 0 Then
                                    Write("Das Gut ist ein INFERIORES Gut")
                                    Write(" (")
                                    Write(EE)
                                    WriteLine(") ")
                                    WriteLine("[anykey] zum fortfahren")
                                    ReadLine()
                                    Console.Clear()
                                    relaunch = True
                                End If


                        End Select
                    Case 2
                        Console.ForegroundColor = ConsoleColor.DarkYellow
                        WriteLine("Es wurde Nummer 2 gewählt, bitte folge dem Piloten!")
                        Console.ForegroundColor = ConsoleColor.Gray


                        ReadLine()

                End Select
            ElseIf auswahlBWL = True Then

            End If



            ' Nutzer wählt BWL

            If auswahlBWL = True Then
                Console.ForegroundColor = ConsoleColor.DarkYellow
                WriteLine("Gewähltes Oberthema: BWL")
                Console.ForegroundColor = ConsoleColor.Gray


                ReadLine()
            End If



        Loop

    End Sub

End Module
