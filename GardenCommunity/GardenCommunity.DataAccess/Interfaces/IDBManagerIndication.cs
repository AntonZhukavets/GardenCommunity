using GardenCommunity.DataAccess.Entities;
using System.Collections.Generic;

namespace GardenCommunity.DataAccess.Interfaces
{
    public interface IDBManagerIndication
    {
        int AddIndication(Indication indication);
        int UpdateIndication(Indication indication);
        int RemoveIndication(int id);
        Indication GetIndication(int id);
        IEnumerable<Indication> GetIndications();
        IEnumerable<Indication> GetIndicationsByMemberId(int id);
    }
}
