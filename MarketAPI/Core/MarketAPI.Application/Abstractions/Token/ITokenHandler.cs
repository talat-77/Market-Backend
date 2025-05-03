using MarketAPI.Application.DTO;
using MarketAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAPI.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        DTO.Token CreateAccessToken(int minute,User user);
    }
}
