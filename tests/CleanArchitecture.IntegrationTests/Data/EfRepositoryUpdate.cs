﻿using CleanArchitecture.Core.Entities;
using CleanArchitecture.UnitTests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.IntegrationTests.Data
{
    public class EfRepositoryUpdate : BaseEfRepoTestFixture
    {
        [Fact]
        public async Task UpdatesItemAfterAddingIt()
        {
            // add an item
            var repository = GetRepository();
            var initialTitle = Guid.NewGuid().ToString();
            var item = new ToDoItemBuilder().Title(initialTitle).Build();

            repository.Add(item);
            _dbContext.SaveChanges();

            // detach the item so we get a different instance
            _dbContext.Entry(item).State = EntityState.Detached;

            // fetch the item and update its title
            var newItem = await repository.FirstOrDefaultAsync(ToDoItemSpecs.ByTitle(initialTitle));
            Assert.NotNull(newItem);
            Assert.NotSame(item, newItem);
            var newTitle = Guid.NewGuid().ToString();
            newItem.Title = newTitle;

            // Update the item
            repository.Update(newItem);
            var updatedItem = await repository.FirstOrDefaultAsync(ToDoItemSpecs.ByTitle(initialTitle));

            Assert.NotNull(updatedItem);
            Assert.NotEqual(item.Title, updatedItem.Title);
            Assert.Equal(newItem.Id, updatedItem.Id);
        }
    }
}
