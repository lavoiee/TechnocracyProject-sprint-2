using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnocracyProject
{
    public enum Dimension { None, A1, A2, A3, A4 };
    public enum Galaxy
    {
        None,
        MilkyWay,
        Andromeda,
        Pegasus,
        Aquarius,
        Atlantis
    }

    public enum Planet
    {
        None,
        Earth,
        Caledan,
        GiediPrime,
        Kaitain
    }

    /// <summary>
    /// the character class the player uses in the game
    /// </summary>
    public class Adama : Character
    {
        #region ENUMERABLES


        #endregion

        #region FIELDS
        private Planet _homeWorld;
        private Galaxy _homeGalaxy;
        private Dimension _homeDimension;
        private int _rank = 1; //TODO: implement. Just issue default rank.
        private string _rankPrefix = "X"; //TODO: implement a rank string to prefix to the numerical rank.
        private bool _alive;
        private TimeSpan _timeAlive; //TODO: Implement Adama._timeAlive.

        private int _experiencePoints;
        private int _health;
        private int _lives;
        private List<int> _spaceTimeLocationsVisited;
        #endregion


        #region PROPERTIES
        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set { _experiencePoints = value; }
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public int Lives
        {
            get { return _lives; }
            set { _lives = value; }
        }

        public List<int> SpaceTimeLocationsVisited
        {
            get { return _spaceTimeLocationsVisited; }
            set { _spaceTimeLocationsVisited = value; }
        }

        public Planet HomeWorld
        {
            get { return _homeWorld; }
            set { _homeWorld = value; }
        }

        public Galaxy HomeGalaxy
        {
            get { return _homeGalaxy; }
            set { _homeGalaxy = value; }
        }

        public Dimension HomeDimension
        {
            get { return _homeDimension; }
            set { _homeDimension = value; }
        }

        public int Rank
        {
            get { return _rank; }
            set { _rank = value; }
        }

        public string RankPrefix
        {
            get { return _rankPrefix; }
            set { _rankPrefix = value; }
        }

        public bool Alive
        {
            get { return _alive; }
            set { _alive = value; }
        }

        public TimeSpan TimeAlive
        {
            get { return _timeAlive; }
            set { _timeAlive = value; }
        }
        #endregion


        #region CONSTRUCTORS

        public Adama()
        {
            _spaceTimeLocationsVisited = new List<int>();
        }

        public Adama(string name, RaceType race, int spaceTimeLocationID) : base(name, race, spaceTimeLocationID)
        {
            _spaceTimeLocationsVisited = new List<int>();
        }

        #endregion


        #region METHODS
        public bool HasVisited(int _spaceTimeLocationID)
        {
            if (SpaceTimeLocationsVisited.Contains(_spaceTimeLocationID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
