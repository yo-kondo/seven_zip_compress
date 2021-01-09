using System;
using System.IO;
using NUnit.Framework;
using SevenZipCompress;

namespace SevenZipCompressTests
{
    public class SevenZipCompressTests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// ファイルを圧縮（7z）
        /// </summary>
        [Test]
        public void Test001()
        {
            var workPath = Path.Combine(Environment.CurrentDirectory, "TestData/Test001");

            DeleteFile(workPath);

            var args = new[] {workPath + "/Test001.txt", "TestData/Test001/appsettings.json"};
            Program.Execute(args);

            Assert.That(File.Exists(workPath + "/PrefixTest001.7z"), Is.True);
        }

        /// <summary>
        /// ディレクトリを圧縮（7z）
        /// </summary>
        [Test]
        public void Test002()
        {
            var workPath = Path.Combine(Environment.CurrentDirectory, "TestData/Test002");

            DeleteFile(workPath);

            var args = new[] {workPath + "/新しいフォルダー", "TestData/Test002/appsettings.json"};
            Program.Execute(args);

            Assert.That(File.Exists(workPath + "/Prefix新しいフォルダー.7z"), Is.True);
        }

        /// <summary>
        /// ファイルを圧縮（zip）
        /// </summary>
        [Test]
        public void Test003()
        {
            var workPath = Path.Combine(Environment.CurrentDirectory, "TestData/Test003");

            DeleteFile(workPath);

            var args = new[] {workPath + "/Test003.txt", "TestData/Test003/appsettings.json"};
            Program.Execute(args);

            Assert.That(File.Exists(workPath + "/PrefixTest003.zip"), Is.True);
        }

        /// <summary>
        /// ディレクトリを圧縮（zip）
        /// </summary>
        [Test]
        public void Test004()
        {
            var workPath = Path.Combine(Environment.CurrentDirectory, "TestData/Test004");

            DeleteFile(workPath);

            var args = new[] {workPath + "/新しいフォルダー", "TestData/Test004/appsettings.json"};
            Program.Execute(args);

            Assert.That(File.Exists(workPath + "/Prefix新しいフォルダー.zip"), Is.True);
        }
        
        /// <summary>
        /// 指定されたディレクトリ内の圧縮ファイルを削除します。
        /// </summary>
        /// <param name="workPath">削除対象のディレクトリ</param>
        private static void DeleteFile(string workPath)
        {
            foreach (var file in Directory.GetFiles(workPath, "*.7z"))
            {
                File.Delete(file);
            }
            foreach (var file in Directory.GetFiles(workPath, "*.zip"))
            {
                File.Delete(file);
            }
        }
    }
}