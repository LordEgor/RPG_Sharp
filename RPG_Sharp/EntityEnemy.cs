using System;
using System.Drawing;

namespace RPG_Sharp
{
    /// <summary>
    /// Враг - злодей - враждебный персонаж (ИИ)
    /// </summary>
    class EntityEnemy : EntityAlive
    {

        static Random r = new Random();
        /// <summary>
        /// Переопределённый для Enemy метод SetImage
        /// </summary>
        public override void SetImage()
        {
            // Число различных скинов мобов (от 0 до enemyTypes-1)
            const int enemyTypes = 7;
            int p = r.Next(0,enemyTypes);

            this.PictureBox.Image = Properties.Resources.ResourceManager.GetObject("Enemy" + p) as Image;
            base.SetImage();
        }

        /// <summary>
        /// Переопределение, так как злодеи не могут двигаться.
        /// Но т.к. этот метод нигде не вызывается, злодей и так
        /// по факту нигде движения не производит
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public override void Move(int x, int y)
        {
            return;
        }

        /// <summary>
        /// Конструктор EntityEnemy
        /// </summary>
        /// <param name="game"></param>
        public EntityEnemy(Game game)
            : base(game, 60, 7, "Чудище-страшилище")
        {
            this.SetImage();
            this.PictureBox.Name = "pbEnemy" + n.ToString();
        }
    }
}