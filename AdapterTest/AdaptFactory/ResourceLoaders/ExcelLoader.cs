namespace ResourceFactory
{
    public class ExcelLoader : IResourceLoader
    {
        string IResourceLoader.WhoAmId()
        {
            return "I am Excel Loader";
        }
    }
}
