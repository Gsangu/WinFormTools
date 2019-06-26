using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
//作者：小红帽   QQ：761716178  论坛：http://bbs.cskin.net/
namespace GsanPlayer
{
    /// <summary>
    /// 本地方法，包含常用静态方法
    /// </summary>
    internal class NativeMethods
    {
        /// <summary>
        /// 提取非托管Ansi字符
        /// </summary>
        /// <param name="ansiPtr"></param>
        /// <returns></returns>
        public static string IntPtrAsStringAnsi(IntPtr ansiPtr)
        {
            if (ansiPtr != IntPtr.Zero)
            {
                return Marshal.PtrToStringAnsi(ansiPtr);
            }
            return null;
        }

        /// <summary>
        /// 提取非托管Ansi字符
        /// </summary>
        /// <param name="ansiPtr"></param>
        /// <param name="len">长度</param>
        /// <returns></returns>
        public static string IntPtrAsStringAnsi(IntPtr ansiPtr, int len)
        {
            if ((ansiPtr != IntPtr.Zero) && (len > 0))
            {
                byte[] destination = new byte[len];
                Marshal.Copy(ansiPtr, destination, 0, len);
                return Encoding.Default.GetString(destination, 0, len);
            }
            return null;
        }
        /// <summary>
        /// 提取非托管Unicode字符
        /// </summary>
        /// <param name="unicodePtr"></param>
        /// <returns></returns>
        public static string IntPtrAsStringUnicode(IntPtr unicodePtr)
        {
            if (unicodePtr != IntPtr.Zero)
            {
                return Marshal.PtrToStringUni(unicodePtr);
            }
            return null;
        }
        /// <summary>
        /// 提取非托管Unicode字符
        /// </summary>
        /// <param name="unicodePtr"></param>
        /// <param name="len">长度</param>
        /// <returns></returns>
        public static string IntPtrAsStringUnicode(IntPtr unicodePtr, int len)
        {
            if (unicodePtr != IntPtr.Zero)
            {
                return Marshal.PtrToStringUni(unicodePtr, len);
            }
            return null;
        }
        /// <summary>
        /// 提取非托管Utf8字符
        /// </summary>
        /// <param name="utf8Ptr"></param>
        /// <returns></returns>
        public static string IntPtrAsStringUtf8(IntPtr utf8Ptr)
        {
            if (utf8Ptr != IntPtr.Zero)
            {
                int length = intPtrSize(utf8Ptr);
                if (length != 0)
                {
                    byte[] destination = new byte[length];
                    Marshal.Copy(utf8Ptr, destination, 0, length);
                    return Encoding.UTF8.GetString(destination, 0, length);
                }
            }
            return null;
        }
        /// <summary>
        /// 提取非托管Utf8字符
        /// </summary>
        /// <param name="utf8Ptr"></param>
        /// <param name="len">长度</param>
        /// <returns></returns>
        public static string IntPtrAsStringUtf8(IntPtr utf8Ptr, out int len)
        {
            len = 0;
            if (utf8Ptr != IntPtr.Zero)
            {
                len = intPtrSize(utf8Ptr);
                if (len != 0)
                {
                    byte[] destination = new byte[len];
                    Marshal.Copy(utf8Ptr, destination, 0, len);
                    return Encoding.UTF8.GetString(destination, 0, len);
                }
            }
            return null;
        }

        /// <summary>
        /// 获取句柄数据空字节之前的长度
        /// </summary>
        /// <param name="A_0"></param>
        /// <returns></returns>
        public static int intPtrSize(IntPtr A_0)
        {
            int ofs = 0;
            while (Marshal.ReadByte(A_0, ofs) != 0)
            {
                ofs++;
            }
            return ofs;
        }

        /// <summary>
        /// 从非托管中提取utf-8字符数组
        /// </summary>
        /// <param name="pointer"></param>
        /// <returns></returns>
        public static unsafe string[] IntPtrToArrayNullTermUtf8(IntPtr pointer)
        {
            if (pointer != IntPtr.Zero)
            {
                List<string> list = new List<string>();
                string item = string.Empty;
                while (true)
                {
                    int length = intPtrSize(pointer);
                    if (length <= 0)
                    {
                        break;
                    }
                    byte[] destination = new byte[length];
                    Marshal.Copy(pointer, destination, 0, length);
                    pointer = new IntPtr(((byte*)pointer.ToPointer() + length) + 1);
                    item = Encoding.UTF8.GetString(destination, 0, length);
                    list.Add(item);
                }
                if (list.Count > 0)
                {
                    return list.ToArray();
                }
            }
            return null;
        }
    }
}
