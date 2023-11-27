namespace WillsIMS
{
    public class ApiEndpoints
    {
        private const string ApiBase = "/api";

        public static class Company
        {
            private const string Base = $"{ApiBase}/company";

            public const string Create = Base;
            public const string Get = $"{Base}/{{id}}";
            public const string GetAll = $"{Base}";
            public const string Update = $"{Base}/{{id}}";
            public const string Delete = $"{Base}/{{id}}";
        }

        public static class Product
        {
            private const string Base = $"{ApiBase}/product";

            public const string Create = Base;
            public const string Get = $"{Base}/{{id}}";
            public const string GetAll = $"{Base}";
            public const string Update = $"{Base}/{{id}}";
            public const string Delete = $"{Base}/{{id}}";
        }

        public static class BinLocation
        {
            private const string Base = $"{ApiBase}/binLocation";

            public const string Create = Base;
            public const string Get = $"{Base}/{{id}}";
            public const string GetAll = $"{Base}";
            public const string Update = $"{Base}/{{id}}";
            public const string Delete = $"{Base}/{{id}}";
        }

        public static class InventoryItem
        {
            private const string Base = $"{ApiBase}/inventoryItem";

            public const string Create = Base;
            public const string Get = $"{Base}/{{id}}";
            public const string GetAll = $"{Base}";
            public const string Update = $"{Base}/{{id}}";
            public const string Delete = $"{Base}/{{id}}";

            public const string GetAllWithBinLocations = $"{Base}WithBinLocations";
        }

        public static class InboundOrder
        {
            private const string Base = $"{ApiBase}/inboundOrder";

            public const string Create = Base;
            public const string Get = $"{Base}/{{id}}";
            public const string GetAll = $"{Base}";
            public const string Update = $"{Base}/{{id}}";
            public const string Delete = $"{Base}/{{id}}";
        }

        public static class InboundOrderItem
        {
            private const string Base = $"{ApiBase}/inboundOrderItem";

            public const string Create = Base;
            public const string Get = $"{Base}/{{id}}";
            public const string GetAll = $"{Base}";
            public const string Update = $"{Base}/{{id}}";
            public const string Delete = $"{Base}/{{id}}";
        }

        public static class OutboundOrder
        {
            private const string Base = $"{ApiBase}/outboundOrder";

            public const string GetAll = $"{Base}";
        }

        public static class OutboundOrderItem
        {
            private const string Base = $"{ApiBase}/outboundOrderItem";

            public const string GetAll = $"{Base}";
        }

        
    }
}
