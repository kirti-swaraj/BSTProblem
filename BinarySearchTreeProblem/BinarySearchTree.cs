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
        public T NodeData { get; set; }
        public BinarySearchTree<T> LeftTree { get; set; }
        public BinarySearchTree<T> RightTree { get; set; }
        public BinarySearchTree(T nodeData)
        {
            this.NodeData = nodeData;
            this.LeftTree = null;
            this.RightTree = null;
        }
        int leftCount = 0, rightCount = 0;
        bool result = false;

        /// <summary>
        /// UC 1 : Inserts the item into the tree in inorder way
        /// </summary>
        /// <param name="item">The item.</param>
        public void Insert(T item)
        {
            T currentNodeValue = this.NodeData;
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
        /// Displays all values of BST
        /// </summary>
        public void Display()
        {
            if (this.LeftTree != null)
            {
                this.leftCount++;
                this.LeftTree.Display();
            }
            Console.WriteLine(this.NodeData.ToString());
            if (this.RightTree != null)
            {
                this.rightCount++;
                this.RightTree.Display();
            }
        }
    }
}