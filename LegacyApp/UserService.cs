using System;

namespace LegacyApp
{
    public class UserService
    {
        private readonly ClientRepository _clientRepository;
        private readonly IUserCreditService _userCreditService;
        private readonly UserValidator _userValidator;
        
        public UserService()
        {
            _clientRepository = new ClientRepository(); 
            _userCreditService = new UserCreditService(new UserCreditRepository()); 
            _userValidator = new UserValidator();
        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            var client = _clientRepository.GetById(clientId);

            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = email,
                DateOfBirth = dateOfBirth,
                Client = client
            };

            if (!_userValidator.Validate(user))
            {
                return false;
            }

            _userCreditService.SetCreditLimit(user, user.Client);
            
            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }
            
            UserDataAccess.AddUser(user);
            return true;
        }
    }
}