using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApiDemo.Models
{   /*Seed para inicialiazar la base de datos , hereda de la clase "DropCreateDatabaseAlways" que recibe el contexto de la base
      de datos y se initicializa cada que se construyela apliacion
    */
    public class WebAPIDemoContextInitializer : DropCreateDatabaseAlways<WebApiDemoContext>
    {
        //Sobre escribe el metodo seed que trae por defecto
        protected override void Seed(WebApiDemoContext context)
        {
            var books = new List<Book>
            {
                new Book() {Title="War and Peace",Author="Tolstoy",Price=15.99m },
                new Book() {Title="Harry Potter",Author="J.k",Price=17.99m },
                new Book() {Title="Pro win 8",Author="Liberty",Price=9.59m },

            };

            books.ForEach(b => context.Books.Add(b));
            context.SaveChanges(); //Guarda los cambios en la base de datos

            var order = new Order() { Customer = "Jose Valdez", OrderDate = new DateTime(2016, 11, 20) };
            var details = new List<OrderDetail>
            {
                new OrderDetail() {Book=books[0],Quantity=1,Order=order },
                new OrderDetail() {Book=books[1],Quantity=3,Order=order },
                new OrderDetail() {Book=books[2],Quantity=2,Order=order }
            };
            context.Order.Add(order);
            details.ForEach(o => context.OrderDetails.Add(o));
            context.SaveChanges();

             order = new Order() { Customer = "Isael Valdez", OrderDate = new DateTime(2016, 11, 25) };
             details = new List<OrderDetail>
            {
                new OrderDetail() {Book=books[2],Quantity=4,Order=order },
                new OrderDetail() {Book=books[1],Quantity=3,Order=order },
                new OrderDetail() {Book=books[0],Quantity=2,Order=order }
            };
            context.Order.Add(order);
            details.ForEach(o => context.OrderDetails.Add(o));
            context.SaveChanges();


            base.Seed(context);
        }
    }
}