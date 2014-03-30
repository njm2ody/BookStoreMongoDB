using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreLogicLayer
{
    public class Client
    {
        private string _FirstName;
        public string FirstName {
            set { _FirstName = value.ToLower(); }
            get { return _FirstName; }}

        private string _LastName;
        public string LastName { 
            set { _LastName = value.ToLower(); } 
            get {return _LastName;} }

        public string PhoneNumber { set; get; }

        public Client() { }

        public Client(string name, string last_name, string phone)
        { this.FirstName = name; this.LastName = last_name; this.PhoneNumber = phone;}

        public Client(string name, string last_name)
        { this.FirstName = name; this.LastName = last_name;}
    }
}
