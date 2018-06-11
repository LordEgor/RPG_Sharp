using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RPG_Sharp
{
    /// <summary>
    /// Одушевлённые сущности (герой/злодеи)
    /// </summary>
    abstract class EntityAlive : Entity, IAttack
    {
        /// <summary>
        /// Движение по пространству
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public virtual void Move(int x, int y)
        {
            //Проверки на выход за границы пространства
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
        
        /// <summary>
        /// Состояние здоровья на данный момент
        /// </summary>
        public int HealthCurrent { get; set; }
        /// <summary>
        /// Максимальное здоровье
        /// </summary>
        public int HealthMaximum { get; set; }

        /// <summary>
        /// Конструктор EntityAlive
        /// </summary>
        /// <param name="game"></param>
        /// <param name="health">Здоровье</param>
        /// <param name="damage">Урон</param>
        /// <param name="name">Имя</param>
        protected EntityAlive(Game game, int health, int damage, string name)
            : base(game, name)
        {
            this.HealthCurrent = health;
            this.HealthMaximum = this.HealthCurrent;
            this.Damage = damage;
        }
        
        /// <summary>
        /// Наносимый урон
        /// </summary>
        public virtual int Damage { get; set; }

        /// <summary>
        /// Персонаж бьёт противника
        /// </summary>
        /// <param name="opponent">Противник, получающий урон</param>
        public virtual void Attack(EntityAlive opponent)
        {
            opponent.HealthCurrent -= this.Damage;
            if (opponent.HealthCurrent <= 0) opponent.HealthCurrent = 0;
            Message = this.Name + " ударил " + opponent.Name + " и нанес ему " + Damage + " урона. (" + opponent.HealthCurrent + "/" + opponent.HealthMaximum + ")";
            if (opponent.HealthCurrent <= 0)
            {
                Message += Environment.NewLine + this.Name + " убил " + opponent.Name;
            }
        }

        /// <summary>
        /// Жив объект, или нет
        /// </summary>
        /// <returns>True, если жив</returns>
        public bool IsAlive()
        {
            return HealthCurrent > 0;
        }
    }
}