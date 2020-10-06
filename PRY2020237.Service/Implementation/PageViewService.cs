using System.Collections.Generic;
using PRY2020237.Entity;
using PRY2020237.Repository;

namespace PRY2020237.Service.implementation
{
    public class PageViewService : IPageViewService
    {

        private IPageViewRepository pageViewRepository;
        public PageViewService(IPageViewRepository pageViewRepository)
        {
            this.pageViewRepository=pageViewRepository;
        }
        
        public bool Delete(int id)
        {
            return pageViewRepository.Delete(id);
        }

        public PageView Get(int id)
        {
            return pageViewRepository.Get(id);
        }

        public IEnumerable<PageView> GetAll()
        {
           return pageViewRepository.GetAll();
        }

        public bool Save(PageView entity)
        {
            return pageViewRepository.Save(entity);
        }

        public bool Update(PageView entity)
        {
            return pageViewRepository.Update(entity);
        }
    }
}