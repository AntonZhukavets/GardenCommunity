using GardenCommunity.DataAccess.Entities;
using System.Collections.Generic;

namespace GardenCommunity.DataAccess.Interfaces
{
    public interface IDBManagerArea
    {
        Area GetArea(int id);
        int AddArea(Area area);
        int UpdateArea(Area area, int memberId);
        int RemoveArea(int id);
        IEnumerable<Area> GetAreas();
        IEnumerable<Area> GetAreasByMemberId(int memberId);
    }
}
