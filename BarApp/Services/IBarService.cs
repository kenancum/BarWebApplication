using BarApp.Models;

namespace BarApp.Services
{
    public interface IBarService
    {
        public Task<List<Bar>> GetAsync();

        public Task<Bar?> GetAsync(string id);

        public Task CreateAsync(Bar newBar);

        public Task UpdateAsync(string id, Bar updatedBar);

        public Task RemoveAsync(string id);
    }
}
