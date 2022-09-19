namespace ResourceFactory
{
    public class CSVLoader : IResourceLoader
    {
        string IResourceLoader.WhoAmId()
        {
            return "I am CSV Loader";
        }
    }
}
