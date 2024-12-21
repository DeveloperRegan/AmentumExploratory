using AmentumExploratory.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AmentumExploratory.Data;

public class DataAccessService(IDbContextFactory<ExploratoryDbContext> dbContextFactory)
{
    public async Task<List<Contact>> GetContacts()
    {
        using var dbContext = await dbContextFactory.CreateDbContextAsync();
        return await dbContext.Contacts.ToListAsync();
    }

    public async Task<Result> AddContact(Contact contact, CancellationToken cancellationToken=default)
    {
        using var dbContext = await dbContextFactory.CreateDbContextAsync();
        await dbContext.AddAsync(contact, cancellationToken);
        int changeCount = await dbContext.SaveChangesAsync(cancellationToken);

        if (changeCount > 0)
        {
            return Result.Success();
        }

        return Result.Failure(Error.DatabaseError);
    }
}
