using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Banque.Models
{
    #region Class Banque avec une List<Courant>
    internal class Banque
    {
        public string Nom { get; set; }

        private List<Courant> _comptes = new List<Courant>();

        public Courant this[string numero]
        {
            get
            {
                foreach (Courant c in _comptes)
                {
                    if (c.Numero == numero) return c;
                }
                return null;
            }
        }

        public void Ajouter(Courant compte)
        {
            if (_comptes.Contains(compte)) return; //Gestion d'Exception
            _comptes.Add(compte);
        }

        public void Supprimer(string numero)
        {
            /*foreach (Courant c in _comptes)
            {
                if(c.Numero == numero) _comptes.Remove(c);
            }*/
            Courant c = this[numero];
            if (c != null) _comptes.Remove(c);
        }
    }
    #endregion

    #region Class Banque avec un Dictionary<string, Courant>

    //internal class Banque
    //{
    //    public string Nom { get; set; }

    //    private Dictionary<string, Courant> _comptes = new Dictionary<string, Courant>();

    //    public Courant this[string numero]
    //    {
    //        get
    //        {
    //            Courant c = null;
    //            _comptes.TryGetValue(numero, out c);
    //            return c;
    //        }
    //    }

    //    public void Ajouter(Courant compte) {
    //        if (_comptes.ContainsKey(compte.Numero)) return;
    //        _comptes.Add(compte.Numero, compte);
    //    }
    //    public void Supprimer(string numero) {
    //        _comptes.Remove(numero);
    //    }
    //}

    #endregion
}
