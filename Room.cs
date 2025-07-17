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
        public int RoomNumber { get; set; }         // Unique room number
        public double DailyRate { get; set; }       // Daily rate of the room
        public bool IsReserved { get; set; }        // Indicates if room is reserved
        public Reservation ReservationInfo { get; set; } // The reservation info (null if not reserved)




        // Constructor with validation for rate
        public Room(int roomNumber, double dailyRate)
        {
            if (roomNumber <= 0)
                throw new ArgumentException("Room number must be positive.");
            if (dailyRate < 100)
                throw new ArgumentException("Daily rate must be at least 100.");

            RoomNumber = roomNumber;
            DailyRate = dailyRate;
            IsReserved = false;
            ReservationInfo = null;
        }


        // Overrides the default ToString method to return a formatted string with room information.
        public override string ToString() //ToString()-> Returns a readable string about the room
        {
            if (!IsReserved)
                return $"Room {RoomNumber} - Available - Rate: {DailyRate}";

            double totalCost = ReservationInfo.Nights * DailyRate;
            return $"Room {RoomNumber} - Reserved by {ReservationInfo.GuestName} - Nights: {ReservationInfo.Nights} - Total: {totalCost}"; // Returns a string showing the room number and daily rate.
        }

    }
}





