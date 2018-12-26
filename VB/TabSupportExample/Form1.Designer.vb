Namespace TabSupportExample
    Partial Public Class Form1
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.panelControl1 = New DevExpress.XtraEditors.PanelControl()
            Me.toggleSwitchTimer = New DevExpress.XtraEditors.ToggleSwitch()
            Me.btnModify = New DevExpress.XtraEditors.SimpleButton()
            Me.btnCreate = New DevExpress.XtraEditors.SimpleButton()
            Me.dashboardViewer1 = New DevExpress.DashboardWin.DashboardViewer(Me.components)
            CType(Me.panelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panelControl1.SuspendLayout()
            CType(Me.toggleSwitchTimer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dashboardViewer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' panelControl1
            ' 
            Me.panelControl1.Controls.Add(Me.toggleSwitchTimer)
            Me.panelControl1.Controls.Add(Me.btnModify)
            Me.panelControl1.Controls.Add(Me.btnCreate)
            Me.panelControl1.Dock = System.Windows.Forms.DockStyle.Top
            Me.panelControl1.Location = New System.Drawing.Point(0, 0)
            Me.panelControl1.Name = "panelControl1"
            Me.panelControl1.Size = New System.Drawing.Size(684, 52)
            Me.panelControl1.TabIndex = 1
            ' 
            ' toggleSwitchTimer
            ' 
            Me.toggleSwitchTimer.Enabled = False
            Me.toggleSwitchTimer.Location = New System.Drawing.Point(429, 13)
            Me.toggleSwitchTimer.Name = "toggleSwitchTimer"
            Me.toggleSwitchTimer.Properties.AutoWidth = True
            Me.toggleSwitchTimer.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far
            Me.toggleSwitchTimer.Properties.OffText = "Timer Off"
            Me.toggleSwitchTimer.Properties.OnText = "Timer On"
            Me.toggleSwitchTimer.Size = New System.Drawing.Size(119, 24)
            Me.toggleSwitchTimer.TabIndex = 3
            ' 
            ' btnModify
            ' 
            Me.btnModify.Enabled = False
            Me.btnModify.Location = New System.Drawing.Point(221, 13)
            Me.btnModify.Name = "btnModify"
            Me.btnModify.Size = New System.Drawing.Size(163, 23)
            Me.btnModify.TabIndex = 1
            Me.btnModify.Text = "Modify Tabbed Dashboard"
            ' 
            ' btnCreate
            ' 
            Me.btnCreate.Location = New System.Drawing.Point(13, 13)
            Me.btnCreate.Name = "btnCreate"
            Me.btnCreate.Size = New System.Drawing.Size(163, 23)
            Me.btnCreate.TabIndex = 0
            Me.btnCreate.Text = "Create Tabbed Dashboard"
            ' 
            ' dashboardViewer1
            ' 
            Me.dashboardViewer1.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.dashboardViewer1.Appearance.Options.UseBackColor = True
            Me.dashboardViewer1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dashboardViewer1.Location = New System.Drawing.Point(0, 52)
            Me.dashboardViewer1.Name = "dashboardViewer1"
            Me.dashboardViewer1.Size = New System.Drawing.Size(684, 437)
            Me.dashboardViewer1.TabIndex = 0
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(684, 489)
            Me.Controls.Add(Me.dashboardViewer1)
            Me.Controls.Add(Me.panelControl1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            CType(Me.panelControl1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.panelControl1.ResumeLayout(False)
            Me.panelControl1.PerformLayout()
            CType(Me.toggleSwitchTimer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dashboardViewer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private dashboardViewer1 As DevExpress.DashboardWin.DashboardViewer
        Private panelControl1 As DevExpress.XtraEditors.PanelControl
        Private WithEvents btnCreate As DevExpress.XtraEditors.SimpleButton
        Private WithEvents btnModify As DevExpress.XtraEditors.SimpleButton
        Private WithEvents toggleSwitchTimer As DevExpress.XtraEditors.ToggleSwitch
    End Class
End Namespace

