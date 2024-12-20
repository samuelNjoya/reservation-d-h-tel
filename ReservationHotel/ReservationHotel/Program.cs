using System;

namespace HotelReservation
{

    // la classe reservation
    class Reservation
    {
        public string Numero { get; set; }
        public string NomClient { get; set; }
        public string TypeService { get; set; }
        public DateTime DateReservation { get; set; }
        public decimal Prix { get; set; }
    }


    class Program
    {
        static List<Reservation> reservations = new List<Reservation>();
        static int disponibilitesTable = 0;
        static int disponibilitesChambre = 5;
        static int disponibilitesSuite = 3;
        static int disponibilitesSalle = 0;

        static decimal prixTable = 50.00m; 
        static decimal prixChambre = 100.00m; 
        static decimal prixSuite = 150.00m;  
        static decimal prixSalle = 200.00m;  
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("== Application  de reservation d'hotel ==");
                Console.WriteLine("1 - Reserver");
                Console.WriteLine("2 - Annuler une reservation");
                Console.WriteLine("3 - Modifier une reservaiton");
                Console.WriteLine("4 - Rechercher une reservation");
                Console.WriteLine("5 - Afficher toutes les réservations");
                Console.WriteLine("0 - Quitter ");
                Console.Write("Choisissez une option : ");

                string choicePrincipal = Console.ReadLine();

                switch(choicePrincipal)
                {
                    case "1":
                        Reserver();
                        break;
                    case "2":
                        Annuler();
                        break;
                    case "3":
                        Modifier();
                        break;
                    case "4":
                        Rechercher();
                        break;
                    case "5":
                        AfficherReservations();
                        break;
                    case "0":
                        Console.WriteLine("Merci d'avoir utiliser l'application !");
                        return;
                    default:
                        Console.WriteLine("Option invalide. Appuyer sur Enter pour reessayer");
                        Console.ReadLine();
                        break;
                }
            }
        }
        public static string GenererNumeroReservationUnique()
        {
            Random random = new Random();
            int number = random.Next(10000, 100000); // Génère un nombre entre 10000 et 99999
            return "RES" + number.ToString();
        }

        static void Reserver()
        {
            Console.Clear();
            Console.WriteLine("=== Reserver ==== \n");
            Console.WriteLine("1 - Une table (disponibilités: " + disponibilitesTable + ", Prix: " + prixTable + " €)");
            Console.WriteLine("2 - Une chambre (disponibilités: " + disponibilitesChambre + ", Prix: " + prixChambre + " €)");
            Console.WriteLine("3 - Une suite (disponibilités: " + disponibilitesSuite + ", Prix: " + prixSuite + " €)");
            Console.WriteLine("4 - Une salle de conférence (disponibilités: " + disponibilitesSalle + ", Prix: " + prixSalle + " €)");

            Console.Write("Choisissez une option: ");

            string choice = Console.ReadLine();

            string typeService = "";
            decimal prixService = 0;


            switch (choice)
            {
                case "1":
                    if (disponibilitesTable > 0) { 
                        typeService = "Table";
                        prixService = prixTable;
                        Console.WriteLine("Reservation d'une Table confirmer");
                        disponibilitesTable--;
                    }else {
                        Console.WriteLine("\n Aucune table disponible.");
                        return;
                    }
                    break;
                case "2":
                    if (disponibilitesChambre > 0)
                    {
                        typeService = "Chambre";
                        prixService = prixChambre;
                        Console.WriteLine("Reservation d'une Chambre confirmer");
                        disponibilitesChambre--;
                    }
                    else
                    {
                        Console.WriteLine("\n Aucune chambre disponible.");
                        return;
                    }
                    break;
                case "3":
                    if (disponibilitesSuite > 0)
                    {
                        typeService = "Suite";
                        prixService = prixSuite;
                        Console.WriteLine("Reservation d'une Suite confirmer");
                        disponibilitesSuite--;
                    }
                    else
                    {
                        Console.WriteLine("\n Aucune suite disponible.");
                        return;
                    }
                    break;
                case "4":
                    if (disponibilitesSalle > 0)
                    {
                        typeService = "Salle";
                        prixService = prixSalle;
                        Console.WriteLine("Reservation d'une salle confirmer");
                        disponibilitesSalle--;
                    }
                    else
                    {
                        Console.WriteLine("\n Aucune salle disponible.");
                        Console.WriteLine();
                        return;
                    }
                    break;
                default:
                    Console.WriteLine("Option invalide. Reessayer");
                    break;
            }

            Console.Write("Entrez votre nom : ");
            string nomClient = Console.ReadLine();
            // string numeroReservation = Guid.NewGuid().ToString(); // Génération d'un numéro de réservation unique
            string numeroReservation = GenererNumeroReservationUnique();
            reservations.Add(new Reservation { Numero = numeroReservation, NomClient = nomClient, TypeService = typeService, Prix = prixService, DateReservation = DateTime.Now });

            Console.WriteLine($"Réservation confirmée pour {nomClient} : {typeService} (Numéro: {numeroReservation}, Prix: {prixService} €), Date de reservation: {DateTime.Now}");
            RetourMenu();
          
        }

        // Fonction annuler une reservation
        static void Annuler()
        {
           
            Console.Clear();
            Console.WriteLine("=== Annuler une réservation ===");
            Console.Write("Entrez le numéro de réservation : ");
            string numeroReservation = Console.ReadLine();//numberReservation
            var reservation = reservations.Find(r => r.Numero == numeroReservation);

            if (reservation != null)
            {
                Console.WriteLine($"Êtes-vous sûr de vouloir annuler la réservation numéro {numeroReservation} ? (O/N)");
                if (Console.ReadLine().ToUpper() == "O")
                {
                    reservations.Remove(reservation);
                    Console.WriteLine("Réservation annulée.");
                    // Rétablir la disponibilité
                    if (reservation.TypeService == "Table") disponibilitesTable++;
                    else if (reservation.TypeService == "Chambre") disponibilitesChambre++;
                    else if (reservation.TypeService == "Suite") disponibilitesSuite++;
                    else if (reservation.TypeService == "Salle de conférence") disponibilitesSalle++;
                }
            }
            else
            {
                Console.WriteLine("Numéro de réservation invalide.");
            }
            RetourMenu();
        }

     
        //Fonction modifier une reservation
        static void Modifier()
        {
            Console.Clear();
            Console.WriteLine("=== Modifier une réservation ===");
            Console.Write("Entrez le numéro de réservation : ");
            string numeroReservation = Console.ReadLine();
            var reservation = reservations.Find(r => r.Numero == numeroReservation);

            if (reservation != null)
            {
                // Rétablir la disponibilité de l'ancien service
                if (reservation.TypeService == "Table") disponibilitesTable++;
                else if (reservation.TypeService == "Chambre") disponibilitesChambre++;
                else if (reservation.TypeService == "Suite") disponibilitesSuite++;
                else if (reservation.TypeService == "Salle") disponibilitesSalle++;

                Console.WriteLine($"Réservation trouvée pour {reservation.NomClient}.");
                Console.WriteLine("Choisissez un nouveau type de service :");
                Console.WriteLine("1 - Une table");
                Console.WriteLine("2 - Une chambre");
                Console.WriteLine("3 - Une suite");
                Console.WriteLine("4 - Une salle de conférence");
                Console.Write("Choisissez une option : ");
                string choixReservation = Console.ReadLine();

                string nouveauService = "";
                switch (choixReservation)
                {
                    case "1":
                        if (disponibilitesTable > 0) { nouveauService = "Table"; disponibilitesTable--; }
                        else { Console.WriteLine("Aucune table disponible."); return; }
                        break;
                    case "2":
                        if (disponibilitesChambre > 0) { nouveauService = "Chambre"; disponibilitesChambre--; }
                        else { Console.WriteLine("Aucune chambre disponible."); return; }
                        break;
                    case "3":
                        if (disponibilitesSuite > 0) { nouveauService = "Suite"; disponibilitesSuite--; }
                        else { Console.WriteLine("Aucune suite disponible."); return; }
                        break;
                    case "4":
                        if (disponibilitesSalle > 0) { nouveauService = "Salle"; disponibilitesSalle--; }
                        else { Console.WriteLine("Aucune salle disponible."); return; }
                        break;
                    default:
                        Console.WriteLine("Option invalide. Reessayer.");
                        return;
                }

                // Mise à jour de la réservation
                reservation.TypeService = nouveauService;
                Console.WriteLine($"Réservation mise à jour pour {reservation.NomClient} : {nouveauService}.");
            }
            else
            {
                Console.WriteLine("Numéro de réservation invalide.");
            }
            RetourMenu();
        }

        //Rechercher une reservation
        static void Rechercher()
        {
            Console.Clear();
            Console.WriteLine("=== Rechercher ===");
            Console.Write("Entrez le numéro de réservation à rechercher : ");
            string numeroReservation = Console.ReadLine();
            var reservation = reservations.Find(r => r.Numero == numeroReservation);

            if (reservation != null)
            {
                Console.WriteLine($"Réservation trouvée : {reservation.NomClient}, {reservation.TypeService}, Date : {reservation.DateReservation}");
            }
            else
            {
                Console.WriteLine("Aucune réservation trouvée pour ce numéro.");
            }
            RetourMenu();
        }

        //fonction afficher toutes les reservations

        static void AfficherReservations()
        {
            Console.Clear();
            Console.WriteLine("=== Liste des réservations ===");

            if (reservations.Count == 0)
            {
                Console.WriteLine("Aucune réservation existante.");
            }
            else
            {
                foreach (var reservation in reservations)
                {
                    Console.WriteLine($"Numéro : {reservation.Numero}, Client : {reservation.NomClient}, Service : {reservation.TypeService}, Date : {reservation.DateReservation},Prix : {reservation.Prix} €");
                }
            }

            RetourMenu();
        }

        //static void Rechercher()
        //{
        //    Console.Clear();
        //    Console.WriteLine("=== Rechercher ====");
        //    Console.WriteLine("1 - prix");
        //    Console.WriteLine("2 - plats");
        //    Console.WriteLine("3 - places");
        //    Console.Write("Choisissez une option: ");

        //    string choice = Console.ReadLine();

        //    switch (choice)
        //    {
        //        case "1":
        //            Console.WriteLine("Affichage des prix ...");
        //            break;
        //        case "2":
        //            Console.WriteLine("Affichage des plats ...");
        //            break;
        //        case "3":
        //            Console.WriteLine("Affichage des places disponible ...");
        //            break;
        //        default:
        //            Console.WriteLine("Option invalide. Reessayer");
        //            break;
        //    }
        //    RetourMenu();
        //}

        static void RetourMenu()
        {
            Console.WriteLine("\nAppuyez sur Entrer pour revenir au menu principal.");
            Console.ReadLine();
        }

    }
}

