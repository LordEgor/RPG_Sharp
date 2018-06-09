using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Sharp
{
    
        interface IAttack
        {
            int Damage { get; set; }
            void Attack(EntityAlive opponent);
        }
    
}
