Imports ASIMoV.ServerCommand

''' <summary>
''' EzTax Expansion
''' </summary>
Public Class EzTaxCommands
    ''' <summary>
    ''' Gets a breakdown of the specified ID's income
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <returns>NewpondIncome,UrbiaIncome,ParadisusIncome,LaertesIncome,NOIncome,SOIncome</returns>
    Public Shared Function Breakdown(ID As String) As String
        'EZTBRK57174
        Return RawCommand("EZTBRK" + ID)
    End Function

    ''' <summary>
    ''' Gets Income Info from the specified User
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <returns>Total,EI</returns>
    Public Shared Function Info(ID As String) As String
        'EZTINF57174
        Return RawCommand("EZTINF" + ID)
    End Function

    ''' <summary>
    ''' Update Income of someone
    ''' </summary>
    ''' <param name="EZTAXMSG"></param>
    ''' <returns></returns>
    Public Shared Function UpdateIncome(ID As String, TotalIncome As Long, NewpondIncome As Long, Urbiaincome As Long, ParadisusIncome As Long, LaertesIncome As Long, NOIncome As Long, SOincome As Long) As String
        'EZTUPD57174,0,0,0,0,0,0
        Return RawCommand("EZTUPD" & ID & "," & TotalIncome & "," & NewpondIncome & "," & Urbiaincome & "," & ParadisusIncome & "," & LaertesIncome & "," & NOIncome & "," & SOincome)
    End Function
End Class
