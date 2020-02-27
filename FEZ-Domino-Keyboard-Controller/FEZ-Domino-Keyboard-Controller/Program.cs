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


namespace FEZ_Domino_Keyboard_Controller
{
    public class Program
    {
        private static OutputPort led;

        public static USBC_Device device = null;
        public static USBC_Keyboard kb = null;
        public static USBC_Mouse mouse = null;

        public static void ledON()
        {
            led.Write(true);
        }

        public static void ledOFF()
        {
            led.Write(false);
        } 

        public static void Main()
        {
            bool ledState = false;
            led = new OutputPort((Cpu.Pin)FEZ_Pin.Digital.LED, ledState);
            led.Write(false);
            //USB Device
            Program.InitDevice();
            //Network
            Program.InitNetwork();
            //Socket
            Socket server = Program.InitSocket();
            //
            while (true)
            {
                // Wait for a client to connect.
                Socket clientSocket = server.Accept();
                // Process the client request.  true means asynchronous.
                Debug.Print("New Client");
                new ProcessClientRequest(clientSocket);
                Debug.Print("Client is working");
            }
            //
        }

        private static void InitDevice()
        {
            // Check debug interface
            if (Configuration.DebugInterface.GetCurrent() == Configuration.DebugInterface.Port.USB1)
                throw new InvalidOperationException("Current debug interface is USB. It must be changed to something else before proceeding. Refer to your platform user manual to change the debug interface.");

            ushort myVID = 0x1234;
            ushort myPID = 0x0006;
            ushort myDeviceVersion = 0x100;
            ushort myDeviceMaxPower = 250; // in milli amps
            string companyName = "DevDotNet.ORG";
            string productName = "Virtual Keyboard and Mouse";
            string myDeviceSerialNumber = "12345";

            // Create the device
            device = new USBC_Device(myVID, myPID, myDeviceVersion, myDeviceMaxPower, companyName, productName, myDeviceSerialNumber);
            // Add a Keyboard
            kb = new USBC_Keyboard(device, "FEZ Domino Keyboard Interface");
            // Add a Mouse
            mouse = new USBC_Mouse(device, "FEZ Domino Mouse Interface");
            // Start CDC
            // When ready, you can start your device as follows:
            USBClientController.Start(device);
            //
            Debug.Print("Waiting to connect to PC...");
            bool isConnect=false;

            while (!isConnect)
            {
                // Check if connected to PC
                if (USBClientController.GetState() != USBClientController.State.Running)
                {
                    Debug.Print("Waiting to connect to PC...");
                }
                else
                {
                    isConnect = true;
                }
            }
        }

        private static void InitNetwork()
        {
            //сетевая конфигурация
            byte[] ip = { 192, 168, 10, 1 };
            byte[] subnet = { 255, 255, 255, 0 };
            byte[] gateway = { 192, 168, 10, 10 };
            byte[] mac = { 0x00, 0x26, 0x1C, 0x7B, 0x29, 0xE8 };
            //инициализация сети
            WIZnet_W5100.Enable(SPI.SPI_module.SPI1, (Cpu.Pin)FEZ_Pin.Digital.Di10, (Cpu.Pin)FEZ_Pin.Digital.Di9, false);
            GHIElectronics.NETMF.Net.NetworkInformation.NetworkInterface.EnableStaticIP(ip, subnet, gateway, mac);
            GHIElectronics.NETMF.Net.NetworkInformation.NetworkInterface.EnableStaticDns(gateway); // DNS Server
            //
            Debug.Print("InitNetwork OK");
        }

        private static Socket InitSocket()
        {
            const Int32 c_port = 1001;
            Socket server = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, c_port);
            server.Bind(localEndPoint);
            server.Listen(1);
            //
            Debug.Print("InitSocket OK");
            //
            return server;
        }
    }
}
      