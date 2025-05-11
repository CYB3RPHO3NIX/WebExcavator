using AutoMapper;
using Excavator.Database.Data;
using Excavator.Database.DbContexts;
using Excavator.Database.Entities.Settings;
using Excavator.Queries.Settings;
using Excavator.Shared.Models.DTOs.Settings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Excavator.QueryHandlers.Settings
{
    public class GetAllSettingsQueryHandler : IRequestHandler<GetAllSettingsQuery, IEnumerable<SettingDTO>>
    {
        private readonly IUnitOfWork<ExcavatorDatabaseContext> _context;
        private readonly IMapper _mapper;
        public GetAllSettingsQueryHandler(IUnitOfWork<ExcavatorDatabaseContext> context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<SettingDTO>> Handle(GetAllSettingsQuery request, CancellationToken cancellationToken)
        {
            var settings = await _context.GetRepository<Setting, Guid>().GetAllAsync();
            return _mapper.Map<IEnumerable<SettingDTO>>(settings);
        }
    }
}
