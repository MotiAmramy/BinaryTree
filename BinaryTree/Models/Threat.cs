using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.Models
{
    internal class Threat
    {
        public string ThreatType {  get; set; }
        public int Volume { get; set; }
        public int Sophistication { get; set; }
        public string Target { get; set; }

        public int TargetValue()
        {
            switch (Target)
            {
                case "Web Server":
                    return 10;
                case "Database":
                    return 15;
                case "User Credentials":
                    return 20;
                    default:
                    return 5;
            }
        }

        public int Sevirity()
        {
            int severity = (Volume * Sophistication) + TargetValue();
            return severity;
        }
    }
}
