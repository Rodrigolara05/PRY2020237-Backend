using System.Collections.Generic;
using PRY2020237.Entity;
using PRY2020237.Repository;

namespace PRY2020237.Service.implementation
{
    public class ProjectService : IProjectService
    {

        private IProjectRepository projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            this.projectRepository=projectRepository;
        }
        
        public bool Delete(int id)
        {
            return projectRepository.Delete(id);
        }

        public Project Get(int id)
        {
            return projectRepository.Get(id);
        }

        public IEnumerable<Project> GetAll()
        {
           return projectRepository.GetAll();
        }

        public bool Save(Project entity)
        {
            return projectRepository.Save(entity);
        }

        public bool Update(Project entity)
        {
            return projectRepository.Update(entity);
        }
    }
}