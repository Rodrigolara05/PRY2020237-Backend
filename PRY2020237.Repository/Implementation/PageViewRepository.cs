using System.Collections.Generic;
using System.Linq;
using PRY2020237.Repository.Context;
using Microsoft.EntityFrameworkCore;
using PRY2020237.Entity;
using PRY2020237.Repository;

namespace PRY2020237.RepositoRy.implementation
{
    public class PageViewRepository : IPageViewRepository
    {
        private ApplicationDbContext context;
        public PageViewRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool Delete(int id)
        {
            try
            {
                var pageview = context.PageView.Single(x => x.Id == id);
                context.Remove(pageview);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public PageView Get(int id)
        {
            var result = new PageView();
            try
            {
                result = context.PageView.Single(x => x.Id == id);
                
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public IEnumerable<PageView> GetAll()
        {
             var result = new List<PageView>();
            try
            {
                result = context.PageView.Include(c => c.project).ToList();

                result.Select(p => new PageView
                {
                    Id= p.Id,
                    projectId =p.projectId,
                    name=p.name,
                    description=p.description,
                    createDate=p.createDate,
                    modifyDate=p.modifyDate,
                    img=p.img,
                    refHtml=p.refHtml
                });
              
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public bool Save(PageView entity)
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

        public bool Update(PageView entity)
        {
            
            try
            {
                 var pageview = context.PageView.Single(
                     x => x.Id == entity.Id
                 );

                 pageview.Id=entity.Id;
                 pageview.name=entity.name;
                 pageview.description=entity.description;
                 pageview.createDate=entity.createDate;
                 pageview.modifyDate=entity.modifyDate;
                 pageview.img=entity.img;
                 pageview.refHtml=entity.refHtml;
                 pageview.projectId=entity.projectId;

                 context.Update(pageview);
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