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
    class TimetrackingQuery : ObjectGraphType
    {
        public TimetrackingQuery(UserRepository userRepository, ProjectRepository projectRepository,TeamRepository teamRepository)
        {
            Field<ListGraphType<UserType>>("users",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "name" }
                ),
                resolve: context => userRepository.Filter(context)
            );
            
            Field<UserType>("User", 
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" }),
                resolve: context => userRepository.Find(context.GetArgument<long>("id"))
            );
            Field<IntGraphType>("login", 
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "email" },
                new QueryArgument<StringGraphType> { Name = "password" }),
                resolve: context => userRepository.Login(context.GetArgument<string>("email"),
                                                         context.GetArgument<string>("password")));

            Field<ListGraphType<ProjectType>>("projects", resolve: context => projectRepository.All());
            ProjectsQuery(projectRepository);
            TeamsQuery(teamRepository);
            UsersQuery(userRepository);
        }
        private void ProjectsQuery(ProjectRepository projectRepository){
            Field<ListGraphType<ProjectType>>("projectsAll",
                resolve: context => projectRepository.Filter(context)
            );
        }
        private void TeamsQuery(TeamRepository teamRepository){
            Field<ListGraphType<TeamType>>("teams", resolve: context => teamRepository.All());
        }
        private void UsersQuery(UserRepository userRepository){
            Field<ListGraphType<UserType>>("userAll", resolve: context => userRepository.All());
        }
    }
}