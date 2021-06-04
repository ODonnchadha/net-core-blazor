namespace BlazorServer.Repository
{
    using AutoMapper;
    using BlazorServer.Domain.DTOs;
    using BlazorServer.Domain.Interfaces.Repositories;
    using BlazorServer.Repository.Contexts;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Security.Principal;
    using System.Threading.Tasks;

    public class BlazorServerRepository : IBlazorServerRepository
    {
        private readonly BlazorServerDbContext context;
        private readonly IMapper mapper;
        public BlazorServerRepository(BlazorServerDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<HotelRoom> IsUnique(string name)
        {
            try
            {
                Domain.Entities.HotelRoom room = await context.HotelRooms.FirstOrDefaultAsync(r => r.Name == name);
                return mapper.Map<Domain.Entities.HotelRoom, HotelRoom>(room);
            }
            catch
            {
                return null;
            }
        }

        public async Task<HotelRoom> CreateHotelRoom(HotelRoom r)
        {
            var room = mapper.Map<HotelRoom, Domain.Entities.HotelRoom>(r);

            room.CreatedDate = DateTime.UtcNow;
#pragma warning disable CA1416 // Validate platform compatibility
            room.CreatedBy = WindowsIdentity.GetCurrent().Name;
#pragma warning restore CA1416 // Validate platform compatibility

            var added = await context.AddAsync(room);
            await context.SaveChangesAsync();

            return mapper.Map<Domain.Entities.HotelRoom, HotelRoom>(room);
        }

        public IEnumerable<HotelRoom> GetAllHotelRooms()
        {
            try
            {
                IEnumerable<HotelRoom> rooms = 
                    mapper.Map<IEnumerable<Domain.Entities.HotelRoom>, IEnumerable<HotelRoom>>(context.HotelRooms);

                return rooms;
            }
            catch
            {
                return null;
            }
        }

        public async Task<HotelRoom> GetHotelRoom(int id)
        {
            try
            {
                Domain.Entities.HotelRoom room = await context.HotelRooms.FirstOrDefaultAsync(r => r.Id == id);
                return mapper.Map<Domain.Entities.HotelRoom, HotelRoom>(room);
            }
            catch
            {
                return null;
            }
        }

        public async Task<HotelRoom> UpdateHotelRoom(int id, HotelRoom r)
        {
            try
            {
                if (id == r.Id)
                {
                    Domain.Entities.HotelRoom details = await context.HotelRooms.FindAsync(id);
                    // Glorified *patch* via the mapper. This needs to occur before any property updates for EF tracking.
                    var room = mapper.Map(r, details);

                    // We need to let EF know that there's a *new* entity to track.
                    room.UpdatedDate = DateTime.UtcNow;
#pragma warning disable CA1416 // Validate platform compatibility
                    room.UpdatedBy = WindowsIdentity.GetCurrent().Name;
#pragma warning restore CA1416 // Validate platform compatibility

                    var updated = context.Update(room);
                    await context.SaveChangesAsync();

                    return mapper.Map<Domain.Entities.HotelRoom, HotelRoom>(updated.Entity);
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<int> DeleteHotelRoom(int id)
        {
            var details = await context.HotelRooms.FindAsync(id);
            if (details != null)
            {
                context.HotelRooms.Remove(details);
                return await context.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
        }
    }
}
