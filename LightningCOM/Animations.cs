using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LightningCOM
{
   public  class Animations
    {
       public  MainWindow window;
      public  List<AnimationPage> anims;
        public int selected = -1;
     
        public Animations(MainWindow window)
        {
            
            this.window = window;
            anims = new List<AnimationPage>();
            
        }
        public void AddAnimation() {
            ListBoxItem myListBoxItem = new ListBoxItem();
            myListBoxItem.Content = "Анимация " + window.listBox_Anims.Items.Count;
            window.listBox_Anims.Items.Add(myListBoxItem);
            anims.Add(new AnimationPage(this));
           
        }
        public void DeleteAnimation()
        {
            if (window.listBox_Anims.SelectedItem != null)
            {
                int id = window.listBox_Anims.Items.IndexOf(window.listBox_Anims.SelectedItem);
                if (id == selected) selected = -1;
                anims.RemoveAt(id);
                window.listBox_Anims.Items.Remove(window.listBox_Anims.SelectedItem);
            }
            
        }
        public void AddFrame() {
            if (selected == -1) return;
            anims[selected].AddFrame();
        }
        public void DeleteFrame()
        {
            if (selected == -1) return;
            anims[selected].DeleteFrame();

        }
        public void SetRele(int a) {
            if (selected == -1) return;
            if(anims[selected].selectedFrame==-1) return;
            anims[selected].frames[anims[selected].selectedFrame].SetRele(a);
        }
        public void SetSettings(int a) {
            if (selected == -1) return;
            if (a == 0) anims[selected].sens_1 = !anims[selected].sens_1;
            if (a == 1) anims[selected].sens_2 = !anims[selected].sens_2;
            if (a == 2) anims[selected].foto = !anims[selected].foto;
            if (a == 3) anims[selected].swich = !anims[selected].swich;
        }
        public void SelectAnim() {
            Clear();
            int ind = 0;
            selected = window.listBox_Anims.SelectedIndex;
            if (selected == -1) return;
            foreach(Frame f in anims[selected].frames)
            {
                ListBoxItem myListBoxItem = new ListBoxItem();
                myListBoxItem.Content = "Кадр " + ind;
                window.listBox_frames.Items.Add(myListBoxItem);
                ind++;

            }
            window.checkBox2_sensor_1.IsChecked = anims[selected].sens_1;
            window.checkBox2_sensor_2.IsChecked = anims[selected].sens_2;
            window.checkBox2_foto.IsChecked = anims[selected].foto;
            window.checkBox2_switch.IsChecked = anims[selected].swich;
        }
        public void SelectFrame() {
            if (selected == -1) return;
           
            anims[selected].SelectFrame();
        }
        public void Clear() {
            for (int i=0;i < window.listBox_frames.Items.Count;) {
                window.listBox_frames.Items.RemoveAt(window.listBox_frames.Items.Count-1);
            }
        }
        

    }
}
