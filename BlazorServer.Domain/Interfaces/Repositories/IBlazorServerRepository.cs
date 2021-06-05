namespace BlazorServer.Domain.Interfaces.Repositories
{
    using BlazorServer.Domain.DTOs;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IBlazorServerRepository
    {
        public Task<HotelRoom> CreateHotelRoom(HotelRoom r);
        public Task<int> DeleteHotelRoom(int id);
        public IEnumerable<HotelRoom> GetAllHotelRooms();
        public Task<HotelRoom> GetHotelRoom(int id);
        public Task<HotelRoom> IsUnique(string name);
        public Task<HotelRoom> UpdateHotelRoom(int id, HotelRoom r);
    }
}
