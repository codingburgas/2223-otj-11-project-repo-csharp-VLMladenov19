using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using wm.dal.Repositories;

namespace wm.bll
{
    public class TypeService
    {
        public static List<dal.Models.Type> GetAllTypes()
        {
            var types = TypeRepository.GetAllTypes()
                .ToList();

            return types;
        }

        public static int GetTypeIdByTypeName(string name)
        {
            var type = TypeRepository.GetAllTypes()
                .FirstOrDefault(t => t.Name == name);

            if(type == null)
            {
                return -1;
            }
            return type.Id;
        }
    }
}
