﻿using System;
using System.Windows.Forms;

namespace RPG_Sharp
{
    /// <summary>
    /// Игровая форма
    /// </summary>
    public partial class RPGForm : Form
    {
        /// <summary>
        /// Игра, в которой весь сырбор
        /// </summary>
        private Game game;

        private RPGForm form;

        /// <summary>
        /// Конструктор RPGForm
        /// </summary>
        public RPGForm()
        {
            InitializeComponent();
            form = this;
            game = new Game(ref form);
            Text = "В поисках сокровищ!";
            Icon = Properties.Resources.ResourceManager.GetObject("khorne") as System.Drawing.Icon;
        }

        /// <summary>
        /// Обработка совершённого по нажатию клавиши нового хода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RPGForm_KeyDown(object sender, KeyEventArgs e)
        {
            game.HandleKeyPress(e);
            Refresh();
            if (textBoxLog.Text.Length > 0)
            {
                textBoxLog.SelectionStart = textBoxLog.Text.Length - 1;
                textBoxLog.ScrollToCaret();
                
            }
        }
    }
}