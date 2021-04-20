using GraphQL.Types;
using TimeTracking.Models;

namespace TimeTracking.GraphQL.Types
{
    public class UserInputType : InputObjectGraphType
    {
        public UserInputType()
        {
            Name = "UserInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("lastName");
            Field<NonNullGraphType<StringGraphType>>("phone");
            Field<NonNullGraphType<StringGraphType>>("email");
            Field<NonNullGraphType<StringGraphType>>("password");
        }
    }
}