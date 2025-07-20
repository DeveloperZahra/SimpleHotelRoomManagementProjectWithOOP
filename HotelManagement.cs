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
            if (guests.Count > 0)
            {
                foreach (var guest in guests)
                    Console.WriteLine(guest);
            }
            else
            {
                Console.WriteLine("You have not added any guest.");
            }

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

        // View all rooms and their stuatus 

        public void ViewAllRooms()
        {
            foreach (var room in rooms)
                Console.WriteLine(room);
        }

        // Reserve a room for an existing guest
        public void ReserveRoom(string nationalID, int roomNumber, int nights)
        {
            var guest = FindGuestByNationalID(nationalID);
            if (guest == null)
                throw new Exception("Guest not found. Please add the guest first.");

            var room = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
            if (room == null)
                throw new Exception("Room does not exist.");
            if (room.IsReserved)
                throw new Exception("Room is already reserved.");

            room.ReservationInfo = new Reservation(guest, nights);
            room.IsReserved = true;
        }

        // View all current reservation 
        public void ViewAllReservations()
        {
            foreach (var room in rooms.Where(r => r.IsReserved))
            {
                double total = room.ReservationInfo.Nights * room.DailyRate;
                Console.WriteLine($"Guest: {room.ReservationInfo.GuestInfo.Name}, Phone: {room.ReservationInfo.GuestInfo.PhoneNumber}, Room: {room.RoomNumber}, Nights: {room.ReservationInfo.Nights}, Rate: {room.DailyRate}, Total: {total}");
            }
        }


        // Search for reservation by guest name (case-insensitive)

        public void SearchReservationByGuest(string guestName)
        {
            var result = rooms.FirstOrDefault(r => r.IsReserved && r.ReservationInfo.GuestInfo.Name.Equals(guestName, StringComparison.OrdinalIgnoreCase));
            if (result != null)
                Console.WriteLine(result);
            else
                Console.WriteLine("Reservation not found.");
        }

        // Show guest who paid the most

        public void ShowHighestPayingGuest()
        {
            var reservedRooms = rooms.Where(r => r.IsReserved);
            if (!reservedRooms.Any())
            {
                Console.WriteLine("No reservations found.");
                return;
            }

            var highest = reservedRooms.OrderByDescending(r => r.ReservationInfo.Nights * r.DailyRate).First();
            double total = highest.ReservationInfo.Nights * highest.DailyRate;
            Console.WriteLine($"Highest Paying Guest: {highest.ReservationInfo.GuestInfo.Name} - Total: {total}");
        }


        // Cancel reservation by room number
        public void CancelReservation(int roomNumber)
        {
            var room = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
            if (room == null || !room.IsReserved)
            {
                Console.WriteLine("No reservation found for this room.");
                return;
            }

            room.IsReserved = false;
            room.ReservationInfo = null;
            Console.WriteLine($"Reservation for room {roomNumber} canceled.");
        }



    }
}
