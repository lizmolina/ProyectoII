using GraphQL.Types;
using TimeTracking.Models;

namespace TimeTracking.GraphQL.Types
{
    public class TeamInputType : InputObjectGraphType
    {
        public TeamInputType()
        {
            Name = "TeamInput";
            Field<NonNullGraphType<IntGraphType>>("userId");
            Field<NonNullGraphType<IntGraphType>>("projectId");
        }
    }
}