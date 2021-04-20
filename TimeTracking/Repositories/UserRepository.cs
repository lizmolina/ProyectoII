using Microsoft.EntityFrameworkCore;
using TimeTracking.Models;
using System.Collections.Generic;
using System.Linq;
using GraphQL.Types;

namespace TimeTracking.Repositories
{
    public class UserRepository
    {
        private readonly DatabaseContext _context;
        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }
/*/
        public IEnumerable<Project> Projects(long userId) {
            var results = from projects in _context.Projects select projects;
            results = results.Where(b => b.UserId == userId);
            return results;
        }
/*/

        public IEnumerable<User> All(){
            return _context.Users.ToList();
        }

        public IEnumerable<User> Filter(ResolveFieldContext<object> graphqlContext){
            var results = from users in _context.Users select users;
            if (graphqlContext.HasArgument("name")) {
                var name = graphqlContext.GetArgument<string>("name");
                results = results.Where(c => c.Name.Contains(name));
            }
            return results;
        }

        public User Find(long id) {
            return _context.Users.Find(id);
        }
        public long Login(string email, string password) {
            var u = _context.Users.Where(a=> a.Email == email && a.Password == password).FirstOrDefault();
            var id = u.Id;
            return id;
        }

        public User Create(User user){
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User Delete(long id){
            var user = _context.Users.Find(id);
            if (user == null) {
                return null;
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return user;
        }

        public User Update(long id, User user) {
            user.Id = id;
            var updated = (_context.Users.Update(user)).Entity;
            if (updated == null) {
                return null;
            }
            _context.SaveChanges();
            return user;
        }


    }
}