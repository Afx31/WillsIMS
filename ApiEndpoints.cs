namespace WillsIMS
{
    public class ApiEndpoints
    {
        private const string ApiBase = "/api";

        public static class Customer
        {
            private const string Base = $"{ApiBase}/customer";

            public const string GetAll = $"{Base}";
        }

        public static class InventoryItem
        {
            private const string Base = $"{ApiBase}/inventoryItem";

            public const string GetAll = $"{Base}";
        }

        public static class OrderItem
        {
            private const string Base = $"{ApiBase}/orderItem";

            public const string GetAll = $"{Base}";
        }

        public static class Orders
        {
            private const string Base = $"{ApiBase}/orders";

            public const string GetAll = $"{Base}";
        }

        public static class Product
        {
            private const string Base = $"{ApiBase}/product";

            public const string GetAll = $"{Base}";
        }
    }
}
