using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Database;
using SocialNetwork.Services.Constants;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Services
{
    public class TownService : ITownService
    {
        private readonly SocialNetworkDBContext context;
        private readonly IMapper mapper;

        public TownService(SocialNetworkDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<TownDTO>> GetAllAsync()
        {
            var towns = await this.context.Towns
                                 .Include(t => t.Country)
                                 .ToListAsync();

            if (!towns.Any())
            {
                throw new ArgumentException(ExceptionMessages.EntitesNotFound);
            }

            return towns.Select(this.mapper.Map<TownDTO>);
        }

        public async Task<TownDTO> GetByNameAsync(string name)
        {
            var town = await this.context.Towns
                                 .Include(t => t.Country)
                                 .FirstOrDefaultAsync(t => t.Name == name)
                                 ?? throw new ArgumentException(ExceptionMessages.EntityNotFound);

            return this.mapper.Map<TownDTO>(town);
        }
    }
}
