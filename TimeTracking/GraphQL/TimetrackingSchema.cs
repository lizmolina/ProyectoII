using GraphQL;
using GraphQL.Types;


namespace TimeTracking.GraphQL
{
    class TimetrackingSchema : Schema
    {
        public TimetrackingSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<TimetrackingQuery>();
            Mutation = resolver.Resolve<TimetrackingMutation>();
        }
    }
}