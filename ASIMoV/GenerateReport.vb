Public Class GenerateReport
    Public Filename As String
    Public CurrentWorkerStatus As String
    Public CurrentWorkerStage As Integer
    Public CurrentWorkerPercentage As Integer
    Public WorkerCanceled As Boolean
    Sub OKTimeToGenerateTheReport() Handles Me.Shown
        OpenReportBTN.Enabled = False
        Size = MinimumSize
        Filename = "AsIMOV Report (" & DateTime.Now.ToString.Replace("/", "-").Replace(":", "-") & ").csv"
        MainLBL.Text = "Generating Report"
        PictureBox1.Image = My.Resources.XVo6
        DoTheCoso.RunWorkerAsync()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Size = MaximumSize Then
            Size = MinimumSize
            Button1.Text = "Details"
        Else
            Size = MaximumSize
            Button1.Text = "Hide Details"
        End If
    End Sub

    Sub ToDetailsTXB(doot As String)
        DetailsTextbBox.AppendText("[" & DateTime.Now & "] " & CurrentWorkerPercentage & "% " & doot & vbNewLine)
    End Sub

    Private Sub DoingTheCoso() Handles DoTheCoso.DoWork
        WorkerCanceled = False
        CurrentWorkerStage = 0
        CurrentWorkerStatus = "Preparing file " & Filename
        CurrentWorkerPercentage = 0
        DoTheCoso.ReportProgress(0)

        FileOpen(1, Filename, OpenMode.Output)
        PrintLine(1, "ASIMOV REPORT")
        PrintLine(1, DateTime.Now.ToLongDateString & " " & DateTime.Now.ToLongTimeString & ":")
        PrintLine(1, "")
        PrintLine(1, "")
        PrintLine(1, "ID,NAME,CORPORATE,UMSNB,GBANK,RIVER,TOTAL,MI,EI,TI,PERCENTAGE,TAX")

        If DoTheCoso.CancellationPending Then
            WorkerCanceled = True
            FileClose(1)
            Exit Sub
        End If

        CurrentWorkerStatus = "Retrieving Directory"
        DoTheCoso.ReportProgress(1)

        Dim ServerMSG As String
        Dim DirectoryArray As String()

        ServerMSG = AsimovMain.ServerCommand("DIR")
        DirectoryArray = ServerMSG.Split(",")

        If DoTheCoso.CancellationPending Then
            WorkerCanceled = True
            FileClose(1)
            Exit Sub
        End If

        Dim LogonID As String
        Dim SplitValues As String()
        Dim Incomes() As String
        Dim UMSNBTotalBalance As Long
        Dim GBANKTotalBalance As Long
        Dim RIVERTotalBalance As Long
        Dim AllTotalBalance As Long
        Dim AllMonthlyIncome As Long
        Dim AllExtraIncome As Long
        Dim AllTotalIncome As Long
        Dim AllTotalTax As Long

        UMSNBTotalBalance = 0
        GBANKTotalBalance = 0
        RIVERTotalBalance = 0
        AllTotalBalance = 0
        AllMonthlyIncome = 0
        AllExtraIncome = 0
        AllTotalIncome = 0
        AllTotalTax = 0

        Dim NonGovernmentAccounts = DirectoryArray.Count

        'For X = 0 To DirectoryArray.Count - 1
        'If DirectoryArray(X).EndsWith("(Gov.)") Then
        'do nothing
        'Else
        'NonGovernmentAccounts = NonGovernmentAccounts + 1
        'End If
        'Next

        Dim MeasuringTimeCoso As Stopwatch
        Dim TimeLeft As String
        TimeLeft = ""
        MeasuringTimeCoso = New Stopwatch

        For X = 0 To DirectoryArray.Count - 1
            'If DirectoryArray(X).EndsWith("(Gov.)") Then
            'GoTo GovernmentAccountSkip
            'End If
            LogonID = DirectoryArray(X).Remove(5, DirectoryArray(X).Length - 5)


            CurrentWorkerPercentage = CInt(((X + 0.3) / (NonGovernmentAccounts)) * 100)

            CurrentWorkerStage = 1
            CurrentWorkerStatus = "Retrieving balances for " & DirectoryArray(X) & ". " & TimeLeft
            DoTheCoso.ReportProgress(X)

            MeasuringTimeCoso.Start()
            ServerMSG = AsimovMain.ServerCommand("INFO" & LogonID)
            MeasuringTimeCoso.Stop()
            TimeLeft = "Approximately " & (CInt(MeasuringTimeCoso.ElapsedMilliseconds / 1000) * (((NonGovernmentAccounts - X - 1) * 2) + 1)) & "s to go."
            Debug.Print("Ellapsed Seconds: " & MeasuringTimeCoso.ElapsedMilliseconds)
            MeasuringTimeCoso.Reset()

            SplitValues = ServerMSG.Split(",")
            If DoTheCoso.CancellationPending Then
                WorkerCanceled = True
                FileClose(1)
                Exit Sub
            End If

            CurrentWorkerPercentage = CInt(((X + 0.6) / (NonGovernmentAccounts)) * 100)
            CurrentWorkerStage = 1
            CurrentWorkerStatus = "Retrieving Tax Information for " & DirectoryArray(X) & ". " & TimeLeft
            DoTheCoso.ReportProgress(X)

            MeasuringTimeCoso.Start()
            ServerMSG = AsimovMain.ServerCommand("EZTINF" & LogonID)
            MeasuringTimeCoso.Stop()
            TimeLeft = "Approximately " & (CInt(MeasuringTimeCoso.ElapsedMilliseconds / 1000) * (((NonGovernmentAccounts - X - 1) * 2))) & "s to go."
            Debug.Print("Ellapsed Seconds: " & MeasuringTimeCoso.ElapsedMilliseconds)
            MeasuringTimeCoso.Reset()

            Incomes = ServerMSG.Split(",")

            If DoTheCoso.CancellationPending Then
                WorkerCanceled = True
                FileClose(1)
                Exit Sub
            End If
            If ServerMSG = "E" Then
                WorkerCanceled = True
                Exit Sub
            End If

            CurrentWorkerPercentage = CInt(((X + 0.9) / (NonGovernmentAccounts)) * 100)
            CurrentWorkerStage = 1
            CurrentWorkerStatus = "Adding the info to the report"
            DoTheCoso.ReportProgress(X)

            Dim TotalBalance As Long
            Dim Username As String
            Dim UMSNBBalance As Long
            Dim GBANKBalance As Long
            Dim RIVERBalance As Long
            Dim corporate As Boolean
            Dim Government As Boolean

            UMSNBBalance = SplitValues(1)
            GBANKBalance = SplitValues(3)
            RIVERBalance = SplitValues(5)

            Username = SplitValues(6)
            If Username.EndsWith("(Corp.)") Then
                Username = Username.Replace(" (Corp.)", "")
                corporate = True
            Else
                corporate = False
            End If

            If Username.EndsWith("(Gov.)") Then
                Username = Username.Replace(" (Gov.)", "")
                Government = True
            Else
                Government = False
            End If


            TotalBalance = UMSNBBalance + GBANKBalance + RIVERBalance

            Dim Income As Long
            Dim EI As Long
            Dim Tax As Long
            Dim Total As Long
            Dim TaxPercentage As Single


            Income = Incomes(0)
            EI = Incomes(1)
            If Government Then
                Income = 0
                EI = 0
            End If

            Total = Income + EI

            If corporate Then

                If Total > 500000000 Then
                    Tax = Total * 0.02
                    TaxPercentage = 0.02
                Else
                    Tax = 0
                    TaxPercentage = 0
                End If

            ElseIf Government Then
                Tax = 0
                TaxPercentage = 0
            Else
                If Total > 5000000 Then
                    Tax = Total * 0.05
                    TaxPercentage = 0.05
                Else
                    Tax = 0
                    TaxPercentage = 0
                End If

            End If
            'PrintLine(1, "ID,NAME,CORPORATE,UMSNB,GBANK,RIVER,TOTAL,INCOME,PERCENTAGE,TAX")
            PrintLine(1, LogonID & "," & Username & "," & corporate.ToString & "," & UMSNBBalance & "," & GBANKBalance & "," & RIVERBalance & "," & TotalBalance & "," & Income & "," & EI & "," & Total & "," & TaxPercentage & "," & Tax)

            UMSNBTotalBalance += UMSNBBalance
            GBANKTotalBalance += GBANKBalance
            RIVERTotalBalance += RIVERBalance
            AllTotalBalance += TotalBalance
            AllMonthlyIncome += Income
            AllExtraIncome += EI
            AllTotalIncome += Total
            AllTotalTax += Tax
GovernmentAccountSkip:

        Next


        CurrentWorkerStage = 1
        CurrentWorkerStatus = "Finalizing Report"
        DoTheCoso.ReportProgress(90)
        'PrintLine(1, "ID,NAME,CORPORATE,UMSNB,GBANK,RIVER,TOTAL,MI,EI,PERCENTAGE,TAX")
        PrintLine(1, "Total:,,," & UMSNBTotalBalance & "," & GBANKTotalBalance & "," & RIVERTotalBalance & "," & AllTotalBalance & "," & AllMonthlyIncome & "," & AllExtraIncome & "," & AllTotalIncome & ",," & AllTotalTax)
        FileClose(1)
    End Sub

    Private Sub ReportingTheCoso() Handles DoTheCoso.ProgressChanged
        StatusLBL.Text = CurrentWorkerStatus
        ToDetailsTXB(CurrentWorkerStatus)
        ProgressBar1.Value = CurrentWorkerPercentage
        Select Case CurrentWorkerStatus
            Case 0
                ProgressBar1.Style = ProgressBarStyle.Marquee
            Case 1
                ProgressBar1.Style = ProgressBarStyle.Continuous
            Case 2

        End Select
    End Sub

    Private Sub DoneWithTheCoso() Handles DoTheCoso.RunWorkerCompleted
        If WorkerCanceled Then
            MainLBL.Text = "Report Canceled!"
            If IO.File.Exists(Filename) Then IO.File.Delete(Filename)
        Else
            MainLBL.Text = "Report Generated!"
            StatusLBL.Text = ""
            OpenReportBTN.Enabled = True
        End If
        ProgressBar1.Value = 0
        Button2.Text = "Close"
        PictureBox1.Image = My.Resources.Asimov

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If DoTheCoso.IsBusy Then DoTheCoso.CancelAsync() Else Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles OpenReportBTN.Click
        AsimovMain.ConvertReport(Filename)
    End Sub
End Class