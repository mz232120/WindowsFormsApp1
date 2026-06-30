using System;
using System.IO;

namespace WindowsFormsApp1.util
{
    /// <summary>
    /// 文件工具类：提供文件操作相关的辅助方法
    /// </summary>
    public class FileHelper
    {
        /// <summary>
        /// 查找项目的根目录
        /// 程序运行时默认在 bin/Debug 或 bin/Release 目录下
        /// 此方法向上查找，直到找到项目根目录（包含 .csproj 文件的目录）
        /// </summary>
        /// <returns>项目根目录的完整路径</returns>
        public static string FindProjectRoot()
        {
            // 获取程序当前运行目录（通常是 bin/Debug/net6.0-windows）
            string path = AppDomain.CurrentDomain.BaseDirectory;

            // 循环向上查找，直到找到包含 .csproj 文件的目录
            while (!string.IsNullOrEmpty(path))
            {
                // 检查当前目录是否包含 .csproj 文件
                string[] csprojFiles = Directory.GetFiles(path, "*.csproj");
                if (csprojFiles.Length > 0)
                {
                    return path;
                }

                // 获取上级目录
                DirectoryInfo parent = Directory.GetParent(path);
                if (parent == null)
                {
                    break;
                }
                path = parent.FullName;
            }

            // 如果没找到，返回原始路径
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        /// <summary>
        /// 检查文件是否存在
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>是否存在</returns>
        public static bool FileExists(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return false;

            // 如果是相对路径，拼接项目根目录
            if (!Path.IsPathRooted(filePath))
            {
                string root = FindProjectRoot();
                filePath = Path.Combine(root, filePath);
            }

            return File.Exists(filePath);
        }

        /// <summary>
        /// 获取文件的完整路径
        /// </summary>
        /// <param name="relativePath">相对路径（相对于项目根目录）</param>
        /// <returns>完整路径</returns>
        public static string GetFullPath(string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath))
                return string.Empty;

            // 如果已经是绝对路径，直接返回
            if (Path.IsPathRooted(relativePath))
                return relativePath;

            // 拼接项目根目录
            string root = FindProjectRoot();
            return Path.Combine(root, relativePath);
        }
    }
}
