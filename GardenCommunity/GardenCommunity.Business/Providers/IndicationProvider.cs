using GardenCommunity.Business.Interfaces;
using GardenCommunity.Common.Entities;
using GardenCommunity.Common.Mappers;
using GardenCommunity.DataAccess.Interfaces;
using System;
using System.Collections.Generic;

namespace GardenCommunity.Business.Providers
{
    public class IndicationProvider : IIndicationProvider
    {
        private readonly IDBManagerIndication dBManagerIndication;

        public IndicationProvider(IDBManagerIndication dBManagerIndication)
        {
            this.dBManagerIndication = dBManagerIndication;
        }

        public int AddIndication(Indication indication)
        {
            var Indication = indication ?? throw new ArgumentNullException("indication");
            return dBManagerIndication.AddIndication(Mapper.FromBusinessToDataAccessMap(indication));
        }

        public Indication GetIndication(int id)
        {
            var indication = dBManagerIndication.GetIndication(id);
            return Mapper.FromDataAccessToBusinessMap(indication);
        }

        public IEnumerable<Indication> GetIndications()
        {
            var indications = new List<Indication>();
            var dALIndications = dBManagerIndication.GetIndications();
            foreach(var dALIndication in dALIndications)
            {
                indications.Add(Mapper.FromDataAccessToBusinessMap(dALIndication));
            }
            return indications;
        }

        public IEnumerable<Indication> GetIndicationsByMemberId(int id)
        {
            var indications = new List<Indication>();
            var dALIndications = dBManagerIndication.GetIndicationsByMemberId(id);
            foreach (var dALIndication in dALIndications)
            {
                indications.Add(Mapper.FromDataAccessToBusinessMap(dALIndication));
            }
            return indications;
        }

        public int RemoveIndication(int id)
        {
            return dBManagerIndication.RemoveIndication(id);
        }

        public int UpdateIndication(Indication indication)
        {
            var Indication = indication ?? throw new ArgumentNullException("indication");
            return dBManagerIndication.UpdateIndication(Mapper.FromBusinessToDataAccessMap(indication));
        }
    }
}
