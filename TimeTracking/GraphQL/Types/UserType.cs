using GraphQL.Types;
using TimeTracking.Models;
using TimeTracking.Repositories;

namespace TimeTracking.GraphQL.Types
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType(UserRepository repository)
        {
            Name = "User";
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.LastName);
            Field(x => x.Phone);
            Field(x => x.Email);
            Field(x => x.Password);
            /*/
            Field<ListGraphType<ProjectType>>(
                "projects",
                resolve: context => {
                    return repository.Projects(context.Source.Id);
                }
            );/*/
        }
    }
}