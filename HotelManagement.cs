using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHotelRoomManagementProjectWithOOP
{
    // Manages guests, rooms, and reservations
    class HotelManagement
    {
        private List<Guest> guests = new List<Guest>();  // All guests
        private List<Room> rooms = new List<Room>();     // All rooms

        // Method to add a new guest to the guests list

        public void AddGuest(Guest guest)
        {
            if (guests.Any(g => g.NationalID == guest.NationalID)) // Check if there is already a guest with the same National ID in the list
                throw new Exception("Guest with this National ID already exists."); // If found, throw an exception to prevent duplicate National ID
            guests.Add(guest);  // If no duplicate is found, add the guest to the list
        }


        
        // Display all guests
        public void ViewAllGuests()
        {
            foreach (var guest in guests)
                Console.WriteLine(guest);
        }


        // Find guest by National ID
        public Guest FindGuestByNationalID(string nationalID)
        {
            return guests.FirstOrDefault(g => g.NationalID == nationalID);
        }

        // Add new room to the system
        public void AddRoom(int roomNumber, double dailyRate)
        {
            if (rooms.Any(r => r.RoomNumber == roomNumber))
                throw new Exception("Room number must be unique.");

            rooms.Add(new Room(roomNumber, dailyRate));
        }


    }
}
