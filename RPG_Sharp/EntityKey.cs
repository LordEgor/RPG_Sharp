using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Sharp
{
    /// <summary>
    /// Ключ от сундука Treasure
    /// </summary>
    class EntityKey : EntityNotAlive
    {
        /// <summary>
        /// Ключ доступен для его сбора
        /// </summary>
        private bool isEnabledToDrop;
        public bool IsEnabledToDrop 
        { 
            get { return isEnabledToDrop; }
            set
            {
                this.PictureBox.Visible = value;
                isEnabledToDrop = value;
            }
        }

        /// <summary>
        /// Подобран ли ключ героем
        /// </summary>
        private bool isObtainedByHero;
        /// <summary>
        /// True, если ключ у героя
        /// </summary>
        public bool IsObtainedByHero 
        {
            get { return isObtainedByHero; }
            set
            {
                if (value)
                {
                    this.PictureBox.Visible = false;
                    this.CanBePassed = true;
                }
                isObtainedByHero = value;
            }
        }

        public override void SetImage()
        {
            this.PictureBox.Image = Properties.Resources.ResourceManager.GetObject("Key") as Image;
            base.SetImage();
        }

        public EntityKey(Game game) : base(game, "Ключ")
        {
            SetImage();
            IsEnabledToDrop = false;
            IsObtainedByHero = false;
            this.PictureBox.Name = "pbKey" + n.ToString();

        }
    }
}
