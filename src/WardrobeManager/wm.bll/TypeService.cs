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
        public static List<dal.Models.Type> GetAll()
        {
            List<wm.dal.Models.Type> types = TypeRepository.GetAllTypes()
                .ToList();

            return types;
        }

        public static dal.Models.Type? GetType(string name)
        {
            dal.Models.Type? type = GetAll()
                .FirstOrDefault(t => t.Name.ToUpper() == name.ToUpper());

            return type;
        }

        public static int GetTypeId(string typeName)
        {
            dal.Models.Type? type = GetType(typeName);

            if(type == null)
            {
                return -1;
            }
            return type.Id;
        }
    }
}
