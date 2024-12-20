//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ReservationHotel
//{
//    internal class Class1
//    {
//    }
//}




//namespace HotelReservation
//{
//    class Reservation
//    {
//        public string Numero { get; set; }
//        public string NomClient { get; set; }
//        public string TypeService { get; set; }
//        public DateTime DateReservation { get; set; }
//    }

//    class Program
//    {
//        static List<Reservation> reservations = new List<Reservation>();
//        static int disponibilitesTable = 10;
//        static int disponibilitesChambre = 5;
//        static int disponibilitesSuite = 3;
//        static int disponibilitesSalle = 2;

//        static void Main(string[] args)
//        {
//            while (true)
//            {
//                Console.Clear();
//                Console.WriteLine("=== Application de Réservation d'Hôtel ===");
//                Console.WriteLine("1 - Réserver");
//                Console.WriteLine("2 - Annuler une réservation");
//                Console.WriteLine("3 - Modifier une réservation");
//                Console.WriteLine("4 - Rechercher");
//                Console.WriteLine("5 - Aide");
//                Console.WriteLine("0 - Quitter");
//                Console.Write("Choisissez une option : ");

//                string choixPrincipal = Console.ReadLine();
//                switch (choixPrincipal)
//                {
//                    case "1":
//                        Reserver();
//                        break;
//                    case "2":
//                        Annuler();
//                        break;
//                    case "3":
//                        Modifier();
//                        break;
//                    case "4":
//                        Rechercher();
//                        break;
//                    case "5":
//                        Aide();
//                        break;
//                    case "0":
//                        Console.WriteLine("Merci d'avoir utilisé l'application !");
//                        return;
//                    default:
//                        Console.WriteLine("Option invalide. Appuyez sur Entrée pour réessayer.");
//                        Console.ReadLine();
//                        break;
//                }
//            }
//        }

//        static void Reserver()
//        {
//            Console.Clear();
//            Console.WriteLine("=== Réserver ===");
//            Console.WriteLine("1 - Une table (disponibilités: " + disponibilitesTable + ")");
//            Console.WriteLine("2 - Une chambre (disponibilités: " + disponibilitesChambre + ")");
//            Console.WriteLine("3 - Une suite (disponibilités: " + disponibilitesSuite + ")");
//            Console.WriteLine("4 - Une salle de conférence (disponibilités: " + disponibilitesSalle + ")");
//            Console.Write("Choisissez une option : ");
//            string choixReservation = Console.ReadLine();

//            string typeService = "";
//            switch (choixReservation)
//            {
//                case "1":
//                    if (disponibilitesTable > 0) { typeService = "Table"; disponibilitesTable--; }
//                    else { Console.WriteLine("Aucune table disponible."); return; }
//                    break;
//                case "2":
//                    if (disponibilitesChambre > 0) { typeService = "Chambre"; disponibilitesChambre--; }
//                    else { Console.WriteLine("Aucune chambre disponible."); return; }
//                    break;
//                case "3":
//                    if (disponibilitesSuite > 0) { typeService = "Suite"; disponibilitesSuite--; }
//                    else { Console.WriteLine("Aucune suite disponible."); return; }
//                    break;
//                case "4":
//                    if (disponibilitesSalle > 0) { typeService = "Salle de conférence"; disponibilitesSalle--; }
//                    else { Console.WriteLine("Aucune salle de conférence disponible."); return; }
//                    break;
//                default:
//                    Console.WriteLine("Option invalide. Réessayez.");
//                    return;
//            }

//            Console.Write("Entrez votre nom : ");
//            string nomClient = Console.ReadLine();
//            string numeroReservation = Guid.NewGuid().ToString(); // Génération d'un numéro de réservation unique
//            reservations.Add(new Reservation { Numero = numeroReservation, NomClient = nomClient, TypeService = typeService, DateReservation = DateTime.Now });

//            Console.WriteLine($"Réservation confirmée pour {nomClient} : {typeService} (Numéro: {numeroReservation})");
//            RetourMenu();
//        }

//        static void Annuler()
//        {
//            Console.Clear();
//            Console.WriteLine("=== Annuler une réservation ===");
//            Console.Write("Entrez le numéro de réservation : ");
//            string numeroReservation = Console.ReadLine();
//            var reservation = reservations.Find(r => r.Numero == numeroReservation);

//            if (reservation != null)
//            {
//                Console.WriteLine($"Êtes-vous sûr de vouloir annuler la réservation numéro {numeroReservation} ? (O/N)");
//                if (Console.ReadLine().ToUpper() == "O")
//                {
//                    reservations.Remove(reservation);
//                    Console.WriteLine("Réservation annulée.");
//                    // Rétablir la disponibilité
//                    if (reservation.TypeService == "Table") disponibilitesTable++;
//                    else if (reservation.TypeService == "Chambre") disponibilitesChambre++;
//                    else if (reservation.TypeService == "Suite") disponibilitesSuite++;
//                    else if (reservation.TypeService == "Salle de conférence") disponibilitesSalle++;
//                }
//            }
//            else
//            {
//                Console.WriteLine("Numéro de réservation invalide.");
//            }
//            RetourMenu();
//        }

//        static void Modifier()
//        {
//            Console.Clear();
//            Console.WriteLine("=== Modifier une réservation ===");
//            Console.Write("Entrez le numéro de réservation : ");
//            string numeroReservation = Console.ReadLine();
//            var reservation = reservations.Find(r => r.Numero == numeroReservation);

//            if (reservation != null)
//            {
//                Console.WriteLine($"Réservation trouvée pour {reservation.NomClient}.");
//                Console.WriteLine("Choisissez un nouveau type de service :");
//                Console.WriteLine("1 - Une table");
//                Console.WriteLine("2 - Une chambre");
//                Console.WriteLine("3 - Une suite");
//                Console.WriteLine("4 - Une salle de conférence");
//                Console.Write("Choisissez une option : ");
//                string choixReservation = Console.ReadLine();

//                // Logique de modification similaire à la réservation
//                // À compléter selon les besoins exacts
//                // ...
//            }
//            else
//            {
//                Console.WriteLine("Numéro de réservation invalide.");
//            }
//            RetourMenu();
//        }

//        static void Rechercher()
//        {
//            Console.Clear();
//            Console.WriteLine("=== Rechercher ===");
//            Console.Write("Entrez le numéro de réservation à rechercher : ");
//            string numeroReservation = Console.ReadLine();
//            var reservation = reservations.Find(r => r.Numero == numeroReservation);

//            if (reservation != null)
//            {
//                Console.WriteLine($"Réservation trouvée : {reservation.NomClient}, {reservation.TypeService}, Date : {reservation.DateReservation}");
//            }
//            else
//            {
//                Console.WriteLine("Aucune réservation trouvée pour ce numéro.");
//            }
//            RetourMenu();
//        }

//        static void Aide()
//        {
//            Console.Clear();
//            Console.WriteLine("=== Aide ===");
//            Console.WriteLine("1 - Réserver : Choisissez le type de service à réserver.");
//            Console.WriteLine("2 - Annuler : Entrez le numéro de réservation pour annuler.");
//            Console.WriteLine("3 - Modifier : Entrez le numéro de réservation pour modifier.");
//            Console.WriteLine("4 - Rechercher : Entrez le numéro de réservation pour afficher les détails.");
//            Console.WriteLine("0 - Quitter : Ferme l'application.");
//            RetourMenu();
//        }

//        static void RetourMenu()
//        {
//            Console.WriteLine("\nAppuyez sur Entrée pour revenir au menu principal.");
//            Console.ReadLine();
//        }
//    }
//}