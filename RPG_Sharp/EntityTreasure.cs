using System;
using System.Drawing;

namespace RPG_Sharp
{
    /// <summary>
    /// Сокровище (сундук и его содержимое)
    /// </summary>
    class EntityTreasure : EntityNotAlive
    {
        /// <summary>
        /// Открыт ли сундук
        /// </summary>
        private bool isOpened;

        /// <summary>
        /// True, если сундук закрыт
        /// </summary>
        public bool IsOpened
        { 
            get { return isOpened; }
            set
            {
                isOpened = value;
                SetImage();
            }
        }

        public override void SetImage()
        {
            if (!this.IsOpened)
                this.PictureBox.Image = Properties.Resources.ResourceManager.GetObject("Treasure") as Image;
            else
                this.PictureBox.Image = Properties.Resources.ResourceManager.GetObject("deathstar") as Image;
            //this.PictureBox.BackColor = Color.Transparent;
            base.SetImage();
        }

        /// <summary>
        /// Конструктор EntityTreasure
        /// </summary>
        /// <param name="game"></param>
        public EntityTreasure(Game game)
            : base(game, "Сундук")
        {
            this.IsOpened = false;
            this.PictureBox.Name = "pbTreasure" + n.ToString();
        }
    }
}
