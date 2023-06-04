using System.Linq;
using System.Windows.Forms;

namespace Hide_SeekGame
{
    partial class Form0
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            ControllerPanel = new Panel();
            btnRefresh = new Button();
            labelControllerNum = new Label();
            ControllerTextBox = new TextBox();
            DummyPatternCBox = new ComboBox();
            labelDummyPattern = new Label();
            DummyCBox = new ComboBox();
            labelDummyNum = new Label();
            DisplayCBox = new ComboBox();
            labelDisplay = new Label();
            GreenCBox = new ComboBox();
            YellowCBox = new ComboBox();
            BlueCBox = new ComboBox();
            GreenLabel4 = new Label();
            YellowLabel3 = new Label();
            BlueLabel2 = new Label();
            RedCBox = new ComboBox();
            RedLabel1 = new Label();
            labelTitle = new Label();
            btnExit = new Button();
            btnPlay = new Button();
            HowToBtn = new Button();
            panel1.SuspendLayout();
            ControllerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = Color.FromArgb(255, 224, 192);
            panel1.Controls.Add(HowToBtn);
            panel1.Controls.Add(ControllerPanel);
            panel1.Controls.Add(DummyPatternCBox);
            panel1.Controls.Add(labelDummyPattern);
            panel1.Controls.Add(DummyCBox);
            panel1.Controls.Add(labelDummyNum);
            panel1.Controls.Add(DisplayCBox);
            panel1.Controls.Add(labelDisplay);
            panel1.Controls.Add(GreenCBox);
            panel1.Controls.Add(YellowCBox);
            panel1.Controls.Add(BlueCBox);
            panel1.Controls.Add(GreenLabel4);
            panel1.Controls.Add(YellowLabel3);
            panel1.Controls.Add(BlueLabel2);
            panel1.Controls.Add(RedCBox);
            panel1.Controls.Add(RedLabel1);
            panel1.Controls.Add(labelTitle);
            panel1.Controls.Add(btnExit);
            panel1.Controls.Add(btnPlay);
            panel1.Location = new Point(0, -2);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(943, 656);
            panel1.TabIndex = 0;
            // 
            // ControllerPanel
            // 
            ControllerPanel.BackColor = Color.FromArgb(255, 192, 128);
            ControllerPanel.Controls.Add(btnRefresh);
            ControllerPanel.Controls.Add(labelControllerNum);
            ControllerPanel.Controls.Add(ControllerTextBox);
            ControllerPanel.Location = new Point(462, 138);
            ControllerPanel.Margin = new Padding(3, 2, 3, 2);
            ControllerPanel.Name = "ControllerPanel";
            ControllerPanel.Size = new Size(408, 281);
            ControllerPanel.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.Silver;
            btnRefresh.Font = new Font("Cooper Black", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnRefresh.Location = new Point(289, 231);
            btnRefresh.Margin = new Padding(3, 2, 3, 2);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(106, 38);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += RefreshButton_Click;
            // 
            // labelControllerNum
            // 
            labelControllerNum.AutoSize = true;
            labelControllerNum.Font = new Font("Cooper Black", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            labelControllerNum.Location = new Point(131, 15);
            labelControllerNum.Name = "labelControllerNum";
            labelControllerNum.Size = new Size(147, 25);
            labelControllerNum.TabIndex = 17;
            labelControllerNum.Text = "Controllers ";
            // 
            // ControllerTextBox
            // 
            ControllerTextBox.BackColor = Color.FromArgb(255, 224, 192);
            ControllerTextBox.Font = new Font("맑은 고딕", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            ControllerTextBox.Location = new Point(41, 56);
            ControllerTextBox.Margin = new Padding(3, 2, 3, 2);
            ControllerTextBox.Multiline = true;
            ControllerTextBox.Name = "ControllerTextBox";
            ControllerTextBox.Size = new Size(324, 169);
            ControllerTextBox.TabIndex = 18;
            ControllerTextBox.Text = "현재 연결된 Controller 없음\r\n";
            // 
            // DummyPatternCBox
            // 
            DummyPatternCBox.Font = new Font("맑은 고딕", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            DummyPatternCBox.FormattingEnabled = true;
            DummyPatternCBox.Items.AddRange(new object[] { "무작위로 움직임", "1초마다 무작위", "2초마다 무작위", "2초마다 직각", "섞어서" });
            DummyPatternCBox.Location = new Point(156, 339);
            DummyPatternCBox.Margin = new Padding(3, 2, 3, 2);
            DummyPatternCBox.Name = "DummyPatternCBox";
            DummyPatternCBox.Size = new Size(189, 27);
            DummyPatternCBox.TabIndex = 16;
            DummyPatternCBox.SelectedIndexChanged += DummyPatternCBox_SelectedIndexChanged;
            // 
            // labelDummyPattern
            // 
            labelDummyPattern.AutoSize = true;
            labelDummyPattern.Font = new Font("Cooper Black", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            labelDummyPattern.Location = new Point(18, 325);
            labelDummyPattern.Name = "labelDummyPattern";
            labelDummyPattern.Size = new Size(101, 50);
            labelDummyPattern.TabIndex = 15;
            labelDummyPattern.Text = "Dummy\r\nPattern";
            // 
            // DummyCBox
            // 
            DummyCBox.Font = new Font("맑은 고딕", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            DummyCBox.FormattingEnabled = true;
            DummyCBox.Items.AddRange(new object[] { "10", "20", "30", "40", "50" });
            DummyCBox.Location = new Point(156, 258);
            DummyCBox.Margin = new Padding(3, 2, 3, 2);
            DummyCBox.Name = "DummyCBox";
            DummyCBox.Size = new Size(189, 27);
            DummyCBox.TabIndex = 14;
            DummyCBox.SelectedIndexChanged += DummyCBox_SelectedIndexChanged;
            // 
            // labelDummyNum
            // 
            labelDummyNum.AutoSize = true;
            labelDummyNum.Font = new Font("Cooper Black", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            labelDummyNum.Location = new Point(18, 258);
            labelDummyNum.Name = "labelDummyNum";
            labelDummyNum.Size = new Size(111, 25);
            labelDummyNum.TabIndex = 13;
            labelDummyNum.Text = "Dummys";
            // 
            // DisplayCBox
            // 
            DisplayCBox.Font = new Font("맑은 고딕", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            DisplayCBox.FormattingEnabled = true;
            DisplayCBox.Items.AddRange(new object[] { "1024 x 768", "1280 x 768", "1366 x 768", "1152 x 864", "1440 x 990", "1680 x 1050", "1280 x 1024", "1400 x 1050", "1600 x 1200", "1920 x 1200" });
            DisplayCBox.Location = new Point(156, 182);
            DisplayCBox.Margin = new Padding(3, 2, 3, 2);
            DisplayCBox.Name = "DisplayCBox";
            DisplayCBox.Size = new Size(189, 27);
            DisplayCBox.TabIndex = 12;
            DisplayCBox.SelectedIndexChanged += DisplayCBox_SelectedIndexChanged;
            // 
            // labelDisplay
            // 
            labelDisplay.AutoSize = true;
            labelDisplay.Cursor = Cursors.Hand;
            labelDisplay.Font = new Font("Cooper Black", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            labelDisplay.Location = new Point(18, 181);
            labelDisplay.Name = "labelDisplay";
            labelDisplay.Size = new Size(97, 25);
            labelDisplay.TabIndex = 11;
            labelDisplay.Text = "Display";
            // 
            // GreenCBox
            // 
            GreenCBox.DropDownStyle = ComboBoxStyle.DropDownList;
            GreenCBox.Font = new Font("맑은 고딕", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            GreenCBox.FormattingEnabled = true;
            GreenCBox.Items.AddRange(new object[] { "KeyBoard1", "KeyBoard2", "None" });
            GreenCBox.Location = new Point(676, 500);
            GreenCBox.Margin = new Padding(3, 2, 3, 2);
            GreenCBox.Name = "GreenCBox";
            GreenCBox.Size = new Size(194, 27);
            GreenCBox.Sorted = true;
            GreenCBox.TabIndex = 10;
            GreenCBox.SelectedIndexChanged += GreenCBox_SelectedIndexChanged;
            // 
            // YellowCBox
            // 
            YellowCBox.DropDownStyle = ComboBoxStyle.DropDownList;
            YellowCBox.Font = new Font("맑은 고딕", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            YellowCBox.FormattingEnabled = true;
            YellowCBox.Items.AddRange(new object[] { "KeyBoard1", "KeyBoard2", "None" });
            YellowCBox.Location = new Point(676, 442);
            YellowCBox.Margin = new Padding(3, 2, 3, 2);
            YellowCBox.Name = "YellowCBox";
            YellowCBox.Size = new Size(194, 27);
            YellowCBox.Sorted = true;
            YellowCBox.TabIndex = 9;
            YellowCBox.SelectedIndexChanged += YellowCBox_SelectedIndexChanged;
            // 
            // BlueCBox
            // 
            BlueCBox.DropDownStyle = ComboBoxStyle.DropDownList;
            BlueCBox.Font = new Font("맑은 고딕", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            BlueCBox.FormattingEnabled = true;
            BlueCBox.Items.AddRange(new object[] { "KeyBoard1", "KeyBoard2", "None" });
            BlueCBox.Location = new Point(209, 494);
            BlueCBox.Margin = new Padding(3, 2, 3, 2);
            BlueCBox.Name = "BlueCBox";
            BlueCBox.Size = new Size(194, 27);
            BlueCBox.Sorted = true;
            BlueCBox.TabIndex = 8;
            BlueCBox.SelectedIndexChanged += BlueCBox_SelectedIndexChanged;
            // 
            // GreenLabel4
            // 
            GreenLabel4.AutoSize = true;
            GreenLabel4.FlatStyle = FlatStyle.Flat;
            GreenLabel4.Font = new Font("Cooper Black", 20F, FontStyle.Regular, GraphicsUnit.Point);
            GreenLabel4.ForeColor = Color.Green;
            GreenLabel4.Location = new Point(456, 494);
            GreenLabel4.Name = "GreenLabel4";
            GreenLabel4.Size = new Size(190, 31);
            GreenLabel4.TabIndex = 7;
            GreenLabel4.Text = "Player Green";
            // 
            // YellowLabel3
            // 
            YellowLabel3.AutoSize = true;
            YellowLabel3.FlatStyle = FlatStyle.Flat;
            YellowLabel3.Font = new Font("Cooper Black", 20F, FontStyle.Regular, GraphicsUnit.Point);
            YellowLabel3.ForeColor = Color.Yellow;
            YellowLabel3.Location = new Point(456, 436);
            YellowLabel3.Name = "YellowLabel3";
            YellowLabel3.Size = new Size(207, 31);
            YellowLabel3.TabIndex = 6;
            YellowLabel3.Text = "Player Yellow";
            // 
            // BlueLabel2
            // 
            BlueLabel2.AutoSize = true;
            BlueLabel2.FlatStyle = FlatStyle.Flat;
            BlueLabel2.Font = new Font("Cooper Black", 20F, FontStyle.Regular, GraphicsUnit.Point);
            BlueLabel2.ForeColor = Color.Blue;
            BlueLabel2.Location = new Point(17, 494);
            BlueLabel2.Name = "BlueLabel2";
            BlueLabel2.Size = new Size(170, 31);
            BlueLabel2.TabIndex = 5;
            BlueLabel2.Text = "Player Blue";
            // 
            // RedCBox
            // 
            RedCBox.DropDownStyle = ComboBoxStyle.DropDownList;
            RedCBox.Font = new Font("맑은 고딕", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            RedCBox.FormattingEnabled = true;
            RedCBox.Items.AddRange(new object[] { "KeyBoard1", "KeyBoard2", "None" });
            RedCBox.Location = new Point(209, 442);
            RedCBox.Margin = new Padding(3, 2, 3, 2);
            RedCBox.Name = "RedCBox";
            RedCBox.Size = new Size(194, 27);
            RedCBox.Sorted = true;
            RedCBox.TabIndex = 4;
            RedCBox.SelectedIndexChanged += RedCBox_SelectedIndexChanged;
            // 
            // RedLabel1
            // 
            RedLabel1.AutoSize = true;
            RedLabel1.FlatStyle = FlatStyle.Flat;
            RedLabel1.Font = new Font("Cooper Black", 20F, FontStyle.Regular, GraphicsUnit.Point);
            RedLabel1.ForeColor = Color.Red;
            RedLabel1.Location = new Point(17, 436);
            RedLabel1.Name = "RedLabel1";
            RedLabel1.Size = new Size(162, 31);
            RedLabel1.TabIndex = 3;
            RedLabel1.Text = "Player Red";
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Cooper Black", 30F, FontStyle.Regular, GraphicsUnit.Point);
            labelTitle.Location = new Point(312, 40);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(265, 46);
            labelTitle.TabIndex = 2;
            labelTitle.Text = "Hide && Seek";
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Silver;
            btnExit.Font = new Font("Cooper Black", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btnExit.Location = new Point(669, 552);
            btnExit.Margin = new Padding(3, 2, 3, 2);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(188, 68);
            btnExit.TabIndex = 1;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += ExitButton_Click;
            // 
            // btnPlay
            // 
            btnPlay.BackColor = Color.Silver;
            btnPlay.Font = new Font("Cooper Black", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btnPlay.Location = new Point(345, 552);
            btnPlay.Margin = new Padding(3, 2, 3, 2);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(188, 68);
            btnPlay.TabIndex = 0;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = false;
            btnPlay.Click += PlayButton_Click;
            // 
            // HowToBtn
            // 
            HowToBtn.BackColor = Color.Silver;
            HowToBtn.Font = new Font("Cooper Black", 18F, FontStyle.Regular, GraphicsUnit.Point);
            HowToBtn.Location = new Point(18, 552);
            HowToBtn.Margin = new Padding(3, 2, 3, 2);
            HowToBtn.Name = "HowToBtn";
            HowToBtn.Size = new Size(188, 68);
            HowToBtn.TabIndex = 17;
            HowToBtn.Text = "How to play";
            HowToBtn.UseVisualStyleBackColor = false;
            HowToBtn.Click += HowToBtn_Click;
            // 
            // Form0
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 652);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form0";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ControllerPanel.ResumeLayout(false);
            ControllerPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label RedLabel1;
        private System.Windows.Forms.ComboBox RedCBox;
        private System.Windows.Forms.ComboBox GreenCBox;
        private System.Windows.Forms.ComboBox YellowCBox;
        private System.Windows.Forms.ComboBox BlueCBox;
        private System.Windows.Forms.Label GreenLabel4;
        private System.Windows.Forms.Label YellowLabel3;
        private System.Windows.Forms.Label BlueLabel2;




        private ComboBox DisplayCBox;
        private Label labelDisplay;
        private Label labelDummyNum;
        private ComboBox DummyPatternCBox;
        private Label labelDummyPattern;
        private ComboBox DummyCBox;
        private Label labelControllerNum;
        private TextBox ControllerTextBox;
        private Panel ControllerPanel;
        private Button btnRefresh;
        private Button HowToBtn;
    }


}

