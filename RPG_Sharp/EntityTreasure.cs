using System;
using System.Drawing;

namespace RPG_Sharp
{
    class EntityTreasure : EntityNotAlive
    {
        private bool isOpened;
        /// <summary>
        /// Открыт ли сундук
        /// </summary>
        public bool IsOpened
        { 
            get { return isOpened; }
            set
            {
                isOpened = value;
#warning Поменять картинку для открытого сундука
                this.PictureBox.Image = Image.FromFile(Environment.CurrentDirectory + @"\deathstar.png");
            }
        }
        public override void SetImage()
        {
            this.PictureBox.Image = Image.FromFile(Environment.CurrentDirectory + @"\Treasure.png");
            this.PictureBox.BackColor = Color.Transparent;
            base.SetImage();
        }

        public EntityTreasure(Game game)
            : base(game, "Сундук")
        {
            this.PictureBox.Name = "pbTreasure" + n.ToString();
        }
    }
}
