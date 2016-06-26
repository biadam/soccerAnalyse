using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace soccerAnalyse
{
    /// <summary>
    /// Class to Analyse Soccer Data
    /// Read Input File and write Results to SoccerResultsData
    /// Parse List of SoccerResultsData and write Points and Teams to SoccerResultsTable
    /// Order List and set Position of Each Team
    /// Include Function to write result Table to XML File
    /// </summary>
    
    class AnaylseSoccerData
    {
        private const int winningPoints = 2;
        private const int equalPoint = 1; 
        private const int loosingPoint = 0;

        private List<SoccerResultsData> _soccerResultDataList = new List<SoccerResultsData>();
        private List<SoccerResultsItem> _soccerResultTableList = new List<SoccerResultsItem>();

        public List<SoccerResultsItem> GetSoccerResultTableList()
        {
            return _soccerResultTableList;
        }

        // read the file and if success parse the results and create the table
        public bool AnalyseFile(string fullFileName, out string resultMsg)
        {
            if (!ReadFile(fullFileName, out resultMsg))
            {
                return false;
            }
            return ParseResults(_soccerResultDataList);
        }

        private bool ReadFile(string fullFileName, out string resultMsg)
        {
            var resultCode = true;
            resultMsg = "";

            if (!File.Exists(fullFileName))
            {
                resultMsg = "Die Angegebene Datei existiert nicht. Bitte prüfen Sie Ihre Auswahl.";
                return false;
            }
            try
            {
                _soccerResultDataList.Clear();
                _soccerResultTableList.Clear();
                using (StreamReader sr = new StreamReader(fullFileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {

                        //Input String vorbereiten
                        line = line.Replace('"', ' ');
                        line = line.TrimStart();
                        line = line.TrimEnd();
                        line = line.Replace(" ", "\t");

                        var soccerResultsDataArr = line.Split('\t');
                        if (soccerResultsDataArr.Length > 3)
                        {
                            var soccerResultsData = new SoccerResultsData()
                            {
                                TeamA = soccerResultsDataArr[0],
                                TeamB = soccerResultsDataArr[1],
                                NumberOfGoalsA = Convert.ToInt16(soccerResultsDataArr[2]),
                                NumberOfGoalsB = Convert.ToInt16(soccerResultsDataArr[3])
                            };
                            _soccerResultDataList.Add(soccerResultsData);
                        }
                    }

                }
            }
            catch (Exception e)
            {
                resultMsg = "Beim Einlesen der Datei ist ein Fehler aufgetreten. Bitte prüfen Sie die Datei.\nFehlercode: " + e.Message;
                return false;
            }
            return resultCode;
        }

        //parse result Data and set points and goalRate for each Team
        public bool ParseResults(List<SoccerResultsData> soccerResultDataList)
        {
            try { 
                bool resultVal = true;
                var soccerResultTable = new SoccerResultsItem();
            
                foreach (var soccerResultData in _soccerResultDataList) {
                    var diff = soccerResultData.NumberOfGoalsA - soccerResultData.NumberOfGoalsB;
                    diff = (diff==0) ? 0 : (diff < 0 ) ? -1 : 1;
                    switch (diff) {
                        //unentschieden
                        case  0 :
                            SetPointsAnGoalRateToTeam(soccerResultData.TeamA, equalPoint, soccerResultData.NumberOfGoalsA);
                            SetPointsAnGoalRateToTeam(soccerResultData.TeamB, equalPoint, soccerResultData.NumberOfGoalsB);
                            break;
                        //Win TeamB
                        case -1:
                            SetPointsAnGoalRateToTeam(soccerResultData.TeamB, winningPoints, soccerResultData.NumberOfGoalsB);
                            SetPointsAnGoalRateToTeam(soccerResultData.TeamA, loosingPoint, soccerResultData.NumberOfGoalsA);
                            break;
                        //Win TeamA
                        case 1:
                            SetPointsAnGoalRateToTeam(soccerResultData.TeamA, winningPoints, soccerResultData.NumberOfGoalsA);
                            SetPointsAnGoalRateToTeam(soccerResultData.TeamB, loosingPoint, soccerResultData.NumberOfGoalsB);
                            break;
                    }
                }

                CalculatePosition();

                return resultVal;
                }
            catch (Exception ex)
            {
                throw new Exception("Beim Analysieren der Ergebnisse ist ein Fehler aufgetreten. Bitte prüfen Sie die Eingabedatei." + 
                    Environment.NewLine + " Fehlercode: " + ex.Message);
            }
        }

        // write all results to XML File
        public bool WriteDataToFile(string fullFileName)
        {
            try { 
                XmlSerializer ser = new XmlSerializer(typeof(SoccerResultsTable));
                SoccerResultsTable soccerResultsTableList = new SoccerResultsTable();
                soccerResultsTableList.ResultsTableList = _soccerResultTableList;

                using (FileStream fs = new FileStream(fullFileName, FileMode.Create))
                {
                    ser.Serialize(fs, soccerResultsTableList);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Beim Schreiben der Ergebnisse ist ein Fehler aufgetreten." +
                   Environment.NewLine + " Fehlercode: " + ex.Message);
            }

        }

        // set points and goals to Team
        private void SetPointsAnGoalRateToTeam(string teamName, int points, int goals){
            int index = _soccerResultTableList.FindIndex ( x => x.TeamName.Equals(teamName) );
            if (index == -1)
            {
                //Team does not exists in Table => create Team in List
                _soccerResultTableList.Add(new SoccerResultsItem()
                {
                    TeamName = teamName,
                    Points = points,
                    GoalRate = goals
                });
            }
            else
            {
                //Update Points of Team
                _soccerResultTableList[index].Points += points;
                _soccerResultTableList[index].GoalRate += goals;
            }
        }

        // analyse points and goals and set the position for each team
        private void CalculatePosition()
        {
            try { 
                //get the Team with most points, then with best GoalRate
                var sortedList = _soccerResultTableList.OrderByDescending(item => item.Points).ThenByDescending(item => item.GoalRate);
                var position = 1;
                SoccerResultsItem lastItem = null;
                foreach (var resultTableItem in sortedList)
                {
                    if (lastItem != null && 
                        resultTableItem.GoalRate == lastItem.GoalRate &&
                        resultTableItem.Points == lastItem.Points)
                    {
                        //Equality of Points and GoalRate => SamePosition
                        position = lastItem.Position;
                    }
                    resultTableItem.Position = position;
                    position++;
                    lastItem = resultTableItem;
                }
                _soccerResultTableList = sortedList.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Beim Berechnen der Ergebnisstabelle ist ein Fehler aufgetreten." +
                    Environment.NewLine + " Fehlercode: " + ex.Message);
            }
        }
    }
}
