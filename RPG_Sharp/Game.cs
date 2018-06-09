﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
namespace RPG_Sharp
{
    class Game  
    {
        /// <summary>
        /// Объявление айдиоплэера 
        /// </summary>
        private SoundPlayer Player;

        /// <summary>
        /// Объявление героя
        /// </summary>
        private EntityHero Hero;
        
        /// <summary>
        /// Объявление формы
        /// </summary>
        public RPGForm Form;
        
        /// <summary>
        /// Объявление поля 
        /// </summary>
        public PictureBox Field;
        
        /// <summary>
        /// Объявление списка врагов 
        /// </summary>
        private List<EntityEnemy> Enemy;

        /// <summary>
        /// Список противников рядом с героем
        /// </summary>
        private List<EntityEnemy> EnemiesNear;
        
        /// <summary>
        /// Объявление списка сундуков 
        /// </summary>
        private List<EntityTreasure> Treasure;
        
        /// <summary>
        /// Объявление списка деревьев(препятствий)
        /// </summary>
        private List<EntityTree> Tree;
        
        /// <summary>
        /// Объявлене списка,в который войдут все сущности 
        /// </summary>
        private List<Entity> Entities;

        /// <summary>
        /// Ключ
        /// </summary>
        private EntityKey Key;

        private Random rand;
        
        /// <summary>
        /// Объявления счетчика шагов 
        /// </summary>
        private long Turn;

        /// <summary>
        /// Счетчик количества оставшихся в живых врагов
        /// </summary>
        private int EnemiesLeft;
#region Key
        /// <summary>
        /// Обработка текущего хода игры
        /// </summary>
        /// <param name="key"></param> 
        public void HandleKeyPress(KeyEventArgs key)
        {
            // Свитч:
            // Если нажат F - атака
            // Если нажат пробел - поднять предмет
            // Если нажаты стрелки или WASD- движение
            // Иначе ничего не делать

            // Увеличивать ход только для шести кнопок действий
            if (Hero.IsAlive() && !EndGame())
            {
                switch (key.KeyCode)
                {
                    case Keys.F: ;
                        if (CheckforEnemies(Hero))
                        {
                            Hero.Attack(EnemiesNear[0]);
                            Form.textBoxLog.Text += Hero.Message + Environment.NewLine;
                            EnemiesThink();
                            UpdateLabelHeroInfo();
                            CheckAliveEnemiesCount();
                            Turn++;
                        }
                        break;
                    case Keys.Space:
                        LootItems();
                        UpdateLabelHeroInfo();
                        break;
                    case Keys.W:
                    case Keys.A:
                    case Keys.S:
                    case Keys.D:
                    case Keys.Up:
                    case Keys.Right:
                    case Keys.Down:
                    case Keys.Left:
                        MoveHero(key);
                        EnemiesThink();
                        UpdateLabelHeroInfo();
                        Turn++;
                        break;
                    default:
                        break;
                }
            }

            //сообщения об окончании игры в случаи смерти или 
            else if(!Hero.IsAlive())
            {
                Player = new SoundPlayer(Environment.CurrentDirectory+@"\loose.wav");
                Player.Play(); 
                if  (DialogResult.Retry==MessageBox.Show
                    ("Ваш герой был злодейски убит силами противника(Впрочем,как всегда). Игра окончена.",
                     "!ПОТРАЧЕНО!", MessageBoxButtons.RetryCancel))
                {
                    RestartGame();
                }
                else
                {
                    Application.Exit();
                }
            }
            else if (EndGame())
            {
                Player = new SoundPlayer(Environment.CurrentDirectory+@"\win.wav");
                Player.Play(); 
                if (DialogResult.Retry == MessageBox.Show("Вы победили всех!И забрали сокровище!", 
                    "Победа!", MessageBoxButtons.RetryCancel))
                {
                    RestartGame();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        /// <summary>
        /// функция передвижения героя 
        /// </summary>
        /// <param name="Key"></param>
        private void MoveHero(KeyEventArgs Key)
        {
            int tempX = 0, tempY = 0;
            // Проверять новое положение героя, чтобы он не выходил за пределы Field
            switch (Key.KeyCode)
            {
                case Keys.W:
                case Keys.Up:
                    tempX = 0;
                    tempY = -50;
                    break;
                case Keys.D:
                case Keys.Right:
                    tempX = 50;
                    tempY = 0;
                    break;
                case Keys.S:
                case Keys.Down:
                    tempX = 0;
                    tempY = 50;
                    break;
                case Keys.A:
                case Keys.Left:
                    tempX = -50;
                    tempY = 0;
                    break;
                default:
                    tempX = 0;
                    tempY = 0;
                    break;
            }

            //проверяем попадение героя, при изменении координат, на другие сущности
            bool conformity = true;
            foreach (var e in Entities)
            {
                if (((Hero.Location.X + tempX) == e.Location.X) && ((Hero.Location.Y + tempY) == e.Location.Y))
                {
                    if (e is EntityEnemy && !(e as EntityEnemy).IsAlive())
                        continue;
                    if (e is EntityNotAlive && (e as EntityNotAlive).CanBePassed)
                        continue;
                    conformity = false;
                    break;
                }
            }

            if (conformity == true)
            {
                Hero.Move(tempX, tempY);
            }
        }
        
#endregion

        /// <summary>
        /// Проверка наличия живых противков 
        /// </summary>
        private void CheckAliveEnemiesCount()
        {
            int KilledEnemies = 0;
            foreach (var e in Enemy)
            {
                if (!e.IsAlive())
                {
                    KilledEnemies++;
                }
                if (e.IsAlive() && (EnemiesLeft == 1))
                {                    
                    Key.Location = e.Location;
                }
            }
            EnemiesLeft = Enemy.Count - KilledEnemies;

            if (EnemiesLeft==0)
            {
                Key.IsEnabledToDrop = true;
            }
        }

        /// <summary>
        /// Интеллект врагов
        /// </summary>
        private void EnemiesThink()
        {
            if (Enemy.Count > 0)
            {
                foreach (var e in Enemy)
                {
                    if (e.IsAlive())
                    {
#warning Logic is not working here!!!!!!
                        if (CheckforEnemies(e))
                        {
                            e.Attack(Hero);
                            Form.textBoxLog.Text += e.Message + Environment.NewLine;
                        }
                    }
                    else
                    {
                        e.PictureBox.Visible = false;
                    }
                }
            }
        }

        /// <summary>
        /// Фунция подбора предметов(конкртено ключ,функционал можно расширить)
        /// </summary>
        private void LootItems()
        {
            // Заготовка на будущее
            //List<EntityNotAlive> PossibleLoot = new List<EntityNotAlive>();

            int X = Hero.Location.X;
            int Y = Hero.Location.Y;
            // Соседние для героя клетки
            Point[] Cells = new Point[4];
            Cells[0] = new Point(X, Y - 50); // сверху
            Cells[1] = new Point(X + 50, Y); // справа
            Cells[2] = new Point(X, Y + 50); // снизу
            Cells[3] = new Point(X - 50, Y); // слева

            for (int i = 0; i < Cells.Length; i++)
            {
                foreach (var e in Entities)
                {
                    if (!(e is EntityAlive) && !(e is EntityTree) && e.Location == Cells[i])
                    {
                        if (e is EntityKey && !Hero.HasKey)
                        {
                            Hero.HasKey = true;
                            Key.IsObtainedByHero = true;
                            return;
                        }
                        if (e is EntityTreasure && Hero.HasKey)
                        {
                            Treasure[Treasure.Count - 1].IsOpened = true;
                            return;
                        }
                    }
                }
            }
            
        }

        /// <summary>
        /// Проверка наличия противников на соседних с сущностью клетках
        /// </summary>
        /// <returns> True - если противники есть, иначе - false </returns>
        private bool CheckforEnemies(EntityAlive entity)
        {
            int X = entity.Location.X;
            int Y = entity.Location.Y;
            // Соседние для героя клетки
            Point[] Cells = new Point[4];
            Cells[0] = new Point(X, Y - 50); // сверху
            Cells[1] = new Point(X + 50, Y); // справа
            Cells[2] = new Point(X, Y + 50); // снизу
            Cells[3] = new Point(X - 50, Y); // слева

            EnemiesNear.Clear();
            bool conformity=false;

            List<EntityAlive> EntitiesTemp = new List<EntityAlive>();
            // Если метод вызван для героя
            if (entity is EntityHero)
            { 
                // Заполняем локальный список сущностей всеми противниками на карте
                foreach (var e in Enemy)
                {
                    EntitiesTemp.Add(e);
                }
            }
            // Если метод вызван для Enemy
            else
            {
                EntitiesTemp.Add(Hero);
            }

            for (int i = 0; i < Cells.Length; i++)
            {
                foreach (var e in EntitiesTemp)
                {
                    if (e.Location == Cells[i] && e.IsAlive())
                    {
                        conformity = true;
                        // Если метод вызван для героя - дополнить список противников рядом
                        if (entity is EntityHero)
                        {
                            EnemiesNear.Add(e as EntityEnemy);
                        }
                        break;
                    }
                }
            }            
            return conformity;
        }

        /// <summary>
        /// Генерация позиции для сущности
        /// </summary>
        /// <param name="e"> Сущность </param>
        private void GetLocationForEntity(Entity entity)
        {
            int MaxWidth = 0, MaxHeight = 0;
            MaxWidth = Field.Width / 50;
            MaxHeight = Field.Height / 50;

            label:
            Point p = new Point(rand.Next(1, MaxWidth) * 50, rand.Next(1, MaxHeight) * 50);

            foreach (var e in Entities )
            {
                if (e == entity)
                    continue;
                if (e.Location == p)
                {
                    goto label;
                }
            }

            entity.Location = p;
        }

#region initialization
        /// <summary>
        /// Инициализация препятствий(деревьев)
        /// </summary> 
        private void InitializationTree()
        {
           int a =  Field.Height / 50;
            int b = Field.Height / 50 + Field.Width/50;
            for (int i = 0; i < rand.Next(a,b); i++)
            {
                Tree.Add(new EntityTree(this));
                // Добавили в список всех сущностей последнего добавленного дерева
                Entities.Add(Tree[Tree.Count - 1]);
                GetLocationForEntity(Tree[Tree.Count - 1]);
            }
        }

        /// <summary>
        /// Инициализация противников
        /// </summary> 
        private void InitializationEnemy()
        {
            int a = Field.Height / (50*2);
            int b = Field.Height / 50;
            
            for (int i = 0; i < rand.Next(a,b+2); i++)
            {
                // Инициализация противников
                Enemy.Add(new EntityEnemy(this));
                // Добавили в список всех сущностей последнего добавленного противника
                Entities.Add(Enemy[Enemy.Count - 1]);
                GetLocationForEntity(Enemy[Enemy.Count - 1]);
            }
        }

        /// <summary>
        /// Инициализация cундука
        /// </summary> 
        private void InitializationTreasure()
        {
            Treasure.Add(new EntityTreasure(this));
            // Добавили в список всех сущностей последнего добавленного сундука
            Entities.Add(Treasure[Treasure.Count - 1]);
            GetLocationForEntity(Treasure[Treasure.Count - 1]);
        }

        /// <summary>
        /// Инициализация героя
        /// </summary>
        private void InitializationHero()
        {
            Hero = new EntityHero(this);
            Entities.Add(Hero);
            GetLocationForEntity(Hero);
        }

        /// <summary>
        /// Инициализация поля  
        /// </summary>
        private void InitializationField()
        {
            int Width = 500;
            int Height = 400;
            Field = new PictureBox();

            Field.Name = "pbField";
            Field.Location = new Point(0, 0);
           // Field.BackgroundImage=Image.FromFile(Environment.CurrentDirectory + @"\Field.jpg");
            Field.BackColor = Color.Tomato;
            Field.Width = Width;
            Field.Height = Height;   
        }

        /// <summary>
        ///  
        /// </summary>
        private void InitializationKey()
        {
            Key = new EntityKey(this);
            Entities.Add(Key);
            Key.Location = new Point(-50, -50);
        }
#endregion 

#region label
        /// <summary>
        /// Обновления информации о герое   
        /// </summary>
        private void UpdateLabelHeroInfo()
        {
            Form.labelHeroInfo.Text = "Здоровье героя " + Hero.HealthCurrent
                                + "/" + Hero.HealthMaximum;
            Form.labelHeroInfo.Text += (Hero.HasKey) ? ". Есть ключ." : "";
        }
        /// <summary>
        /// помощи игроку
        /// </summary>
        private void LabelHelp()
        {
            Form.labelHelp.Text = "Задача: Уничтожить всех врагов Дарта Вейдера в мире Майнкрафт,"+ Environment.NewLine
                                + "Остаться в живых,поднять выпавший ключ," + Environment.NewLine
                                + "              открыть сундук и забрать сокровища Майнкрафта!" + Environment.NewLine
                                + "Передвижение Вейдера осуществляется с помощью стрелок или WASD" + Environment.NewLine
                                + "F - атаковать " + Environment.NewLine
                                + "Space - поднять ключ" + Environment.NewLine;
        }
#endregion

#region game
        /// <summary>
        /// запуск игры 
        /// </summary>
        private void StartGame()
        {
            InitializationField();
           
            Enemy = new List<EntityEnemy>();
            EnemiesNear = new List<EntityEnemy>();
            Treasure = new List<EntityTreasure>();
            Tree = new List<EntityTree>();
            Entities = new List<Entity>();

            // Инициализация героя
            InitializationHero();

            // Инициализация сундука
            InitializationTreasure();

            // Инициализация ключа
            InitializationKey();

            // Инициализация препятствий(деревьев)
            InitializationTree();

            // Инициализация врагов
            InitializationEnemy();

            //Добавление сгенерированных сущностей на поле
            for (int i = 0; i < Entities.Count; i++)
            {
                Entities[i].SetImage();
                Field.Controls.Add(Entities[i].PictureBox);
            }
            Form.Controls.Add(Field);

            UpdateLabelHeroInfo();
        }

        
        /// <summary>
        /// рестарт игры 
        /// </summary>
        private void RestartGame()
        {
            Form.Controls.Remove(Field);
            Field.Controls.Clear();
            Form.textBoxLog.Clear();
            StartGame();
        }
        /// <summary>
        /// Конструктор Game 
        /// </summary>
        /// <param name="form"></param>
        public Game(ref RPGForm form)
        {
            this.Form = form;
            LabelHelp();
            
            //Form.checkBoxMusic.CheckedChanged +=checkBoxMusic_CheckedChanged;
            MusicCheck();
            rand = new Random();

            StartGame();
        }
        ////
        //private void checkBoxMusic_CheckedChanged(object sender, EventArgs e)
        //{
        //    MusicCheck();
        //}
        /// <summary>
        /// Воспроизведение музыки 
        /// </summary>
        private void MusicCheck()
        {
            //if (Form.checkBoxMusic.Checked)
            {
                Player = new SoundPlayer(Environment.CurrentDirectory + @"\game.wav");
                Player.Play();
            }
            //else
            //{
            //    Player.Stop();
            //}
        }

        /// <summary>
        /// Условие окончания игры
        /// </summary>
        /// <returns></returns>
        private bool EndGame()
        {
            return Treasure[Treasure.Count - 1].IsOpened;
        }

#endregion
    }
}