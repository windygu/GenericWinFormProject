
using App.WinForm.Entities;

namespace App.WinForm
{
    public interface IBaseEntryForm
    {
        /// <summary>
        /// Afficher l'objet dans le formulaire
        /// </summary>
        void WriteEntityToField();

        /// <summary>
        /// Lire l'objet à partire du formulaire
        /// </summary>
        void Lire();

        /// <summary>
        /// Création d'une instance du form en cours
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        BaseEntryForm CreateInstance(IBaseRepository service);

        /// <summary>
        /// Créer d'une instance de l'objet en cours
        /// </summary>
        /// <returns></returns>
        BaseEntity CreateObjetInstance();
    }
}