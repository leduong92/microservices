using Microservices.ProductApi.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Microservices.ProductApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<TypeCategory> Types { get; set; }
        public DbSet<LifeStyle> LifeStyles { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialCategory> MaterialCategories { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Collection>().HasData(new Collection { Id = 1, Name = "Iconic", Slug = "the-iconic-collection", SortOrder = 10, ImageUrl = "https://ik.imagekit.io/9float9hy/Banner_for_Collection/the-iconic-collection/1.jpg?updatedAt=1750665390031", Description = "The Iconic Collection makes careful use of rich materials and elevated forms for a discerning aesthetic that emphasizes luxury and eclectic refinement. Bronze outlines, asymmetric surfaces, sumptuous tufting, and bold, textural bases are beautifully concluded in an Icon Bronze finish." });
            modelBuilder.Entity<Collection>().HasData(new Collection { Id = 2, Name = "Repose", Slug = "repose", SortOrder = 20, ImageUrl = "https://ik.imagekit.io/9float9hy/Banner_for_Collection/repose/2.jpg?updatedAt=1750665342699", Description = "Elevated by a carefully sculpted minimalism, the Repose collection beautifully plays sinuous curves against distinctly shaped forms in a relaxed palette of soothing neutrals. Wire-brushed white oak is elegantly finished in a choice of Charcoal Oak or Grey Oak. " });
            modelBuilder.Entity<Collection>().HasData(new Collection { Id = 3, Name = "Hudson", Slug = "hudson-collection", SortOrder = 30, ImageUrl = "https://ik.imagekit.io/9float9hy/Banner_for_Collection/hudson-collection/1.jpg?updatedAt=1750665317811", Description = "Luxurious upholstered pieces pair elegantly with rich maple veneers and contrasting metal accents in Theodore Alexander’s Hudson Collection. A curated assortment of exquisite designs, the feeling of Art Deco luxury follows muted burl finished in exquisite maple grey with polished stainless-steel accents. From contrasting maple drawers to white marble tops, the Hudson Collection places an emphasis on sleek and modern sophistication. Finished in Pebble Grey with stainless steel hardware." });
            modelBuilder.Entity<Collection>().HasData(new Collection { Id = 4, Name = "Kesden", Slug = "kesden-collection", SortOrder = 40, ImageUrl = "https://ik.imagekit.io/9float9hy/Banner_for_Collection/kesden-collection/1.jpg?updatedAt=1750665322308", Description = "The Kesden Collection tells a story that begins with the depth and richness of Theodore Alexander’s veneers and ends with clean and transitional lines that promote gorgeous finishes and metal accents. The Kesden Collection possesses a feeling of effortless sophistication. With graceful silhouettes and gentle figures, Kesden is a harmonious blend of organic, sculpted bamboo forms and contrasting marbles, metals and veneers. From exquisite legs in bronze to Tamo ash burl tops, each piece serves as functional art for the home." });
            modelBuilder.Entity<Collection>().HasData(new Collection { Id = 5, Name = "Dorchester", Slug = "dorchester", SortOrder = 50, ImageUrl = "https://ik.imagekit.io/9float9hy/Banner_for_Collection/dorchester/5.jpg?updatedAt=1750665308596", Description = "The Dorchester Collection is an accomplished reimagining of early 20th century design. Pairing decorative ornamentation with masterfully sculpted forms, handcrafted silhouettes lend themselves to a refined and sumptuous presence across swooping curves, tapered lines, and modern profiles." });
            modelBuilder.Entity<Collection>().HasData(new Collection { Id = 6, Name = "Luna", Slug = "luna", SortOrder = 60, ImageUrl = "https://ik.imagekit.io/9float9hy/Banner_for_Collection/luna/1.jpg?updatedAt=1750665327360", Description = "A tease between understated glamor  and coastal ease, the Luna collection’s  gentle round edges and stylish  silhouettes infuse contemporary comfort  in two colorways: dark Palmer and  light Cascade. This collection’s suite of  thoughtfully designed oak furnishings  adapts to a wide range of settings from  seaside estate to bustling city lofts and  everything in between." });
            modelBuilder.Entity<Collection>().HasData(new Collection { Id = 7, Name = "Spencer London", Slug = "spencer-london", SortOrder = 70, ImageUrl = "https://ik.imagekit.io/9float9hy/Banner_for_Collection/spencer-london/6.jpg?updatedAt=1750665356731", Description = "Marrying styles of Lord Spencer’s London home  with the exquisite capabilities of Theodore  Alexander’s craftsmanship, the Spencer London  collection brings fresh perspective to elegant  metro living. A consistent thread of chic,  mixed metal inlays are seen throughout the  furniture forms, bringing England’s rich history  to a current day contemporary style. Crafted  in figured sycamore, maple, and khaya crotch  wood, these designs have been painstakingly  fine tuned to offer a tailored product that is  uncompromising, timeless and approachable." });
            modelBuilder.Entity<Collection>().HasData(new Collection { Id = 8, Name = "Judith Leiber Couture", Slug = "judith-leiber-couture", SortOrder = 80, ImageUrl = "https://ik.imagekit.io/9float9hy/Banner_for_Collection/judith-leiber-couture/1.jpg?updatedAt=1750665321193", Description = "Immerse yourself in the opulent world of Judith Leiber Couture with our inaugural collection, a showcase of indulgent sophistication that pays homage to the iconic aesthetic of the revered fashion designer. Each piece is a creative masterpiece, adorned with resplendent details such as mother-of-pearl encrusted inlays, meticulously hand-painted details, and polished brass accents. Presented in the exquisite Mink or Martini oak finishes, these luxurious statement pieces, mirroring the essence of the brand’s iconic handbags, are tailored to individuals who embrace an elegant approach to life." });
            modelBuilder.Entity<Collection>().HasData(new Collection { Id = 9, Name = "Althorp - Victory Oak", Slug = "althorp--victory-oak", SortOrder = 90, ImageUrl = "https://ik.imagekit.io/9float9hy/Banner_for_Collection/althorp--victory-oak/3.jpg?updatedAt=1750665278808", Description = "The histories of the Spencer Family’s Heritage and Althorp are so tightly entwined that they would be impossible to unravel and separate. These Spencer ancestors were able to indulge their tastes – to commission art, furniture, and all the finer things in life. You can see the Spencer touch in every corner of Althorp – this historic house that my family has called “home” for over 500 years, and which for the past decade, has been given unprecedented care and attention." });
            modelBuilder.Entity<Collection>().HasData(new Collection { Id = 10, Name = "Steve Leung", Slug = "the-steve-leung-collection", SortOrder = 100, ImageUrl = "https://ik.imagekit.io/9float9hy/Banner_for_Collection/the-steve-leung-collection/3.jpg?updatedAt=1750665395304", Description = "Steve Leung is an internationally recognized architect, interior designer and product designer based in Hong Kong. As a dedicated contemporary style advocate, Steve’s works reflect a sophisticated minimalism, with skillful adoption of Asian culture and arts. Over the past 20 years, Steve has led many extensive projects that have received worldwide acclaim and fame. In 2015, Steve was honored with the Andrew Martin International Designer of the Year Award. He has also won the Andrew Martin International Design Award 13 times since 1999." });
            modelBuilder.Entity<Collection>().HasData(new Collection { Id = 11, Name = "Stephen Church", Slug = "the-stephen-church-collection", SortOrder = 110, ImageUrl = "https://ik.imagekit.io/9float9hy/Banner_for_Collection/the-stephen-church-collection/2.jpg?updatedAt=1750665392278", Description = "Stephen Church is a Master Cabinetmaker who designs as well as crafts fine furniture following the tradition of English 18th century cabinet makers from Adam and Chippendale to Hepplewhite and Sheraton. Today those traditions are maintained with pride by a selected team of craftsmen working at Theodore Alexander." });

            modelBuilder.Entity<Room>().HasData(new Room { Id = 1, Name = "Office", Slug = "office", SortOrder = 40, ImageUrl = "https://ik.imagekit.io/9float9hy/Banner_for_Room/office/1.jpg?updatedAt=1750665186620", Description = "office" });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 2, Name = "Dining", Slug = "dining-room", SortOrder = 20, ImageUrl = "https://ik.imagekit.io/9float9hy/Banner_for_Room/dining-room/1.jpg?updatedAt=1750665186841", Description = "dining" });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 3, Name = "Décor", Slug = "decor", SortOrder = 60, ImageUrl = "https://ik.imagekit.io/9float9hy/Banner_for_Room/decor/1.jpg?updatedAt=1750665186988", Description = "decor" });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 4, Name = "Lighting", Slug = "lighting", SortOrder = 50, ImageUrl = "https://ik.imagekit.io/9float9hy/Banner_for_Room/lighting/1.jpg?updatedAt=1750665186559", Description = "lighting" });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 5, Name = "Bed", Slug = "bedroom", SortOrder = 30, ImageUrl = "https://ik.imagekit.io/9float9hy/Banner_for_Room/bedroom/1.jpg?updatedAt=1750665186637", Description = "bedroom" });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 6, Name = "Living", Slug = "living-room", SortOrder = 1, ImageUrl = "https://ik.imagekit.io/9float9hy/Banner_for_Room/living-room/1.jpg?updatedAt=1750665186744", Description = "living" });

            modelBuilder.Entity<LifeStyle>().HasData(new LifeStyle { Id = 1, Name = "Classic", Slug = "classic", SortOrder = 10, ImageUrl = "", Description = "" });
            modelBuilder.Entity<LifeStyle>().HasData(new LifeStyle { Id = 2, Name = "Transitional", Slug = "transitional", SortOrder = 20, ImageUrl = "", Description = "" });
            modelBuilder.Entity<LifeStyle>().HasData(new LifeStyle { Id = 3, Name = "Rustic", Slug = "rustic", SortOrder = 30, ImageUrl = "", Description = "" });
            modelBuilder.Entity<LifeStyle>().HasData(new LifeStyle { Id = 4, Name = "Modern", Slug = "modern", SortOrder = 40, ImageUrl = "", Description = "" });
            modelBuilder.Entity<LifeStyle>().HasData(new LifeStyle { Id = 5, Name = "Casual", Slug = "casual", SortOrder = 50, ImageUrl = "", Description = "" });

            modelBuilder.Entity<Style>().HasData(new Style { Id = 1, Name = "Formal Classic", Slug = "classic", SortOrder = 10, ImageUrl = "", Description = "" });
            modelBuilder.Entity<Style>().HasData(new Style { Id = 2, Name = "Casual Classic", Slug = "casual-classic", SortOrder = 20, ImageUrl = "", Description = "" });
            modelBuilder.Entity<Style>().HasData(new Style { Id = 3, Name = "Formal Traditional", Slug = "formal-traditional", SortOrder = 30, ImageUrl = "", Description = "" });
            modelBuilder.Entity<Style>().HasData(new Style { Id = 4, Name = "Casual Traditional", Slug = "casual-traditional", SortOrder = 40, ImageUrl = "", Description = "" });
            modelBuilder.Entity<Style>().HasData(new Style { Id = 5, Name = "Casual Rustic", Slug = "casual-rustic", SortOrder = 50, ImageUrl = "", Description = "" });
            modelBuilder.Entity<Style>().HasData(new Style { Id = 6, Name = "Formal Modern", Slug = "formal-modern", SortOrder = 60, ImageUrl = "", Description = "" });
            modelBuilder.Entity<Style>().HasData(new Style { Id = 7, Name = "Casual Modern", Slug = "casual-modern", SortOrder = 70, ImageUrl = "", Description = "" });
            modelBuilder.Entity<Style>().HasData(new Style { Id = 8, Name = "Formal Casual", Slug = "formal-casual", SortOrder = 80, ImageUrl = "", Description = "" });
            modelBuilder.Entity<Style>().HasData(new Style { Id = 9, Name = "Casual", Slug = "casual", SortOrder = 90, ImageUrl = "", Description = "" });

            modelBuilder.Entity<TypeCategory>().HasData(new TypeCategory { Id = 1, RoomId = 1, Name = "Bookcases & Etageres", Slug = "bookcases--etageres", SortOrder = 90, ImageUrl = "", Description = "" });
            modelBuilder.Entity<TypeCategory>().HasData(new TypeCategory { Id = 2, RoomId = 1, Name = "Desks & Bureauxs", Slug = "Desks--Bureauxs", SortOrder = 90, ImageUrl = "", Description = "" });
            modelBuilder.Entity<TypeCategory>().HasData(new TypeCategory { Id = 3, RoomId = 1, Name = "Desk Chairs", Slug = "desk-chairs", SortOrder = 370, ImageUrl = "", Description = "" });
            modelBuilder.Entity<TypeCategory>().HasData(new TypeCategory { Id = 4, RoomId = 2, Name = "Round Dining Tables", Slug = "round-dining-tables", SortOrder = 90, ImageUrl = "", Description = "" });
            modelBuilder.Entity<TypeCategory>().HasData(new TypeCategory { Id = 5, RoomId = 2, Name = "Rectangular & Oval Dining Table", Slug = "rectangular--oval-dining-table", SortOrder = 90, ImageUrl = "", Description = "" });
            modelBuilder.Entity<TypeCategory>().HasData(new TypeCategory { Id = 6, RoomId = 2, Name = "Bar Carts & Cabinets", Slug = "bar-carts--cabinets", SortOrder = 90, ImageUrl = "", Description = "" });
            modelBuilder.Entity<TypeCategory>().HasData(new TypeCategory { Id = 7, RoomId = 2, Name = "Dining Chairs", Slug = "dining-chairs", SortOrder = 380, ImageUrl = "", Description = "" });
            modelBuilder.Entity<TypeCategory>().HasData(new TypeCategory { Id = 8, RoomId = 2, Name = "Sideboards & Buffets", Slug = "sideboards--buffets", SortOrder = 710, ImageUrl = "", Description = "" });
            modelBuilder.Entity<TypeCategory>().HasData(new TypeCategory { Id = 9, RoomId = 3, Name = "Mirrors", Slug = "mirrors", SortOrder = 560, ImageUrl = "", Description = "" });
            modelBuilder.Entity<TypeCategory>().HasData(new TypeCategory { Id = 10, RoomId = 3, Name = "Table Top Accessories", Slug = "table-top-accessories", SortOrder = 780, ImageUrl = "", Description = "" });
            modelBuilder.Entity<TypeCategory>().HasData(new TypeCategory { Id = 11, RoomId = 3, Name = "Wall Art", Slug = "wall-art", SortOrder = 880, ImageUrl = "", Description = "" });
            modelBuilder.Entity<TypeCategory>().HasData(new TypeCategory { Id = 12, RoomId = 4, Name = "Ceiling Lighting", Slug = "ceiling-lighting", SortOrder = 200, ImageUrl = "", Description = "" });
            modelBuilder.Entity<TypeCategory>().HasData(new TypeCategory { Id = 13, RoomId = 4, Name = "Floor Lighting", Slug = "floor-lighting", SortOrder = 480, ImageUrl = "", Description = "" });
            modelBuilder.Entity<TypeCategory>().HasData(new TypeCategory { Id = 14, RoomId = 4, Name = "Table Lighting", Slug = "table-lighting", SortOrder = 770, ImageUrl = "", Description = "" });
            modelBuilder.Entity<TypeCategory>().HasData(new TypeCategory { Id = 15, RoomId = 5, Name = "Beds", Slug = "beds", SortOrder = 90, ImageUrl = "", Description = "" });
            modelBuilder.Entity<TypeCategory>().HasData(new TypeCategory { Id = 16, RoomId = 5, Name = "Benches", Slug = "benches", SortOrder = 100, ImageUrl = "", Description = "" });
            modelBuilder.Entity<TypeCategory>().HasData(new TypeCategory { Id = 17, RoomId = 5, Name = "Dressers & Chests", Slug = "dressers--chests", SortOrder = 410, ImageUrl = "", Description = "" });
            modelBuilder.Entity<TypeCategory>().HasData(new TypeCategory { Id = 18, RoomId = 5, Name = "Nightstands", Slug = "nightstands", SortOrder = 580, ImageUrl = "", Description = "" });
            modelBuilder.Entity<TypeCategory>().HasData(new TypeCategory { Id = 19, RoomId = 6, Name = "Accent Tables", Slug = "accent-tables", SortOrder = 40, ImageUrl = "", Description = "" });
            modelBuilder.Entity<TypeCategory>().HasData(new TypeCategory { Id = 20, RoomId = 6, Name = "Center Tables", Slug = "center-tables", SortOrder = 210, ImageUrl = "", Description = "" });
            modelBuilder.Entity<TypeCategory>().HasData(new TypeCategory { Id = 21, RoomId = 6, Name = "Cocktail Tables", Slug = "cocktail-tables", SortOrder = 270, ImageUrl = "", Description = "" });
            modelBuilder.Entity<TypeCategory>().HasData(new TypeCategory { Id = 22, RoomId = 6, Name = "Console Tables", Slug = "console-tables", SortOrder = 300, ImageUrl = "", Description = "" });
            modelBuilder.Entity<TypeCategory>().HasData(new TypeCategory { Id = 23, RoomId = 6, Name = "Ottomans & Stools", Slug = "ottomans--stools", SortOrder = 600, ImageUrl = "", Description = "" });
            modelBuilder.Entity<TypeCategory>().HasData(new TypeCategory { Id = 24, RoomId = 6, Name = "Side Tables", Slug = "side-tables", SortOrder = 700, ImageUrl = "", Description = "" });
            modelBuilder.Entity<TypeCategory>().HasData(new TypeCategory { Id = 25, RoomId = 6, Name = "Sofas & Settees", Slug = "sofas--settees", SortOrder = 730, ImageUrl = "", Description = "" });

        }
    }
}
