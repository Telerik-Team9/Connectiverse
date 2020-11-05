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
    public class CountryService : ICountryService
    {
        private readonly SocialNetworkDBContext context;
        private readonly IMapper mapper;

        public CountryService(SocialNetworkDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<CountryDTO> GetByNameAsync(string name)
        {
            var country = await this.context.Countries
                             .Include(c => c.Towns)
                             .FirstOrDefaultAsync(c => c.Name == name)
                        ?? throw new ArgumentException(ExceptionMessages.EntityNotFound);

            return this.mapper.Map<CountryDTO>(country);
        }

        public async Task<IEnumerable<CountryDTO>> GetAllAsync()
        {
            var countres = await this.context.Countries
                             .Include(c => c.Towns)
                             .ToListAsync();

            if (!countres.Any())
            {
                throw new ArgumentException(ExceptionMessages.EntitesNotFound);
            }

            return countres.Select(this.mapper.Map<CountryDTO>);
        }
    }
}