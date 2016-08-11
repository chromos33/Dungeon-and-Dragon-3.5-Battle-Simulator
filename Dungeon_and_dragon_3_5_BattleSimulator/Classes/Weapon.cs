using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_and_Dragon_3_5_BattleSimulator.Classes
{
    public class Weapon
    {
        public string name;
        public int Dice;
        public bool twohanded;
        public bool range;
        public int attackrange;
        public int bonusdamage;
        public bool is_primary = false;

        public Weapon(string _name, int _dice, int _bonusdamage = 0, bool _twohanded = false, bool _range = false, int _attackrange = 0)
        {
            name = _name;
            Dice = _dice;
            twohanded = _twohanded;
            range = _range;
            attackrange = _attackrange;
            bonusdamage = _bonusdamage;
        }
        public override string ToString()
        {
            return name;
        }
    }
}
