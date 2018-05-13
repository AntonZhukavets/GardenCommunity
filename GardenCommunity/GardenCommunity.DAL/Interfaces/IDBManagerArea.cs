using System;
using System.Collections.Generic;
using GardenCommunity.DAL.Entities;


namespace GardenCommunity.DAL.Interfaces
{
    public interface IDBManagerArea
    {
        Area GetArea(int id);
        void AddArea(Area area);
        void UpdateArea(Area area);
        void RemoveArea(int id);
        IEnumerable<Area> GetAreas();
        IEnumerable<Area> GetAreasByMemberId(int memberId);       
    }
}
