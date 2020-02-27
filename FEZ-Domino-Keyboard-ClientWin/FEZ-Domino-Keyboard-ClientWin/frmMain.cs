using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics;
using static FEZ_Domino_Keyboard.Net.TransmittedData;

namespace FEZ_Domino_Keyboard_ClientWin
{
    public partial class frmMain : Form
    {
        Point pointOldCursor = new Point(0,0);
        ClientKeyboard _clientKeyboard = new ClientKeyboard();
        public frmMain()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            var _currentPosition = e.Location;
            //
            lblPosition.Text = String.Format("Position X={0}, Y={1}", _currentPosition.X, _currentPosition.Y);
            //
            if(pointOldCursor!=new Point(0,0))
            {
                Point _dxdy = new Point(_currentPosition.X - pointOldCursor.X, _currentPosition.Y - pointOldCursor.Y);
                if(_dxdy.Y!=0&& _dxdy.X != 0)
                {
                    //Send Mouse
                    _clientKeyboard.SendMouse(_dxdy.X, _dxdy.Y);
                    //
                    lblMouseButton.Text = String.Format("Event {0} Button {1}", MouseActions.None.ToString(), System.Windows.Forms.MouseButtons.None.ToString());
                    lblDxDy.Text = String.Format("Mouse dX = {0} dY = {1}", _dxdy.X, _dxdy.Y);
                    //
                    pointOldCursor = _currentPosition;
                    //
                    Debug.WriteLine(_dxdy.X + " " + _dxdy.Y);
                } 
            }
        }

        private void picBoxPad_MouseDown(object sender, MouseEventArgs e)
        {
            lblMouseButton.Text = String.Format("Button {0} Event {1}", e.Button.ToString(), MouseActions.MouseDown.ToString());
            lblDxDy.Text = String.Format("Mouse dX = {0} dY = {1}", 0, 0);
            //
            _clientKeyboard.SendMouse(MouseActions.MouseDown, e.Button);
        }

        private void picBoxPad_MouseUp(object sender, MouseEventArgs e)
        {
            lblMouseButton.Text = String.Format("Button {0} Event {1}", e.Button.ToString(), MouseActions.MouseUp.ToString());
            lblDxDy.Text = String.Format("Mouse dX = {0} dY = {1}", 0, 0);
            //
            _clientKeyboard.SendMouse(MouseActions.MouseUp, e.Button);
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            //
            this.KeyPreview = true;
            this.KeyPress +=
                new KeyPressEventHandler(Form1_KeyPress);
            //Test
            txtIPAddress.Text = "192.168.10.1";
            //
        }

        void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            var _intCodeKey = (int)e.KeyChar;
            //
            lblKey.Text = String.Format("Key = {0} Code = {1}", e.KeyChar, _intCodeKey);
            //
            _clientKeyboard.SendKey(_intCodeKey);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            var stripAddress = txtIPAddress.Text;
            stripAddress = stripAddress.Trim();
            stripAddress = stripAddress.Replace(" ", String.Empty);
            //
            _clientKeyboard = new ClientKeyboard();
            if (!_clientKeyboard.Connected)
            {
                //Connect
                IPAddress ipAddress;
                if (IPAddress.TryParse(stripAddress, out ipAddress))
                {
                    //valid ip
                    _clientKeyboard.Connect(ipAddress, 1001);
                    //
                    txtIPAddress.Enabled = false;
                    btnConnect.Text = "Disconnect";
                }
                else
                {
                    //is not valid ip
                    MessageBox.Show("is not valid ip");
                }
                //
            }
            else
            {
                //Disconnect
                _clientKeyboard.Disconnect();
                //
                txtIPAddress.Enabled = Enabled;
                btnConnect.Text = "Connect";
            }
        }

        private void btnSendKey(object sender, EventArgs e)
        {
            Button _button = (System.Windows.Forms.Button)sender;
            switch (_button.Name)
            {
                case "btnSendCtrlAltDel":
                    _clientKeyboard.SendKey(KeyboardKey.CtrlAltDel);
                    break;
                case "btnSendEnter":
                    _clientKeyboard.SendKey(KeyboardKey.Enter);
                    break;
                case "btnSendShiftAlt":
                    _clientKeyboard.SendKey(KeyboardKey.ShiftAlt);
                    break;
                default:
                    Console.WriteLine("No Name Button");
                    break;
            }
        }

        private void picBoxPad_MouseEnter(object sender, EventArgs e)
        {
            var _point=picBoxPad.PointToClient(Cursor.Position);
            pointOldCursor = _point;   
        }

        private void picBoxPad_MouseLeave(object sender, EventArgs e)
        {
            //off
            pointOldCursor = new Point(0, 0);
        }
    }
}
