using GardenCommunity.Business.DTO;
using System.Collections.Generic;

namespace GardenCommunity.Business.Interfaces
{
    public interface IIndicationProvider
    {
        int AddIndication(Indication indication);
        int UpdateIndication(Indication indication);
        int RemoveIndication(int id);
        Indication GetIndication(int id);
        IEnumerable<Indication> GetIndications();
        IEnumerable<Indication> GetIndicationsByMemberId(int id);
    }
}
