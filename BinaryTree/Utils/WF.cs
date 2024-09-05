using BinaryTree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.Utils
{
    internal static class WF
    {
        public static void SearchTheThreatToDefence(BSTree BST, int Threat)
        {

            if (BST.FindMinSearchHelper() > Threat)
            {
                Console.WriteLine("Attack severity is below the threshold. Attack is ignored");
                return;
            }
            BST.PreOrderTraversalSearchHelper(Threat);

        }



        public static void InsertFromJsonToTree(List<Defence> defences, BSTree TN)
        {
            foreach (var item in defences)
            {
                TN.Insert(item);
            }
        }

        public static void PrintInPreOrder(List<TreeNodeDefence> TND)
        {
            foreach (var item in TND)
            {

                Console.WriteLine($"{item.Dir}{item.Value.ToString()}");
            }
        }

        public static void PrintAllSearchTheThreatToDefence(BSTree TN, List<Threat>? allAttack)
        {
            foreach (var item in allAttack)
            {
                SearchTheThreatToDefence(TN, item.Sevirity());
            }

        }
    }
}
