using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw7.Services
{
    public interface IPasswordHashingService
    {
        public string HashPassword(string password, string salt);

        public bool Validate(string value, string salt, string hash);
        public string CreateSalt();
    }
}
