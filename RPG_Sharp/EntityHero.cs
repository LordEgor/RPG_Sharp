using System;
using System.Drawing;
using System.Windows.Forms;

namespace RPG_Sharp
{
    /// <summary>
    /// Герой (играбельный персонаж)
    /// </summary>
    class EntityHero : EntityAlive
    {
        public bool HasKey { get; set; }
        public override void SetImage()
        {
            this.PictureBox.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + @"\Hero2.png");
            base.SetImage();
        }
        public EntityHero(Game game)
            : base(game, 250, 15, "Дарт Вейдер")
        {
            this.PictureBox.Name = "pbHero" + n.ToString();
            this.HasKey = false;
        }
    }
}
