<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TripForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        btnSaveAgentChanges = New Button()
        txtAgentNotes = New TextBox()
        txtTripNotes = New TextBox()
        lblTotalPilgrims = New Label()
        txtChildCount = New TextBox()
        txtInfantCount = New TextBox()
        txtAdultCount = New TextBox()
        dgvData = New DataGridView()
        dgvAgents = New DataGridView()
        cmbTrips = New ComboBox()
        txtPilgrimsWithoutProgram = New TextBox()
        txtPilgrimsWithoutVisa = New TextBox()
        txtAgentName = New TextBox()
        btnSaveAgentData = New Button()
        txtTripName = New TextBox()
        dtpTripDate = New DateTimePicker()
        btnCreateTrip = New Button()
        CType(dgvData, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvAgents, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnSaveAgentChanges
        ' 
        btnSaveAgentChanges.Anchor = AnchorStyles.Top
        btnSaveAgentChanges.BackColor = Color.FromArgb(CByte(128), CByte(255), CByte(128))
        btnSaveAgentChanges.Location = New Point(929, 43)
        btnSaveAgentChanges.Name = "btnSaveAgentChanges"
        btnSaveAgentChanges.Size = New Size(137, 23)
        btnSaveAgentChanges.TabIndex = 36
        btnSaveAgentChanges.Text = "حفظ التعديلات الوكلاء"
        btnSaveAgentChanges.UseVisualStyleBackColor = False
        ' 
        ' txtAgentNotes
        ' 
        txtAgentNotes.Anchor = AnchorStyles.Top
        txtAgentNotes.Location = New Point(798, 43)
        txtAgentNotes.Name = "txtAgentNotes"
        txtAgentNotes.Size = New Size(81, 23)
        txtAgentNotes.TabIndex = 35
        txtAgentNotes.Text = "ملاحظات"
        ' 
        ' txtTripNotes
        ' 
        txtTripNotes.Anchor = AnchorStyles.Top
        txtTripNotes.Location = New Point(498, 11)
        txtTripNotes.Name = "txtTripNotes"
        txtTripNotes.Size = New Size(157, 23)
        txtTripNotes.TabIndex = 34
        txtTripNotes.Text = "ملاحظات"
        ' 
        ' lblTotalPilgrims
        ' 
        lblTotalPilgrims.Anchor = AnchorStyles.Top
        lblTotalPilgrims.AutoSize = True
        lblTotalPilgrims.Location = New Point(897, 46)
        lblTotalPilgrims.Name = "lblTotalPilgrims"
        lblTotalPilgrims.Size = New Size(13, 15)
        lblTotalPilgrims.TabIndex = 33
        lblTotalPilgrims.Text = "0"
        ' 
        ' txtChildCount
        ' 
        txtChildCount.Anchor = AnchorStyles.Top
        txtChildCount.Location = New Point(391, 43)
        txtChildCount.Name = "txtChildCount"
        txtChildCount.Size = New Size(101, 23)
        txtChildCount.TabIndex = 32
        txtChildCount.Text = "طفل"
        ' 
        ' txtInfantCount
        ' 
        txtInfantCount.Anchor = AnchorStyles.Top
        txtInfantCount.Location = New Point(498, 43)
        txtInfantCount.Name = "txtInfantCount"
        txtInfantCount.Size = New Size(75, 23)
        txtInfantCount.TabIndex = 31
        txtInfantCount.Text = "رضيع"
        ' 
        ' txtAdultCount
        ' 
        txtAdultCount.Anchor = AnchorStyles.Top
        txtAdultCount.Location = New Point(284, 43)
        txtAdultCount.Name = "txtAdultCount"
        txtAdultCount.Size = New Size(101, 23)
        txtAdultCount.TabIndex = 30
        txtAdultCount.Text = "بالغ"
        ' 
        ' dgvData
        ' 
        dgvData.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvData.BackgroundColor = Color.White
        dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvData.Location = New Point(1072, 72)
        dgvData.Name = "dgvData"
        dgvData.Size = New Size(814, 408)
        dgvData.TabIndex = 29
        ' 
        ' dgvAgents
        ' 
        dgvAgents.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvAgents.BackgroundColor = Color.White
        dgvAgents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvAgents.Location = New Point(12, 72)
        dgvAgents.Name = "dgvAgents"
        dgvAgents.Size = New Size(1054, 408)
        dgvAgents.TabIndex = 28
        ' 
        ' cmbTrips
        ' 
        cmbTrips.Anchor = AnchorStyles.Top
        cmbTrips.FormattingEnabled = True
        cmbTrips.Items.AddRange(New Object() {"افتراضي"})
        cmbTrips.Location = New Point(12, 43)
        cmbTrips.Name = "cmbTrips"
        cmbTrips.Size = New Size(144, 23)
        cmbTrips.TabIndex = 27
        cmbTrips.Text = "اسم الوكيل"
        ' 
        ' txtPilgrimsWithoutProgram
        ' 
        txtPilgrimsWithoutProgram.Anchor = AnchorStyles.Top
        txtPilgrimsWithoutProgram.Location = New Point(685, 43)
        txtPilgrimsWithoutProgram.Name = "txtPilgrimsWithoutProgram"
        txtPilgrimsWithoutProgram.Size = New Size(107, 23)
        txtPilgrimsWithoutProgram.TabIndex = 26
        txtPilgrimsWithoutProgram.Text = "معتمر بدون برنامج"
        ' 
        ' txtPilgrimsWithoutVisa
        ' 
        txtPilgrimsWithoutVisa.Anchor = AnchorStyles.Top
        txtPilgrimsWithoutVisa.Location = New Point(579, 43)
        txtPilgrimsWithoutVisa.Name = "txtPilgrimsWithoutVisa"
        txtPilgrimsWithoutVisa.Size = New Size(100, 23)
        txtPilgrimsWithoutVisa.TabIndex = 25
        txtPilgrimsWithoutVisa.Text = "معتمر بدون فيزا"
        ' 
        ' txtAgentName
        ' 
        txtAgentName.Anchor = AnchorStyles.Top
        txtAgentName.Location = New Point(162, 43)
        txtAgentName.Name = "txtAgentName"
        txtAgentName.Size = New Size(116, 23)
        txtAgentName.TabIndex = 24
        txtAgentName.Text = "اسم المتعهد"
        ' 
        ' btnSaveAgentData
        ' 
        btnSaveAgentData.Anchor = AnchorStyles.Top
        btnSaveAgentData.Location = New Point(1072, 43)
        btnSaveAgentData.Name = "btnSaveAgentData"
        btnSaveAgentData.Size = New Size(814, 25)
        btnSaveAgentData.TabIndex = 23
        btnSaveAgentData.Text = "حفظ بيانات الرحلة"
        btnSaveAgentData.UseVisualStyleBackColor = True
        ' 
        ' txtTripName
        ' 
        txtTripName.Anchor = AnchorStyles.Top
        txtTripName.Location = New Point(12, 12)
        txtTripName.Name = "txtTripName"
        txtTripName.Size = New Size(480, 23)
        txtTripName.TabIndex = 22
        txtTripName.Text = "اسم الرحلة"
        ' 
        ' dtpTripDate
        ' 
        dtpTripDate.Anchor = AnchorStyles.Top
        dtpTripDate.Location = New Point(661, 10)
        dtpTripDate.Name = "dtpTripDate"
        dtpTripDate.Size = New Size(202, 23)
        dtpTripDate.TabIndex = 21
        ' 
        ' btnCreateTrip
        ' 
        btnCreateTrip.Anchor = AnchorStyles.Top
        btnCreateTrip.Location = New Point(869, 9)
        btnCreateTrip.Name = "btnCreateTrip"
        btnCreateTrip.Size = New Size(1017, 24)
        btnCreateTrip.TabIndex = 20
        btnCreateTrip.Text = "ادارج رحلة"
        btnCreateTrip.UseVisualStyleBackColor = True
        ' 
        ' TripForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1898, 487)
        Controls.Add(btnSaveAgentChanges)
        Controls.Add(txtAgentNotes)
        Controls.Add(txtTripNotes)
        Controls.Add(lblTotalPilgrims)
        Controls.Add(txtChildCount)
        Controls.Add(txtInfantCount)
        Controls.Add(txtAdultCount)
        Controls.Add(dgvData)
        Controls.Add(dgvAgents)
        Controls.Add(cmbTrips)
        Controls.Add(txtPilgrimsWithoutProgram)
        Controls.Add(txtPilgrimsWithoutVisa)
        Controls.Add(txtAgentName)
        Controls.Add(btnSaveAgentData)
        Controls.Add(txtTripName)
        Controls.Add(dtpTripDate)
        Controls.Add(btnCreateTrip)
        Name = "TripForm"
        Text = "TripForm"
        CType(dgvData, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvAgents, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnSaveAgentChanges As Button
    Friend WithEvents txtAgentNotes As TextBox
    Friend WithEvents txtTripNotes As TextBox
    Friend WithEvents lblTotalPilgrims As Label
    Friend WithEvents txtChildCount As TextBox
    Friend WithEvents txtInfantCount As TextBox
    Friend WithEvents txtAdultCount As TextBox
    Friend WithEvents dgvData As DataGridView
    Friend WithEvents dgvAgents As DataGridView
    Friend WithEvents cmbTrips As ComboBox
    Friend WithEvents txtPilgrimsWithoutProgram As TextBox
    Friend WithEvents txtPilgrimsWithoutVisa As TextBox
    Friend WithEvents txtAgentName As TextBox
    Friend WithEvents btnSaveAgentData As Button
    Friend WithEvents txtTripName As TextBox
    Friend WithEvents dtpTripDate As DateTimePicker
    Friend WithEvents btnCreateTrip As Button
End Class
