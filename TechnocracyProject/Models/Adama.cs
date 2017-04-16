using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnocracyProject
{
    

    /// <summary>
    /// the character class the player uses in the game
    /// </summary>
    public class Adama : Character
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
        #region ENUMERABLES
        public enum WeaponType
        {
            NONE,
            PHASER,
            PLASMARIFLE,
            ATOMICMINE
        }

        #endregion

        #region FIELDS
        // TODO: Planet, Galaxy, and Dimension do not show up in Adama info menu 
        private Planet _homeWorld;
        private Galaxy _homeGalaxy;
        private Dimension _homeDimension;
        private int _rank = 1; //TODO: implement. Just issue default rank.
        private string _rankPrefix = "X"; //TODO: implement a rank string to prefix to the numerical rank.
        private bool _discharged;
        private TimeSpan _missionTime; //TODO: Implement Adama._missionTime.
        private WeaponType _weapon;
        private int _experiencePoints;
        private int _health;
        private int _lives;
        protected int _spaceTimeLocationId;
        private List<int> _spaceTimeLocationsVisited;
        private List<TravelerObject> _inventory;

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

        public bool Discharged
        {
            get { return _discharged; }
            set { _discharged = value; }
        }

        public TimeSpan MissionTime
        {
            get { return _missionTime; }
            set { _missionTime = value; }
        }

        public WeaponType Weapon
        {
            get { return _weapon; }
            set { _weapon = value; }
        }

        public int SpaceTimeLocationId
        {
            get { return _spaceTimeLocationId; }
            set { _spaceTimeLocationId = value; }
        }

        public List<TravelerObject> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }
        #endregion


        #region CONSTRUCTORS

        public Adama()
        {
            _spaceTimeLocationsVisited = new List<int>();
            _inventory = new List<TravelerObject>();
        }

        public Adama(string name, RaceType race, int spaceTimeLocationID) : base(name, race, spaceTimeLocationID)
        {
            _spaceTimeLocationsVisited = new List<int>();
            _inventory = new List<TravelerObject>();
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
