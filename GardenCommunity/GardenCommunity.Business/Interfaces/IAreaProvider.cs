using System;
using System.Collections.Generic;
using GardenCommunity.Business.DTO;

namespace GardenCommunity.Business.Interfaces
{
    public interface IAreaProvider
    {
        void AddArea(Area area);
        void UpdateArea(Area area, int memberId);
        void RemoveArea(int id);
        IEnumerable<Area> GetAreas();
        Area GetArea(int id);
        IEnumerable<Area> GetAreasByMemberId(int id);
    }
}
