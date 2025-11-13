namespace QuickLaunchLauncher
{
    partial class Form2
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.rdo_Left_Top = new System.Windows.Forms.RadioButton();
            this.rdo_Center_Top = new System.Windows.Forms.RadioButton();
            this.grpPosition = new System.Windows.Forms.GroupBox();
            this.rdo_Right_Bottom = new System.Windows.Forms.RadioButton();
            this.rdo_Center_Bottom = new System.Windows.Forms.RadioButton();
            this.rdo_Left_Bottom = new System.Windows.Forms.RadioButton();
            this.rdo_Right_Top = new System.Windows.Forms.RadioButton();
            this.cmbBackground = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpPosition.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdo_Left_Top
            // 
            this.rdo_Left_Top.AutoSize = true;
            this.rdo_Left_Top.Location = new System.Drawing.Point(22, 18);
            this.rdo_Left_Top.Name = "rdo_Left_Top";
            this.rdo_Left_Top.Size = new System.Drawing.Size(14, 13);
            this.rdo_Left_Top.TabIndex = 0;
            this.rdo_Left_Top.UseVisualStyleBackColor = true;
            // 
            // rdo_Center_Top
            // 
            this.rdo_Center_Top.AutoSize = true;
            this.rdo_Center_Top.Location = new System.Drawing.Point(96, 18);
            this.rdo_Center_Top.Name = "rdo_Center_Top";
            this.rdo_Center_Top.Size = new System.Drawing.Size(14, 13);
            this.rdo_Center_Top.TabIndex = 1;
            this.rdo_Center_Top.UseVisualStyleBackColor = true;
            // 
            // grpPosition
            // 
            this.grpPosition.Controls.Add(this.rdo_Right_Bottom);
            this.grpPosition.Controls.Add(this.rdo_Center_Bottom);
            this.grpPosition.Controls.Add(this.rdo_Left_Bottom);
            this.grpPosition.Controls.Add(this.rdo_Right_Top);
            this.grpPosition.Controls.Add(this.rdo_Center_Top);
            this.grpPosition.Controls.Add(this.rdo_Left_Top);
            this.grpPosition.Location = new System.Drawing.Point(12, 12);
            this.grpPosition.Name = "grpPosition";
            this.grpPosition.Size = new System.Drawing.Size(208, 102);
            this.grpPosition.TabIndex = 1;
            this.grpPosition.TabStop = false;
            this.grpPosition.Text = "Position";
            // 
            // rdo_Right_Bottom
            // 
            this.rdo_Right_Bottom.AutoSize = true;
            this.rdo_Right_Bottom.Location = new System.Drawing.Point(168, 74);
            this.rdo_Right_Bottom.Name = "rdo_Right_Bottom";
            this.rdo_Right_Bottom.Size = new System.Drawing.Size(14, 13);
            this.rdo_Right_Bottom.TabIndex = 5;
            this.rdo_Right_Bottom.UseVisualStyleBackColor = true;
            // 
            // rdo_Center_Bottom
            // 
            this.rdo_Center_Bottom.AutoSize = true;
            this.rdo_Center_Bottom.Location = new System.Drawing.Point(96, 74);
            this.rdo_Center_Bottom.Name = "rdo_Center_Bottom";
            this.rdo_Center_Bottom.Size = new System.Drawing.Size(14, 13);
            this.rdo_Center_Bottom.TabIndex = 4;
            this.rdo_Center_Bottom.UseVisualStyleBackColor = true;
            // 
            // rdo_Left_Bottom
            // 
            this.rdo_Left_Bottom.AutoSize = true;
            this.rdo_Left_Bottom.Location = new System.Drawing.Point(22, 74);
            this.rdo_Left_Bottom.Name = "rdo_Left_Bottom";
            this.rdo_Left_Bottom.Size = new System.Drawing.Size(14, 13);
            this.rdo_Left_Bottom.TabIndex = 3;
            this.rdo_Left_Bottom.UseVisualStyleBackColor = true;
            // 
            // rdo_Right_Top
            // 
            this.rdo_Right_Top.AutoSize = true;
            this.rdo_Right_Top.Location = new System.Drawing.Point(168, 18);
            this.rdo_Right_Top.Name = "rdo_Right_Top";
            this.rdo_Right_Top.Size = new System.Drawing.Size(14, 13);
            this.rdo_Right_Top.TabIndex = 2;
            this.rdo_Right_Top.UseVisualStyleBackColor = true;
            // 
            // cmbBackground
            // 
            this.cmbBackground.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBackground.FormattingEnabled = true;
            this.cmbBackground.Location = new System.Drawing.Point(82, 120);
            this.cmbBackground.Name = "cmbBackground";
            this.cmbBackground.Size = new System.Drawing.Size(138, 20);
            this.cmbBackground.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "background";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 150);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbBackground);
            this.Controls.Add(this.grpPosition);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.grpPosition.ResumeLayout(false);
            this.grpPosition.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdo_Left_Top;
        private System.Windows.Forms.RadioButton rdo_Center_Top;
        private System.Windows.Forms.GroupBox grpPosition;
        private System.Windows.Forms.RadioButton rdo_Right_Top;
        private System.Windows.Forms.RadioButton rdo_Right_Bottom;
        private System.Windows.Forms.RadioButton rdo_Center_Bottom;
        private System.Windows.Forms.RadioButton rdo_Left_Bottom;
        private System.Windows.Forms.ComboBox cmbBackground;
        private System.Windows.Forms.Label label1;
    }
}