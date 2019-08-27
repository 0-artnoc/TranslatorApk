using System.IO;
using System.Net;
using System.Threading.Tasks;
using TranslatorApk.Logic.OrganisationItems;

namespace TranslatorApk.Logic.Utils
{
    internal static class WebUtils
    {
        /// <summary>
        /// ����� �������� ������ �� ������� ��� �������� ������ �� ���������
        /// </summary>
        public const int DefaultTimeout = 50000;

        public const string ServerVersionLink = "https://pixelcurves.ams3.digitaloceanspaces.com/TranslatorApk/Version.txt";
        public const string ServerChangesLink = "https://pixelcurves.ams3.digitaloceanspaces.com/TranslatorApk/Changes.xml";
        public const string ServerLatestExeLink = "https://pixelcurves.ams3.digitaloceanspaces.com/TranslatorApk/Update.exe";
        public const string ServerPluginsDirLink = "https://pixelcurves.ams3.digitaloceanspaces.com/TranslatorApk/Plugins";

        /// <summary>
        /// ���������� ��������� �������� � ���� ������ �� ������
        /// </summary>
        /// <param name="link">������</param>
        /// <param name="timeout">����� �������� ������ �� �������</param>
        public static Task<string> DownloadStringAsync(string link, int timeout)
        {
            return Task<string>.Factory.StartNew(() => DownloadString(link, timeout));
        }

        /// <summary>
        /// ��������� �������� � ���� ������ �� ������
        /// </summary>
        /// <param name="link">������</param>
        /// <param name="timeout">����� �������� ������ �� �������</param>
        public static string DownloadString(string link, int timeout)
        {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType) 3072; //SecurityProtocolType.Tls12

            var client = (HttpWebRequest)WebRequest.Create(link);

            client.UserAgent = GlobalVariables.MozillaAgent;
            client.Timeout = client.ReadWriteTimeout = timeout;

            Stream stream = client.GetResponse().GetResponseStream();

            if (stream == null)
                return string.Empty;

            using (var reader = new StreamReader(stream))
                return reader.ReadToEnd();
        }
    }
}