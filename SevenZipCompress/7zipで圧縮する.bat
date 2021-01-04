@echo off

REM 7zipで圧縮する
REM このbatファイルにディレクトリ、ファイルをドラッグ＆ドロップすればOK

REM カレントディレクトリをbatファイルのディレクトリに変更
cd /d %~dp0

SevenZipCompress.exe %1 appsettings.json
echo 処理結果 = %ERRORLEVEL%
pause
