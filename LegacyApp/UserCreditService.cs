using System;
using System.Threading.Tasks;

namespace LegacyApp
{
    public class UserCreditService : IUserCreditService, IDisposable
    {
        private readonly IUserCreditRepository _repository;

        public UserCreditService(IUserCreditRepository repository)
        {
            _repository = repository;
        }

        public void Dispose()
        {
        }

        public int GetCreditLimit(string lastName, DateTime dateOfBirth)
        {
            Task.Delay(new Random().Next(100, 500)).Wait();
            return _repository.GetCreditLimit(lastName);
        }

        public void SetCreditLimit(User user, Client client)
        {
            if (client.Type == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
                user.CreditLimit = 0;
            }
            else if (client.Type == "ImportantClient")
            {
                user.HasCreditLimit = true;
                int creditLimit = GetCreditLimit(user.LastName, user.DateOfBirth);
                user.CreditLimit = creditLimit * 2;
            }
            else
            {
                user.HasCreditLimit = true;
                int creditLimit = GetCreditLimit(user.LastName, user.DateOfBirth);
                user.CreditLimit = creditLimit;
            }
        }
    }
}