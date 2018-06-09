using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Sharp
{
    class EntityKey : EntityNotAlive
    {
        private bool isEnabledToDrop;
        public bool IsEnabledToDrop 
        { 
            get { return isEnabledToDrop; }
            set
            {
                if (value)
                {
                    this.PictureBox.Visible = true;
                }
                isEnabledToDrop = value;
            }
        }


        private bool isObtainedByHero;
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
            this.PictureBox.Image = Image.FromFile(Environment.CurrentDirectory + @"\Key.png");
            base.SetImage();
            this.PictureBox.Visible = false;
        }

        public EntityKey(Game game) : base(game, "Ключ")
        {
            IsEnabledToDrop = false;
            IsObtainedByHero = false;
            this.PictureBox.Name = "pbKey" + n.ToString();

        }
    }
}
