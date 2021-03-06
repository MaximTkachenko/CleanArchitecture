﻿using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;

namespace CleanArchitecture.Core
{
    public static class DatabasePopulator
    {
        public static async Task<int> PopulateDatabaseAsync(IRepository todoRepository)
        {
            if ((await todoRepository.CountAsync(ToDoItemSpecs.All())) >= 5) return 0;

            todoRepository.Add(new ToDoItem
            {
                Title = "Get Sample Working",
                Description = "Try to get the sample to build."
            });
            todoRepository.Add(new ToDoItem
            {
                Title = "Review Solution",
                Description = "Review the different projects in the solution and how they relate to one another."
            });
            todoRepository.Add(new ToDoItem
            {
                Title = "Run and Review Tests",
                Description = "Make sure all the tests run and review what they are doing."
            });

            return await todoRepository.CountAsync(ToDoItemSpecs.All());
        }
    }
}
