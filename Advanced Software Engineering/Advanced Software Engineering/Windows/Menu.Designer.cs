namespace Advanced_Software_Engineering
{
    /// <summary>
    /// Auto generated code.
    /// </summary>
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.InteractivePreviewButton = new System.Windows.Forms.Button();
            this.TextEditorButton = new System.Windows.Forms.Button();
            this.AboutButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InteractivePreviewButton
            // 
            this.InteractivePreviewButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.InteractivePreviewButton.Location = new System.Drawing.Point(0, 26);
            this.InteractivePreviewButton.Name = "InteractivePreviewButton";
            this.InteractivePreviewButton.Size = new System.Drawing.Size(172, 23);
            this.InteractivePreviewButton.TabIndex = 0;
            this.InteractivePreviewButton.Text = "Interactive Preview";
            this.InteractivePreviewButton.UseVisualStyleBackColor = true;
            this.InteractivePreviewButton.Click += new System.EventHandler(this.InteractivePreviewClick);
            // 
            // TextEditorButton
            // 
            this.TextEditorButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.TextEditorButton.Location = new System.Drawing.Point(0, 49);
            this.TextEditorButton.Name = "TextEditorButton";
            this.TextEditorButton.Size = new System.Drawing.Size(172, 23);
            this.TextEditorButton.TabIndex = 0;
            this.TextEditorButton.Text = "Text Editor";
            this.TextEditorButton.UseVisualStyleBackColor = true;
            this.TextEditorButton.Click += new System.EventHandler(this.TextEditorClick);
            // 
            // AboutButton
            // 
            this.AboutButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.AboutButton.Location = new System.Drawing.Point(0, 72);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(172, 23);
            this.AboutButton.TabIndex = 0;
            this.AboutButton.Text = "About";
            this.AboutButton.UseVisualStyleBackColor = true;
            this.AboutButton.Click += new System.EventHandler(this.AboutWindowClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Advanced Software Engineering";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Drawing Program";
            // 
            // ExitButton
            // 
            this.ExitButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ExitButton.Location = new System.Drawing.Point(0, 95);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(172, 23);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitClick);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(172, 118);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.AboutButton);
            this.Controls.Add(this.TextEditorButton);
            this.Controls.Add(this.InteractivePreviewButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Menu";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button InteractivePreviewButton;
        private System.Windows.Forms.Button TextEditorButton;
        private System.Windows.Forms.Button AboutButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ExitButton;
    }
}

