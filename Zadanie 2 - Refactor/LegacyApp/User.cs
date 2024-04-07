﻿using System;

namespace LegacyApp
{
    public class User
    {
        public object Client { get; internal set; }
        public DateTime DateOfBirth { get; internal set; }
        public string EmailAddress { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public bool HasCreditLimit { get; internal set; }
        public int CreditLimit { get; internal set; }
    }
    public static bool validate(string firstName, string lastName, string emailAddress)
    {
        return validateName(firstName, lastName) && validateEmail(emailAddress);

    }
    private static bool validateName(string firstName, string lastName)
    {
        return !(string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName));
       
    }
    private static bool validateEmail(string email)
    {
        return !(!email.Contains("@") && !email.Contains("."));
           
    }
}