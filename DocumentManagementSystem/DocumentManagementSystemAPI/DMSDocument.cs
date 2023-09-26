using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystemAPI
{
    public class DMSDocument : Document
    {
        private const string docType = "DMS Document";

        //DMSDocument constructor - when this constructor is called it redirects the call to the Document constructor
        //  as that constructor is inherited from/extended (???? phrasing) using 'base' keyword
        public DMSDocument(int id) : base(id)
        {

        }

        // function called from the Main program
        public async Task<string> DownloadContent()
        {
            Task<string> downloadTask = Download(); // asynch call to Download document data

            string content = await downloadTask; // fills content string object with downloaded data after a simulated wait i.e. when the asynch call is finished

            return content;

        }

        // mock method to simulate a call to a database or server
        // builds a string of content and "waits" for 6 seconds
        private async Task<string> Download()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"This is content for document {Id}");
            sb.AppendLine($"This is content for document {Id}");
            sb.AppendLine($"This is content for document {Id}");
            sb.AppendLine($"This is content for document {Id}");
            sb.AppendLine($"This is content for document {Id}");
            sb.AppendLine($"This is content for document {Id}");
            sb.AppendLine($"This is content for document {Id}");
            sb.AppendLine($"This is content for document {Id}");
            sb.AppendLine($"This is content for document {Id}");
            sb.AppendLine($"This is content for document {Id}");

            await Task.Delay(6000); //simulation of call to web service to download document content

            return sb.ToString();

        }

        public override string GetSerializedDocumentMetaData(DocumentMetaDataFormat documentMetaDataFormat)
        {
            return base.GetSerializedDocumentMetaData(DocumentMetaDataFormat.CSV) + "," + docType;
        }

        // this function is called from within the Document constructor, when id is being validated
        //  in order to create new Document object (and its metadata)
        // its a basic/mock/deliberately uncomplicated function just for demonstration purposes
        public override bool IsDocIdValid(int id)
        {
            if (id >= 1 && id <= 1000)
            {
                return true;
            }
            return false;
        }
    }
}