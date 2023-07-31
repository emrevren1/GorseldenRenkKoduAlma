Public Class Form2

    Dim r, g, b As Integer
    Dim dizix(100) As Integer
    Dim diziy(100) As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PictureBox1.ImageLocation = ""
        Array.Clear(dizix, 0, dizix.Length)
        Array.Clear(diziy, 0, dizix.Length)
    End Sub

    Private Sub PictureBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseClick
        dizix(adet) = Windows.Forms.Cursor.Position.X

        diziy(adet) = Windows.Forms.Cursor.Position.Y

        MsgBox(dizix(adet) & " " & diziy(adet))
        adet = adet + 1
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim kagit As Graphics
        Dim kalem As Pen
        kagit = PictureBox1.CreateGraphics()
        kalem = New Pen(Color.Red)

        Dim i As Integer

        For i = 0 To adet
            kagit.DrawLine(kalem, dizix(i), diziy(i), dizix(i + 1), diziy(i + 1))
        Next
        kagit.DrawLine(kalem, dizix(0), diziy(0), dizix(1), diziy(1))
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Dim adet As Integer

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub
End Class