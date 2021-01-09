# seven_zip_compress

7zipで圧縮します。

## 使い方

`7zipで圧縮する.bat`に圧縮したいファイルをドラッグ＆ドロップします。  
パスワードなど圧縮する際の設定情報はコマンドライン引数で指定して下さい。

## 前提条件

実行するPCに`7-Zip`がインストールされていること。

## 設定

``` json
{
    "sevenZipPath": "C:\\Program Files\\7-Zip\\7z.exe",
    "compressPassword": "password1",
    "filePrefix": "Prefix"
    "extension": ".zip"
}
```

* sevenZipPath  
  7-zipのインストールパス（7z.exeのパス）を指定して下さい。
* compressPassword  
  圧縮パスワードを指定して下さい。
* filePrefix  
  圧縮したファイルの先頭に付与する文字列を指定してください。
* extension  
  圧縮するタイプの拡張子を指定してください。`.zip`、`.7z`は動作確認済です。

設定ファイルのパスは、実行ファイルのコマンドライン引数で指定して下さい。

## バージョン

* 7-Zip 19.00 (x64)
