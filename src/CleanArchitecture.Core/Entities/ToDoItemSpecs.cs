using CleanArchitecture.Core.Interfaces;

namespace CleanArchitecture.Core.Entities
{
    public static class ToDoItemSpecs
    {
        public static ISpecification<ToDoItem> All() => new ToDoItemAllSpecification();

        public static ISpecification<ToDoItem> ById(int id) => new ToDoItemByIdSpecification(id);

        public static ISpecification<ToDoItem> ByTitle(string title) => new ToDoItemByTitleSpecification(title);
    }
}
