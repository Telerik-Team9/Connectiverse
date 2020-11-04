using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Database;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Services.Services.Contracts;
using System.Linq;

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
        public CountryDTO Get(int id)
        {
            var country = this.context.Countries
                              .Include(c => c.Towns)
                              .FirstOrDefault(c => c.Id == id);

            var dto = this.mapper.Map<CountryDTO>(country);
            return dto;
        }
    }
}
