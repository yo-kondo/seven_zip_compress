@echo off

REM 7zip�ň��k����
REM ����bat�t�@�C���Ƀf�B���N�g���A�t�@�C�����h���b�O���h���b�v�����OK

REM �J�����g�f�B���N�g����bat�t�@�C���̃f�B���N�g���ɕύX
cd /d %~dp0

SevenZipCompress.exe %1 appsettings.json
pause
