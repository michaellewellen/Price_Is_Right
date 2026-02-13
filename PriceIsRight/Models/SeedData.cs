using Microsoft.EntityFrameworkCore;

public static class SeedData
{
    public static void Initialize(PriceIsRightContext context)
    {
        if (context.Prizes.Any()) return;

        context.Prizes.AddRange(
            // D Tier - Grocery Items
            new Prize { Tier = "D", Name = "Campbell's Chunky Gumbo Soup", MSRP = 1.45m, ShortDescription = "A can of Campbell's Chunky Gumbo Soup", LongDescription = "A hearty can of Campbell's Chunky Gumbo Soup, perfect for a quick and delicious meal.", ImageURL = null, IsActive = true },
            new Prize { Tier = "D", Name = "Barilla Spaghetti Noodles", MSRP = 1.25m, ShortDescription = "A box of Barilla Spaghetti Noodles", LongDescription = "A classic box of Barilla Spaghetti Noodles, perfect for your favorite pasta dishes.", ImageURL = null, IsActive = true },
            new Prize { Tier = "D", Name = "Libby's Fresh Green Beans", MSRP = 0.75m, ShortDescription = "A can of Libby's Fresh Green Beans", LongDescription = "A can of Libby's Fresh Green Beans, a healthy and delicious side dish for any meal.", ImageURL = null, IsActive = true },

            // C Tier - Opening Bid Prizes
            new Prize { Tier = "C", Name = "Samsung 75\" 8K UHD TV", MSRP = 2500.00m, ShortDescription = "A stunning 75 inch 8K UHD TV from Samsung", LongDescription = "Experience breathtaking picture quality with this Samsung 75 inch 8K UHD Television. With stunning clarity and vibrant colors, this TV will transform your living room into a home theater.", ImageURL = null, IsActive = true },
            new Prize { Tier = "C", Name = "ELIO E-Bike 5-Speed Pedal Assist", MSRP = 3000.00m, ShortDescription = "A 5-speed pedal assist E-Bike from ELIO", LongDescription = "Cruise through your neighborhood in style with this ELIO 5-Speed Pedal Assist E-Bike. With a powerful electric motor and five pedal assist levels, this bike makes every ride effortless and fun.", ImageURL = null, IsActive = true },
            new Prize { Tier = "C", Name = "Traeger Outdoor Grill", MSRP = 900.00m, ShortDescription = "A Traeger Outdoor Grill with self-feeding pellet smoker", LongDescription = "Take your outdoor cooking to the next level with this Traeger Outdoor Grill featuring a self-feeding pellet smoker. Whether you're grilling, smoking, or baking, this grill does it all.", ImageURL = null, IsActive = true },

            // B Tier - Medium Prizes
            new Prize { Tier = "B", Name = "7-Day Caribbean Cruise", MSRP = 5400.00m, ShortDescription = "A 7-day Caribbean cruise on Carnival Cruise Lines", LongDescription = "Set sail for paradise with this 7-Day Caribbean Cruise on Carnival Cruise Lines. Enjoy stunning ocean views, world-class dining, and exciting port excursions on this unforgettable voyage.", ImageURL = null, IsActive = true },
            new Prize { Tier = "B", Name = "Broyhill King Bedroom Set", MSRP = 9000.00m, ShortDescription = "A complete king bedroom set from Broyhill", LongDescription = "Transform your bedroom into a luxury retreat with this complete Broyhill Bedroom Set, featuring a elegant bed frame, two matching nightstands, and a plush Sealy King mattress.", ImageURL = null, IsActive = true },
            new Prize { Tier = "B", Name = "Vespa Scooter 75HP", MSRP = 3000.00m, ShortDescription = "A bright red 75HP Vespa Scooter", LongDescription = "Turn heads wherever you go with this stunning bright red Vespa Scooter. With a powerful 75HP engine and iconic Italian styling, this scooter is the perfect blend of performance and elegance.", ImageURL = null, IsActive = true },

            // A Tier - Big Prizes
            new Prize { Tier = "A", Name = "14-Day Mediterranean Cruise", MSRP = 12500.00m, ShortDescription = "A luxurious 14-day Mediterranean cruise", LongDescription = "Experience the magic of the Mediterranean on this breathtaking 14-Day Cruise. Visit stunning ports of call, indulge in exquisite cuisine, and create memories that will last a lifetime.", ImageURL = null, IsActive = true },
            new Prize { Tier = "A", Name = "Toyota Tundra Deluxe Sports Package", MSRP = 42000.00m, ShortDescription = "A brand new Toyota Tundra with Deluxe Sports Package", LongDescription = "Hit the road in style with this brand new Toyota Tundra featuring the Deluxe Sports Package. With powerful performance, premium features, and rugged good looks, this truck is ready for any adventure.", ImageURL = null, IsActive = true },
            new Prize { Tier = "A", Name = "2026 Mercedes-Benz S-Class", MSRP = 75000.00m, ShortDescription = "A stunning 2026 Mercedes-Benz S-Class Diesel", LongDescription = "Experience the pinnacle of automotive luxury with this stunning 2026 Mercedes-Benz S-Class Diesel. With unparalleled comfort, cutting-edge technology, and effortless performance, this is the ultimate driving experience.", ImageURL = null, IsActive = true }
        );

        context.SaveChanges();
    }
}