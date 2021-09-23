using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WS_VentaReal_NetCore5.Models.Request;
using WS_VentaReal_NetCore5.Models.Response;

namespace WS_VentaReal_NetCore5.Services
{
    public interface IUserService
    {
        UserResponse Auth(AuthRequest model);
    }
}
