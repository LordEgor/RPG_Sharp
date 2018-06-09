using System.Drawing;
using System.Windows.Forms;

namespace RPG_Sharp
{
    abstract class Entity
    {
        protected static int n = 0;

        /// <summary>
        /// Имя объекта
        /// </summary>
        public string Name { get; set; }

        private Point location;
        /// <summary>
        /// Координаты левого верхнего угла
        /// </summary>
        public Point Location 
        {
            get { return location; }
            set 
            { 
                location = value;
                this.PictureBox.Location = location;
            }
        }

        /// <summary>
        /// Сообщение о действии сущности за текущий ход
        /// </summary>
        public string Message { get; protected set; }        

        /// <summary>
        /// 
        /// </summary>
        public PictureBox PictureBox {get; protected set; }

        /// <summary>
        /// Выбор изображения 
        /// </summary>
        public virtual void SetImage()
        {
            this.PictureBox.Location = this.Location;
            this.PictureBox.Visible = true;
            this.PictureBox.Size = new Size(50, 50);
            this.PictureBox.BackColor = Color.Transparent;
           
        }

        protected Game Game;
        public Entity(Game game, string name)
        {
            PictureBox = new PictureBox();
            this.Game = game;
            this.Name = name;
            n++;
        }
    }
}
