using RojikanPU.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojikanPU.Repositories.Interfaces
{
    public interface IStateRepository : IBaseRepository<State>
    {
        bool IsStateExist(string areaCode);

        List<State> GetStatesGraph(string id, int year);
    }
}
