using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Kutuphane_Otomasyonu_Entities.Interfaces
{
    public interface IGenerıcRepository<TContext,TEntity>//Generic Repository Pattern
        where TContext : DbContext, new()//DbContext'ten türeyen bir context olmalı ve new'lenebilir
        where TEntity : class, new()//Entity class'ı olmalı ve new'lenebilir
    {
        List<TEntity> GetAll(TContext context,Expression<Func<TEntity, bool> >filter = null);//Tüm verileri getirme null ise filtre uygulama

        TEntity GetByFilter(TContext context, Expression<Func<TEntity, bool>> filter);//Filtreye göre tek bir veri getirme

        TEntity GetByID(TContext context, int? id);//ID'ye göre veri getirme

        void insertupdate(TContext context, TEntity entity);//Ekleme veya güncelleme işlemi
        void delete(TContext context, Expression<Func<TEntity,bool>>filter);//Silme işlemi    
        void save(TContext context);//Değişiklikleri kaydetme
    }
}
