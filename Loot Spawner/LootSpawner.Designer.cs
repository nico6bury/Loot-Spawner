namespace Loot_Spawner
{
    partial class LootSpawner
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
            this.uxCategoryOptions = new System.Windows.Forms.CheckedListBox();
            this.uxResultsList = new System.Windows.Forms.ListBox();
            this.uxOutputGroup = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.uxSpecOrigAllowed = new System.Windows.Forms.CheckBox();
            this.uxEnchantAllowed = new System.Windows.Forms.CheckBox();
            this.uxEmbellishAllowed = new System.Windows.Forms.CheckBox();
            this.uxSpawnLoot = new System.Windows.Forms.Button();
            this.uxCLearLoot = new System.Windows.Forms.Button();
            this.uxShowDetail = new System.Windows.Forms.Button();
            this.uxShowTotal = new System.Windows.Forms.Button();
            this.uxRemoveQuantity = new System.Windows.Forms.Button();
            this.uxRemoveEntirety = new System.Windows.Forms.Button();
            this.uxOutputToText = new System.Windows.Forms.Button();
            this.uxOutputGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // uxCategoryOptions
            // 
            this.uxCategoryOptions.FormattingEnabled = true;
            this.uxCategoryOptions.Location = new System.Drawing.Point(9, 10);
            this.uxCategoryOptions.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxCategoryOptions.Name = "uxCategoryOptions";
            this.uxCategoryOptions.Size = new System.Drawing.Size(286, 154);
            this.uxCategoryOptions.TabIndex = 0;
            // 
            // uxResultsList
            // 
            this.uxResultsList.FormattingEnabled = true;
            this.uxResultsList.Location = new System.Drawing.Point(4, 17);
            this.uxResultsList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxResultsList.Name = "uxResultsList";
            this.uxResultsList.Size = new System.Drawing.Size(282, 147);
            this.uxResultsList.TabIndex = 1;
            // 
            // uxOutputGroup
            // 
            this.uxOutputGroup.Controls.Add(this.uxOutputToText);
            this.uxOutputGroup.Controls.Add(this.uxRemoveEntirety);
            this.uxOutputGroup.Controls.Add(this.uxRemoveQuantity);
            this.uxOutputGroup.Controls.Add(this.uxShowTotal);
            this.uxOutputGroup.Controls.Add(this.uxShowDetail);
            this.uxOutputGroup.Controls.Add(this.uxResultsList);
            this.uxOutputGroup.Location = new System.Drawing.Point(9, 184);
            this.uxOutputGroup.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxOutputGroup.Name = "uxOutputGroup";
            this.uxOutputGroup.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxOutputGroup.Size = new System.Drawing.Size(582, 171);
            this.uxOutputGroup.TabIndex = 2;
            this.uxOutputGroup.TabStop = false;
            this.uxOutputGroup.Text = "Ouput Options";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDown3);
            this.groupBox1.Controls.Add(this.numericUpDown2);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.uxSpecOrigAllowed);
            this.groupBox1.Controls.Add(this.uxEnchantAllowed);
            this.groupBox1.Controls.Add(this.uxEmbellishAllowed);
            this.groupBox1.Location = new System.Drawing.Point(299, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(291, 88);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Extra Options";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(140, 61);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "chance as percent:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "chance as percent:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(140, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "chance as percent:";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(241, 59);
            this.numericUpDown3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(31, 20);
            this.numericUpDown3.TabIndex = 5;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(241, 37);
            this.numericUpDown2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(31, 20);
            this.numericUpDown2.TabIndex = 4;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(241, 16);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(31, 20);
            this.numericUpDown1.TabIndex = 3;
            // 
            // uxSpecOrigAllowed
            // 
            this.uxSpecOrigAllowed.AutoSize = true;
            this.uxSpecOrigAllowed.Location = new System.Drawing.Point(4, 60);
            this.uxSpecOrigAllowed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxSpecOrigAllowed.Name = "uxSpecOrigAllowed";
            this.uxSpecOrigAllowed.Size = new System.Drawing.Size(119, 17);
            this.uxSpecOrigAllowed.TabIndex = 2;
            this.uxSpecOrigAllowed.Text = "allow special origins";
            this.uxSpecOrigAllowed.UseVisualStyleBackColor = true;
            // 
            // uxEnchantAllowed
            // 
            this.uxEnchantAllowed.AutoSize = true;
            this.uxEnchantAllowed.Location = new System.Drawing.Point(4, 38);
            this.uxEnchantAllowed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxEnchantAllowed.Name = "uxEnchantAllowed";
            this.uxEnchantAllowed.Size = new System.Drawing.Size(120, 17);
            this.uxEnchantAllowed.TabIndex = 1;
            this.uxEnchantAllowed.Text = "allow enchantments";
            this.uxEnchantAllowed.UseVisualStyleBackColor = true;
            // 
            // uxEmbellishAllowed
            // 
            this.uxEmbellishAllowed.AutoSize = true;
            this.uxEmbellishAllowed.Location = new System.Drawing.Point(4, 17);
            this.uxEmbellishAllowed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxEmbellishAllowed.Name = "uxEmbellishAllowed";
            this.uxEmbellishAllowed.Size = new System.Drawing.Size(122, 17);
            this.uxEmbellishAllowed.TabIndex = 0;
            this.uxEmbellishAllowed.Text = "allow embelishments";
            this.uxEmbellishAllowed.UseVisualStyleBackColor = true;
            // 
            // uxSpawnLoot
            // 
            this.uxSpawnLoot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uxSpawnLoot.Location = new System.Drawing.Point(317, 103);
            this.uxSpawnLoot.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxSpawnLoot.Name = "uxSpawnLoot";
            this.uxSpawnLoot.Size = new System.Drawing.Size(88, 52);
            this.uxSpawnLoot.TabIndex = 4;
            this.uxSpawnLoot.Text = "Spawn Loot";
            this.uxSpawnLoot.UseVisualStyleBackColor = true;
            // 
            // uxCLearLoot
            // 
            this.uxCLearLoot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uxCLearLoot.Location = new System.Drawing.Point(450, 103);
            this.uxCLearLoot.Margin = new System.Windows.Forms.Padding(2);
            this.uxCLearLoot.Name = "uxCLearLoot";
            this.uxCLearLoot.Size = new System.Drawing.Size(88, 52);
            this.uxCLearLoot.TabIndex = 5;
            this.uxCLearLoot.Text = "Clear Loot";
            this.uxCLearLoot.UseVisualStyleBackColor = true;
            // 
            // uxShowDetail
            // 
            this.uxShowDetail.Location = new System.Drawing.Point(330, 30);
            this.uxShowDetail.Name = "uxShowDetail";
            this.uxShowDetail.Size = new System.Drawing.Size(113, 23);
            this.uxShowDetail.TabIndex = 2;
            this.uxShowDetail.Text = "show detailed info";
            this.uxShowDetail.UseVisualStyleBackColor = true;
            // 
            // uxShowTotal
            // 
            this.uxShowTotal.Location = new System.Drawing.Point(330, 59);
            this.uxShowTotal.Name = "uxShowTotal";
            this.uxShowTotal.Size = new System.Drawing.Size(113, 23);
            this.uxShowTotal.TabIndex = 3;
            this.uxShowTotal.Text = "show total stats";
            this.uxShowTotal.UseVisualStyleBackColor = true;
            // 
            // uxRemoveQuantity
            // 
            this.uxRemoveQuantity.Location = new System.Drawing.Point(330, 87);
            this.uxRemoveQuantity.Name = "uxRemoveQuantity";
            this.uxRemoveQuantity.Size = new System.Drawing.Size(150, 23);
            this.uxRemoveQuantity.TabIndex = 4;
            this.uxRemoveQuantity.Text = "remove quantity of selected";
            this.uxRemoveQuantity.UseVisualStyleBackColor = true;
            // 
            // uxRemoveEntirety
            // 
            this.uxRemoveEntirety.Location = new System.Drawing.Point(330, 116);
            this.uxRemoveEntirety.Name = "uxRemoveEntirety";
            this.uxRemoveEntirety.Size = new System.Drawing.Size(150, 23);
            this.uxRemoveEntirety.TabIndex = 5;
            this.uxRemoveEntirety.Text = "remove entirety of selected";
            this.uxRemoveEntirety.UseVisualStyleBackColor = true;
            // 
            // uxOutputToText
            // 
            this.uxOutputToText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uxOutputToText.Location = new System.Drawing.Point(448, 30);
            this.uxOutputToText.Margin = new System.Windows.Forms.Padding(2);
            this.uxOutputToText.Name = "uxOutputToText";
            this.uxOutputToText.Size = new System.Drawing.Size(88, 52);
            this.uxOutputToText.TabIndex = 6;
            this.uxOutputToText.Text = "Output to Text";
            this.uxOutputToText.UseVisualStyleBackColor = true;
            // 
            // LootSpawner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 362);
            this.Controls.Add(this.uxCLearLoot);
            this.Controls.Add(this.uxSpawnLoot);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.uxOutputGroup);
            this.Controls.Add(this.uxCategoryOptions);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "LootSpawner";
            this.Text = "Loot Spawner";
            this.uxOutputGroup.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox uxCategoryOptions;
        private System.Windows.Forms.ListBox uxResultsList;
        private System.Windows.Forms.GroupBox uxOutputGroup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.CheckBox uxSpecOrigAllowed;
        private System.Windows.Forms.CheckBox uxEnchantAllowed;
        private System.Windows.Forms.CheckBox uxEmbellishAllowed;
        private System.Windows.Forms.Button uxSpawnLoot;
        private System.Windows.Forms.Button uxCLearLoot;
        private System.Windows.Forms.Button uxOutputToText;
        private System.Windows.Forms.Button uxRemoveEntirety;
        private System.Windows.Forms.Button uxRemoveQuantity;
        private System.Windows.Forms.Button uxShowTotal;
        private System.Windows.Forms.Button uxShowDetail;
    }
}

