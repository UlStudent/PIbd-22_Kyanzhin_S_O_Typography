
namespace TypographyView
{
    partial class FormFillStore
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
            this.comboBoxStore = new System.Windows.Forms.ComboBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.labelStore = new System.Windows.Forms.Label();
            this.labelVAlue = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonFill = new System.Windows.Forms.Button();
            this.comboBoxComponent = new System.Windows.Forms.ComboBox();
            this.labelComponent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxStore
            // 
            this.comboBoxStore.FormattingEnabled = true;
            this.comboBoxStore.Location = new System.Drawing.Point(144, 15);
            this.comboBoxStore.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxStore.Name = "comboBoxStore";
            this.comboBoxStore.Size = new System.Drawing.Size(278, 28);
            this.comboBoxStore.TabIndex = 0;
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(144, 107);
            this.textBoxCount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(276, 26);
            this.textBoxCount.TabIndex = 1;
            // 
            // labelStore
            // 
            this.labelStore.AutoSize = true;
            this.labelStore.Location = new System.Drawing.Point(20, 20);
            this.labelStore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStore.Name = "labelStore";
            this.labelStore.Size = new System.Drawing.Size(58, 20);
            this.labelStore.TabIndex = 2;
            this.labelStore.Text = "Склад";
            // 
            // labelVAlue
            // 
            this.labelVAlue.AutoSize = true;
            this.labelVAlue.Location = new System.Drawing.Point(18, 111);
            this.labelVAlue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelVAlue.Name = "labelVAlue";
            this.labelVAlue.Size = new System.Drawing.Size(100, 20);
            this.labelVAlue.TabIndex = 2;
            this.labelVAlue.Text = "Количество";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(310, 147);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(112, 35);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonFill
            // 
            this.buttonFill.Location = new System.Drawing.Point(188, 147);
            this.buttonFill.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonFill.Name = "buttonFill";
            this.buttonFill.Size = new System.Drawing.Size(112, 35);
            this.buttonFill.TabIndex = 4;
            this.buttonFill.Text = "Пополнить";
            this.buttonFill.UseVisualStyleBackColor = true;
            this.buttonFill.Click += new System.EventHandler(this.ButtonFill_Click);
            // 
            // comboBoxComponent
            // 
            this.comboBoxComponent.FormattingEnabled = true;
            this.comboBoxComponent.Location = new System.Drawing.Point(144, 53);
            this.comboBoxComponent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxComponent.Name = "comboBoxComponent";
            this.comboBoxComponent.Size = new System.Drawing.Size(278, 28);
            this.comboBoxComponent.TabIndex = 0;
            // 
            // labelComponent
            // 
            this.labelComponent.AutoSize = true;
            this.labelComponent.Location = new System.Drawing.Point(20, 58);
            this.labelComponent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelComponent.Name = "labelComponent";
            this.labelComponent.Size = new System.Drawing.Size(93, 20);
            this.labelComponent.TabIndex = 2;
            this.labelComponent.Text = "Компонент";
            // 
            // FormFillStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 196);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonFill);
            this.Controls.Add(this.labelVAlue);
            this.Controls.Add(this.labelComponent);
            this.Controls.Add(this.labelStore);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.comboBoxComponent);
            this.Controls.Add(this.comboBoxStore);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormFillStore";
            this.Text = "Пополнение склада";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxStore;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Label labelStore;
        private System.Windows.Forms.Label labelVAlue;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonFill;
        private System.Windows.Forms.ComboBox comboBoxComponent;
        private System.Windows.Forms.Label labelComponent;
    }
}