Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class FormAgents
    Private ReadOnly firebaseUrl As String = "https://umrahprograming-default-rtdb.firebaseio.com/Contracts.json"
    Private httpClient As New HttpClient()
    Public SelectedAgentID As Integer
    Public SelectedAgentName As String
    Private ContractNumber As Integer

    ' منشئ افتراضي بدون معاملات
    Public Sub New()
        InitializeComponent()
        Me.ContractNumber = 0
    End Sub

    ' المنشئ الحالي الذي يتطلب contractNumber
    Public Sub New(contractNumber As Integer)
        InitializeComponent()
        Me.ContractNumber = contractNumber
        LoadContracts() ' تحميل بيانات العقد 
    End Sub

    Private Async Sub FormAgents_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' تهيئة DataGridViewContracts 
        If DataGridViewContracts.Columns.Count = 0 Then
            DataGridViewContracts.Columns.Add("ContractNumber", "رقم العقد")
            DataGridViewContracts.Columns.Add("ClientName", "اسم العميل")
            DataGridViewContracts.Columns.Add("MakaHotelName", "اسم فندق مكة")
            DataGridViewContracts.Columns.Add("MadinaHotelName", "اسم فندق المدينة")
            DataGridViewContracts.Columns.Add("TotalNights", "عدد الليالي")
            DataGridViewContracts.Columns.Add("MakaRooms", "عدد غرف مكة")
            DataGridViewContracts.Columns.Add("ChildCount", "عدد الأطفال")
            DataGridViewContracts.Columns.Add("AdultCount", "عدد البالغين")
            DataGridViewContracts.Columns.Add("ContractTerms", "الشروط")
            DataGridViewContracts.Columns.Add("ContractDate", "تاريخ")
            DataGridViewContracts.Columns.Add("TotalCost", "التكلفة الكلية")
            DataGridViewContracts.Columns.Add("ConfirmedBy", "تم التأكيد بواسطة")

            DataGridViewContracts.Rows.Add()
            Dim editButtonColumn As New DataGridViewButtonColumn()
            editButtonColumn.HeaderText = "تعديل"
            editButtonColumn.Name = "EditButton"
            editButtonColumn.Text = "تعديل"
            editButtonColumn.UseColumnTextForButtonValue = True
            DataGridViewContracts.Columns.Add(editButtonColumn)
        End If

        Dim btnConfirmAli As New DataGridViewButtonColumn()
        btnConfirmAli.Name = "btnConfirmAli"
        btnConfirmAli.HeaderText = "تأكيد من علي"
        btnConfirmAli.Text = "تأكيد من علي"
        btnConfirmAli.UseColumnTextForButtonValue = True
        DataGridViewContracts.Columns.Add(btnConfirmAli)

        Dim btnConfirmHussein As New DataGridViewButtonColumn()
        btnConfirmHussein.Name = "btnConfirmHussein"
        btnConfirmHussein.HeaderText = "تأكيد من حسين"
        btnConfirmHussein.Text = "تأكيد من حسين"
        btnConfirmHussein.UseColumnTextForButtonValue = True
        DataGridViewContracts.Columns.Add(btnConfirmHussein)

        Dim btnConfirmMahmood As New DataGridViewButtonColumn()
        btnConfirmMahmood.Name = "btnConfirmMahmood"
        btnConfirmMahmood.HeaderText = "تأكيد من محمود"
        btnConfirmMahmood.Text = "تأكيد من محمود"
        btnConfirmMahmood.UseColumnTextForButtonValue = True
        DataGridViewContracts.Columns.Add(btnConfirmMahmood)

        ' تحميل العقود من Firebase
        Await LoadContracts()
    End Sub

    Private Async Sub DataGridViewContracts_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewContracts.CellClick
        ' تأكد من أن الصف والعمود صحيحان
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim contractKey As String = DataGridViewContracts.Rows(e.RowIndex).Cells("ContractNumber").Value.ToString() ' استخدام رقم العقد

            Select Case DataGridViewContracts.Columns(e.ColumnIndex).Name
                Case "btnConfirmAli"
                    ' تأكيد العقد بواسطة علي
                    Await ConfirmContract(contractKey, "علي")
                Case "btnConfirmHussein"
                    ' تأكيد العقد بواسطة حسين
                    Await ConfirmContract(contractKey, "حسين")
                Case "btnConfirmMahmood"
                    ' تأكيد العقد بواسطة حسين
                    Await ConfirmContract(contractKey, "محمود")
                Case "EditButton"
                    Await ConfirmContract(contractKey, "تم التعديل")
                    ' تعديل العقد
                    Dim editForm As New Form5(contractKey) ' تمرير contractKey إلى Form5
                    If editForm.ShowDialog() = DialogResult.OK Then
                        Await LoadContracts() ' إعادة تحميل العقود بعد التعديل
                    End If
            End Select
        End If
    End Sub

    Private Async Function ConfirmContract(contractKey As String, confirmer As String) As Task
        Try
            ' تحديث حالة التأكيد في Firebase فقط للعقد المحدد بناءً على رقم العقد
            Dim confirmationData As New Dictionary(Of String, Object) From {
                {"ConfirmedBy", confirmer} ' تحديث ConfirmedBy
            }

            ' تحويل البيانات إلى JSON
            Dim json As String = JsonConvert.SerializeObject(confirmationData)
            Dim content As New StringContent(json, Encoding.UTF8, "application/json")

            ' استخدام العنوان الصحيح لتحديث العقد بناءً على رقم العقد
            Dim url As String = $"https://umrahprograming-default-rtdb.firebaseio.com/Contracts/{contractKey}.json" ' العنوان مع رقم العقد المحدد
            Dim response = Await httpClient.PatchAsync(url, content) ' استخدام Patch لتحديث خاصية معينة

            If response.IsSuccessStatusCode Then
                MessageBox.Show($"تم تأكيد العقد {contractKey} بواسطة {confirmer} بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Await LoadContracts() ' أعد تحميل البيانات بعد التحديث
            Else
                MessageBox.Show("فشل في تأكيد العقد: " & response.ReasonPhrase, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء تأكيد العقد: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Async Function LoadContracts() As Task
        Try
            Dim response = Await httpClient.GetStringAsync(firebaseUrl)
            Dim contracts As List(Of Dictionary(Of String, Object)) = JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(response)

            DataGridViewContracts.Rows.Clear()

            If contracts IsNot Nothing AndAlso contracts.Count > 0 Then
                For Each contractData In contracts
                    If contractData IsNot Nothing Then
                        Dim contractNumber As String = If(contractData.TryGetValue("ContractNumber", contractNumber), contractNumber.ToString(), "N/A")
                        Dim clientName As String = If(contractData.TryGetValue("ClientName", clientName), clientName.ToString(), "N/A")
                        Dim makaHotelName As String = If(contractData.TryGetValue("MakaHotelName", makaHotelName), makaHotelName.ToString(), "N/A")
                        Dim madinaHotelName As String = If(contractData.TryGetValue("MadinaHotelName", madinaHotelName), madinaHotelName.ToString(), "N/A")
                        Dim totalNights As String = If(contractData.TryGetValue("TotalNights", totalNights), totalNights.ToString(), "0")
                        Dim makaRooms As String = If(contractData.TryGetValue("MakaRooms", makaRooms), makaRooms.ToString(), "0")
                        Dim childCount As String = If(contractData.TryGetValue("ChildCount", childCount), childCount.ToString(), "0")
                        Dim adultCount As String = If(contractData.TryGetValue("AdultCount", adultCount), adultCount.ToString(), "0")
                        Dim contractTerms As String = If(contractData.TryGetValue("ContractTerms", contractTerms), contractTerms.ToString(), "N/A")
                        Dim contractDate As String = If(contractData.TryGetValue("ContractDate", contractDate), contractDate.ToString(), "N/A")
                        Dim totalCost As String = If(contractData.TryGetValue("TotalCost", totalCost), totalCost.ToString(), "0")
                        Dim confirmedBy As String = If(contractData.ContainsKey("ConfirmedBy"), contractData("ConfirmedBy").ToString(), "N/A")

                        ' إضافة البيانات إلى DataGridView
                        Dim rowIndex As Integer = DataGridViewContracts.Rows.Add(contractNumber, clientName, makaHotelName, madinaHotelName, totalNights, makaRooms, childCount, adultCount, contractTerms, contractDate, totalCost, confirmedBy)

                        ' تخصيص اللون بناءً على ConfirmedBy
                        Dim currentRow As DataGridViewRow = DataGridViewContracts.Rows(rowIndex)
                        ApplyRowColors(currentRow, confirmedBy)
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء تحميل العقود: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub ApplyRowColors(row As DataGridViewRow, confirmedBy As String)
        If confirmedBy = "علي" Then
            row.DefaultCellStyle.BackColor = Color.LightBlue
        ElseIf confirmedBy = "حسين" Then
            row.DefaultCellStyle.BackColor = Color.LightGreen
        ElseIf confirmedBy = "محمود" Then
            row.DefaultCellStyle.BackColor = Color.Gray
        ElseIf confirmedBy = "تم التعديل" Then
            row.DefaultCellStyle.BackColor = Color.LightYellow
        Else
            row.DefaultCellStyle.BackColor = Color.White
        End If
    End Sub
End Class
