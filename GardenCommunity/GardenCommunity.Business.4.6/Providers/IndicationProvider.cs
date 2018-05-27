using System;
using System.Collections.Generic;
using GardenCommunity.Business.DTO;
using GardenCommunity.Business.Interfaces;
using GardenCommunity.Business.Mappers;
using GardenCommunity.DAL.Interfaces;

namespace GardenCommunity.Business.Providers
{
    public class IndicationProvider : IIndicationProvider
    {
        private readonly IDBManagerIndication dBManagerIndication;
        public IndicationProvider(IDBManagerIndication dBManagerIndication)
        {
            this.dBManagerIndication = dBManagerIndication;
        }

        public void AddIndication(Indication indication)
        {
            if(indication == null)
            {
                throw new ArgumentNullException("indication");
            }
            dBManagerIndication.AddIndication(Mapper.FromDtoToDalMap(indication));
        }

        public Indication GetIndication(int id)
        {
            var indication = dBManagerIndication.GetIndication(id);
            return Mapper.FromDalToDtoMap(indication);
        }

        public IEnumerable<Indication> GetIndications()
        {
            var dALIndications = dBManagerIndication.GetIndications();
            if (dALIndications != null)
            {
                var dTOIndications = new List<Indication>();
                foreach (var dALIndication in dALIndications)
                {
                    dTOIndications.Add(Mapper.FromDalToDtoMap(dALIndication));
                }
                return dTOIndications;
            }
            return null;
        }

        public IEnumerable<Indication> GetIndicationsByMemberId(int id)
        {
            var dALIndications = dBManagerIndication.GetIndicationsByMemberId(id);
            if (dALIndications != null)
            {
                var dTOIndications = new List<Indication>();
                foreach (var dALIndication in dALIndications)
                {
                    dTOIndications.Add(Mapper.FromDalToDtoMap(dALIndication));
                }
                return dTOIndications;
            }
            return null;
        }      

        public void RemoveIndication(int id)
        {
            dBManagerIndication.RemoveIndication(id);
        }

        public void UpdateIndication(Indication indication)
        {
            if (indication == null)
            {
                throw new ArgumentNullException("indication");
            }
            dBManagerIndication.UpdateIndication(Mapper.FromDtoToDalMap(indication));
        }
    }
}
