using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ostranauts_Ship_Importer
{
    internal class SaveInfo
    {
        public string strName { get; set; }
        public string playerName { get; set; }
        public string shipName { get; set; }
        public string formerOccupation { get; set; }
        public string version { get; set; }
        public float age { get; set; }
        public float money { get; set; }
        public float playTimeElapsed { get; set; }
        public float simTimeElapsed { get; set; }
        public float simTimeCurrent { get; set; }
        public string realWorldTime { get; set; }
        public long epochCreationTime { get; set; }
        public string seedId { get; set; }
        public int autoSaveCounter { get; set; }
        public string strSaveLog { get; set; }
    }
}
