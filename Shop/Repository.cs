using System;
using System.Collections.Generic;
using System.Text;

namespace Shop
{
    public static class Repository
    {
        //DB of products sample
        public static List<Product> productsList = new List<Product>()
        {
            new Product("Apple", Product.productCategoryType.Fruit, "Description of Apple", 100m),
            new Product("Plum", Product.productCategoryType.Fruit, "Description of Plum", 200m),
            new Product("Carrot", Product.productCategoryType.Vegetable, "Description of Carrot", 300m),
            new Product("Veal", Product.productCategoryType.Meat, "Description of Veal", 400m),
            new Product("Pork", Product.productCategoryType.Meat, "Description of Pork", 500m),
            new Product("Sword fish", Product.productCategoryType.Fish, "Description of Sword fish", 600m),
            new Product("Beer", Product.productCategoryType.Alcohol, "Description of Beer", 600m),
            new Product("Wine", Product.productCategoryType.Alcohol, "Description of Wine", 600m),
            new Product("Juice", Product.productCategoryType.nonAlcohol, "Description of Juice", 600m),
            new Product("Coca-Cola", Product.productCategoryType.nonAlcohol, "Description of Coca-Cola", 600m)
        };

        internal static void Add(Product product)
        {
            productsList.Add(product);
        }
    }
}
