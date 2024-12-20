using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace NakayamaPJ.Model
{
    public class IUserAccountModel
    {
        public string? Username { get; set; }
        public string? DisplayName { get; set; }
        public byte[]? ProfilePicture { get; set; }
    }
}
