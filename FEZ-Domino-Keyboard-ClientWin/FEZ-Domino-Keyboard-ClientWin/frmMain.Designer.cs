namespace FEZ_Domino_Keyboard_ClientWin
{
    partial class frmMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblPosition = new System.Windows.Forms.Label();
            this.picBoxPad = new System.Windows.Forms.PictureBox();
            this.lblMouseButton = new System.Windows.Forms.Label();
            this.btnSendCtrlAltDel = new System.Windows.Forms.Button();
            this.lblKey = new System.Windows.Forms.Label();
            this.btnSendShiftAlt = new System.Windows.Forms.Button();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.btnSendEnter = new System.Windows.Forms.Button();
            this.lblDxDy = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPad)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Address:";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(185, 10);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Tag = "Подключиться";
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(12, 48);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(76, 13);
            this.lblPosition.TabIndex = 3;
            this.lblPosition.Text = "MousePosition";
            // 
            // picBoxPad
            // 
            this.picBoxPad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxPad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxPad.Location = new System.Drawing.Point(12, 84);
            this.picBoxPad.Name = "picBoxPad";
            this.picBoxPad.Size = new System.Drawing.Size(776, 340);
            this.picBoxPad.TabIndex = 4;
            this.picBoxPad.TabStop = false;
            this.picBoxPad.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBoxPad_MouseDown);
            this.picBoxPad.MouseEnter += new System.EventHandler(this.picBoxPad_MouseEnter);
            this.picBoxPad.MouseLeave += new System.EventHandler(this.picBoxPad_MouseLeave);
            this.picBoxPad.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.picBoxPad.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picBoxPad_MouseUp);
            // 
            // lblMouseButton
            // 
            this.lblMouseButton.AutoSize = true;
            this.lblMouseButton.Location = new System.Drawing.Point(182, 48);
            this.lblMouseButton.Name = "lblMouseButton";
            this.lblMouseButton.Size = new System.Drawing.Size(70, 13);
            this.lblMouseButton.TabIndex = 5;
            this.lblMouseButton.Text = "MouseButton";
            // 
            // btnSendCtrlAltDel
            // 
            this.btnSendCtrlAltDel.Location = new System.Drawing.Point(491, 4);
            this.btnSendCtrlAltDel.Name = "btnSendCtrlAltDel";
            this.btnSendCtrlAltDel.Size = new System.Drawing.Size(128, 23);
            this.btnSendCtrlAltDel.TabIndex = 6;
            this.btnSendCtrlAltDel.Text = "Send Ctr+Alt+Del";
            this.btnSendCtrlAltDel.UseVisualStyleBackColor = true;
            this.btnSendCtrlAltDel.Click += new System.EventHandler(this.btnSendKey);
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(354, 48);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(25, 13);
            this.lblKey.TabIndex = 8;
            this.lblKey.Text = "Key";
            // 
            // btnSendShiftAlt
            // 
            this.btnSendShiftAlt.Location = new System.Drawing.Point(572, 33);
            this.btnSendShiftAlt.Name = "btnSendShiftAlt";
            this.btnSendShiftAlt.Size = new System.Drawing.Size(128, 23);
            this.btnSendShiftAlt.TabIndex = 9;
            this.btnSendShiftAlt.Text = "Send Shift+Alt";
            this.btnSendShiftAlt.UseVisualStyleBackColor = true;
            this.btnSendShiftAlt.Click += new System.EventHandler(this.btnSendKey);
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(79, 12);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(100, 20);
            this.txtIPAddress.TabIndex = 11;
            // 
            // btnSendEnter
            // 
            this.btnSendEnter.Location = new System.Drawing.Point(491, 33);
            this.btnSendEnter.Name = "btnSendEnter";
            this.btnSendEnter.Size = new System.Drawing.Size(75, 23);
            this.btnSendEnter.TabIndex = 12;
            this.btnSendEnter.Text = "Send Enter";
            this.btnSendEnter.UseVisualStyleBackColor = true;
            this.btnSendEnter.Click += new System.EventHandler(this.btnSendKey);
            // 
            // lblDxDy
            // 
            this.lblDxDy.AutoSize = true;
            this.lblDxDy.Location = new System.Drawing.Point(12, 61);
            this.lblDxDy.Name = "lblDxDy";
            this.lblDxDy.Size = new System.Drawing.Size(43, 13);
            this.lblDxDy.TabIndex = 13;
            this.lblDxDy.Text = "lblDxDy";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 436);
            this.Controls.Add(this.lblDxDy);
            this.Controls.Add(this.btnSendEnter);
            this.Controls.Add(this.txtIPAddress);
            this.Controls.Add(this.btnSendShiftAlt);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.btnSendCtrlAltDel);
            this.Controls.Add(this.lblMouseButton);
            this.Controls.Add(this.picBoxPad);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label1);
            this.Name = "frmMain";
            this.Text = "FEZ-Domino-Keyboard-ClientWin";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.PictureBox picBoxPad;
        private System.Windows.Forms.Label lblMouseButton;
        private System.Windows.Forms.Button btnSendCtrlAltDel;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.Button btnSendShiftAlt;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.Button btnSendEnter;
        private System.Windows.Forms.Label lblDxDy;
    }
}

