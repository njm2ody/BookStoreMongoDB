using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoRepository
{
    public class Client
    {
        [BsonId]
        public ObjectId Id;

        private string _FirstName;
        public string FirstName {
            set { _FirstName = value.ToLower().Trim(); }
            get { return _FirstName; }}

        private string _LastName;
        public string LastName { 
            set { _LastName = value.ToLower().Trim(); } 
            get {return _LastName;} }

        private string _PhoneNumber;
        public string PhoneNumber { 
            set { this._PhoneNumber = value.ToLower().Trim(); } 
            get {return _PhoneNumber;} }

        public Client() { }

        public Client(string first_name, string last_name, string phone)
        { this.FirstName = first_name; this.LastName = last_name; this.PhoneNumber = phone;}

        public Client(string first_name, string last_name)
        { this.FirstName = first_name; this.LastName = last_name;}
    }
}
