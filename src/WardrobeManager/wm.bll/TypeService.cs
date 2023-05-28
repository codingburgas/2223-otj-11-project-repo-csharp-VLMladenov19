using wm.dal.Repositories;
using wm.dal.Data;
using wm.util;

namespace wm.bll
{
    public class TypeService
    {
        // Retrieve all clothing types
        public static List<dal.Models.Type> GetAll()
        {
            using(var context = new WardrobeManagerContext())
            {
                TypeRepository typeRepository = new(context);

                List<wm.dal.Models.Type> types = typeRepository.GetAll()
                .ToList();

                return types;
            }
        }

        // Retrieve a type
        public static dal.Models.Type? GetType(string name)
        {
            dal.Models.Type? type = GetAll()
                .FirstOrDefault(t => t.Name.ToUpper() == name.ToUpper());

            return type;
        }

        // Retrieve a type's id
        public static int GetTypeId(string typeName)
        {
            dal.Models.Type? type = GetType(typeName);

            if(type == null)
            {
                return (int)ErrorCodes.InvalidObject;
            }
            return type.Id;
        }
    }
}
