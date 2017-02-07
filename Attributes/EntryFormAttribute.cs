using System;
using System.Windows.Forms;

namespace App.WinForm.Attributes
{
    public class EntryFormAttribute : Attribute
    {
        #region EntryForm
        /// <summary>
        /// Indique si la propriété fait partie de la formulaire
        /// </summary>
        public bool isFormulaire { get; set; }
        /// <summary>
        /// Affichage dans un groupe Box
        /// </summary>
        public string GroupeBox { get; set; }
        /// <summary>
        /// Unité : min,h,annee, g, Kg
        /// </summary>
        public string Unite { get; set; }
        /// <summary>
        /// Width dans le formulaire
        /// </summary>
        public int WidthControl { get; set; }
        /// <summary>
        /// Indique l'ordre d'affichage dans le formulaire et dans le dataGrid 
        /// </summary>
        public int Ordre { set; get; }
        /// <summary>
        /// Indique si l'information est MultiLine dans la formulaire de saisie
        /// </summary>
        public bool MultiLine { get; set; }
        /// <summary>
        /// En cas d'un champs multi-ligne, il détermine le nombre de ligne à utiliser
        /// </summary>
        public int NombreLigne { get; set; }
        /// <summary>
        /// Orientation d'affichage du champs 
        /// </summary>
        public Orientation OrientationField { get; set; }
        /// <summary>
        /// Indique si on va utiliser l'orientation de filed,
        /// Cette configuration exisite parceque le type "Orientation" n'est pas nullable
        /// </summary>
        public bool UseOrientationField { get; set; }
        /// <summary>
        /// Indique si la saisie de cette information est 
        /// </summary>
        public bool isOblegatoir { get; set; }
        /// <summary>
        /// si l'affichage est activté ou non
        /// La valeur par défaut est vrais
        /// </summary>
        public bool Enable { get; set; }
     
        /// <summary>
        /// Utilisation de filtre de selection pour le comboBox
        /// </summary>
        public bool FilterSelection { get; set; }

        /// <summary>
        /// Indique si l'affichage du champs ManyToMany se fait dans une TabPage
        /// </summary>
        public bool TabPage { get; set; }

        #endregion

        public EntryFormAttribute()
        {
            Enable = true;
            // Par défaut le nombre du ligne d'un champs MultiLigne = 1
            NombreLigne = 1;
        }
    }
}