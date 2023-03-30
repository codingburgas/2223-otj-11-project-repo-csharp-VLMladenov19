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

        public static void RemoveClothe(int clotheId)
        {
            using (var context = new WardrobeManagerContext())
            {
                var clothe = context.Clothes
                    .FirstOrDefault(c => c.Id == clotheId);

                if(clothe != null)
                {
                    context.Clothes.Remove(clothe);

                    context.SaveChanges();
                }
            }
        }

        public static void EditClothe(Clothe newClothe)
        {
            using (var context = new WardrobeManagerContext())
            {
                var oldClothe = context.Clothes
                    .FirstOrDefault(c => c.Id == newClothe.Id);

                if(oldClothe != null)
                {
                    oldClothe.Name = newClothe.Name;
                    oldClothe.TypeId = newClothe.TypeId;
                }

                context.SaveChanges();
            }
        }
    }
}
