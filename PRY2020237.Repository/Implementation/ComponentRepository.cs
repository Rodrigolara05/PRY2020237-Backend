using System.Collections.Generic;
using System.Linq;
using PRY2020237.Repository.Context;
using Microsoft.EntityFrameworkCore;
using PRY2020237.Entity;
using PRY2020237.Repository;

namespace PRY2020237.RepositoRy.implementation
{
    public class ComponentRepository : IComponentRepository
    {
        private ApplicationDbContext context;
        public ComponentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool Delete(int id)
        {
            try
            {
                var componente = context.Component.Single(x => x.Id == id);
                context.Remove(componente);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public Component Get(int id)
        {
           var result = new Component();
            try
            {
                result = context.Component.Single(x => x.Id == id);
                
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public IEnumerable<Component> GetAll()
        {
             var result = new List<Component>();
            try
            {
                result = context.Component.Include(c => c.pageView).ToList();

                result.Select(p => new Component
                {
                    Id= p.Id,
                    pageViewId =p.pageViewId,
                    componentTypeId=p.componentTypeId,
                    src =p.src,
                    text=p.text,
                    height =p.height,
                    width=p.width
                    
                });
              
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public bool Save(Component entity)
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

        public bool Update(Component entity)
        {
            try
            {
                 var componente = context.Component.Single(
                     x => x.Id == entity.Id
                 );

                 componente.Id=entity.Id;
                 componente.src=entity.src;
                 componente.text=entity.text;
                 componente.height=entity.height;
                 componente.width=entity.width;
                 componente.pageViewId=entity.pageViewId;
                 componente.componentTypeId=entity.componentTypeId;

                 context.Update(componente);
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