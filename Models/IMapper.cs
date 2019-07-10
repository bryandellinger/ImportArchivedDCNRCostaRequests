using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportArchivedDCNRCostaRequests.Models
{
    public interface IMapper
    {
        List<COSTAForm> MapOstForm(List<OstForm> ostForms);
    }
}
