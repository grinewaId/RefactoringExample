using System;

namespace LegacyApp;

public interface IUserCreditService
{
    int GetCreditLimit(string lastName, DateTime dateOfBirth);
    void SetCreditLimit(User user, Client client);

}