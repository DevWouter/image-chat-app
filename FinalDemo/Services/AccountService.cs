using FinalDemo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalDemo.Services
{
    public class AccountService
    {
        private readonly SessionService _sessionService;
        
        public AccountService(SessionService sessionService)
        {
            _sessionService = sessionService;
        }

        public Account Create(string username, string password)
        {
            var accounts = Store.ReadJsonFromFile<IEnumerable<Account>>(StorePaths.Accounts)
                .ToList();

            if (accounts.Any(x => x.Name == username))
            {
                throw new Exception("Username is already in use");
            }

            var nextId = accounts
                .Select(x => x.Id)
                .OrderByDescending(x => x)
                .FirstOrDefault() + 1;

            var newAccount = new Account
            {
                Id = nextId,
                Name = username,
                Password = password
            };

            accounts.Add(newAccount);

            Store.WriteJsonToFile(StorePaths.Accounts, accounts);

            return newAccount;
        }

        public Account FindByUsernameAndPassword(string username, string password)
        {
            var accounts = Store.ReadJsonFromFile<IEnumerable<Account>>(StorePaths.Accounts);
            var account = accounts.SingleOrDefault(x => x.Name == username && x.Password == password);
            return account;
        }

        public Account FindBySessionKey(Guid sessionKey)
        {
            var session = _sessionService.GetBySessionKey(sessionKey);
            var accounts = Store.ReadJsonFromFile<IEnumerable<Account>>(StorePaths.Accounts);
            return accounts.SingleOrDefault(x => x.Id == session.UserId);
        }

        public Account FindById(int accountId)
        {
            System.Threading.Thread.Sleep(100);
            var accounts = Store.ReadJsonFromFile<IEnumerable<Account>>(StorePaths.Accounts);
            return accounts.SingleOrDefault(x => x.Id == accountId);
        }
    }
}
