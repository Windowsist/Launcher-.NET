# ProcessTools

## Launcher

start process according to configuration file(xml file)

this is an example:

``` xml
<?xml version="1.0" encoding="utf-8"?>
<Launcher xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <WorkingDirectory>%LauncherDir%</WorkingDirectory>
  <FileName>%SystemRoot%\system32\cmd.exe</FileName>
  <UseShellExecute>false</UseShellExecute>
</Launcher>
```

this is an default value:

``` xml
<?xml version="1.0" encoding="utf-8"?>
<Launcher xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <ErrorDialog>false</ErrorDialog>
  <WorkingDirectory />
  <FileName />
  <LoadUserProfile>false</LoadUserProfile>
  <Domain />
  <UserName />
  <UseShellExecute>true</UseShellExecute>
  <RedirectStandardError>false</RedirectStandardError>
  <RedirectStandardOutput>false</RedirectStandardOutput>
  <RedirectStandardInput>false</RedirectStandardInput>
  <CreateNoWindow>false</CreateNoWindow>
  <Arguments />
  <Verb />
  <WindowStyle>Normal</WindowStyle>
</Launcher>
```
