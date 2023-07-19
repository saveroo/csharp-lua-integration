namespace CSharpLuaIntegration;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.executeBtn = new System.Windows.Forms.Button();
            this.pluginListBox = new System.Windows.Forms.ListBox();
            this.tboxPluginDescription = new System.Windows.Forms.TextBox();
            this.labelPluginName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.executeBtn.Location = new System.Drawing.Point(12, 158);
            this.executeBtn.Name = "executeBtn";
            this.executeBtn.Size = new System.Drawing.Size(161, 41);
            this.executeBtn.TabIndex = 0;
            this.executeBtn.Text = "Execute";
            this.executeBtn.UseVisualStyleBackColor = true;
            // 
            // pluginListBox
            // 
            this.pluginListBox.FormattingEnabled = true;
            this.pluginListBox.ItemHeight = 15;
            this.pluginListBox.Location = new System.Drawing.Point(179, 28);
            this.pluginListBox.Name = "pluginListBox";
            this.pluginListBox.Size = new System.Drawing.Size(161, 169);
            this.pluginListBox.TabIndex = 1;
            // 
            // tboxPluginDescription
            // 
            this.tboxPluginDescription.Location = new System.Drawing.Point(12, 27);
            this.tboxPluginDescription.Multiline = true;
            this.tboxPluginDescription.Name = "tboxPluginDescription";
            this.tboxPluginDescription.ReadOnly = true;
            this.tboxPluginDescription.Size = new System.Drawing.Size(161, 125);
            this.tboxPluginDescription.TabIndex = 3;
            this.tboxPluginDescription.Text = "Description:";
            // 
            // labelPluginName
            // 
            this.labelPluginName.AutoSize = true;
            this.labelPluginName.Location = new System.Drawing.Point(12, 9);
            this.labelPluginName.Name = "labelPluginName";
            this.labelPluginName.Size = new System.Drawing.Size(44, 15);
            this.labelPluginName.TabIndex = 4;
            this.labelPluginName.Text = "Plugin:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 211);
            this.Controls.Add(this.labelPluginName);
            this.Controls.Add(this.tboxPluginDescription);
            this.Controls.Add(this.pluginListBox);
            this.Controls.Add(this.executeBtn);
            this.Name = "MainForm";
            this.Text = "Lua";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private Button executeBtn;
    private ListBox pluginListBox;
    private TextBox tboxPluginDescription;
    private Label labelPluginName;
}