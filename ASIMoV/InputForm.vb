Public Class InputForm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrEmpty(Answer.Text.Trim) Then
            MsgBox("Please specify an answer to the prompt", MsgBoxStyle.Critical, "Error")
        Else
            Me.DialogResult = DialogResult.OK
            Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.DialogResult = DialogResult.Cancel
        Close()
    End Sub
End Class