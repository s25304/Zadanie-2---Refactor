using System;

namespace LegacyApp
{
    public class UserService
    {
        private ICreditService creditService;
        private IClientRepository clientRepo;

        public UserService(ICreditService creditService, IClientRepository clientRepo)
        {
            this.creditService = creditService;
            this.clientRepo = clientRepo;
        }
        public UserService()
        {
            this.creditService = new UserCreditService();
            this.clientRepo = ClientRepository();
        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if(!User.validate(firstName, lastName, email))
            {
                return false;
            }
            if (!validateAge(dateOfBirth))
            {
                return false;
            }
       
            var client = clientRepo.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            setCreditLimit(user, cleint);
            
            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }
        private bool validateAge(DateTime dateOfBirth)
        {
             var now = DateTime.Now;
             int age = now.Year - dateOfBirth.Year;
             if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

             return !(age < 21)
            
        }
        private void setCreditLimit(User user, Client client)
        {
            if (client.Type == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
            }
            else if (client.Type == "ImportantClient")
            {

                int creditLimit = creditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                creditLimit = creditLimit * 2;
                user.CreditLimit = creditLimit;
            }
            else
            {
                user.HasCreditLimit = true;
                
                int creditLimit = creditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                user.CreditLimit = creditLimit;
            }
        }
    }
}
