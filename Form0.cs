using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Gaming.Input;

namespace Hide_SeekGame
{
    public partial class Form0 : Form
    {
        //Player[0] = Red 
        //Player[1] = Green
        //Player[2] = Blue
        //Player[3] = Yellow

        // 0 -> None 
        // 1 -> KeyBoard1 
        // 2 -> KeyBoard2 
        // 3 -> GamePad1 
        // 4 -> GamePad2
        int[] Players;

        PlayerInfo player1 = InfoNone.None;
        PlayerInfo player2 = InfoNone.None;
        PlayerInfo player3 = InfoNone.None;
        PlayerInfo player4 = InfoNone.None;


        //Gamepad

        Gamepad?[] gamepads = new Gamepad?[4] { null, null, null, null };



        //Dummy
        int NumberOfDummys = 20;
        string DummyPattern = "0";  // 0,1,2,3, Random

        Size resolution = new Size(1440, 990);



        public Form0()
        {
            InitializeComponent();
            Players = new int[4];

            RedCBox.Text = "None";
            GreenCBox.Text = "None";
            BlueCBox.Text = "None";
            YellowCBox.Text = "None";

            DisplayCBox.Text = "1440 x 990";

            DummyCBox.Text = "20";
            DummyPatternCBox.Text = "무작위로 움직임";
            ControllerTextBox.Text = "현재 연결된 Controller 없음\r\n";

            Gamepad.GamepadAdded += Gamepad_GamepadAdded;
            Gamepad.GamepadRemoved += Gamepad_GamepadRemoved;
        }





        #region 버튼 클릭 -------------------------------------------------------

        private void PlayButton_Click(object sender, EventArgs e)
        {
            int cnt = 0;

            if(player1.IsPlaying == true) 
            {
                cnt++;
            }
            if (player2.IsPlaying == true)
            {
                cnt++;
            }
            if (player3.IsPlaying == true)
            {
                cnt++;
            }
            if (player4.IsPlaying == true)
            {
                cnt++;
            }

            if(cnt < 2)
            {
                Form4 form4 = new Form4();
                form4.ShowDialog();

            }
            else
            {
                Form1 form1 = new Form1();

                form1.Player1Info = player1;
                form1.Player2Info = player2;
                form1.Player3Info = player3;
                form1.Player4Info = player4;

                form1.ReceivedResolution = resolution;

                form1.DummyCnt = NumberOfDummys;
                form1.DummyPattern = DummyPattern;

                form1.ClientSize = resolution;

                form1.Show();
                this.Close();
                //
                this.Dispose(true);

            }




        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
            this.Dispose(true);
        }


        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshGamepad();
        }

        private void HowToBtn_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }


        #endregion


        #region 콤보박스 이벤트----------------------------------------------------------------------------

        string redSelected = "None";
        string greenSelected = "None";
        string blueSelected = "None";
        string yellowSelected = "None";

        private void RedCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (RedCBox.Text)
            {
                case "None":
                    {
                        this.player1 = InfoNone.None;


                        RedDeselect(redSelected);


                        break;
                    }
                case "KeyBoard1":
                    {
                        this.player1.IsPlaying = true;
                        this.player1.Keyboard = true;
                        this.player1.Controller = false;

                        this.player1.Color = "Red";

                        this.player1.PlayerKeys = KeyOneTwo.One;
                        this.player1.Gamepad = null;



                        RedDeselect(redSelected);
                        RedSelect(RedCBox.Text);


                        break;

                    }
                case "KeyBoard2":
                    {
                        this.player1.IsPlaying = true;
                        this.player1.Keyboard = true;
                        this.player1.Controller = false;

                        this.player1.Color = "Red";

                        this.player1.PlayerKeys = KeyOneTwo.Two;
                        this.player1.Gamepad = null;



                        RedDeselect(redSelected);
                        RedSelect(RedCBox.Text);


                        break;

                    }
                case "Gamepad1":
                    {
                        this.player1.IsPlaying = true;
                        this.player1.Keyboard = false;
                        this.player1.Controller = true;

                        this.player1.Color = "Red";

                        this.player1.PlayerKeys = KeyNone.None;
                        this.player1.Gamepad = this.gamepads[0];



                        RedDeselect(redSelected);
                        RedSelect(RedCBox.Text);

                        break;
                    }
                case "Gamepad2":
                    {
                        this.player1.IsPlaying = true;
                        this.player1.Keyboard = false;
                        this.player1.Controller = true;

                        this.player1.Color = "Red";

                        this.player1.PlayerKeys = KeyNone.None;
                        this.player1.Gamepad = this.gamepads[1];



                        RedDeselect(redSelected);
                        RedSelect(RedCBox.Text);

                        break;
                    }
                case "Gamepad3":
                    {
                        this.player1.IsPlaying = true;
                        this.player1.Keyboard = false;
                        this.player1.Controller = true;

                        this.player1.Color = "Red";

                        this.player1.PlayerKeys = KeyNone.None;
                        this.player1.Gamepad = this.gamepads[2];



                        RedDeselect(redSelected);
                        RedSelect(RedCBox.Text);

                        break;
                    }
                case "Gamepad4":
                    {
                        this.player1.IsPlaying = true;
                        this.player1.Keyboard = false;
                        this.player1.Controller = true;

                        this.player1.Color = "Red";

                        this.player1.PlayerKeys = KeyNone.None;
                        this.player1.Gamepad = this.gamepads[3];



                        RedDeselect(redSelected);
                        RedSelect(RedCBox.Text);

                        break;
                    }
            }

            redSelected = RedCBox.Text;
        }

        private void GreenCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (GreenCBox.Text)
            {
                case "None":
                    {
                        this.player2 = InfoNone.None;


                        GreenDeselect(greenSelected);


                        break;
                    }
                case "KeyBoard1":
                    {
                        this.player2.IsPlaying = true;
                        this.player2.Keyboard = true;
                        this.player2.Controller = false;

                        this.player2.Color = "Green";

                        this.player2.PlayerKeys = KeyOneTwo.One;
                        this.player2.Gamepad = null;



                        GreenDeselect(greenSelected);
                        GreenSelect(GreenCBox.Text);


                        break;

                    }
                case "KeyBoard2":
                    {
                        this.player2.IsPlaying = true;
                        this.player2.Keyboard = true;
                        this.player2.Controller = false;

                        this.player2.Color = "Green";

                        this.player2.PlayerKeys = KeyOneTwo.Two;
                        this.player2.Gamepad = null;



                        GreenDeselect(greenSelected);
                        GreenSelect(GreenCBox.Text);


                        break;

                    }
                case "Gamepad1":
                    {
                        this.player2.IsPlaying = true;
                        this.player2.Keyboard = false;
                        this.player2.Controller = true;

                        this.player2.Color = "Green";

                        this.player2.PlayerKeys = KeyNone.None;
                        this.player2.Gamepad = this.gamepads[0];



                        GreenDeselect(greenSelected);
                        GreenSelect(GreenCBox.Text);

                        break;
                    }
                case "Gamepad2":
                    {
                        this.player2.IsPlaying = true;
                        this.player2.Keyboard = false;
                        this.player2.Controller = true;

                        this.player2.Color = "Green";

                        this.player2.PlayerKeys = KeyNone.None;
                        this.player2.Gamepad = this.gamepads[1];



                        GreenDeselect(greenSelected);
                        GreenSelect(GreenCBox.Text);

                        break;
                    }
                case "Gamepad3":
                    {
                        this.player2.IsPlaying = true;
                        this.player2.Keyboard = false;
                        this.player2.Controller = true;

                        this.player2.Color = "Green";

                        this.player2.PlayerKeys = KeyNone.None;
                        this.player2.Gamepad = this.gamepads[2];



                        GreenDeselect(greenSelected);
                        GreenSelect(GreenCBox.Text);

                        break;
                    }
                case "Gamepad4":
                    {
                        this.player2.IsPlaying = true;
                        this.player2.Keyboard = false;
                        this.player2.Controller = true;

                        this.player2.Color = "Green";

                        this.player2.PlayerKeys = KeyNone.None;
                        this.player2.Gamepad = this.gamepads[3];



                        GreenDeselect(greenSelected);
                        GreenSelect(GreenCBox.Text);

                        break;
                    }
            }

            greenSelected = GreenCBox.Text;
        }

        private void BlueCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (BlueCBox.Text)
            {
                case "None":
                    {
                        this.player3 = InfoNone.None;


                        BlueDeselect(blueSelected);


                        break;
                    }
                case "KeyBoard1":
                    {
                        this.player3.IsPlaying = true;
                        this.player3.Keyboard = true;
                        this.player3.Controller = false;

                        this.player3.Color = "Blue";

                        this.player3.PlayerKeys = KeyOneTwo.One;
                        this.player3.Gamepad = null;



                        BlueDeselect(blueSelected);
                        BlueSelect(BlueCBox.Text);


                        break;

                    }
                case "KeyBoard2":
                    {
                        this.player3.IsPlaying = true;
                        this.player3.Keyboard = true;
                        this.player3.Controller = false;

                        this.player3.Color = "Blue";

                        this.player3.PlayerKeys = KeyOneTwo.Two;
                        this.player3.Gamepad = null;



                        BlueDeselect(blueSelected);
                        BlueSelect(BlueCBox.Text);


                        break;

                    }
                case "Gamepad1":
                    {
                        this.player3.IsPlaying = true;
                        this.player3.Keyboard = false;
                        this.player3.Controller = true;

                        this.player3.Color = "Blue";

                        this.player3.PlayerKeys = KeyNone.None;
                        this.player3.Gamepad = this.gamepads[0];



                        BlueDeselect(blueSelected);
                        BlueSelect(BlueCBox.Text);

                        break;
                    }
                case "Gamepad2":
                    {
                        this.player3.IsPlaying = true;
                        this.player3.Keyboard = false;
                        this.player3.Controller = true;

                        this.player3.Color = "Blue";

                        this.player3.PlayerKeys = KeyNone.None;
                        this.player3.Gamepad = this.gamepads[1];



                        BlueDeselect(blueSelected);
                        BlueSelect(BlueCBox.Text);

                        break;
                    }
                case "Gamepad3":
                    {
                        this.player3.IsPlaying = true;
                        this.player3.Keyboard = false;
                        this.player3.Controller = true;

                        this.player3.Color = "Blue";

                        this.player3.PlayerKeys = KeyNone.None;
                        this.player3.Gamepad = this.gamepads[2];



                        BlueDeselect(blueSelected);
                        BlueSelect(BlueCBox.Text);

                        break;
                    }
                case "Gamepad4":
                    {
                        this.player3.IsPlaying = true;
                        this.player3.Keyboard = false;
                        this.player3.Controller = true;

                        this.player3.Color = "Blue";

                        this.player3.PlayerKeys = KeyNone.None;
                        this.player3.Gamepad = this.gamepads[3];



                        BlueDeselect(blueSelected);
                        BlueSelect(BlueCBox.Text);

                        break;
                    }
            }

            blueSelected = BlueCBox.Text;
        }

        private void YellowCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (YellowCBox.Text)
            {
                case "None":
                    {
                        this.player4 = InfoNone.None;


                        YellowDeselect(yellowSelected);


                        break;
                    }
                case "KeyBoard1":
                    {
                        this.player4.IsPlaying = true;
                        this.player4.Keyboard = true;
                        this.player4.Controller = false;

                        this.player4.Color = "Yellow";

                        this.player4.PlayerKeys = KeyOneTwo.One;
                        this.player4.Gamepad = null;



                        YellowDeselect(yellowSelected);
                        YellowSelect(YellowCBox.Text);


                        break;

                    }
                case "KeyBoard2":
                    {
                        this.player4.IsPlaying = true;
                        this.player4.Keyboard = true;
                        this.player4.Controller = false;

                        this.player4.Color = "Yellow";

                        this.player4.PlayerKeys = KeyOneTwo.Two;
                        this.player4.Gamepad = null;



                        YellowDeselect(yellowSelected);
                        YellowSelect(YellowCBox.Text);


                        break;

                    }
                case "Gamepad1":
                    {
                        this.player4.IsPlaying = true;
                        this.player4.Keyboard = false;
                        this.player4.Controller = true;

                        this.player4.Color = "Yellow";

                        this.player4.PlayerKeys = KeyNone.None;
                        this.player4.Gamepad = this.gamepads[0];



                        YellowDeselect(yellowSelected);
                        YellowSelect(YellowCBox.Text);

                        break;
                    }
                case "Gamepad2":
                    {
                        this.player4.IsPlaying = true;
                        this.player4.Keyboard = false;
                        this.player4.Controller = true;

                        this.player4.Color = "Yellow";

                        this.player4.PlayerKeys = KeyNone.None;
                        this.player4.Gamepad = this.gamepads[1];



                        YellowDeselect(yellowSelected);
                        YellowSelect(YellowCBox.Text);

                        break;
                    }
                case "Gamepad3":
                    {
                        this.player4.IsPlaying = true;
                        this.player4.Keyboard = false;
                        this.player4.Controller = true;

                        this.player4.Color = "Yellow";

                        this.player4.PlayerKeys = KeyNone.None;
                        this.player4.Gamepad = this.gamepads[2];



                        YellowDeselect(yellowSelected);
                        YellowSelect(YellowCBox.Text);

                        break;
                    }
                case "Gamepad4":
                    {
                        this.player4.IsPlaying = true;
                        this.player4.Keyboard = false;
                        this.player4.Controller = true;

                        this.player4.Color = "Yellow";

                        this.player4.PlayerKeys = KeyNone.None;
                        this.player4.Gamepad = this.gamepads[3];



                        YellowDeselect(yellowSelected);
                        YellowSelect(YellowCBox.Text);

                        break;
                    }
            }

            yellowSelected = YellowCBox.Text;
        }


        private void RedSelect(string item)
        {
            if (item != "None")
            {
                /*
                if (GreenCBox.Text == item)
                {
                    GreenCBox.Text = "None";
                }
                if (BlueCBox.Text == item)
                {
                    BlueCBox.Text = "None";
                }
                if (YellowCBox.Text == item)
                {
                    YellowCBox.Text = "None";
                }
                */
                DeleteItemFromBox(GreenCBox, item);
                DeleteItemFromBox(BlueCBox, item);
                DeleteItemFromBox(YellowCBox, item);
            }
        }

        private void RedDeselect(string item)
        {
            if (item != "None")
            {
                AddItemToBox(GreenCBox, new string[] { item });
                AddItemToBox(BlueCBox, new string[] { item });
                AddItemToBox(YellowCBox, new string[] { item });
            }
        }


        private void GreenSelect(string item)
        {
            if (item != "None")
            {
                /*
                if (RedCBox.Text == item)
                {
                    RedCBox.Text = "None";
                }
                if (BlueCBox.Text == item)
                {
                    BlueCBox.Text = "None";
                }
                if (YellowCBox.Text == item)
                {
                    YellowCBox.Text = "None";
                }
                */
                DeleteItemFromBox(RedCBox, item);
                DeleteItemFromBox(BlueCBox, item);
                DeleteItemFromBox(YellowCBox, item);
            }
        }

        private void GreenDeselect(string item)
        {
            if (item != "None")
            {
                AddItemToBox(RedCBox, new string[] { item });
                AddItemToBox(BlueCBox, new string[] { item });
                AddItemToBox(YellowCBox, new string[] { item });
            }
        }
        private void BlueSelect(string item)
        {
            if (item != "None")
            {
                /*
                if (GreenCBox.Text == item)
                {
                    GreenCBox.Text = "None";
                }
                if (RedCBox.Text == item)
                {
                    RedCBox.Text = "None";
                }
                if (YellowCBox.Text == item)
                {
                    YellowCBox.Text = "None";
                }
                */
                DeleteItemFromBox(GreenCBox, item);
                DeleteItemFromBox(RedCBox, item);
                DeleteItemFromBox(YellowCBox, item);
            }
        }

        private void BlueDeselect(string item)
        {
            if (item != "None")
            {
                AddItemToBox(GreenCBox, new string[] { item });
                AddItemToBox(RedCBox, new string[] { item });
                AddItemToBox(YellowCBox, new string[] { item });
            }
        }
        private void YellowSelect(string item)
        {
            if (item != "None")
            {
                /*
                if (GreenCBox.Text == item)
                {
                    GreenCBox.Text = "None";
                }
                if (BlueCBox.Text == item)
                {
                    BlueCBox.Text = "None";
                }
                if (RedCBox.Text == item)
                {
                    RedCBox.Text = "None";
                }
                */
                DeleteItemFromBox(GreenCBox, item);
                DeleteItemFromBox(BlueCBox, item);
                DeleteItemFromBox(RedCBox, item);
            }
        }

        private void YellowDeselect(string item)
        {
            if (item != "None")
            {
                AddItemToBox(GreenCBox, new string[] { item });
                AddItemToBox(BlueCBox, new string[] { item });
                AddItemToBox(RedCBox, new string[] { item });
            }
        }



        private void DisplayCBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            /*
            1024 x 768
            1280 x 768
            1366 x 768.
            1152 x 864.
            1440 x 990.
            1680 x 1050.
            1280 x 1024
            1400 x 1050
            1600 x 1200
            1920 x 1200
             */
            switch (DisplayCBox.Text)
            {
                case "1280 x 1024":
                    {
                        resolution.Width = 1280;
                        resolution.Height = 1024;
                        break;
                    }

                case "1024 x 768":
                    {
                        resolution.Width = 1024;
                        resolution.Height = 768;
                        break;
                    }

                case "1280 x 768":
                    {
                        resolution.Width = 1280;
                        resolution.Height = 768;
                        break;
                    }
                case "1366 x 768":
                    {
                        resolution.Width = 1366;
                        resolution.Height = 768;
                        break;
                    }
                case "1152 x 864":
                    {
                        resolution.Width = 1152;
                        resolution.Height = 864;
                        break;
                    }
                case "1440 x 990":
                    {
                        resolution.Width = 1440;
                        resolution.Height = 990;
                        break;
                    }
                case "1680 x 1050":
                    {
                        resolution.Width = 1680;
                        resolution.Height = 1050;
                        break;
                    }

                case "1400 x 1050":
                    {
                        resolution.Width = 1400;
                        resolution.Height = 1050;
                        break;
                    }

                case "1600 x 1200":
                    {
                        resolution.Width = 1600;
                        resolution.Height = 1200;
                        break;
                    }

                case "1920 x 1200":
                    {
                        resolution.Width = 1920;
                        resolution.Height = 1200;
                        break;
                    }

                default:
                    {
                        resolution.Width = 1280;
                        resolution.Height = 1024;
                        break;
                    }

            }
        }

        private void DummyCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (DummyCBox.Text)
            {
                case "10":
                    NumberOfDummys = 10;
                    break;
                case "20":
                    NumberOfDummys = 20;
                    break;
                case "30":
                    NumberOfDummys = 30;
                    break;
                case "40":
                    NumberOfDummys = 40;
                    break;
                case "50":
                    NumberOfDummys = 50;
                    break;
                default:
                    NumberOfDummys = 20;
                    break;
            }
        }

        private void DummyPatternCBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            /*
             무작위로 움직임
            1초마다 무작위
            2초마다 무작위
            2초마다 직각
            섞어서
             */
            switch (DummyPatternCBox.Text)
            {
                case "섞어서":
                    DummyPattern = "Random";
                    break;
                case "무작위로 움직임":
                    DummyPattern = "0";
                    break;
                case "1초마다 무작위":
                    DummyPattern = "1";
                    break;
                case "2초마다 무작위":
                    DummyPattern = "2";
                    break;
                default:
                    DummyPattern = "3";
                    break;
            }
        }

        #endregion

        #region 콤보박스 변경 ---------------------------------------------------------------------


        //Player의 ComboBox에 Items추가
        public void AddItemToBox(ComboBox comboBox, string[] items)
        {
            comboBox.Items.AddRange(items);
        }


        //Player의 ComboBox에 Item삭제
        public void DeleteItemFromBox(ComboBox comboBox, string item)
        {
            comboBox.Items.Remove(item);
        }


        //연결된 Controller수에 따라 TextBox에 입력 문구 추가
        public void AddToControllerTextBox(string str)
        {
            ControllerTextBox.AppendText(str);
        }

        //TextBox의 문구 전부 삭제
        public void DeleteFromControllerTextBox()
        {
            ControllerTextBox.Clear();
        }

        #endregion


        #region 게임패드 관련 -------------------------------------------------------------

        private bool HasGamepad(Gamepad targetGamepad)
        {
            bool rst = false;

            foreach (Gamepad? gamepad in this.gamepads)
            {
                if (gamepad == targetGamepad) rst = true;
            }

            return rst;
        }

        private int FindIndexGamepad(Gamepad targetGamepad)
        {
            int rst = -1;

            if (HasGamepad(targetGamepad) == true)
            {
                return rst;
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    if (this.gamepads[i] == null)
                    {
                        rst = i;
                        break;
                    }
                }
                return rst;
            }
        }

        private void CheckGamepad()
        {
            DeleteFromControllerTextBox();

            DeleteItemFromBox(RedCBox, "Gamepad1");
            DeleteItemFromBox(GreenCBox, "Gamepad1");
            DeleteItemFromBox(BlueCBox, "Gamepad1");
            DeleteItemFromBox(YellowCBox, "Gamepad1");

            DeleteItemFromBox(RedCBox, "Gamepad2");
            DeleteItemFromBox(GreenCBox, "Gamepad2");
            DeleteItemFromBox(BlueCBox, "Gamepad2");
            DeleteItemFromBox(YellowCBox, "Gamepad2");

            DeleteItemFromBox(RedCBox, "Gamepad3");
            DeleteItemFromBox(GreenCBox, "Gamepad3");
            DeleteItemFromBox(BlueCBox, "Gamepad3");
            DeleteItemFromBox(YellowCBox, "Gamepad3");

            DeleteItemFromBox(RedCBox, "Gamepad4");
            DeleteItemFromBox(GreenCBox, "Gamepad4");
            DeleteItemFromBox(BlueCBox, "Gamepad4");
            DeleteItemFromBox(YellowCBox, "Gamepad4");

            int cnt = 0;

            for (int i = 0; i < 4; i++)
            {
                if (this.gamepads[i] != null)
                {
                    cnt++;
                    AddToControllerTextBox("Gamepad" + Convert.ToString(i + 1) + "\r\n");

                    AddItemToBox(RedCBox, new string[] { "Gamepad" + Convert.ToString(i + 1) });
                    AddItemToBox(GreenCBox, new string[] { "Gamepad" + Convert.ToString(i + 1) });
                    AddItemToBox(BlueCBox, new string[] { "Gamepad" + Convert.ToString(i + 1) });
                    AddItemToBox(YellowCBox, new string[] { "Gamepad" + Convert.ToString(i + 1) });
                }
            }


            if (cnt == 0)
            {
                AddToControllerTextBox("현재 연결된 Controller 없음\r\n");
            }
        }

        private void AddGamepad(Gamepad targetGamepad)
        {
            int index = FindIndexGamepad(targetGamepad);

            if (index != -1)
            {
                this.gamepads[index] = targetGamepad;
            }

        }

        private void RemoveGamepad(Gamepad targetGamepad)
        {
            for (int i = 0; i < 4; i++)
            {
                if (this.gamepads[i] == targetGamepad)
                {
                    this.gamepads[i] = null;
                }
            }
        }

        private void RefreshGamepad()
        {
            RedCBox.Text = "None";
            GreenCBox.Text = "None";
            BlueCBox.Text = "None";
            YellowCBox.Text = "None";

            redSelected = "None";
            greenSelected = "None";
            blueSelected = "None";
            yellowSelected = "None";



            foreach (Gamepad gamepad in Gamepad.Gamepads)
            {
                AddGamepad(gamepad);
            }
            CheckGamepad();
        }
        private void Gamepad_GamepadAdded(object? sender, Gamepad e)
        {
            AddGamepad(e);
        }
        private void Gamepad_GamepadRemoved(object? sender, Gamepad e)
        {
            RemoveGamepad(e);
        }

        #endregion

        
    }
}
