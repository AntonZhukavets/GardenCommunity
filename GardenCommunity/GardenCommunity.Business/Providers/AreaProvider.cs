using GardenCommunity.Business.Interfaces;
using GardenCommunity.Common.Entities;
using GardenCommunity.Common.Mappers;
using GardenCommunity.DataAccess.Interfaces;
using System;
using System.Collections.Generic;

namespace GardenCommunity.Business.Providers
{
    public class AreaProvider : IAreaProvider
    {
        private readonly IDBManagerArea dBManagerArea;        
        public AreaProvider(IDBManagerArea dBManagerArea)
        {
            this.dBManagerArea = dBManagerArea;            
        }
        public int AddArea(Area area)
        {
            var Area = area ?? throw new ArgumentNullException("area");
            return dBManagerArea.AddArea(Mapper.FromBusinessToDataAccessMap(area));
        }

        public Area GetArea(int id)
        {
            var area = dBManagerArea.GetArea(id);
            return Mapper.FromDataAccessToBusinessMap(area);
        }

        public IEnumerable<Area> GetAreas()
        {
            var areas = new List<Area>();
            var dALAreas = dBManagerArea.GetAreas();
            foreach(var dalArea in dALAreas)
            {
                areas.Add(Mapper.FromDataAccessToBusinessMap(dalArea));
            }
            return areas; 
        }

        public IEnumerable<Area> GetAreasByMemberId(int id)
        {
            throw new NotImplementedException();
        }

        public int RemoveArea(int id)
        {
            return dBManagerArea.RemoveArea(id);
        }

        public int UpdateArea(Area area, int memberId)
        {
            var Area = area ?? throw new ArgumentNullException();
            return dBManagerArea.UpdateArea(Mapper.FromBusinessToDataAccessMap(area), memberId);
        }
    }
}
