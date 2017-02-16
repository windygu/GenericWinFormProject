using App.WinForm.Application.Presentation.Messages;
using App.WinForm.Attributes;
using App.WinForm.Entities;
using LinqExtension;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.WinForm.Application.BAL
{
    public class GenericWinAppBaseRepository<T>: IBaseRepository where T : BaseEntity
    {
        #region Variables
        protected Type typeEntity;
        /// <summary>
        /// Obtient l'objet Type de l'entity en gestion
        /// </summary>
        public Type TypeEntity
        {
            get
            {
                return typeEntity;
            }

            set
            {
                typeEntity = value;
            }
        }

        protected IDbSet<T> DbSet { get; set; }
        #endregion

        #region Evénements
        /// <summary>
        /// Indique que les valeurs de l'entity sont changé
        /// </summary>
        public virtual void ValueChanged(object sender, BaseEntity entity)
        {
            // Cette méthode est surcharger pour appliquer les règle de gestions 

        }
        #endregion

        #region Context

        public virtual DbContext context {
            get;
            set;
        }

        public virtual DbContext Context()
        {
            return this.context;
        }

        public virtual void Dispose()
        {
            if (this.context != null)
            {
                this.context.Dispose();
            }
        }
        #endregion

        #region construcreur
        public GenericWinAppBaseRepository(DbContext context)
        {
            this.context = context;
            if (this.context == null) this.context = new TestModelContext();

            this.DbSet = this.context.Set<T>();
            this.TypeEntity = typeof(T);
        }
        public GenericWinAppBaseRepository() : this(null) { }
        #endregion

        #region Traitement des excéption

        public void DbEntityValidationExceptionTreatment(DbEntityValidationException ex)
        {
            foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
            {
                // Get entry
                DbEntityEntry entry = item.Entry;

                BaseEntity entity = (BaseEntity)entry.Entity;
                string entityTypeName = entity.ToString();

                // Display or log error messages
                foreach (DbValidationError subItem in item.ValidationErrors)
                {
                    string message = string.Format("Erreur : '{0}' \n trouvé dans l'objet : {1}  \n sur la propriété {2}",
                             subItem.ErrorMessage, entityTypeName, subItem.PropertyName);
                    MessageToUser.AddMessage(MessageToUser.Category.EntityValidation, message);
                }
            }
        }
        public void SQLExceptionTreatment(SqlException sqlException)
        {
            if (sqlException != null)
            {
                if (sqlException.Errors.Count > 0)
                {
                    switch (sqlException.Errors[0].Number)
                    {
                        case 547: // Foreign Key violation
                            MessageToUser.AddMessage(MessageToUser.Category.ForeignKeViolation, "");
                            break;
                        default:
                            throw (sqlException);

                    }
                }
            }
            else
            {
                throw (sqlException);
            }
        }

        public virtual void DbUpdateExceptionTreatment(DbUpdateException e)
        {
            var sqlException = e.GetBaseException() as SqlException;
            if (sqlException != null)
            {
                if (sqlException.Errors.Count > 0)
                {
                    switch (sqlException.Errors[0].Number)
                    {
                        case 547: // Foreign Key violation
                            MessageToUser.AddMessage(MessageToUser.Category.ForeignKeViolation, "");
                            break;
                        default:
                            throw (sqlException);

                    }
                }
            }
            else
            {
                throw (sqlException);
            }
        }
        #endregion

        #region Save
        public virtual int Save(BaseEntity item)
        {
            return this.Save((T)item);
        }
        public virtual int Save(T item)
        {
            // Calcule de l'ordre 
            CalculateOrder(item);

            // Enregistrement
            try
            {
                if (item.Id <= 0) return Insert(item);
                else return Update(item);
            }
            catch (SqlException e)
            {
                this.SQLExceptionTreatment(e);
                return 0;
            }
            catch (DbEntityValidationException e)
            {
                DbEntityValidationExceptionTreatment(e);
                return 0;
            }

        }
        protected virtual int Insert(T item)
        {
            // Règle de gestion : La date de création égale la date de système lors de l'enregistrement
            item.DateCreation = DateTime.Now;
            this.DbSet.Add(item);
            string  state = this.context.Entry(item).State.ToString();
            return this.context.SaveChanges();
        }

        protected virtual int Update(T item)
        {
            this.context.Entry(item).State = EntityState.Modified;

            // Règle de gestion : Modification de la date de modification avec la date Actuel
            item.DateModification = DateTime.Now;

            return this.context.SaveChanges();
        }
        protected virtual void CalculateOrder(BaseEntity entity)
        {
            if (entity.Ordre == 0)
            {
                int ordre = this.DbSet.Count();
                entity.Ordre = ++ordre;
            }
        }
        #endregion

        #region Delete
        public virtual int Delete(BaseEntity obj)
        {
            return this.Delete(obj.Id);
        }

        public virtual int Delete(Int64 Id)
        {
            var original = DbSet.Find(Id);
            DbSet.Remove(original);
            try
            {
                return context.SaveChanges();

            }

            catch (DbUpdateException e)
            {
                DbUpdateExceptionTreatment(e);
                return 0;
            }

        }










        public virtual int Count(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = DbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.Count();
        }
        #endregion

        #region Recherche
        /// <summary>
        /// Recherche, il est n'est pas déclarer dans l'interface IBaseRepositoty
        /// </summary>
        /// <param name="startPage"></param>
        /// <param name="itemsPerPage"></param>
        /// <param name="filter"></param>
        /// <param name="order"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public virtual List<T> GetAll(int startPage = 0, int itemsPerPage = 0, Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> order = null, string includeProperties = "")
        {
            IQueryable<T> query = DbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(
                new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (order != null && (startPage != 0 && itemsPerPage != 0))
            {
                query = order(query).Skip((startPage - 1) * itemsPerPage).Take(itemsPerPage);
            }

            if (order == null && (startPage != 0 && itemsPerPage != 0))
            {
                query = query.OrderByDescending(x => x.Id).Skip((startPage - 1) * itemsPerPage).Take(itemsPerPage);
            }

            return query.ToList<T>();
        }


        public virtual List<object> Recherche(Dictionary<string, object> rechercheInfos, int startPage = 0, int itemsPerPage = 0)
        {
            IQueryable<T> query = DbSet;

            //ParameterExpression entity = Expression.Parameter(typeof(T), "entity");
            if (rechercheInfos != null)
            {
                foreach (var item in rechercheInfos)
                {

                    //MemberExpression entity_string = Expression.PropertyOrField(entity, item.Key.Name);
                    //string valeur_string = (string)item.Value;
                    //valeur_string = "%" + valeur_string + "%";
                    //ConstantExpression valeur = Expression.Constant(item.Value, typeof(String));

                    //BinaryExpression EqualValeur = Expression.Equal(entity_string, valeur);
                    //var lambda = Expression.Lambda<Func<T, bool>>(EqualValeur, new ParameterExpression[] { entity });

                    var lambda = Extensions.BuildPredicate<T>(item.Key, item.Value);
                    if (lambda != null)
                        query = query.Where(lambda);
                }
            }


            List<object> ls = query.ToList<object>();
            return ls;
        }

        public List<object> GetAll()
        {
            List<T> ls = this.GetAll(0, 0).ToList<T>();
            return ls.ToList<Object>();
        }
        public List<Object> GetAllDetached()
        {

            List<Object> ls = this.DbSet.ToList<Object>();
            foreach (var item in ls)
            {
                this.context.Entry(item).State = EntityState.Detached;
            }
            return ls;

        }

        public virtual T GetByID(Int64 id)
        {
            return DbSet.Find(id);
        }
        public virtual BaseEntity GetBaseEntityByID(Int64 id)
        {
            return DbSet.Find(id);
        }


        #endregion

        #region Binding Source
        public object ToBindingList()
        {
            DbSet.Load();
            return DbSet.Local.ToBindingList();

        }
        #endregion





        #region CreateInstance

        public virtual object CreateInstanceObjet()
        {
            return this.context.Set<T>().Create();
        }

        /// <summary>
        /// Creating an instance of the Service object from the entity type
        /// </summary>
        /// <param name="TypeEntity">the entity type</param>
        /// <returns></returns>
        public virtual IBaseRepository CreateInstance_Of_Service_From_TypeEntity(Type TypeEntity)
        {

            Type TypeEntityService = typeof(GenericWinAppBaseRepository<>).MakeGenericType(TypeEntity);
            IBaseRepository EntityService = (IBaseRepository)Activator.CreateInstance(TypeEntityService, this.context);
            return EntityService;
        }
        /// <summary>
        /// Creating an instance of the Service object from the entity type and Context
        /// </summary>
        /// <param name="TypeEntity">the entity type</param>
        /// <param name="context">the context</param>
        /// <returns></returns>
        public virtual IBaseRepository CreateInstance_Of_Service_From_TypeEntity(Type TypeEntity, DbContext context)
        {

            Type TypeEntityService = typeof(GenericWinAppBaseRepository<>).MakeGenericType(TypeEntity);
            IBaseRepository EntityService = (IBaseRepository)Activator.CreateInstance(TypeEntityService, context);
            return EntityService;
        }
        #endregion


        #region Annotations
        /// <summary>
        /// Obtien l'annotion 'AffichageDansFormGestion' de la classe Entity
        /// pour le paramétrage des titre de l'interface de gestion
        /// </summary>
        /// <returns></returns>
        public virtual ConfigEntity getAttributesOfEntity()
        {
            return new ConfigEntity(this.TypeEntity);
        }

        #endregion
    }
}
