@echo off
echo folder_path %1%
set folder_path=%1%

echo key_path %2%
set key_path=%2%

echo key_alias %3%
set key_alias=%3%

echo key_pass %4%
set key_pass=%4%

echo apk_name %5%
set apk_name=%5%


cd c:\Program Files\Java\jdk1.8.0_221\bin
echo %key_pass%|jarsigner -verbose -sigalg SHA1withRSA -digestalg SHA1 -keystore %key_path% %folder_path%\platforms\android\app\build\outputs\apk\release\app-release-unsigned.apk %key_alias%

c:\Unity\SDK\Sdk\build-tools\28.0.3\zipalign -v 4 %folder_path%\platforms\android\app\build\outputs\apk\release\app-release-unsigned.apk c:\Unity\Projects\ReleaseAPK\%apk_name%.apk

set /p par3=