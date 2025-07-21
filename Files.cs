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
    }
}

