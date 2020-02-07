Imports System.ComponentModel
Imports System.IO
Imports Microsoft.Office.Interop
Imports System.Net.Sockets

Public Class AsimovMain

    Public ServerMSG As String
    Public DirectoryArray() As String
    Public LogonID As String
    Public splitvalues() As String
    Public Incomes() As String
    Public WorkerStatus As Integer




    Private Sub HeyItsTimeToLoad() Handles Me.Shown

        SplashScreen.Show()
        ListBox1.Items.Clear()
        ActionsGroupBox.Enabled = False
        LoadDirectory.RunWorkerAsync()

    End Sub

    Public Function ServerCommand(ByVal ClientMSG As String) As String

        Dim tc As TcpClient = New TcpClient()
        Dim ns As NetworkStream
        Dim br As BinaryReader
        Dim bw As BinaryWriter


        ServerMSG = "E"

        If String.IsNullOrEmpty(ClientMSG) Then
            Return "E"
        End If

        Try
            tc.Connect(“IGTNET-W.DDNS.NET”, 757)
            Exit Try

        Catch
            MsgBox("Unable to connect to the server.", MsgBoxStyle.Exclamation, "ViBE Error")
            ServerCommand = "NOCONNECT"
            Exit Function

        End Try



        If tc.Connected = True Then
            ns = tc.GetStream
            br = New BinaryReader(ns)
            bw = New BinaryWriter(ns)

            bw.Write(ClientMSG)

            Try
                ServerMSG = br.ReadString()
            Catch
                MsgBox("Seems like the server might've crashed! Contact CHOPO!", MsgBoxStyle.Exclamation, "ViBE Error")
                ServerCommand = "CRASH"
                Exit Function

            End Try


            tc.Close()

        End If

        ServerCommand = ServerMSG

    End Function

    Private Sub DoTheCosos() Handles LoadDirectory.DoWork
        ServerMSG = ServerCommand("DIR")
        DirectoryArray = ServerMSG.Split(",")
    End Sub

    Private Sub DisplayTheCosos() Handles LoadDirectory.RunWorkerCompleted
        Dim Counter1 As Integer
        ListBox1.MultiColumn = False
        For Counter1 = 0 To DirectoryArray.Count - 1
            ListBox1.Items.Add(DirectoryArray(Counter1))
        Next

        ListBox1.Visible = True
        SplashScreen.Close()

    End Sub

    Private Sub OhItChanged() Handles ListBox1.SelectedIndexChanged
        LogonID = ListBox1.SelectedItem.ToString.Remove(5, ListBox1.SelectedItem.ToString.Length - 5)
        UserLoad.Show()
        ListBox1.Enabled = False
        AddFundsBTN.Enabled = False
        ModIncomeBTN.Enabled = False
        ChangePinBTN.Enabled = False
        RefreshBTN.Enabled = False

        ActionsGroupBox.Enabled = False

        LoadUser.RunWorkerAsync()

    End Sub

    Private Sub LoadUser_DoWork(sender As Object, e As DoWorkEventArgs) Handles LoadUser.DoWork

        WorkerStatus = 0
        LoadUser.ReportProgress(0)

        ServerMSG = ServerCommand("INFO" & LogonID)

        WorkerStatus = 1
        LoadUser.ReportProgress(1)

        splitvalues = ServerMSG.Split(",")
        ServerMSG = ServerCommand("EZTINF" & LogonID)

        WorkerStatus = 2
        LoadUser.ReportProgress(2)

        If ServerMSG = "E" Then
            MsgBox("There has been a serverside error. Please Contact CHOPO.", vbCritical, "ASIMOV cannot continue")
            Close()
        End If
        Incomes = ServerMSG.Split(",")

    End Sub

    Private Sub AreWeThereYet() Handles LoadUser.ProgressChanged
        Select Case WorkerStatus
            Case 0
                UserLoad.StatusLabel.Text = "Retrieving Bank Balances"

            Case 1
                UserLoad.StatusLabel.Text = "Retrieving Tax Information"

            Case 2
                UserLoad.StatusLabel.Text = "Displaying Information"

            Case Else
                UserLoad.StatusLabel.Text = "The Background Worker is doing ALGO"

        End Select

    End Sub

    Private Sub LoadUser_RunWorkerCompleted() Handles LoadUser.RunWorkerCompleted
        Dim TotalBalance As Long
        Dim Username As String
        Dim UMSNB As Boolean
        Dim GBANK As Boolean
        Dim RIVER As Boolean
        Dim UMSNBBalance As Long
        Dim GBANKBalance As Long
        Dim RIVERBalance As Long
        Dim corporate As Boolean

        If splitvalues(0) = 1 Then UMSNB = True Else UMSNB = False
        UMSNBBalance = splitvalues(1)
        If splitvalues(2) = 1 Then GBANK = True Else GBANK = False
        GBANKBalance = splitvalues(3)
        If splitvalues(4) = 1 Then RIVER = True Else RIVER = False
        RIVERBalance = splitvalues(5)
        Username = splitvalues(6)
        If Username.EndsWith("(Corp.)") Then
            Username = Username.Replace(" (Corp.)", "")
            corporate = True
        Else
            corporate = False
        End If

        CorporateCHKBX.Checked = corporate


        UMSNBCheck.Checked = UMSNB
        GBANKCheck.Checked = GBANK
        RIVERCheck.Checked = RIVER

        UMSNBBLabel.Text = UMSNBBalance.ToString("N0") & "p"
        GBANKBLabel.Text = GBANKBalance.ToString("N0") & "p"
        RIVERBLabel.Text = RIVERBalance.ToString("N0") & "p"

        TotalBalance = UMSNBBalance + GBANKBalance + RIVERBalance
        TotalBLabel.Text = TotalBalance.ToString("N0") & "p"

        NameLabel.Text = Username & " (" & LogonID & ")"


        Dim Income As Long
        Dim EI As Long
        Dim TaxBracket As String
        Dim Tax As Long
        Dim Total As Long


        Income = Incomes(0)
        EI = Incomes(1)

        Total = Income + EI

        If corporate Then

            If Total > 500000000 Then
                Tax = Total * 0.02
                TaxBracket = "Corporate Taxed (2%)"
            Else
                Tax = 0
                TaxBracket = "Corporate Exempt (0%)"
            End If

        Else
            If Total > 5000000 Then
                Tax = Total * 0.05
                TaxBracket = "Personal Taxed (5%)"
            Else
                Tax = 0
                TaxBracket = "Personal Exempt (0%)"
            End If

        End If



        IncomeLabel.Text = Income.ToString("N0") & "p"
        EILabel.Text = EI.ToString("N0") & "p"
        TotalLabel.Text = Total.ToString("N0") & "p"
        TaxBracketLabel.Text = TaxBracket
        TaxDueLabel.Text = Tax.ToString("N0") & "p"


        UserLoad.Close()
        AddFundsBTN.Enabled = True
        ModIncomeBTN.Enabled = True
        ChangePinBTN.Enabled = True
        RefreshBTN.Enabled = True
        ListBox1.Enabled = True

        ActionsGroupBox.Enabled = True
    End Sub
    ''' <summary>
    ''' Renders a fancier input box
    ''' </summary>
    ''' <param name="Prompt">The prompt of the InputBox</param>
    ''' <returns></returns>
    Shared Function FancyInputBox(ByVal Prompt As String, Optional ByVal maxstringlength As Integer = 999999) As String

        InputForm.PromptLBL.Text = Prompt
        InputForm.Answer.Text = ""
        InputForm.Answer.MaxLength = maxstringlength


        Select Case InputForm.ShowDialog()
            Case DialogResult.OK
                FancyInputBox = InputForm.Answer.Text
            Case DialogResult.Cancel
                FancyInputBox = "CANCEL"
            Case Else
                FancyInputBox = "CANCEL"
        End Select

    End Function

    Private Sub RefreshBTN_Click(sender As Object, e As EventArgs) Handles RefreshBTN.Click
        OhItChanged()
    End Sub

    Private Sub AddFundsBTN_Click(sender As Object, e As EventArgs) Handles AddFundsBTN.Click
        Dim AmountSTR As String
        Dim Amount As Long

        Try
            AmountSTR = FancyInputBox("Amount to add:")
            If AmountSTR = "CANCEL" Then Exit Sub
            Amount = CInt(AmountSTR)
        Catch
            MsgBox("Invalid input specified", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End Try


        Select Case ServerCommand("NTA" & LogonID & Amount)
            Case "E"
                MsgBox("Could not add amount", vbCritical, "ASIMoV")

            Case "S"
                MsgBox("Added amount succesfully", vbInformation, "ASIMoV")

        End Select


    End Sub

    Private Sub ModIncomeBTN_Click(sender As Object, e As EventArgs) Handles ModIncomeBTN.Click
        Dim AmountSTR As String
        Dim Amount As Long

        Try
            AmountSTR = FancyInputBox("New Income:")
            If AmountSTR = "CANCEL" Then Exit Sub
            Amount = CInt(AmountSTR)
        Catch
            MsgBox("Invalid input specified", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End Try

        Select Case ServerCommand("EZTUPD" & LogonID & Amount)
            Case "E"
                MsgBox("Could not update income", vbCritical, "ASIMoV")

            Case "S"
                MsgBox("Updated income succesfully", vbInformation, "ASIMoV")
        End Select



    End Sub

    Private Sub ChangePinBTN_Click(sender As Object, e As EventArgs) Handles ChangePinBTN.Click
        Dim NewPin As String

        Try
            NewPin = FancyInputBox("New Pin:", 4)
            If NewPin = "CANCEL" Then Exit Sub
            If Not NewPin.Length = 4 Then
                MsgBox("Invalid input specified", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If
        Catch
            MsgBox("Invalid input specified", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End Try


        Select Case ServerCommand("CP" & LogonID & NewPin)
            Case "1"
                MsgBox("Improperly Coded Change Pin Request", vbInformation, "Change Pin Notice")
            Case "2"
                MsgBox("Could not complete pin change", vbInformation, "Change Pin Notice")
            Case "S"
                MsgBox("Pin Changed Successfully", vbInformation, "Change Pin Notice")
        End Select

    End Sub

    Private Sub GenericBackgroundWorker_DoWork(sender As Object, e As DoWorkEventArgs) Handles GenericBackgroundWorker.DoWork

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GenerateReport.ShowDialog()
    End Sub

    Private Sub DoTheCosos(sender As Object, e As DoWorkEventArgs) Handles LoadDirectory.DoWork

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim OpenFile As New OpenFileDialog With {
            .InitialDirectory = My.Application.Info.DirectoryPath,
            .Multiselect = False,
            .FileName = "AsIMOV Report (XX-XX-20XX XX-XX-XX PM).csv",
            .DefaultExt = ".csv",
            .Filter = "Asimov Reports (*.csv)|*.csv"
        }

        Dim DoTheDo As Boolean = OpenFile.ShowDialog()

        If DoTheDo Then
            ConvertReport(OpenFile.FileName)

        End If
        OpenFile.Dispose()
    End Sub

    Public Shared Sub ConvertReport(Filename As String)

        'Now lets make an excel
        Dim ExcelApp As Excel._Application
        Dim ExcelBook As Excel._Workbook
        Dim CurrentWorksheet As Excel._Worksheet
        Dim SelectedRange As Excel.Range


        ExcelApp = New Excel.Application()
        ExcelApp.Workbooks.Add()
        ExcelBook = ExcelApp.Workbooks(1)
        CurrentWorksheet = ExcelBook.Sheets(1)


        ExcelApp.Visible = True

        SelectedRange = CurrentWorksheet.Range("A1", "L1")
        SelectedRange.Merge()
        SelectedRange.Value = "Reading report..."


        'open the file and Retrieve the INfo

        FileOpen(1, Filename, OpenMode.Input)
        LineInput(1)
        Dim ReportDate As String = LineInput(1)
        LineInput(1)
        LineInput(1)
        LineInput(1)

        Dim UsersArrayList As New ArrayList

        While Not EOF(1)
            UsersArrayList.Add(LineInput(1))
        End While

        FileClose(1)

        'HEADERS
        SelectedRange.Value = "ASIMOV REPORT"
        SelectedRange.HorizontalAlignment = HorizontalAlignment.Center
        SelectedRange.VerticalAlignment = HorizontalAlignment.Center
        SelectedRange.Font.Bold = True
        SelectedRange.Font.Size = 20

        SelectedRange = CurrentWorksheet.Range("A2", "L2")
        SelectedRange.Merge()
        SelectedRange.Value = ReportDate
        SelectedRange.Font.Italic = True

        'TABLE SETUP

        'RegularHeaders
        CurrentWorksheet.Range("A5").Value = "ID"
        CurrentWorksheet.Range("B5").Value = "NAME"
        CurrentWorksheet.Range("C5").Value = "CORP."
        CurrentWorksheet.Range("D5").Value = "UMSNB"
        CurrentWorksheet.Range("E5").Value = "GBANK"
        CurrentWorksheet.Range("F5").Value = "RIVER"
        CurrentWorksheet.Range("G5").Value = "TOTAL"
        CurrentWorksheet.Range("H5").Value = "MONTHLY"
        CurrentWorksheet.Range("I5").Value = "EXTRA"
        CurrentWorksheet.Range("J5").Value = "TOTAL"
        CurrentWorksheet.Range("K5").Value = "%"
        CurrentWorksheet.Range("L5").Value = "AMOUNT"

        'AddData
        Dim Users As Integer = 0

        For Each CurrentUser As String In UsersArrayList
            If CurrentUser.StartsWith("T") Then Exit For
            Dim Doot() = CurrentUser.Split(",")
            Users += 1
            CurrentWorksheet.Range("A" & (5 + Users)).Value = Doot(0)
            CurrentWorksheet.Range("B" & (5 + Users)).Value = Doot(1)
            If Doot(2) Then
                CurrentWorksheet.Range("C" & (5 + Users)).Value = "✔"
            Else
                CurrentWorksheet.Range("C" & (5 + Users)).Value = ""
            End If

            CurrentWorksheet.Range("D" & (5 + Users)).Value = Doot(3)
            CurrentWorksheet.Range("E" & (5 + Users)).Value = Doot(4)
            CurrentWorksheet.Range("F" & (5 + Users)).Value = Doot(5)
            CurrentWorksheet.Range("G" & (5 + Users)).Value = Doot(6)
            CurrentWorksheet.Range("H" & (5 + Users)).Value = Doot(7)
            CurrentWorksheet.Range("I" & (5 + Users)).Value = Doot(8)
            CurrentWorksheet.Range("J" & (5 + Users)).Value = Doot(9)
            CurrentWorksheet.Range("K" & (5 + Users)).Value = Doot(10)
            CurrentWorksheet.Range("L" & (5 + Users)).Value = Doot(11)

        Next

        'TOTALS
        CurrentWorksheet.Range("A" & (5 + Users + 1)).Value = "TOTAL:"
        CurrentWorksheet.Range("D" & (5 + Users + 1)).Value = "=SUM(D6:D" & (5 + Users) & ")"
        CurrentWorksheet.Range("E" & (5 + Users + 1)).Value = "=SUM(E6:E" & (5 + Users) & ")"
        CurrentWorksheet.Range("F" & (5 + Users + 1)).Value = "=SUM(F6:F" & (5 + Users) & ")"
        CurrentWorksheet.Range("G" & (5 + Users + 1)).Value = "=SUM(G6:G" & (5 + Users) & ")"
        CurrentWorksheet.Range("H" & (5 + Users + 1)).Value = "=SUM(H6:H" & (5 + Users) & ")"
        CurrentWorksheet.Range("I" & (5 + Users + 1)).Value = "=SUM(I6:I" & (5 + Users) & ")"
        CurrentWorksheet.Range("J" & (5 + Users + 1)).Value = "=SUM(J6:J" & (5 + Users) & ")"
        CurrentWorksheet.Range("L" & (5 + Users + 1)).Value = "=SUM(L6:L" & (5 + Users) & ")"

        'NUMBER FORMATS
        CurrentWorksheet.Range("D6", "J" & (5 + Users + 1)).NumberFormat = "$#,##0.00"
        CurrentWorksheet.Range("L6", "L" & (5 + Users + 1)).NumberFormat = "$#,##0.00"
        CurrentWorksheet.Range("K6", "K" & (5 + Users + 1)).NumberFormat = "0.00%"

        'AUTOFIT
        CurrentWorksheet.Columns("A:L").AutoFit()

        'TABLE
        Dim IdentifierTable = CurrentWorksheet.ListObjects.AddEx(Excel.XlListObjectSourceType.xlSrcRange, CurrentWorksheet.Range("A5", "L" & (5 + Users)),, Excel.XlYesNoGuess.xlYes)
        IdentifierTable.Name = "IdentifierTable"
        IdentifierTable.TableStyle = "TableStyleDark7"

        CurrentWorksheet.Range("A" & (6 + Users), "L" & (6 + Users)).Interior.Color = Color.Black
        CurrentWorksheet.Range("A" & (6 + Users), "L" & (6 + Users)).Font.Color = Color.White


        'SuperHeaders
        SelectedRange = CurrentWorksheet.Range("A4", "C4")
        SelectedRange.Merge()
        SelectedRange.Value = "IDENTIFIERS"
        SelectedRange.Font.Color = Color.White
        SelectedRange.Interior.Color = Color.Black
        SelectedRange.Font.Bold = True
        SelectedRange.Font.Italic = True

        SelectedRange = CurrentWorksheet.Range("D4", "G4")
        SelectedRange.Merge()
        SelectedRange.Value = "BANK BALANCES"
        SelectedRange.Font.Color = Color.White
        SelectedRange.Interior.Color = Color.Black
        SelectedRange.Font.Bold = True
        SelectedRange.Font.Italic = True

        SelectedRange = CurrentWorksheet.Range("H4", "J4")
        SelectedRange.Merge()
        SelectedRange.Value = "INCOME"
        SelectedRange.Font.Color = Color.White
        SelectedRange.Interior.Color = Color.Black
        SelectedRange.Font.Bold = True
        SelectedRange.Font.Italic = True

        SelectedRange = CurrentWorksheet.Range("K4", "L4")
        SelectedRange.Merge()
        SelectedRange.Value = "TAX"
        SelectedRange.Font.Color = Color.White
        SelectedRange.Interior.Color = Color.Black
        SelectedRange.Font.Bold = True
        SelectedRange.Font.Italic = True

        CurrentWorksheet.Range("D5", "D" & (5 + Users)).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
        CurrentWorksheet.Range("D5", "D" & (5 + Users)).Borders(Excel.XlBordersIndex.xlEdgeLeft).Color = Color.Black

        CurrentWorksheet.Range("H5", "H" & (5 + Users)).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
        CurrentWorksheet.Range("H5", "H" & (5 + Users)).Borders(Excel.XlBordersIndex.xlEdgeLeft).Color = Color.Black

        CurrentWorksheet.Range("K5", "K" & (5 + Users)).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
        CurrentWorksheet.Range("K5", "K" & (5 + Users)).Borders(Excel.XlBordersIndex.xlEdgeLeft).Color = Color.Black

        ExcelApp.UserControl = True

    End Sub



End Class

