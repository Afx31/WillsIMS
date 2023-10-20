﻿namespace WillsIMS
{
    public class ApiEndpoints
    {
        private const string ApiBase = "/api";

        public static class Company
        {
            private const string Base = $"{ApiBase}/company";

            public const string GetAll = $"{Base}";
        }

        public static class InventoryItem
        {
            private const string Base = $"{ApiBase}/inventoryItem";

            public const string GetAll = $"{Base}";
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

        public static class Product
        {
            private const string Base = $"{ApiBase}/product";

            public const string GetAll = $"{Base}";
        }
    }
}
