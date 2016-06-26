using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soccerAnalyse
{
    /// <summary>
    /// Class to write Item of ResultTable for each Team
    /// Includes Position, Teamname, Points an GoalRate
    /// </summary>
    public class SoccerResultsItem
    {
        private int _position;
        private string _teamName;
        private int _points;
        private int _goalRate;


        public int Position {
            get { return _position; } 
            set { _position = value; }
        }

        public string TeamName
        {
            get { return _teamName; }
            set { _teamName = value; }
        }
        public int Points
        {
            get { return _points; }
            set { _points = value;  }
        }
        public int GoalRate{
            get { return _goalRate; }
            set { _goalRate = value; } 
        }


    }
}
