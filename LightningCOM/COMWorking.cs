using System;
using System.IO.Ports;
using System.Threading;

namespace LightningCOM
{
    public class COMWorking
    {
        MainWindow window;
        Thread th;
        SerialPort port;
        string com;
        public COMWorking(MainWindow window)
        {
            this.window = window;

        }
        public void StartCom(string com) {
            StopCom();
            try
            {
            port = new SerialPort();
            port.PortName = com;
            port.BaudRate = 9600;
            port.DataReceived += process;
            port.Open();
            window.Console("Успешное соединение с устройством " + port.PortName);
            }
             catch (Exception ex) {
                    window.Console("Отключение от устройства");
                }
        }

        private void process(object sender, SerialDataReceivedEventArgs e)
        {
            string mess = port.ReadExisting();
            
            processMess(mess);
        }

        void processMess(string mess)
        {
            if (mess.StartsWith("end")) TransferEnd();
            else
            if (mess.StartsWith("setting")) {  TransferStart(); }
            else
            if (mess.StartsWith("mess")) window.Console(mess);
            else
            if (mess.StartsWith("frame")) TransferFrame();else
            if (mess.StartsWith("foto")) TransferBoolen(window.anims.anims[window.anims.selected].foto);
            else
            if (mess.StartsWith("sens_1")) TransferBoolen(window.anims.anims[window.anims.selected].sens_1);
            else
            if (mess.StartsWith("sens_2")) TransferBoolen(window.anims.anims[window.anims.selected].sens_2);
            else
            if (mess.StartsWith("switch")) TransferBoolen(window.anims.anims[window.anims.selected].swich);
        }
        public void TransferBoolen(bool b) {
            if (b) {
                port.WriteLine("1");
            } else {
                port.WriteLine("0");
            }
        }
        public void TransferFrame() {
                 byte b = window.anims.anims[window.anims.selected].frames[window.anims.anims[window.anims.selected].selectedFrame].ConvertBoolArrayToByte();
                 window.anims.anims[window.anims.selected].selectedFrame+=1;
                 
                 port.WriteLine(b.ToString());
        }
        public void TransferStart() {
            if (window.anims.selected == -1) return;
            window.loading = true;
            window.Console("Найстройка начата");
            int a = window.anims.anims[window.anims.selected].frames.Count;
            if (a==0) return;
            window.anims.anims[window.anims.selected].selectedFrame = 0;
            Console.WriteLine(a.ToString());
            port.WriteLine(a.ToString());
        }
        public void TransferEnd()
        {
            port.WriteLine("end");
            window.Console("Настройка завершена");
            window.anims.selected = 0;
            window.anims.anims[window.anims.selected].selectedFrame = 0;
            window.loading = false;
        }
        public void StopCom()
        {
            if (port != null)
            {
                port.Close();
                port = null;
            }
            if (th == null) return;
            window.Console("Отключение от устройства");
            th.Abort();
            th = null;
        }
    }
}