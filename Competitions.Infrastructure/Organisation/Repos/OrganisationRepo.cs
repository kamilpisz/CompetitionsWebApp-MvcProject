using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplikacjaASPNET.Models.OrganisationItems
{
    public class OrganisationRepo : ISQLOrganisationRepository
    {
        private readonly AppDbContext context;

        public OrganisationRepo(AppDbContext context)
        {
            this.context = context;
        }



        public Organisation Create(Organisation nowyOrganisation)
        {
            context.OrganisationDB.Add(nowyOrganisation);
            context.SaveChanges();
            return nowyOrganisation;

        }

        public Organisation Delete(int id)
        {
            Organisation Organisation = context.OrganisationDB.Find(id);
            if (Organisation != null)
            {
                context.OrganisationDB.Remove(Organisation);
                context.SaveChanges();

            }
            return Organisation;
        }

        public Organisation Edit(Organisation EditOrganisation)
        {
            var Organisation = context.OrganisationDB.Attach(EditOrganisation);
            Organisation.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return EditOrganisation;
        }

        public IEnumerable<Organisation> GetAllOrganisation()
        {
            return context.OrganisationDB;
        }

        public Organisation GetById(int id)
        {
            return context.OrganisationDB.Find(id);
        }

        public IQueryable<string> GetAllCategories()
        {
            var categories = context.OrganisationDB.Select(x => x.Category);
            return categories;
        }





    }
}