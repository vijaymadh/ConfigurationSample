
namespace ServiceLocator
{
    public static class Locator
    {
        public static Iservice objService;
        public static Iservice SetLocation(Iservice temService)
        {
            if (objService == null) objService = new LoggingService();
            return objService;
        }
        public static void ExecuteService()
        {
            objService.ExecuteService();
        }

    }
}
