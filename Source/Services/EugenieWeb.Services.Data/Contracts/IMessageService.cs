namespace EugenieWeb.Services.Data.Contracts
{
    using System.Linq;

    using EugenieWeb.Data.Models;

    public interface IMessageService
    {
        void Add(string email, string content);

        IQueryable<Message> Get();

        void Delete(int messageId);
    }
}
