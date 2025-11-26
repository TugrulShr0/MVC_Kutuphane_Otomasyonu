using MVC_Kutuphane_Otomasyonu_Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Kutuphane_Otomasyonu_Entities.Repository
{
    public class GenericRepository<TContext, TEntity> : IGenerıcRepository<TContext, TEntity>
        where TContext : DbContext, new()
        where TEntity : class, new()
    {
        public void delete(TContext context, Expression<Func<TEntity, bool>> filter)
        {
            var model = context.Set<TEntity>().FirstOrDefault(filter);  
            context.Set<TEntity>().Remove(model);
        }

        public List<TEntity> GetAll(TContext context, Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null//Eğer filtre null ise tüm verileri döner
                ? context.Set<TEntity>().ToList()
                : context.Set<TEntity>().Where(filter).ToList();
        }

        public TEntity GetByFilter(TContext context, Expression<Func<TEntity, bool>> filter)
        {
            return context.Set<TEntity>().FirstOrDefault(filter);//Filtreye göre ilk veriyi döner
        }

        public TEntity GetByID(TContext context, int? id)
        {
            return context.Set<TEntity>().Find(id);//ID'ye göre veriyi döner
        }

        public void insertupdate(TContext context, TEntity entity)
        {
            context.Set<TEntity>().Add(entity);//Veriyi ekler
        }

        public void save(TContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    // Hangi entity hatalı
                    System.Diagnostics.Debug.WriteLine($"Entity: {eve.Entry.Entity.GetType().Name}");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        // Hangi property hatalı ve hata mesajı
                        System.Diagnostics.Debug.WriteLine($"Property: {ve.PropertyName}, Error: {ve.ErrorMessage}");
                    }
                }
                throw; // Hata tekrar fırlatılır
            }
        }

    }
}
