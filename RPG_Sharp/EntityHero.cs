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
        /// <summary>
        /// Наличие у героя ключа.
        /// True, если ключ есть
        /// </summary>
        public bool HasKey { get; set; }

        /// <summary>
        /// Скин героя
        /// </summary>
        public override void SetImage()
        {
            this.PictureBox.Image = Properties.Resources.ResourceManager.GetObject("Hero3") as Image;
            base.SetImage();
        }

        /// <summary>
        /// Конструктор EntityHero
        /// </summary>
        /// <param name="game"></param>
        public EntityHero(Game game)
            : base(game, 300, 20, "Ведьмак")
        {
            SetImage();
            this.PictureBox.Name = "pbHero" + n.ToString();
            this.HasKey = false;
        }
    }
}
