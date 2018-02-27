namespace Library.Configuration
{
    public static class ConfigSettings
    {
        public static string ConnectionString { get; set; }

        static ConfigSettings()
        {
            ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=LibraryDb;Trusted_Connection=True;MultipleActiveResultSets=true";
        }
    }
}
