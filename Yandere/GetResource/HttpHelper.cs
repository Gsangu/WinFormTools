using GetResource;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Yandere
{
    class HttpHelper
    {
        //public static string GetHtml(string url)
        //{
        //    CookieContainer cookie = new CookieContainer();
        //    cookie.Add(new Uri(url), new Cookie("PHPSESSID", "p3l65qoa1a90ps0sds1m751un0"));
        //    cookie.Add(new Uri(url), new Cookie("yunsuo_session_verify", "4f3096e53349b07a82837afc47b6dbee"));
        //    return GetHtml(url, cookie);
        //}

        public static string GetHtml(string url, CookieContainer cookie = null, WebProxy proxy = null)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            request.UserAgent = GetUserAgent();
            request.Timeout = 60000;
            // 添加cookie
            if (cookie != null)
            {
                request.CookieContainer = cookie;
            }

            if (proxy != null)
            {
                request.Proxy = proxy;
            }

            string retString = "";
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return retString;
        }

        public static Image GetImage(string url)
        {
            Image image = null;
            try
            {
                System.Net.WebRequest webreq = System.Net.WebRequest.Create(url);
                System.Net.WebResponse webres = webreq.GetResponse();
                using (System.IO.Stream stream = webres.GetResponseStream())
                {
                    image = Image.FromStream(stream);
                }
            }
            catch
            {
                return null;
            }
            return image;
        }

        public static string GetUserAgent()
        {
            string[] userAgents = {
                "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_5) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.115 Safari/537.36",
                "Mozilla/5.0 (iPhone; CPU iPhone OS 9_1 like Mac OS X) AppleWebKit/601.1.46 (KHTML, like Gecko) Version/9.0 Mobile/13B143 Safari/601.1",
                "Mozilla/5.0 (iPhone; CPU iPhone OS 9_1 like Mac OS X) AppleWebKit/601.1.46 (KHTML, like Gecko) Version/9.0 Mobile/13B143 Safari/601.1",
                "Mozilla/5.0 (Linux; Android 5.0; SM-G900P Build/LRX21T) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.115 Mobile Safari/537.36",
                "Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.115 Mobile Safari/537.36",
                "Mozilla/5.0 (Linux; Android 5.1.1; Nexus 6 Build/LYZ28E) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.115 Mobile Safari/537.36",
                "Mozilla/5.0 (iPhone; CPU iPhone OS 10_3_2 like Mac OS X) AppleWebKit/603.2.4 (KHTML, like Gecko) Mobile/14F89;GameHelper",
                "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_5) AppleWebKit/603.2.4 (KHTML, like Gecko) Version/10.1.1 Safari/603.2.4",
                "Mozilla/5.0 (iPhone; CPU iPhone OS 10_0 like Mac OS X) AppleWebKit/602.1.38 (KHTML, like Gecko) Version/10.0 Mobile/14A300 Safari/602.1",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36",
                "Mozilla/5.0 (Macintosh; Intel Mac OS X 10.12; rv:46.0) Gecko/20100101 Firefox/46.0",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:46.0) Gecko/20100101 Firefox/46.0",
                "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0)",
                "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0; Trident/4.0)",
                "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)",
                "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Win64; x64; Trident/6.0)",
                "Mozilla/5.0 (Windows NT 6.3; Win64, x64; Trident/7.0; rv:11.0) like Gecko",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2311.135 Safari/537.36 Edge/13.10586",
                "Mozilla/5.0 (iPad; CPU OS 10_0 like Mac OS X) AppleWebKit/602.1.38 (KHTML, like Gecko) Version/10.0 Mobile/14A300 Safari/602.1"
            };
            Random r = new Random();
            return userAgents[r.Next(0, userAgents.Length)];
        }

        public static string SougouOCR(string url)
        {
            try
            {
                string text = "------WebKitFormBoundaryRDEqU0w702X9cWPJ";
                Image image = new Bitmap(GetImage(url));
                if (image.Width > 70 && image.Height < 70)
                {
                    Bitmap bitmap = new Bitmap(image.Width, 80);
                    Graphics graphics = Graphics.FromImage(bitmap);
                    graphics.DrawImage(image, 10, 0, image.Width, image.Height);
                    graphics.Save();
                    graphics.Dispose();
                    image = new Bitmap(bitmap);
                }
                else if (image.Width <= 70 && image.Height >= 70)
                {
                    Bitmap bitmap = new Bitmap(80, image.Height);
                    Graphics graphics = Graphics.FromImage(bitmap);
                    graphics.DrawImage(image, 0, 10, image.Width, image.Height);
                    graphics.Save();
                    graphics.Dispose();
                    image = new Bitmap(bitmap);
                }
                else if (image.Width < 70 && image.Height < 70)
                {
                    Bitmap bitmap = new Bitmap(80, 80);
                    Graphics graphics = Graphics.FromImage(bitmap);
                    graphics.DrawImage(image, 10, 10, image.Width, image.Height);
                    graphics.Save();
                    graphics.Dispose();
                    image = new Bitmap(bitmap);
                }
                else
                {
                    image = new Bitmap(GetImage(url));
                }
                byte[] b = ImageTobyte(image);
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(text + "\r\n");
                stringBuilder.Append("Content-Disposition: form-data; name=\"pic\"; filename=\"test.jpg\"");
                stringBuilder.Append("\r\n");
                stringBuilder.Append("Content-Type: image/jpeg\r\n\r\n");
                byte[] arg_1B0_0 = Encoding.ASCII.GetBytes(stringBuilder.ToString());
                stringBuilder.Clear();
                stringBuilder.Append("\r\n" + text + "--\r\n");
                byte[] bytes = Encoding.ASCII.GetBytes(stringBuilder.ToString());
                byte[] array = Copybyte(arg_1B0_0, b);
                array = Copybyte(array, bytes);
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://ocr.shouji.sogou.com/v2/ocr/json");
                httpWebRequest.Method = "POST";
                httpWebRequest.ContentType = "multipart/form-data; boundary=" + text.Substring(2);
                httpWebRequest.Timeout = 10000;
                httpWebRequest.ReadWriteTimeout = 2000;
                httpWebRequest.Accept = "application/x-ms-application, image/jpeg, application/xaml+xml, image/gif, image/pjpeg, application/x-ms-xbap, */*";
                httpWebRequest.Referer = "http://ocr.shouji.sogou.com/v2/ocr/json";
                httpWebRequest.Headers.Add("Accept-Encoding", "gzip,deflate");
                httpWebRequest.Headers.Add("Accept-Language", "zh-CN");
                byte[] buffer = array;
                using (Stream requestStream = httpWebRequest.GetRequestStream())
                {
                    requestStream.Write(buffer, 0, array.Length);
                }
                Stream result = ((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream();
                string txt = new StreamReader(result, Encoding.GetEncoding("utf-8")).ReadToEnd();
                httpWebRequest.Abort();
                result.Close();
                Match match = Regex.Match(txt, @"[1-9]\d*", RegexOptions.Multiline | RegexOptions.IgnoreCase);
                return match.Value;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        
        public static byte[] ImageTobyte(Image imgPhoto)
        {
            MemoryStream memoryStream = new MemoryStream();
            imgPhoto.Save(memoryStream, ImageFormat.Bmp);
            byte[] array = new byte[memoryStream.Length];
            memoryStream.Position = 0L;
            memoryStream.Read(array, 0, array.Length);
            memoryStream.Close();
            return array;
        }
        public static byte[] Copybyte(byte[] a, byte[] b)
        {
            byte[] array = new byte[a.Length + b.Length];
            a.CopyTo(array, 0);
            b.CopyTo(array, a.Length);
            return array;
        }
    }
}
