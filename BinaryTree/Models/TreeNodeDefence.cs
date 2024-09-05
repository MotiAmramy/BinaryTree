using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.Models
{
    internal class TreeNodeDefence
    {
        public Defence Value { get; set; }
        public int Height { get; set; } = 1;
        public string Dir { get; set; }
        public TreeNodeDefence? Left { get; set; }
        public TreeNodeDefence? Right { get; set; }

    }
    internal class BSTree
    {
        private TreeNodeDefence? root;
        public void Insert(Defence value)
        {
            // Use a helper method for the recursive implementation
            root = InsertRecursive(root, value, height: 0, dir: "root--");
        }


        private TreeNodeDefence? InsertRecursive(TreeNodeDefence? node, Defence value, int height, string dir)
        {
            // Base case: if the node is null, create a new node with the given value
            height += 1;
            if (node == null)
            {

                return new TreeNodeDefence()
                {
                    Value = value,
                    Height = height,
                    Dir = dir
                };
            }

            //If the value already exists, don't insert it again
            if (node.Value.MinSeverity == value.MinSeverity)
            {
                node.Right = InsertRecursive(node.Right, value, height, dir);
            }

            // Recursively insert into the left subtree if the value is smaller
            if (node.Value.MinSeverity > value.MinSeverity)
            {
                dir += "--left--";
                node.Left = InsertRecursive(node.Left, value, height, dir);
            }
            // Recursively insert into the right subtree if the value is larger
            else if (node.Value.MinSeverity < value.MinSeverity)
            {
                dir += "--right--";
                node.Right = InsertRecursive(node.Right, value, height, dir);
            }

            // Return the (unchanged) node pointer
            return node;
        }



        public List<TreeNodeDefence> PreOrderTraversal() => PreOrderTraversalHelper(root);
        private List<TreeNodeDefence> PreOrderTraversalHelper(TreeNodeDefence? node)
        {
            // Base case: if the current node is null, return an empty list
            if (node == null) { return []; }

            // Create a list with the current node's value
            var currentNodeList = new List<TreeNodeDefence> { node };

            // Recursively get the list from the left subtree
            var leftSubtreeList = PreOrderTraversalHelper(node.Left);

            // Recursively get the list from the right subtree
            var rightSubtreeList = PreOrderTraversalHelper(node.Right);
            // Combine all lists: current node, left subtree, and right subtree
            return [.. currentNodeList, .. leftSubtreeList, .. rightSubtreeList];
        }

        public void PreOrderTraversalSearchHelper(int Threat) => PreOrderTraversalSearch(root, Threat);
        public void PreOrderTraversalSearch(TreeNodeDefence Node, int Threat)
        {

            if (Node == null)
            {
                Console.WriteLine("No suitable defence was found. Brace for impact!");
                return;
            }


            if (Threat <= Node.Value.MaxSeverity && Threat >= Node.Value.MinSeverity)
            {
                foreach (var item in Node.Value.Defenses)
                {
                    Console.WriteLine(item);
                    Thread.Sleep(2000);
                }

            }
            else if (Threat < Node.Value.MinSeverity)
            {
                PreOrderTraversalSearch(Node.Left, Threat);

            }
            else if (Threat > Node.Value.MaxSeverity)
            {
                PreOrderTraversalSearch(Node.Right, Threat);
            }


        }
        public int FindMinSearchHelper() => FindMinSeverity(root);

        public int FindMinSeverity(TreeNodeDefence node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node.Value.MinSeverity;
        }

    }
}
