using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace BugChang.Blog.Utility
{
    public static class ImageHelper
    {
        /// <summary>
        /// 无损压缩图片
        /// </summary>
        /// <param name="sFile">原图片地址</param>
        /// <param name="dFile">压缩后保存图片地址</param>
        /// <param name="flag">压缩质量（数字越小压缩率越高）1-100</param>
        /// <returns></returns>
        public static bool CompressImage(string sFile, string dFile, int flag = 90)
        {
            var iSource = Image.FromFile(sFile);
            var tFormat = iSource.RawFormat;
            var dHeight = iSource.Height / 2;
            var dWidth = iSource.Width / 2;
            int sW;
            int sH;
            //按比例缩放
            var temSize = new Size(iSource.Width, iSource.Height);
            if (temSize.Width > dHeight || temSize.Width > dWidth)
            {
                if ((temSize.Width * dHeight) > (temSize.Width * dWidth))
                {
                    sW = dWidth;
                    sH = dWidth * temSize.Height / temSize.Width;
                }
                else
                {
                    sH = dHeight;
                    sW = temSize.Width * dHeight / temSize.Height;
                }
            }
            else
            {
                sW = temSize.Width;
                sH = temSize.Height;
            }

            var ob = new Bitmap(dWidth, dHeight);
            var g = Graphics.FromImage(ob);

            g.Clear(Color.WhiteSmoke);
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            g.DrawImage(iSource, new Rectangle((dWidth - sW) / 2, (dHeight - sH) / 2, sW, sH), 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);

            g.Dispose();

            //以下代码为保存图片时，设置压缩质量
            var ep = new EncoderParameters();
            var qy = new long[1];
            qy[0] = flag;//设置压缩的比例1-100
            var eParam = new EncoderParameter(Encoder.Quality, qy);
            ep.Param[0] = eParam;

            try
            {
                var arrayIci = ImageCodecInfo.GetImageEncoders();
                var jpegIcInfo = arrayIci.FirstOrDefault(t => t.FormatDescription.Equals("JPEG"));
                if (jpegIcInfo != null)
                {
                    ob.Save(dFile, jpegIcInfo, ep);//dFile是压缩后的新路径
                }
                else
                {
                    ob.Save(dFile, tFormat);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                iSource.Dispose();
                ob.Dispose();
            }
        }

        public static bool CompressImage(Stream stream, string savePath, int flag = 90)
        {
            if (stream.Length < 358400)
            {
                using var fileStream = System.IO.File.Create(savePath);
                stream.Position = 0;
                stream.CopyTo(fileStream);
                return true;
            }
            var iSource = Image.FromStream(stream);
            var tFormat = iSource.RawFormat;
            var dHeight = iSource.Height / 2;
            var dWidth = iSource.Width / 2;
            int sW, sH;
            //按比例缩放
            var temSize = new Size(iSource.Width, iSource.Height);
            if (temSize.Width > dHeight || temSize.Width > dWidth)
            {
                if ((temSize.Width * dHeight) > (temSize.Width * dWidth))
                {
                    sW = dWidth;
                    sH = dWidth * temSize.Height / temSize.Width;
                }
                else
                {
                    sH = dHeight;
                    sW = temSize.Width * dHeight / temSize.Height;
                }
            }
            else
            {
                sW = temSize.Width;
                sH = temSize.Height;
            }

            var ob = new Bitmap(dWidth, dHeight);
            var g = Graphics.FromImage(ob);

            g.Clear(Color.WhiteSmoke);
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            g.DrawImage(iSource, new Rectangle((dWidth - sW) / 2, (dHeight - sH) / 2, sW, sH), 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);

            g.Dispose();

            //以下代码为保存图片时，设置压缩质量
            var ep = new EncoderParameters();
            var qy = new long[1];
            qy[0] = flag;//设置压缩的比例1-100
            var eParam = new EncoderParameter(Encoder.Quality, qy);
            ep.Param[0] = eParam;

            try
            {
                var arrayIci = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo jpegIcInfo = arrayIci.FirstOrDefault(t => t.FormatDescription.Equals("JPEG"));
                if (jpegIcInfo != null)
                {
                    ob.Save(savePath, jpegIcInfo, ep);//dFile是压缩后的新路径
                }
                else
                {
                    ob.Save(savePath, tFormat);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                iSource.Dispose();
                ob.Dispose();
            }
        }
    }
}
