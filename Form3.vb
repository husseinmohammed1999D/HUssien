Imports System.Runtime.InteropServices
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.Office.Interop.Excel

Public Class Form3


    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = My.Settings.Companyprice
        TextBox2.Text = My.Settings.Image
        TextBox3.Text = My.Settings.ImageInvois
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button2.Click
        My.Settings.Companyprice = TextBox1.Text
        My.Settings.Save()

    End Sub


    Private Sub ButtonUploadImage_Click(sender As Object, e As EventArgs) Handles ButtonUploadImage.Click
        ' تكوين OpenFileDialog
        OpenFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*"
        OpenFileDialog1.Title = "Select an Image"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            ' تحديث TextBoxFilePath بمسار الملف المختار
            TextBox2.Text = OpenFileDialog1.FileName

            ' تحديث المسار في إعدادات التطبيق
            My.Settings.Image = OpenFileDialog1.FileName
            My.Settings.Save()

            ' إعلام المستخدم بنجاح التحديث
            MessageBox.Show("تم تحديث مسار الملف بنجاح.")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' تكوين OpenFileDialog
        OpenFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*"
        OpenFileDialog1.Title = "Select an Image"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            ' تحديث TextBoxFilePath بمسار الملف المختار
            TextBox3.Text = OpenFileDialog1.FileName

            ' تحديث المسار في إعدادات التطبيق
            My.Settings.Image = OpenFileDialog1.FileName
            My.Settings.Save()

            ' إعلام المستخدم بنجاح التحديث
            MessageBox.Show("تم تحديث مسار الملف بنجاح.")
        End If
    End Sub
End Class

