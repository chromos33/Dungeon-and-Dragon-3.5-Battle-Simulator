using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_and_Dragon_3_5_BattleSimulator.Classes
{
    public class Armor
    {
        int iArmorClass;
        int imovementrestriction;
        string sname;

        public int iAC
        {
            get { return iArmorClass; }
            set { iArmorClass = value; }
        }
        public int iMovementRestriction
        {
            get { return imovementrestriction; }
            set { imovementrestriction = value; }
        }
        public string sName
        {
            get { return sname; }
            set { sname = value; }
        }

        public Armor(int _iArmorClass, int _iMovementRestriction, string _sName)
        {
            iArmorClass = _iArmorClass;
            imovementrestriction = _iMovementRestriction;
            sname = _sName;
        }

        public int MovementRestriction()
        {
            int iMR = imovementrestriction;
            // use here to add Functionality for MovementRestriction
            return iMR;
        }
        public override string ToString()
        {
            return sName;
        }
    }
}
