using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Net;
using System.IO;

namespace GsanPlayer
{

    /// <summary> 
    /// 图像处理辅助类 
    /// </summary> 
    public class ImageHelper
    {
        /// <summary> 
        /// 获取均分图片中的某一个 
        /// </summary> 
        public static Image GetImageByAverageIndex(Image orignal, int count, int index)
        {
            int width = orignal.Width / count;
            return CutImage(orignal, width * (index - 1), width, orignal.Height-3);
        }

        /// <summary> 
        /// 获取图片一部分 
        /// </summary> 
        private static Image CutImage(Image orignal, int start, int width, int height)
        {
            Bitmap partImage = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(partImage);//获取画板 
            Rectangle srcRect = new Rectangle(start, 0, width, height);//源位置开始 
            Rectangle destRect = new Rectangle(0, 0, width, height);//目标位置 
            //复制图片 
            g.DrawImage(orignal, destRect, srcRect, GraphicsUnit.Pixel);
            partImage.MakeTransparent(Color.FromArgb(255, 0, 255));
            g.Dispose();
            return partImage;
        }
        #region 网络图片转成image
        /// <summary>
        /// 网络图片转成image
        /// </summary>
        /// <param name="aPhotoUrl">图片url</param>
        /// <returns>图片</returns>
        public static Image GetImg(string aPhotoUrl)
        {
                Uri mUri = new Uri(aPhotoUrl);
                HttpWebRequest mRequest = (HttpWebRequest)WebRequest.Create(mUri);
                mRequest.Method = "GET";
                mRequest.Timeout = 2000;
                mRequest.ContentType = "text/html;charset=utf-8";
                HttpWebResponse mResponse = (HttpWebResponse)mRequest.GetResponse();
                Stream mStream = mResponse.GetResponseStream();
                Image mImage = Image.FromStream(mStream);
                return mImage;
        }
        #endregion

        #region 缩略图
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="img">源图</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>    
        public static Image MakeThumbnail(Image img, int width, int height, string mode)
        {
            Image originalImage = img;

            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            switch (mode)
            {
                case "HW":  //指定高宽缩放（可能变形）                
                    break;
                case "W":   //指定宽，高按比例                    
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H":   //指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut": //指定高宽裁减（不变形）                
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }

            //新建一个bmp图片
            Image bitmap = new Bitmap(towidth, toheight);

            //新建一个画板
            Graphics g = Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            g.Clear(Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight), new Rectangle(x, y, ow, oh), GraphicsUnit.Pixel);
            return bitmap;
        }
        #endregion
    }
}
