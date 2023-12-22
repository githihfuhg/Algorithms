namespace Algorithms.LeetCode.BinaryTrees;

/// <summary>
/// Maximum Depth of Binary Tree.
/// <see href="https://leetcode.com/problems/maximum-depth-of-binary-tree"/>
/// </summary>
public class MaximumDepthOfBinaryTreeAlgorithm
{
    public int MaxDepth(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }

        var leftDepth = MaxDepth(root.left);
        var rightDepth = MaxDepth(root.right);

        var result = Math.Max(leftDepth, rightDepth) + 1;

        return result;
    }
}