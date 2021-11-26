namespace Catalog.API
{
    public static class ApiRoutes
    {
        public const string BaseCatalogRouteV1 = "api/v1/catalog";

        public const string WithId = "{id:length(24)}";
        public const string WithActionByCategory = "[action]/{category}";
    }
}