using Microsoft.EntityFrameworkCore;
using TimeTracking.Models;
using System.Collections.Generic;
using System.Linq;
using GraphQL.Types;

namespace TimeTracking.Repositories
{
    public class ProjectRepository
    {
        private readonly DatabaseContext _context;
        public ProjectRepository(DatabaseContext context)
        {
            _context = context;
        }
        

        public User User(long userId) {
            return _context.Users.Find(userId);
        }

        public IEnumerable<Project> All(){
            return _context.Projects.ToList();
        }
        public IEnumerable<Project> Filter(ResolveFieldContext<object> graphqlContext){
            var results = from projects in _context.Projects select projects;

            return results;
        }
        public Project Create(Project project){
            _context.Projects.Add(project);
            _context.SaveChanges();
            return project;
        }

        public Project Delete(long id){
            var project = _context.Projects.Find(id);
            if (project == null) {
                return null;
            }
            _context.Projects.Remove(project);
            _context.SaveChanges();
            return project;
        }

        public Project Update(long id, Project project) {
            project.Id = id;
            var updated = (_context.Projects.Update(project)).Entity;
            if (updated == null) {
                return null;
            }
            _context.SaveChanges();
            return project;
        }
    }
}