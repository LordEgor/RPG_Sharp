
namespace RPG_Sharp
{
    /// <summary>
    /// Неодушевлённые сущности
    /// </summary>
    abstract class EntityNotAlive : Entity
    {
        /// <summary>
        /// Можно ли попасть на клетку с этим объектом
        /// </summary>
        public bool CanBePassed { get; set; }
        public EntityNotAlive(Game game, string name)
            : base(game, name)
        {
            this.CanBePassed = false;
        }
    }
}