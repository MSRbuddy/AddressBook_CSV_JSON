using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AddressBooks
{

    public class AddrBook
    {
        public List<AddrBook> stateList { get; set; }
        public List<AddrBook> cityList { get; set; }

        //instance variables 
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public List<AddrBook> ContactArray;
        public int contact = 0;


        //Default Contructor
        public AddrBook()
        {
            this.ContactArray = new List<AddrBook>();
        }
        public override string ToString()
        {
            return ("Name: " + this.firstName + " " + this.lastName + "\tAddress: " + this.Address + "\tCity: " + this.city + " \t State: " + this.state + "\tPincode: " + this.zip + " \t Phone Number: " + this.phoneNumber + "\tEmail Id: " + this.email);
        }
        //To add Contact to Address Book
        public void CreateContact(string firstName, string lastName, string Address, string city, string state, string zip, string phoneNumber, string email)
        {
            AddrBook bookSystem = new AddrBook();
            bookSystem.firstName = firstName;
            bookSystem.lastName = lastName;
            bookSystem.Address = Address;
            bookSystem.city = city;
            bookSystem.state = state;
            bookSystem.zip = zip;
            bookSystem.phoneNumber = phoneNumber;
            bookSystem.email = email;



            //Newly add element to List
            if (ContactArray.Count == 0)
            {
                ContactArray.Add(bookSystem);
                if (Program.State.ContainsKey(state))
                {
                    List<AddrBook> existing = Program.State[state];
                    existing.Add(bookSystem);

                }
                else
                {
                    stateList = new List<AddrBook>();
                    stateList.Add(bookSystem);
                    Program.State.Add(state, stateList);

                }
                if (Program.City.ContainsKey(city))
                {
                    List<AddrBook> existing = Program.City[city];
                    existing.Add(bookSystem);

                }
                else
                {
                    cityList = new List<AddrBook>();
                    cityList.Add(bookSystem);
                    Program.City.Add(city, cityList);

                }

                Program obj = new Program();
                obj.Display(ContactArray, ContactArray.Count);

            }
            else if (contact != 0)
            {
                //Check if element already present in List
                AddrBook addressBookSystems = ContactArray.Find(x => x.firstName.Equals(firstName));
                if (addressBookSystems == null)
                {

                    ContactArray.Add(bookSystem);
                    if (Program.State.ContainsKey(state))
                    {
                        List<AddrBook> existing = Program.State[state];
                        existing.Add(bookSystem);

                    }
                    else
                    {
                        stateList = new List<AddrBook>();
                        stateList.Add(bookSystem);
                        Program.State.Add(state, stateList);

                    }
                    if (Program.City.ContainsKey(city))
                    {
                        List<AddrBook> existing = Program.City[city];
                        existing.Add(bookSystem);

                    }
                    else
                    {
                        cityList = new List<AddrBook>();
                        cityList.Add(bookSystem);
                        Program.City.Add(city, cityList);

                    }

                    Program obj = new Program();
                    obj.Display(ContactArray, ContactArray.Count);
                }
                else
                {
                    Console.WriteLine("This person already exists in your AddressBook!");
                }

            }
        }
        //Function call To modify
        public void Modify()
        {
            //User enters field to Modify
            int i = 0;
            Console.WriteLine("-------To Modify-------\nEnter first name of user that needs modification");
            string name = Console.ReadLine();

            //Traverse till the desired index
            while (ContactArray[i].firstName != name)
            {
                i++;
            }

            Console.WriteLine("Enter field to be modified 1.firstName 2.lastName 3.Address 4.city 5.state 6.zip 7.phoneNumber 8.email 9.Delete a contact");
            int ch = Convert.ToInt32(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    Console.WriteLine("Enter the modified value");
                    string fn = Console.ReadLine();
                    ContactArray[i].firstName = fn;
                    break;
                case 2:
                    Console.WriteLine("Enter the modified value");
                    string ls = Console.ReadLine();
                    ContactArray[i].lastName = ls;
                    break;
                case 3:
                    Console.WriteLine("Ente the modified value");
                    string add = Console.ReadLine();
                    ContactArray[i].Address = add;
                    break;
                case 4:
                    Console.WriteLine("Enter the modified value");
                    string cities = Console.ReadLine();
                    ContactArray[i].city = cities;
                    break;
                case 5:
                    Console.WriteLine("Enter the modified value");
                    string states = Console.ReadLine();
                    ContactArray[i].state = states;
                    break;
                case 6:
                    Console.WriteLine("Enter the modified value");
                    string temp = (Console.ReadLine());
                    ContactArray[i].zip = temp;
                    break;
                case 7:
                    Console.WriteLine("Ente the modified value");
                    string phn = Console.ReadLine();
                    ContactArray[i].phoneNumber = phn;
                    break;
                case 8:
                    Console.WriteLine("Ente the modified value");
                    string emails = Console.ReadLine();
                    ContactArray[i].email = emails;
                    break;
                //Delete a user
                case 9:
                    ContactArray = ContactArray.Take(i).Concat(ContactArray.Skip(i + 1)).ToList();

                    break;
                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }
            //Display Function
            Program obj = new Program();
            obj.Display(ContactArray, ContactArray.Count);
        }
    }

}
