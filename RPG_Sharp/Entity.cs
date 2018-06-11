using System.Drawing;
using System.Windows.Forms;

namespace RPG_Sharp
{
    /// <summary>
    /// Родительский класс всех объектов/сущностей
    /// </summary>
    abstract class Entity
    {
        /// <summary>
#warning /// Зачем это, пока не понял
        /// </summary>
        protected static int n = 0;

        /// <summary>
        /// Имя объекта
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Координаты левого верхнего угла объекта
        /// </summary>
        private Point location;

        /// <summary>
        /// Положение объекта в пространстве
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
        /// Внешний вид сущности (изображение)
        /// </summary>
        public PictureBox PictureBox {get; protected set; }

        /// <summary>
        /// Установка изображения сущности
        /// </summary>
        public virtual void SetImage()
        {
            this.PictureBox.Location = this.Location;
            this.PictureBox.Visible = true;
            this.PictureBox.Size = new Size(50, 50);
            this.PictureBox.BackColor = Color.Transparent;
           
        }

        /// <summary>
        /// Игра, в которой участвует объект
        /// </summary>
        protected Game Game;

        public Entity(Game game, string name)
        {
            PictureBox = new PictureBox();
            this.SetImage();
            this.Game = game;
            this.Name = name;
            n++;
        }
    }
}
