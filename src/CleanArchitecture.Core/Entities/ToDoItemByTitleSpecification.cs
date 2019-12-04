using CleanArchitecture.Core.Interfaces;

namespace CleanArchitecture.Core.Entities
{
    public class ToDoItemByTitleSpecification : BaseSpecification<ToDoItem>
    {
        public ToDoItemByTitleSpecification(string title) : base(x => x.Title == title)
        { }
    }
}
