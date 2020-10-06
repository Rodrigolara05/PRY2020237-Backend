using System.Collections.Generic;
using PRY2020237.Entity;
using PRY2020237.Repository;

namespace PRY2020237.Service.implementation
{
    public class ComponentTypeService : IComponentTypeService
    {

        private IComponentTypeRepository componentTypeRepository;
        public ComponentTypeService(IComponentTypeRepository componentTypeRepository)
        {
            this.componentTypeRepository=componentTypeRepository;
        }
        
        public bool Delete(int id)
        {
            return componentTypeRepository.Delete(id);
        }

        public ComponentType Get(int id)
        {
            return componentTypeRepository.Get(id);
        }

        public IEnumerable<ComponentType> GetAll()
        {
           return componentTypeRepository.GetAll();
        }

        public bool Save(ComponentType entity)
        {
            return componentTypeRepository.Save(entity);
        }

        public bool Update(ComponentType entity)
        {
            return componentTypeRepository.Update(entity);
        }
    }
}