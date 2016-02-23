namespace EugenieWeb.Services.Data
{
    using System.Linq;

    using EugenieWeb.Data.Models;

    public interface IMessageService
    {
        void Add(string email, string content);

        IQueryable<Message> Get();
    }
}
