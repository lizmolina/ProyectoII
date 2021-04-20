using GraphQL.Types;
using TimeTracking.Models;
using TimeTracking.Repositories;

namespace TimeTracking.GraphQL.Types
{
    public class TeamType : ObjectGraphType<Team>
    {
        public TeamType(TeamRepository repository)
        {
            Name = "Team";
            Field(x => x.Id);
            Field(x => x.UserId);
            Field(x => x.ProjectId);
            
        }
    }
}