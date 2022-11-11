/*
Title: Mobile phone contact management
Author Name: Priyadarshini. D
Created At: 19.10.2022
Updated At: 25.10.2022
Reviewed By: Sabapathi shanmugam
*/
using System;
using System.Collections;       //hashtable(non-generic) is defined in collections namespace

namespace MethodOverloading{
    //base class
    class Contact{

        public string? contactName, emailId;        //public field accessed in all fields
        protected long contactNumber,alternateNumber;       //protected field accessed in same class and also in derived class
        protected Hashtable name = new Hashtable();
        
        protected ArrayList details = new ArrayList();
        //overloading saveContact method with different parameters
        public void saveContact(string contactName, long contactNumber){

                details.Add(contactNumber);
                name.Add(contactName,details);
                Console.WriteLine("\nContact Saved!\n");
               
        }
        public void saveContact(string contactName, long contactNumber, long alternateNumber){
            
            details.Add(contactNumber);
            details.Add(alternateNumber);
            name.Add(contactName,details);
            Console.WriteLine("\nContact Saved!\n");
               
        }

        public void saveContact(string contactName, long contactNumber, string? emailId){

            details.Add(contactNumber);
            details.Add(emailId);
            name.Add(contactName,details);
            Console.WriteLine("\nContact Saved!\n");
                    
        }
        public void deleteContact(){

            Console.Write("Enter Contact name to delete: ");
            string? value = Console.ReadLine();
            foreach(string keyValue in name.Keys)
            {
                if (value!.Equals(keyValue)){
                    name.Remove(keyValue);
                    Console.WriteLine("\nContact Deleted!\n");
                    break;
                }
            } 
        }
        public void displayContact(){

            Console.WriteLine("\n-------------\nContacts List\n-------------");
            //foreach loop used to access values in hashtable collection
            foreach (var item in name.Keys)
            {
                Console.WriteLine("{0} ",item);
            }
        }        
    }
    //derived class PhoneNumber from contact
    class PhoneNumber:Contact{

        public void displayOption(){
            bool flag = true;
            while(flag){
                try{
                    Console.Write("--------\nContacts\n--------\n1. Add New Contact\n2. Delete Contact\n3. Display Contact\n4. Exit\nWhat action? ");
                    int option = Convert.ToInt16(Console.ReadLine());
                    switch(option){
                        case 1:
                            addNewContact();
                            break;
                        case 2:
                            deleteContact();
                            break;
                        case 3:
                            displayContact();
                            break;
                        case 4:
                            flag = false;
                            break;
                        default:
                            Console.WriteLine("Select from above option!");
                            break;
                    }
                }
                catch(Exception){
                    Console.WriteLine("\nEnter valid option!\n");
                    displayOption();
                }
            }
        }
        public void addNewContact(){
            
            try{
                Console.Write("1. Save contact with one number\n2. Save contact with two Numbers\n3. Save contact with number and Email\n4. Exit\nSelect Option: ");
                int option = Convert.ToInt16(Console.ReadLine());
                switch(option){
                case 1: 
                    Console.Write("Enter Name: ");
                    contactName = Console.ReadLine()!;
                    if(validateName(contactName)){
                        Console.Write("Enter Phone Number: ");
                        contactNumber = Convert.ToInt64(Console.ReadLine());
                        if(validateNumber(contactNumber)){
                            saveContact(contactName,contactNumber);
                        }
                    }                      
                    break;

                case 2:
                    Console.Write("Enter Name: ");
                    contactName = Console.ReadLine()!;
                    if(validateName(contactName)){
                        Console.Write("Enter Phone Number: ");
                        contactNumber = Convert.ToInt64(Console.ReadLine());
                        if(validateNumber(contactNumber)){
                            Console.Write("Enter alternate number: ");
                            alternateNumber = Convert.ToInt64(Console.ReadLine());
                            if(validateNumber(alternateNumber)){
                                saveContact(contactName,contactNumber,alternateNumber);
                            }
                        }
                    }
                    break;

                case 3:
                    Console.Write("Enter Name: ");
                    contactName = Console.ReadLine()!;
                    Console.WriteLine("validation"+ validateName(contactName));
                    if(validateName(contactName)){
                        Console.Write("Enter Phone Number: ");
                        contactNumber = Convert.ToInt64(Console.ReadLine());
                        if(validateNumber(contactNumber)){
                            Console.Write("Enter Email: ");
                            emailId = Console.ReadLine();
                            saveContact(contactName,contactNumber,emailId);
                        }
                    }                   
                    break;
                case 4: 
                    break;
                default:
                    Console.WriteLine("Select from above option!");
                    break; 
                }
            }
            catch(Exception){
                Console.WriteLine("\nEnter valid Option!\n");
                addNewContact();
            }
            
        }  
       //validating name if name already exists
        public bool validateName(string contactName){
            bool flag = true;
            if(name.ContainsKey(contactName)){
                Console.WriteLine("\nContact already exists!\n");
                flag = false;
            }
            return flag;
        } 
         
        //validating phone number
        public bool validateNumber(long number){
            bool flag = true;
            int numberLength = number.ToString().Length;
            if(numberLength<10 || numberLength>10){
                Console.WriteLine("\nEnter valid Number!\n");
                flag = false;
            }
            return flag;
        }
    }
    internal class MobilePhone{
        private static void Main(string[] args)
        {
            PhoneNumber phoneNumber = new PhoneNumber();
            phoneNumber.displayOption();    
        }
    }
}