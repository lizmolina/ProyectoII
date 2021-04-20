using GraphQL.Types;
using TimeTracking.Models;
using TimeTracking.Repositories;

namespace TimeTracking.GraphQL.Types
{
    public class ProjectType : ObjectGraphType<Project>
    {
        public ProjectType(ProjectRepository repository)
        {
            Name = "Project";
            Field(x => x.Id);
            Field(x => x.Title);
            Field(x => x.Description);      
            
            
        }
    }
}

