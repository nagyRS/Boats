using BWL.Domain.Abstract;
using BWL.Domain.Entities;
using System.Collections.Generic;


namespace BWL.Domain.Concrete
{
    public class EFBoatRepository : IBoatRepository
    {

        private EFDbContext context = new EFDbContext();

        public IEnumerable<Boat> Boats
        {
            get { return context.Boats; }
        }

        public void SaveBoat(Boat boat)
        {
            if (boat.Id == 0)
            {
                context.Boats.Add(boat);
            }
            else
            {
                Boat dbEntry = context.Boats.Find(boat.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = boat.Name;
                    dbEntry.Length = boat.Length;
                    dbEntry.YearBuilt = boat.YearBuilt;
                    dbEntry.Price = boat.Price;
                    dbEntry.BestOfferUrl = boat.BestOfferUrl;
                    dbEntry.ImageData = boat.ImageData;
                    dbEntry.ImageMimeType = boat.ImageMimeType;
                }
            }

            context.SaveChanges();
        }


        public Boat DeleteBoat(int id)
        {
            Boat dbEntry = context.Boats.Find(id);


            if (dbEntry != null)
            {
                context.Boats.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }



    }
}
