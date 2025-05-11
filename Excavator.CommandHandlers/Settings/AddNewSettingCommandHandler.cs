using AutoMapper;
using Excavator.Commands.Settings;
using Excavator.Database.Data;
using Excavator.Database.DbContexts;
using Excavator.Database.Entities.Settings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Excavator.CommandHandlers.Settings
{
    public class AddNewSettingCommandHandler : IRequestHandler<AddNewSettingCommand, bool>
    {
        private readonly IUnitOfWork<ExcavatorDatabaseContext> _context;
        private readonly IMapper _mapper;
        public AddNewSettingCommandHandler(IUnitOfWork<ExcavatorDatabaseContext> context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> Handle(AddNewSettingCommand request, CancellationToken cancellationToken)
        {
            Setting setting = new Setting() 
            {
                Section = request.Section,
                Description = request.Description,
                IsEncrypted = request.IsEncrypted,
                Key = request.Key,
                Value = request.Value,
                UpdatedAt = DateTime.Now
            };
            try
            {
                await _context.GetRepository<Setting, Guid>().AddAsync(setting);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //Logger will come here.
                return false;
            }
            
        }
    }
}
