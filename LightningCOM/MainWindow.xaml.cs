using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Management;

namespace LightningCOM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Animations anims;
        public LightningSettings settings;
        public COMWorking com;
        public bool loading;
        public MainWindow()
        { 
            InitializeComponent();
           Init();
        }
        public void Init()
        {

            anims = new Animations(this);
            settings = new LightningSettings(this);
            com = new COMWorking(this);
        }
        public void Console(string st)
        {
            DateTime time = DateTime.Now;
            string t = time.ToString();
           
            if (!Dispatcher.CheckAccess())
              {
               
                Dispatcher.Invoke(new Action<string>(Console), new object[] {st});
               return;
              }
        
            anims.window.ConsoleBlock.Text += "<"+t+">"+st + " \n";
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (loading) return;
            if (e.OriginalSource == Find) {
                settings.LoadComPorts();
                if (settings.ports.Length<=0) { Console("Устройтсво не найдено");return; }
                com.StartCom(settings.ports[settings.selectedPort]);

            } else
            if (e.OriginalSource == button_add) anims.AddAnimation();
            else
            if (e.OriginalSource == button_del) anims.DeleteAnimation();else
            if (e.OriginalSource == button_add2) anims.AddFrame();
            else
            if (e.OriginalSource == button_del2) anims.DeleteFrame();else
            if (e.OriginalSource == checkBox_rele1) anims.SetRele(0);else
            if (e.OriginalSource == checkBox_rele2) anims.SetRele(1);
            else
            if (e.OriginalSource == checkBox_rele3) anims.SetRele(2);
            else
            if (e.OriginalSource == checkBox_rele4) anims.SetRele(3);
            else
            if (e.OriginalSource == checkBox_rele5) anims.SetRele(4);
            else
            if (e.OriginalSource == checkBox_rele6) anims.SetRele(5);
            else
            if(e.OriginalSource == checkBox_rele7) anims.SetRele(6);else
            if (e.OriginalSource == checkBox2_sensor_1) anims.SetSettings(0);
            else if (e.OriginalSource == checkBox2_sensor_2) anims.SetSettings(1);else
                if (e.OriginalSource == checkBox2_foto) anims.SetSettings(2);else
                if (e.OriginalSource == checkBox2_switch) anims.SetSettings(3);
        }
        public void StartCom() {

        }

        private void listBox_Anims_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (loading) return;
            if (e.OriginalSource == listBox_Anims) anims.SelectAnim();
            else
            if (e.OriginalSource == listBox_frames) anims.SelectFrame();
            else
            if (e.OriginalSource == ComPorts) {
                if (settings == null) return;
                if (ComPorts.SelectedItem != null) {
                    settings.SelectPort(ComPorts.SelectedIndex);

                }

            }
            
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           
            com.StopCom();
        }


    }
}
