using Claims_WPF.Models.Wrappers;
using Orders_WPF.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Orders_WPF.Models.Converters;

namespace Orders_WPF
{
    class Repository
    {
        public List<TypeOfTask> GetTypeOfTasks()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.TypeOfTasks.ToList();
            }
        }

        public List<ClaimWrapper> GetClaims(int typeOfTaskId)
        {
            using (var context = new ApplicationDbContext())
            {
                var claims = context
                    .Claims
                    .Include(x => x.TypeOfTask)
                    .ToList()
                    .AsQueryable();

                if (typeOfTaskId != 0)
                {
                    claims = claims.Where(x => x.TypeOfTaskId == typeOfTaskId);
                }

                return claims
                    .ToList()
                    .Select(x => x.ToWrapper())
                    .ToList();
            }
        }

        public void DeleteClaim(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var claimToDelete = context.Claims.Find(id);
                context.Claims.Remove(claimToDelete);
                context.SaveChanges();
            }


        }

        public void UpdateClaim(ClaimWrapper claimWrapper)
        {
            var claim = claimWrapper.ToDao();

            using (var context = new ApplicationDbContext())
            {
                UpdateClaimProperties(context, claim);

                context.SaveChanges();
            }
        }


        private void UpdateClaimProperties(ApplicationDbContext context, Claim claim)
        {
            var claimToUpdate = context.Claims.Find(claim.Id);
            claimToUpdate.ClaimNumber = claim.ClaimNumber;
            claimToUpdate.TaskNumber = claim.TaskNumber;
            claimToUpdate.TypeOfTaskId = claim.TypeOfTaskId;
            claimToUpdate.Comments = claim.Comments;
            claimToUpdate.DateToRegisterTheClaim = claim.DateToRegisterTheClaim;
        }
            

        public void AddClaim(ClaimWrapper claimWrapper)
        {
            var claim = claimWrapper.ToDao();

            using (var context = new ApplicationDbContext())

            {
                var dbClaim = context.Claims.Add(claim);
                context.SaveChanges();
            }

        }

    }
}
