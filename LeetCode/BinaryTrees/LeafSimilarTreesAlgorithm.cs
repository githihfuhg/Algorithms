namespace Algorithms.LeetCode.BinaryTrees;

/// <summary>
/// Leaf-Similar Trees.
/// <see href="https://leetcode.com/problems/leaf-similar-trees"/>
/// </summary>
public class LeafSimilarTreesAlgorithm
{
    public bool LeafSimilar(TreeNode root1, TreeNode root2)
    {
        var firstLeafNodes = new List<TreeNode>();
        var secondLeafNodes = new List<TreeNode>();
        
        FindLeafNodes(root1, firstLeafNodes);
        FindLeafNodes(root2, secondLeafNodes);

        if (firstLeafNodes.Count != secondLeafNodes.Count)
        {
            return false;
        }

        for (var index = 0; index < firstLeafNodes.Count; index++)
        {
            var firstLeafNode = firstLeafNodes[index];
            var secondLeafNode = secondLeafNodes[index];

            if (firstLeafNode.val != secondLeafNode.val)
            {
                return false;
            }
        }

        return true;
    }

    private static void FindLeafNodes(TreeNode root, List<TreeNode> leafNodes)
    {
        if (root == null)
        {
            return;
        }

        if (root.left == null && root.right == null)
        {
            leafNodes.Add(root);
            return;
        }
        
        FindLeafNodes(root.left, leafNodes);
        FindLeafNodes(root.right, leafNodes);
    }
}