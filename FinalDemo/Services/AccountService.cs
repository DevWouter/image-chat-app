using FinalDemo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalDemo.Services
{
    public class AccountService
    {
        public Account Create(string username, string password)
        {
            var accounts = Store.ReadJsonFromFile<IEnumerable<Account>>(StorePaths.Accounts)
                .ToList();

            if(accounts.Any(x=> x.Name == username))
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
    }
}
