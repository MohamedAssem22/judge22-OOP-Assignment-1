using System;

namespace Part2_HotelReservationSystem;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("=== Starting Hotel Reservation System Test ===");

            // 1. Create a Guest
            Guest guest = new Guest(1, "Ahmed Ali", "01234567891");
            Console.WriteLine($"Guest Created: {guest.FullName} (ID: {guest.GuestId})");

            // 2. Create Rooms
            Room room1 = new Room(101, RoomType.Single, 150.0m);
            Room room2 = new Room(102, RoomType.Double, 250.0m);
            Console.WriteLine($"Rooms Created: Room {room1.RoomNumber} (${room1.NightlyRate}/night), Room {room2.RoomNumber} (${room2.NightlyRate}/night)");

            // 3. Test Maintenance Rule (Try to put room 2 under maintenance)
            room2.StartMaintenance();
            Console.WriteLine($"Room {room2.RoomNumber} is under maintenance: {room2.IsUnderMaintenance}");

            // 4. Try booking a room under maintenance (Should throw an Exception)
            try
            {
                Console.WriteLine("Attempting to book Room 102 (under maintenance)...");
                Reservation badReservation = new Reservation(
                    1, 
                    room2, 
                    guest, 
                    DateTime.Now.AddDays(1), 
                    DateTime.Now.AddDays(4)
                );
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"[Expected Error Caught]: {ex.Message}");
            }

            // 5. Create a Valid Reservation for Room 101
            Reservation reservation = new Reservation(
                10, 
                room1, 
                guest, 
                DateTime.Now.AddDays(1), 
                DateTime.Now.AddDays(4) 
            );
            
            Console.WriteLine($"\nReservation Created Successfully ID: {reservation.ReservationId}");
            Console.WriteLine($"Initial Status: {reservation.Status}");
            Console.WriteLine($"Total Cost for 3 nights: ${reservation.TotalCost}");

       
            Console.WriteLine("\nTesting State Transitions ");
            
            reservation.Confirm();
            Console.WriteLine($"Status after Confirm : {reservation.Status}");

            reservation.CheckIn();
            Console.WriteLine($"Status after CheckIn : {reservation.Status}");

            reservation.CheckOut();
            Console.WriteLine($"Status after CheckOut : {reservation.Status}");

            // 7. Guest History
            Console.WriteLine($"\nTotal reservations in guest history: {guest.ReservationsList.Count}");

            Console.WriteLine("\n All Tests Passed Successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected Error: {ex.Message}");
        }
    }
}