namespace NetworkConsole
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ConsoleWindow = new System.Windows.Forms.TextBox();
            this.BroadcastTimer = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BroadcastBtn = new System.Windows.Forms.ToolStripButton();
            this.MyIPLbl = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConsoleWindow
            // 
            this.ConsoleWindow.BackColor = System.Drawing.Color.White;
            this.ConsoleWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsoleWindow.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsoleWindow.Location = new System.Drawing.Point(0, 0);
            this.ConsoleWindow.Multiline = true;
            this.ConsoleWindow.Name = "ConsoleWindow";
            this.ConsoleWindow.ReadOnly = true;
            this.ConsoleWindow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ConsoleWindow.Size = new System.Drawing.Size(800, 450);
            this.ConsoleWindow.TabIndex = 0;
            // 
            // BroadcastTimer
            // 
            this.BroadcastTimer.Tick += new System.EventHandler(this.BroadcastTimer_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BroadcastBtn,
            this.MyIPLbl});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BroadcastBtn
            // 
            this.BroadcastBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BroadcastBtn.Image = global::NetworkConsole.Properties.Resources.network;
            this.BroadcastBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BroadcastBtn.Name = "BroadcastBtn";
            this.BroadcastBtn.Size = new System.Drawing.Size(23, 22);
            this.BroadcastBtn.Text = "Broadcast";
            this.BroadcastBtn.Click += new System.EventHandler(this.BroadcastBtn_Click);
            // 
            // MyIPLbl
            // 
            this.MyIPLbl.Name = "MyIPLbl";
            this.MyIPLbl.Size = new System.Drawing.Size(34, 22);
            this.MyIPLbl.Text = "MyIP";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.ConsoleWindow);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "MyRetailerMobileConsole";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ConsoleWindow;
        private System.Windows.Forms.Timer BroadcastTimer;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BroadcastBtn;
        private System.Windows.Forms.ToolStripLabel MyIPLbl;
    }
}

