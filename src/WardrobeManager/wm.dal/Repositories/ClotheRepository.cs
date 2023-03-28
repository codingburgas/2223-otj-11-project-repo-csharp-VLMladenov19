using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wm.dal.Data;
using wm.dal.Models;

namespace wm.dal.Repositories
{
    public class ClotheRepository
    {
        public static List<Clothe> GetAllClothes()
        {
            using (var context = new WardrobeManagerContext())
            {
                var list = context.Clothes
                    .ToList();

                return list;
            }
        }

        public static void AddClothe(Clothe clothe)
        {
            using (var context = new WardrobeManagerContext())
            {
                context.Clothes.Add(clothe);

                context.SaveChanges();
            }
        }

        public static void RemoveClothing(int clotheId)
        {
            using (var context = new WardrobeManagerContext())
            {
                var clothing = context.Clothes
                    .FirstOrDefault(c => c.Id == clotheId);

                if(clothing != null)
                {
                    context.Clothes.Remove(clothing);

                    context.SaveChanges();
                }
            }
        }

        public static void EditClothing(Clothe newClothing)
        {
            using (var context = new WardrobeManagerContext())
            {
                var oldClothing = context.Clothes
                    .FirstOrDefault(c => c.Id == newClothing.Id);

                if(oldClothing != null)
                {
                    oldClothing.Name = newClothing.Name;
                    oldClothing.TypeId = newClothing.TypeId;
                }

                context.SaveChanges();
            }
        }
    }
}
