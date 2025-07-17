using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHotelRoomManagementProjectWithOOP
{
    // This class represents a Reservation between a Guest and a Room.
    class Reservation
    {
        public string  GuestName { get; }   // Guest name who mode the reservation

        public string RoomNumber { get; set; } // Room number for contact

        public int Nights { get; set; } // Property to store the number of nights the guest will stay in the room

        public DateTime BookingDate { get; set; }  // Date of booking, stored at creation time 
    }
}
