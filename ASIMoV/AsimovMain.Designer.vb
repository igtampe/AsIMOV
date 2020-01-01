<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AsimovMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AsimovMain))
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.ChangePinBTN = New System.Windows.Forms.Button()
        Me.ModIncomeBTN = New System.Windows.Forms.Button()
        Me.RefreshBTN = New System.Windows.Forms.Button()
        Me.AddFundsBTN = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TotalBLabel = New System.Windows.Forms.Label()
        Me.RIVERBLabel = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GBANKBLabel = New System.Windows.Forms.Label()
        Me.UMSNBBLabel = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.UMSNBCheck = New System.Windows.Forms.CheckBox()
        Me.GBANKCheck = New System.Windows.Forms.CheckBox()
        Me.RIVERCheck = New System.Windows.Forms.CheckBox()
        Me.NameLabel = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TotalLabel = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.EILabel = New System.Windows.Forms.Label()
        Me.IncomeLabel = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.CorporateCHKBX = New System.Windows.Forms.CheckBox()
        Me.TaxDueLabel = New System.Windows.Forms.Label()
        Me.TaxBracketLabel = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ActionsGroupBox = New System.Windows.Forms.GroupBox()
        Me.LoadDirectory = New System.ComponentModel.BackgroundWorker()
        Me.LoadUser = New System.ComponentModel.BackgroundWorker()
        Me.GenericBackgroundWorker = New System.ComponentModel.BackgroundWorker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.ActionsGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(12, 12)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(219, 264)
        Me.ListBox1.TabIndex = 0
        '
        'ChangePinBTN
        '
        Me.ChangePinBTN.Location = New System.Drawing.Point(100, 53)
        Me.ChangePinBTN.Name = "ChangePinBTN"
        Me.ChangePinBTN.Size = New System.Drawing.Size(75, 23)
        Me.ChangePinBTN.TabIndex = 19
        Me.ChangePinBTN.Text = "Change Pin"
        Me.ChangePinBTN.UseVisualStyleBackColor = True
        '
        'ModIncomeBTN
        '
        Me.ModIncomeBTN.Location = New System.Drawing.Point(19, 53)
        Me.ModIncomeBTN.Name = "ModIncomeBTN"
        Me.ModIncomeBTN.Size = New System.Drawing.Size(75, 23)
        Me.ModIncomeBTN.TabIndex = 18
        Me.ModIncomeBTN.Text = "Mod Income"
        Me.ModIncomeBTN.UseVisualStyleBackColor = True
        '
        'RefreshBTN
        '
        Me.RefreshBTN.Location = New System.Drawing.Point(100, 24)
        Me.RefreshBTN.Name = "RefreshBTN"
        Me.RefreshBTN.Size = New System.Drawing.Size(75, 23)
        Me.RefreshBTN.TabIndex = 16
        Me.RefreshBTN.Text = "Refresh"
        Me.RefreshBTN.UseVisualStyleBackColor = True
        '
        'AddFundsBTN
        '
        Me.AddFundsBTN.Location = New System.Drawing.Point(19, 24)
        Me.AddFundsBTN.Name = "AddFundsBTN"
        Me.AddFundsBTN.Size = New System.Drawing.Size(75, 23)
        Me.AddFundsBTN.TabIndex = 17
        Me.AddFundsBTN.Text = "Add Funds"
        Me.AddFundsBTN.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TotalBLabel)
        Me.GroupBox2.Controls.Add(Me.RIVERBLabel)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.GBANKBLabel)
        Me.GroupBox2.Controls.Add(Me.UMSNBBLabel)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(237, 95)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 89)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Balances"
        '
        'TotalBLabel
        '
        Me.TotalBLabel.AutoSize = True
        Me.TotalBLabel.Location = New System.Drawing.Point(123, 68)
        Me.TotalBLabel.Name = "TotalBLabel"
        Me.TotalBLabel.Size = New System.Drawing.Size(0, 13)
        Me.TotalBLabel.TabIndex = 16
        '
        'RIVERBLabel
        '
        Me.RIVERBLabel.AutoSize = True
        Me.RIVERBLabel.Location = New System.Drawing.Point(123, 42)
        Me.RIVERBLabel.Name = "RIVERBLabel"
        Me.RIVERBLabel.Size = New System.Drawing.Size(0, 13)
        Me.RIVERBLabel.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Total"
        '
        'GBANKBLabel
        '
        Me.GBANKBLabel.AutoSize = True
        Me.GBANKBLabel.Location = New System.Drawing.Point(123, 29)
        Me.GBANKBLabel.Name = "GBANKBLabel"
        Me.GBANKBLabel.Size = New System.Drawing.Size(0, 13)
        Me.GBANKBLabel.TabIndex = 12
        '
        'UMSNBBLabel
        '
        Me.UMSNBBLabel.AutoSize = True
        Me.UMSNBBLabel.Location = New System.Drawing.Point(123, 16)
        Me.UMSNBBLabel.Name = "UMSNBBLabel"
        Me.UMSNBBLabel.Size = New System.Drawing.Size(0, 13)
        Me.UMSNBBLabel.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Riverside Bank"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "GBank"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "UMS National Bank"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.UMSNBCheck)
        Me.GroupBox1.Controls.Add(Me.GBANKCheck)
        Me.GroupBox1.Controls.Add(Me.RIVERCheck)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(237, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(406, 43)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Registered Banks"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(27, 19)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(101, 13)
        Me.Label19.TabIndex = 12
        Me.Label19.Text = "UMS National Bank"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(153, 19)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 13)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "GBank"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(221, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Riverside Bank"
        '
        'UMSNBCheck
        '
        Me.UMSNBCheck.AutoSize = True
        Me.UMSNBCheck.Enabled = False
        Me.UMSNBCheck.Location = New System.Drawing.Point(6, 19)
        Me.UMSNBCheck.Name = "UMSNBCheck"
        Me.UMSNBCheck.Size = New System.Drawing.Size(15, 14)
        Me.UMSNBCheck.TabIndex = 2
        Me.UMSNBCheck.UseVisualStyleBackColor = True
        '
        'GBANKCheck
        '
        Me.GBANKCheck.AutoSize = True
        Me.GBANKCheck.Enabled = False
        Me.GBANKCheck.Location = New System.Drawing.Point(132, 19)
        Me.GBANKCheck.Name = "GBANKCheck"
        Me.GBANKCheck.Size = New System.Drawing.Size(15, 14)
        Me.GBANKCheck.TabIndex = 3
        Me.GBANKCheck.UseVisualStyleBackColor = True
        '
        'RIVERCheck
        '
        Me.RIVERCheck.AutoSize = True
        Me.RIVERCheck.Enabled = False
        Me.RIVERCheck.Location = New System.Drawing.Point(200, 19)
        Me.RIVERCheck.Name = "RIVERCheck"
        Me.RIVERCheck.Size = New System.Drawing.Size(15, 14)
        Me.RIVERCheck.TabIndex = 4
        Me.RIVERCheck.UseVisualStyleBackColor = True
        '
        'NameLabel
        '
        Me.NameLabel.AutoSize = True
        Me.NameLabel.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NameLabel.Location = New System.Drawing.Point(237, 12)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(0, 32)
        Me.NameLabel.TabIndex = 11
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TotalLabel)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.EILabel)
        Me.GroupBox3.Controls.Add(Me.IncomeLabel)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Location = New System.Drawing.Point(443, 95)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(200, 89)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Income"
        '
        'TotalLabel
        '
        Me.TotalLabel.AutoSize = True
        Me.TotalLabel.Location = New System.Drawing.Point(123, 68)
        Me.TotalLabel.Name = "TotalLabel"
        Me.TotalLabel.Size = New System.Drawing.Size(0, 13)
        Me.TotalLabel.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 68)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Total"
        '
        'EILabel
        '
        Me.EILabel.AutoSize = True
        Me.EILabel.Location = New System.Drawing.Point(123, 29)
        Me.EILabel.Name = "EILabel"
        Me.EILabel.Size = New System.Drawing.Size(0, 13)
        Me.EILabel.TabIndex = 12
        '
        'IncomeLabel
        '
        Me.IncomeLabel.AutoSize = True
        Me.IncomeLabel.Location = New System.Drawing.Point(123, 16)
        Me.IncomeLabel.Name = "IncomeLabel"
        Me.IncomeLabel.Size = New System.Drawing.Size(0, 13)
        Me.IncomeLabel.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 29)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 13)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "Extra Income"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(82, 13)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "Monthly Income"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.CorporateCHKBX)
        Me.GroupBox4.Controls.Add(Me.TaxDueLabel)
        Me.GroupBox4.Controls.Add(Me.TaxBracketLabel)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Location = New System.Drawing.Point(237, 190)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(200, 89)
        Me.GroupBox4.TabIndex = 13
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Tax"
        '
        'CorporateCHKBX
        '
        Me.CorporateCHKBX.AutoSize = True
        Me.CorporateCHKBX.Enabled = False
        Me.CorporateCHKBX.Location = New System.Drawing.Point(9, 57)
        Me.CorporateCHKBX.Name = "CorporateCHKBX"
        Me.CorporateCHKBX.Size = New System.Drawing.Size(72, 17)
        Me.CorporateCHKBX.TabIndex = 15
        Me.CorporateCHKBX.Text = "Corporate"
        Me.CorporateCHKBX.UseVisualStyleBackColor = True
        '
        'TaxDueLabel
        '
        Me.TaxDueLabel.AutoSize = True
        Me.TaxDueLabel.Location = New System.Drawing.Point(123, 29)
        Me.TaxDueLabel.Name = "TaxDueLabel"
        Me.TaxDueLabel.Size = New System.Drawing.Size(0, 13)
        Me.TaxDueLabel.TabIndex = 12
        '
        'TaxBracketLabel
        '
        Me.TaxBracketLabel.AutoSize = True
        Me.TaxBracketLabel.Location = New System.Drawing.Point(123, 16)
        Me.TaxBracketLabel.Name = "TaxBracketLabel"
        Me.TaxBracketLabel.Size = New System.Drawing.Size(0, 13)
        Me.TaxBracketLabel.TabIndex = 11
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 29)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(52, 13)
        Me.Label17.TabIndex = 9
        Me.Label17.Text = "Total Tax"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 16)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(65, 13)
        Me.Label18.TabIndex = 8
        Me.Label18.Text = "Tax Bracket"
        '
        'ActionsGroupBox
        '
        Me.ActionsGroupBox.Controls.Add(Me.ChangePinBTN)
        Me.ActionsGroupBox.Controls.Add(Me.AddFundsBTN)
        Me.ActionsGroupBox.Controls.Add(Me.ModIncomeBTN)
        Me.ActionsGroupBox.Controls.Add(Me.RefreshBTN)
        Me.ActionsGroupBox.Location = New System.Drawing.Point(443, 190)
        Me.ActionsGroupBox.Name = "ActionsGroupBox"
        Me.ActionsGroupBox.Size = New System.Drawing.Size(200, 89)
        Me.ActionsGroupBox.TabIndex = 13
        Me.ActionsGroupBox.TabStop = False
        Me.ActionsGroupBox.Text = "Actions"
        '
        'LoadDirectory
        '
        '
        'LoadUser
        '
        Me.LoadUser.WorkerReportsProgress = True
        '
        'GenericBackgroundWorker
        '
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(443, 290)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(200, 23)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "Generate Report"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(237, 290)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(200, 23)
        Me.Button2.TabIndex = 15
        Me.Button2.Text = "Convert Report to Excel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'AsimovMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(655, 325)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.ActionsGroupBox)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.NameLabel)
        Me.Controls.Add(Me.ListBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AsimovMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ActionsGroupBox.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents ChangePinBTN As Button
    Friend WithEvents ModIncomeBTN As Button
    Friend WithEvents RefreshBTN As Button
    Friend WithEvents AddFundsBTN As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TotalBLabel As Label
    Friend WithEvents RIVERBLabel As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents GBANKBLabel As Label
    Friend WithEvents UMSNBBLabel As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents UMSNBCheck As CheckBox
    Friend WithEvents GBANKCheck As CheckBox
    Friend WithEvents RIVERCheck As CheckBox
    Friend WithEvents NameLabel As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents TotalLabel As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents EILabel As Label
    Friend WithEvents IncomeLabel As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents TaxDueLabel As Label
    Friend WithEvents TaxBracketLabel As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents ActionsGroupBox As GroupBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents LoadDirectory As System.ComponentModel.BackgroundWorker
    Friend WithEvents LoadUser As System.ComponentModel.BackgroundWorker
    Friend WithEvents GenericBackgroundWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents Button1 As Button
    Friend WithEvents CorporateCHKBX As CheckBox
    Friend WithEvents Button2 As Button
End Class
