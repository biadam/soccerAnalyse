using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace soccerAnalyse
{
    class SoccerResultsData
    {
        private string _teamA;
        private string _teamB;
        private int _numberOfGoalsA;
        private int _numberOfGoalsB;

        private bool IsTeamNameValid(string teamName)
        {
           Regex regex = new Regex(@"^[A-Z]{1,50}$");
           Match match = regex.Match(teamName);
           if (match.Success)
             {
                return true;
            }
            throw new Exception("Der Teamname "+ teamName +" ist nicht gültig. Bitte prüfen Sie die Quelldatei!"); 
        }

        private bool IsGoalValueValid(int numberOfGoals,string teamName)
        {
            if (numberOfGoals >= 0 && numberOfGoals <= 20)
            {
                return true;
            }
            throw new Exception("Die Anzahl Tore für  " + teamName + " sind nicht gültig. Bitte prüfen Sie die Quelldatei!"); 
        }

        public string TeamA
        {
            get { return _teamA ;}
            set { _teamA = (IsTeamNameValid(value)) ? value : "";}
        }
        
        public string TeamB
        {
            get { return _teamB;  }
            set { _teamB = (IsTeamNameValid(value)) ? value :  ""; }
            
        }
        public int NumberOfGoalsA
        {
            get { return _numberOfGoalsA; }
            set { _numberOfGoalsA = (IsGoalValueValid(value, _teamA)) ? value :0;  }
        }
        public int NumberOfGoalsB
        {
            get { return _numberOfGoalsB; }
            set { _numberOfGoalsB = (IsGoalValueValid(value, _teamB)) ? value : 0; }
        }
    }
}
