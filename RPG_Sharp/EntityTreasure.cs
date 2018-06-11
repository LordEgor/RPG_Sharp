using System;
using System.Drawing;

namespace RPG_Sharp
{
    /// <summary>
    /// Сокровище (сундук и его содержимое)
    /// </summary>
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
