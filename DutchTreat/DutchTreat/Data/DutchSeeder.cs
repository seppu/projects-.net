using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat.Data
{
    public class DutchSeeder
    {
        private readonly DutchContext ctx;
        private readonly IWebHostEnvironment hosting;
        private readonly UserManager<StoreUser> userManager;

        public DutchSeeder(DutchContext ctx,IWebHostEnvironment hosting, UserManager<StoreUser> userManager)
        {
            this.ctx = ctx;
            this.hosting = hosting;
            this.userManager = userManager;
        }

        public async Task SeedAsync()
        {
            this.ctx.Database.EnsureCreated();
            StoreUser user = await userManager.FindByEmailAsync("joseph@josephabraham.dev");
            if (user == null)
            {
                user = new StoreUser()
                {
                    FirstName = "Joseph",
                    LastName = "Abraham",
                    Email = "joseph@josephabraham.dev",
                    UserName = "joseph@josephabraham.dev"
                };
                var result = await userManager.CreateAsync(user, "P@ssw0rd!");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create new user in seeder");
                }
            }
            if (!this.ctx.Products.Any())
            {
                //Need to create sample data
                var filePath = Path.Combine(this.hosting.ContentRootPath,"Data/art.json");                
                var json = File.ReadAllText(filePath);
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                this.ctx.Products.AddRange(products);

                var order = this.ctx.Orders.Where(o => o.Id == 1).FirstOrDefault();
                if (order != null)
                {
                    order.User = user;
                    order.Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                          Product = products.First(),
                          Quantity = 5,
                          UnitPrice = products.First().Price
                        }
                    };
                }

                this.ctx.SaveChanges();
            }
        }
    }
}
