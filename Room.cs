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
            //Console.ReadLine();
            if (dailyRate < 100)
                throw new ArgumentException("Daily rate must be at least 100.");
           // Console.ReadLine();

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
            return $"Room {RoomNumber} - Reserved by {ReservationInfo.GuestInfo.Name} - Nights: {ReservationInfo.Nights} - Total: {totalCost}";
        }

        // Load rooms from a file 

        public static List<Room> LoadRooms(string filePath)
        {
            List<Room> rooms = new List<Room>();
            if (!File.Exists(filePath)) return rooms;

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                var room = new Room(int.Parse(parts[0]), double.Parse(parts[1]))
                {
                    IsReserved = parts[2] == "1"
                };
                rooms.Add(room);
            }
            return rooms;
        }



        // Save rooms to a file

        public static void SaveRooms(List<Room> rooms, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var room in rooms)
                {
                    string reserved = room.IsReserved ? "1" : "0";
                    writer.WriteLine($"{room.RoomNumber}|{room.DailyRate}|{reserved}");
                }

            }
        }








    }
}





