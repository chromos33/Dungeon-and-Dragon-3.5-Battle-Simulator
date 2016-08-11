using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_and_Dragon_3_5_BattleSimulator.Classes
{
    public class BattleField
    {
        List<Character> Characters;
        List<Point> MapConfig;
        Random randomenerator;
        string sname;
        public void RemoveCharacter(int index)
        {
            Characters.RemoveAt(index);
            return;
        }
        public BattleField(Random randomizer, List<Point> _battlefieldconfig)
        {

            randomenerator = randomizer;
            Characters = new List<Character>();
            MapConfig = _battlefieldconfig;
        }
        public BattleField()
        {

        }
        public List<Point> mapconfig
        {
            get { return MapConfig; }
            set { MapConfig = value; }
        }
        public string sName
        {
            get { return sname; }
            set { sname = value; }
        }
        public override string ToString()
        {
            return sName;
        }
        public bool CheckIfAlreadyExistant(Point point)
        {
            IEnumerable<Point> movementpoints = MapConfig.Where(x => x.X == point.X && x.Y == point.Y);
            return false;
        }
        public void addCharacter(Character character, int _x = -1, int _y = -1)
        {
            if (Characters == null)
            {
                Characters = new List<Character>();
            }
            if (_x == -1 && _y == -1)
            {
                if (Characters.Count > 0)
                {
                    bool positionoccupied = false;
                    Point position = null;
                    while (true)
                    {
                        position = MapConfig.ElementAt(randomenerator.Next(MapConfig.Count));
                        foreach (Character Character in Characters)
                        {
                            if (Character.isOccupied(position))
                            {
                                positionoccupied = true;
                            }
                        }
                        if (!positionoccupied)
                        {
                            break;
                        }
                    }
                    character.setPosition(position);
                    character.setBattlefield(this);
                    Characters.Add(character);
                }
                else
                {
                    character.setPosition(MapConfig.ElementAt(randomenerator.Next(MapConfig.Count)));
                    character.setBattlefield(this);
                    Characters.Add(character);
                }
            }
            else
            {
                Point pos = new Point(_x, _y);
                character.setPosition(pos);
                character.setBattlefield(this);
                Characters.Add(character);
            }

        }
        public List<Character> getCharacters()
        {
            return Characters;
        }
        public bool isMovable(Point _point, Point _origin)
        {
            //TODO isDiagonal truly possible (check adjacend fields for existance)
            IEnumerable<Point> mapconfigqueryresult = MapConfig.Where(x => x.X == _point.X && x.Y == _point.Y);
            bool result = false;
            if (mapconfigqueryresult.Count() > 0)
            {
                result = true;
                if (_point.isOnField(_origin))
                {
                    result = false;
                }
                if (isDiagonal(_point, _origin))
                {
                    IEnumerable<Point> mapconfigquerydiagonalresult = MapConfig.Where(x => x.X == _point.X && x.Y == _origin.Y || x.X == _origin.X && x.Y == _point.Y);
                    if (mapconfigquerydiagonalresult.Count() == 0)
                    {
                        result = false;
                    }
                }
                if (result)
                {
                    IEnumerable<Character> characterqueryresult = Characters.Where(x => x.getPoint().X == _point.X && x.getPoint().Y == _point.Y);
                    if (characterqueryresult.Count() > 0)
                    {
                        result = false;
                    }
                }
            }
            return result;
        }
        public bool isDiagonal(Point p1, Point p2)
        {
            if (p1.Distance(p2) > 1)
            {
                return true;
            }
            return false;
        }
        public Tuple<int, int> getDimensions()
        {


            int width = 0;
            int height = 0;
            foreach (Point point in MapConfig)
            {
                if (width < point.X)
                {
                    width = point.X;
                }
                if (height < point.Y)
                {
                    height = point.Y;
                }
            }
            width += 2;
            height += 2;

            return new Tuple<int, int>(width, height);
        }
    }
}
