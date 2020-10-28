// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BinarySearchTree.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kirti Swaraj"/>
// --------------------------------------------------------------------------------------------------------------------


namespace BinarySearchTreeProblem
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Text;
    class BinarySearchTree<T> where T : IComparable<T>
    {
        public T RootNodeData { get; set; }
        public BinarySearchTree<T> LeftTree { get; set; }
        public BinarySearchTree<T> RightTree { get; set; }
        public BinarySearchTree(T RootNodeData)
        {
            this.RootNodeData = RootNodeData;
            this.LeftTree = null;
            this.RightTree = null;
        }
        /// <summary>
        /// The two variables store the count of nodes in the left and right trees
        /// of the parent root node while we traverse the BST
        /// </summary>
        static int leftCount = 0, rightCount = 0;
        bool result = false;

        /// <summary>
        /// UC 1 : Inserts the item into the tree in inorder way
        /// </summary>
        /// <param name="item">The item.</param>
        public void Insert(T item)
        {
            T currentNodeValue = this.RootNodeData;
            if (currentNodeValue.CompareTo(item) > 0)
            {
                if (this.LeftTree == null)
                    this.LeftTree = new BinarySearchTree<T>(item);
                else
                    this.LeftTree.Insert(item);
            }
            else
            {
                if (this.RightTree == null)
                    this.RightTree = new BinarySearchTree<T>(item);
                else
                    this.RightTree.Insert(item);
            }
        }
        /// <summary>
        /// UC 2 : Gets the size and display.
        /// </summary>
        public void GetSizeAndDisplay()
        {
            Console.WriteLine("Elements of tree in sorted order:");
            Display();
            /// Size will be equal to total nodes present in left subtree + right subtree + parent node
            Console.WriteLine("Size of the BST: " + (1 + leftCount + rightCount));
        }
        /// <summary>
        /// UC 3 : Checks for the element If it exists.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="tree">The node.</param>
        /// <returns>true if it is present else false</returns>
        public bool IfExists(T element, BinarySearchTree<T> tree)
        {
            /// If no node is present in the tree
            if (tree == null)
            {
                return false;
            }
            /// If at any subtree the rootNode data equals the element we are searching for
            if (tree.RootNodeData.Equals(element))
            {
                Console.WriteLine("Found the element in BST: " + tree.RootNodeData);
                result = true;
            }
            else
            {
                /// Showing how the tree is being traversed while searching for the entered element
                Console.WriteLine("Traversing the BST: Current element is {0} in BST", tree.RootNodeData);
            }
            /// Recursion to traverse the whole BST
            if (element.CompareTo(tree.RootNodeData) < 0)
            {
                IfExists(element, tree.LeftTree);
            }
            if (element.CompareTo(tree.RootNodeData) > 0)
            {
                IfExists(element, tree.RightTree);
            }
            return result;
        }


        /// <summary>
        /// Displays all values of BST
        /// </summary>
        public void Display()
        {
            if (this.LeftTree != null)
            {
                /// Incrementing leftcount value to signify presence of each node present in the left subtree 
                /// of parent node to ultimately give number of nodes present in the left subtree
                leftCount++;
                this.LeftTree.Display();
            }
            /// Prints the value of the current root node while recursion
            Console.WriteLine(this.RootNodeData.ToString());

            /// Traverses the right subtree to reach the leaf node and start printing
            if (this.RightTree != null)
            {
                rightCount++;
                this.RightTree.Display();
            }
        }
    }
}