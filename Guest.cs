using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHotelRoomManagementProjectWithOOP
{
    // This class represents a Guest (visitor) in the hotel.
    class Guest
    {
        private string name; // Guest's full name
        private string nationalID;  // National ID for identity verification
        private string phoneNumber; // Room number for contact

        // Guest's full name with validation
        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                    throw new ArgumentException("Guest name must be at least 3 characters.");
                name = value;
            }
        }



        // Guest's national ID with validation
        public string NationalID
        {
            get => nationalID;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                    throw new ArgumentException("National ID must be at least 5 characters.");
                nationalID = value;
            }
        }


        // Guest's phone number with validation
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 7)
                    throw new ArgumentException("Phone number must be at least 7 digits.");
                phoneNumber = value;
            }
        }

        // Constructor
        public Guest(string name, string phoneNumber, string nationalID)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            NationalID = nationalID;
        }

        // Override ToString to display guest information clearly
        public override string ToString()
        {
            return $"Name: {Name}, Phone: {PhoneNumber}, National ID: {NationalID}";
        }


    }
}
