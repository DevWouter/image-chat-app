using FinalDemo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalDemo.Services
{
    public class SessionService
    {
        public Session Create(int userId)
        {
            var sessions = Store.ReadJsonFromFile<IEnumerable<Session>>(StorePaths.Sessions)
                .ToList();

            var nextId = sessions
                .Select(x => x.Id)
                .OrderByDescending(x => x)
                .FirstOrDefault() + 1;

            var newSession = new Session
            {
                Id = nextId,
                UserId = userId,
                SessionKey= Guid.NewGuid()
            };

            sessions.Add(newSession);

            Store.WriteJsonToFile(StorePaths.Sessions, sessions);

            return newSession;
        }

        public Session GetBySessionKey(Guid sessionKey)
        {
            return Store.ReadJsonFromFile<IEnumerable<Session>>(StorePaths.Sessions)
                .SingleOrDefault(x => x.SessionKey == sessionKey);
        }
    }
}
