using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

namespace SevenZipCompress
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                Execute(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// メイン処理
        /// </summary>
        /// <param name="args">コマンドライン引数</param>
        private static void Execute(IReadOnlyList<string> args)
        {
            // コマンドライン引数
            if (args.Count != 2)
            {
                throw new Exception("コマンドライン引数には、第1引数に圧縮ファイル、第2引数に設定ファイルを指定して下さい。");
            }

            // 圧縮ファイルの存在チェック
            // TODO ファイル、ディレクトリどっちでも動く？
            var targetFile = args[0];
            if (!File.Exists(targetFile))
            {
                throw new Exception("圧縮対象のファイルが存在しません。");
            }

            // 設定ファイルの存在チェック
            var settingFile = args[1];
            if (!File.Exists(settingFile))
            {
                throw new Exception("設定ファイルが存在しません。");
            }

            // 設定ファイル
            var file = File.ReadAllText(settingFile);
            var settings = JsonConvert.DeserializeObject<Settings>(file);

            if (!File.Exists(settings.SevenZipPath))
            {
                throw new Exception("[設定ファイル sevenZipPath] 7zipのexeが存在しません。");
            }

            if (string.IsNullOrEmpty(settings.CompressPassword))
            {
                // TODO パスワードがブランクの場合は、パスワードなしで圧縮する
                throw new Exception("[設定ファイル compressPassword] 圧縮パスワードを指定してください。");
            }

            if (string.IsNullOrEmpty(settings.FilePrefix))
            {
                // TODO FilePrefixがブランクの場合は、プリフィックスを付与しない
                throw new Exception("[設定ファイル filePrefix] ファイルに付与するプリフィックスを指定してください。");
            }
            
            // TODO 出力ファイル名
            var changeFile = "";

            // 7zipで圧縮する
            var proInfo = new ProcessStartInfo
            {
                FileName = settings.SevenZipPath,
                // 引数はコマンドプロンプトで"C:\Program Files\7-Zip\7z.exe"を実行すれば表示される。
                ArgumentList =
                {
                    "a", // a: 圧縮
                    "-y", // -y: 強制的に処理を続行
                    $"-p{settings.CompressPassword}", // -p: パスワードを設定
                    $"-o{Path.GetDirectoryName(changeFile)}", // -o: 出力先を指定
                    $"{targetFile}" // 圧縮対象のファイル
                },
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            var process = Process.Start(proInfo);
            if (process == null)
            {
                throw new Exception("7zipのexe実行に失敗しました。");
            }

            // Console.WriteLine(process.StandardOutput.ReadToEnd());

            process.WaitForExit();
            if (process.ExitCode == 0)
            {
                throw new Exception("圧縮に成功しました。");
            }
        }
    }

    /// <summary>
    /// appsettings.json
    /// </summary>
    internal abstract class Settings
    {
        /// <summary>
        /// 7-zipのインストールパス（7z.exeのパス）
        /// </summary>
        [JsonProperty("sevenZipPath")]
        public string SevenZipPath { get; set; } = "";

        /// <summary>
        /// 圧縮パスワード
        /// </summary>
        [JsonProperty("compressPassword")]
        public string CompressPassword { get; set; } = "";

        /// <summary>
        /// 圧縮したファイルの先頭に付与する文字列
        /// </summary>
        [JsonProperty("filePrefix")]
        public string FilePrefix { get; set; } = "";
    }
}