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
        IEnumerable<Indication> GetIndicationsByMemberId(int id);        
    }
}
