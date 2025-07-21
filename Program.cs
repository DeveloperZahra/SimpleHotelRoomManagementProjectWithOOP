namespace SimpleHotelRoomManagementProjectWithOOP
{
    internal class Program
    {
        static void Main(string[] args)

        {
           

                // Create an instance of the HotelManagement class to manage the hotel operations

                HotelManagement hotel = new HotelManagement();
            bool GoList = true;

            while (GoList) // Start an infinite loop to keep showing the menu until the user chooses to exit
            {
                Console.Clear();
                // Display the main menu options to the user
                Console.WriteLine("\n__________Hotel Management System__________");
                Console.WriteLine("1. Add Guest");
                Console.WriteLine("2. View All Guests");
                Console.WriteLine("3. Add Room");
                Console.WriteLine("4. View All Rooms");
                Console.WriteLine("5. Reserve Room");
                Console.WriteLine("6. View All Reservations");
                Console.WriteLine("7. Search Reservation by Guest Name");
                Console.WriteLine("8. Show Highest Paying Guest");
                Console.WriteLine("9. Cancel Reservation");
                Console.WriteLine("0. Save & Exit");
                Console.Write("Choose an option: ");
                Console.WriteLine("\nPress any key to return to the main menu...");

                int choice = int.Parse(Console.ReadLine()); // Read the user choice from the console and convert it to an integer
                try
                {
                    

                    switch (choice) // Perform an action depending on the user's choice
                    {
                        case 1:
                            // Ask the user to input guest information and add a new guest
                            Console.Write("Guest Name: ");
                            string name = Console.ReadLine();
                            Console.Write("Phone Number: ");
                            string phone = Console.ReadLine();
                            Console.Write("National ID: ");
                            string id = Console.ReadLine();
                            hotel.AddGuest(new Guest(name, phone, id));
                            Console.WriteLine("Successfully add guest");
                            Console.ReadLine();
                            break;

                        case 2:
                            // Display all guests in the hotel
                            hotel.ViewAllGuests();
                            Console.ReadLine();
                            break;

                        case 3:
                            // Ask the user to input room information and add a new room
                            Console.Write("Room Number: ");
                            int roomNum = int.Parse(Console.ReadLine());
                            Console.Write("Daily Rate: ");
                            double rate = double.Parse(Console.ReadLine());
                            hotel.AddRoom(roomNum, rate);
                          
                            break;

                        case 4:
                            // Display all rooms in the hotel
                            hotel.ViewAllRooms();
                            Console.ReadLine();
                            break;

                        case 5:
                            // // Request reservation details from the user: National ID, Room Number, Check-In Date, and Number of Nights.
                            Console.Write("Guest National ID: ");
                            string nationalID = Console.ReadLine();
                            Console.Write("Room Number: ");
                            int reserveRoom = int.Parse(Console.ReadLine());
                            Console.Write("Check-In Date (yyyy-MM-dd HH:mm): ");
                            DateTime checkInDate = DateTime.Parse(Console.ReadLine());
                            Console.Write("Nights: ");
                            int nights = int.Parse(Console.ReadLine());
                            hotel.ReserveRoom(nationalID, reserveRoom, checkInDate, nights);
                            Console.WriteLine("Visitor data has been successfully verified.");
                            Console.ReadLine();
                            break;

                        case 6:
                            // Display all reservations
                            hotel.ViewAllReservations();
                            Console.WriteLine("All reservations have been successfully displayed.");
                            Console.ReadLine();
                            break;

                        case 7:
                            // Search for a reservation by guest name
                            Console.Write("Guest Name to Search: ");
                            string searchName = Console.ReadLine();
                            hotel.SearchReservationByGuest(searchName);
                            Console.WriteLine("A reservation was successfully found for the guest's name.");
                            Console.ReadLine();
                            break;

                        case 8:
                            // Show the guest who paid the most (highest total payment)
                            hotel.ShowHighestPayingGuest();
                            Console.WriteLine("The guest who paid the highest amount has been successfully found.");
                            Console.ReadLine();
                            break;

                        case 9:
                            // Ask for a room number to cancel its reservation
                            Console.Write("Room Number to Cancel: ");
                            int cancelRoom = int.Parse(Console.ReadLine());
                            hotel.CancelReservation(cancelRoom);
                            Console.WriteLine("The room number was successfully found to cancel the reservation.");
                            Console.ReadLine();
                            break;

                        case 0:
                            // Exit the program
                            GoList =false;
                            hotel.SaveAll();
                            Console.WriteLine("Data saved successfully. Exiting...");
                            return;
                            break;

                        default:
                            // Handle invalid menu choices
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // Handle and display any errors that occur during user input or execution
                    Console.WriteLine($"Error: {ex.Message}");
                }

            }


        }

    }
}
