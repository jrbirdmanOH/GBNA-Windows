::@ECHO OFF
:: eViewerPostBuild.bat 
:: Embeds manifest file and digitally signs the assembly
:: MANIFEST_RESOURCE_ID value should be 1 for .exe and 2 for .dll

:: Tildes strip the quotes off the parameters
SET SDK_PATH=%~1
SET SOLUTION_DIR=%~2
SET PROJECT_DIR=%~3
SET PROJECT_NAME=%~4
SET OUT_DIR=%~5
SET TARGET_FILE_NAME=%~6
SET MANIFEST_RESOURCE_ID=%7
SET TARGET_DIR=%PROJECT_DIR%%OUT_DIR%
SET SDK_BIN_DIR=%SDK_PATH%bin\x86\

::ECHO SDKPath is %SDK_PATH%
::ECHO OutDir is %OUT_DIR%
::ECHO TargetDir is %TARGET_DIR%
::ECHO TargetFileName is %TARGET_FILE_NAME%
::ECHO ProjectDir is %PROJECT_DIR%
::ECHO SdkBinDir is %SDK_BIN_DIR%
::ECHO "%SDK_BIN_DIR%mt.exe" -manifest "%PROJECT_DIR%%PROJECT_NAME%.manifest" -outputresource:"%TARGET_DIR%%TARGET_FILE_NAME%";#%MANIFEST_RESOURCE_ID%

:: Embed the manifest file
"%SDK_BIN_DIR%mt.exe" -manifest "%PROJECT_DIR%%PROJECT_NAME%.manifest" -outputresource:"%TARGET_DIR%%TARGET_FILE_NAME%";#%MANIFEST_RESOURCE_ID%
IF ERRORLEVEL 1 EXIT 1

:: Digitally sign the assembly with the certificate
"%SDK_BIN_DIR%signtool.exe" sign /a /tr http://rfc3161timestamp.globalsign.com/advanced /td SHA256 "%TARGET_DIR%%TARGET_FILE_NAME%"
IF ERRORLEVEL 1 EXIT 1

EXIT 0