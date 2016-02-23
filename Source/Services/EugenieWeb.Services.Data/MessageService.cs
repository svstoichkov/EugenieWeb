namespace EugenieWeb.Services.Data
{
    using System.Linq;

    using Eugenie.Data;

    using EugenieWeb.Data.Models;

    public class MessageService : IMessageService
    {
        private readonly IRepository<Message> messagesRepository;

        public MessageService(IRepository<Message> messagesRepository)
        {
            this.messagesRepository = messagesRepository;
        }

        public void Add(string email, string content)
        {
            var message = new Message();
            message.Email = email;
            message.Content = content;
            this.messagesRepository.Add(message);
            this.messagesRepository.SaveChanges();
        }

        public IQueryable<Message> Get()
        {
            return this.messagesRepository.All();
        }
    }
}
