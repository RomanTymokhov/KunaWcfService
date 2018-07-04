using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CunaWrapper.DataLevel.ServiceData
{
    public class Credentials
    {
        private string publicKey;
        private string secretKey;

        public string PublicKey { get; private set; }
        public string SecretKey { get; private set; }

        public Credentials (string pub, string sec)
        {
            PublicKey = pub;
            SecretKey = sec;
        }
    }
}
