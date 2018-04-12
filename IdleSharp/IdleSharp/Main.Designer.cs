namespace SharpAdventure
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.locationBox = new System.Windows.Forms.RichTextBox();
            this.WestButton = new System.Windows.Forms.Button();
            this.SouthButton = new System.Windows.Forms.Button();
            this.EastButton = new System.Windows.Forms.Button();
            this.NordButton = new System.Windows.Forms.Button();
            this.HomeButton = new System.Windows.Forms.Button();
            this.RunButton = new System.Windows.Forms.Button();
            this.CombatButton = new System.Windows.Forms.Button();
            this.FoodButton = new System.Windows.Forms.Button();
            this.AttackButton = new System.Windows.Forms.Button();
            this.playerStats = new System.Windows.Forms.TableLayoutPanel();
            this.levelValue = new System.Windows.Forms.Label();
            this.expValue = new System.Windows.Forms.Label();
            this.goldValue = new System.Windows.Forms.Label();
            this.hpLabel = new System.Windows.Forms.Label();
            this.goldLabel = new System.Windows.Forms.Label();
            this.levelLabel = new System.Windows.Forms.Label();
            this.hpValue = new System.Windows.Forms.Label();
            this.expLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.InventoryBox = new System.Windows.Forms.DataGridView();
            this.QuestBox = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playerStats.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InventoryBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuestBox)).BeginInit();
            this.SuspendLayout();
            // 
            // logBox
            // 
            this.logBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.logBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logBox.Location = new System.Drawing.Point(586, 296);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(346, 185);
            this.logBox.TabIndex = 0;
            this.logBox.Text = "";
            // 
            // locationBox
            // 
            this.locationBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.locationBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationBox.Location = new System.Drawing.Point(12, 182);
            this.locationBox.Name = "locationBox";
            this.locationBox.Size = new System.Drawing.Size(447, 108);
            this.locationBox.TabIndex = 1;
            this.locationBox.Text = "";
            // 
            // WestButton
            // 
            this.WestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WestButton.Location = new System.Drawing.Point(4, 65);
            this.WestButton.Name = "WestButton";
            this.WestButton.Size = new System.Drawing.Size(61, 52);
            this.WestButton.TabIndex = 3;
            this.WestButton.Text = "W";
            this.WestButton.UseVisualStyleBackColor = true;
            this.WestButton.Click += new System.EventHandler(this.WestButton_Click);
            // 
            // SouthButton
            // 
            this.SouthButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SouthButton.Location = new System.Drawing.Point(72, 126);
            this.SouthButton.Name = "SouthButton";
            this.SouthButton.Size = new System.Drawing.Size(61, 54);
            this.SouthButton.TabIndex = 2;
            this.SouthButton.Text = "S";
            this.SouthButton.UseVisualStyleBackColor = true;
            this.SouthButton.Click += new System.EventHandler(this.SouthButton_Click);
            // 
            // EastButton
            // 
            this.EastButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EastButton.Location = new System.Drawing.Point(140, 65);
            this.EastButton.Name = "EastButton";
            this.EastButton.Size = new System.Drawing.Size(61, 52);
            this.EastButton.TabIndex = 1;
            this.EastButton.Text = "E";
            this.EastButton.UseVisualStyleBackColor = true;
            this.EastButton.Click += new System.EventHandler(this.EastButton_Click);
            // 
            // NordButton
            // 
            this.NordButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NordButton.Location = new System.Drawing.Point(72, 4);
            this.NordButton.Name = "NordButton";
            this.NordButton.Size = new System.Drawing.Size(61, 52);
            this.NordButton.TabIndex = 0;
            this.NordButton.Text = "N";
            this.NordButton.UseVisualStyleBackColor = true;
            this.NordButton.Click += new System.EventHandler(this.NordButton_Click);
            // 
            // HomeButton
            // 
            this.HomeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("HomeButton.BackgroundImage")));
            this.HomeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HomeButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.HomeButton.FlatAppearance.BorderSize = 4;
            this.HomeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.HomeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.HomeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeButton.Location = new System.Drawing.Point(288, 126);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Size = new System.Drawing.Size(65, 54);
            this.HomeButton.TabIndex = 8;
            this.HomeButton.UseVisualStyleBackColor = true;
            this.HomeButton.Click += new System.EventHandler(this.HomeButton_Click);
            // 
            // RunButton
            // 
            this.RunButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RunButton.BackgroundImage")));
            this.RunButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RunButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.RunButton.FlatAppearance.BorderSize = 4;
            this.RunButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.RunButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.RunButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunButton.Location = new System.Drawing.Point(146, 4);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(64, 52);
            this.RunButton.TabIndex = 7;
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // CombatButton
            // 
            this.CombatButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CombatButton.BackgroundImage")));
            this.CombatButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CombatButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.CombatButton.FlatAppearance.BorderSize = 4;
            this.CombatButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.CombatButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.CombatButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CombatButton.Location = new System.Drawing.Point(217, 126);
            this.CombatButton.Name = "CombatButton";
            this.CombatButton.Size = new System.Drawing.Size(64, 54);
            this.CombatButton.TabIndex = 6;
            this.CombatButton.UseVisualStyleBackColor = true;
            this.CombatButton.Click += new System.EventHandler(this.CombatButton_Click);
            // 
            // FoodButton
            // 
            this.FoodButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FoodButton.BackgroundImage")));
            this.FoodButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FoodButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.FoodButton.FlatAppearance.BorderSize = 4;
            this.FoodButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.FoodButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.FoodButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FoodButton.Location = new System.Drawing.Point(75, 4);
            this.FoodButton.Name = "FoodButton";
            this.FoodButton.Size = new System.Drawing.Size(64, 52);
            this.FoodButton.TabIndex = 5;
            this.FoodButton.UseVisualStyleBackColor = true;
            this.FoodButton.Click += new System.EventHandler(this.FoodButton_Click);
            // 
            // AttackButton
            // 
            this.AttackButton.BackColor = System.Drawing.Color.SkyBlue;
            this.AttackButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AttackButton.BackgroundImage")));
            this.AttackButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AttackButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.AttackButton.FlatAppearance.BorderSize = 4;
            this.AttackButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.AttackButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.AttackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AttackButton.Location = new System.Drawing.Point(4, 4);
            this.AttackButton.Name = "AttackButton";
            this.AttackButton.Size = new System.Drawing.Size(64, 52);
            this.AttackButton.TabIndex = 4;
            this.AttackButton.UseVisualStyleBackColor = false;
            this.AttackButton.Click += new System.EventHandler(this.AttackButton_Click);
            // 
            // playerStats
            // 
            this.playerStats.ColumnCount = 2;
            this.playerStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.playerStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.playerStats.Controls.Add(this.levelValue, 1, 3);
            this.playerStats.Controls.Add(this.expValue, 1, 2);
            this.playerStats.Controls.Add(this.goldValue, 1, 1);
            this.playerStats.Controls.Add(this.hpLabel, 0, 0);
            this.playerStats.Controls.Add(this.goldLabel, 0, 1);
            this.playerStats.Controls.Add(this.levelLabel, 0, 3);
            this.playerStats.Controls.Add(this.hpValue, 1, 0);
            this.playerStats.Controls.Add(this.expLabel, 0, 2);
            this.playerStats.Location = new System.Drawing.Point(12, 12);
            this.playerStats.Name = "playerStats";
            this.playerStats.RowCount = 4;
            this.playerStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.playerStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.playerStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.playerStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.playerStats.Size = new System.Drawing.Size(359, 164);
            this.playerStats.TabIndex = 9;
            // 
            // levelValue
            // 
            this.levelValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.levelValue.AutoSize = true;
            this.levelValue.BackColor = System.Drawing.Color.Transparent;
            this.levelValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelValue.ForeColor = System.Drawing.Color.Black;
            this.levelValue.Location = new System.Drawing.Point(110, 133);
            this.levelValue.Name = "levelValue";
            this.levelValue.Size = new System.Drawing.Size(81, 20);
            this.levelValue.TabIndex = 6;
            this.levelValue.Text = "levelValue";
            // 
            // expValue
            // 
            this.expValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.expValue.AutoSize = true;
            this.expValue.BackColor = System.Drawing.Color.Transparent;
            this.expValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expValue.ForeColor = System.Drawing.Color.Black;
            this.expValue.Location = new System.Drawing.Point(110, 92);
            this.expValue.Name = "expValue";
            this.expValue.Size = new System.Drawing.Size(75, 20);
            this.expValue.TabIndex = 7;
            this.expValue.Text = "expValue";
            // 
            // goldValue
            // 
            this.goldValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.goldValue.AutoSize = true;
            this.goldValue.BackColor = System.Drawing.Color.Transparent;
            this.goldValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goldValue.ForeColor = System.Drawing.Color.Black;
            this.goldValue.Location = new System.Drawing.Point(110, 51);
            this.goldValue.Name = "goldValue";
            this.goldValue.Size = new System.Drawing.Size(80, 20);
            this.goldValue.TabIndex = 8;
            this.goldValue.Text = "goldValue";
            // 
            // hpLabel
            // 
            this.hpLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hpLabel.AutoSize = true;
            this.hpLabel.BackColor = System.Drawing.Color.Transparent;
            this.hpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hpLabel.ForeColor = System.Drawing.Color.Black;
            this.hpLabel.Location = new System.Drawing.Point(3, 10);
            this.hpLabel.Name = "hpLabel";
            this.hpLabel.Size = new System.Drawing.Size(38, 20);
            this.hpLabel.TabIndex = 0;
            this.hpLabel.Text = "HP:";
            // 
            // goldLabel
            // 
            this.goldLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.goldLabel.AutoSize = true;
            this.goldLabel.BackColor = System.Drawing.Color.Transparent;
            this.goldLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goldLabel.ForeColor = System.Drawing.Color.Black;
            this.goldLabel.Location = new System.Drawing.Point(3, 51);
            this.goldLabel.Name = "goldLabel";
            this.goldLabel.Size = new System.Drawing.Size(52, 20);
            this.goldLabel.TabIndex = 4;
            this.goldLabel.Text = "Gold:";
            // 
            // levelLabel
            // 
            this.levelLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.levelLabel.AutoSize = true;
            this.levelLabel.BackColor = System.Drawing.Color.Transparent;
            this.levelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelLabel.ForeColor = System.Drawing.Color.Black;
            this.levelLabel.Location = new System.Drawing.Point(3, 133);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(56, 20);
            this.levelLabel.TabIndex = 2;
            this.levelLabel.Text = "Level:";
            // 
            // hpValue
            // 
            this.hpValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hpValue.AutoSize = true;
            this.hpValue.BackColor = System.Drawing.Color.Transparent;
            this.hpValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hpValue.ForeColor = System.Drawing.Color.Black;
            this.hpValue.Location = new System.Drawing.Point(110, 10);
            this.hpValue.Name = "hpValue";
            this.hpValue.Size = new System.Drawing.Size(68, 20);
            this.hpValue.TabIndex = 5;
            this.hpValue.Text = "hpValue";
            // 
            // expLabel
            // 
            this.expLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.expLabel.AutoSize = true;
            this.expLabel.BackColor = System.Drawing.Color.Transparent;
            this.expLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expLabel.ForeColor = System.Drawing.Color.Black;
            this.expLabel.Location = new System.Drawing.Point(3, 92);
            this.expLabel.Name = "expLabel";
            this.expLabel.Size = new System.Drawing.Size(49, 20);
            this.expLabel.TabIndex = 3;
            this.expLabel.Text = "EXP:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.SouthButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.WestButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.EastButton, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.NordButton, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 296);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(205, 185);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.HomeButton, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.RunButton, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.FoodButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.CombatButton, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.AttackButton, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(223, 296);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(357, 185);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // InventoryBox
            // 
            this.InventoryBox.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InventoryBox.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.InventoryBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InventoryBox.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.InventoryBox.DefaultCellStyle = dataGridViewCellStyle2;
            this.InventoryBox.Location = new System.Drawing.Point(377, 12);
            this.InventoryBox.Name = "InventoryBox";
            this.InventoryBox.RowHeadersVisible = false;
            this.InventoryBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.InventoryBox.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.InventoryBox.Size = new System.Drawing.Size(555, 164);
            this.InventoryBox.TabIndex = 12;
            // 
            // QuestBox
            // 
            this.QuestBox.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.QuestBox.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.QuestBox.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.QuestBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.QuestBox.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column6,
            this.Column7});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.QuestBox.DefaultCellStyle = dataGridViewCellStyle4;
            this.QuestBox.Location = new System.Drawing.Point(465, 182);
            this.QuestBox.Name = "QuestBox";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.QuestBox.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.QuestBox.RowHeadersVisible = false;
            this.QuestBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.QuestBox.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.QuestBox.Size = new System.Drawing.Size(467, 108);
            this.QuestBox.TabIndex = 13;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Quest";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Progress";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Status";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "#";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Type";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Description";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Effects";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(944, 501);
            this.Controls.Add(this.QuestBox);
            this.Controls.Add(this.InventoryBox);
            this.Controls.Add(this.locationBox);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.playerStats);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "MainPage";
            this.playerStats.ResumeLayout(false);
            this.playerStats.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InventoryBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuestBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button NordButton;
        private System.Windows.Forms.Button WestButton;
        private System.Windows.Forms.Button SouthButton;
        private System.Windows.Forms.Button EastButton;
        private System.Windows.Forms.Button AttackButton;
        private System.Windows.Forms.RichTextBox locationBox;
        private System.Windows.Forms.RichTextBox logBox;
        private System.Windows.Forms.Button HomeButton;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.Button CombatButton;
        private System.Windows.Forms.Button FoodButton;
        private System.Windows.Forms.TableLayoutPanel playerStats;
        private System.Windows.Forms.Label levelValue;
        private System.Windows.Forms.Label expValue;
        private System.Windows.Forms.Label goldValue;
        private System.Windows.Forms.Label hpLabel;
        private System.Windows.Forms.Label goldLabel;
        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.Label hpValue;
        private System.Windows.Forms.Label expLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView InventoryBox;
        private System.Windows.Forms.DataGridView QuestBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}

