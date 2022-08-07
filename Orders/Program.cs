// See https://aka.ms/new-console-template for more information
using Orders.EF;
using Orders.Models;

using (var ctx = new OrderDbContext())
{
    var order = new Order{ OrderDate=DateTime.Now };
    ctx.Orders.Add(order);
   
    ctx.SaveChanges();
}
Console.WriteLine("1 order inserted!");
