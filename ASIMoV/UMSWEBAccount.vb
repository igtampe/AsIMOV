Imports ASIMoV.TaxCalc

Public Class UMSWEBAccount
    Public ID As String
    Public Name As String
    Public Category As UMSWEBAccountCategory
    Public BankInfo As BankInformation
    Public Taxinfo As TaxInformation

    Public Structure BankInformation
        Public UMSNB As Boolean
        Public GBANK As Boolean
        Public RIVER As Boolean
        Public UMSNBBalance As Long
        Public GBANKBalance As Long
        Public RIVERBalance As Long
        Public TotalBalance As Long

        Public Sub New(INF As String())
            UMSNB = INF(0)
            UMSNBBalance = INF(1)
            GBANK = INF(2)
            GBANKBalance = INF(3)
            RIVER = INF(4)
            RIVERBalance = INF(5)

            TotalBalance = UMSNBBalance + GBANKBalance + RIVERBalance

        End Sub

    End Structure

    Public Enum UMSWEBAccountCategory As Integer
        Personal = 0
        Corporate = 1
        Government = 2
    End Enum

    Public Sub New(ID As String)
        Me.ID = ID
        Dim INF() As String = CoreCommands.INFO(ID).Split(",")
        'HasUMSNB, ",", UMSNBBalance, ",", HasGBANK, ",", GBANKBalance, ",", HasRIVER, ",", RIVERBalance, ",", UserName, ",", notifs

        Name = INF(6)
        Category = UMSWEBAccountCategory.Personal

        If Name.EndsWith(" (Corp.)") Then
            Name = Name.Replace(" (Corp.)", "")
            Category = UMSWEBAccountCategory.Corporate
        ElseIf Name.EndsWith(" (Gov.)") Then
            Name = Name.Replace(" (Gov.)", "")
            Category = UMSWEBAccountCategory.Government
        End If

        BankInfo = New BankInformation(INF)

        Dim BRK() As String = EzTaxCommands.Breakdown(ID).Split(",")
        Dim EI As Long = EzTaxCommands.Info(ID).Split(",")(1)

        Taxinfo = New TaxInformation(EI, BRK(0), BRK(1), BRK(2), BRK(3), BRK(4), BRK(5), Category)

    End Sub


End Class
