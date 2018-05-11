using System;
using System.Collections.Generic;
using GardenCommunity.DAL.Entities;


namespace GardenCommunity.DAL.Interfaces
{
    public interface IDBManagerIndication
    {
        IEnumerable<Indication> GetIndicationsByMemberId(int id);
        void AddIndication(Indication indication);
        void UpdateIndication(Indication indication);
        void RemoveIndication(int id);
    }
}
