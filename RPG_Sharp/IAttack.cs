using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Sharp
{
    /// <summary>
    /// Способность атаковать (наносить урон)
    /// </summary>
    interface IAttack
    {
        /// <summary>
        /// Наносимый урон
        /// </summary>
        int Damage { get; set; }

        /// <summary>
        /// Персонаж бьёт противника
        /// </summary>
        /// <param name="opponent">Противник, получающий урон</param>
        void Attack(EntityAlive opponent);
    }
    
}
