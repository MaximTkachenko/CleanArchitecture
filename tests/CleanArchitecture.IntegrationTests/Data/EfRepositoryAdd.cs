using CleanArchitecture.Core.Entities;
using CleanArchitecture.UnitTests;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.IntegrationTests.Data
{
    public class EfRepositoryAdd : BaseEfRepoTestFixture
    {
        [Fact]
        public async Task AddsItemAndSetsId()
        {
            var repository = GetRepository();
            var item = new ToDoItemBuilder().Build();

            repository.Add(item);
            _dbContext.SaveChanges();

            var newItem = await repository.FirstOrDefaultAsync(ToDoItemSpecs.All());

            Assert.Equal(item, newItem);
            Assert.True(newItem?.Id > 0);
        }
    }
}
