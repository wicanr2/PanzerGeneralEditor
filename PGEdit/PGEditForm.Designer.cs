namespace PanzerGeneralEdit 
{
    partial class PGEditForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PGEditForm));
            this.tb_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_hard_atk = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_air_atk = new System.Windows.Forms.TextBox();
            this.tb_nav_atk = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_soft_atk = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lb_unit = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.pg_menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.RootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EndToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tb_air_def = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_range = new System.Windows.Forms.TextBox();
            this.tb_initiative = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_close_def = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_gnd_def = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_fuel = new System.Windows.Forms.TextBox();
            this.tb_movement = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tb_spotting = new System.Windows.Forms.TextBox();
            this.tb_ammo = new System.Windows.Forms.TextBox();
            this.tb_move_type = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tb_cost = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tb_level_pression = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.store_button = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.tb_type = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lable_unknown1 = new System.Windows.Forms.Label();
            this.tb_unknown1 = new System.Windows.Forms.TextBox();
            this.label_ground_unit = new System.Windows.Forms.Label();
            this.tb_ground_unit = new System.Windows.Forms.TextBox();
            this.label_init_force = new System.Windows.Forms.Label();
            this.label_unknown4 = new System.Windows.Forms.Label();
            this.label_unknown5 = new System.Windows.Forms.Label();
            this.tb_init_force = new System.Windows.Forms.TextBox();
            this.tb_unknown4 = new System.Windows.Forms.TextBox();
            this.tb_unknown5 = new System.Windows.Forms.TextBox();
            this.pg_menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_name
            // 
            this.tb_name.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb_name.Location = new System.Drawing.Point(117, 45);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(275, 29);
            this.tb_name.TabIndex = 1;
            this.tb_name.TextChanged += new System.EventHandler(this.tb_TextChanged);
            this.tb_name.Enter += new System.EventHandler(this.tb_Enter);
            this.tb_name.Leave += new System.EventHandler(this.tb_MouseLeave);
            this.tb_name.MouseLeave += new System.EventHandler(this.tb_MouseLeave);
            this.tb_name.MouseHover += new System.EventHandler(this.tb_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(14, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "名稱";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(14, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "柔性攻擊";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // tb_hard_atk
            // 
            this.tb_hard_atk.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb_hard_atk.Location = new System.Drawing.Point(117, 122);
            this.tb_hard_atk.Name = "tb_hard_atk";
            this.tb_hard_atk.Size = new System.Drawing.Size(72, 29);
            this.tb_hard_atk.TabIndex = 3;
            this.tb_hard_atk.TextChanged += new System.EventHandler(this.tb_TextChanged);
            this.tb_hard_atk.Enter += new System.EventHandler(this.tb_Enter);
            this.tb_hard_atk.Leave += new System.EventHandler(this.tb_MouseLeave);
            this.tb_hard_atk.MouseLeave += new System.EventHandler(this.tb_MouseLeave);
            this.tb_hard_atk.MouseHover += new System.EventHandler(this.tb_MouseHover);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(14, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "硬性攻擊";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(14, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "對空攻擊";
            // 
            // tb_air_atk
            // 
            this.tb_air_atk.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb_air_atk.Location = new System.Drawing.Point(117, 155);
            this.tb_air_atk.Name = "tb_air_atk";
            this.tb_air_atk.Size = new System.Drawing.Size(72, 29);
            this.tb_air_atk.TabIndex = 4;
            this.tb_air_atk.TextChanged += new System.EventHandler(this.tb_TextChanged);
            this.tb_air_atk.Enter += new System.EventHandler(this.tb_Enter);
            this.tb_air_atk.Leave += new System.EventHandler(this.tb_MouseLeave);
            this.tb_air_atk.MouseLeave += new System.EventHandler(this.tb_MouseLeave);
            this.tb_air_atk.MouseHover += new System.EventHandler(this.tb_MouseHover);
            // 
            // tb_nav_atk
            // 
            this.tb_nav_atk.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb_nav_atk.Location = new System.Drawing.Point(117, 189);
            this.tb_nav_atk.Name = "tb_nav_atk";
            this.tb_nav_atk.Size = new System.Drawing.Size(72, 29);
            this.tb_nav_atk.TabIndex = 5;
            this.tb_nav_atk.TextChanged += new System.EventHandler(this.tb_TextChanged);
            this.tb_nav_atk.Enter += new System.EventHandler(this.tb_Enter);
            this.tb_nav_atk.Leave += new System.EventHandler(this.tb_MouseLeave);
            this.tb_nav_atk.MouseLeave += new System.EventHandler(this.tb_MouseLeave);
            this.tb_nav_atk.MouseHover += new System.EventHandler(this.tb_MouseHover);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(14, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "對海攻擊";
            // 
            // tb_soft_atk
            // 
            this.tb_soft_atk.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb_soft_atk.Location = new System.Drawing.Point(117, 88);
            this.tb_soft_atk.Name = "tb_soft_atk";
            this.tb_soft_atk.Size = new System.Drawing.Size(72, 29);
            this.tb_soft_atk.TabIndex = 2;
            this.tb_soft_atk.TextChanged += new System.EventHandler(this.tb_TextChanged);
            this.tb_soft_atk.Enter += new System.EventHandler(this.tb_Enter);
            this.tb_soft_atk.Leave += new System.EventHandler(this.tb_MouseLeave);
            this.tb_soft_atk.MouseLeave += new System.EventHandler(this.tb_MouseLeave);
            this.tb_soft_atk.MouseHover += new System.EventHandler(this.tb_MouseHover);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(429, 472);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 26);
            this.button1.TabIndex = 18;
            this.button1.Text = "上一個";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lb_unit
            // 
            this.lb_unit.FormattingEnabled = true;
            this.lb_unit.ItemHeight = 18;
            this.lb_unit.Location = new System.Drawing.Point(429, 55);
            this.lb_unit.Name = "lb_unit";
            this.lb_unit.Size = new System.Drawing.Size(181, 400);
            this.lb_unit.TabIndex = 20;
            this.lb_unit.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(530, 472);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 26);
            this.button2.TabIndex = 19;
            this.button2.Text = "下一個";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pg_menuStrip1
            // 
            this.pg_menuStrip1.AutoSize = false;
            this.pg_menuStrip1.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.pg_menuStrip1.ImageScalingSize = new System.Drawing.Size(12, 12);
            this.pg_menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RootToolStripMenuItem});
            this.pg_menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.pg_menuStrip1.Name = "pg_menuStrip1";
            this.pg_menuStrip1.Size = new System.Drawing.Size(622, 40);
            this.pg_menuStrip1.TabIndex = 13;
            this.pg_menuStrip1.Text = "menuStrip1";
            // 
            // RootToolStripMenuItem
            // 
            this.RootToolStripMenuItem.AutoSize = false;
            this.RootToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.EndToolStripMenuItem});
            this.RootToolStripMenuItem.Name = "RootToolStripMenuItem";
            this.RootToolStripMenuItem.Size = new System.Drawing.Size(94, 32);
            this.RootToolStripMenuItem.Text = "檔案";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.AutoSize = false;
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(160, 28);
            this.FileToolStripMenuItem.Text = "打開裝備檔";
            this.FileToolStripMenuItem.Click += new System.EventHandler(this.FileToolStripMenuItem_Click);
            // 
            // EndToolStripMenuItem
            // 
            this.EndToolStripMenuItem.Name = "EndToolStripMenuItem";
            this.EndToolStripMenuItem.Size = new System.Drawing.Size(170, 28);
            this.EndToolStripMenuItem.Text = "結束";
            this.EndToolStripMenuItem.Click += new System.EventHandler(this.EndToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "*.eqp";
            this.openFileDialog1.Filter = "裝甲元帥裝備檔 | *.eqp";
            // 
            // tb_air_def
            // 
            this.tb_air_def.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb_air_def.Location = new System.Drawing.Point(117, 256);
            this.tb_air_def.Name = "tb_air_def";
            this.tb_air_def.Size = new System.Drawing.Size(72, 29);
            this.tb_air_def.TabIndex = 7;
            this.tb_air_def.TextChanged += new System.EventHandler(this.tb_TextChanged);
            this.tb_air_def.Enter += new System.EventHandler(this.tb_Enter);
            this.tb_air_def.Leave += new System.EventHandler(this.tb_MouseLeave);
            this.tb_air_def.MouseLeave += new System.EventHandler(this.tb_MouseLeave);
            this.tb_air_def.MouseHover += new System.EventHandler(this.tb_MouseHover);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(13, 364);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 18);
            this.label6.TabIndex = 22;
            this.label6.Text = "攻擊範圍";
            // 
            // tb_range
            // 
            this.tb_range.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb_range.Location = new System.Drawing.Point(117, 358);
            this.tb_range.Name = "tb_range";
            this.tb_range.Size = new System.Drawing.Size(72, 29);
            this.tb_range.TabIndex = 10;
            this.tb_range.TextChanged += new System.EventHandler(this.tb_TextChanged);
            this.tb_range.Enter += new System.EventHandler(this.tb_Enter);
            this.tb_range.Leave += new System.EventHandler(this.tb_MouseLeave);
            this.tb_range.MouseLeave += new System.EventHandler(this.tb_MouseLeave);
            this.tb_range.MouseHover += new System.EventHandler(this.tb_MouseHover);
            // 
            // tb_initiative
            // 
            this.tb_initiative.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb_initiative.Location = new System.Drawing.Point(117, 324);
            this.tb_initiative.Name = "tb_initiative";
            this.tb_initiative.Size = new System.Drawing.Size(72, 29);
            this.tb_initiative.TabIndex = 9;
            this.tb_initiative.TextChanged += new System.EventHandler(this.tb_TextChanged);
            this.tb_initiative.Enter += new System.EventHandler(this.tb_Enter);
            this.tb_initiative.Leave += new System.EventHandler(this.tb_MouseLeave);
            this.tb_initiative.MouseLeave += new System.EventHandler(this.tb_MouseLeave);
            this.tb_initiative.MouseHover += new System.EventHandler(this.tb_MouseHover);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(14, 327);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 18);
            this.label7.TabIndex = 19;
            this.label7.Text = "攻擊起始值";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(14, 292);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 18);
            this.label8.TabIndex = 18;
            this.label8.Text = "近戰防禦";
            // 
            // tb_close_def
            // 
            this.tb_close_def.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb_close_def.Location = new System.Drawing.Point(117, 290);
            this.tb_close_def.Name = "tb_close_def";
            this.tb_close_def.Size = new System.Drawing.Size(72, 29);
            this.tb_close_def.TabIndex = 8;
            this.tb_close_def.TextChanged += new System.EventHandler(this.tb_TextChanged);
            this.tb_close_def.Enter += new System.EventHandler(this.tb_Enter);
            this.tb_close_def.Leave += new System.EventHandler(this.tb_MouseLeave);
            this.tb_close_def.MouseLeave += new System.EventHandler(this.tb_MouseLeave);
            this.tb_close_def.MouseHover += new System.EventHandler(this.tb_MouseHover);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(14, 259);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 18);
            this.label9.TabIndex = 16;
            this.label9.Text = "對空防禦";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(14, 225);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 18);
            this.label10.TabIndex = 15;
            this.label10.Text = "對地防禦";
            // 
            // tb_gnd_def
            // 
            this.tb_gnd_def.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb_gnd_def.Location = new System.Drawing.Point(117, 224);
            this.tb_gnd_def.Name = "tb_gnd_def";
            this.tb_gnd_def.Size = new System.Drawing.Size(72, 29);
            this.tb_gnd_def.TabIndex = 6;
            this.tb_gnd_def.TextChanged += new System.EventHandler(this.tb_TextChanged);
            this.tb_gnd_def.Enter += new System.EventHandler(this.tb_Enter);
            this.tb_gnd_def.Leave += new System.EventHandler(this.tb_MouseLeave);
            this.tb_gnd_def.MouseLeave += new System.EventHandler(this.tb_MouseLeave);
            this.tb_gnd_def.MouseHover += new System.EventHandler(this.tb_MouseHover);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.Location = new System.Drawing.Point(14, 463);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 18);
            this.label11.TabIndex = 29;
            this.label11.Text = "油量";
            // 
            // tb_fuel
            // 
            this.tb_fuel.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb_fuel.Location = new System.Drawing.Point(117, 460);
            this.tb_fuel.Name = "tb_fuel";
            this.tb_fuel.Size = new System.Drawing.Size(72, 29);
            this.tb_fuel.TabIndex = 13;
            this.tb_fuel.TextChanged += new System.EventHandler(this.tb_TextChanged);
            this.tb_fuel.Enter += new System.EventHandler(this.tb_Enter);
            this.tb_fuel.Leave += new System.EventHandler(this.tb_MouseLeave);
            this.tb_fuel.MouseLeave += new System.EventHandler(this.tb_MouseLeave);
            this.tb_fuel.MouseHover += new System.EventHandler(this.tb_MouseHover);
            // 
            // tb_movement
            // 
            this.tb_movement.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb_movement.Location = new System.Drawing.Point(117, 426);
            this.tb_movement.Name = "tb_movement";
            this.tb_movement.Size = new System.Drawing.Size(72, 29);
            this.tb_movement.TabIndex = 12;
            this.tb_movement.TextChanged += new System.EventHandler(this.tb_TextChanged);
            this.tb_movement.Enter += new System.EventHandler(this.tb_Enter);
            this.tb_movement.Leave += new System.EventHandler(this.tb_MouseLeave);
            this.tb_movement.MouseLeave += new System.EventHandler(this.tb_MouseLeave);
            this.tb_movement.MouseHover += new System.EventHandler(this.tb_MouseHover);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(14, 429);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 18);
            this.label12.TabIndex = 26;
            this.label12.Text = "移動量";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 395);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 18);
            this.label13.TabIndex = 25;
            this.label13.Text = "偵查範圍";
            // 
            // tb_spotting
            // 
            this.tb_spotting.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb_spotting.Location = new System.Drawing.Point(117, 393);
            this.tb_spotting.Name = "tb_spotting";
            this.tb_spotting.Size = new System.Drawing.Size(72, 29);
            this.tb_spotting.TabIndex = 11;
            this.tb_spotting.TextChanged += new System.EventHandler(this.tb_TextChanged);
            this.tb_spotting.Enter += new System.EventHandler(this.tb_Enter);
            this.tb_spotting.Leave += new System.EventHandler(this.tb_MouseLeave);
            this.tb_spotting.MouseLeave += new System.EventHandler(this.tb_MouseLeave);
            this.tb_spotting.MouseHover += new System.EventHandler(this.tb_MouseHover);
            // 
            // tb_ammo
            // 
            this.tb_ammo.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb_ammo.Location = new System.Drawing.Point(320, 88);
            this.tb_ammo.Name = "tb_ammo";
            this.tb_ammo.Size = new System.Drawing.Size(73, 29);
            this.tb_ammo.TabIndex = 14;
            this.tb_ammo.TextChanged += new System.EventHandler(this.tb_TextChanged);
            this.tb_ammo.Enter += new System.EventHandler(this.tb_Enter);
            this.tb_ammo.Leave += new System.EventHandler(this.tb_MouseLeave);
            this.tb_ammo.MouseLeave += new System.EventHandler(this.tb_MouseLeave);
            this.tb_ammo.MouseHover += new System.EventHandler(this.tb_MouseHover);
            // 
            // tb_move_type
            // 
            this.tb_move_type.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb_move_type.Location = new System.Drawing.Point(320, 155);
            this.tb_move_type.Name = "tb_move_type";
            this.tb_move_type.ReadOnly = true;
            this.tb_move_type.Size = new System.Drawing.Size(73, 29);
            this.tb_move_type.TabIndex = 34;
            this.tb_move_type.TabStop = false;
            this.tb_move_type.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label15.Location = new System.Drawing.Point(218, 158);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 18);
            this.label15.TabIndex = 33;
            this.label15.Text = "移動型態";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label16.Location = new System.Drawing.Point(218, 124);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 18);
            this.label16.TabIndex = 32;
            this.label16.Text = "單位價格";
            // 
            // tb_cost
            // 
            this.tb_cost.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb_cost.Location = new System.Drawing.Point(320, 122);
            this.tb_cost.Name = "tb_cost";
            this.tb_cost.Size = new System.Drawing.Size(73, 29);
            this.tb_cost.TabIndex = 15;
            this.tb_cost.TextChanged += new System.EventHandler(this.tb_TextChanged);
            this.tb_cost.Enter += new System.EventHandler(this.tb_Enter);
            this.tb_cost.Leave += new System.EventHandler(this.tb_MouseLeave);
            this.tb_cost.MouseLeave += new System.EventHandler(this.tb_MouseLeave);
            this.tb_cost.MouseHover += new System.EventHandler(this.tb_MouseHover);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label17.Location = new System.Drawing.Point(218, 90);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 18);
            this.label17.TabIndex = 30;
            this.label17.Text = "彈藥量";
            // 
            // tb_level_pression
            // 
            this.tb_level_pression.Enabled = false;
            this.tb_level_pression.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb_level_pression.Location = new System.Drawing.Point(320, 189);
            this.tb_level_pression.Name = "tb_level_pression";
            this.tb_level_pression.Size = new System.Drawing.Size(73, 29);
            this.tb_level_pression.TabIndex = 16;
            this.tb_level_pression.TextChanged += new System.EventHandler(this.tb_TextChanged);
            this.tb_level_pression.Enter += new System.EventHandler(this.tb_Enter);
            this.tb_level_pression.Leave += new System.EventHandler(this.tb_MouseLeave);
            this.tb_level_pression.MouseLeave += new System.EventHandler(this.tb_MouseLeave);
            this.tb_level_pression.MouseHover += new System.EventHandler(this.tb_MouseHover);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(218, 191);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 18);
            this.label14.TabIndex = 38;
            this.label14.Text = "壓制力";
            // 
            // store_button
            // 
            this.store_button.Enabled = false;
            this.store_button.Location = new System.Drawing.Point(221, 225);
            this.store_button.Name = "store_button";
            this.store_button.Size = new System.Drawing.Size(172, 38);
            this.store_button.TabIndex = 17;
            this.store_button.Text = "儲存修改";
            this.store_button.UseVisualStyleBackColor = true;
            this.store_button.Click += new System.EventHandler(this.store_button_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(218, 281);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(44, 18);
            this.label18.TabIndex = 41;
            this.label18.Text = "類別";
            // 
            // tb_type
            // 
            this.tb_type.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb_type.Location = new System.Drawing.Point(268, 278);
            this.tb_type.Name = "tb_type";
            this.tb_type.ReadOnly = true;
            this.tb_type.Size = new System.Drawing.Size(124, 29);
            this.tb_type.TabIndex = 42;
            this.tb_type.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("微軟正黑體", 9.216F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 522);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(622, 22);
            this.statusStrip1.TabIndex = 43;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // lable_unknown1
            // 
            this.lable_unknown1.AutoSize = true;
            this.lable_unknown1.Location = new System.Drawing.Point(218, 325);
            this.lable_unknown1.Name = "lable_unknown1";
            this.lable_unknown1.Size = new System.Drawing.Size(52, 18);
            this.lable_unknown1.TabIndex = 44;
            this.lable_unknown1.Text = "未知1";
            // 
            // tb_unknown1
            // 
            this.tb_unknown1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb_unknown1.Location = new System.Drawing.Point(320, 314);
            this.tb_unknown1.Name = "tb_unknown1";
            this.tb_unknown1.ReadOnly = true;
            this.tb_unknown1.Size = new System.Drawing.Size(73, 29);
            this.tb_unknown1.TabIndex = 45;
            this.tb_unknown1.TabStop = false;
            // 
            // label_ground_unit
            // 
            this.label_ground_unit.AutoSize = true;
            this.label_ground_unit.Location = new System.Drawing.Point(218, 358);
            this.label_ground_unit.Name = "label_ground_unit";
            this.label_ground_unit.Size = new System.Drawing.Size(80, 18);
            this.label_ground_unit.TabIndex = 46;
            this.label_ground_unit.Text = "地面部隊";
            // 
            // tb_ground_unit
            // 
            this.tb_ground_unit.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb_ground_unit.Location = new System.Drawing.Point(320, 347);
            this.tb_ground_unit.Name = "tb_ground_unit";
            this.tb_ground_unit.ReadOnly = true;
            this.tb_ground_unit.Size = new System.Drawing.Size(73, 29);
            this.tb_ground_unit.TabIndex = 47;
            this.tb_ground_unit.TabStop = false;
            // 
            // label_init_force
            // 
            this.label_init_force.AutoSize = true;
            this.label_init_force.Location = new System.Drawing.Point(218, 393);
            this.label_init_force.Name = "label_init_force";
            this.label_init_force.Size = new System.Drawing.Size(80, 18);
            this.label_init_force.TabIndex = 48;
            this.label_init_force.Text = "起始兵力";
            // 
            // label_unknown4
            // 
            this.label_unknown4.AutoSize = true;
            this.label_unknown4.Location = new System.Drawing.Point(218, 426);
            this.label_unknown4.Name = "label_unknown4";
            this.label_unknown4.Size = new System.Drawing.Size(52, 18);
            this.label_unknown4.TabIndex = 49;
            this.label_unknown4.Text = "未知4";
            // 
            // label_unknown5
            // 
            this.label_unknown5.AutoSize = true;
            this.label_unknown5.Location = new System.Drawing.Point(218, 460);
            this.label_unknown5.Name = "label_unknown5";
            this.label_unknown5.Size = new System.Drawing.Size(52, 18);
            this.label_unknown5.TabIndex = 50;
            this.label_unknown5.Text = "未知5";
            // 
            // tb_init_force
            // 
            this.tb_init_force.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb_init_force.Location = new System.Drawing.Point(320, 382);
            this.tb_init_force.Name = "tb_init_force";
            this.tb_init_force.Size = new System.Drawing.Size(73, 29);
            this.tb_init_force.TabIndex = 51;
            this.tb_init_force.TabStop = false;
            this.tb_init_force.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // tb_unknown4
            // 
            this.tb_unknown4.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb_unknown4.Location = new System.Drawing.Point(320, 415);
            this.tb_unknown4.Name = "tb_unknown4";
            this.tb_unknown4.ReadOnly = true;
            this.tb_unknown4.Size = new System.Drawing.Size(73, 29);
            this.tb_unknown4.TabIndex = 52;
            this.tb_unknown4.TabStop = false;
            // 
            // tb_unknown5
            // 
            this.tb_unknown5.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb_unknown5.Location = new System.Drawing.Point(320, 451);
            this.tb_unknown5.Name = "tb_unknown5";
            this.tb_unknown5.ReadOnly = true;
            this.tb_unknown5.Size = new System.Drawing.Size(73, 29);
            this.tb_unknown5.TabIndex = 53;
            this.tb_unknown5.TabStop = false;
            // 
            // PGEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(622, 544);
            this.Controls.Add(this.tb_unknown5);
            this.Controls.Add(this.tb_unknown4);
            this.Controls.Add(this.tb_init_force);
            this.Controls.Add(this.label_unknown5);
            this.Controls.Add(this.label_unknown4);
            this.Controls.Add(this.label_init_force);
            this.Controls.Add(this.tb_ground_unit);
            this.Controls.Add(this.label_ground_unit);
            this.Controls.Add(this.tb_unknown1);
            this.Controls.Add(this.lable_unknown1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tb_type);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.store_button);
            this.Controls.Add(this.tb_level_pression);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tb_ammo);
            this.Controls.Add(this.tb_move_type);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.tb_cost);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tb_fuel);
            this.Controls.Add(this.tb_movement);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tb_spotting);
            this.Controls.Add(this.tb_air_def);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_range);
            this.Controls.Add(this.tb_initiative);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tb_close_def);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tb_gnd_def);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lb_unit);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb_soft_atk);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_nav_atk);
            this.Controls.Add(this.tb_air_atk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_hard_atk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.pg_menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.pg_menuStrip1;
            this.Name = "PGEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "裝甲元帥修改器";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pg_menuStrip1.ResumeLayout(false);
            this.pg_menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_hard_atk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_air_atk;
        private System.Windows.Forms.TextBox tb_nav_atk;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_soft_atk;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lb_unit;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MenuStrip pg_menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem RootToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EndToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox tb_air_def;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_range;
        private System.Windows.Forms.TextBox tb_initiative;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_close_def;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_gnd_def;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tb_fuel;
        private System.Windows.Forms.TextBox tb_movement;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tb_spotting;
        private System.Windows.Forms.TextBox tb_ammo;
        private System.Windows.Forms.TextBox tb_move_type;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tb_cost;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tb_level_pression;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button store_button;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tb_type;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label lable_unknown1;
        private System.Windows.Forms.TextBox tb_unknown1;
        private System.Windows.Forms.Label label_ground_unit;
        private System.Windows.Forms.TextBox tb_ground_unit;
        private System.Windows.Forms.Label label_init_force;
        private System.Windows.Forms.Label label_unknown4;
        private System.Windows.Forms.Label label_unknown5;
        private System.Windows.Forms.TextBox tb_init_force;
        private System.Windows.Forms.TextBox tb_unknown4;
        private System.Windows.Forms.TextBox tb_unknown5;
    }
}

