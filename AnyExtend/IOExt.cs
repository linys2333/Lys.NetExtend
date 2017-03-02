using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using AnyExtend;

namespace AnyExtend
{
    #region IOExtend异常

    /// <summary>
    /// 文件路径异常
    /// </summary>
    public class IOFilePathException : Exception
    {
        public IOFilePathException(string path)
            : base($"文件路径【{path}】不合法！")
        {
        }
    }

    /// <summary>
    /// 文件名异常
    /// </summary>
    public class IOFileNameException : Exception
    {
        public IOFileNameException(string name)
            : base($"文件名【{name}】不合法！")
        {
        }
    }

    /// <summary>
    /// 扩展名异常
    /// </summary>
    public class IOExtNameException : Exception
    {
        public IOExtNameException(string name)
            : base($"扩展名【{name}】不合法！")
        {
        }
    }

    /// <summary>
    /// 文件夹路径异常
    /// </summary>
    public class IOFolderPathException : Exception
    {
        public IOFolderPathException(string path)
            : base($"文件夹路径【{path}】不合法！")
        {
        }
    }
    
    /// <summary>
    /// 文件夹名异常
    /// </summary>
    public class IOFolderNameException : Exception
    {
        public IOFolderNameException(string name)
            : base($"文件夹名【{name}】不合法！")
        {
        }
    }
    
    #endregion

    /// <summary>
    /// 提供IO扩展方法
    /// </summary>
    public static class IOExt
    {
        #region 系统文件夹

        /// <summary>
        /// 存放用户数据的公共文件夹路径
        /// </summary>
        public static readonly string ApplicationPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        #endregion

        #region 常用操作

        /// <summary>
        /// 去只读
        /// <para>IOFilePathException异常</para>
        /// <para>IOFolderPathException异常</para>
        /// </summary>
        /// <param name="path">文件或文件夹路径</param>
        /// <param name="isFile">类型是文件还是文件夹</param>
        public static void RemoveReadonly(string path, bool isFile = true)
        {
            // 文件
            if (isFile)
            {
                if (!CheckFilePath(path))
                {
                    throw new IOFilePathException(path);
                }

                if (File.Exists(path))
                {
                    File.SetAttributes(path, FileAttributes.Normal);
                }
            }
            // 文件夹
            else
            {
                if (!CheckFolderPath(path, false))
                {
                    throw new IOFolderPathException(path);
                }

                if (Directory.Exists(path))
                {
                    var folder = new DirectoryInfo(path);
                    folder.Attributes = FileAttributes.Normal & FileAttributes.Directory;
                }
            }
        }
        
        #endregion

        #region 校验

        /// <summary>
        /// 校验文件扩展名是否合法
        /// </summary>
        /// <param name="ext">扩展名（不含.）</param>
        /// <returns></returns>
        public static bool CheckExt(string ext)
        {
            return Regex.IsMatch(ext, RegexExt.ExtName);
        }

        /// <summary>
        /// 校验文件名称是否合法
        /// <para>IOExtNameException异常</para>
        /// </summary>
        /// <param name="name">文件完整名称</param>
        /// <param name="ext">扩展名（不含.）</param>
        /// <returns></returns>
        public static bool CheckFileName(string name, string ext = "")
        {
            string pattern;
            switch (ext)
            {
                case "":
                    pattern = RegexExt.FileName;
                    break;
                case "*":
                    pattern = RegexExt.FileName2;
                    break;
                default:
                    if (!CheckExt(ext))
                    {
                        throw new IOExtNameException(ext);
                    }
                    pattern = $@"^[^{RegexExt.NoAvailChar}]+\.{ext.ToRegex()}$";
                    break;
            }

            return RegexExt.IsMatchNoCase(name, pattern);
        }

        /// <summary>
        /// 校验文件夹名称（以 \ 开头）是否合法，示例：
        /// <para>\folder</para>
        /// <para>\folder\</para>
        /// <para>\folder\folder</para>
        /// </summary>
        /// <param name="name">文件夹名称</param>
        /// <returns></returns>
        public static bool CheckFolderName(string name)
        {
            return Regex.IsMatch(name, RegexExt.FolderName2);
        }

        /// <summary>
        /// 校验文件路径是否合法，示例：
        /// <para>C:\1.txt</para>
        /// <para>C:\folder\1.txt</para>
        /// <para>C:\folder\1txt</para>
        /// <para>IOExtNameException异常</para>
        /// </summary>
        /// <param name="path">需校验的完整路径</param>
        /// <param name="ext">扩展名（不含.）
        /// <para>若ext=""，则不校验扩展名</para>
        /// <para>若ext=*，则校验任意扩展名</para>
        /// <para>否则，校验指定扩展名</para>
        /// </param>
        /// <returns></returns>
        public static bool CheckFilePath(string path, string ext = "")
        {
            // 解析：[盘符:] + 1或多段[\合法文件夹或文件名]
            string pattern;
            switch (ext)
            {
                case "":
                    pattern = RegexExt.FilePath;
                    break;
                case "*":
                    pattern = RegexExt.FilePath2;
                    break;
                default:
                    if (!CheckExt(ext))
                    {
                        throw new IOExtNameException(ext);
                    }
                    pattern = $@"^{RegexExt.AvailDisk}:({RegexExt.AvailSplit}[^{RegexExt.NoAvailChar}]+)+(?<=\.{ext.ToRegex()})$";
                    break;
            }

            return RegexExt.IsMatchNoCase(path, pattern);
        }

        /// <summary>
        /// 校验文件夹路径是否合法，示例：
        /// <para>C:</para>
        /// <para>C:\</para>
        /// <para>C:\folder</para>
        /// <para>C:\folder\</para>
        /// <para>C:\folder\1.txt</para>
        /// </summary>
        /// <param name="path">需校验的完整路径</param>
        /// <param name="isAvailDiskRootPath">磁盘根路径是否有效</param>
        /// <returns></returns>
        public static bool CheckFolderPath(string path, bool isAvailDiskRootPath = true)
        {
            string pattern = isAvailDiskRootPath ? RegexExt.FolderPath : RegexExt.FolderPath2;

            return Regex.IsMatch(path, pattern);
        }
        
        #endregion

        #region 获取

        /// <summary>
        /// 根据文件路径获取文件夹路径（以 \ 结尾）
        /// <para>IOFilePathException异常</para>
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static string GetFolder(string path)
        {
            if (!CheckFilePath(path))
            {
                throw new IOFilePathException(path);
            }

            return path.Left(path.LastIndexOf('\\') + 1);
        }

        /// <summary>
        /// 根据文件路径获取文件名（含扩展名）
        /// <para>IOFilePathException异常</para>
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static string GetFileName(string path)
        {
            if (!CheckFilePath(path))
            {
                throw new IOFilePathException(path);
            }

            return path.Right(0 - (path.LastIndexOf('\\') + 1));
        }

        /// <summary>
        /// 根据文件名称获取扩展名（不含.）
        /// <para>IOFileNameException异常</para>
        /// </summary>
        /// <param name="name">文件名称</param>
        /// <returns></returns>
        public static string GetExt(string name)
        {
            if (!CheckFileName(name))
            {
                throw new IOFileNameException(name);
            }

            return name.Right(0 - (name.LastIndexOf('.') + 1));
        }

        #endregion

        #region 创建

        /// <summary>
        /// 创建文件夹，若存在则无处理
        /// <para>IOFolderPathException异常</para>
        /// </summary>
        /// <param name="path">文件夹路径</param>
        public static void CreateFolder(string path)
        {
            if (!CheckFolderPath(path, false))
            {
                throw new IOFolderPathException(path);
            }

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        /// <summary>
        /// 创建文件，若存在则无处理。若所在文件夹不存在，则先创建文件夹
        /// <para>IOFilePathException异常</para>
        /// </summary>
        /// <param name="path">文件路径</param>
        public static void CreateFile(string path)
        {
            if(!CheckFilePath(path))
            {
                throw new IOFilePathException(path);
            }
            
            if (!File.Exists(path))
            {
                CreateFolder(GetFolder(path));
                File.Create(path).Close();
            }
        }

        #endregion

        #region 读写

        /// <summary>
        /// 读取文本
        /// <para>IOFilePathException异常</para>
        /// <para>IOException</para>
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="encoding">编码方式（默认UTF8）</param>
        /// <returns></returns>
        public static string Read(string path, Encoding encoding = null)
        {
            EncodingExt.SetEncoding(ref encoding);

            if (!CheckFilePath(path))
            {
                throw new IOFilePathException(path);
            }

            if (!File.Exists(path))
            {
                throw new IOException($"文件路径【{path}】不存在！");
            }

            using (var sw = new StreamReader(path, encoding))
            {
                return sw.ReadToEnd();
            }
        }

        /// <summary>
        /// 写入文本。若文件不存在，则先创建
        /// <para>IOFilePathException异常</para>
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="text">文本内容</param>
        /// <param name="isAppend">是否以追加方式写入</param>
        /// <param name="encoding">编码方式（默认UTF8）</param>
        public static void Write(string path, string text, bool isAppend = false, Encoding encoding = null)
        {
            EncodingExt.SetEncoding(ref encoding);

            CreateFile(path);

            // 去只读
            RemoveReadonly(path);

            using (var sw = new StreamWriter(path, isAppend, encoding))
            {
                sw.WriteLine(text);
            }
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除文件夹及其文件，不存在则无操作
        /// <para>IOFolderPathException异常</para>
        /// </summary>
        /// <param name="path">文件夹路径</param>
        /// <param name="isCheckFiles">是否校验存在文件
        /// <para>若为true（默认），只有空文件夹或子文件夹才执行删除</para>
        /// <para>若为false，清空子文件夹和文件</para>
        /// </param>
        public static void DeleteFolder(string path, bool isCheckFiles = true)
        {
            if (!CheckFolderPath(path, false))
            {
                throw new IOFolderPathException(path);
            }
            
            if (Directory.Exists(path))
            {
                if (isCheckFiles)
                {
                    // 如果存在子文件，不执行清空
                    if (Directory.GetFiles(path).Length > 0)
                    {
                        return;
                    }
                }

                // 循环子级删除
                string[] children = Directory.GetFileSystemEntries(path);
                children.ForEach((childPath) =>
                {
                    // 文件
                    if (File.Exists(childPath))
                    {
                        RemoveReadonly(path);
                        File.Delete(path);
                    }
                    // 文件夹
                    else if(Directory.Exists(childPath))
                    {
                        // 递归删除
                        DeleteFolder(childPath, isCheckFiles);

                        RemoveReadonly(path, false);
                        Directory.Delete(childPath);
                    }
                });
            }
        }

        /// <summary>
        /// 删除文件，不存在则无操作
        /// <para>IOFilePathException异常</para>
        /// </summary>
        /// <param name="path">文件路径</param>
        public static void DeleteFile(string path)
        {
            if (!CheckFilePath(path))
            {
                throw new IOFilePathException(path);
            }

            if (File.Exists(path))
            {
                RemoveReadonly(path);
                File.Delete(path);
            }
        }

        #endregion

        #region Xml操作

        /// <summary>
        /// 创建xml文件
        /// <para>IOFilePathException异常</para>
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="xmlDoc">xml对象</param>
        public static void CreateXml(string path, XmlDocument xmlDoc)
        {
            if (!CheckFilePath(path))
            {
                throw new IOFilePathException(path);
            }
            
            if (!File.Exists(path))
            {
                CreateFolder(GetFolder(path));
                xmlDoc.Save(path);
            }
        }

        /// <summary>
        /// 创建xml文件（UTF8格式）
        /// <para>IOFilePathException异常</para>
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="rootNodeName">根节点名称</param>
        public static XmlDocument CreateXml(string path, string rootNodeName)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", ""));
            xmlDoc.AppendChild(xmlDoc.CreateElement(rootNodeName));

            CreateXml(path, xmlDoc);
            return xmlDoc;
        }

        /// <summary>
        /// 读取xml文本
        /// <para>IOFilePathException异常</para>
        /// <para>IOException</para>
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static XmlDocument ReadXml(string path)
        {
            if (!CheckFilePath(path))
            {
                throw new IOFilePathException(path);
            }

            if (!File.Exists(path))
            {
                throw new IOException($"文件路径【{path}】不存在！");
            }

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(path);

            return xmlDoc;
        }

        /// <summary>
        /// 写入xml文本。若文件不存在，则先创建
        /// <para>IOFilePathException异常</para>
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="xmlDoc">xml对象</param>
        public static void WriteXml(string path, XmlDocument xmlDoc)
        {
            CreateXml(path, xmlDoc);

            // 去只读
            RemoveReadonly(path);

            xmlDoc.Save(path);
        }

        #endregion
    }
}
