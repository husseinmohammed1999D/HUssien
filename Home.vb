Public Class Home
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
    End Sub

    'Private Sub OpenFormInPanel()
    '    ' إنشاء كائن من الفورم الفرعي
    '    Dim childForm As New Form1()

    '    ' إعدادات الفورم الفرعي لعرضه داخل Panel
    '    childForm.TopLevel = False
    '    childForm.FormBorderStyle = FormBorderStyle.None
    '    childForm.Dock = DockStyle.Fill

    '    ' إزالة أي عناصر تحكم سابقة من الـ Panel
    '    Panel1.Controls.Clear()

    '    ' إضافة الفورم إلى Panel
    '    Panel1.Controls.Add(childForm)

    '    ' عرض الفورم الفرعي
    '    childForm.Show()

    '    ' استدعاء الدالة CAL() بعد عرض الفورم الفرعي
    '    childForm.CAL()
    'End Sub

    'Private Sub OpenFormInPanel1()
    '    ' إنشاء كائن من الفورم الفرعي
    '    Dim childForm As New Form4()

    '    ' إعدادات الفورم الفرعي لعرضه داخل Panel
    '    childForm.TopLevel = False
    '    childForm.FormBorderStyle = FormBorderStyle.None
    '    childForm.Dock = DockStyle.Fill

    '    ' إزالة أي عناصر تحكم سابقة من الـ Panel
    '    Panel1.Controls.Clear()

    '    ' إضافة الفورم إلى Panel
    '    Panel1.Controls.Add(childForm)

    '    ' عرض الفورم الفرعي
    '    childForm.Show()
    'End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form4.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FormAgents.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form3.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TripForm.Show()
    End Sub
End Class