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
            this.components = new System.ComponentModel.Container();
            this.uxCategoryOptions = new System.Windows.Forms.CheckedListBox();
            this.uxResultsList = new System.Windows.Forms.ListBox();
            this.uxOutputGroup = new System.Windows.Forms.GroupBox();
            this.uxOutputToText = new System.Windows.Forms.Button();
            this.uxRemoveEntirety = new System.Windows.Forms.Button();
            this.uxRemoveQuantity = new System.Windows.Forms.Button();
            this.uxShowTotal = new System.Windows.Forms.Button();
            this.uxShowDetail = new System.Windows.Forms.Button();
            this.uxOptionsGroup = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uxSpecOrigChance = new System.Windows.Forms.NumericUpDown();
            this.uxEnchantChance = new System.Windows.Forms.NumericUpDown();
            this.uxEmbelishChance = new System.Windows.Forms.NumericUpDown();
            this.uxSpecOrigAllowed = new System.Windows.Forms.CheckBox();
            this.uxEnchantAllowed = new System.Windows.Forms.CheckBox();
            this.uxEmbellishAllowed = new System.Windows.Forms.CheckBox();
            this.uxSpawnLoot = new System.Windows.Forms.Button();
            this.uxCLearLoot = new System.Windows.Forms.Button();
            this.uxClearSelection = new System.Windows.Forms.Button();
            this.uxSelectAll = new System.Windows.Forms.Button();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uxOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.uxToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.uxLootAmount = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.uxSpawningGroup = new System.Windows.Forms.GroupBox();
            this.uxOutputGroup.SuspendLayout();
            this.uxOptionsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxSpecOrigChance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxEnchantChance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxEmbelishChance)).BeginInit();
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxLootAmount)).BeginInit();
            this.uxSpawningGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxCategoryOptions
            // 
            this.uxCategoryOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.uxCategoryOptions.FormattingEnabled = true;
            this.uxCategoryOptions.Location = new System.Drawing.Point(11, 26);
            this.uxCategoryOptions.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxCategoryOptions.Name = "uxCategoryOptions";
            this.uxCategoryOptions.Size = new System.Drawing.Size(286, 169);
            this.uxCategoryOptions.TabIndex = 0;
            // 
            // uxResultsList
            // 
            this.uxResultsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.uxResultsList.FormattingEnabled = true;
            this.uxResultsList.ItemHeight = 16;
            this.uxResultsList.Location = new System.Drawing.Point(4, 17);
            this.uxResultsList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxResultsList.Name = "uxResultsList";
            this.uxResultsList.Size = new System.Drawing.Size(282, 132);
            this.uxResultsList.TabIndex = 1;
            // 
            // uxOutputGroup
            // 
            this.uxOutputGroup.Controls.Add(this.uxOutputToText);
            this.uxOutputGroup.Controls.Add(this.uxRemoveEntirety);
            this.uxOutputGroup.Controls.Add(this.uxRemoveQuantity);
            this.uxOutputGroup.Controls.Add(this.uxShowTotal);
            this.uxOutputGroup.Controls.Add(this.uxCLearLoot);
            this.uxOutputGroup.Controls.Add(this.uxShowDetail);
            this.uxOutputGroup.Controls.Add(this.uxResultsList);
            this.uxOutputGroup.Enabled = false;
            this.uxOutputGroup.Location = new System.Drawing.Point(11, 200);
            this.uxOutputGroup.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxOutputGroup.Name = "uxOutputGroup";
            this.uxOutputGroup.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxOutputGroup.Size = new System.Drawing.Size(568, 171);
            this.uxOutputGroup.TabIndex = 2;
            this.uxOutputGroup.TabStop = false;
            this.uxOutputGroup.Text = "Ouput Options";
            // 
            // uxOutputToText
            // 
            this.uxOutputToText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uxOutputToText.Location = new System.Drawing.Point(444, 34);
            this.uxOutputToText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxOutputToText.Name = "uxOutputToText";
            this.uxOutputToText.Size = new System.Drawing.Size(88, 52);
            this.uxOutputToText.TabIndex = 6;
            this.uxOutputToText.Text = "Output to Text";
            this.uxOutputToText.UseVisualStyleBackColor = true;
            // 
            // uxRemoveEntirety
            // 
            this.uxRemoveEntirety.Location = new System.Drawing.Point(326, 120);
            this.uxRemoveEntirety.Name = "uxRemoveEntirety";
            this.uxRemoveEntirety.Size = new System.Drawing.Size(150, 23);
            this.uxRemoveEntirety.TabIndex = 5;
            this.uxRemoveEntirety.Text = "remove entirety of selected";
            this.uxRemoveEntirety.UseVisualStyleBackColor = true;
            // 
            // uxRemoveQuantity
            // 
            this.uxRemoveQuantity.Location = new System.Drawing.Point(326, 91);
            this.uxRemoveQuantity.Name = "uxRemoveQuantity";
            this.uxRemoveQuantity.Size = new System.Drawing.Size(150, 23);
            this.uxRemoveQuantity.TabIndex = 4;
            this.uxRemoveQuantity.Text = "remove quantity of selected";
            this.uxRemoveQuantity.UseVisualStyleBackColor = true;
            // 
            // uxShowTotal
            // 
            this.uxShowTotal.Location = new System.Drawing.Point(326, 63);
            this.uxShowTotal.Name = "uxShowTotal";
            this.uxShowTotal.Size = new System.Drawing.Size(113, 23);
            this.uxShowTotal.TabIndex = 3;
            this.uxShowTotal.Text = "show total stats";
            this.uxShowTotal.UseVisualStyleBackColor = true;
            // 
            // uxShowDetail
            // 
            this.uxShowDetail.Location = new System.Drawing.Point(326, 34);
            this.uxShowDetail.Name = "uxShowDetail";
            this.uxShowDetail.Size = new System.Drawing.Size(113, 23);
            this.uxShowDetail.TabIndex = 2;
            this.uxShowDetail.Text = "show detailed info";
            this.uxShowDetail.UseVisualStyleBackColor = true;
            // 
            // uxOptionsGroup
            // 
            this.uxOptionsGroup.Controls.Add(this.label3);
            this.uxOptionsGroup.Controls.Add(this.label2);
            this.uxOptionsGroup.Controls.Add(this.label1);
            this.uxOptionsGroup.Controls.Add(this.uxSpecOrigChance);
            this.uxOptionsGroup.Controls.Add(this.uxEnchantChance);
            this.uxOptionsGroup.Controls.Add(this.uxEmbelishChance);
            this.uxOptionsGroup.Controls.Add(this.uxSpecOrigAllowed);
            this.uxOptionsGroup.Controls.Add(this.uxEnchantAllowed);
            this.uxOptionsGroup.Controls.Add(this.uxEmbellishAllowed);
            this.uxOptionsGroup.Location = new System.Drawing.Point(301, 107);
            this.uxOptionsGroup.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxOptionsGroup.Name = "uxOptionsGroup";
            this.uxOptionsGroup.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxOptionsGroup.Size = new System.Drawing.Size(278, 88);
            this.uxOptionsGroup.TabIndex = 3;
            this.uxOptionsGroup.TabStop = false;
            this.uxOptionsGroup.Text = "Extra Options";
            this.uxToolTip.SetToolTip(this.uxOptionsGroup, "Extra Options are not yet available.");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(130, 61);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "chance as percent:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(130, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "chance as percent:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(130, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "chance as percent:";
            // 
            // uxSpecOrigChance
            // 
            this.uxSpecOrigChance.Enabled = false;
            this.uxSpecOrigChance.Location = new System.Drawing.Point(233, 57);
            this.uxSpecOrigChance.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxSpecOrigChance.Name = "uxSpecOrigChance";
            this.uxSpecOrigChance.Size = new System.Drawing.Size(37, 20);
            this.uxSpecOrigChance.TabIndex = 5;
            this.uxSpecOrigChance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uxToolTip.SetToolTip(this.uxSpecOrigChance, "Chance for special origins");
            // 
            // uxEnchantChance
            // 
            this.uxEnchantChance.Enabled = false;
            this.uxEnchantChance.Location = new System.Drawing.Point(233, 35);
            this.uxEnchantChance.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxEnchantChance.Name = "uxEnchantChance";
            this.uxEnchantChance.Size = new System.Drawing.Size(37, 20);
            this.uxEnchantChance.TabIndex = 4;
            this.uxEnchantChance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uxToolTip.SetToolTip(this.uxEnchantChance, "Chance for enchantments");
            // 
            // uxEmbelishChance
            // 
            this.uxEmbelishChance.Enabled = false;
            this.uxEmbelishChance.Location = new System.Drawing.Point(233, 14);
            this.uxEmbelishChance.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxEmbelishChance.Name = "uxEmbelishChance";
            this.uxEmbelishChance.Size = new System.Drawing.Size(37, 20);
            this.uxEmbelishChance.TabIndex = 3;
            this.uxEmbelishChance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uxToolTip.SetToolTip(this.uxEmbelishChance, "Chance for embellishments");
            // 
            // uxSpecOrigAllowed
            // 
            this.uxSpecOrigAllowed.AutoSize = true;
            this.uxSpecOrigAllowed.Enabled = false;
            this.uxSpecOrigAllowed.Location = new System.Drawing.Point(4, 60);
            this.uxSpecOrigAllowed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxSpecOrigAllowed.Name = "uxSpecOrigAllowed";
            this.uxSpecOrigAllowed.Size = new System.Drawing.Size(119, 17);
            this.uxSpecOrigAllowed.TabIndex = 2;
            this.uxSpecOrigAllowed.Text = "allow special origins";
            this.uxToolTip.SetToolTip(this.uxSpecOrigAllowed, "Whether or not to potentially generate special origins for items. This will be fa" +
        "irly generic");
            this.uxSpecOrigAllowed.UseVisualStyleBackColor = true;
            // 
            // uxEnchantAllowed
            // 
            this.uxEnchantAllowed.AutoSize = true;
            this.uxEnchantAllowed.Enabled = false;
            this.uxEnchantAllowed.Location = new System.Drawing.Point(4, 38);
            this.uxEnchantAllowed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxEnchantAllowed.Name = "uxEnchantAllowed";
            this.uxEnchantAllowed.Size = new System.Drawing.Size(120, 17);
            this.uxEnchantAllowed.TabIndex = 1;
            this.uxEnchantAllowed.Text = "allow enchantments";
            this.uxToolTip.SetToolTip(this.uxEnchantAllowed, "Whether or not to allow arcane enchantments on items.");
            this.uxEnchantAllowed.UseVisualStyleBackColor = true;
            // 
            // uxEmbellishAllowed
            // 
            this.uxEmbellishAllowed.AutoSize = true;
            this.uxEmbellishAllowed.Enabled = false;
            this.uxEmbellishAllowed.Location = new System.Drawing.Point(4, 17);
            this.uxEmbellishAllowed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxEmbellishAllowed.Name = "uxEmbellishAllowed";
            this.uxEmbellishAllowed.Size = new System.Drawing.Size(122, 17);
            this.uxEmbellishAllowed.TabIndex = 0;
            this.uxEmbellishAllowed.Text = "allow embelishments";
            this.uxToolTip.SetToolTip(this.uxEmbellishAllowed, "Whether or not to allow decorative embellishments on items");
            this.uxEmbellishAllowed.UseVisualStyleBackColor = true;
            // 
            // uxSpawnLoot
            // 
            this.uxSpawnLoot.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.uxSpawnLoot.Location = new System.Drawing.Point(112, 18);
            this.uxSpawnLoot.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxSpawnLoot.Name = "uxSpawnLoot";
            this.uxSpawnLoot.Size = new System.Drawing.Size(60, 46);
            this.uxSpawnLoot.TabIndex = 4;
            this.uxSpawnLoot.Text = "Spawn Loot";
            this.uxToolTip.SetToolTip(this.uxSpawnLoot, "Spawns loot with your current specifications. Won\'t remove loot already spawned");
            this.uxSpawnLoot.UseVisualStyleBackColor = true;
            this.uxSpawnLoot.Click += new System.EventHandler(this.SpawnLoot);
            // 
            // uxCLearLoot
            // 
            this.uxCLearLoot.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.uxCLearLoot.Location = new System.Drawing.Point(481, 90);
            this.uxCLearLoot.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxCLearLoot.Name = "uxCLearLoot";
            this.uxCLearLoot.Size = new System.Drawing.Size(51, 53);
            this.uxCLearLoot.TabIndex = 5;
            this.uxCLearLoot.Text = "Clear Loot";
            this.uxToolTip.SetToolTip(this.uxCLearLoot, "Clears the loot from the table below");
            this.uxCLearLoot.UseVisualStyleBackColor = true;
            // 
            // uxClearSelection
            // 
            this.uxClearSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.uxClearSelection.Location = new System.Drawing.Point(5, 18);
            this.uxClearSelection.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxClearSelection.Name = "uxClearSelection";
            this.uxClearSelection.Size = new System.Drawing.Size(103, 23);
            this.uxClearSelection.TabIndex = 6;
            this.uxClearSelection.Text = "Clear Selection";
            this.uxToolTip.SetToolTip(this.uxClearSelection, "Clears the selection to the left");
            this.uxClearSelection.UseVisualStyleBackColor = true;
            this.uxClearSelection.Click += new System.EventHandler(this.DeselectAllCats);
            // 
            // uxSelectAll
            // 
            this.uxSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.uxSelectAll.Location = new System.Drawing.Point(5, 41);
            this.uxSelectAll.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxSelectAll.Name = "uxSelectAll";
            this.uxSelectAll.Size = new System.Drawing.Size(103, 23);
            this.uxSelectAll.TabIndex = 7;
            this.uxSelectAll.Text = "Select All";
            this.uxToolTip.SetToolTip(this.uxSelectAll, "Selects all the boxes to the left");
            this.uxSelectAll.UseVisualStyleBackColor = true;
            this.uxSelectAll.Click += new System.EventHandler(this.SelectAllCats);
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(588, 24);
            this.MenuStrip.TabIndex = 8;
            this.MenuStrip.Text = "MenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxOpenFile});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // uxOpenFile
            // 
            this.uxOpenFile.Name = "uxOpenFile";
            this.uxOpenFile.Size = new System.Drawing.Size(180, 22);
            this.uxOpenFile.Text = "Open";
            // 
            // uxToolTip
            // 
            this.uxToolTip.AutoPopDelay = 5000;
            this.uxToolTip.InitialDelay = 1500;
            this.uxToolTip.ReshowDelay = 100;
            this.uxToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // uxLootAmount
            // 
            this.uxLootAmount.Location = new System.Drawing.Point(180, 41);
            this.uxLootAmount.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.uxLootAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uxLootAmount.Name = "uxLootAmount";
            this.uxLootAmount.Size = new System.Drawing.Size(84, 20);
            this.uxLootAmount.TabIndex = 9;
            this.uxLootAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uxToolTip.SetToolTip(this.uxLootAmount, "How many items of randomly generated loot to spawn.");
            this.uxLootAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(177, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "loot amount:";
            // 
            // uxSpawningGroup
            // 
            this.uxSpawningGroup.Controls.Add(this.uxClearSelection);
            this.uxSpawningGroup.Controls.Add(this.label4);
            this.uxSpawningGroup.Controls.Add(this.uxSpawnLoot);
            this.uxSpawningGroup.Controls.Add(this.uxLootAmount);
            this.uxSpawningGroup.Controls.Add(this.uxSelectAll);
            this.uxSpawningGroup.Location = new System.Drawing.Point(302, 26);
            this.uxSpawningGroup.Name = "uxSpawningGroup";
            this.uxSpawningGroup.Size = new System.Drawing.Size(278, 71);
            this.uxSpawningGroup.TabIndex = 11;
            this.uxSpawningGroup.TabStop = false;
            this.uxSpawningGroup.Text = "Loot Spawning";
            // 
            // LootSpawner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 379);
            this.Controls.Add(this.uxSpawningGroup);
            this.Controls.Add(this.uxOptionsGroup);
            this.Controls.Add(this.uxOutputGroup);
            this.Controls.Add(this.uxCategoryOptions);
            this.Controls.Add(this.MenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MainMenuStrip = this.MenuStrip;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "LootSpawner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loot Spawner";
            this.uxOutputGroup.ResumeLayout(false);
            this.uxOptionsGroup.ResumeLayout(false);
            this.uxOptionsGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxSpecOrigChance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxEnchantChance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxEmbelishChance)).EndInit();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxLootAmount)).EndInit();
            this.uxSpawningGroup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox uxCategoryOptions;
        private System.Windows.Forms.ListBox uxResultsList;
        private System.Windows.Forms.GroupBox uxOutputGroup;
        private System.Windows.Forms.GroupBox uxOptionsGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown uxSpecOrigChance;
        private System.Windows.Forms.NumericUpDown uxEnchantChance;
        private System.Windows.Forms.NumericUpDown uxEmbelishChance;
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
        private System.Windows.Forms.Button uxClearSelection;
        private System.Windows.Forms.Button uxSelectAll;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uxOpenFile;
        private System.Windows.Forms.ToolTip uxToolTip;
        private System.Windows.Forms.NumericUpDown uxLootAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox uxSpawningGroup;
    }
}

