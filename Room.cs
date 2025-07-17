using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SimpleHotelRoomManagementProjectWithOOP
{
    // This class represents a Room in a hotel.
    class Room
    {
        public int RoomNumber { get; set; } // Property to store the room number.
        public double DailyRate  { get; set; } // Property to store the daily rate of the room.

        public bool IsReserved { get; set; } // Room reservation status (true if reserved)



        // Constructor with validation for rate
        public Room(int roomNumber, double dailyRate)
        {
            if (dailyRate < 100)
                throw new ArgumentException("Daily rate must be at least 100.");

            RoomNumber = roomNumber;
            DailyRate = dailyRate;
            IsReserved = false;
        }

        // Overrides the default ToString method to return a formatted string with room information.
        public override string ToString() //ToString()-> Returns a readable string about the room
        {

            string status = IsReserved ? "Reserved" : "Available";
            return $"Room {RoomNumber} | Rate: {DailyRate} | Status: {status}"; // Returns a string showing the room number and daily rate.
        }
    }





}
