﻿using System;
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
        int Damage { get; set; }
        void Attack(EntityAlive opponent);
    }
    
}
