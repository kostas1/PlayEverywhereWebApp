using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayEv.WebUI.Infrastructure.Abstract
{
    public interface ISecurePass
    {
        string encriptPassword(string realPass);
    }
}
