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
        public string Name { get; }  // Guest's full name
        public string NationalID { get; }  // National ID for identity verification
        public string RoomNumber { get; set; } // Room number for contact
        public int Nights { get; set; } // Property to store the number of nights the guest will stay in the room

        // Constructor with validation for required fields
        public Guest(string name, string nationalID, string roomNumber, int nights)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 3)
                throw new ArgumentException("Guest name must be at least 3 characters.");

            if (string.IsNullOrWhiteSpace(nationalID) || nationalID.Length < 5)
                throw new ArgumentException("National ID must be at least 5 characters.");

            if (string.IsNullOrWhiteSpace(roomNumber))
                throw new ArgumentException("Room number cannot be empty.");

            if (nights <= 0)
                throw new ArgumentException("Nights must be greater than 0.");

            Name = name;
            NationalID = nationalID;
            RoomNumber = roomNumber;
            Nights = nights;
        }




    }
}
