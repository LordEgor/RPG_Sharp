using System;
using System.Windows.Forms;

namespace RPG_Sharp
{
    public partial class RPGForm : Form
    {
        private Game game;
        private RPGForm form;
        public RPGForm()
        {
            InitializeComponent();
            form = this;
            game = new Game(ref form);
        }

        private void RPGForm_KeyDown(object sender, KeyEventArgs e)
        {
            game.HandleKeyPress(e);     //Если нажаты стрелки
            Refresh();
            if (textBoxLog.Text.Length > 0)
            {
                textBoxLog.SelectionStart = textBoxLog.Text.Length - 1;
                textBoxLog.ScrollToCaret();
                
            }
        }
    }
}