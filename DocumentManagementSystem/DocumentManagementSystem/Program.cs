using System;
using System.Threading.Tasks;
using DocumentManagementSystemAPI;

namespace DocumentManagementSystem
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string content = string.Empty; //create empty string to hold downloaded document content

            DMS dms = new DMS(); // instantiate new DMS object - the constructor is empty and there are no fields in the DMS class
                                 // so this new DMS object has only methods: CreateDocument (overloaded(2)) and GetDMSDocumentBST() which takes a sorted array and 
                                 // returns a DMSDocumentBST type object, which has:
                                 // - a binary search tree of Document objects created from the array of document ids
                                 //   if the id corresponds to a Document object, a new Document object is created either as the root document or as a child of a parent Document object
                                 // - a sorted/sequential list of Document objects is then created from the BST

            int[] docIds = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22}; // create integer array to store document ids (sorted already)

            DMSDocumentBST dmsDocumentBST = dms.GetDMSDocumentBST(docIds); // the dms object has a method called 'GetDMSDocumentBST()', that takes an (sorted?) array of
                                                                           // document ids and returns a new instance of DMSDocumentBST, a binary search tree created from the 
                                                                           // sorted array of document ids
                                                                           // also creates a new generic list (type:Document) and populates that list with the document objects
                                                                           // in sequential order (by traversing binary tree) by calling the CreateInOrderDocumentList function

            int key = 0;

            while (true)
            {
                Console.WriteLine("Please enter a document Id"); // prompt user for a document on which to gather the data/metadata

                key = Convert.ToInt32(Console.ReadLine());

                Console.Write("Search path: ");
                DMSDocument doc = (DMSDocument)dmsDocumentBST.FindDoc(key); // FindDoc method recursively searches for the document in the BST
                Console.Write(key);

                Console.WriteLine();
                Console.WriteLine();

                if (doc != null)
                {
                    Console.WriteLine($"Document - {doc.Id} - has been found");
                    Console.WriteLine("Downloading document content...");

                    content = await doc.DownloadContent(); // asynchronous call to download data

                    //Console.Clear();

                    Console.WriteLine(doc.GetSerializedDocumentMetaData(DocumentMetaDataFormat.CSV));

                    Console.WriteLine();
                    Console.WriteLine();

                    Console.WriteLine(content); // write content to the console

                    Console.WriteLine();
                    Console.WriteLine();

                }
                else
                {
                    Console.WriteLine($"Document, {key}, could not be found.");
                }
                if (!SearchDocsAgain()) break;

                Console.Clear();

            }
        }

        // prompt to continue searching or end app
        private static bool SearchDocsAgain()
        {
            Console.WriteLine("Please press spacebar to end application or any other key to continue...");

            if (Console.ReadKey().Key == ConsoleKey.Spacebar)
            {
                return false;
            }
            return true;
        }


        // demo method just to show how recursive functions work
        private static void RepeatMultiply(int x, int multiplier, int limit)
        {
            // Recursive function must have a base case, otherwise loop could get called over and over and cause a STACKOVERFLOW!!!
            if (x > limit || x <= 0) //Base Case
                return;

            Console.WriteLine(x);
            x = x * multiplier;

            RepeatMultiply(x, multiplier, limit);


            // Alternate to recursion in this case could be to use a while loop, same functionality
            //while (x < limit && x > 0)
            //{
            //    Console.WriteLine(x);
            //    x = x * multiplier;
            //}
        }

    }
}