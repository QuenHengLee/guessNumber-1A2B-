Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AcceptButton = Button1 'btn確定 設為預設
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = "Amy" Or ComboBox1.Text = "Tina" Or ComboBox1.Text = "Rita" Or ComboBox1.Text = "Kiki" Then
            If TextBox1.Text = ComboBox1.Text Then
                Form2.Show()
                Hide()
            Else
                MsgBox("錯誤", MsgBoxStyle.OkOnly, "GUESS NUMBER")
            End If
        Else
            MsgBox("無此使用者", MsgBoxStyle.OkOnly, "GUESS NUMBER")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ComboBox1.Text = ""  'btn2重新輸入
        TextBox1.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        End 'btn3結束
    End Sub

End Class
