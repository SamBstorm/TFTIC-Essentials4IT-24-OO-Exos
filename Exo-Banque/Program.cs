using Exo_Banque.Models;

namespace Exo_Banque
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Personne p1 = new Personne() { 
                Nom = "Legrain",
                Prenom = "Samuel",
                DateNaiss = new DateTime(1987,9,27)
            };

            Console.WriteLine($"Une personne s'appelle {p1.Nom} {p1.Prenom} et est né le {p1.DateNaiss}.");

            Courant c1 = new Courant() { 
                Numero = "BE1234",
                LigneDeCredit = 50,
                Titulaire = p1
            };

            string input;
            do
            {
                Console.WriteLine($"Le compte {c1.Numero}, appartenant à {c1.Titulaire.Nom} {c1.Titulaire.Prenom}, a un solde de {c1.Solde} € et autorise une ligne de crédit de {c1.LigneDeCredit} €.");

                Console.WriteLine("Voulez vous effectuer :");
                Console.WriteLine("1. Dépot");
                Console.WriteLine("2. Retrait");
                Console.WriteLine("3. Quitter");
                input = Console.ReadLine();
                while (input != "1" && input != "2" && input != "3")
                {
                    Console.WriteLine("Erreur! Voulez vous effectuer :");
                    Console.WriteLine("1. Dépot");
                    Console.WriteLine("2. Retrait");
                    Console.WriteLine("3. Quitter");
                    input = Console.ReadLine();
                }
                double argent;
                switch (input)
                {
                    case "1":
                        do
                        {
                            Console.WriteLine("Quel montant voulez-vous déposer ?");
                        } while (!double.TryParse(Console.ReadLine(), out argent));
                        c1.Depot(argent);
                        break;
                    case "2":
                        do
                        {
                            Console.WriteLine("Quel montant voulez-vous retirer ?");
                        } while (!double.TryParse(Console.ReadLine(), out argent));
                        c1.Retrait(argent);
                        break;
                    case "3":
                        Console.WriteLine("Merci d'utiliser banque3000! Au revoir!");
                        break;
                } 
            } while (input != "3");
        }
    }
}
