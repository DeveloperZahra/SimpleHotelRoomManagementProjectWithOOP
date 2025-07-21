using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHotelRoomManagementProjectWithOOP
{
    //__________This class includes save and load files__________ 
    internal class Files
    {

        // Save guests to a text file
        public static void SaveGuests(List<Guest> guests, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var guest in guests)
                {
                    writer.WriteLine($"{guest.Name}|{guest.PhoneNumber}|{guest.NationalID}");
                }
            }
        }



        // Load guests from a text file
        public static List<Guest> LoadGuests(string filePath)
        {
            List<Guest> guests = new List<Guest>();
            if (!File.Exists(filePath)) return guests;

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                guests.Add(new Guest(parts[0], parts[1], parts[2]));
            }
            return guests;
        }

        //________________________

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

        //____________________

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
}

