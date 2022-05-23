using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Plc.Shared.Entities.Abstract;

namespace Plc.Shared.Data.Abstract
{
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        T Get(Expression<Func<T,bool>>filter);

        List<T> GetAll(Expression<Func<T, bool>> filter = null);

        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        bool Any(Expression<Func<T, bool>> filter);//filtreye göre varmı sonucu döner
        int CountAsync(Expression<Func<T, bool>> filter);


    }
}
