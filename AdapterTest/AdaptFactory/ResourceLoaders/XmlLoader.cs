namespace ResourceFactory
{
    public class XmlLoader : IResourceLoader
    {
        string IResourceLoader.WhoAmId()
        {
            return "I am xml Loader";
        }
    }
}
