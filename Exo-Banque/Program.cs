using Exo_Banque.Models;

namespace Exo_Banque
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Banque b1 = new Banque() { Nom = "DonneTonFric" };

            Console.WriteLine($"Bienvenu chez {b1.Nom}.");
            Console.Write("Veuillez indiquer votre nom : ");
            string nom = Console.ReadLine();
            Console.Write("Veuillez indiquer votre prénom : ");
            string prenom = Console.ReadLine();

            int jour, mois, annee;
            do {
                Console.Write("Veuillez indiquer le jour de votre naissance : ");
            } while (!int.TryParse(Console.ReadLine(), out jour) || jour < 1 || jour > 31);
            do {
                Console.Write("Veuillez indiquer le mois de votre naissance : ");
            } while (!int.TryParse(Console.ReadLine(), out mois) || mois < 1 || mois > 12);
            do
            {
                Console.Write("Veuillez indiquer l'année de votre naissance : ");
            } while (!int.TryParse(Console.ReadLine(), out annee) || annee < 1900 || annee > DateTime.Now.Year);

            Personne p1 = new Personne() { 
                Nom = nom,
                Prenom = prenom,
                DateNaiss = new DateTime(annee,mois,jour)
            };

            Console.WriteLine($"Bonjour {p1.Prenom} {p1.Nom}!");

            Courant c1 = new Courant() { 
                Numero = "BE1234",
                LigneDeCredit = 50,
                Titulaire = p1
            };

            b1.Ajouter(c1);

            Console.WriteLine($"Votre premier compte est {c1.Numero}.");

            string reponse;
            do
            {
                Console.WriteLine("Voulez-vous ajouter un compte ? (Oui - Non)");
                reponse = Console.ReadLine();
                if (reponse == "Oui")
                {
                    string numero;
                    do
                    {
                        Console.WriteLine("Quel est le numéro de compte ?");
                        numero = Console.ReadLine();
                    } while (b1[numero] != null);
                    double ligneCredit;
                    do
                    {
                        Console.WriteLine("Quel est la limite de votre ligne de crédit ?");
                    } while (!double.TryParse(Console.ReadLine(), out ligneCredit));

                    b1.Ajouter(new Courant()
                    {
                        Numero = numero,
                        LigneDeCredit = ligneCredit,
                        Titulaire = p1
                    });
                }
            } while (reponse == "Oui") ;



                Courant monCompte;
                do
                {
                    Console.WriteLine($"Pouvez-vous me donner votre numéro de compte ?");
                    string numero_str = Console.ReadLine();
                    monCompte = b1[numero_str];
                } while (monCompte == null);


                string input;
                do
                {
                    Console.WriteLine($"Le compte {monCompte.Numero}, appartenant à {monCompte.Titulaire.Nom} {monCompte.Titulaire.Prenom}, a un solde de {monCompte.Solde} € et autorise une ligne de crédit de {monCompte.LigneDeCredit} €.");

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
                            monCompte.Depot(argent);
                            break;
                        case "2":
                            do
                            {
                                Console.WriteLine("Quel montant voulez-vous retirer ?");
                            } while (!double.TryParse(Console.ReadLine(), out argent));
                            monCompte.Retrait(argent);
                            break;
                        case "3":
                            Console.WriteLine($"Merci d'utiliser {b1.Nom}! Au revoir!");
                            break;
                    }
                } while (input != "3");
        }
    }
}
