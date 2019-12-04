using CleanArchitecture.Core.Interfaces;

namespace CleanArchitecture.Core.Entities
{
    public class ToDoItemByIdSpecification : BaseSpecification<ToDoItem>
    {
        public ToDoItemByIdSpecification(int id) : base(x => x.Id == id)
        { }
    }
}
