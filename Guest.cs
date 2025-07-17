using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHotelRoomManagementProjectWithOOP
{
    // This class represents a Guest (visitor) in the hotel.
    class Guest
    {
        public string Name { get; }
        public string NationalID { get; }
        public string RoomNumber { get; }
        public int Nights { get; }
    }
}
