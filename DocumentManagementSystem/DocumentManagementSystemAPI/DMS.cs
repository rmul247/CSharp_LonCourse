using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentManagementSystemAPI
{
    public class DMS
    {
        // empty constructor, probably doesnt need to be here as it doesnt do anything and the default constructor will be called anyway on instantiation
        public DMS()
        {

        }

        // - demonstration of overloading of the CreateDocument method
        // - also a demo of the ref keyword
        //     since the function returns a boolean value, using the ref keyword allows the value of ID temporarily become a reference type
        //     allowing a change to the data locally to persist outside the scope of this method
        public bool CreateDocument(string name, string description, ref int id)
        {
            int webCallResult = 0;
            bool success = false;

            //Call to web method that adds new document to DMS goes here

            webCallResult = 8;

            if (webCallResult != 0)
            {
                success = true;
            }

            id = webCallResult;

            return success;
        }

        // return type can be changes when overloading a method, providing that the parameters have also been altered
        //  changing the return type alone does not overload the method
        public int CreateDocument(string name, string description, ref int id, int size)
        {
            return 1;
        }

        // fake news function, just to demonstrate overloading
        public int CreateDocument(string name)
        {

            //Call to web method that adds new document to DMS goes here

            int webCallResult = 8;

            return webCallResult;
        }

        //
        public DMSDocumentBST GetDMSDocumentBST(int[] sortedArray)
        {
            return new DMSDocumentBST(sortedArray);
        }
    }
}
