using System.Collections.Generic;
using System.Linq;
using PRY2020237.Repository.Context;
using Microsoft.EntityFrameworkCore;
using PRY2020237.Entity;
using PRY2020237.Repository;

namespace PRY2020237.RepositoRy.implementation
{
    public class ComponentTypeRepository : IComponentTypeRepository
    {
        private ApplicationDbContext context;
        public ComponentTypeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool Delete(int id)
        {
            try
            {
                var componentetipo = context.ComponentType.Single(x => x.Id == id);
                context.Remove(componentetipo);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public ComponentType Get(int id)
        {
             var result = new ComponentType();
            try
            {
                result = context.ComponentType.Single(x => x.Id == id);
                
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public IEnumerable<ComponentType> GetAll()
        {
           var result = new List<ComponentType>();
            try
            {
                result = context.ComponentType.ToList();
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public bool Save(ComponentType entity)
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

        public bool Update(ComponentType entity)
        {
            try
            {
                 var tipocomponente = context.ComponentType.Single(
                     x => x.Id == entity.Id
                 );
                 tipocomponente.Id=entity.Id;
                 tipocomponente.name=entity.name;
                 tipocomponente.description=entity.description;
                 context.Update(tipocomponente);
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