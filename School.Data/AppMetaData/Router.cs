namespace School.Data.AppMetaData
{
    public static class Router
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Rule = Root + "/" + Version + "/";
        public const string SingleRoute = "{id}";
        public static class StudentRouting
        {
            public const string Prefix = Rule + "student";
            public const string Create = Prefix + "/create";
            public const string GetById = Prefix + SingleRoute;
        }
    }
}
