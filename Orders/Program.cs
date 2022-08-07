// See https://aka.ms/new-console-template for more information
using Orders.EF;
using Orders.Models;

using (var ctx = new OrderDbContext())
{
    var order = new Order{ };
    ctx.Orders.Add(order);
    var orderdetails = new OrderDetail() {OrderID=1, ProductID = 1, Quantity = 2 };

    ctx.OrderDetails.Add(orderdetails);
    ctx.SaveChanges();
}
Console.WriteLine("1 order inserted!");
