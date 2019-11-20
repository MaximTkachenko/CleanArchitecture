using System.Threading.Tasks;
using CleanArchitecture.SharedKernel;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(BaseDomainEvent domainEvent);
    }
}