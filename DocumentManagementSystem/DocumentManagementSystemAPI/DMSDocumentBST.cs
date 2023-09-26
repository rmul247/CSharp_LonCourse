using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentManagementSystemAPI
{
    public class DMSDocumentBST
    {
        private readonly Document _rootDoc = null;
        private readonly List<Document> _documents = null;

        public Document RootDoc
        {
            get
            {
                return _rootDoc;
            }
        }

        // constructor that creates a BST like nested objects of type Document
        // also creates a sequential List of these objects
        public DMSDocumentBST(int[] arr)
        {
            _rootDoc = SortedArrayToBST(arr, 0, arr.Length - 1); //create BinarySearchTree of child objects nested within parent objects

            _documents = new List<Document>(); // create new List to hold Document objects

            CreateInOrderDocumentList(_rootDoc); // traverse through the rootDoc BST/nested document objects and populate
                                                 //  the list from the lowest node to the highest

        }

        // public access to search method, passes in key(/document ID)
        public Document FindDoc(int key)
        {
            return Search(_rootDoc, key);
        }

        //recursively search the BST from the top down
        // it moves through the tree checking the key against the documents ID
        // if key is bigger, Search() moves right, if not Search() moves left
        // at each layer that layers document ID is "added" to the search path
        private Document Search(Document rootDoc, int key)
        {
            if (rootDoc == null || rootDoc.Id == key) //Base Case
                return rootDoc;

            Console.Write($"{rootDoc.Id} - "); //Print search path

            //key is greater than root's key
            if (rootDoc.Id < key)
                return Search(rootDoc.RightDoc, key);

            //key is smaller than root's key
            return Search(rootDoc.LeftDoc, key);


        }



        /* A function that constructs Balanced Binary 
         Search Tree from sorted array
        
        the function checks if it should go lower on the left side, if yes then it creates a new doc object as the upper levels doc.LeftDoc field
        if not then it returns null, same check and doc object creation process for the right side, process is recursively looped until all ids are "on the tree"
        
        Diagram of the tree that is created:
                        4
                     /     \
                   2        6
                  /  \    /   \
                 1    3  5     7
         
         */
        private Document SortedArrayToBST(int[] arr, int start, int end)
        {
            /*Base Case*/
            if (start > end)
            {
                return null;
            }

            /*Get the middle element and make it root*/
            int mid = (start + end) / 2;

            Document doc = new DMSDocument(arr[mid]); // new Document object called doc is created
                                                      // this object contains the metadata (id/name/description) relevant to the document id stored at arr[mid]
                                                      // as well as the methods in the document class
                                                      // as the function progresses, if appropriate, the LeftDoc and RightDoc fields of this doc object will be
                                                      // recursively assignened new doc objects, potentially with their own left and right children, and so on down the layers

            /*Recursively construct the left subtree and make it
             left child of root*/
            doc.LeftDoc = SortedArrayToBST(arr, start, mid - 1);

            /*Recursively construct the right subtree and make it
             right child of root*/
            doc.RightDoc = SortedArrayToBST(arr, mid + 1, end);

            return doc; // return the doc object created here as either the left or right child of the upper doc
                        //  with it's own left and right children having been (potentially) recursively created

        }

        // These functions return an IEnumerable List of document objects
        // the yield keyword holds the position after each call of the method
        // e.g. the first loop it returns out after one pass but "remembers" the loop position
        //  next time the function is called the loop does its second iteration, then returns
        //  third call, third loop, third return, third remember for next call etc...
        //  this causes the IEnumerable list to act as a collection
        public IEnumerable<Document> GetOrderedDocumentList()
        {
            for (int x = 0; x < _documents.Count; x++)
            {
                yield return _documents[x];
            }
        }

        //overload the GetOrderedDocumentList method
        public IEnumerable<Document> GetOrderedDocumentList(bool reverse)
        {
            if (reverse)
            {
                for (int x = _documents.Count - 1; x > -1; x--)
                {
                    yield return _documents[x];
                }
            }
            else
            {
                for (int x = 0; x < _documents.Count; x++)
                {
                    yield return _documents[x];
                }
            }

        }


        //Inorder tree traversal
        // In a similar way to the BST being created, this function recursively iterates a document object (rootDoc) that has
        //  similar document objects as it's left and right children
        // - goes to bottom left node of the BST(/chain of Document objects)
        // - after it goes one node beyond the end i.e. rootDoc == null, the function jumps back up a
        //    layer and adds the lowest left (a.k.a. first) node to the List _documents
        // - then it checks to the right, if no node is there then this loop/layer is finished with
        // - each layer is moved through adding documents to the list if either they have nothing to
        //    their left or the previous document(/left branch) has been iterated through completely
        private void CreateInOrderDocumentList(Document rootDoc)
        {
            // if rootDoc is null then the end of that branch has been found
            if(rootDoc == null)
            {
                return;
            }

            /*first recur on left child*/
            // - goes to bottom left node of the BST(/chain of Document objects)
            CreateInOrderDocumentList(rootDoc.LeftDoc);

            /* Add document object to the list */
            _documents.Add(rootDoc);

            /* now recur on right child*/
            // if an object exists, it is recursively iterated into
            // if nothing is there then this layer of recursion is done with 
            CreateInOrderDocumentList(rootDoc.RightDoc);
         }


        //Function to print level order traversal of the tree
        public void PrintLevelOrder()
        {
            int h = Height(_rootDoc);
            int i;

            for (i = 1; i <= h; i++)
            {
                PrintGivenLevel(_rootDoc, i);
            }
        }


        //Compute the height of tree
        private int Height(Document rootDoc)
        {
            if (rootDoc == null)
            {
                return 0;
            }
            else
            {
                int lheight = Height(rootDoc.LeftDoc);
                int rheight = Height(rootDoc.RightDoc);

                //use the larger one
                if (lheight > rheight)
                {
                    return (lheight + 1);
                }
                else
                {
                    return (rheight + 1);
                }
            }
        }

        //print tree in breadth first order
        private void PrintGivenLevel(Document rootDoc, int level)
        {
            if (rootDoc == null)
            {
                return;
            }
            if (level == 1)
            {
                Console.WriteLine(rootDoc.Id + " ");
            }
            else if (level > 1)
            {
                PrintGivenLevel(rootDoc.LeftDoc, level - 1);
                PrintGivenLevel(rootDoc.RightDoc, level - 1);
            }
        }
    }
}
