namespace _001Ado.net.SQLite
{
    partial class MainFrm
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
            this.dgvManagerInfo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManagerInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvManagerInfo
            // 
            this.dgvManagerInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManagerInfo.Location = new System.Drawing.Point(12, 21);
            this.dgvManagerInfo.Name = "dgvManagerInfo";
            this.dgvManagerInfo.RowTemplate.Height = 23;
            this.dgvManagerInfo.Size = new System.Drawing.Size(379, 289);
            this.dgvManagerInfo.TabIndex = 0;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 333);
            this.Controls.Add(this.dgvManagerInfo);
            this.Name = "MainFrm";
            this.Text = "MainFrm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvManagerInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvManagerInfo;
    }
}