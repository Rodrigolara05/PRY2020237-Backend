using System.Collections.Generic;
using System.Linq;
using PRY2020237.Repository.Context;
using PRY2020237.Entity;
using PRY2020237.Repository;

namespace PRY2020237.RepositoRy.implementation
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext context;
        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool Delete(int id)
        {
           try
            {
                var usuario = context.User.Single(x => x.Id == id);
                context.Remove(usuario);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public User Get(int id)
        {
            var result = new User();
            try
            {
                result = context.User.Single(x => x.Id == id);
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public IEnumerable<User> GetAll()
        {
            var result = new List<User>();
            try
            {
                result = context.User.ToList();
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public User Login(string email, string password)
        {
            var result = new User();
            try{
                result = context.User.Single(x=>x.email==email&&x.password==password);
            }
            catch{
                return null;
            }
            return result;
        }

        public bool Save(User entity)
        {
             try
            {
                context.Add(entity);
                context.SaveChanges();
            }
            catch (System.Exception)
            {

                return false;
            }
            return true;
        }

        public bool Update(User entity)
        {
             try
            {
                 var usuario = context.User.Single(
                     x => x.Id == entity.Id
                 );

                 usuario.Id=entity.Id;
                 usuario.firstName=entity.firstName;
                 usuario.lastName=entity.lastName;
                 usuario.email=entity.email;
                 usuario.password=entity.password;
                 usuario.token=entity.token;

                 context.Update(usuario);
                 context.SaveChanges();
            }
            catch (System.Exception)
            {
                
                return false;
            }
            return true;
        }

    }



}