using ExcelDataReader;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Data;

namespace Gourmet.Database
{
    internal sealed class AppDatabaseContext : DbContext
    {

        public DbSet<Products> ProductsDbSet { get; set; }
        public DbSet<Users> UsersDbSet { get; set; }
        public DbSet<Recipes> RecipesDbSet { get; set; }
        private int rowCount = 0;
        private int colCount = 0;


        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            Console.WriteLine("Calling OnConfiguring from AppDatabaseContext and configure the database...");
            dbContextOptionsBuilder.UseSqlite("Data Source=./Database/ApplicationDatabase.db");
        }

        //private byte[] ImageToByteArray(String imageTitle)
        //{
        //    return File.ReadAllBytes("E:/Facultate An III Sem II/II/Proiect II 2/Repo/Web-App-II/Gourmet/Database/Products Images/" + imageTitle);
        //}

        //private Microsoft.Office.Interop.Excel._Worksheet GetExcelFileWorksheet(String fileName)
        //{
        //    Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
        //    Microsoft.Office.Interop.Excel.Workbook xlWorkbook =
        //        xlApp.Workbooks.Open(
        //            "E:/Facultate An III Sem II/II/Proiect II 2/Repo/Web-App-II/Gourmet/Database/" + fileName);
        //    Microsoft.Office.Interop.Excel._Worksheet xlWorksheet =
        //        (Microsoft.Office.Interop.Excel._Worksheet)xlWorkbook.Sheets[1];
        //    Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;

        //    this.rowCount = xlRange.Rows.Count;
        //    this.colCount = xlRange.Columns.Count;

        //    return xlWorksheet;
        //}

        //private void populateProductsTable(ModelBuilder modelBuilder)
        //{
        //    ArrayList productsArrayList = new ArrayList();
        //    Microsoft.Office.Interop.Excel._Worksheet workSheet = GetExcelFileWorksheet("Products.xlsx");
        //    int ProductIdAux = 0;
        //    string ProductNameAux = "";
        //    int ProductQuantityAux = 0;
        //    double ProductPriceAux = 0.0;
        //    string ProductDescriptionAux = "";
        //    byte[] ProductImageAux = new byte[] { 0 };
        //    for (int i = 1; i <= rowCount; i++)
        //    {
        //        for (int j = 1; j <= colCount; j++)
        //        {
        //            switch (j)
        //            {
        //                case 1:
        //                    ProductIdAux = (int)(workSheet.Cells[i, j] as Microsoft.Office.Interop.Excel.Range).Value;
        //                    break;
        //                case 2:
        //                    ProductNameAux = (string)(workSheet.Cells[i, j] as Microsoft.Office.Interop.Excel.Range).Value;
        //                    break;
        //                case 3:
        //                    ProductQuantityAux = (int)(workSheet.Cells[i, j] as Microsoft.Office.Interop.Excel.Range).Value;
        //                    break;
        //                case 4:
        //                    ProductPriceAux = (double)(workSheet.Cells[i, j] as Microsoft.Office.Interop.Excel.Range).Value;
        //                    break;
        //                case 5:
        //                    ProductDescriptionAux = (string)(workSheet.Cells[i, j] as Microsoft.Office.Interop.Excel.Range).Value;
        //                    break;
        //                case 6:
        //                    ProductImageAux = ImageToByteArray((string)(workSheet.Cells[i, j] as Microsoft.Office.Interop.Excel.Range).Value);
        //                    break;
        //            }
        //        }

        //        productsArrayList.Add(new Products
        //        {
        //            ProductId = ProductIdAux,
        //            ProductName = ProductNameAux,
        //            ProductQuantity = ProductQuantityAux,
        //            ProductPrice = ProductPriceAux,
        //            ProductDescription = ProductDescriptionAux,
        //            ProductImage = ProductImageAux
        //        });
        //    }
        //    modelBuilder.Entity<Products>().HasData(productsArrayList);
        //}

        //private void populateRecipesTable(ModelBuilder modelBuilder)
        //{
        //    ArrayList recipesArrayList = new ArrayList();

        //    // TO BE COMPLETED AS ABOVE

        //    modelBuilder.Entity<Products>().HasData(recipesArrayList);

        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Console.WriteLine("Calling OnModelCreating from AppDatabaseContext and creating the database...");
        }
    }
}
