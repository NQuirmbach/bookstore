using BookStore.BookService.Database;
using BookStore.BookService.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.BookService.Graph.Authors;

public class AuthorDataLoader : BatchDataLoader<Guid, Author>
{
    private readonly AppDbContext _context;

    public AuthorDataLoader(
        AppDbContext context,
        IBatchScheduler batchScheduler,
        DataLoaderOptions? options = null
    ) : base(batchScheduler, options)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    protected override async Task<IReadOnlyDictionary<Guid, Author>> LoadBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
    {
        var data = await _context.Authors
            .Where(m => keys.Contains(m.Id))
            .ToListAsync(cancellationToken);

        return data.ToDictionary(m => m.Id, m => m);
    }
}