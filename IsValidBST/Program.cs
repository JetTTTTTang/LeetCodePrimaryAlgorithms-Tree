using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsValidBST
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode n1 = new TreeNode(10);
            TreeNode n2 = new TreeNode(5);
            TreeNode n3 = new TreeNode(15);
            TreeNode n4 = new TreeNode(6);
            TreeNode n5 = new TreeNode(20);
            n1.left = n2;
            n1.right = n3;
            n3.left = n4;
            n3.right = n5;
            Solution solution = new Solution();
            solution.IsValidBST(n1);
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Solution
    {
        public bool IsValidBST(TreeNode root)
        {
            List<int> values = new List<int>();
            Stack<TreeNode> treeNodes = new Stack<TreeNode>();
            while(root != null || treeNodes.Count != 0)
            {
                if(root != null)
                {
                    treeNodes.Push(root);
                    root = root.left;
                }
                else
                {
                    root = treeNodes.Pop();
                    values.Add(root.val);
                    root = root.right;
                }
            }

            for (int i = 1; i < values.Count; i++)
            {
                if (values[i] <= values[i - 1])
                    return false;
            }

            return true;
        }

#if false

        List<int> intList = new List<int>();

        public bool IsValidBST(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            if (root.left != null)
            {
                if(!IsValidBST(root.left))
                    return false;
                if (intList[intList.Count - 1] < root.val)
                    intList.Add(root.val);
                else
                    return false;
            }
            else
            {
                if (intList.Count == 0 || intList[intList.Count - 1] < root.val)
                    intList.Add(root.val);
                else
                    return false;
            }

            if (root.right != null)
            {
                if (!IsValidBST(root.right))
                    return false;
            }
            else
                return true;

            return true;
        }
#endif
    }
}
