using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Windows.Gaming.Input;
using Windows.Networking.Vpn;

namespace Hide_SeekGame
{
    

    public partial class Form1 : Form
    {
        #region 넘겨받는 데이터-----------------------------------------------------------------------------

        public PlayerInfo Player1Info { get; set; }
        public PlayerInfo Player2Info { get; set; }
        public PlayerInfo Player3Info { get; set; }
        public PlayerInfo Player4Info { get; set; }

        public Size ReceivedResolution { get; set; }


        public string DummyPattern { get; set; }
        public int DummyCnt { get; set; }

        #endregion

        private Size resolution = new Size(1280, 1024);


        private GameManager gameManager;

        private ObjectManager objectManager;

        private System.Windows.Forms.Timer mainTimer;

        private TimerTickRecoder tickOfMainTimer;


        private int statusBoxMaxWidth = 320; // Maximum width for the PictureBox controls
        private int statusBoxHeight = 124; // Height of the PictureBox controls
        private int statusBoxSpacing = 0; // Adjust the spacing between PictureBox controls as needed

        private PictureBox statusBox1;
        private PictureBox statusBox2;
        private PictureBox statusBox3;
        private PictureBox statusBox4;

        private Label player1Cool = new Label();
        private Label player2Cool = new Label();
        private Label player3Cool = new Label();
        private Label player4Cool = new Label();


        private List<PictureBox> statusBox = new List<PictureBox>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            resolution = this.ReceivedResolution;

            #region 메인타이머 생성---------------------------------------
            mainTimer = new System.Windows.Forms.Timer();
            mainTimer.Enabled = true;
            mainTimer.Interval = 1;
            mainTimer.Tick += MainTimer_Tick;

            tickOfMainTimer = new TimerTickRecoder();

            #endregion

            #region 두 매니저 초기화------------------------------
            gameManager = new GameManager();
            objectManager = new ObjectManager(tickOfMainTimer,this);
            #endregion

            #region 플레이어 데이터-------------------------------------------
            RandomChoose randQudrant = new RandomChoose(4);


            PlayerInfo player1Info = Player1Info;
            player1Info.Qudrant = randQudrant.Choose();


            PlayerInfo player2Info = Player2Info;
            player2Info.Qudrant = randQudrant.Choose();

            PlayerInfo player3Info = Player3Info;
            player3Info.Qudrant = randQudrant.Choose();

            PlayerInfo player4Info = Player4Info;
            player4Info.Qudrant = randQudrant.Choose();
            #endregion

            #region 더미 추가--------------------------------------
            gameManager.DummyPatternSetting(DummyPattern);
            gameManager.DummyCountSetting(DummyCnt);

            for (int i = 0; i < gameManager.DummyCount; i++)
            {
                if (gameManager.DummyPattern == "Random")
                {
                    Random rand = new Random();
                    int tmp = rand.Next(0, 4);
                    objectManager.AddDummy(Controls, resolution, tmp);
                }
                else
                {
                    objectManager.AddDummy(Controls, resolution, Int32.Parse(gameManager.DummyPattern));
                }
            }

            #endregion

            #region 플레이어 추가 -----------------------------------------------
            gameManager.Player1Setting(player1Info);

            gameManager.Player2Setting(player2Info);

            gameManager.Player3Setting(player3Info);

            gameManager.Player4Setting(player4Info);

            objectManager.AddPlayer(Controls, resolution, gameManager.Player1Info,player1Cool);
            objectManager.AddPlayer(Controls, resolution, gameManager.Player2Info,player2Cool);
            objectManager.AddPlayer(Controls, resolution, gameManager.Player3Info,player3Cool);
            objectManager.AddPlayer(Controls, resolution, gameManager.Player4Info,player4Cool);
            #endregion

            #region 상태창 추가 ----------------------------------------

            CreatePlayerStatusWindows();

            objectManager.StatusBox = statusBox;
            UpdatePlayerCondition(this.statusBox1,this.statusBox2,this.statusBox3,this.statusBox4, this.objectManager.Players);

            #endregion

        }

        private void MainTimer_Tick(object? sender, EventArgs e)
        {
            tickOfMainTimer.IncreaseTotalTick();

            objectManager.PlayersPadCheck();

            objectManager.PlayersMove();
            objectManager.DummiesMove();

        }


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            objectManager.PlayersKeyUpCheck(e);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            objectManager.PlayersKeyDownCheck(e);
        }


        #region 상태창 관련--------------------------------------------

        private void CreatePlayerStatusWindows()
        {
            // Calculate the total width required for the PictureBox controls and spacing
            int totalWidth = 4 * statusBoxMaxWidth + 3 * statusBoxSpacing;

            // Calculate the left offset to center the statusBox controls at the bottom
            int leftOffset = (resolution.Width - totalWidth) / 2;

            #region 가로 1280미만
            if (resolution.Width < 1280)
            {
                int smallerWidth = resolution.Width / 4;  // Calculate the smaller width proportionally

                // Adjust the total width and left offset based on the smaller width
                totalWidth = 4 * smallerWidth + 3 * statusBoxSpacing;
                leftOffset = (resolution.Width - totalWidth) / 2;

                // Update the statusBoxMaxWidth with the smaller width
                statusBoxMaxWidth = smallerWidth;
                statusBoxHeight = (int)(smallerWidth * 124 / 320);
            }
            #endregion



            #region 플레이어별 상태창 생성


            

            // Create and position the PictureBox controls
            statusBox1 = new PictureBox();
            statusBox1.Width = statusBoxMaxWidth;
            statusBox1.Height = statusBoxHeight;
            statusBox1.Left = leftOffset;
            statusBox1.Top = resolution.Height - statusBoxHeight; // Adjust the vertical position as needed
            statusBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            if (this.Player1Info.IsPlaying == true)
            {
                player1Cool.Text = Convert.ToString(0);
                player1Cool.Location = statusBox1.Location;
                player1Cool.Left += (int)(statusBox1.Width * 0.8);
                player1Cool.Top += (int)(statusBox1.Height * 0.65);
                player1Cool.Width = 50;
                player1Cool.Height = 30;
                player1Cool.Font = new Font("맑은 고딕", 15F, FontStyle.Regular, GraphicsUnit.Point);

                this.Controls.Add(player1Cool);
            }
            this.Controls.Add(statusBox1);

            




            statusBox2 = new PictureBox();
            statusBox2.Width = statusBoxMaxWidth;
            statusBox2.Height = statusBoxHeight;
            statusBox2.Left = statusBox1.Right + statusBoxSpacing;
            statusBox2.Top = resolution.Height - statusBoxHeight; // Adjust the vertical position as needed
            statusBox2.SizeMode = PictureBoxSizeMode.StretchImage;

            if (this.Player2Info.IsPlaying == true)
            {
                player2Cool.Text = Convert.ToString(0);
                player2Cool.Location = statusBox2.Location;
                player2Cool.Left += (int)(statusBox2.Width * 0.8);
                player2Cool.Top += (int)(statusBox2.Height * 0.65);
                player2Cool.Width = 50;
                player2Cool.Height = 30;
                player2Cool.Font = new Font("맑은 고딕", 15F, FontStyle.Regular, GraphicsUnit.Point);

                this.Controls.Add(player2Cool);
            }
            this.Controls.Add(statusBox2);



            statusBox3 = new PictureBox();
            statusBox3.Width = statusBoxMaxWidth;
            statusBox3.Height = statusBoxHeight;
            statusBox3.Left = statusBox2.Right + statusBoxSpacing;
            statusBox3.Top = resolution.Height - statusBoxHeight; // Adjust the vertical position as needed
            statusBox3.SizeMode = PictureBoxSizeMode.StretchImage;

            if (this.Player3Info.IsPlaying == true)
            {
                player3Cool.Text = Convert.ToString(0);
                player3Cool.Location = statusBox3.Location;
                player3Cool.Left += (int)(statusBox3.Width * 0.8);
                player3Cool.Top += (int)(statusBox3.Height * 0.65);
                player3Cool.Width = 50;
                player3Cool.Height = 30;
                player3Cool.Font = new Font("맑은 고딕", 15F, FontStyle.Regular, GraphicsUnit.Point);

                this.Controls.Add(player3Cool);
            }
            this.Controls.Add(statusBox3);



            statusBox4 = new PictureBox();
            statusBox4.Width = statusBoxMaxWidth;
            statusBox4.Height = statusBoxHeight;
            statusBox4.Left = statusBox3.Right + statusBoxSpacing;
            statusBox4.Top = resolution.Height - statusBoxHeight; // Adjust the vertical position as needed
            statusBox4.SizeMode = PictureBoxSizeMode.StretchImage;

            if (this.Player4Info.IsPlaying == true)
            {
                player4Cool.Text = Convert.ToString(0);
                player4Cool.Location = statusBox4.Location;
                player4Cool.Left += (int)(statusBox4.Width * 0.8);
                player4Cool.Top += (int)(statusBox4.Height * 0.65);
                player4Cool.Width = 50;
                player4Cool.Height = 30;
                player4Cool.Font = new Font("맑은 고딕", 15F, FontStyle.Regular, GraphicsUnit.Point);

                this.Controls.Add(player4Cool);
            }

            this.Controls.Add(statusBox4);




            statusBox.Add(statusBox1);
            statusBox.Add(statusBox2);
            statusBox.Add(statusBox3);
            statusBox.Add(statusBox4);

            #endregion

            #region 상태창 배경 검정 패널
            PictureBox blackBox = new PictureBox();
            blackBox.BackColor = Color.Black;
            blackBox.Width = resolution.Width;
            blackBox.Height = 124;
            blackBox.Left = 0;
            blackBox.Top = resolution.Height - blackBox.Height;
            this.Controls.Add(blackBox);
            #endregion
        }


        private void UpdatePlayerCondition(PictureBox statusBox1, PictureBox statusBox2, PictureBox statusBox3, PictureBox statusBox4, List<Player> players)
        {
            PlayerStatus AllFalse = new PlayerStatus()
            {
                IsPlaying = false,
                Keyboard = false,
                Controller = false,
                IsAlive = false,
                CanGunAttack = false,
            };

            PlayerStatus player1 = AllFalse;
            PlayerStatus player2 = AllFalse;
            PlayerStatus player3 = AllFalse;
            PlayerStatus player4 = AllFalse;

            foreach(Player player in players) 
            {
                if(player.StrColor == "Red")
                {
                    if(player.IsPlaying == true)
                    {
                        player1.IsPlaying = true;
                    }
                    
                    if(player is KeyboardPlayer)
                    {
                        player1.Keyboard = true;
                    }
                    else if(player is ControllerPlayer)
                    {
                        player1.Controller = true;
                    }


                    if(player.IsAlive == true)
                    {
                        player1.IsAlive = true;
                    }

                    if(player.CanGunAttack == true)
                    {
                        player1.CanGunAttack = true;
                    }
                }
                else if (player.StrColor == "Green")
                {
                    if (player.IsPlaying == true)
                    {
                        player2.IsPlaying = true;
                    }

                    if (player is KeyboardPlayer)
                    {
                        player2.Keyboard = true;
                    }
                    else if (player is ControllerPlayer)
                    {
                        player2.Controller = true;
                    }


                    if (player.IsAlive == true)
                    {
                        player2.IsAlive = true;
                    }

                    if (player.CanGunAttack == true)
                    {
                        player2.CanGunAttack = true;
                    }
                }
                else if (player.StrColor == "Blue")
                {
                    if (player.IsPlaying == true)
                    {
                        player3.IsPlaying = true;
                    }

                    if (player is KeyboardPlayer)
                    {
                        player3.Keyboard = true;
                    }
                    else if (player is ControllerPlayer)
                    {
                        player3.Controller = true;
                    }


                    if (player.IsAlive == true)
                    {
                        player3.IsAlive = true;
                    }

                    if (player.CanGunAttack == true)
                    {
                        player3.CanGunAttack = true;
                    }
                }
                else
                {
                    if (player.IsPlaying == true)
                    {
                        player4.IsPlaying = true;
                    }

                    if (player is KeyboardPlayer)
                    {
                        player4.Keyboard = true;
                    }
                    else if (player is ControllerPlayer)
                    {
                        player4.Controller = true;
                    }


                    if (player.IsAlive == true)
                    {
                        player4.IsAlive = true;
                    }

                    if (player.CanGunAttack == true)
                    {
                        player4.CanGunAttack = true;
                    }
                }
            }



            #region 플레이어 상태창 업데이트-------------------------

            if (!player1.IsPlaying)
            {
                statusBox1.Image = Properties.Resources.NoPlayer;
            }
            else if (!player1.IsAlive)
            {
                statusBox1.Image = Properties.Resources.redDead;
            }
            else
            {
                if (!player1.Keyboard)
                {
                    if (!player1.CanGunAttack)
                    {
                        statusBox1.Image = Properties.Resources.redPad2;
                    }
                    else
                    {
                        statusBox1.Image = Properties.Resources.redPad1;
                    }
                }
                else
                {
                    if (!player1.CanGunAttack)
                    {
                        statusBox1.Image = Properties.Resources.redKey2;
                    }
                    else
                    {
                        statusBox1.Image = Properties.Resources.redKey1;
                    }
                }
            }

            if (!player2.IsPlaying)
            {
                statusBox2.Image = Properties.Resources.NoPlayer;
            }
            else if (!player2.IsAlive)
            {
                statusBox2.Image = Properties.Resources.greenDead;
            }
            else
            {
                if (!player2.Keyboard)
                {
                    if (!player2.CanGunAttack)
                    {
                        statusBox2.Image = Properties.Resources.greenPad2;
                    }
                    else
                    {
                        statusBox2.Image = Properties.Resources.greenPad1;
                    }
                }
                else
                {
                    if (!player2.CanGunAttack)
                    {
                        statusBox2.Image = Properties.Resources.greenKey2;
                    }
                    else
                    {
                        statusBox2.Image = Properties.Resources.greenKey1;
                    }
                }
            }

            if (!player3.IsPlaying)
            {
                statusBox3.Image = Properties.Resources.NoPlayer;
            }
            else if (!player3.IsAlive)
            {
                statusBox3.Image = Properties.Resources.blueDead;
            }
            else
            {
                if (!player3.Keyboard)
                {
                    if (!player3.CanGunAttack)
                    {
                        statusBox3.Image = Properties.Resources.bluePad2;
                    }
                    else
                    {
                        statusBox3.Image = Properties.Resources.bluePad1;
                    }
                }
                else
                {
                    if (!player3.CanGunAttack)
                    {
                        statusBox3.Image = Properties.Resources.blueKey2;
                    }
                    else
                    {
                        statusBox3.Image = Properties.Resources.blueKey1;
                    }
                }
            }

            if (!player4.IsPlaying)
            {
                statusBox4.Image = Properties.Resources.NoPlayer;
            }
            else if (!player4.IsAlive)
            {
                statusBox4.Image = Properties.Resources.yellowDead;
            }
            else
            {
                if (!player4.Keyboard)
                {
                    if (!player4.CanGunAttack)
                    {
                        statusBox4.Image = Properties.Resources.yellowPad2;
                    }
                    else
                    {
                        statusBox4.Image = Properties.Resources.yellowPad1;
                    }
                }
                else
                {
                    if (!player4.CanGunAttack)
                    {
                        statusBox4.Image = Properties.Resources.yellowKey2;
                    }
                    else
                    {
                        statusBox4.Image = Properties.Resources.yellowKey1;
                    }
                }
            }
            #endregion
        }



        #endregion

        public void CloseForm()
        {
            this.Close();
            this.Dispose();
        }
    }

    public struct PlayerInfo
    {
        public bool IsPlaying;
        public bool Keyboard;
        public bool Controller;

        public int Qudrant;
        public string Color;

        public PlayerKeys PlayerKeys;
        public Gamepad? Gamepad;

    }

    public struct PlayerKeys
    {
        public Keys Up;
        public Keys Down;
        public Keys Left;
        public Keys Right;
        public Keys Run;
        public Keys Aim;
        public Keys Attack;

    }

    public struct PlayerStatus
    {
        public bool IsPlaying;
        public bool Keyboard;
        public bool Controller;

        public bool IsAlive;
        public bool CanGunAttack;
    }

    public class KeyNone
    {
        public static PlayerKeys None = new PlayerKeys()
        {
            Up = Keys.None,
            Down = Keys.None,
            Left = Keys.None,
            Right = Keys.None,
            Run = Keys.None,
            Aim = Keys.None,
            Attack = Keys.None,
        };
    }

    public class InfoNone
    {
        public static PlayerInfo None = new PlayerInfo()
        {
            IsPlaying = false,
            Keyboard = false,
            Controller = false,

            Qudrant = 0,
            Color = "Grey",

            PlayerKeys = KeyNone.None,
            Gamepad = null,
        };
    }

    public class KeyOneTwo
    {
        public static PlayerKeys One = new PlayerKeys()
        {
            Up = Keys.Up,
            Down = Keys.Down,
            Left = Keys.Left,
            Right = Keys.Right,
            Run = Keys.OemQuestion,
            Aim = Keys.Oemcomma,
            Attack = Keys.OemPeriod,
        };

        public static PlayerKeys Two = new PlayerKeys()
        {
            Up = Keys.W,
            Down = Keys.S,
            Left = Keys.A,
            Right = Keys.D,
            Run = Keys.R,
            Aim = Keys.Y,
            Attack = Keys.T,
        };
    }




    public class Player
    {
        #region 필수 필드 ---------------------------------------
        protected Size resolution;

        protected Size mapSize;

        protected bool isPlaying = false;


        public bool IsPlaying { get { return isPlaying; } }

        protected bool isAlive = true;

        public bool IsAlive { get { return isAlive; } }

        protected bool isGameStarted = false;

        protected int qudrant = 0;

        protected Size characterSize;
        protected Size attackRangeSize;
        protected Size aimerSize;

        protected string strColor;
        public string StrColor { get { return strColor; } }

        protected Color color = Color.Gray; //Player Color

        protected Color StrToColor(string str)
        {
            if (str == "Red")
            {
                return Color.Red;
            }
            else if (str == "Green")
            {
                return Color.Green;
            }
            else if (str == "Blue")
            {
                return Color.Blue;
            }
            else if (str == "Yellow")
            {
                return Color.Yellow;
            }
            else
            {
                return Color.Gray;
            }
        }


        protected Control.ControlCollection Controls;

        public Label Cooltime { get; set; }

        #endregion

        #region 플레이 관련 필드 --------------------------------

        private const int startCool = 5;
        private int nowStartCool = startCool;

        protected Point nowPosition;
        protected Point nowAimer1Position;
        protected Point nowAimer2Position;
        protected Point nowAimer3Position;
        protected Point nowAimer4Position;

        protected int sizeOfAimer;

        private const int moveSpeed = 1;

        protected bool isMovingL = false;
        protected bool isMovingR = false;
        protected bool isMovingU = false;
        protected bool isMovingD = false;
        protected bool isRunning = false;
        protected bool isAiming = false;


        private bool canAttack = true;
        private const int attackCooltime = 10; //sec
        private int attackCooldown = 0;
        private int attackCooltick = 0;

        private int attackRange;

        private bool canGunAttack = true;
        public bool CanGunAttack { get { return canGunAttack; } }

        private bool bulletSizeBigger = true;

        #endregion

        #region 캐릭터 크기 계산-------------------------

        protected void calcSize()
        {
            this.mapSize = new Size(this.resolution.Width, this.resolution.Height - 124);

            this.characterSize = new Size((int)(this.resolution.Width * (30.0 / 1280.0)), (int)(this.resolution.Width * (30.0 / 1280.0)));
            this.sizeOfAimer = this.characterSize.Width / 2;
            this.attackRange = this.characterSize.Width * 2;
            this.attackRangeSize = new Size(attackRange, attackRange);
            this.aimerSize = new Size(sizeOfAimer, sizeOfAimer);
        }

        #endregion

        #region 생성자 및 게임 시작 이벤트-----------------------

        protected void StartingTimer_Tick(object? sender, EventArgs e)
        {
            nowStartCool--;
            EditStartCoolLabel(nowStartCool);

            if (nowStartCool == -1)
            {
                EndStartingTimer();
            }
        }

        protected void EndStartingTimer()
        {
            this.isGameStarted = true;

            this.startingTimer.Enabled = false;
            this.startingTimer.Tick -= StartingTimer_Tick;

            RemoveControl(this.Controls, playerQudrant);
            RemoveControl(this.Controls, startCoolLabel);
        }
        #endregion

        #region 컨트롤 추가 및 제거 -----------------------------
        public void AddControl(Control.ControlCollection Controls, Control Obj)
        {
            Controls.Add(Obj);
        }

        public void RemoveControl(Control.ControlCollection Controls, Control Obj)
        {
            Obj.Dispose();
            Controls.Remove(Obj);
        }
        #endregion


        #region 타이머 및 컨트롤 --------------------------------
        protected System.Windows.Forms.Timer startingTimer = new System.Windows.Forms.Timer();
        protected System.Windows.Forms.Timer attackTimer = new System.Windows.Forms.Timer()
        {
            Enabled = true,
            Interval = 100,
        };
        protected System.Windows.Forms.Timer bulletTimer = new System.Windows.Forms.Timer()
        {
            Enabled = true,
            Interval = 3,
        };

        protected PictureBox playerObj = new PictureBox()
        {
            BackColor = Color.Orange,
            Visible = true,
        };

        protected PictureBox playerAttackRange = new PictureBox()
        {
            BackColor = Color.Black,
            Visible = false,
        };

        protected PictureBox bullet = new PictureBox()
        {
            Size = new Size(10, 10),
            BackColor = Color.Black,
            Visible = false,
        };

        protected PictureBox playerAimer1 = new PictureBox()
        {
            Visible = false,
        };
        protected PictureBox playerAimer2 = new PictureBox()
        {
            Visible = false,
        };
        protected PictureBox playerAimer3 = new PictureBox()
        {
            Visible = false,
        };
        protected PictureBox playerAimer4 = new PictureBox()
        {
            Visible = false,
        };

        protected PictureBox playerQudrant = new PictureBox()
        {
            Visible = true,
        };

        protected Label startCoolLabel = new Label()
        {
            Size = new Size(30, 30),
            Text = Convert.ToString(startCool),
            Visible = true,
            Font = new Font("맑은 고딕", 15F, FontStyle.Regular, GraphicsUnit.Point),
            Location = new Point(10, 10),
            Enabled = true,
            AutoSize = true,
        };
        #endregion


        #region 컨트롤 위치 설정 메서드--------------------------
        private void SetPosition(Control control, Point point)
        {
            control.Location = point;
        }
        protected void SetPlayerPosition(Point point)
        {
            SetPosition(this.playerObj, point);
            SetPosition(this.playerAttackRange, new Point(point.X - this.characterSize.Width / 2, point.Y - this.characterSize.Width / 2));

            SetPosition(this.playerAimer1, new Point(point.X + this.characterSize.Width * 2 - sizeOfAimer, point.Y - this.characterSize.Width));
            SetPosition(this.playerAimer2, new Point(point.X - this.characterSize.Width, point.Y - this.characterSize.Width));
            SetPosition(this.playerAimer3, new Point(point.X - this.characterSize.Width, point.Y + this.characterSize.Width * 2 - sizeOfAimer));
            SetPosition(this.playerAimer4, new Point(point.X + this.characterSize.Width * 2 - sizeOfAimer, point.Y + this.characterSize.Width * 2 - sizeOfAimer));
        }
        protected void SetQudrant()
        {
            this.playerQudrant.BackColor = this.color;
            if (this.qudrant == 1)
            {
                this.playerQudrant.Location = new Point(this.mapSize.Width / 2, 0);
            }
            else if (this.qudrant == 2)
            {
                this.playerQudrant.Location = new Point(0, 0);
            }
            else if (this.qudrant == 3)
            {
                this.playerQudrant.Location = new Point(0, this.mapSize.Height / 2);
            }
            else
            {
                this.playerQudrant.Location = new Point(this.mapSize.Width / 2, this.mapSize.Height / 2);
            }
        }

        protected Point RandomPoint()
        {
            int x, y;
            Random rand = new Random();

            if (this.qudrant == 1)
            {
                x = rand.Next(this.mapSize.Width / 2 + this.characterSize.Width / 2, this.mapSize.Width - (int)(this.characterSize.Width * 1.5) + 1);
                y = rand.Next(this.characterSize.Width / 2, this.mapSize.Height / 2 - (int)(this.characterSize.Height * 1.5) + 1);
            }
            else if (this.qudrant == 2)
            {
                x = rand.Next(this.characterSize.Width / 2, this.mapSize.Width / 2 - (int)(this.characterSize.Width * 1.5) + 1);
                y = rand.Next(this.characterSize.Width / 2, this.mapSize.Height / 2 - (int)(this.characterSize.Width * 1.5) + 1);
            }
            else if (this.qudrant == 3)
            {
                x = rand.Next(this.characterSize.Width / 2, this.mapSize.Width / 2 - (int)(this.characterSize.Width * 1.5) + 1);
                y = rand.Next(this.mapSize.Height / 2 + this.characterSize.Width / 2, this.mapSize.Height - (int)(this.characterSize.Width * 1.5) + 1);
            }
            else
            {
                x = rand.Next(this.mapSize.Width / 2 + this.characterSize.Width / 2, this.mapSize.Width - (int)(this.characterSize.Width * 1.5) + 1);
                y = rand.Next(this.mapSize.Height / 2 + this.characterSize.Width / 2, this.mapSize.Height - (int)(this.characterSize.Width * 1.5) + 1);
            }

            return new Point(x, y);
        }
        protected Point StartLabelPoint()
        {
            int x, y;

            if (this.qudrant == 1)
            {
                x = this.mapSize.Width / 2 + 10;
                y = 10;
            }
            else if (this.qudrant == 2)
            {
                x = 10;
                y = 10;
            }
            else if (this.qudrant == 3)
            {
                x = 10;
                y = this.mapSize.Height / 2 + 10;
            }
            else
            {
                x = this.mapSize.Width / 2 + 10;
                y = this.mapSize.Height / 2 + 10;
            }

            return new Point(x, y);
        }
        protected void SetStartLabelPosition(Point point)
        {
            this.startCoolLabel.Location = point;
        }

        #endregion


        #region 레이블 수정 -------------------------------------

        private void EditLable(Label label, int elem)
        {
            label.Text = Convert.ToString(elem);
        }

        private void EditStartCoolLabel(int elem)
        {
            EditLable(this.startCoolLabel, elem);
        }

        #endregion

        #region 이동 --------------------------------------------

        public void Move()
        {
            if (this.isPlaying == true && this.isAlive == true)
            {
                if (this.isAiming == false)
                {
                    if (this.isRunning == false)
                    {
                        if (isMovingU == true)
                        {
                            this.nowPosition.Y -= moveSpeed;
                        }
                        if (isMovingD == true)
                        {
                            this.nowPosition.Y += moveSpeed;
                        }
                        if (isMovingL == true)
                        {
                            this.nowPosition.X -= moveSpeed;
                        }
                        if (isMovingR == true)
                        {
                            this.nowPosition.X += moveSpeed;
                        }



                    }
                    else
                    {
                        if (isMovingU == true)
                        {
                            this.nowPosition.Y -= moveSpeed * 3;
                        }
                        if (isMovingD == true)
                        {
                            this.nowPosition.Y += moveSpeed * 3;
                        }
                        if (isMovingL == true)
                        {
                            this.nowPosition.X -= moveSpeed * 3;
                        }
                        if (isMovingR == true)
                        {
                            this.nowPosition.X += moveSpeed * 3;
                        }
                    }

                    if (this.nowPosition.X < 0)
                    {
                        this.nowPosition.X = 0;
                    }
                    else if (this.nowPosition.X > this.mapSize.Width - this.characterSize.Width)
                    {
                        this.nowPosition.X = this.mapSize.Width - this.characterSize.Width;
                    }

                    if (this.nowPosition.Y < 0)
                    {
                        this.nowPosition.Y = 0;
                    }
                    else if (this.nowPosition.Y > this.mapSize.Height - this.characterSize.Width)
                    {
                        this.nowPosition.Y = this.mapSize.Height - this.characterSize.Width;
                    }

                    this.nowAimer1Position = new Point(this.nowPosition.X + this.characterSize.Width * 2 - sizeOfAimer, this.nowPosition.Y - this.characterSize.Width);
                    this.nowAimer2Position = new Point(this.nowPosition.X - this.characterSize.Width, this.nowPosition.Y - this.characterSize.Width);
                    this.nowAimer3Position = new Point(this.nowPosition.X - this.characterSize.Width, this.nowPosition.Y + this.characterSize.Width * 2 - sizeOfAimer);
                    this.nowAimer4Position = new Point(this.nowPosition.X + this.characterSize.Width * 2 - sizeOfAimer, this.nowPosition.Y + this.characterSize.Width * 2 - sizeOfAimer);

                    SetPlayerPosition(this.nowPosition);
                }
                else
                {
                    if (isMovingU == true)
                    {
                        this.nowAimer1Position.Y -= moveSpeed * 4;
                        this.nowAimer2Position.Y -= moveSpeed * 4;
                        this.nowAimer3Position.Y -= moveSpeed * 4;
                        this.nowAimer4Position.Y -= moveSpeed * 4;

                    }
                    if (isMovingD == true)
                    {
                        this.nowAimer1Position.Y += moveSpeed * 4;
                        this.nowAimer2Position.Y += moveSpeed * 4;
                        this.nowAimer3Position.Y += moveSpeed * 4;
                        this.nowAimer4Position.Y += moveSpeed * 4;
                    }
                    if (isMovingL == true)
                    {
                        this.nowAimer1Position.X -= moveSpeed * 4;
                        this.nowAimer2Position.X -= moveSpeed * 4;
                        this.nowAimer3Position.X -= moveSpeed * 4;
                        this.nowAimer4Position.X -= moveSpeed * 4;
                    }
                    if (isMovingR == true)
                    {
                        this.nowAimer1Position.X += moveSpeed * 4;
                        this.nowAimer2Position.X += moveSpeed * 4;
                        this.nowAimer3Position.X += moveSpeed * 4;
                        this.nowAimer4Position.X += moveSpeed * 4;
                    }

                    SetPosition(this.playerAimer1, this.nowAimer1Position);
                    SetPosition(this.playerAimer2, this.nowAimer2Position);
                    SetPosition(this.playerAimer3, this.nowAimer3Position);
                    SetPosition(this.playerAimer4, this.nowAimer4Position);
                }
            }
        }

        #endregion

        #region 플레이어 죽음---------------------------------------
        public void PlayerDeath(Control.ControlCollection Controls)
        {
            this.isAlive = false;
            RemoveControl(Controls, playerObj);
            RemoveControl(Controls, playerAttackRange);
            RemoveControl(Controls, playerAimer1);
            RemoveControl(Controls, playerAimer2);
            RemoveControl(Controls, playerAimer3);
            RemoveControl(Controls, playerAimer4);
        }

        #endregion

        #region 공격 -----------------------------------------------

        public void Attack(Control.ControlCollection Controls, List<Player> players, List<Dummy> dummies, Form1 form1, List<PictureBox> statusBox)//
        {
            if (this.isPlaying == true && this.isAlive == true && this.isGameStarted == true && this.canAttack == true)
            {
                if (this.isAiming == false) //근거리 공격
                {

                    #region 공격 쿨타임 및 이펙트 -------------------------
                    this.playerAttackRange.Visible = true;

                    this.attackCooldown = attackCooltime;
                    this.canAttack = false;

                    this.attackTimer.Start();
                    this.attackTimer.Tick += AttackTimer_Tick;

                    this.Cooltime.Text = Convert.ToString(this.attackCooldown);

                    #endregion

                    #region 공격 효과 -------------------------

                    int thisPosX = this.playerAttackRange.Location.X;
                    int thisPosY = this.playerAttackRange.Location.Y;


                    foreach (Player player in players)
                    {

                        int thatPosX = player.playerObj.Location.X;
                        int thatPosY = player.playerObj.Location.Y;

                        if (thatPosX > thisPosX - this.characterSize.Width && thatPosX < thisPosX + attackRange &&
                            thatPosY > thisPosY - this.characterSize.Width && thatPosY < thisPosY + attackRange &&
                            player != this)
                        {
                            player.PlayerDeath(Controls);
                        }
                    }

                    foreach (Dummy dummy in dummies)
                    {

                        int thatPosX = dummy.dummyObj.Location.X;
                        int thatPosY = dummy.dummyObj.Location.Y;

                        if (thatPosX > thisPosX - this.characterSize.Width && thatPosX < thisPosX + attackRange &&
                            thatPosY > thisPosY - this.characterSize.Width && thatPosY < thisPosY + attackRange)
                        {
                            dummy.DummyDeath(Controls);
                        }
                    }



                    #endregion


                }
                else //원거리 공격
                {
                    if (this.canGunAttack == true)
                    {

                        #region 공격 이펙트-----------------------------------------
                        this.playerObj.BackColor = this.color;

                        this.canGunAttack = false;

                        this.bullet.Visible = true;
                        SetPosition(this.bullet, new Point(this.playerAimer2.Location.X + (int)(this.characterSize.Width * 1.5) - 5, this.playerAimer2.Location.Y + (int)(this.characterSize.Width * 1.5) - 5));
                        AddControl(Controls, this.bullet);

                        this.bulletTimer.Start();
                        this.bulletTimer.Tick += BulletTimer_Tick;
                        #endregion


                        #region 공격 효과-----------------------------------
                        int thisPosX = this.playerAimer2.Location.X;
                        int thisPosY = this.playerAimer2.Location.Y;

                        foreach (Player player in players)
                        {

                            int thatPosX = player.playerObj.Location.X;
                            int thatPosY = player.playerObj.Location.Y;

                            if (thatPosX > thisPosX - this.characterSize.Width && thatPosX < thisPosX + this.characterSize.Width * 3 &&
                                thatPosY > thisPosY - this.characterSize.Width && thatPosY < thisPosY + this.characterSize.Width * 3 &&
                                player != this)
                            {
                                player.PlayerDeath(Controls);
                            }
                        }

                        foreach (Dummy dummy in dummies)
                        {

                            int thatPosX = dummy.dummyObj.Location.X;
                            int thatPosY = dummy.dummyObj.Location.Y;

                            if (thatPosX > thisPosX - this.characterSize.Width && thatPosX < thisPosX + this.characterSize.Width * 3 &&
                                thatPosY > thisPosY - this.characterSize.Width && thatPosY < thisPosY + this.characterSize.Width * 3)
                            {
                                dummy.DummyDeath(Controls);
                            }
                        }
                        #endregion
                    }
                }

                PictureBox statusBox1 = statusBox[0];
                PictureBox statusBox2 = statusBox[1];
                PictureBox statusBox3 = statusBox[2];
                PictureBox statusBox4 = statusBox[3];

                UpdatePlayerCondition(statusBox1, statusBox2, statusBox3, statusBox4, players);

                // *필수* 게임오버체크
                int aliveCnt = 0;

                foreach (Player player in players)
                {
                    if(player.isPlaying == true && player.isAlive == true && player != this)
                    {
                        aliveCnt++;
                    }
                }

                if(aliveCnt == 0)
                {
                    foreach (Dummy dummy in dummies)
                    {
                        dummy.DummyDeath(Controls);
                    }


                    Form2 form2 = new Form2();

                    form2.form1 = form1;
                    form2.WinnerColor = this.strColor;
                    form2.ShowDialog();
                }
            }
        }

        private void BulletTimer_Tick(object? sender, EventArgs e)
        {
            if (this.bulletSizeBigger == true)
            {
                this.bullet.Size = new Size(this.bullet.Width + 2, this.bullet.Height + 2);
                this.bullet.Location = new Point(this.bullet.Location.X - 1, this.bullet.Location.Y - 1);

                if (this.bullet.Width > this.characterSize.Width * 3)
                {
                    this.bulletSizeBigger = false;
                }
            }
            else
            {
                this.bullet.Size = new Size(this.bullet.Width - 2, this.bullet.Height - 2);
                this.bullet.Location = new Point(this.bullet.Location.X + 1, this.bullet.Location.Y + 1);

                if (this.bullet.Width < 10)
                {
                    this.playerObj.BackColor = Color.Orange;
                    RemoveControl(Controls, this.bullet);

                    this.bulletTimer.Stop();
                    this.bulletTimer.Tick -= BulletTimer_Tick;
                }
            }
        }

        private void AttackTimer_Tick(object? sender, EventArgs e)
        {
            this.attackCooltick++;

            if (this.attackCooltick == 2)
            {
                this.playerAttackRange.Visible = false;
            }
            else if (this.attackCooltick % 10 == 0)
            {
                this.attackCooldown--;

                this.Cooltime.Text = Convert.ToString(this.attackCooldown);
                if (attackCooldown == 0)
                {
                    this.attackCooltick = 0;

                    this.canAttack = true;
                    this.attackTimer.Stop();
                    this.attackTimer.Tick -= AttackTimer_Tick;
                }
            }

        }

        #endregion




        #region 상태창 --------------------------------------
        private void UpdatePlayerCondition(PictureBox statusBox1, PictureBox statusBox2, PictureBox statusBox3, PictureBox statusBox4, List<Player> players)
        {
            PlayerStatus AllFalse = new PlayerStatus()
            {
                IsPlaying = false,
                Keyboard = false,
                Controller = false,
                IsAlive = false,
                CanGunAttack = false,
            };

            PlayerStatus player1 = AllFalse;
            PlayerStatus player2 = AllFalse;
            PlayerStatus player3 = AllFalse;
            PlayerStatus player4 = AllFalse;

            foreach (Player player in players)
            {
                if (player.StrColor == "Red")
                {
                    if (player.IsPlaying == true)
                    {
                        player1.IsPlaying = true;
                    }

                    if (player is KeyboardPlayer)
                    {
                        player1.Keyboard = true;
                    }
                    else if (player is ControllerPlayer)
                    {
                        player1.Controller = true;
                    }


                    if (player.IsAlive == true)
                    {
                        player1.IsAlive = true;
                    }

                    if (player.CanGunAttack == true)
                    {
                        player1.CanGunAttack = true;
                    }
                }
                else if (player.StrColor == "Green")
                {
                    if (player.IsPlaying == true)
                    {
                        player2.IsPlaying = true;
                    }

                    if (player is KeyboardPlayer)
                    {
                        player2.Keyboard = true;
                    }
                    else if (player is ControllerPlayer)
                    {
                        player2.Controller = true;
                    }


                    if (player.IsAlive == true)
                    {
                        player2.IsAlive = true;
                    }

                    if (player.CanGunAttack == true)
                    {
                        player2.CanGunAttack = true;
                    }
                }
                else if (player.StrColor == "Blue")
                {
                    if (player.IsPlaying == true)
                    {
                        player3.IsPlaying = true;
                    }

                    if (player is KeyboardPlayer)
                    {
                        player3.Keyboard = true;
                    }
                    else if (player is ControllerPlayer)
                    {
                        player3.Controller = true;
                    }


                    if (player.IsAlive == true)
                    {
                        player3.IsAlive = true;
                    }

                    if (player.CanGunAttack == true)
                    {
                        player3.CanGunAttack = true;
                    }
                }
                else
                {
                    if (player.IsPlaying == true)
                    {
                        player4.IsPlaying = true;
                    }

                    if (player is KeyboardPlayer)
                    {
                        player4.Keyboard = true;
                    }
                    else if (player is ControllerPlayer)
                    {
                        player4.Controller = true;
                    }


                    if (player.IsAlive == true)
                    {
                        player4.IsAlive = true;
                    }

                    if (player.CanGunAttack == true)
                    {
                        player4.CanGunAttack = true;
                    }
                }
            }



            #region 플레이어 상태창 업데이트-------------------------

            if (!player1.IsPlaying)
            {
                statusBox1.Image = Properties.Resources.NoPlayer;
            }
            else if (!player1.IsAlive)
            {
                statusBox1.Image = Properties.Resources.redDead;
            }
            else
            {
                if (!player1.Keyboard)
                {
                    if (!player1.CanGunAttack)
                    {
                        statusBox1.Image = Properties.Resources.redPad2;
                    }
                    else
                    {
                        statusBox1.Image = Properties.Resources.redPad1;
                    }
                }
                else
                {
                    if (!player1.CanGunAttack)
                    {
                        statusBox1.Image = Properties.Resources.redKey2;
                    }
                    else
                    {
                        statusBox1.Image = Properties.Resources.redKey1;
                    }
                }
            }

            if (!player2.IsPlaying)
            {
                statusBox2.Image = Properties.Resources.NoPlayer;
            }
            else if (!player2.IsAlive)
            {
                statusBox2.Image = Properties.Resources.greenDead;
            }
            else
            {
                if (!player2.Keyboard)
                {
                    if (!player2.CanGunAttack)
                    {
                        statusBox2.Image = Properties.Resources.greenPad2;
                    }
                    else
                    {
                        statusBox2.Image = Properties.Resources.greenPad1;
                    }
                }
                else
                {
                    if (!player2.CanGunAttack)
                    {
                        statusBox2.Image = Properties.Resources.greenKey2;
                    }
                    else
                    {
                        statusBox2.Image = Properties.Resources.greenKey1;
                    }
                }
            }

            if (!player3.IsPlaying)
            {
                statusBox3.Image = Properties.Resources.NoPlayer;
            }
            else if (!player3.IsAlive)
            {
                statusBox3.Image = Properties.Resources.blueDead;
            }
            else
            {
                if (!player3.Keyboard)
                {
                    if (!player3.CanGunAttack)
                    {
                        statusBox3.Image = Properties.Resources.bluePad2;
                    }
                    else
                    {
                        statusBox3.Image = Properties.Resources.bluePad1;
                    }
                }
                else
                {
                    if (!player3.CanGunAttack)
                    {
                        statusBox3.Image = Properties.Resources.blueKey2;
                    }
                    else
                    {
                        statusBox3.Image = Properties.Resources.blueKey1;
                    }
                }
            }

            if (!player4.IsPlaying)
            {
                statusBox4.Image = Properties.Resources.NoPlayer;
            }
            else if (!player4.IsAlive)
            {
                statusBox4.Image = Properties.Resources.yellowDead;
            }
            else
            {
                if (!player4.Keyboard)
                {
                    if (!player4.CanGunAttack)
                    {
                        statusBox4.Image = Properties.Resources.yellowPad2;
                    }
                    else
                    {
                        statusBox4.Image = Properties.Resources.yellowPad1;
                    }
                }
                else
                {
                    if (!player4.CanGunAttack)
                    {
                        statusBox4.Image = Properties.Resources.yellowKey2;
                    }
                    else
                    {
                        statusBox4.Image = Properties.Resources.yellowKey1;
                    }
                }
            }
            #endregion
        }

        #endregion
    }

    public class KeyboardPlayer : Player
    {
        private PlayerKeys playerKeys;

        #region 생성자 ---------------------------------------------
        public KeyboardPlayer(Control.ControlCollection Controls, Size resolution, bool isPlaying, int qudrant, string color, PlayerKeys playerKeys)
        {
            base.Controls = Controls;
            base.resolution = resolution;
            base.isPlaying = isPlaying;
            base.strColor = color;
            base.color = StrToColor(color);
            base.qudrant = qudrant;

            base.calcSize();

            if (base.isPlaying == true)
            {
                this.playerKeys = playerKeys;

                base.playerAimer1.BackColor = base.color;
                base.playerAimer2.BackColor = base.color;
                base.playerAimer3.BackColor = base.color;
                base.playerAimer4.BackColor = base.color;

                base.nowPosition = RandomPoint();
                base.nowAimer1Position = new Point(base.nowPosition.X + this.characterSize.Width * 2 - sizeOfAimer, base.nowPosition.Y - this.characterSize.Width);
                base.nowAimer2Position = new Point(base.nowPosition.X - this.characterSize.Width, base.nowPosition.Y - this.characterSize.Width);
                base.nowAimer3Position = new Point(base.nowPosition.X - this.characterSize.Width, base.nowPosition.Y + this.characterSize.Width * 2 - sizeOfAimer);
                base.nowAimer4Position = new Point(base.nowPosition.X + this.characterSize.Width * 2 - sizeOfAimer, base.nowPosition.Y + this.characterSize.Width * 2 - sizeOfAimer);

                SetPlayerPosition(base.nowPosition);

                AddControl(Controls, base.playerObj);
                base.playerObj.Size = base.characterSize;
                AddControl(Controls, base.playerAttackRange);
                base.playerAttackRange.Size = base.attackRangeSize;
                AddControl(Controls, base.playerAimer1);
                base.playerAimer1.Size = base.aimerSize;
                AddControl(Controls, base.playerAimer2);
                base.playerAimer2.Size = base.aimerSize;
                AddControl(Controls, base.playerAimer3);
                base.playerAimer3.Size = base.aimerSize;
                AddControl(Controls, base.playerAimer4);
                base.playerAimer4.Size = base.aimerSize;


                SetStartLabelPosition(StartLabelPoint());
                AddControl(Controls, base.startCoolLabel);

                SetQudrant();
                AddControl(Controls, base.playerQudrant);
                base.playerQudrant.Size = new Size(base.mapSize.Width / 2, base.mapSize.Height / 2);

                base.startingTimer.Enabled = true;
                base.startingTimer.Interval = 1000;
                base.startingTimer.Tick += StartingTimer_Tick;


            }
        }
        #endregion


        #region 키보드 체크 ----------------------------------------
        public void KeyDownCheck(KeyEventArgs e, List<Player> players, List<Dummy> dummies, Form1 form1, List<PictureBox> statusBox)
        {
            if (e.KeyCode == this.playerKeys.Up)
            {
                base.isMovingU = true;
            }
            if (e.KeyCode == this.playerKeys.Down)
            {
                base.isMovingD = true;
            }
            if (e.KeyCode == this.playerKeys.Left)
            {
                base.isMovingL = true;
            }
            if (e.KeyCode == this.playerKeys.Right)
            {
                base.isMovingR = true;
            }
            if (e.KeyCode == this.playerKeys.Run)
            {
                base.isRunning = true;
            }
            if (e.KeyCode == this.playerKeys.Aim)
            {
                base.isAiming = true;
                base.playerAimer1.Visible = true;
                base.playerAimer2.Visible = true;
                base.playerAimer3.Visible = true;
                base.playerAimer4.Visible = true;
            }
            if (e.KeyCode == this.playerKeys.Attack)
            {
                base.Attack(base.Controls, players, dummies,form1, statusBox);
            }
        }
        public void KeyUpCheck(KeyEventArgs e)
        {
            if (e.KeyCode == this.playerKeys.Up)
            {
                base.isMovingU = false;
            }
            if (e.KeyCode == this.playerKeys.Down)
            {
                base.isMovingD = false;
            }
            if (e.KeyCode == this.playerKeys.Left)
            {
                base.isMovingL = false;
            }
            if (e.KeyCode == this.playerKeys.Right)
            {
                base.isMovingR = false;
            }
            if (e.KeyCode == this.playerKeys.Run)
            {
                base.isRunning = false;
            }
            if (e.KeyCode == this.playerKeys.Aim)
            {
                base.isAiming = false;
                base.playerAimer1.Visible = false;
                base.playerAimer2.Visible = false;
                base.playerAimer3.Visible = false;
                base.playerAimer4.Visible = false;
            }
        }
        #endregion
    }

    public class ControllerPlayer : Player
    {
        private Gamepad gamepad;

        private GamepadReading reading;

        #region 생성자-----------------------------------------
        public ControllerPlayer(Control.ControlCollection Controls, Size resolution, bool isPlaying, int qudrant, string color, Gamepad gamepad)
        {
            base.Controls = Controls;
            base.resolution = resolution;
            base.isPlaying = isPlaying;
            base.strColor = color;
            base.color = StrToColor(color);
            base.qudrant = qudrant;

            base.calcSize();

            if (base.isPlaying == true)
            {
                this.gamepad = gamepad;

                base.playerAimer1.BackColor = base.color;
                base.playerAimer2.BackColor = base.color;
                base.playerAimer3.BackColor = base.color;
                base.playerAimer4.BackColor = base.color;

                base.nowPosition = RandomPoint();
                base.nowAimer1Position = new Point(base.nowPosition.X + this.characterSize.Width * 2 - sizeOfAimer, base.nowPosition.Y - this.characterSize.Width);
                base.nowAimer2Position = new Point(base.nowPosition.X - this.characterSize.Width, base.nowPosition.Y - this.characterSize.Width);
                base.nowAimer3Position = new Point(base.nowPosition.X - this.characterSize.Width, base.nowPosition.Y + this.characterSize.Width * 2 - sizeOfAimer);
                base.nowAimer4Position = new Point(base.nowPosition.X + this.characterSize.Width * 2 - sizeOfAimer, base.nowPosition.Y + this.characterSize.Width * 2 - sizeOfAimer);

                SetPlayerPosition(base.nowPosition);

                AddControl(Controls, base.playerObj);
                base.playerObj.Size = base.characterSize;
                AddControl(Controls, base.playerAttackRange);
                base.playerAttackRange.Size = base.attackRangeSize;
                AddControl(Controls, base.playerAimer1);
                base.playerAimer1.Size = base.aimerSize;
                AddControl(Controls, base.playerAimer2);
                base.playerAimer2.Size = base.aimerSize;
                AddControl(Controls, base.playerAimer3);
                base.playerAimer3.Size = base.aimerSize;
                AddControl(Controls, base.playerAimer4);
                base.playerAimer4.Size = base.aimerSize;


                SetStartLabelPosition(StartLabelPoint());
                AddControl(Controls, base.startCoolLabel);

                SetQudrant();
                AddControl(Controls, base.playerQudrant);
                base.playerQudrant.Size = new Size(base.mapSize.Width / 2, base.mapSize.Height / 2);

                base.startingTimer.Enabled = true;
                base.startingTimer.Interval = 1000;
                base.startingTimer.Tick += StartingTimer_Tick;
            }
        }

        #endregion

        #region 게임패드 체크 --------------------------------------

        private void GamepadCheck(List<Player> players, List<Dummy> dummies,Form1 form1, List<PictureBox> statusBox)
        {
            double leftStickX = this.reading.LeftThumbstickX;   // returns a value between -1.0 and +1.0
            double leftStickY = this.reading.LeftThumbstickY;   // returns a value between -1.0 and +1.0

            double leftTrigger = this.reading.LeftTrigger;  // Run
            double rightTrigger = this.reading.RightTrigger; // Attack

            if (leftStickX > 0.3)
            {
                base.isMovingR = true;
            }
            else if (leftStickX < -0.3)
            {
                base.isMovingL = true;
            }
            else
            {
                base.isMovingR = false;
                base.isMovingL = false;
            }

            if (leftStickY > 0.3)
            {
                base.isMovingU = true;
            }
            else if (leftStickY < -0.3)
            {
                base.isMovingD = true;
            }
            else
            {
                base.isMovingU = false;
                base.isMovingD = false;
            }

            if ((GamepadButtons.X == (reading.Buttons & GamepadButtons.X)) || (GamepadButtons.Y == (reading.Buttons & GamepadButtons.Y)))
            {
                base.isAiming = true;
                base.playerAimer1.Visible = true;
                base.playerAimer2.Visible = true;
                base.playerAimer3.Visible = true;
                base.playerAimer4.Visible = true;
            }

            if ((GamepadButtons.None == (reading.Buttons & GamepadButtons.X)) && (GamepadButtons.None == (reading.Buttons & GamepadButtons.Y)))
            {
                base.isAiming = false;
                base.playerAimer1.Visible = false;
                base.playerAimer2.Visible = false;
                base.playerAimer3.Visible = false;
                base.playerAimer4.Visible = false;
            }

            if (leftTrigger > 0.3)
            {
                this.isRunning = true;
            }
            else
            {
                this.isRunning = false;
            }

            if (rightTrigger > 0.3)
            {
                base.Attack(base.Controls, players, dummies, form1, statusBox);
            }

        }

        public void GamepadRead(List<Player> players, List<Dummy> dummies, Form1 form1, List<PictureBox> statusBox)
        {
            this.reading = this.gamepad.GetCurrentReading();

            this.GamepadCheck(players, dummies, form1,statusBox);
        }

        #endregion
    }

    public class Dummy
    {

        #region 필수 필드 -----------------------------------------------------
        private Control.ControlCollection Controls;
        private Size resolution;
        protected Size mapSize;
        private Size characterSize;

        private bool isAlive = true;

        public bool IsAlive { get { return isAlive; } }

        #endregion

        #region 움직임 관련 필드-----------------------------------------------
        private int patternType = 0; // 0.always random, 1. random per 1sec, 2. random per 2sec, 3. only L/R/U/D per 2sec.

        private bool isMovingL = false;
        private bool isMovingR = false;
        private bool isMovingU = false;
        private bool isMovingD = false;

        private int direction = 0;

        /*
        4   3   2          
        5       1
        6   7   8
         */

        private Point nowPosition;

        private const int moveSpeed = 1;
        #endregion

        #region 생성자 --------------------------------------------------------

        public Dummy(Control.ControlCollection Controls, Size resolution, int patternType)
        {
            this.Controls = Controls;
            this.resolution = resolution;

            this.characterSize = new Size((int)(this.resolution.Width * (30.0 / 1280.0)), (int)(this.resolution.Width * (30.0 / 1280.0)));
            this.mapSize = new Size(this.resolution.Width, this.resolution.Height - 124);


            this.patternType = patternType;

            nowPosition = RandomPoint();

            SetPosition(dummyObj, nowPosition);
            AddControl(Controls, dummyObj);
            dummyObj.Size = this.characterSize;

            Random rand = new Random();

            this.direction = rand.Next(1, 9);

        }

        #endregion

        #region 컨트롤 추가 및 제거 -------------------------------------------
        public void AddControl(Control.ControlCollection Controls, Control Obj)
        {
            Controls.Add(Obj);
        }

        public void RemoveControl(Control.ControlCollection Controls, Control Obj)
        {
            Obj.Dispose();
            Controls.Remove(Obj);
        }
        #endregion

        #region 타이머 및 컨트롤 ----------------------------------------------

        public PictureBox dummyObj = new PictureBox()
        {
            BackColor = Color.Orange,
            Visible = true,
        };

        #endregion

        #region 위치 설정 -----------------------------------------------------
        private void SetPosition(Control control, Point point)
        {
            control.Location = point;
        }

        private Point RandomPoint()
        {
            int x, y;
            Random rand = new Random();


            x = rand.Next(0, this.mapSize.Width - this.characterSize.Width + 1);
            y = rand.Next(0, this.mapSize.Height - this.characterSize.Width + 1);


            return new Point(x, y);
        }

        #endregion

        #region 방향 조정(패턴에 따른)------------------------------------------
        private void directionToBool(int direction)
        {
            if (direction == 1)
            {
                this.isMovingL = false;
                this.isMovingR = true;
                this.isMovingU = false;
                this.isMovingD = false;
            }
            else if (direction == 2)
            {
                this.isMovingL = false;
                this.isMovingR = true;
                this.isMovingU = true;
                this.isMovingD = false;
            }
            else if (direction == 3)
            {
                this.isMovingL = false;
                this.isMovingR = false;
                this.isMovingU = true;
                this.isMovingD = false;
            }
            else if (direction == 4)
            {
                this.isMovingL = true;
                this.isMovingR = false;
                this.isMovingU = true;
                this.isMovingD = false;
            }
            else if (direction == 5)
            {
                this.isMovingL = true;
                this.isMovingR = false;
                this.isMovingU = false;
                this.isMovingD = false;
            }
            else if (direction == 6)
            {
                this.isMovingL = true;
                this.isMovingR = false;
                this.isMovingU = false;
                this.isMovingD = true;
            }
            else if (direction == 7)
            {
                this.isMovingL = false;
                this.isMovingR = false;
                this.isMovingU = false;
                this.isMovingD = true;
            }
            else
            {
                this.isMovingL = false;
                this.isMovingR = true;
                this.isMovingU = false;
                this.isMovingD = true;
            }
        }

        private void randomDirection(bool diagonal)
        {
            Random rand = new Random();



            if (diagonal == true)
            {
                int tmp = rand.Next(0, 3); //0 ; left, 1,save, 1.right

                if (tmp == 0)
                {
                    this.direction++;
                }
                else if (tmp == 2)
                {
                    this.direction--;
                }

                this.direction += 9;
                this.direction %= 9;
            }
            else
            {
                int tmp = rand.Next(0, 4);

                this.direction = tmp * 2 + 1;
            }

        }

        private void chooseDirection(TimerTickRecoder maintick)
        {

            if (this.patternType == 0)
            {
                if (maintick.TotalTick % 5 == 0)
                {
                    randomDirection(true);
                }

            }
            else if (this.patternType == 1)
            {
                if (maintick.TotalTick % 100 == 0)
                {
                    randomDirection(true);
                }
            }
            else if (this.patternType == 2)
            {
                if (maintick.TotalTick % 200 == 0)
                {
                    randomDirection(true);
                }
            }
            else
            {
                if (maintick.TotalTick % 200 == 0)
                {
                    randomDirection(false);
                }
            }
        }

        #endregion


        #region 이동 -----------------------------------------------------------

        public void Move(TimerTickRecoder maintick)
        {
            chooseDirection(maintick);

            directionToBool(this.direction);
            if (isMovingU == true)
            {
                this.nowPosition.Y -= moveSpeed;
            }
            if (isMovingD == true)
            {
                this.nowPosition.Y += moveSpeed;
            }
            if (isMovingL == true)
            {
                this.nowPosition.X -= moveSpeed;
            }
            if (isMovingR == true)
            {
                this.nowPosition.X += moveSpeed;
            }

            if (this.nowPosition.X < 0)
            {
                this.nowPosition.X = 0;
                this.direction = 1;
                directionToBool(this.direction);
            }
            else if (this.nowPosition.X > this.mapSize.Width - this.characterSize.Width)
            {
                this.nowPosition.X = this.mapSize.Width - this.characterSize.Width;
                this.direction = 5;
                directionToBool(this.direction);
            }

            if (this.nowPosition.Y < 0)
            {
                this.nowPosition.Y = 0;
                this.direction = 7;
                directionToBool(this.direction);
            }
            else if (this.nowPosition.Y > this.mapSize.Height - this.characterSize.Width)
            {
                this.nowPosition.Y = this.mapSize.Height - this.characterSize.Width;
                this.direction = 3;
                directionToBool(this.direction);
            }


            SetPosition(dummyObj, this.nowPosition);


        }

        #endregion

        #region 더미 죽음-------------------------------------------------------
        public void DummyDeath(Control.ControlCollection Controls)
        {
            this.isAlive = false;
            RemoveControl(Controls, this.dummyObj);
        }
        #endregion
    }
    public class GameManager
    {
        private PlayerInfo player1Info, player2Info, player3Info, player4Info;
        private string dummyPattern = "0"; // 0,1,2,3,Random

        private int dummyCount = 0;

        public PlayerInfo Player1Info { get { return player1Info; } }
        public PlayerInfo Player2Info { get { return player2Info; } }
        public PlayerInfo Player3Info { get { return player3Info; } }
        public PlayerInfo Player4Info { get { return player4Info; } }
        public string DummyPattern { get { return dummyPattern; } }
        public int DummyCount { get { return dummyCount; } }


        public GameManager()
        {
            player1Info = new PlayerInfo();
            player2Info = new PlayerInfo();
            player3Info = new PlayerInfo();
            player4Info = new PlayerInfo();
        }

        public void Player1Setting(PlayerInfo player1Setting)
        {
            player1Info = player1Setting;
        }

        public void Player2Setting(PlayerInfo player2Setting)
        {
            player2Info = player2Setting;
        }

        public void Player3Setting(PlayerInfo player3Setting)
        {
            player3Info = player3Setting;
        }

        public void Player4Setting(PlayerInfo player4Setting)
        {
            player4Info = player4Setting;
        }

        public void DummyPatternSetting(string dummyPattern)
        {
            this.dummyPattern = dummyPattern;
        }
        public void DummyCountSetting(int dummyCount)
        {
            this.dummyCount = dummyCount;
        }

    }
    public class ObjectManager
    {
        private Form1 form1;

        private TimerTickRecoder maintick;

        private List<Player> players = new List<Player>();

        public List<Player> Players { get { return players; } }

        private List<Dummy> dummies = new List<Dummy>();

        public List<PictureBox> StatusBox { get; set; }

        public ObjectManager(TimerTickRecoder maintick, Form1 form1)
        {
            this.maintick = maintick;
            this.form1 = form1;
        }

        public void AddPlayer(Control.ControlCollection Controls, Size resolution, PlayerInfo playerInfo,Label cooltime)
        //플레이어 정보 >> 플레이어 인스턴스 >> 플레이어 리스트에 저장.
        {
            Player tmp;

            if (playerInfo.IsPlaying == true)
            {
                if (playerInfo.Keyboard == true)
                {
                    tmp = new KeyboardPlayer(Controls, resolution, true, playerInfo.Qudrant, playerInfo.Color, playerInfo.PlayerKeys);
                    tmp.Cooltime = cooltime;
                }
                else
                {
                    tmp = new ControllerPlayer(Controls, resolution, true, playerInfo.Qudrant, playerInfo.Color, playerInfo.Gamepad);
                    tmp.Cooltime = cooltime;

                    //ADD ControllerPlayer
                }
                this.players.Add(tmp);
            }


        }
        public void AddDummy(Control.ControlCollection Controls, Size resolution, int patternType)//0~3
        {
            Dummy tmp = new Dummy(Controls, resolution, patternType);
            this.dummies.Add(tmp);
        }


        #region 플레이어 전체의 이벤트----------------------------------------------------
        public void PlayersMove()
        {
            foreach (Player player in this.players)
            {
                if (player.IsPlaying == true && player.IsAlive == true)
                {
                    player.Move();
                }
            }
        }

        public void PlayersPadCheck()
        {
            foreach (Player player in this.players)
            {
                if (player.IsPlaying == true && player.IsAlive == true)
                {

                    if (player is ControllerPlayer)
                    {
                        ((ControllerPlayer)player).GamepadRead(this.players, this.dummies,this.form1, this.StatusBox);
                    }
                }
            }
        }

        public void PlayersKeyDownCheck(KeyEventArgs e) //only for keyboard player
        {
            foreach (Player player in this.players)
            {
                if (player.IsPlaying == true && player.IsAlive == true)
                {
                    if (player is KeyboardPlayer)
                    {

                        ((KeyboardPlayer)player).KeyDownCheck(e, this.players, this.dummies,this.form1, this.StatusBox);
                    }
                }
            }
        }



        public void PlayersKeyUpCheck(KeyEventArgs e) //only for keyboard player
        {
            foreach (Player player in this.players)
            {
                if (player.IsPlaying == true && player.IsAlive == true && player is KeyboardPlayer)
                {
                    ((KeyboardPlayer)player).KeyUpCheck(e);
                }
            }
        }
        #endregion

        #region 더미 전체의 이벤트----------------------------------------------------

        public void DummiesMove()
        {
            foreach (Dummy dummy in this.dummies)
            {
                if (dummy.IsAlive == true)
                    dummy.Move(this.maintick);
            }
        }

        #endregion

    }

    public class TimerTickRecoder
    {
        private int totalTick = 0;
        public int TotalTick { get { return totalTick; } }
        public void IncreaseTotalTick()
        {
            totalTick++;
        }

    }

    public class RandomChoose
    {
        private Random rand = new Random();

        private int N;

        private List<int> list = new List<int>();

        public RandomChoose(int N)
        {
            this.N = N;
            for (int i = 0; i < this.N; ++i)
            {
                list.Add(i);
            }
        }

        public int Choose()
        {
            int rst;
            int a = rand.Next(0, N);
            rst = list[a];

            list.RemoveAt(a);
            this.N--;
            return rst;
        }
    }
}