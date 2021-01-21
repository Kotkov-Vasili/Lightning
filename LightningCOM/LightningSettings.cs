using System.IO.Ports;
using System.Windows.Controls;

namespace LightningCOM
{
    public class LightningSettings
    {
        public int channels = 7;
        MainWindow window;
        public string[] ports;
        public int selectedPort = 0;
        public LightningSettings(MainWindow window){
            this.window = window;
           LoadComPorts();
        }
        public void LoadComPorts() {
            ClearComPorts();
            ports = SerialPort.GetPortNames();
            for (int i=0;i<ports.Length;i++) {
                ComboBoxItem myListBoxItem = new ComboBoxItem();
                myListBoxItem.Content = ports[i];
               window.ComPorts.Items.Add(myListBoxItem);
            }
            
          
            
            
            

        }
        void ClearComPorts() {
            if (ports == null) return;
            if (ports.Length < 0) return;
            window.ComPorts.Items.Clear();
            ports = null;
         

        }
        public void SelectPort(int a) {
            selectedPort = a;
            
        }
    }
}