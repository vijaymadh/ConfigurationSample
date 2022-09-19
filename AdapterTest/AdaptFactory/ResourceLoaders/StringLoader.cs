namespace ResourceFactory
{
    public class StringLoader : IResourceLoader
    {
        string IResourceLoader.WhoAmId()
        {
            return "I am string Loader";
        }
    }
}
