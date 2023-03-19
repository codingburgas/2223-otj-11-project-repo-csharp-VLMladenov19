using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.dal.Repositories;

namespace wm.bll
{
    public class TypeService
    {
        public static List<dal.Models.Type> GetAllTypes()
        {
            var types = TypeRepository.GetAllTypes().ToList();

            return types;
        }
    }
}
