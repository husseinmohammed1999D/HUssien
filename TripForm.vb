Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class TripForm

    Private originalText As New Dictionary(Of TextBox, String)
    Private SelectedAgentIndex As Integer? = Nothing

    Private Sub TripForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' تعريف الأعمدة لـ DataGridView1 (عرض الرحلات)
        InitializeTripDataGridView()

        ' تعريف الأعمدة لـ DataGridView2 (عرض الوكلاء)
        InitializeAgentDataGridView()

        ' تحميل الرحلات عند تحميل النموذج
        LoadTrips()
        LoadTripNames()
        InitializeTextBoxes()
    End Sub
    Private Sub InitializeTripDataGridView()
        dgvData.Columns.Clear()
        dgvData.Columns.Add("رقم الرحلة", "رقم الرحلة")
        dgvData.Columns.Add("TripName", "اسم الرحلة")
        dgvData.Columns.Add("تاريخ الرحلة", "تاريخ الرحلة")
        dgvData.Columns.Add("ملاحظات الرحلة", "ملاحظات الرحلة")
        dgvData.Columns.Add("ConfirmedBy", "ConfirmedBy")

        ' إضافة أعمدة الأزرار
        Dim btnConfirmAli As New DataGridViewButtonColumn()
        btnConfirmAli.Name = "btnConfirmAli"
        btnConfirmAli.HeaderText = "تأكيد من علي"
        btnConfirmAli.Text = "تأكيد من علي"
        btnConfirmAli.UseColumnTextForButtonValue = True
        dgvData.Columns.Add(btnConfirmAli)

        Dim btnConfirmHussein As New DataGridViewButtonColumn()
        btnConfirmHussein.Name = "btnConfirmHussein"
        btnConfirmHussein.HeaderText = "تأكيد من حسين"
        btnConfirmHussein.Text = "تأكيد من حسين"
        btnConfirmHussein.UseColumnTextForButtonValue = True
        dgvData.Columns.Add(btnConfirmHussein)

        Dim TriphasebeenEEdite As New DataGridViewButtonColumn()
        TriphasebeenEEdite.Name = "BtnEditr"
        TriphasebeenEEdite.HeaderText = "الرحلة معدلة"
        TriphasebeenEEdite.Text = "تأكيد  التعديل"
        TriphasebeenEEdite.UseColumnTextForButtonValue = True
        dgvData.Columns.Add(TriphasebeenEEdite)
    End Sub

    Private Sub InitializeAgentDataGridView()
        dgvAgents.Columns.Clear()
        dgvAgents.Columns.Add("اسم الوكيل", "اسم الوكيل")
        dgvAgents.Columns.Add("بالغ", "بالغ")
        dgvAgents.Columns.Add("طفل", "طفل")
        dgvAgents.Columns.Add("رضيع", "رضيع")
        dgvAgents.Columns.Add("معتمر بدون فيزا", "معتمر بدون فيزا")
        dgvAgents.Columns.Add("معتمر بدون برنامج", "معتمر بدون برنامج")
        dgvAgents.Columns.Add("مجموع الكلي", "مجموع الكلي")
        dgvAgents.Columns.Add("ملاحظات الوكيل", "ملاحظات الوكيل")
        AddButtonColumn(dgvAgents, "btnEdit", "تعديل")
        AddButtonColumn(dgvAgents, "btnDelete", "حذف")
    End Sub
    Private Sub AddButtonColumn(dataGridView As DataGridView, name As String, text As String)
        Dim buttonColumn As New DataGridViewButtonColumn()
        buttonColumn.HeaderText = text
        buttonColumn.Name = name
        buttonColumn.Text = text
        buttonColumn.UseColumnTextForButtonValue = True
        dataGridView.Columns.Add(buttonColumn)
    End Sub

    Private Sub InitializeTextBoxes()
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is TextBox Then
                Dim textBox As TextBox = CType(ctrl, TextBox)
                originalText(textBox) = textBox.Text
                AddHandler textBox.GotFocus, AddressOf TextBox_GotFocus
                AddHandler textBox.LostFocus, AddressOf TextBox_LostFocus
                AddHandler textBox.TextChanged, AddressOf TextBox_TextChanged
            End If
        Next
    End Sub
    Private Sub dgvData_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then
            Dim tripId As String = dgvData.Rows(e.RowIndex).Cells("رقم الرحلة").Value.ToString()

            ' إذا تم النقر على زر "تأكيد من علي"
            If dgvData.Columns(e.ColumnIndex).Name = "btnConfirmAli" Then
                ConfirmTrip(tripId, "علي")

                ' إذا تم النقر على زر "تأكيد من حسين"
            ElseIf dgvData.Columns(e.ColumnIndex).Name = "btnConfirmHussein" Then
                ConfirmTrip(tripId, "حسين")
            ElseIf dgvData.Columns(e.ColumnIndex).Name = "BtnEditr" Then
                ConfirmTrip(tripId, "تم التعديل")
            End If
        End If

        If e.RowIndex >= 0 Then
            ' إذا تم النقر على زر "حذف"
            If e.ColumnIndex = dgvData.Columns("حذف").Index Then
                Dim tripId As String = dgvData.Rows(e.RowIndex).Cells("رقم الرحلة").Value.ToString()
                Dim confirmResult = MessageBox.Show("هل أنت متأكد أنك تريد حذف هذه الرحلة؟", "تأكيد الحذف", MessageBoxButtons.YesNo)
                If confirmResult = DialogResult.Yes Then
                    DeleteTrip(tripId) ' استدعاء دالة الحذف



                End If
            End If
        End If
    End Sub

    ' دالة لتأكيد الرحلة وحفظها في Firebase
    Private Async Sub ConfirmTrip(tripId As String, confirmer As String)
        ' تحديث حالة التأكيد في Firebase
        Dim confirmationData As New Dictionary(Of String, Object) From {
        {"ConfirmedBy", confirmer}
    }

        Dim json As String = JsonConvert.SerializeObject(confirmationData)
        Dim content As New StringContent(json, Encoding.UTF8, "application/json")

        Using client As New HttpClient()
            Dim url As String = $"https://umrahtrip-2f202-default-rtdb.firebaseio.com/trips/{tripId}/ConfirmedBy.json"
            Dim response = Await client.PutAsync(url, content)
            If response.IsSuccessStatusCode Then
                MessageBox.Show($"تم تأكيد الرحلة من {confirmer} بنجاح!")

                ' إعادة تحميل بيانات الرحلات وتحديث الألوان
                LoadTrips()
            Else
                MessageBox.Show("فشل في تأكيد الرحلة.")
            End If
        End Using
    End Sub
    Private Sub ApplyRowColors()
        ' قم بتطبيق اللون لكل صف بناءً على قيمة التأكيد
        For Each row As DataGridViewRow In dgvData.Rows
            ' افترض أن عمود التأكيد يحتوي على اسم الشخص الذي قام بالتأكيد
            Dim confirmedBy As String = row.Cells("ConfirmedBy").Value?.ToString()

            ' تحقق من قيمة التأكيد وقم بتطبيق اللون المناسب
            If confirmedBy = "علي" Then
                row.DefaultCellStyle.BackColor = Color.Black  ' لون خاص بالتأكيد من علي
            ElseIf confirmedBy = "حسين" Then
                row.DefaultCellStyle.BackColor = Color.LightGreen ' لون خاص بالتأكيد من حسين
            ElseIf confirmedBy = "تم التعديل" Then
                row.DefaultCellStyle.BackColor = Color.Red ' لون خاص بالتأكيد من حسين
            Else
                row.DefaultCellStyle.BackColor = Color.White  ' لون افتراضي إذا لم يتم التأكيد
            End If
        Next
    End Sub

    Private Async Sub EditAgent(agentName As String)
        Dim url As String = $"https://umrahtrip-2f202-default-rtdb.firebaseio.com/agents/{agentName}.json"
        Dim agentDetails = Await GetJsonFromFirebase(url)

        If agentDetails IsNot Nothing Then
            txtAgentName.Text = agentDetails("اسم الوكيل").ToString()
            txtAdultCount.Text = agentDetails("بالغ").ToString()
            txtChildCount.Text = agentDetails("طفل").ToString()
            txtInfantCount.Text = agentDetails("رضيع").ToString()
            txtPilgrimsWithoutVisa.Text = agentDetails("معتمر بدون فيزا").ToString()
            txtPilgrimsWithoutProgram.Text = agentDetails("معتمر بدون برنامج").ToString()
            txtAgentNotes.Text = agentDetails("ملاحظات الوكيل").ToString()
        End If
    End Sub
    Private Async Sub btnSaveAgent_Click(sender As Object, e As EventArgs) Handles btnSaveAgentChanges.Click
        If dgvAgents.SelectedRows.Count = 0 Then
            MessageBox.Show("يجب اختيار وكيل أولاً.")
            Return
        End If

        Dim selectedRow = dgvAgents.SelectedRows(0)
        Dim agentName As String = selectedRow.Cells("اسم الوكيل").Value.ToString()
        Dim agentData As New Dictionary(Of String, Object) From {
        {"اسم الوكيل", txtAgentName.Text},
        {"بالغ", txtAdultCount.Text},
        {"طفل", txtChildCount.Text},
        {"رضيع", txtInfantCount.Text},
        {"معتمر بدون فيزا", txtPilgrimsWithoutVisa.Text},
        {"معتمر بدون برنامج", txtPilgrimsWithoutProgram.Text},
        {"ملاحظات الوكيل", txtAgentNotes.Text}
    }

        Await UpdateAgentOnline(agentName, agentData)
    End Sub
    Private Async Sub DeleteAgent(agentName As String)
        Dim url As String = $"https://umrahtrip-2f202-default-rtdb.firebaseio.com/agents/{agentName}.json"

        Using client As New HttpClient()
            Dim response = Await client.DeleteAsync(url)
            If response.IsSuccessStatusCode Then
                MessageBox.Show("تم حذف الوكيل بنجاح!")
                '  LoadAgentsForTrip(tripId) ' إعادة تحميل بيانات الوكلاء بعد الحذف
            Else
                MessageBox.Show("فشل في حذف الوكيل.")
            End If
        End Using
    End Sub

    Private Async Function UpdateAgentOnline(agentName As String, agentData As Dictionary(Of String, Object)) As Task
        Dim json As String = JsonConvert.SerializeObject(agentData)
        Dim content As New StringContent(json, Encoding.UTF8, "application/json")

        Using client As New HttpClient()
            Dim url As String = $"https://umrahtrip-2f202-default-rtdb.firebaseio.com/agents/{agentName}.json"
            Dim response = Await client.PutAsync(url, content)
            If response.IsSuccessStatusCode Then
                MessageBox.Show("تم تحديث بيانات الوكيل بنجاح!")
            Else
                MessageBox.Show("فشل في تحديث بيانات الوكيل.")
            End If
        End Using
    End Function

    Private Async Sub EditTrip(tripId As String)
        Dim url As String = $"https://umrahtrip-2f202-default-rtdb.firebaseio.com/trips/{tripId}.json"
        Dim tripDetails = Await GetJsonFromFirebase(url)

        If tripDetails IsNot Nothing Then
            txtTripName.Text = tripDetails("TripName").ToString()
            dtpTripDate.Value = DateTime.Parse(tripDetails("تاريخ الرحلة").ToString())
            txtTripNotes.Text = tripDetails("ملاحظات الرحلة").ToString()
        End If
    End Sub

    ' دالة للتحقق إذا تم تعديل الوكلاء (يمكنك تعديل هذا الشرط بناءً على حاجتك)
    Private Function CheckIfAgentsModified(row As DataGridViewRow) As Boolean
        ' افترض وجود عمود يحتوي على حالة تعديل الوكلاء
        Dim agentStatus As String = row.Cells("AgentModified").Value.ToString()

        ' إذا كانت حالة تعديل الوكلاء هي "True" أو "معدل"
        If agentStatus = "True" Or agentStatus = "معدل" Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Async Function LoadTripDetails(tripId As String) As Task
        Using client As New HttpClient()
            Dim url As String = $"https://umrahtrip-2f202-default-rtdb.firebaseio.com/trips/{tripId}.json"
            Dim response = Await client.GetAsync(url)
            If response.IsSuccessStatusCode Then
                Dim json As String = Await response.Content.ReadAsStringAsync()
                Dim tripDetails = JsonConvert.DeserializeObject(Of JObject)(json)

                If tripDetails IsNot Nothing Then
                    txtTripName.Text = tripDetails("TripName").ToString()
                    dtpTripDate.Value = DateTime.Parse(tripDetails("تاريخ الرحلة").ToString())
                    txtTripNotes.Text = tripDetails("ملاحظات الرحلة").ToString()

                    ' Load agents
                    If tripDetails.ContainsKey("Agents") Then
                        Dim agents = tripDetails("Agents").ToObject(Of List(Of Dictionary(Of String, Object)))()
                        LoadAgents(agents)
                    End If
                End If
            Else
                MessageBox.Show("فشل في جلب تفاصيل الرحلة.")
            End If
        End Using
    End Function


    ' عرض بيانات الوكلاء في DataGridView2
    Private Sub LoadAgents(agents As List(Of Dictionary(Of String, Object)))
        dgvAgents.Rows.Clear()
        For Each agent In agents
            dgvAgents.Rows.Add(agent("اسم الوكيل"), agent("بالغ"), agent("طفل"), agent("رضيع"), agent("معتمر بدون فيزا"), agent("معتمر بدون برنامج"), agent("مجموع الكلي"), agent("ملاحظات الوكيل"))
        Next
    End Sub
    Private Async Sub LoadTrips()
        Try
            ' رابط Firebase
            Dim url As String = "https://umrahtrip-2f202-default-rtdb.firebaseio.com/trips.json"

            ' جلب بيانات الرحلات من Firebase
            Dim tripsData = Await GetJsonFromFirebase(url)
            dgvData.Rows.Clear()  ' مسح البيانات السابقة

            ' التحقق من أن البيانات غير فارغة
            If tripsData IsNot Nothing Then
                ' إضافة كل رحلة إلى DataGridView
                For Each trip In tripsData.Properties()
                    Dim tripInfo As JObject = TryCast(trip.Value, JObject)

                    ' التحقق من وجود بيانات الرحلة
                    If tripInfo IsNot Nothing Then
                        ' التحقق من القيم قبل استخدامها
                        Dim tripName As String = If(tripInfo("TripName") IsNot Nothing, tripInfo("TripName").ToString(), String.Empty)
                        Dim tripDate As String = If(tripInfo("تاريخ الرحلة") IsNot Nothing, tripInfo("تاريخ الرحلة").ToString(), String.Empty)
                        Dim tripNotes As String = If(tripInfo("ملاحظات الرحلة") IsNot Nothing, tripInfo("ملاحظات الرحلة").ToString(), String.Empty)
                        Dim tripId As String = trip.Name ' افتراض أن اسم الرحلة هو المعرف

                        ' استخراج ConfirmedBy
                        Dim confirmedBy As String = String.Empty
                        If tripInfo("ConfirmedBy") IsNot Nothing Then
                            Dim confirmedByObj As JObject = TryCast(tripInfo("ConfirmedBy"), JObject)
                            If confirmedByObj IsNot Nothing Then
                                confirmedBy = If(confirmedByObj("ConfirmedBy") IsNot Nothing, confirmedByObj("ConfirmedBy").ToString(), String.Empty)
                            End If
                        End If

                        ' إضافة الصف إلى DataGridView
                        Dim rowIndex As Integer = dgvData.Rows.Add(trip.Name, tripName, tripDate, tripNotes, confirmedBy)

                        ' تخصيص لون الصف بناءً على "ConfirmedBy"
                        Dim currentRow As DataGridViewRow = dgvData.Rows(rowIndex)

                        ' تخصيص الألوان بناءً على ConfirmedBy
                        If confirmedBy = "علي" Then
                            currentRow.DefaultCellStyle.BackColor = Color.LightBlue  ' لون خاص بعلي
                        ElseIf confirmedBy = "حسين" Then
                            currentRow.DefaultCellStyle.BackColor = Color.LightGreen  ' لون خاص بحسين
                        ElseIf confirmedBy = "تم التعديل" Then
                            currentRow.DefaultCellStyle.BackColor = Color.Red  ' لون خاص بحسين
                        Else
                            currentRow.DefaultCellStyle.BackColor = Color.White  ' لون افتراضي
                        End If
                    End If
                Next

            End If
        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء تحميل الرحلات: " & ex.Message)
        End Try
        If dgvData.Columns("حذف") Is Nothing Then
            Dim deleteColumn As New DataGridViewButtonColumn()
            deleteColumn.Name = "حذف"
            deleteColumn.HeaderText = "حذف"
            deleteColumn.Text = "حذف"
            deleteColumn.UseColumnTextForButtonValue = True
            dgvData.Columns.Add(deleteColumn)
            LoadTripNames()

        End If
    End Sub


    Private Async Function GetJsonFromFirebase(url As String) As Task(Of JObject)
        Using client As New HttpClient()
            Dim response = Await client.GetAsync(url)
            If response.IsSuccessStatusCode Then
                Dim json = Await response.Content.ReadAsStringAsync()
                Return JsonConvert.DeserializeObject(Of JObject)(json)
            Else
                MessageBox.Show($"فشل في الاتصال بقاعدة البيانات. رمز الخطأ: {response.StatusCode}")
                Return Nothing
            End If
        End Using
    End Function



    ' تحديث بيانات الرحلة على Firebase
    ' تحديث بيانات الرحلة على Firebase
    Private Async Function UpdateTripOnline(tripId As String, tripName As String, tripDate As Date, tripNotes As String) As Task
        Dim tripData As New Dictionary(Of String, Object) From {
        {"TripName", tripName},
        {"تاريخ الرحلة", tripDate.ToString("yyyy-MM-dd")},
        {"ملاحظات الرحلة", tripNotes}
    }

        Dim json As String = JsonConvert.SerializeObject(tripData)
        Dim content As New StringContent(json, Encoding.UTF8, "application/json")

        Using client As New HttpClient()
            Dim url As String = $"https://umrahtrip-2f202-default-rtdb.firebaseio.com/trips/{tripId}.json"
            Dim response = Await client.PutAsync(url, content)
            If response.IsSuccessStatusCode Then
                MessageBox.Show("تم تحديث الرحلة بنجاح!")
                LoadTrips() ' إعادة تحميل الرحلات بعد التحديث
            Else
                MessageBox.Show("فشل في تحديث البيانات.")
            End If
        End Using
    End Function

    Private Async Sub DeleteTrip(tripId As String)
        Await DeleteTripOnline(tripId)
        LoadTrips()
        LoadTripNames()
    End Sub
    Private Async Function DeleteTripOnline(tripId As String) As Task
        If String.IsNullOrWhiteSpace(tripId) Then
            MessageBox.Show("معرف الرحلة غير صحيح.")
            Return
        End If

        Using client As New HttpClient()
            Dim url As String = $"https://umrahtrip-2f202-default-rtdb.firebaseio.com/trips/{tripId}.json"
            Try
                Dim response = Await client.DeleteAsync(url)
                If response.IsSuccessStatusCode Then
                    MessageBox.Show("تم حذف الرحلة بنجاح!")
                Else
                    Dim errorMessage = Await response.Content.ReadAsStringAsync()
                    MessageBox.Show($"فشل في حذف الرحلة. رمز الحالة: {response.StatusCode}. الرسالة: {errorMessage}")
                End If
            Catch ex As Exception
                MessageBox.Show("حدث خطأ أثناء حذف الرحلة: " & ex.Message)
            End Try
        End Using
    End Function

    Private Sub TextBox_GotFocus(sender As Object, e As EventArgs)
        Dim textBox As TextBox = CType(sender, TextBox)
        textBox.BackColor = Color.LightYellow
        If textBox.Text = originalText(textBox) Then
            textBox.Text = ""
        End If
    End Sub
    Private Sub TextBox_LostFocus(sender As Object, e As EventArgs)
        Dim textBox As TextBox = CType(sender, TextBox)
        textBox.BackColor = Color.White
        If textBox.Text = "" Then
            textBox.Text = originalText(textBox)
        End If
    End Sub
    Private Sub TextBox_TextChanged(sender As Object, e As EventArgs)
        Dim textBox As TextBox = CType(sender, TextBox)
        If textBox.Text <> originalText(textBox) Then
            originalText(textBox) = textBox.Text
        End If
    End Sub
    Private Async Sub btnCreateTrip_Click(sender As Object, e As EventArgs)
        Dim tripData As New Dictionary(Of String, Object) From {
            {"TripName", txtTripName.Text},
            {"تاريخ الرحلة", dtpTripDate.Value.ToString("yyyy-MM-dd")},
            {"ملاحظات الرحلة", txtTripNotes.Text}
        }

        Dim json = JsonConvert.SerializeObject(tripData)
        Dim content As New StringContent(json, Encoding.UTF8, "application/json")

        Using client As New HttpClient
            Dim url = "https://umrahtrip-2f202-default-rtdb.firebaseio.com/trips.json"
            Dim response = Await client.PostAsync(url, content)
            If response.IsSuccessStatusCode Then
                MessageBox.Show("تم إضافة الرحلة بنجاح!")
                LoadTrips()
            Else
                MessageBox.Show("فشل في إضافة الرحلة.")
            End If
        End Using
        LoadTripNames()
    End Sub
    Private Async Function AddTripOnline(tripData As Dictionary(Of String, Object)) As Task
        Dim json As String = JsonConvert.SerializeObject(tripData)
        Dim content As New StringContent(json, Encoding.UTF8, "application/json")

        Using client As New HttpClient()
            Dim url As String = "https://umrahtrip-2f202-default-rtdb.firebaseio.com/trips.json"
            Dim response = Await client.PostAsync(url, content)
            If response.IsSuccessStatusCode Then
                MessageBox.Show("تم إضافة الرحلة بنجاح!")
                LoadTrips() ' إعادة تحميل الرحلات بعد الإدراج
            Else
                MessageBox.Show("فشل في إضافة الرحلة.")
            End If
        End Using
    End Function
    ' دالة لحفظ بيانات الوكيل في الرحلة المختارة عند الضغط على زر btnSaveAgentData
    Private Async Sub btnSaveAgentData_Click(sender As Object, e As EventArgs)
        ' التحقق من أن هناك رحلة مختارة
        If cmbTrips.SelectedIndex = -1 Then
            MessageBox.Show("يرجى اختيار اسم الرحلة أولاً.")
            Return
        End If

        ' جلب اسم الرحلة المختارة
        Dim selectedTrip As String = cmbTrips.SelectedItem.ToString()
        lblTotalPilgrims.Text = (Integer.Parse(txtAdultCount.Text) + Integer.Parse(txtChildCount.Text) +
                          Integer.Parse(txtInfantCount.Text) + Integer.Parse(txtPilgrimsWithoutVisa.Text) +
                          Integer.Parse(txtPilgrimsWithoutProgram.Text)).ToString
        ' جمع بيانات الوكيل من الحقول
        Dim agentData As New Dictionary(Of String, Object) From {
        {"اسم الوكيل", txtAgentName.Text},
        {"بالغ", Integer.Parse(txtAdultCount.Text)},
        {"طفل", Integer.Parse(txtChildCount.Text)},
        {"رضيع", Integer.Parse(txtInfantCount.Text)},
        {"معتمر بدون فيزا", Integer.Parse(txtPilgrimsWithoutVisa.Text)},
        {"معتمر بدون برنامج", Integer.Parse(txtPilgrimsWithoutProgram.Text)},
        {"مجموع الكلي", Integer.Parse(lblTotalPilgrims.Text)},
        {"ملاحظات الوكيل", txtAgentNotes.Text}
    }

        ' جلب الرحلة المطلوبة من Firebase
        Dim url = "https://umrahtrip-2f202-default-rtdb.firebaseio.com/trips.json"
        Using client As New HttpClient
            Dim response = Await client.GetStringAsync(url)
            Dim tripsData = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(response)

            ' البحث عن الرحلة المختارة
            For Each tripKey In tripsData.Keys
                ' استخدام JObject للتحويل بدون مشاكل 
                Dim trip = DirectCast(tripsData(tripKey), JObject)
                If trip("TripName").ToString = selectedTrip Then
                    ' جلب قائمة الوكلاء الحالية أو إنشاء قائمة جديدة
                    Dim agents = If(trip.ContainsKey("Agents"), DirectCast(trip("Agents"), JArray), New JArray)

                    ' إضافة الوكيل الجديد إلى قائمة الوكلاء
                    agents.Add(JObject.FromObject(agentData))

                    ' تحديث بيانات الرحلة مع الوكلاء الجدد
                    trip("Agents") = agents

                    ' رفع البيانات الجديدة إلى Firebase
                    Dim json = JsonConvert.SerializeObject(trip)
                    Dim content As New StringContent(json, Encoding.UTF8, "application/json")
                    Await client.PutAsync($"https://umrahtrip-2f202-default-rtdb.firebaseio.com/trips/{tripKey}.json", content)

                    ' رسالة نجاح
                    MessageBox.Show("تم إضافة بيانات الوكيل بنجاح!")

                    ' تحديث بيانات الوكلاء في dgvAgents
                    Await LoadAgentsForTrip(selectedTrip)

                    Exit For
                End If
            Next
        End Using
    End Sub
    Private Function s(tex As TextBox)
        If tex.Text = Nothing Then
            tex.Text = 0
        End If
    End Function

    ' دالة لتحميل أسماء الرحلات من Firebase وتعبئة الـ ComboBox (cmbTrips)
    Private Async Sub LoadTripNames()
        Try
            ' رابط قاعدة البيانات للرحلات في Firebase
            Dim url As String = $"https://umrahtrip-2f202-default-rtdb.firebaseio.com/trips.json"
            ' جلب البيانات من Firebase
            Using client As New HttpClient()
                Dim response As HttpResponseMessage = Await client.GetAsync(url)
                ' التحقق من نجاح الجلب
                If response.IsSuccessStatusCode Then
                    Dim responseData As String = Await response.Content.ReadAsStringAsync()
                    If Not String.IsNullOrEmpty(responseData) AndAlso responseData <> "null" Then
                        ' تحويل البيانات إلى JObject
                        Dim tripsData As JObject = JObject.Parse(responseData)

                        ' مسح العناصر القديمة من الـ ComboBox
                        cmbTrips.Items.Clear()

                        ' التحقق من وجود بيانات رحلات
                        If tripsData IsNot Nothing Then
                            ' التعامل مع بيانات الرحلات
                            For Each trip As JProperty In tripsData.Properties()
                                Dim tripInfo As JObject = CType(trip.Value, JObject)
                                Dim tripName As String = tripInfo("TripName").ToString()
                                cmbTrips.Items.Add(tripName)
                            Next
                            'MessageBox.Show("تم تحميل أسماء الرحلات بنجاح.")
                        Else
                            '    MessageBox.Show("لا توجد رحلات في قاعدة البيانات.")
                        End If
                    Else
                        '   MessageBox.Show("لم يتم العثور على بيانات في قاعدة البيانات.")
                    End If
                Else
                    '  MessageBox.Show($"فشل في الاتصال بقاعدة البيانات. رمز الخطأ: {response.StatusCode}")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show($"حدث خطأ: {ex.Message}")
        End Try
    End Sub
    Private Async Function UpdateTripOnline(tripId As String, tripData As Dictionary(Of String, Object)) As Task
        Dim json As String = JsonConvert.SerializeObject(tripData)
        Dim content As New StringContent(json, Encoding.UTF8, "application/json")

        Using client As New HttpClient()
            Dim url As String = $"https://umrahtrip-2f202-default-rtdb.firebaseio.com/trips/{tripId}.json"
            Dim response = Await client.PutAsync(url, content)
            If response.IsSuccessStatusCode Then
                MessageBox.Show("تم تحديث الرحلة بنجاح!")
            Else
                MessageBox.Show("فشل في تحديث البيانات.")
            End If
        End Using
    End Function

    ' حدث تغيير الرحلة في ComboBox
    Private Sub cmbTrips_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' التحقق من أن هناك رحلة مختارة
        If cmbTrips.SelectedIndex <> -1 Then
            Dim selectedTrip As String = cmbTrips.SelectedItem.ToString()
            ' استدعاء الدالة لتحميل بيانات الوكلاء لهذه الرحلة
            LoadAgentsForTrip(selectedTrip)
        End If
    End Sub

    ' دالة لتحميل بيانات الوكلاء للرحلة المحددة
    Private Async Function LoadAgentsForTrip(selectedTrip As String) As Task
        Try
            ' جلب بيانات الرحلة من Firebase
            Dim url As String = "https://umrahtrip-2f202-default-rtdb.firebaseio.com/trips.json"
            Using client As New HttpClient()
                Dim response = Await client.GetStringAsync(url)
                Dim tripsData As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(response)

                ' البحث عن الرحلة المحددة
                For Each tripKey As String In tripsData.Keys
                    Dim trip As JObject = DirectCast(tripsData(tripKey), JObject)

                    ' تحقق من أن الكائن trip ليس فارغًا
                    If trip IsNot Nothing AndAlso trip("TripName").ToString() = selectedTrip Then
                        ' جلب قائمة الوكلاء
                        Dim agents As JArray = If(trip.ContainsKey("Agents"), DirectCast(trip("Agents"), JArray), Nothing)

                        ' تحقق من أن قائمة الوكلاء ليست فارغة
                        If agents Is Nothing OrElse agents.Count = 0 Then
                            MessageBox.Show("لا توجد بيانات للوكلاء.")
                            dgvAgents.Rows.Clear()
                            Return
                        End If

                        ' تعبئة DataGridView بالبيانات
                        dgvAgents.Rows.Clear() ' تفريغ الداتا كري فيو قبل إضافة البيانات الجديدة
                        For Each agent As JObject In agents
                            dgvAgents.Rows.Add(agent("اسم الوكيل").ToString(), agent("بالغ").ToString(), agent("طفل").ToString(), agent("رضيع").ToString(), agent("معتمر بدون فيزا").ToString(), agent("معتمر بدون برنامج").ToString(), agent("مجموع الكلي").ToString())
                        Next
                        Exit For
                    End If
                Next
            End Using

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء تحميل بيانات الوكلاء: " & ex.Message)
        End Try
    End Function
    ' إعداد DataGridView لإضافة أزرار تعديل وحذف
    Private Sub SetupDataGridView()
        ' إضافة عمود زر التعديل
        Dim editButton As New DataGridViewButtonColumn()
        editButton.HeaderText = "تعديل"
        editButton.Text = "تعديل"
        editButton.UseColumnTextForButtonValue = True
        dgvAgents.Columns.Add(editButton)

        ' إضافة عمود زر الحذف
        Dim deleteButton As New DataGridViewButtonColumn()
        deleteButton.HeaderText = "حذف"
        deleteButton.Text = "حذف"
        deleteButton.UseColumnTextForButtonValue = True
        dgvAgents.Columns.Add(deleteButton)
    End Sub

    ' حدث عند الضغط على زر في DataGridView
    Private Async Sub dgvAgents_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        ' التأكد من أن الضغط تم على زر
        If e.RowIndex >= 0 Then
            Dim selectedAgentName As String = dgvAgents.Rows(e.RowIndex).Cells("اسم الوكيل").Value.ToString()

            ' التحقق من الضغط على زر تعديل
            If dgvAgents.Columns(e.ColumnIndex).HeaderText = "تعديل" Then
                ' تحميل بيانات الوكيل في الحقول لتعديلها
                txtAgentName.Text = dgvAgents.Rows(e.RowIndex).Cells("اسم الوكيل").Value.ToString()
                txtAdultCount.Text = dgvAgents.Rows(e.RowIndex).Cells("بالغ").Value.ToString()
                txtChildCount.Text = dgvAgents.Rows(e.RowIndex).Cells("طفل").Value.ToString()
                txtInfantCount.Text = dgvAgents.Rows(e.RowIndex).Cells("رضيع").Value.ToString()
                txtPilgrimsWithoutVisa.Text = dgvAgents.Rows(e.RowIndex).Cells("معتمر بدون فيزا").Value.ToString()
                txtPilgrimsWithoutProgram.Text = dgvAgents.Rows(e.RowIndex).Cells("معتمر بدون برنامج").Value.ToString()
                lblTotalPilgrims.Text = dgvAgents.Rows(e.RowIndex).Cells("مجموع الكلي").Value.ToString()

                ' حفظ بيانات الصف المختار لتحديثه بعد التعديل
                SelectedAgentIndex = e.RowIndex

                ' التحقق من الضغط على زر حذف
            ElseIf dgvAgents.Columns(e.ColumnIndex).HeaderText = "حذف" Then
                ' تأكيد عملية الحذف
                Dim result = MessageBox.Show("هل تريد حذف هذا الوكيل؟", "تأكيد الحذف", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then
                    ' حذف الوكيل من Firebase ومن DataGridView
                    Await DeleteAgentFromFirebase(selectedAgentName)
                    dgvAgents.Rows.RemoveAt(e.RowIndex)
                    MessageBox.Show("تم حذف الوكيل بنجاح.")
                End If
            End If
        End If
    End Sub

    ' دالة لحذف الوكيل من Firebase
    Private Async Function DeleteAgentFromFirebase(agentName As String) As Task
        Try
            ' جلب بيانات الرحلة من Firebase
            Dim url As String = "https://umrahtrip-2f202-default-rtdb.firebaseio.com/trips.json"
            Using client As New HttpClient()
                Dim response = Await client.GetStringAsync(url)
                Dim tripsData As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(response)

                ' البحث عن الرحلة المختارة
                For Each tripKey As String In tripsData.Keys
                    Dim trip As JObject = DirectCast(tripsData(tripKey), JObject)
                    If trip("TripName").ToString() = cmbTrips.SelectedItem.ToString() Then
                        ' جلب قائمة الوكلاء
                        Dim agents As JArray = DirectCast(trip("Agents"), JArray)

                        ' البحث عن الوكيل وحذفه
                        For i As Integer = 0 To agents.Count - 1
                            If agents(i)("اسم الوكيل").ToString() = agentName Then
                                agents.RemoveAt(i)
                                Exit For
                            End If
                        Next

                        ' رفع البيانات المحدثة إلى Firebase
                        trip("Agents") = agents
                        Dim json As String = JsonConvert.SerializeObject(trip)
                        Dim content As New StringContent(json, Encoding.UTF8, "application/json")
                        Await client.PutAsync($"https://umrahtrip-2f202-default-rtdb.firebaseio.com/trips/{tripKey}.json", content)
                        Exit For
                    End If
                Next
            End Using
        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء حذف الوكيل: " & ex.Message)
        End Try
    End Function

    ' دالة لحفظ التعديلات بعد تعديل بيانات الوكيل
    Private Async Sub btnSaveAgentChanges_Click(sender As Object, e As EventArgs)
        If SelectedAgentIndex.HasValue Then
            Dim selectedIndex = SelectedAgentIndex.Value
            If SelectedAgentIndex IsNot Nothing Then
                Dim selectedIndexs As Integer = SelectedAgentIndex
                Dim selectedTrip As String = cmbTrips.SelectedItem.ToString()

                lblTotalPilgrims.Text = (Integer.Parse(txtAdultCount.Text) + Integer.Parse(txtChildCount.Text) +
                          Integer.Parse(txtInfantCount.Text) + Integer.Parse(txtPilgrimsWithoutVisa.Text) +
                          Integer.Parse(txtPilgrimsWithoutProgram.Text)).ToString
                ' تحديث بيانات الوكيل في DataGridView
                dgvAgents.Rows(selectedIndexs).Cells("اسم الوكيل").Value = txtAgentName.Text
                dgvAgents.Rows(selectedIndexs).Cells("بالغ").Value = txtAdultCount.Text
                dgvAgents.Rows(selectedIndexs).Cells("طفل").Value = txtChildCount.Text
                dgvAgents.Rows(selectedIndexs).Cells("رضيع").Value = txtInfantCount.Text
                dgvAgents.Rows(selectedIndexs).Cells("معتمر بدون فيزا").Value = txtPilgrimsWithoutVisa.Text
                dgvAgents.Rows(selectedIndexs).Cells("معتمر بدون برنامج").Value = txtPilgrimsWithoutProgram.Text
                dgvAgents.Rows(selectedIndexs).Cells("مجموع الكلي").Value = lblTotalPilgrims.Text

                ' تحديث البيانات في Firebase
                Await UpdateAgentInFirebase(selectedTrip, selectedIndexs)
            End If
        End If

    End Sub

    ' دالة لتحديث بيانات الوكيل في Firebase
    Private Async Function UpdateAgentInFirebase(selectedTrip As String, agentIndex As Integer) As Task
        Try
            ' جلب بيانات الرحلة من Firebase
            Dim url As String = "https://umrahtrip-2f202-default-rtdb.firebaseio.com/trips.json"
            Using client As New HttpClient()
                Dim response = Await client.GetStringAsync(url)
                Dim tripsData As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(response)

                ' البحث عن الرحلة المختارة
                For Each tripKey As String In tripsData.Keys
                    Dim trip As JObject = DirectCast(tripsData(tripKey), JObject)
                    If trip("TripName").ToString() = selectedTrip Then
                        ' جلب قائمة الوكلاء
                        Dim agents As JArray = DirectCast(trip("Agents"), JArray)

                        ' تحديث بيانات الوكيل
                        Dim agent As JObject = agents(agentIndex)
                        agent("اسم الوكيل") = txtAgentName.Text
                        agent("بالغ") = Integer.Parse(txtAdultCount.Text)
                        agent("طفل") = Integer.Parse(txtChildCount.Text)
                        agent("رضيع") = Integer.Parse(txtInfantCount.Text)
                        agent("معتمر بدون فيزا") = Integer.Parse(txtPilgrimsWithoutVisa.Text)
                        agent("معتمر بدون برنامج") = Integer.Parse(txtPilgrimsWithoutProgram.Text)
                        agent("مجموع الكلي") = Integer.Parse(lblTotalPilgrims.Text)

                        ' رفع البيانات المحدثة إلى Firebase
                        trip("Agents") = agents
                        Dim json As String = JsonConvert.SerializeObject(trip)
                        Dim content As New StringContent(json, Encoding.UTF8, "application/json")
                        Await client.PutAsync($"https://umrahtrip-2f202-default-rtdb.firebaseio.com/trips/{tripKey}.json", content)
                        MessageBox.Show("تم تعديل بيانات الوكيل بنجاح.")
                        Exit For
                    End If
                Next
            End Using
        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء تعديل الوكيل: " & ex.Message)
        End Try
    End Function

    Private Sub lblTotalPilgrims_Click(sender As Object, e As EventArgs)

    End Sub
End Class
