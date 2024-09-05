using BinaryTree.Models;
using BinaryTree.Utils;
using static BinaryTree.Utils.WF;

namespace BinaryTree;
internal class Program
{
    static void Main(string[] args)
    {
        string PathForDefenceJson = "C:\\Users\\poly7\\source\\repos\\BinaryTree\\BinaryTree\\Jsons\\Defence.json";
        string PathForThreatJson = "C:\\Users\\poly7\\source\\repos\\BinaryTree\\BinaryTree\\Jsons\\Threat.json";
        string PathForDefenceStrategies = "C:\\Users\\poly7\\source\\repos\\BinaryTree\\BinaryTree\\Jsons\\DefenceStrategies.json";

        // 1. ייבוא קובץ גייסון של הגנות

        List<Defence>? allDefences = ManipulateJson.ReadFromJsonAsync<List<Defence>>(PathForDefenceJson);
        
        // 2. ייבוא קובץ גייסון של התקפות

        List<Threat>? allAttack = ManipulateJson.ReadFromJsonAsync<List<Threat>>(PathForThreatJson);

        // 3. הדפסת עץ הבינארי של ההגנות

        BSTree TN = new();
        InsertFromJsonToTree(allDefences, TN);
        var ListOfDefences = TN.PreOrderTraversal();
        PrintInPreOrder(ListOfDefences);
        // 4. חישוב חומרה של התקפה מתבצעת במודל ההתקפות

        // 5. מתודת חיפוש לסיכול התקפה בעזרת הגנה ראוייה
        int RandomAttack = allAttack[1].Sevirity();
        SearchTheThreatToDefence(TN, RandomAttack);
       
    }

}






