using System.Reflection;

namespace NhaList.ExtensionMethods
{
    public interface IVersionProvider
    {
        string GetVersion();
    }
    public class VersionProvider : IVersionProvider
    {
        public string GetVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}