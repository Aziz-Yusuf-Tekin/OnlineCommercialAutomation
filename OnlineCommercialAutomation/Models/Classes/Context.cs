using System.Data.Entity;

namespace OnlineCommercialAutomation.Models.Classes
{
    public class Context : DbContext
    {
        //admin
        public DbSet<Admin> Admins { get; set; }
        //cari
        public DbSet<Customer> Customers { get; set; }
        //departman
        public DbSet<Department> Departments { get; set; }
        //fatura kalem
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        //fatura
        public DbSet<Invoice> Invoices { get; set; }
        //gider
        public DbSet<Expense> Expenses { get; set; }
        //kategori
        public DbSet<Category> Categories { get; set; }
        //personel
        public DbSet<Employee> Employees { get; set; }
        //satış hareket
        public DbSet<SalesMovement> SalesMovements { get; set; }
        //ürün
        public DbSet<Product> Products { get; set; }
        //ürün detay
        public DbSet<Detail> Details { get; set; }
        //yapılacaklar listesi
        public DbSet<ToDoList> ToDoLists { get; set; }
        //kargo detay 
        public DbSet<CargoDetail> CargoDetails { get; set; }
        //kargo takip
        public DbSet<CargoTracking> CargoTrackings { get; set; }
        //mesajlar
        public DbSet<Message> Messages { get; set; }
    }
}
