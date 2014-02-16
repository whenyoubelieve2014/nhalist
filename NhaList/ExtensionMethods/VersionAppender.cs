namespace NhaList.ExtensionMethods
{
    public interface IVersionAppender
    {
        string Append(string filename);
    }

    public class VersionAppender : IVersionAppender
    {
        private readonly IVersionProvider _versionProvider;

        public VersionAppender(IVersionProvider versionProvider)
        {
            _versionProvider = versionProvider;
        }

        public string Append(string filename)
        {
            string version = _versionProvider.GetVersion();
            return string.Format("{0}?v={1}", filename, version);
        }
    }
}