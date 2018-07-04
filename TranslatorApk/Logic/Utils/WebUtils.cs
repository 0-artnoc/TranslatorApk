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
            var client = (HttpWebRequest)WebRequest.Create(link);

            client.UserAgent = GlobalVariables.MozillaAgent;
            client.Timeout = client.ReadWriteTimeout = timeout;

            Stream stream = client.GetResponse().GetResponseStream();

            if (stream == null)
                return string.Empty;

            using (var strread = new StreamReader(stream))
                return strread.ReadToEnd();
        }
    }
}