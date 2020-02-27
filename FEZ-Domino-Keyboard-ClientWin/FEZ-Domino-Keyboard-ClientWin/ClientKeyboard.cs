using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using FEZ_Domino_Keyboard.Net;
using static FEZ_Domino_Keyboard.Net.TransmittedData;

namespace FEZ_Domino_Keyboard_ClientWin
{
    class ClientKeyboard
    {
        public bool Connected
        {
            get
            {
                if (_socketClient != null) return _socketClient.Connected;
                return false;
            }
            set { }
        }
        //
        private Socket _socketClient;

        public ClientKeyboard()
        {
             
        }

        public void Connect(IPAddress address, int port)
        {
            if (!this.Connected)
            {
                _socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _socketClient.Connect(address, port);
            }
        }
        public void Disconnect()
        {
            //Disconnect
            if (this.Connected)
            {
                _socketClient.Close();
                _socketClient.Dispose();
            }
        }
        public void SendKey(KeyboardKey keyboardKey)
        {
            int key = (int)keyboardKey;
            SendKey(key);
        }

        public void SendKey(int intKey)
        {
            if (this.Connected)
            {
                //Send Key
                /* Format: [Type device];[Key Code]
                 * Sample: 1;40
                 */
                var strCMD = String.Format("{0};{1}\r", (int)HIDTypeDevice.Keyboard, intKey);
                byte[] dataBytes = Encoding.Default.GetBytes(strCMD);
                _socketClient.Send(dataBytes);   
            }

        }
        public void SendMouse(int intDX, int intDY)
        {
            SendMouse(MouseActions.None, System.Windows.Forms.MouseButtons.None, intDX, intDY);
        }


        public void SendMouse(MouseActions mouseAction, System.Windows.Forms.MouseButtons frmmouseButton, int intDX=0,int intDY=0)
        {
            if (this.Connected)
            {
                //Send Mouse
                /* Format: [Type device];[Mouse Action];[MouseButton];DX;DY
                 * Sample: 2;0;0;1;2
                 */
                //Convert type MouseButtons
                TransmittedData.MouseButtons mouseButton;
                switch (frmmouseButton)
                {
                    case System.Windows.Forms.MouseButtons.Left:
                        mouseButton = TransmittedData.MouseButtons.Left;
                        break;
                    case System.Windows.Forms.MouseButtons.Middle:
                        mouseButton = TransmittedData.MouseButtons.Middle;
                        break;
                    case System.Windows.Forms.MouseButtons.Right:
                        mouseButton = TransmittedData.MouseButtons.Right;
                        break;
                    default:
                        mouseButton = TransmittedData.MouseButtons.None;
                        break;
                }
                //
                var strCMD = String.Format("{0};{1};{2};{3};{4}\r",(int)HIDTypeDevice.Mouse,(int) mouseAction, (int)mouseButton, intDX, intDY);
                byte[] dataBytes = Encoding.Default.GetBytes(strCMD);
                _socketClient.Send(dataBytes);
            } 
        }
    }
}
