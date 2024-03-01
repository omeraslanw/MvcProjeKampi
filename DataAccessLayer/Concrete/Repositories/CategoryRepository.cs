using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class CategoryRepository : ICategoryDal
    {
        Context context = new Context();
        DbSet<Category> _object;
        /*
         * Entity Framework CRUD methods:
         * ToList();
         * Add();
         * Remove();
         * Find();
         */
        public void Delete(Category category)
        {
            _object.Remove(category);
            context.SaveChanges();
            //throw new NotImplementedException();
        }

        public void Insert(Category category)
        {
            _object.Add(category);
            context.SaveChanges();
            //throw new NotImplementedException();
        }

        public List<Category> List()
        {
            return _object.ToList();
            //throw new NotImplementedException();
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Category category)
        {
            context.SaveChanges();
            //throw new NotImplementedException();
        }
    }
}
//Her sınıf için bir interface oluşturup tekrar başka bir sınıfa
//metodların görevlerini kodlamak kurumsal mimariye uygun değildir.
//Çok fazla kod tekrarı olur ve programı yorar.
//Bu yanlış bir örnektir ama burda kalmasında fayda var.
