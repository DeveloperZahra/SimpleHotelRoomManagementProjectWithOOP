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













    }
}

