
namespace TTLauncher
{
    partial class settingsForm
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
            this.pathToGameLabel = new System.Windows.Forms.Label();
            this.pathToGameTextBox = new System.Windows.Forms.TextBox();
            this.pathToGameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pathToGameLabel
            // 
            this.pathToGameLabel.AutoSize = true;
            this.pathToGameLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pathToGameLabel.Location = new System.Drawing.Point(9, 10);
            this.pathToGameLabel.Name = "pathToGameLabel";
            this.pathToGameLabel.Size = new System.Drawing.Size(167, 15);
            this.pathToGameLabel.TabIndex = 0;
            this.pathToGameLabel.Text = "Путь к установленной игре";
            // 
            // pathToGameTextBox
            // 
            this.pathToGameTextBox.Enabled = false;
            this.pathToGameTextBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pathToGameTextBox.Location = new System.Drawing.Point(12, 28);
            this.pathToGameTextBox.Name = "pathToGameTextBox";
            this.pathToGameTextBox.Size = new System.Drawing.Size(306, 21);
            this.pathToGameTextBox.TabIndex = 1;
            // 
            // pathToGameButton
            // 
            this.pathToGameButton.Location = new System.Drawing.Point(324, 28);
            this.pathToGameButton.Name = "pathToGameButton";
            this.pathToGameButton.Size = new System.Drawing.Size(27, 20);
            this.pathToGameButton.TabIndex = 2;
            this.pathToGameButton.Text = "...";
            this.pathToGameButton.UseVisualStyleBackColor = true;
            this.pathToGameButton.Click += new System.EventHandler(this.pathToGameButton_Click);
            // 
            // settingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 70);
            this.Controls.Add(this.pathToGameButton);
            this.Controls.Add(this.pathToGameTextBox);
            this.Controls.Add(this.pathToGameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "settingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pathToGameLabel;
        private System.Windows.Forms.TextBox pathToGameTextBox;
        private System.Windows.Forms.Button pathToGameButton;
    }
}