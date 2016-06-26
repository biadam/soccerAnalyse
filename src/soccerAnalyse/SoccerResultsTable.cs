using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace soccerAnalyse
{
    /// <summary>
    /// List of Result Items
    /// Class to Serialize to XML
    /// </summary>
    [XmlRoot("SoccerResultsTable")]  
    public class SoccerResultsTable
    {
        [XmlArray("Teams"), XmlArrayItem(typeof(SoccerResultsItem), ElementName = "Team")]
        public List<SoccerResultsItem> ResultsTableList { get; set; }
    }
}
