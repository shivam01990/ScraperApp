using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class wslu_JobTypesServices
    {
        #region--Instance--
        public static wslu_JobTypesServices Instance = new wslu_JobTypesServices();
        #endregion

        #region--Get wslu_JobTypesServices--
        public List<wslu_JobTypes> GetJobTypes(int jobtype_id)
        {
            List<wslu_JobTypes> rType = new List<wslu_JobTypes>();
            using (DBEntities db = new DBEntities())
            {
                rType = db.wslu_JobTypes.Where(u => u.jobtype_id == jobtype_id || jobtype_id == 0).ToList();
            }
            return rType;
        }
        #endregion

    }
}
