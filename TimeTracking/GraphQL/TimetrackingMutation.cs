using GraphQL;
using GraphQL.Types;
using System.Linq;
using TimeTracking.GraphQL.Types;
using TimeTracking.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TimeTracking.Repositories;

namespace TimeTracking.GraphQL
{
    class TimetrackingMutation : ObjectGraphType
    {
        public TimetrackingMutation(UserRepository userRepository,ProjectRepository projectRepository)
        {
            Field<UserType>("createUser",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<UserInputType>> { Name = "input" }),
                resolve: context => userRepository.Create(context.GetArgument<User>("input"))
            );

            Field<UserType>("deleteUser",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" }),
                resolve: context => userRepository.Delete(context.GetArgument<long>("id"))
            );

            Field<UserType>("updateUser",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" },
                                              new QueryArgument<NonNullGraphType<UserInputType>> { Name = "input" }),
                resolve: context => userRepository.Update(context.GetArgument<long>("id"), 
                                                             context.GetArgument<User>("input"))
            );
           
            projectMutation(projectRepository);
        }
        private void projectMutation(ProjectRepository projectRepository){
            Field<ProjectType>("createProject",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ProjectInputType>> { Name = "input" }),
                resolve: context => projectRepository.Create(context.GetArgument<Project>("input"))
            );
            Field<ProjectType>("deleteProject",
            arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" }),
            resolve: context => projectRepository.Delete(context.GetArgument<long>("id"))
            );
            Field<ProjectType>("updateProject",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" },
                                              new QueryArgument<NonNullGraphType<ProjectInputType>> { Name = "input" }),
                resolve: context => projectRepository.Update(context.GetArgument<long>("id"), 
                                                             context.GetArgument<Project>("input"))
            );
            

        }

    
    }
}