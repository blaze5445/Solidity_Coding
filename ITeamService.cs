using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICD.Base.BusinessServiceContract
{
    public interface ITeamService
    {
        Task<InsertTeamResult> InsertTeamAsync(InsertTeamRequest request);
        Task<RemoveTeamFromChampionshipResult> RemoveTeamFromChampionshipAsync(RemoveTeamFromChampionshipRequest request);
        Task<GetTeamsBySpecificChampionshipResult> GetTeamsBySpecificChampionshipAsync(GetTeamsBySpecificChampionshipQuery query);
    }
}
