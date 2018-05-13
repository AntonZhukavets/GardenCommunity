using System;
using System.Collections.Generic;
using GardenCommunity.Business.DTO;
using GardenCommunity.Business.Interfaces;
using GardenCommunity.Business.Mappers;
using GardenCommunity.DAL.Interfaces;

namespace GardenCommunity.Business.Providers
{
    public class AreaProvider : IAreaProvider
    {
        private readonly IDBManagerArea dBManagerArea;
        public AreaProvider(IDBManagerArea dBManagerArea)
        {
            this.dBManagerArea = dBManagerArea;
        }

        public void AddArea(Area area)
        {
            if(area==null)
            {
                throw new ArgumentException("area");                
            }
            dBManagerArea.AddArea(Mapper.AreaFromDtoToDalMap(area));

        }

        public Area GetArea(int id)
        {
            return Mapper.AreaFromDalToDtoMap(dBManagerArea.GetArea(id));
        }

        public IEnumerable<Area> GetAreas()
        {            
            var dALAreas = dBManagerArea.GetAreas();
            if (dALAreas != null)
            {
                var dTOAreas = new List<Area>();
                foreach (var dALArea in dALAreas)
                {
                    dTOAreas.Add(Mapper.AreaFromDalToDtoMap(dALArea));
                }
                return dTOAreas;
            }
            return null;            
        }

        public IEnumerable<Area> GetAreasByMemberId(int id)
        {           
            var dALAreas = dBManagerArea.GetAreasByMemberId(id);
            if (dALAreas != null)
            {
                var dTOAreas = new List<Area>();
                foreach (var dALArea in dALAreas)
                {
                    dTOAreas.Add(Mapper.AreaFromDalToDtoMap(dALArea));
                }
                return dTOAreas;
            }
            return null;            
        }

        public void RemoveArea(int id)
        {
            dBManagerArea.RemoveArea(id);
        }

        public void UpdateArea(Area area)
        {
            if(area==null)
            {
                throw new ArgumentNullException("area");
            }
            dBManagerArea.UpdateArea(Mapper.AreaFromDtoToDalMap(area));
        }
    }
}
