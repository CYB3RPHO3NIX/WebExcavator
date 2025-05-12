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
    public class GetSettingsBySectionNameQueryHandler : IRequestHandler<GetSettingsBySectionNameQuery, IEnumerable<SettingDTO>>
    {
        private readonly IUnitOfWork<ExcavatorDatabaseContext> _context;
        private readonly IMapper _mapper;
        public GetSettingsBySectionNameQueryHandler(IUnitOfWork<ExcavatorDatabaseContext> context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<SettingDTO>> Handle(GetSettingsBySectionNameQuery request, CancellationToken cancellationToken)
        {
            string sectionName = request.SectionName;
            var settings = await _context.GetRepository<Setting, Guid>().Get(s => s.Section == sectionName);
            return _mapper.Map<IEnumerable<SettingDTO>>(settings);
        }
    }
}
