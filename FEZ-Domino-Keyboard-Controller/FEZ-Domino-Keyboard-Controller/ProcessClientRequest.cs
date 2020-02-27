using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using GHIElectronics.NETMF.FEZ;

using Microsoft.SPOT.Net.NetworkInformation;
using System.Text;
//using GHIElectronics.NETMF.Hardware.LowLevel;
//using GHIElectronics.NETMF.IO;

using GHIElectronics.NETMF.Net;
using GHIElectronics.NETMF.Net.Sockets;
using Socket = GHIElectronics.NETMF.Net.Sockets.Socket;
using GHIElectronics.NETMF.Net.NetworkInformation;

using GHIElectronics.NETMF.USBClient;
using GHIElectronics.NETMF.Hardware;

using FEZ_Domino_Keyboard.Net;

namespace FEZ_Domino_Keyboard_Controller
{
    /// <summary>
    /// Processes a client request.
    /// </summary>
    internal sealed class ProcessClientRequest
    {
        private Socket m_clientSocket;

        /// <summary>
        /// The constructor calls another method to handle the request, but can 
        /// optionally do so in a new thread.
        /// </summary>
        /// <param name="clientSocket"></param>
        /// <param name="asynchronously"></param>
        public ProcessClientRequest(Socket clientSocket)
        {
                m_clientSocket = clientSocket;
               // Spawn a new thread to handle the request.
                    new Thread(ProcessRequest).Start();
        }

        private void HandleCommand(string cmd)
        {
            Debug.Print(cmd);
            //Send to USB Device
            //TODO
            string[] arrayStrCMD=cmd.Split(';');
            int[] arrayIntCMD= new int[arrayStrCMD.Length];
            //toInt
            for (int i=0;i<arrayIntCMD.Length;i++)
            {
                arrayIntCMD[i] = int.Parse(arrayStrCMD[i]);
            }
            //
            GC.SuppressFinalize(cmd);
            GC.SuppressFinalize(arrayStrCMD);
           //Keyboard or Mouse
            switch(arrayIntCMD[0])
            {
                case (int)TransmittedData.HIDTypeDevice.Mouse:
                    Debug.Print("CMD Device Mouse");
                    //
                    if (Program.mouse != null)
                    {
                        USBC_Mouse.Buttons button = USBC_Mouse.Buttons.BUTTON_NONE;
                        //Format: [Type device];[Mouse Action];[MouseButton];DX;DY
                        //Mouse Button
                        button = (GHIElectronics.NETMF.USBClient.USBC_Mouse.Buttons)arrayIntCMD[2];
                        //Send Mouse Device
                        Program.mouse.SendData(arrayIntCMD[3], arrayIntCMD[4], 0, button);
                    }
                    //
                    break;
                case (int)TransmittedData.HIDTypeDevice.Keyboard:
                    Debug.Print("CMD  Device Keyboard");
                    break;
                default:
                    Debug.Print("CMD None");
                    break;

            }
        }
        
        /// <summary>
        /// Processes the request.
        /// </summary>
        private void ProcessRequest()
        {
            //
            Debug.Print("ProcessRequest");
            //
            byte[] command = new byte[100];
            int index = 0;
            using (m_clientSocket)
            {
                while (true)
                {
                    //
                    if (m_clientSocket.Receive(command, index, 1, SocketFlags.None) == 0)
                    {
                        Debug.Print("Socket Close");
                        m_clientSocket.Close();
                        break;
                    }
                    //
                    if (command[index] == '\r')
                    {
                        Program.ledON();
                        // do we have some data?
                        string cmd = new string(Encoding.UTF8.GetChars(command), 0, index);
                        HandleCommand(cmd);
                        index = 0;
                        //
                        Program.ledOFF();
                    }
                    else if (command[index] >= 32 && command[index] <= 126)
                    {

                        index++;
                        if (index >= command.Length)
                        {
                            Debug.Print("We have too much data!");
                            index = 0;//dump it all
                        }
                    }
                    //
                }
            }
         }
   }
}
     
