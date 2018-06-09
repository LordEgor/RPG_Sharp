using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RPG_Sharp
{
    abstract class EntityAlive : Entity, IAttack
    {
        public virtual void Move(int x, int y)
        {
            //Проверки для движения
            if (((this.Location.X + x) < Game.Field.Width) && ((this.Location.X + x) >= 0))
            {
                this.Location = new Point(Location.X + x, Location.Y);
            }
            if (((this.Location.Y + y) < Game.Field.Height) && ((this.Location.Y + y) >= 0))
            {
                this.Location = new Point(Location.X, Location.Y + y);
            }           

            this.PictureBox.Location = new Point(Location.X, Location.Y);
        }
        
        public int HealthCurrent { get; set; }
        public int HealthMaximum { get; set; }

        protected EntityAlive(Game game, int health, int damage, string name)
            : base(game, name)
        {
            this.HealthCurrent = health;
            this.HealthMaximum = this.HealthCurrent;
            this.Damage = damage;
        }

        public virtual int Damage { get; set; }

        public virtual void Attack(EntityAlive opponent)
        {
            opponent.HealthCurrent -= this.Damage;
            Message = this.Name + " ударил " + opponent.Name + " и нанес ему " + Damage + " урона. (" + opponent.HealthCurrent + "/" + opponent.HealthMaximum + ")";
            if (opponent.HealthCurrent < 0)
            {
                opponent.HealthCurrent = 0;
                Message += Environment.NewLine + this.Name + " убил " + opponent.Name;
            }
        }

        public bool IsAlive()
        {
            return HealthCurrent > 0;
        }
    }
}