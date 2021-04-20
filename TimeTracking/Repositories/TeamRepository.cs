using Microsoft.EntityFrameworkCore;
using TimeTracking.Models;
using System.Collections.Generic;
using System.Linq;
using GraphQL.Types;

namespace TimeTracking.Repositories
{
    public class TeamRepository
    {
        private readonly DatabaseContext _context;
        public TeamRepository(DatabaseContext context)
        {
            _context = context;
        }
        

        public IEnumerable<Team> All(){
            return _context.Teams.ToList();
        }
        
        public Team Create(Team teams){
            _context.Teams.Add(teams);
            _context.SaveChanges();
            return teams;
        }

        public Team Delete(long id){
            var teams = _context.Teams.Find(id);
            if (teams == null) {
                return null;
            }
            _context.Teams.Remove(teams);
            _context.SaveChanges();
            return teams;
        }

        public Team Update(long id, Team teams) {
            teams.Id = id;
            var updated = (_context.Teams.Update(teams)).Entity;
            if (updated == null) {
                return null;
            }
            _context.SaveChanges();
            return teams;
        }
    }
}