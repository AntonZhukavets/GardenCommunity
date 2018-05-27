using GardenCommunity.Common.Entities;
using System.Collections.Generic;

namespace GardenCommunity.Business.Interfaces
{
    public interface IAreaProvider
    {
        int AddArea(Area area);
        int UpdateArea(Area area, int memberId);
        int RemoveArea(int id);
        IEnumerable<Area> GetAreas();
        Area GetArea(int id);
        IEnumerable<Area> GetAreasByMemberId(int id);
    }
}
