namespace CaterUI
{
    partial class TableInfoFrm
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
            this.列表 = new System.Windows.Forms.GroupBox();
            this.dgvTableInfo = new System.Windows.Forms.DataGridView();
            this.TId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.THallTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIsFree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlSearchFree = new System.Windows.Forms.ComboBox();
            this.ddlSearchHall = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbUse = new System.Windows.Forms.RadioButton();
            this.rbFree = new System.Windows.Forms.RadioButton();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnManagerHall = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ddlHall = new System.Windows.Forms.ComboBox();
            this.列表.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableInfo)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // 列表
            // 
            this.列表.Controls.Add(this.dgvTableInfo);
            this.列表.Location = new System.Drawing.Point(2, 12);
            this.列表.Name = "列表";
            this.列表.Size = new System.Drawing.Size(454, 450);
            this.列表.TabIndex = 0;
            this.列表.TabStop = false;
            this.列表.Text = "列表";
            // 
            // dgvTableInfo
            // 
            this.dgvTableInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TId,
            this.TTitle,
            this.THallTitle,
            this.TIsFree});
            this.dgvTableInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTableInfo.Location = new System.Drawing.Point(3, 17);
            this.dgvTableInfo.Name = "dgvTableInfo";
            this.dgvTableInfo.RowTemplate.Height = 23;
            this.dgvTableInfo.Size = new System.Drawing.Size(448, 430);
            this.dgvTableInfo.TabIndex = 0;
            this.dgvTableInfo.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTableInfo_CellContentDoubleClick);
            this.dgvTableInfo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTableInfo_CellFormatting);
            // 
            // TId
            // 
            this.TId.DataPropertyName = "TId";
            this.TId.HeaderText = "编号";
            this.TId.Name = "TId";
            // 
            // TTitle
            // 
            this.TTitle.DataPropertyName = "TTitle";
            this.TTitle.HeaderText = "名称";
            this.TTitle.Name = "TTitle";
            // 
            // THallTitle
            // 
            this.THallTitle.DataPropertyName = "THallTitle";
            this.THallTitle.HeaderText = "厅包";
            this.THallTitle.Name = "THallTitle";
            // 
            // TIsFree
            // 
            this.TIsFree.DataPropertyName = "TIsFree";
            this.TIsFree.HeaderText = "是否空闲";
            this.TIsFree.Name = "TIsFree";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnShowAll);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.ddlSearchFree);
            this.groupBox2.Controls.Add(this.ddlSearchHall);
            this.groupBox2.Location = new System.Drawing.Point(462, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(193, 140);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "搜索";
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(57, 97);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(117, 23);
            this.btnShowAll.TabIndex = 2;
            this.btnShowAll.Text = "显示全部";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "空闲：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "厅包:";
            // 
            // ddlSearchFree
            // 
            this.ddlSearchFree.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSearchFree.FormattingEnabled = true;
            this.ddlSearchFree.Location = new System.Drawing.Point(57, 60);
            this.ddlSearchFree.Name = "ddlSearchFree";
            this.ddlSearchFree.Size = new System.Drawing.Size(121, 20);
            this.ddlSearchFree.TabIndex = 0;
            this.ddlSearchFree.SelectedIndexChanged += new System.EventHandler(this.ddlSearchFree_SelectedIndexChanged);
            // 
            // ddlSearchHall
            // 
            this.ddlSearchHall.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSearchHall.FormattingEnabled = true;
            this.ddlSearchHall.Location = new System.Drawing.Point(57, 17);
            this.ddlSearchHall.Name = "ddlSearchHall";
            this.ddlSearchHall.Size = new System.Drawing.Size(121, 20);
            this.ddlSearchHall.TabIndex = 0;
            this.ddlSearchHall.SelectedIndexChanged += new System.EventHandler(this.ddlSearchHall_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbUse);
            this.groupBox3.Controls.Add(this.rbFree);
            this.groupBox3.Controls.Add(this.txtName);
            this.groupBox3.Controls.Add(this.txtId);
            this.groupBox3.Controls.Add(this.btnAdd);
            this.groupBox3.Controls.Add(this.btnRemove);
            this.groupBox3.Controls.Add(this.btnCancel);
            this.groupBox3.Controls.Add(this.btnManagerHall);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.ddlHall);
            this.groupBox3.Location = new System.Drawing.Point(462, 158);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(193, 304);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "添加/修改";
            // 
            // rbUse
            // 
            this.rbUse.AutoSize = true;
            this.rbUse.Location = new System.Drawing.Point(124, 164);
            this.rbUse.Name = "rbUse";
            this.rbUse.Size = new System.Drawing.Size(59, 16);
            this.rbUse.TabIndex = 4;
            this.rbUse.TabStop = true;
            this.rbUse.Text = "使用中";
            this.rbUse.UseVisualStyleBackColor = true;
            // 
            // rbFree
            // 
            this.rbFree.AutoSize = true;
            this.rbFree.Location = new System.Drawing.Point(58, 164);
            this.rbFree.Name = "rbFree";
            this.rbFree.Size = new System.Drawing.Size(47, 16);
            this.rbFree.TabIndex = 4;
            this.rbFree.TabStop = true;
            this.rbFree.Text = "空闲";
            this.rbFree.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(57, 57);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(121, 21);
            this.txtName.TabIndex = 3;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(57, 21);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(121, 21);
            this.txtId.TabIndex = 3;
            this.txtId.Text = "添加时无编号";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(27, 207);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(60, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(27, 273);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(151, 23);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "删除选中的行数据";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(116, 207);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(58, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnManagerHall
            // 
            this.btnManagerHall.Location = new System.Drawing.Point(57, 135);
            this.btnManagerHall.Name = "btnManagerHall";
            this.btnManagerHall.Size = new System.Drawing.Size(75, 23);
            this.btnManagerHall.TabIndex = 2;
            this.btnManagerHall.Text = "厅包管理";
            this.btnManagerHall.UseVisualStyleBackColor = true;
            this.btnManagerHall.Click += new System.EventHandler(this.btnManagerHall_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Crimson;
            this.label7.Location = new System.Drawing.Point(25, 250);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "提示：双击表格项进行修改";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "空闲:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "厅包：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "名称:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "编号：";
            // 
            // ddlHall
            // 
            this.ddlHall.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlHall.FormattingEnabled = true;
            this.ddlHall.Location = new System.Drawing.Point(57, 96);
            this.ddlHall.Name = "ddlHall";
            this.ddlHall.Size = new System.Drawing.Size(121, 20);
            this.ddlHall.TabIndex = 0;
            // 
            // TableInfoFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 461);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.列表);
            this.Name = "TableInfoFrm";
            this.Text = "餐桌管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TableInfoFrm_FormClosing);
            this.Load += new System.EventHandler(this.TableInfoFrm_Load);
            this.列表.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableInfo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox 列表;
        private System.Windows.Forms.DataGridView dgvTableInfo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlSearchFree;
        private System.Windows.Forms.ComboBox ddlSearchHall;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbUse;
        private System.Windows.Forms.RadioButton rbFree;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnManagerHall;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ddlHall;
        private System.Windows.Forms.DataGridViewTextBoxColumn TId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn THallTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIsFree;
    }
}