using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace BookStoreLogicLayer
{
    public class Client
    {
        public ObjectId Id { set; get; }

        private string _FirstName;
        public string FirstName {
            set { _FirstName = value.ToLower(); }
            get { return _FirstName; }}

        private string _LastName;
        public string LastName { 
            set { _LastName = value.ToLower(); } 
            get {return _LastName;} }

        private string _PhoneNumber;
        public string PhoneNumber {
            set { if (_PhoneNumber.Length > 0) { _PhoneNumber = value; } else { throw new ArgumentException(); } }
            get { return _PhoneNumber; }
        }


        public Client FromDataObject(MongoRepository.Client c) { return new Client(c); }

        public Client() { }

        private Client(MongoRepository.Client client) 
        {
            this.FirstName   = client.FirstName;
            this.LastName    = client.LastName;
            this.PhoneNumber = client.PhoneNumber;
            this.Id = client.Id;
        }

        public Client(string name, string last_name, string phone)
        { this.FirstName = name; this.LastName = last_name; this.PhoneNumber = phone;}

        public Client(string name, string last_name)
        { this.FirstName = name; this.LastName = last_name;}
    }
}
