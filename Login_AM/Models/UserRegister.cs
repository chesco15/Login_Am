using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_AM.Models
{
    internal class UserRegister
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName1 { get; set; }
        public string lastName2 { get; set; }
        public string PhoneNumber { get; set; }
        

        public UserRegister(int id,string firstName, string lastname1, string lastname2, string phonenumber, string email, string password) 
        {
            this.Id = id;
            this.firstName = firstName;
            this.lastName1 = lastname1; 
            this.lastName2 = lastname2;
            this.PhoneNumber = phonenumber;
            this.email = email;
            this.password = password;
        }
    }
}
