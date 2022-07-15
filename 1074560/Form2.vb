Public Class Form2
    '程式中a1代表個位數 a2 代表十位數 以此類推...
    Dim inser_ckeck As Boolean '判斷輸入是否正確
    Dim num, ans, time, a, b As Integer
    Dim a1, a2, a3, a4 As Char '正確答案每個數字

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = Form1.ComboBox1.SelectedItem & "歡迎來玩猜猜看" '設定視窗名稱
        Me.AcceptButton = Me.Button1 'btn確定答案 設為預設
        TextBox1.Select() '預設輸入
        inser_ckeck = False

        Randomize()  '亂數產生4個不重複的數字
        a1 = (Int(Rnd() * 10)).ToString
        Do
            a2 = (Int(Rnd() * 10)).ToString
        Loop While a2 = a1
        Do
            a3 = (Int(Rnd() * 10)).ToString
        Loop While a3 = a1 Or a3 = a2
        Do
            a4 = (Int(Rnd() * 10)).ToString
        Loop While a4 = a1 Or a4 = a2 Or a4 = a3

        TextBox2.Text = a4 & a3 & a2 & a1 '正確答案
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then '顯示or隱藏歷史紀錄
            Form3.Show()
        Else
            Form3.Hide()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim ret1, ret2 '存放MSGBOX 結果

        ret1 = MsgBox("確定要放棄看答案嗎?", MsgBoxStyle.YesNo, "GUESS NUMBER")
        If ret1 = MsgBoxResult.Yes Then
            TextBox2.UseSystemPasswordChar = True '顯示正解
            Button1.Enabled = False
            Button3.Enabled = False
            TextBox1.Enabled = False

            ret2 = MsgBox("要從新產生數字嗎?", MsgBoxStyle.YesNo, "GUESS NUMBER")


        End If

        If ret2 = MsgBoxResult.No Then
            Form1.Show() 'btn結束程式
            Form3.Close()
            Form1.ComboBox1.Text = ""
            Form1.TextBox1.Text = ""
            Me.Close()
        Else
            TextBox1.Text = ""
            Form3.ListBox1.Items.Clear()
            TextBox2.UseSystemPasswordChar = False
            Randomize()  '亂數產生4個不重複的數字



            a1 = (Int(Rnd() * 10)).ToString

            Do
                a2 = (Int(Rnd() * 10)).ToString
            Loop While a2 = a1
            Do
                a3 = (Int(Rnd() * 10)).ToString
            Loop While a3 = a1 Or a3 = a2
            Do
                a4 = (Int(Rnd() * 10)).ToString
            Loop While a4 = a1 Or a4 = a2 Or a4 = a3

            TextBox2.Text = a4 & a3 & a2 & a1
        End If
    End Sub

    Dim n1, n2, n3, n4 As Char '猜的答案每個數字



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form1.Show() 'btn結束程式
        Form1.ComboBox1.Text = ""
        Form1.TextBox1.Text = ""

        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' num = CInt(Trim(TextBox1.Text)) '將輸入內容char轉換成數字int
        TextBox1.SelectAll()


        a = 0
        b = 0

        If Len(TextBox1.Text) <> 4 Then '檢查輸入為數是否正確
            MsgBox("輸入數字位數錯誤")
        Else
            n1 = Mid(TextBox1.Text, 4, 1)
            n2 = Mid(TextBox1.Text, 3, 1)
            n3 = Mid(TextBox1.Text, 2, 1)
            n4 = Mid(TextBox1.Text, 1, 1)





            If ((Asc(n1) < 48 Or Asc(n1) > 57) Or (Asc(n2) < 48 Or Asc(n2) > 57) Or (Asc(n3) < 48 Or Asc(n3) > 57) Or (Asc(n4) < 48 Or Asc(n4) > 57)) Then
                MsgBox("輸入數字包含非數字")
            Else
                If n4 = n3 Or n4 = n2 Or n4 = n1 Or n3 = n2 Or n3 = n1 Or n2 = n1 Then '檢查輸入是否重複
                    MsgBox("輸入數字有重複數字")
                Else
                    inser_ckeck = True
                    time += 1
                End If
            End If
        End If



        If inser_ckeck = True Then
            If n1 = a1 Or n1 = a2 Or n1 = a3 Or n1 = a4 Then
                If n1 = a1 Then
                    a += 1
                Else
                    b += 1
                End If
            End If

            If n2 = a1 Or n2 = a2 Or n2 = a3 Or n2 = a4 Then
                If n2 = a2 Then
                    a += 1
                Else
                    b += 1
                End If
            End If

            If n3 = a1 Or n3 = a2 Or n3 = a3 Or n3 = a4 Then
                If n3 = a3 Then
                    a += 1
                Else
                    b += 1
                End If
            End If

            If n4 = a1 Or n4 = a2 Or n4 = a3 Or n4 = a4 Then
                If n4 = a4 Then
                    a += 1
                Else
                    b += 1
                End If
            End If
        End If






        Label1.Text = time & ":  " & a & "A" & b & "B" & "(" & n4 & n3 & n2 & n1 & ")"



        Dim ret3






        If a1 = n1 And a2 = n2 And a3 = n3 And a4 = n4 Then
            ret3 = MsgBox("恭喜你猜了" & time & "次猜中了!!要繼續下一題?", MsgBoxStyle.YesNo, "GUESS NUMBER")
            If ret3 = MsgBoxResult.Yes Then
                TextBox1.Text = ""
                Label1.Text = "0:  0A0B (0000)"
                Form3.ListBox1.Items.Clear()
                TextBox2.UseSystemPasswordChar = False
                Randomize()  '亂數產生4個不重複的數字



                a1 = (Int(Rnd() * 10)).ToString

                Do
                    a2 = (Int(Rnd() * 10)).ToString
                Loop While a2 = a1
                Do
                    a3 = (Int(Rnd() * 10)).ToString
                Loop While a3 = a1 Or a3 = a2
                Do
                    a4 = (Int(Rnd() * 10)).ToString
                Loop While a4 = a1 Or a4 = a2 Or a4 = a3

                TextBox2.Text = a4 & a3 & a2 & a1
            Else
                End
            End If
        End If
        Form3.ListBox1.Items.Add(Label1.Text)


    End Sub
End Class