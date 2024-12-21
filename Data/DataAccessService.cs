using AmentumExploratory.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AmentumExploratory.Data
{
    public class DataAccessService(IDbContextFactory<ExploratoryDbContext> dbContextFactory)
    {
        public async Task<List<Contact>> GetContacts()
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();
            return await dbContext.Contacts.ToListAsync();
        }

        public async Task AddContact(Contact contact)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();
            await dbContext.AddAsync(contact);
            await dbContext.SaveChangesAsync();
        }
    }
}
