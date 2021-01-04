using System;
using System.IO;
using NUnit.Framework;
using SevenZipCompress;

namespace SevenZipCompressTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// ファイルを圧縮
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
        /// ディレクトリを圧縮
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
        /// 指定されたディレクトリ内の「*.7z」ファイルを削除します。
        /// </summary>
        /// <param name="workPath">削除対象のディレクトリ</param>
        private static void DeleteFile(string workPath)
        {
            foreach (var file in Directory.GetFiles(workPath, "*.7z"))
            {
                File.Delete(file);
            }
        }
    }
}