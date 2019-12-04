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

            var newItem = repository.FirstOrDefault(new ToDoItemAllSpecification());

            Assert.Equal(item, newItem);
            Assert.True(newItem?.Id > 0);
        }
    }
}
