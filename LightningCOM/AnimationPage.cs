using System.Collections.Generic;
using System.Windows.Controls;

namespace LightningCOM
{
    public class AnimationPage
    {
        public Animations anims;
        public  List<Frame> frames;
        public bool foto = true;
        public bool sens_1 = true;
        public bool sens_2 = true;
        public bool swich = true;
        public int selectedFrame =-1;
        public AnimationPage(Animations anims) {
            this.anims = anims;
            frames = new List<Frame>();
        }
        public void AddFrame()
        {
            if (anims.selected == -1) return;
            ListBoxItem myListBoxItem = new ListBoxItem();
            myListBoxItem.Content = "Кадр " + anims.window.listBox_frames.Items.Count;
            anims.window.listBox_frames.Items.Add(myListBoxItem);
            frames.Add(new Frame(anims));
            
        }
        public void DeleteFrame()
        {
            selectedFrame = anims.window.listBox_frames.SelectedIndex;
            if (anims.selected == -1) return;
            if (anims.window.listBox_frames.SelectedItem != null)
            {
                int id = anims.window.listBox_frames.Items.IndexOf(anims.window.listBox_frames.SelectedItem);
                if (id == selectedFrame) selectedFrame = -1;
                frames.RemoveAt(id);
                anims.window.listBox_frames.Items.Remove(anims.window.listBox_frames.SelectedItem);
            }

        }
        public void SelectFrame()
        {
            selectedFrame = anims.window.listBox_frames.SelectedIndex;
            if (anims.selected == -1) return;
            if (selectedFrame == -1) return;
            Clear();
            anims.window.checkBox_rele1.IsChecked = frames[selectedFrame].reles[0];
            anims.window.checkBox_rele2.IsChecked = frames[selectedFrame].reles[1];
            anims.window.checkBox_rele3.IsChecked = frames[selectedFrame].reles[2];
            anims.window.checkBox_rele4.IsChecked = frames[selectedFrame].reles[3];
            anims.window.checkBox_rele5.IsChecked = frames[selectedFrame].reles[4];
            anims.window.checkBox_rele6.IsChecked = frames[selectedFrame].reles[5];
            anims.window.checkBox_rele7.IsChecked = frames[selectedFrame].reles[6];
          
        }
        public void SelectFrame(int s)
        {
            selectedFrame = s;
            if (anims.selected == -1) return;
            if (selectedFrame == -1) return;
            Clear();
            anims.window.checkBox_rele1.IsChecked = frames[selectedFrame].reles[0];
            anims.window.checkBox_rele2.IsChecked = frames[selectedFrame].reles[1];
            anims.window.checkBox_rele3.IsChecked = frames[selectedFrame].reles[2];
            anims.window.checkBox_rele4.IsChecked = frames[selectedFrame].reles[3];
            anims.window.checkBox_rele5.IsChecked = frames[selectedFrame].reles[4];
            anims.window.checkBox_rele6.IsChecked = frames[selectedFrame].reles[5];
            anims.window.checkBox_rele7.IsChecked = frames[selectedFrame].reles[6];

        }
        public void Clear()
        {
            anims.window.checkBox_rele1.IsChecked = false;
            anims.window.checkBox_rele2.IsChecked = false;
            anims.window.checkBox_rele3.IsChecked = false;
            anims.window.checkBox_rele4.IsChecked = false;
            anims.window.checkBox_rele5.IsChecked = false;
            anims.window.checkBox_rele6.IsChecked = false;
            anims.window.checkBox_rele7.IsChecked = false;
        }
    }
}