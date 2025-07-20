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
        public Guest GuestInfo { get; set; }      // The guest who made the reservation
        public int Nights { get; set; }           // Number of nights reserved
        public DateTime CheckInDateTime { get; set; }     // Exact check-in date and time
        public DateTime CheckOutDateTime { get; set; }    // Exact check-out date and time

        // Constructor ensures nights > 0 and marks the room as reserved

        public Reservation(Guest guest, DateTime checkInDateTime, int nights)
        {
            if (nights <= 0) // Validate that the number of nights is positive (cannot reserve 0 or negative nights)
                throw new ArgumentException("Number of nights must be positive.");

            GuestInfo = guest; // Store the guest information (the guest who made the reservation)
            Nights = nights; // Store the number of nights for this reservation
            CheckInDateTime = checkInDateTime;
            CheckOutDateTime = CheckInDateTime.AddDays(Nights);  // Automatically calculate checkout based on nights
        }


        public override string ToString()
        {
            return $"Guest: {GuestInfo.Name}, Phone: {GuestInfo.PhoneNumber}, Nights: {Nights}, " +
               $"Check-In: {CheckInDateTime}, Check-Out: {CheckOutDateTime}";
        }





    }
}
