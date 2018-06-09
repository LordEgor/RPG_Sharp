using System;
using System.Drawing;

namespace RPG_Sharp
{
    class EntityTree : EntityNotAlive
    {
        public override void SetImage()
        {
            this.PictureBox.Image = Image.FromFile(Environment.CurrentDirectory + @"\Tree.png");
            base.SetImage();
        }

        public EntityTree(Game game)
            : base(game, "Дерево")
        {
            this.PictureBox.Name = "pbTree" + n.ToString();
        }
    }
}
