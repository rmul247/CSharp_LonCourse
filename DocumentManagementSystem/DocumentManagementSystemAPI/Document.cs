using System;

namespace DocumentManagementSystemAPI
{
    public enum DocumentMetaDataFormat
    {
        JSON,
        XML,
        CSV
    }

    public abstract class Document
    {
        private readonly int _id = 0;
        private readonly string _name = String.Empty;
        private readonly string _description = String.Empty;

        private Document _leftDoc = null;
        private Document _rightDoc = null;


        // Getters and Setters
        // ************************************
        //get can be implemented either way it's the same
        //A)
        public int Id { get => _id; }
        
        //B)
        public string Name
        {
            get
            {
                return _name;
            }
        }
        public string Description { get => _description; }

        public Document LeftDoc
        {
            get
            {
                return _leftDoc;
            }
            set
            {
                _leftDoc = value;
            }
        }

        public Document RightDoc
        {
            get
            {
                return _rightDoc;
            }
            set
            {
                _rightDoc = value;
            }
        }


        // Document constructor - document id is the argument it takes
        // if id is valid, the constructor creates a new Document object that contains metadata of the document
        //  assigns id and metadata strings (name/description) to private fields
        protected Document(int id)
        {
            if (IsDocIdValid(id))
            {
                //Web service method call that retrieves document metadata goes here
                _id = id;
                _name = $"Doc{_id}";
                _description = $"Document description for document: {_id}";
            }
            else
            {
                throw new Exception("Invalid Id");
            }

        }

        private bool IsValidId(int id)
        {
            if (this.IsDocIdValid(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // prints dummy metadata for CSV files
        public virtual string GetSerializedDocumentMetaData(DocumentMetaDataFormat documentMetaDataFormat)
        {
            string result = null;

            switch (documentMetaDataFormat)
            {
                case DocumentMetaDataFormat.JSON:
                    throw new NotImplementedException();
                case DocumentMetaDataFormat.XML:
                    throw new NotImplementedException();
                case DocumentMetaDataFormat.CSV:
                    result = $"{Id}, \"{Name}\", \"{Description}\"";
                    break;
                default:
                    Console.WriteLine("Invalid");
                    break;
            }
            return result ;
        }
        public abstract bool IsDocIdValid(int id);

    }
}
