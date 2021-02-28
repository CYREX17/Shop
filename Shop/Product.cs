namespace Shop
{
    public class Product
    {
        private string productName;
        private productCategoryType productCategory;
        private string productDescription;
        private decimal productPrice;

        public string ProductName
        {
            get => productName;
            set => productName = value;
        }

        public productCategoryType ProductCategory
        {
            get => productCategory;
            set => productCategory = value;
        }

        public string ProductDescription
        {
            get => productDescription;
            set => productDescription = value;
        }

        public decimal ProductPrice
        {
            get => productPrice;
            set => productPrice = value;
        }


        public enum productCategoryType
        {
            Fruit,
            Vegetable,
            Meat,
            Fish,
            Alcohol,
            nonAlcohol
        }

        public Product(string name, productCategoryType category, string description, decimal price)
        {
            productName = name;
            productCategory = category;
            productDescription = description;
            productPrice = price;
        }
    }
}