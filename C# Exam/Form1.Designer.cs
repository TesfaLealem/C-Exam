partial class Form1
{
    private System.ComponentModel.IContainer components = null;
    private Button btnSetTargetFile;
    private Label lblFilePath;
    private TextBox txtChanges;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.btnSetTargetFile = new Button();
        this.lblFilePath = new Label();
        this.txtChanges = new TextBox();
        this.SuspendLayout();

        // 
        // btnSetTargetFile
        // 
        this.btnSetTargetFile.Location = new System.Drawing.Point(13, 13);
        this.btnSetTargetFile.Name = "btnSetTargetFile";
        this.btnSetTargetFile.Size = new System.Drawing.Size(100, 23);
        this.btnSetTargetFile.TabIndex = 0;
        this.btnSetTargetFile.Text = "Set Target File";
        this.btnSetTargetFile.UseVisualStyleBackColor = true;
        this.btnSetTargetFile.Click += new System.EventHandler(this.btnSetTargetFile_Click);

        // 
        // lblFilePath
        // 
        this.lblFilePath.AutoSize = true;
        this.lblFilePath.Location = new System.Drawing.Point(120, 18);
        this.lblFilePath.Name = "lblFilePath";
        this.lblFilePath.Size = new System.Drawing.Size(0, 13);
        this.lblFilePath.TabIndex = 1;

        // 
        // txtChanges
        // 
        this.txtChanges.Location = new System.Drawing.Point(13, 43);
        this.txtChanges.Multiline = true;
        this.txtChanges.Name = "txtChanges";
        this.txtChanges.ScrollBars = ScrollBars.Vertical;
        this.txtChanges.Size = new System.Drawing.Size(775, 395);
        this.txtChanges.TabIndex = 2;

        // 
        // Form1
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Controls.Add(this.txtChanges);
        this.Controls.Add(this.lblFilePath);
        this.Controls.Add(this.btnSetTargetFile);
        this.Name = "Form1";
        this.Text = "File Change Monitor";
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
