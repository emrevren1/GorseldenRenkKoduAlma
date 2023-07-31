Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        'PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage (resmi picturebox a sığdırma kodu, bunu yazınca resimlerin kalitesi düşüyor)
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If PictureBox1.ImageLocation = " " Then
            MsgBox("resim yükleyiniz")
        Else
            Dim i, j As Integer
            Dim bmp As New Bitmap(PictureBox1.Image)
            ProgressBar1.Visible = True
            ProgressBar1.Minimum = 0
            ProgressBar1.Maximum = bmp.Width * bmp.Height
            ProgressBar1.Value = 0
            For i = 0 To bmp.Width - 1 Step 1
                For j = 0 To bmp.Height - 1 Step 1

                    Dim r As Byte = 255 - bmp.GetPixel(i, j).R
                    Dim g As Byte = 255 - bmp.GetPixel(i, j).G
                    Dim b As Byte = 255 - bmp.GetPixel(i, j).B
                    Dim a As Byte = bmp.GetPixel(i, j).A

                    bmp.SetPixel(i, j, Color.FromArgb(a, r, g, b))
                    ProgressBar1.Value = ProgressBar1.Value + 1
                Next
            Next
            ProgressBar1.Visible = False
            PictureBox2.Image = bmp
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        OpenFileDialog1.Filter = "Resim Dosyaları|" + "*.bmp;*.jpg;*.gif;*.wmf;*.tif;*.png"
        If (OpenFileDialog1.ShowDialog() = DialogResult.OK) Then
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If
        Button1.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Timer1.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ProgressBar1.Visible = True
        Dim i, j, r, g, b As Integer
        Dim renk1, renk2, renk3 As Color
        Dim bmp = New Bitmap(PictureBox1.Image)
        ProgressBar1.Maximum = bmp.Width * bmp.Height
        For i = 0 To bmp.Width - 2
            For j = 0 To bmp.Height - 2
                renk1 = bmp.GetPixel(i, j) 'i,j noktasının rengini öğren
                renk2 = bmp.GetPixel(i + 1, j + 1) 'sonraki noktanın rengini öğren
                r = Math.Abs(renk1.R) - (renk2.R) + 128
                If r > 255 Then
                    r = 255
                ElseIf r < 0 Then
                    r = 0
                End If
                g = Math.Abs(renk1.G) - (renk2.G) + 128
                If g > 255 Then
                    g = 255
                ElseIf g < 0 Then
                    g = 0
                End If
                b = Math.Abs(renk1.B) - (renk2.B) + 128
                If b > 255 Then
                    b = 255
                ElseIf b < 0 Then
                    b = 0
                End If
                renk3 = Color.FromArgb(r, g, b)
                bmp.SetPixel(i, j, renk3)
                If (i Mod 10) = 0 Then 'her on satırda bir göstergeyi güncelle
                    ProgressBar1.Value = i * bmp.Height + j
                    Application.DoEvents()
                End If
            Next
        Next
        PictureBox2.Image = bmp
        ProgressBar1.Visible = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ProgressBar1.Visible = True
        Dim i, j As Integer
        Dim renk As Color 'Color sınıfından bir renk nesne tanımlıyoruz.
        Dim bmp = New Bitmap(PictureBox1.Image)
        'int r,g,b
        ProgressBar1.Maximum = bmp.Width * bmp.Height 'İşlem çubuğunun maksimim olduğu yer For döngüsünün sonundaki piksel değerine erişmemiz durumundadır.
        For i = 0 To bmp.Width - 1
            For j = 0 To bmp.Height - 1
                renk = bmp.GetPixel(i, j)
                renk = Color.FromArgb(((Convert.ToInt32(renk.R) + Convert.ToInt32(renk.G) + Convert.ToInt32(renk.B)) / 3), ((Convert.ToInt32(renk.R) + Convert.ToInt32(renk.G) + Convert.ToInt32(renk.B)) / 3), ((Convert.ToInt32(renk.R) + Convert.ToInt32(renk.G) + Convert.ToInt32(renk.B)) / 3))
                bmp.SetPixel(i, j, renk)
                If i Mod 10 = 0 Then 'her on satırda bir göstergeyi güncelle
                    ProgressBar1.Value = i * bmp.Height + j
                    Application.DoEvents()
                End If

            Next
        Next
        PictureBox2.Image = bmp
        ProgressBar1.Visible = False
    End Sub

    Dim re, ge, be, k, c, m, y As Integer

    Private Sub PictureBox1_MouseHover(sender As Object, e As EventArgs) Handles PictureBox1.MouseHover

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox1_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox1.MouseLeave

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        PictureBox2.Image = Nothing
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim bmp As Bitmap = PictureBox1.Image
        Using ge As Graphics = Graphics.FromImage(bmp)
            ge.CopyFromScreen(Windows.Forms.Cursor.Position, New Point(0, 0), New Size(1, 1))
        End Using
        Dim pixel As Drawing.Color = bmp.GetPixel(0, 0)

        re = pixel.R
        ge = pixel.G
        be = pixel.B

        Label1.Text$ = bmp.GetPixel(0, 0).ToString
        Dim p As New Point
        p.X = (Me.Width / 2) - (Label1.Width / 2)
        p.Y = Label1.Top
        Label1.Location = p
        PictureBox2.BackColor = pixel
        PictureBox1.Invalidate()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub PictureBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseClick
        Dim bmp As Bitmap = PictureBox1.Image
        Dim pixel As Drawing.Color = bmp.GetPixel(0, 0)

        re = pixel.R
        ge = pixel.G
        be = pixel.B

        k = (re + ge + be)
        c = (ge + be) / 2
        m = (re + be) / 2
        y = (re + ge) / 2

        RichTextBox1.Text += "Cyan : " & c & Chr(13) & "Megenta : " & m & Chr(13) & "Yellow : " & y & Chr(13) & "Black : " & k & Chr(13) & "-----------------------" & Chr(13) & "Red : " & re & Chr(13) & "Green : " & ge & Chr(13) & "Blue : " & be & Chr(13) & "-----------------------" & Chr(13)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim yol As String
        SaveFileDialog1.Filter = "Metin Dosyaları (*.txt)|*.txt"
        SaveFileDialog1.Title = "Metni Kaydet"
        If (SaveFileDialog1.ShowDialog() = DialogResult.OK) Then
            yol = SaveFileDialog1.FileName
            RichTextBox1.SaveFile(yol, RichTextBoxStreamType.PlainText)
        End If

    End Sub
End Class
