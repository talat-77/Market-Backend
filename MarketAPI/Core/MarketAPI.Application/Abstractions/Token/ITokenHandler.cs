using MarketAPI.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAPI.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        DTO.Token CreateAccessToken(int minute);
    }
}
