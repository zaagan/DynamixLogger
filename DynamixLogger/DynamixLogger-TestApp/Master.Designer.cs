namespace DynamixLogger_TestApp
{
    partial class Master
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
            this.btnDoSomething = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUsingDependencyInjection = new System.Windows.Forms.Button();
            this.btnLogMessageUsingDI = new System.Windows.Forms.Button();
            this.btnLogException = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnBasicLogging = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDoSomething
            // 
            this.btnDoSomething.BackColor = System.Drawing.Color.White;
            this.btnDoSomething.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(213)))), ((int)(((byte)(218)))));
            this.btnDoSomething.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoSomething.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoSomething.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDoSomething.Location = new System.Drawing.Point(222, 151);
            this.btnDoSomething.Name = "btnDoSomething";
            this.btnDoSomething.Size = new System.Drawing.Size(225, 40);
            this.btnDoSomething.TabIndex = 0;
            this.btnDoSomething.Text = "Log Normal Message ( Type 1 )";
            this.btnDoSomething.UseVisualStyleBackColor = false;
            this.btnDoSomething.Click += new System.EventHandler(this.btnDoSomething_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(217, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "DynamixLogger Examples";
            // 
            // btnUsingDependencyInjection
            // 
            this.btnUsingDependencyInjection.BackColor = System.Drawing.Color.White;
            this.btnUsingDependencyInjection.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(213)))), ((int)(((byte)(218)))));
            this.btnUsingDependencyInjection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsingDependencyInjection.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsingDependencyInjection.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUsingDependencyInjection.Location = new System.Drawing.Point(222, 243);
            this.btnUsingDependencyInjection.Name = "btnUsingDependencyInjection";
            this.btnUsingDependencyInjection.Size = new System.Drawing.Size(225, 64);
            this.btnUsingDependencyInjection.TabIndex = 3;
            this.btnUsingDependencyInjection.Text = "Log Exception Using Dependency Injection";
            this.btnUsingDependencyInjection.UseVisualStyleBackColor = false;
            this.btnUsingDependencyInjection.Click += new System.EventHandler(this.btnUsingDependencyInjection_Click);
            // 
            // btnLogMessageUsingDI
            // 
            this.btnLogMessageUsingDI.BackColor = System.Drawing.Color.White;
            this.btnLogMessageUsingDI.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(213)))), ((int)(((byte)(218)))));
            this.btnLogMessageUsingDI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogMessageUsingDI.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogMessageUsingDI.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLogMessageUsingDI.Location = new System.Drawing.Point(222, 313);
            this.btnLogMessageUsingDI.Name = "btnLogMessageUsingDI";
            this.btnLogMessageUsingDI.Size = new System.Drawing.Size(225, 64);
            this.btnLogMessageUsingDI.TabIndex = 4;
            this.btnLogMessageUsingDI.Text = "Log Message Using Dependency Injection";
            this.btnLogMessageUsingDI.UseVisualStyleBackColor = false;
            this.btnLogMessageUsingDI.Click += new System.EventHandler(this.btnLogMessageUsingDI_Click);
            // 
            // btnLogException
            // 
            this.btnLogException.BackColor = System.Drawing.Color.White;
            this.btnLogException.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(213)))), ((int)(((byte)(218)))));
            this.btnLogException.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogException.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogException.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLogException.Location = new System.Drawing.Point(222, 197);
            this.btnLogException.Name = "btnLogException";
            this.btnLogException.Size = new System.Drawing.Size(225, 40);
            this.btnLogException.TabIndex = 5;
            this.btnLogException.Text = "Log An Exception ( Type 2 )";
            this.btnLogException.UseVisualStyleBackColor = false;
            this.btnLogException.Click += new System.EventHandler(this.btnLogException_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoEllipsis = true;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMessage.Location = new System.Drawing.Point(0, 396);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(658, 46);
            this.lblMessage.TabIndex = 6;
            this.lblMessage.Text = "Welcome";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBasicLogging
            // 
            this.btnBasicLogging.BackColor = System.Drawing.Color.White;
            this.btnBasicLogging.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(213)))), ((int)(((byte)(218)))));
            this.btnBasicLogging.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBasicLogging.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBasicLogging.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBasicLogging.Location = new System.Drawing.Point(222, 105);
            this.btnBasicLogging.Name = "btnBasicLogging";
            this.btnBasicLogging.Size = new System.Drawing.Size(225, 40);
            this.btnBasicLogging.TabIndex = 7;
            this.btnBasicLogging.Text = "Basic Logging with No Configuration";
            this.btnBasicLogging.UseVisualStyleBackColor = false;
            this.btnBasicLogging.Click += new System.EventHandler(this.btnBasicLogging_Click);
            // 
            // Master
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 442);
            this.Controls.Add(this.btnBasicLogging);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnLogException);
            this.Controls.Add(this.btnLogMessageUsingDI);
            this.Controls.Add(this.btnUsingDependencyInjection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDoSomething);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximumSize = new System.Drawing.Size(674, 481);
            this.MinimumSize = new System.Drawing.Size(674, 481);
            this.Name = "Master";
            this.Text = "Master";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDoSomething;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUsingDependencyInjection;
        private System.Windows.Forms.Button btnLogMessageUsingDI;
        private System.Windows.Forms.Button btnLogException;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnBasicLogging;
    }
}

