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
        public List<Guest> Guests { get; private set; }  // Guests list
        public List<Room> Rooms { get; private set; }    // Rooms list

        // Load all saved data on startup
        public HotelManagement()
        {
            Guests = Guest.LoadGuests("Guests.txt");
            Rooms = Room.LoadRooms("Rooms.txt");
            Reservation.LoadReservations(Rooms, Guests, "Reservations.txt");
        }


        // Method to add a new guest to the guests list
        public void AddGuest(Guest guest)
        {
            if (Guests.Any(g => g.NationalID == guest.NationalID)) // Check if there is already a guest with the same National ID in the list
                throw new Exception("Guest with this National ID already exists."); // If found, throw an exception to prevent duplicate National ID
            Guests.Add(guest);  // If no duplicate is found, add the guest to the list
        }


        
        // Display all guests
        public void ViewAllGuests()
        {
            if (Guests.Count > 0)
            {
                foreach (var guest in Guests)
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
            return Guests.FirstOrDefault(g => g.NationalID == nationalID);
        }

        // Add new room to the system
        public void AddRoom(int roomNumber, double dailyRate)
        {
            if (Rooms.Any(r => r.RoomNumber == roomNumber))
                throw new Exception("Room number must be unique.");
            //update Console.ReadLine();
            Rooms.Add(new Room(roomNumber, dailyRate));
            Console.WriteLine("Room data has been successfully entered.");
            Console.ReadLine();
        }

        // View all rooms and their stuatus 

        public void ViewAllRooms()
            {
            if (Rooms.Count > 0)
            {
                foreach (var room in Rooms)
                    Console.WriteLine(room);
            }
            else
            { 
            Console.WriteLine("You have not added any room.");
            
            }
        }

        // Reserve a room for an existing guest
        public void ReserveRoom(string nationalID, int roomNumber, DateTime checkInDateTime, int nights)
        {
            var guest = FindGuestByNationalID(nationalID);
            if (guest == null)
                throw new Exception("Guest not found. Please add the guest first.");

            var room = Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
            if (room == null)
                throw new Exception("Room does not exist.");

            if (room.IsReserved)
            {
                // If the requested check-in date is before the current check-out, deny reservation
                if (checkInDateTime < room.ReservationInfo.CheckOutDateTime)
                    throw new Exception($"Room is already reserved until {room.ReservationInfo.CheckOutDateTime}.");
            }

            room.ReservationInfo = new Reservation(guest, checkInDateTime, nights);
            room.IsReserved = true;
        }

        // View all current reservation 
        public void ViewAllReservations()
        {
            foreach (var room in Rooms.Where(r => r.IsReserved))
            {
                double total = room.ReservationInfo.Nights * room.DailyRate;
                Console.WriteLine($"Guest: {room.ReservationInfo.GuestInfo.Name}, Phone: {room.ReservationInfo.GuestInfo.PhoneNumber}, " +
                                  $"Room: {room.RoomNumber}, Nights: {room.ReservationInfo.Nights}, " +
                                  $"Check-In: {room.ReservationInfo.CheckInDateTime}, " +
                                  $"Check-Out: {room.ReservationInfo.CheckOutDateTime}, " +
                                  $"Rate: {room.DailyRate}, Total: {total}");
            }
        }


        // Search for reservation by guest name (case-insensitive)

        public void SearchReservationByGuest(string guestName)
        {
            var result = Rooms.FirstOrDefault(r => r.IsReserved && r.ReservationInfo.GuestInfo.Name.Equals(guestName, StringComparison.OrdinalIgnoreCase));
            if (result != null)
                Console.WriteLine(result);
            else
                Console.WriteLine("Reservation not found.");
        }

        // Show guest who paid the most

        public void ShowHighestPayingGuest()
        {
            var reservedRooms = Rooms.Where(r => r.IsReserved);
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
            var room = Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
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
