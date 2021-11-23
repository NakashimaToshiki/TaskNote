using Microsoft.EntityFrameworkCore;

namespace TaskNote.Entity.FrameworkCore.InMemory
{
    public interface IDbContextAddDammy
    {
        void AddDammy(ModelBuilder modelBuilder);
    }
}
