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


        // Load reservations from file and reconnect to guests and rooms
        public static void LoadReservations(List<Room> rooms, List<Guest> guests, string filePath)
        {
            if (!File.Exists(filePath)) return;

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                int roomNumber = int.Parse(parts[0]);
                string nationalID = parts[1];
                int nights = int.Parse(parts[2]);
                DateTime checkIn = DateTime.Parse(parts[3]);
                DateTime checkOut = DateTime.Parse(parts[4]);

                var room = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
                var guest = guests.FirstOrDefault(g => g.NationalID == nationalID);

                if (room != null && guest != null)
                {
                    room.ReservationInfo = new Reservation(guest, checkIn, nights)
                    {
                        CheckOutDateTime = checkOut
                    };
                    room.IsReserved = true;
                }
            }
        }

            // Save all reservations into file 

        public static void SaveReservations(List<Room> rooms, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var room in rooms.Where(r => r.IsReserved))
                {
                    var res = room.ReservationInfo;
                    writer.WriteLine($"{room.RoomNumber}|{res.GuestInfo.NationalID}|{res.Nights}|" +
                                     $"{res.CheckInDateTime:yyyy-MM-dd HH:mm}|{res.CheckOutDateTime:yyyy-MM-dd HH:mm}");
                }


            }
        }



    }
}
