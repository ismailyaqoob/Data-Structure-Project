﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeSort
{
    class BinarySearchTree
    {
        BSTNode root;
        int count;
        public BinarySearchTree()
        {
            //set root to null
            root = null;
        }
        //Adding data in BST
        public void Add(int data)
        {
            BSTNode newnode = new BSTNode();
            newnode.data = data;
            if (root == null)
            {
                root = newnode;
                count = count++;
            }
            else
            {
                BSTNode n;
                n = root;
                while (n != null)
                {
                    if (data < n.data)
                    {
                        if (n.leftnode == null)
                        {
                            n.leftnode = newnode;
                            count = count++;
                            break;
                        }
                        else
                        {
                            n = n.leftnode;
                        }
                    }
                    else if (data > n.data)
                    {
                        if (n.rightnode == null)
                        {
                            n.rightnode = newnode;
                            count = count++;
                            break;
                        }
                        else
                        {
                            n = n.rightnode;
                        }
                    }
                    else
                    {
                        break;
                    }

                }
            }
        }
        //Returning inordered data that is, left root right
        public int[] Inorder()
        {
            List<int> datalist = new List<int>();
            Inorder(root, datalist);
            return datalist.ToArray();
        }
        private void Inorder(BSTNode node, List<int> datalist)
        {
            if (node != null)
            {
                Inorder(node.leftnode, datalist);
                datalist.Add(node.data);
                Inorder(node.rightnode, datalist);
            }
        }
        //Returning preordered data that is, root left right
        public int[] Preorder()
        {
            List<int> datalist = new List<int>();
            Preorder(root, datalist);
            return datalist.ToArray();
        }
        private void Preorder(BSTNode node, List<int> datalist)
        {
            if (node != null)
            {
                datalist.Add(node.data);
                Preorder(node.leftnode, datalist);
                Preorder(node.rightnode, datalist);
            }
        }
        //Returning postordered data that is, left right root
        public int[] Postorder()
        {
            List<int> datalist = new List<int>();
            Postorder(root, datalist);
            return datalist.ToArray();
        }
        private void Postorder(BSTNode node, List<int> datalist)
        {
            if (node != null)
            {
                Postorder(node.leftnode, datalist);
                Postorder(node.rightnode, datalist);
                datalist.Add(node.data);
            }
        }
        //Search for the given element if exist return node else return null
        public BSTNode Search(int data)
        {
            BSTNode n = new BSTNode();
            n = root;
            while (n != null)
            {
                if (n.data == data)
                {
                    return n;
                }
                else if (n.data > data)
                {
                    n = n.leftnode;
                }
                else
                {
                    n = n.rightnode;
                }
            }
            return n;
        }
        //Returning the height of the tree.
        public int Height()
        {
            return Height(root);
        }
        private int Height(BSTNode node)
        {
            if (node != null)
            {
                int leftheight = 0, rightheight = 0;
                leftheight = Height(node.leftnode) + 1;
                rightheight = Height(node.rightnode) + 1;
                if (rightheight < leftheight)
                {
                    return leftheight;
                }
                else
                {
                    return rightheight;
                }
            }
            return -1;
        }
        //Returning the size of the tree.
        public int Size()
        {
            return Size(root);
        }
        private int Size(BSTNode node)
        {
            if (node != null)
            {
                return Size(node.leftnode) + Size(node.rightnode) + 1;
            }
            return 0;
        }
        //Returning the minimum node of the right subtree.
        public BSTNode Successor(BSTNode node)
        {
            if (node != null)
            {
                return Minimum(node.rightnode);
            }
            return node;
        }
        //Returning the minimum node of the tree.
        public BSTNode Minimum(BSTNode node)
        {
            while (node.leftnode != null)
            {
                node = node.leftnode;
            }
            return node;
        }
        //Returning the maximum node of the left subtree.
        public BSTNode Predecessor(BSTNode node)
        {
            if (node != null)
            {
                return Maximum(node.leftnode);
            }
            return node;
        }
        //Returning the maximum node of the tree.
        public BSTNode Maximum(BSTNode node)
        {
            while (node.rightnode != null)
            {
                node = node.rightnode;
            }
            return node;
        }
        //Deleting the given node of the tree if exist.
        public void Delete(int data)
        {
            root = Delete(root, data);
        }
        private BSTNode Delete(BSTNode node, int data)
        {
            if (node != null)
            {
                if (data == node.data)
                {
                    if (node.leftnode == null && node.rightnode == null)
                    {
                        return null;
                    }
                    else if (node.leftnode != null && node.rightnode == null)
                    {
                        return node.leftnode;
                    }
                    else if (node.leftnode == null && node.rightnode != null)
                    {
                        return node.rightnode;
                    }
                    else
                    {
                        BSTNode suc = Successor(node);
                        node.data = suc.data;
                        node.rightnode = Delete(node.rightnode, suc.data);
                        return node;
                    }
                }
                if (data < node.data)
                {
                    node.leftnode = Delete(node.leftnode, data);
                }
                else
                {
                    node.rightnode = Delete(node.rightnode, data);
                }
            }
            return node;
        }
    }
}
