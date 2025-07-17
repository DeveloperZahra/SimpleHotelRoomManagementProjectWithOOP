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

        // Overrides the default ToString method to return a formatted string with room information.
        public override string ToString()
        {

            return $"Room RoomNumber: {RoomNumber}, DailyRate: {DailyRate}"; // Returns a string showing the room number and daily rate.
        }

        // Static method to create a Room object from a string.
        public static Room FromString(string line)

        {
            var parts = line.Split('|'); // Split the input string using the '|' character as a separator.
            return new Room  // Create a new Room object and assign the values after parsing
            {
                RoomNumber = int.Parse(parts[0]), // Convert the first part to int for the room number.
                DailyRate = int.Parse(parts[1]) // Convert the second part to double for the daily rate.
                                                // It's better to use double.Parse instead of int.Parse here.
            };

        }
     }





}
