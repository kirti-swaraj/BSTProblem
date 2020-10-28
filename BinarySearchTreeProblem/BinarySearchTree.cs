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