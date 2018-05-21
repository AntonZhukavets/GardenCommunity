using System;
using System.Collections.Generic;
using GardenCommunity.Business.DTO;

namespace GardenCommunity.Business.Interfaces
{
    public interface IIndicationProvider
    {
        void AddIndication(Indication indication);
        void UpdateIndication(Indication indication);
        void RemoveIndication(int id);
        Indication GetIndication(int id);
        IEnumerable<Indication> GetIndications();        
        IEnumerable<Indication> GetIndicationsByMemberId(int id);        
    }
}
