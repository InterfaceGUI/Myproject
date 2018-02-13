<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
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

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(116, 26)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 27)
        Me.ComboBox1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(243, 23)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(116, 33)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "開啟通訊埠"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(243, 58)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(116, 33)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "重新整理"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"2400", "4800", "9600", "19200", "38400", "57600", "115200", "230400", "460800", "921600", "1382400"})
        Me.ComboBox2.Location = New System.Drawing.Point(116, 62)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(121, 27)
        Me.ComboBox2.TabIndex = 2
        Me.ComboBox2.Text = "9600"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(243, 97)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(116, 70)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "設定"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(116, 98)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(121, 30)
        Me.TextBox1.TabIndex = 4
        Me.TextBox1.Text = "HC-00"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(116, 137)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(121, 30)
        Me.TextBox2.TabIndex = 5
        Me.TextBox2.Text = "1234"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TextBox3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.RadioButton2)
        Me.Panel1.Controls.Add(Me.RadioButton1)
        Me.Panel1.Location = New System.Drawing.Point(365, 26)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(170, 141)
        Me.Panel1.TabIndex = 6
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(0, 110)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(170, 30)
        Me.TextBox3.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(0, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(166, 19)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "從端藍牙裝置位址:"
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Checked = True
        Me.RadioButton2.Location = New System.Drawing.Point(34, 44)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(84, 23)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "從控端"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(34, 14)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(84, 23)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.Text = "主控端"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(382, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(142, 19)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "主端與從端選擇"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Location = New System.Drawing.Point(12, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 27)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "序列埠:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Location = New System.Drawing.Point(12, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 27)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "連線速率"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Location = New System.Drawing.Point(12, 98)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 30)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "藍芽名稱:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Location = New System.Drawing.Point(12, 137)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 30)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "藍芽PIN碼:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(12, 189)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(104, 49)
        Me.Button4.TabIndex = 9
        Me.Button4.Text = "線路接法"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(28, 15)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(76, 23)
        Me.RadioButton3.TabIndex = 11
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "HC-05"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Location = New System.Drawing.Point(110, 15)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(76, 23)
        Me.RadioButton4.TabIndex = 12
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "HC-06"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.RadioButton3)
        Me.Panel2.Controls.Add(Me.RadioButton4)
        Me.Panel2.Location = New System.Drawing.Point(134, 189)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(215, 49)
        Me.Panel2.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(180, 175)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(123, 19)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "選擇藍芽模組"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(364, 189)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(171, 23)
        Me.ProgressBar1.TabIndex = 15
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("新細明體", 8.0!)
        Me.Button5.Location = New System.Drawing.Point(364, 214)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(172, 23)
        Me.Button5.TabIndex = 16
        Me.Button5.Text = "日誌"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 19
        Me.ListBox1.Location = New System.Drawing.Point(13, 259)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(523, 213)
        Me.ListBox1.TabIndex = 17
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(548, 481)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Font = New System.Drawing.Font("新細明體", 14.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(564, 520)
        Me.MinimumSize = New System.Drawing.Size(564, 285)
        Me.Name = "Form1"
        Me.Text = "藍芽設定程式"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Button3 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton4 As RadioButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Button5 As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
End Class
