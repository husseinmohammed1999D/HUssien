Imports System.Deployment.Application


Imports System.Data.SQLite
Imports System.Net

Public Class Form1
    Private ReadOnly connectionString As String = "Data Source=mydatabase.db;Version=3;"
    Private ContractNumber As Integer

    Dim companyPrice As Integer = My.Settings.Companyprice

    Public Function CAL() As (Decimal, Decimal, Decimal)
        Try
            Dim VisaPric As Decimal = Decimal.Parse(TextBox1.Text)
            Dim MadinaPric As Decimal = Decimal.Parse(TextBox2.Text)
            Dim MakePrice As Decimal = Decimal.Parse(TextBox4.Text)
            Dim NumM1 As Decimal = Decimal.Parse(TextBox3.Text)
            Dim Numm As Decimal = Decimal.Parse(TextBox5.Text)
            Dim tNT As Decimal = Decimal.Parse(TextBox7.Text)
            Dim hiap As Decimal = Decimal.Parse(TextBox6.Text)
            Dim hadayap As Decimal = Decimal.Parse(TextBox8.Text)
            Dim AgentPric As Decimal = Decimal.Parse(TextBox9.Text)

            ' تحديد قيمة التقسيم بناءً على حالة CheckBox
            Dim multiplier As Decimal = If(CheckBox1.Checked, Decimal.Parse(TextBox10.Text), 4)

            If multiplier <= 0 Then
                MessageBox.Show("Invalid multiplier value. Please check the input.")
                Return (0, 0, 0)
            Else
                ' إذا كان CheckBox مفعل، قم بالتقسيم فقط لغرف رباعية وتصفير القيم الأخرى
                If CheckBox1.Checked Then
                    Dim TotalPriceQuad = CalculatePrice(VisaPric, MakePrice, MadinaPric, NumM1, Numm, tNT, hiap, hadayap, AgentPric, 4, multiplier)
                    Label11.Text = TotalPriceQuad.ToString("N0")
                    Label13.Text = "0"
                    Label14.Text = "0"

                    Return (TotalPriceQuad, 0, 0)
                Else
                    ' إذا كان CheckBox غير مفعل، قم بحساب جميع الغرف
                    Dim TotalPriceQuad = CalculatePrice(VisaPric, MakePrice, MadinaPric, NumM1, Numm, tNT, hiap, hadayap, AgentPric, 4, 4)
                    Dim TotalPriceDouble = CalculatePrice(VisaPric, MakePrice, MadinaPric, NumM1, Numm, tNT, hiap, hadayap, AgentPric, 2, 2)
                    Dim TotalPriceTriple = CalculatePrice(VisaPric, MakePrice, MadinaPric, NumM1, Numm, tNT, hiap, hadayap, AgentPric, 3, 3)

                    Label11.Text = TotalPriceQuad.ToString("N0")
                    Label13.Text = TotalPriceTriple.ToString("N0")
                    Label14.Text = TotalPriceDouble.ToString("N0")

                    Return (TotalPriceQuad, TotalPriceDouble, TotalPriceTriple)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Error calculating the values: " & ex.Message)
            Return (0, 0, 0)
        End Try
    End Function

    ' Helper function to calculate price based on occupancy
    Private Function CalculatePrice(visaPrice As Decimal, makePrice As Decimal, madinaPrice As Decimal, numM1 As Decimal, numm As Decimal, tNT As Decimal, hiap As Decimal, hadayap As Decimal, agentPrice As Decimal, occupancy As Decimal, divider As Decimal) As Decimal
        Return Math.Ceiling((visaPrice / 3.72) + (numm * makePrice / divider / 3.72) + (numM1 * madinaPrice / divider / 3.72) + tNT + hiap + hadayap + agentPrice + companyPrice)
    End Function


    Private Sub SetttingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetttingToolStripMenuItem.Click
        Form3.Show()

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()

    End Sub

    ' هذا الحدث يتم تشغيله عندما يتم تحميل النموذج
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        ' حلقة تمر على جميع عناصر التحكم في النموذج
        For Each ctrl As Control In Me.Controls
            ' التحقق إذا كان العنصر هو TextBox
            If TypeOf ctrl Is TextBox Then
                Dim txtBox As TextBox = CType(ctrl, TextBox)
                ' حفظ النص الافتراضي داخل خاصية Tag
                txtBox.Tag = txtBox.Text
                ' تعيين لون النص الافتراضي إلى رمادي
                txtBox.ForeColor = Color.Gray
                ' إضافة أحداث Enter و Leave
                AddHandler txtBox.Enter, AddressOf TextBox_Enter
                AddHandler txtBox.Leave, AddressOf TextBox_Leave
            End If
        Next
        For Each ctrl As Control In GroupBox1.Controls
            ' التحقق إذا كان العنصر هو TextBox
            If TypeOf ctrl Is TextBox Then
                Dim txtBox As TextBox = CType(ctrl, TextBox)
                ' حفظ النص الافتراضي داخل خاصية Tag
                txtBox.Tag = txtBox.Text
                ' تعيين لون النص الافتراضي إلى رمادي
                txtBox.ForeColor = Color.Gray
                ' إضافة أحداث Enter و Leave
                AddHandler txtBox.Enter, AddressOf TextBox_Enter
                AddHandler txtBox.Leave, AddressOf TextBox_Leave
            End If
        Next
        For Each ctrl As Control In GroupBox2.Controls
            ' التحقق إذا كان العنصر هو TextBox
            If TypeOf ctrl Is TextBox Then
                Dim txtBox As TextBox = CType(ctrl, TextBox)
                ' حفظ النص الافتراضي داخل خاصية Tag
                txtBox.Tag = txtBox.Text
                ' تعيين لون النص الافتراضي إلى رمادي
                txtBox.ForeColor = Color.Gray
                ' إضافة أحداث Enter و Leave
                AddHandler txtBox.Enter, AddressOf TextBox_Enter
                AddHandler txtBox.Leave, AddressOf TextBox_Leave
            End If
        Next
    End Sub

    ' هذا الحدث يتم تشغيله عند دخول المستخدم إلى TextBox
    Private Sub TextBox_Enter(sender As Object, e As EventArgs)
        Dim txtBox As TextBox = CType(sender, TextBox)
        ' إذا كان النص الحالي هو النص الافتراضي، قم بمسحه
        If txtBox.Text = txtBox.Tag.ToString() Then
            txtBox.Text = ""
            txtBox.ForeColor = Color.Black
        End If
    End Sub

    ' هذا الحدث يتم تشغيله عند مغادرة المستخدم لـ TextBox
    Private Sub TextBox_Leave(sender As Object, e As EventArgs)
        Dim txtBox As TextBox = CType(sender, TextBox)
        ' إذا كان TextBox فارغًا، قم بإعادة النص الافتراضي
        If String.IsNullOrWhiteSpace(txtBox.Text) Then
            txtBox.Text = txtBox.Tag.ToString()
            txtBox.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub btnSum_Click(sender As Object, e As EventArgs) Handles btnSum.Click
        CAL()


    End Sub
    Private Sub ButtonPrint_Click_1(sender As Object, e As EventArgs) Handles ButtonPrint.Click
        Form2.Show()
    End Sub

    Private Sub ادارةعقودToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ادارةعقودToolStripMenuItem.Click
        Dim formAgents As New FormAgents() ' إنشاء مثيل جديد من FormAgents
        formAgents.Show() ' عرض النموذج
    End Sub

    Private Sub ToolStripTextBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub سدادToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles سدادToolStripMenuItem.Click
        form4.Show()
    End Sub
End Class