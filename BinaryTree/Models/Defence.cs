using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.Models
{
    internal class Defence
    {
        public int MinSeverity { get; set; }
        public int MaxSeverity { get; set; }
        public List<string> Defenses { get; set; }

        public override string ToString()
        {
            return $"[{MinSeverity}-{MaxSeverity} " +
                $"Defenses: {string.Join(",", Defenses)}";
        }

    }
}
