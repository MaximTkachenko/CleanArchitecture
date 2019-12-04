using CleanArchitecture.Core.Entities;
using CleanArchitecture.UnitTests;
using System.Linq;
using Xunit;

namespace CleanArchitecture.IntegrationTests.Data
{
    public class EfRepositoryAdd : BaseEfRepoTestFixture
    {
        [Fact]
        public void AddsItemAndSetsId()
        {
            var repository = GetRepository();
            var item = new ToDoItemBuilder().Build();

            repository.Add(item);
            _dbContext.SaveChanges();

            var newItem = repository.FirstOrDefault(ToDoItemSpecs.All());

            Assert.Equal(item, newItem);
            Assert.True(newItem?.Id > 0);
        }
    }
}
