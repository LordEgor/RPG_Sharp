using System;
using System.Drawing;

namespace RPG_Sharp
{
    class EntityEnemy : EntityAlive
    {

        static Random r = new Random();
        public override void SetImage()
        {
            int p = r.Next(1,5);
        
        switch (p)
    	{
		    case 1:
                this.PictureBox.Image = Image.FromFile(Environment.CurrentDirectory + @"\Enemy.png");
                break;
            case 2:
                this.PictureBox.Image = Image.FromFile(Environment.CurrentDirectory + @"\Enemy2.png");
                break;
            case 3:
                this.PictureBox.Image = Image.FromFile(Environment.CurrentDirectory + @"\Enemy3.png");
                break;
            case 4:
                this.PictureBox.Image = Image.FromFile(Environment.CurrentDirectory + @"\Enemy4.png");
                break;
            default:
            break;

	    }
            //this.PictureBox.Image = Image.FromFile(Environment.CurrentDirectory + @"\Enemy.png");
            base.SetImage();
        }
        public override void Move(int x, int y)
        {
            return;
        }

        public EntityEnemy(Game game)
            : base(game, 60, 7, "Участник сопротивления")
        {
            this.PictureBox.Name = "pbEnemy" + n.ToString();
        }
    }
}