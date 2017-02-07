using App.WinForm.Attributes;
using App.WinForm.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    /// <summary>
    ///  L'inteface non générique de BaseRepository
    /// </summary>
    public interface IBaseRepository 
    {
        #region Variables
        /// <summary>
        /// Obtient l'objet Type de l'entity en gestion
        /// </summary>
        Type TypeEntity { set; get; }
        #endregion

        #region Evénements
        /// <summary>
        /// à exécuter aprés l'événement qui Indique que les valeurs de l'entity sont changé
        /// </summary>
        void ValueChanged(object sender, BaseEntity entity);
        #endregion

        #region Context
        /// <summary>
        /// Obtient le context 
        /// </summary>
        /// <returns></returns>
       // ModelContext Context();
        DbContext Context();

        void Dispose();
        #endregion

        #region CRUD

        /// <summary>
        /// Enregistrement d'une Entity en cas de Add ou Update
        /// </summary>
        /// <param name="entity">L'entity à enregistrer</param>
        /// <returns></returns>
        int Save(BaseEntity entity);

        /// <summary>
        /// Supprimer un entity
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Le nombre des entity supprimés</returns>
        int Delete(BaseEntity obj);


        #endregion

        #region Rechercher

        /// <summary>
        /// Rechercher 
        /// </summary>
        /// <param name="rechercheInfos"></param>
        /// <param name="startPage"></param>
        /// <param name="itemsPerPage"></param>
        /// <returns></returns>
        List<Object> Recherche(Dictionary<string, object> rechercheInfos, int startPage = 0, int itemsPerPage = 0);

        /// <summary>
        /// Reourne tous les objets avec l'état détaché
        /// </summary>
        /// <returns></returns>
        List<object> GetAllDetached();

        List<Object> GetAll();

        BaseEntity GetBaseEntityByID(Int64 id);

        #endregion

        #region Binding Source
        /// <summary>
        /// Binding une liste avec une source de données
        /// </summary>
        /// <returns></returns>
        Object ToBindingList();
        #endregion

        #region Create Instance
        /// <summary>
        /// Création d'une instance de l'objet T
        /// </summary>
        /// <returns></returns>
        object CreateInstanceObjet();

        /// <summary>
        /// Création d'une instance de de BaseRepositoty depuis le type de l'objet Entity
        /// </summary>
        /// <param name="TypeEntity">Le type de classe à utiliser dans BaseRepository</param>
        /// <returns></returns>
        IBaseRepository CreateInstance_Of_Service_From_TypeEntity(Type TypeEntity);
        IBaseRepository CreateInstance_Of_Service_From_TypeEntity(Type TypeEntity,DbContext context);
        #endregion

        #region Annotation
        ConfigEntity getAttributesOfEntity();
        #endregion

    }
}
