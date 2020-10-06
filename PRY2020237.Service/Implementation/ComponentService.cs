using System.Collections.Generic;
using PRY2020237.Entity;
using PRY2020237.Repository;

namespace PRY2020237.Service.implementation
{
    public class ComponentService : IComponentService
    {

        private IComponentRepository componentRepository;
        public ComponentService(IComponentRepository componentRepository)
        {
            this.componentRepository=componentRepository;
        }
        
        public bool Delete(int id)
        {
            return componentRepository.Delete(id);
        }

        public Component Get(int id)
        {
            return componentRepository.Get(id);
        }

        public IEnumerable<Component> GetAll()
        {
           return componentRepository.GetAll();
        }

        public bool Save(Component entity)
        {
            return componentRepository.Save(entity);
        }

        public bool Update(Component entity)
        {
            return componentRepository.Update(entity);
        }
    }
}