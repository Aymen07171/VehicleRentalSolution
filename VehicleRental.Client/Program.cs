using System;
using VehicleRental.Contracts.DTOs;                  // ← ADD this line
using VehicleRental.Client.UserServiceRef;
using VehicleRental.Client.VehicleServiceRef;
using VehicleRental.Client.ReservationServiceRef;

namespace VehicleRental.Client
{
    class Program
    {
        static UserDTO currentUser = null;

        static void Main(string[] args)
        {
            Console.WriteLine("=============================");
            Console.WriteLine("   VEHICLE RENTAL SYSTEM    ");
            Console.WriteLine("=============================");

            while (true)
            {
                if (currentUser == null)
                    ShowGuestMenu();
                else
                    ShowUserMenu();
            }
        }

        static void ShowGuestMenu()
        {
            Console.WriteLine("\n--- MAIN MENU ---");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Browse available vehicles");
            Console.WriteLine("0. Exit");
            Console.Write("\nChoose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": Register(); break;
                case "2": Login(); break;
                case "3": BrowseVehicles(); break;
                case "0": Environment.Exit(0); break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }

        static void ShowUserMenu()
        {
            Console.WriteLine($"\n--- WELCOME, {currentUser.FullName} ---");
            Console.WriteLine("1. Browse available vehicles");
            Console.WriteLine("2. Book a vehicle");
            Console.WriteLine("3. My reservations");
            Console.WriteLine("4. Cancel a reservation");
            Console.WriteLine("5. Logout");
            Console.Write("\nChoose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": BrowseVehicles(); break;
                case "2": BookVehicle(); break;
                case "3": ViewMyReservations(); break;
                case "4": CancelReservation(); break;
                case "5": Logout(); break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }

        static void Register()
        {
            Console.WriteLine("\n--- REGISTER ---");

            Console.Write("Full name: ");
            string name = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            Console.Write("Phone: ");
            string phone = Console.ReadLine();

            using (UserServiceClient client = new UserServiceClient())
            {
                bool success = client.Register(name, email, password, phone);

                if (success)
                    Console.WriteLine("\nRegistration successful! You can now log in.");
                else
                    Console.WriteLine("\nRegistration failed. Email may already exist.");
            }
        }

        static void Login()
        {
            Console.WriteLine("\n--- LOGIN ---");

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            using (UserServiceClient client = new UserServiceClient())
            {
                // ✅ Fully qualified
                UserServiceRef.UserDTO user = client.Login(email, password);

                if (user != null)
                {
                    currentUser = user;
                    Console.WriteLine($"\nWelcome back, {user.FullName}!");
                }
                else
                {
                    Console.WriteLine("\nInvalid email or password.");
                }
            }
        }

        static void BrowseVehicles()
        {
            Console.WriteLine("\n--- AVAILABLE VEHICLES ---");

            using (VehicleServiceClient client = new VehicleServiceClient())
            {
                VehicleDTO[] vehicles = client.GetAvailableVehicles();

                if (vehicles == null || vehicles.Length == 0)
                {
                    Console.WriteLine("No vehicles available right now.");
                    return;
                }

                Console.WriteLine($"\n{"ID",-5} {"Brand",-12} {"Model",-12} {"Year",-6} {"Price/Day",-12} {"Plate",-12}");
                Console.WriteLine(new string('-', 60));

                foreach (VehicleDTO v in vehicles)
                {
                    Console.WriteLine(
                        $"{v.VehicleId,-5} {v.Brand,-12} {v.Model,-12} {v.Year,-6} ${v.PricePerDay,-11} {v.LicensePlate,-12}");
                }
            }
        }

        static void BookVehicle()
        {
            Console.WriteLine("\n--- BOOK A VEHICLE ---");

            BrowseVehicles();

            Console.Write("\nEnter Vehicle ID to book: ");
            if (!int.TryParse(Console.ReadLine(), out int vehicleId))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            Console.Write("Start date (yyyy-mm-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime startDate))
            {
                Console.WriteLine("Invalid date format.");
                return;
            }

            Console.Write("End date (yyyy-mm-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime endDate))
            {
                Console.WriteLine("Invalid date format.");
                return;
            }

            using (VehicleServiceClient vClient = new VehicleServiceClient())
            {
                VehicleDTO vehicle = vClient.GetVehicleById(vehicleId);

                if (vehicle == null)
                {
                    Console.WriteLine("Vehicle not found.");
                    return;
                }

                int days = (endDate - startDate).Days;
                decimal totalPrice = days * vehicle.PricePerDay;

                Console.WriteLine($"\nSummary:");
                Console.WriteLine($"  Vehicle    : {vehicle.Brand} {vehicle.Model}");
                Console.WriteLine($"  Duration   : {days} day(s)");
                Console.WriteLine($"  Total price: ${totalPrice}");
                Console.Write("\nConfirm booking? (y/n): ");

                if (Console.ReadLine().ToLower() != "y")
                {
                    Console.WriteLine("Booking cancelled.");
                    return;
                }
            }

            using (ReservationServiceClient rClient = new ReservationServiceClient())
            {
                bool success = rClient.BookVehicle(
                    currentUser.UserId, vehicleId, startDate, endDate);

                if (success)
                    Console.WriteLine("\nBooking confirmed!");
                else
                    Console.WriteLine("\nBooking failed. Vehicle may no longer be available.");
            }
        }

        static void ViewMyReservations()
        {
            Console.WriteLine("\n--- MY RESERVATIONS ---");

            using (ReservationServiceClient client = new ReservationServiceClient())
            {
                ReservationDTO[] reservations =
                    client.GetUserReservations(currentUser.UserId);

                if (reservations == null || reservations.Length == 0)
                {
                    Console.WriteLine("You have no reservations.");
                    return;
                }

                Console.WriteLine($"\n{"ID",-5} {"Vehicle ID",-12} {"Start",-14} {"End",-14} {"Price",-10} {"Status"}");
                Console.WriteLine(new string('-', 65));

                foreach (ReservationDTO r in reservations)
                {
                    Console.WriteLine(
                        $"{r.ReservationId,-5} {r.VehicleId,-12} " +
                        $"{r.StartDate.ToShortDateString(),-14} " +
                        $"{r.EndDate.ToShortDateString(),-14} " +
                        $"${r.TotalPrice,-9} {r.Status}");
                }
            }
        }

        static void CancelReservation()
        {
            Console.WriteLine("\n--- CANCEL A RESERVATION ---");

            ViewMyReservations();

            Console.Write("\nEnter Reservation ID to cancel: ");
            if (!int.TryParse(Console.ReadLine(), out int reservationId))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            Console.Write("Are you sure? (y/n): ");
            if (Console.ReadLine().ToLower() != "y")
            {
                Console.WriteLine("Cancellation aborted.");
                return;
            }

            using (ReservationServiceClient client = new ReservationServiceClient())
            {
                bool success = client.CancelReservation(reservationId);

                if (success)
                    Console.WriteLine("\nReservation cancelled. Vehicle is now available again.");
                else
                    Console.WriteLine("\nCancellation failed. Reservation may not exist.");
            }
        }

        static void Logout()
        {
            Console.WriteLine($"\nGoodbye, {currentUser.FullName}!");
            currentUser = null;
        }

    }   // ← closes class Program
}       // ← closes namespace VehicleRental.Client