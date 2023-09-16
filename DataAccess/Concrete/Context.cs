using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DILAN\SQLEXPRESS;Database=StajData;integrated security=true;TrustServerCertificate=True;
");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                    .HasKey(c => new { c.CategoryID, c.ProductId });
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SaleTransaction> SaleTransactions { get; set; }
        public DbSet<Invoice> Invoinces { get; set; }
        public DbSet<InvoiceItem> InvoinceItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem>CartItems { get; set; }
        public DbSet<WishlistItem> WishlistItems { get; set; }




    }
}
