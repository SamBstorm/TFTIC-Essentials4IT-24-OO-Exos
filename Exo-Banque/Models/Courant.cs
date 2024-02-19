using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Banque.Models
{
    internal class Courant
    {
        public string Numero { get; set; }
        public Personne Titulaire { get; set; }

        private double _ligneDeCredit;

        public double LigneDeCredit
        {
            get { return _ligneDeCredit; }
            set { 
                if( value >= 0)
                {
                    _ligneDeCredit = value; 
                }
            }
        }

        private double _solde;

        public double Solde
        {
            get { return _solde; }
            private set {
                if( value >= -LigneDeCredit)
                {
                    _solde = value;
                }
            }
        }

        public void Depot(double montant)
        {
            if( montant <= 0) return; // A revoir lors des Exceptions
            Solde += montant;
        }

        public void Retrait(double montant)
        {
            if( montant <= 0) return; // A revoir lors des Exceptions
            if (LigneDeCredit + Solde < montant) return; // A revoir lors des Exceptions
            Solde -= montant;
        }
    }
}
