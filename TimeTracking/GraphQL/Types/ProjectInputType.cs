using GraphQL.Types;
using TimeTracking.Models;

namespace TimeTracking.GraphQL.Types
{
    public class ProjectInputType : InputObjectGraphType
    {
        public ProjectInputType()
        {
            Name = "ProjectInput";
            Field<NonNullGraphType<StringGraphType>>("title");
            Field<NonNullGraphType<StringGraphType>>("description");
            
        }
    }
}