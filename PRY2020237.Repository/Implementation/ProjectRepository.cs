using System.Collections.Generic;
using System.Linq;
using PRY2020237.Repository.Context;
using Microsoft.EntityFrameworkCore;
using PRY2020237.Entity;
using PRY2020237.Repository;

namespace PRY2020237.RepositoRy.implementation
{
    public class ProjectRepository : IProjectRepository
    {
        private ApplicationDbContext context;
        public ProjectRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool Delete(int id)
        {
           var rpta=false;
            
           try
           {
             var aux=context.Project.Single(x=>x.Id==id);
             context.Project.Remove(aux);
             context.SaveChanges();   
           }
           catch (System.Exception)
           {
               
               throw;
           }
           return rpta;
        }

        public Project Get(int id)
        {
            var result = new Project();
            try
            {
                result = context.Project.Single(x => x.Id == id);
                
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public IEnumerable<Project> GetAll()
        {
            var result = new List<Project>();
            try
            {
                result = context.Project.Include(c => c.user).ToList();

                result.Select(p => new Project
                {
                    Id= p.Id,
                    userId =p.userId,
                    name=p.name,
                    description=p.description,
                    createDate=p.createDate,
                    modifyDate=p.modifyDate
                });
              
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public bool Save(Project entity)
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

        public bool Update(Project entity)
        {
            try
            {
                 var proyecto = context.Project.Single(
                     x => x.Id == entity.Id
                 );

                 proyecto.Id=entity.Id;
                 proyecto.name=entity.name;
                 proyecto.description=entity.description;
                 proyecto.createDate=entity.createDate;
                 proyecto.modifyDate=entity.modifyDate;
                 proyecto.userId=entity.userId;

                 context.Update(proyecto);
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