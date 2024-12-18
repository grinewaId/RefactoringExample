﻿using System;
using LegacyApp;

public class UserValidator
{
    public bool Validate(User user)
    {
        if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName))
        {
            return false;
        }

        if (!user.EmailAddress.Contains("@") || !user.EmailAddress.Contains("."))
        {
            return false;
        }

        var now = DateTime.Now;
        int age = now.Year - user.DateOfBirth.Year;
        if (now.Month < user.DateOfBirth.Month || (now.Month == user.DateOfBirth.Month && now.Day < user.DateOfBirth.Day))
        {
            age--;
        }

        if (age < 21)
        {
            return false;
        }

        return true;
    }
}