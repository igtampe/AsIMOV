<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GenerateReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GenerateReport))
        Me.MainLBL = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.StatusLBL = New System.Windows.Forms.Label()
        Me.DetailsTextbBox = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DoTheCoso = New System.ComponentModel.BackgroundWorker()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.OpenReportBTN = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainLBL
        '
        Me.MainLBL.AutoSize = True
        Me.MainLBL.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainLBL.Location = New System.Drawing.Point(116, 9)
        Me.MainLBL.Name = "MainLBL"
        Me.MainLBL.Size = New System.Drawing.Size(254, 31)
        Me.MainLBL.TabIndex = 1
        Me.MainLBL.Text = "Generating Report"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(123, 58)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(494, 23)
        Me.ProgressBar1.TabIndex = 2
        '
        'StatusLBL
        '
        Me.StatusLBL.AutoSize = True
        Me.StatusLBL.Location = New System.Drawing.Point(120, 40)
        Me.StatusLBL.Name = "StatusLBL"
        Me.StatusLBL.Size = New System.Drawing.Size(73, 13)
        Me.StatusLBL.TabIndex = 3
        Me.StatusLBL.Text = "Please Wait..."
        '
        'DetailsTextbBox
        '
        Me.DetailsTextbBox.Location = New System.Drawing.Point(6, 19)
        Me.DetailsTextbBox.Multiline = True
        Me.DetailsTextbBox.Name = "DetailsTextbBox"
        Me.DetailsTextbBox.ReadOnly = True
        Me.DetailsTextbBox.Size = New System.Drawing.Size(597, 212)
        Me.DetailsTextbBox.TabIndex = 4
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(461, 91)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Details"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(542, 91)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DetailsTextbBox)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 124)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(609, 237)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Details"
        '
        'DoTheCoso
        '
        Me.DoTheCoso.WorkerReportsProgress = True
        Me.DoTheCoso.WorkerSupportsCancellation = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ASIMoV.My.Resources.Resources.XVo6
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(98, 77)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'OpenReportBTN
        '
        Me.OpenReportBTN.Location = New System.Drawing.Point(336, 91)
        Me.OpenReportBTN.Name = "OpenReportBTN"
        Me.OpenReportBTN.Size = New System.Drawing.Size(119, 23)
        Me.OpenReportBTN.TabIndex = 8
        Me.OpenReportBTN.Text = "Convert Report"
        Me.OpenReportBTN.UseVisualStyleBackColor = True
        '
        'GenerateReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(633, 373)
        Me.Controls.Add(Me.OpenReportBTN)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.StatusLBL)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.MainLBL)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(649, 411)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(649, 164)
        Me.Name = "GenerateReport"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generating Report"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents MainLBL As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents StatusLBL As Label
    Friend WithEvents DetailsTextbBox As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DoTheCoso As System.ComponentModel.BackgroundWorker
    Friend WithEvents OpenReportBTN As Button
End Class
