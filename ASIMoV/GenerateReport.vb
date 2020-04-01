Imports ASIMoV.EzTaxCommands
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
        PrintLine(1, "INDEX,ID,Name,CAT,UMSNB,GBANK,RIVER,Balance,,Newpond,Urbia,Paradisus,Laertes,North Osten,South Osten,Extra Income,Total Income,,Newpond Bracket,Urbia Bracket,Paradisus Bracket,Laertes Bracket,North Osten Bracket,South Osten Bracket,Federal Bracket,,Newpond Tax,Urbia Tax,Paradisus Tax,Laertes Tax,North Osten Tax, South Osten Tax, Federal Tax")

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

        Dim UMSNBTotalBalance As Long = 0
        Dim GBANKTotalBalance As Long = 0
        Dim RIVERTotalBalance As Long = 0
        Dim AllTotalBalance As Long = 0

        Dim TotalFedIncome As Long = 0
        Dim TotalNewpondIncome As Long = 0
        Dim TotalUrbiaIncome As Long = 0
        Dim TotalParadisusIncome As Long = 0
        Dim TotalLaertesIncome As Long = 0
        Dim TotalNOSTENIncome As Long = 0
        Dim TotalSOSTENIncome As Long = 0

        Dim TotalExtraIncome As Long = 0
        Dim TotalIncome As Long = 0

        Dim TotalFedTax As Long = 0
        Dim TotalNewpondTax As Long = 0
        Dim TotalUrbiaTax As Long = 0
        Dim TotalParadisusTax As Long = 0
        Dim TotalLaertesTax As Long = 0
        Dim TotalNOSTENTax As Long = 0
        Dim TotalSOSTENTax As Long = 0

        Dim NonGovernmentAccounts = DirectoryArray.Count

        Dim MeasuringTimeCoso As Stopwatch
        Dim TimeLeft As String
        TimeLeft = ""
        MeasuringTimeCoso = New Stopwatch

        Dim X = 0

        For Each UserString As String In DirectoryArray
            ''Update or percentage
            CurrentWorkerStatus = "Retrieving All Information from " & UserString & ". " & TimeLeft
            CurrentWorkerPercentage = CInt(((X) / (NonGovernmentAccounts)) * 100)
            CurrentWorkerStage = 1
            DoTheCoso.ReportProgress(X)

            ''Get all the information of the user
            MeasuringTimeCoso.Start()
            Dim User As UMSWEBAccount = New UMSWEBAccount(UserString.Split(":")(0))
            MeasuringTimeCoso.Stop()

            ''Update our time left
            TimeLeft = "Approximately " & (CInt(MeasuringTimeCoso.ElapsedMilliseconds / 1000) * (((NonGovernmentAccounts - X - 1) * 2) + 1)) & "s to go."
            Debug.Print("Ellapsed Seconds: " & MeasuringTimeCoso.ElapsedMilliseconds)
            MeasuringTimeCoso.Reset()

            ''Update our percentage
            CurrentWorkerPercentage = CInt(((X + 0.7) / (NonGovernmentAccounts)) * 100)
            CurrentWorkerStatus = "Adding to report"
            DoTheCoso.ReportProgress(X)

            ''We're one user ahead
            X += 1

            ''Make sure we don't want to cancel just yet
            If DoTheCoso.CancellationPending Then
                WorkerCanceled = True
                FileClose(1)
                Exit Sub
            End If

            PrintLine(1,
                      X & "," &
                      User.ID & "," &
                      User.Name & "," &
                      User.Category & "," &
                      User.BankInfo.UMSNBBalance & "," &
                      User.BankInfo.GBANKBalance & "," &
                      User.BankInfo.RIVERBalance & "," &
                      User.BankInfo.TotalBalance & "," &
                      "" & "," &
                      User.Taxinfo.NewpondIncome & "," &
                      User.Taxinfo.UrbiaIncome & "," &
                      User.Taxinfo.ParadisusIncome & "," &
                      User.Taxinfo.LaertesIncome & "," &
                      User.Taxinfo.NorthOstenIncome & "," &
                      User.Taxinfo.SouthOstenIncome & "," &
                      User.Taxinfo.ExtraIncome & "," &
                      User.Taxinfo.FederalIncome & "," &
                      "" & "," &
                      User.Taxinfo.Newpond.Bracket.toString & "," &
                      User.Taxinfo.Urbia.Bracket.toString & "," &
                      User.Taxinfo.Paradisus.Bracket.toString & "," &
                      User.Taxinfo.Laertes.Bracket.toString & "," &
                      User.Taxinfo.NorthOsten.Bracket.toString & "," &
                      User.Taxinfo.SouthOsten.Bracket.toString & "," &
                      User.Taxinfo.Federal.Bracket.toString & "," &
                      "" & "," &
                      User.Taxinfo.Newpond.MoneyOwed & "," &
                      User.Taxinfo.Urbia.MoneyOwed & "," &
                      User.Taxinfo.Paradisus.MoneyOwed & "," &
                      User.Taxinfo.Laertes.MoneyOwed & "," &
                      User.Taxinfo.NorthOsten.MoneyOwed & "," &
                      User.Taxinfo.SouthOsten.MoneyOwed & "," &
                      User.Taxinfo.Federal.MoneyOwed)


            UMSNBTotalBalance += User.BankInfo.UMSNBBalance
            GBANKTotalBalance += User.BankInfo.GBANKBalance
            RIVERTotalBalance += User.BankInfo.RIVERBalance
            AllTotalBalance += User.BankInfo.TotalBalance

            TotalFedIncome += User.Taxinfo.FederalIncome - User.Taxinfo.ExtraIncome
            TotalExtraIncome += User.Taxinfo.ExtraIncome
            TotalNewpondIncome += User.Taxinfo.NewpondIncome
            TotalUrbiaIncome += User.Taxinfo.UrbiaIncome
            TotalParadisusIncome += User.Taxinfo.ParadisusIncome
            TotalLaertesIncome += User.Taxinfo.LaertesIncome
            TotalNOSTENIncome += User.Taxinfo.NorthOstenIncome
            TotalSOSTENIncome += User.Taxinfo.SouthOstenIncome

            TotalIncome += User.Taxinfo.FederalIncome

            TotalFedTax += User.Taxinfo.Federal.MoneyOwed
            TotalNewpondTax += User.Taxinfo.Newpond.MoneyOwed
            TotalUrbiaTax += User.Taxinfo.Urbia.MoneyOwed
            TotalParadisusTax += User.Taxinfo.Paradisus.MoneyOwed
            TotalLaertesTax += User.Taxinfo.Laertes.MoneyOwed
            TotalNOSTENTax += User.Taxinfo.NorthOsten.MoneyOwed
            TotalSOSTENTax += User.Taxinfo.SouthOsten.MoneyOwed
        Next

        CurrentWorkerStage = 1
        CurrentWorkerStatus = "Finalizing Report"
        DoTheCoso.ReportProgress(90)
        PrintLine(1, ",TOTAL" & "," &
                  "" & "," &
                  "" & "," &
                  UMSNBTotalBalance & "," &
                  GBANKTotalBalance & "," &
                  RIVERTotalBalance & "," &
                  AllTotalBalance & "," &
                  "" & "," &
                  TotalNewpondIncome & "," &
                  TotalUrbiaIncome & "," &
                  TotalParadisusIncome & "," &
                  TotalLaertesIncome & "," &
                  TotalNOSTENIncome & "," &
                  TotalSOSTENIncome & "," &
                  TotalExtraIncome & "," &
                  TotalIncome & "," &
                  "" & "," & "" & "," & "" & "," & "" & "," & "" & "," & "" & "," & "" & "," & "" & "," & "" & "," &
                  TotalNewpondTax & "," &
                  TotalUrbiaTax & "," &
                  TotalParadisusTax & "," &
                  TotalLaertesTax & "," &
                  TotalNOSTENTax & "," &
                  TotalSOSTENTax & "," &
                  TotalFedTax)
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