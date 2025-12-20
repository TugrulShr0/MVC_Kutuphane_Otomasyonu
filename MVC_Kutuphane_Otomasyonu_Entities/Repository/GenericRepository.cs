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

        public List<TEntity> GetAll(TContext context, Expression<Func<TEntity, bool>> filter = null,params string[] tbl)
        {
            IQueryable<TEntity> query = context.Set<TEntity>();

            // 1. Önce ilişkili tabloları (Join/Include) ekliyoruz
            if (tbl != null)
            {
                foreach (var item in tbl)
                {
                    query = query.Include(item);
                }
            }

            // 2. Eğer filtre gönderilmişse (null değilse) sorguya ekliyoruz
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.ToList();

            //null hatası vardı
            //IQueryable <TEntity> query = context.Set<TEntity>();
            //foreach (var item in tbl) 
            //{
            //    query = query.Where(filter).Include(item);

            //}
            //return query.ToList();
            //return filter == null ? tbl==null ?  context.Set<TEntity>().ToList(): context.Set<TEntity>().Include(tbl).ToList()
            //    : tbl==null ? context.Set<TEntity>().Where(filter).ToList() : context.Set<TEntity>().Include(tbl).Where(filter).ToList();
        }

        public TEntity GetByFilter(TContext context, Expression<Func<TEntity, bool>> filter, params string[] tbl)
        {

            IQueryable<TEntity> query = context.Set<TEntity>();

            // İlişkili tabloları ekle
            if (tbl != null)
            {
                foreach (var item in tbl)
                {
                    query = query.Include(item);
                }
            }

            // Filtreye uyan ilk kaydı getir
            return query.FirstOrDefault(filter);

            //null hatası
            //IQueryable<TEntity> query = context.Set<TEntity>();
            //foreach (var item in tbl)
            //{
            //    query = query.Include(item);

            //}
            //return query.FirstOrDefault(filter);
            //return tbl ==null ? context.Set<TEntity>().FirstOrDefault(filter) : context.Set<TEntity>().Include(tbl).FirstOrDefault(filter);//Filtreye göre ilk veriyi döner
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
