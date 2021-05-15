
@cls
@echo off

@echo Creating Enum
codesmithconsole.exe /out:"..\Model\Enumeration.Generated.cs" /t:"C:\Dev\C#\Framework\NewEnum\GenerateEnum.cst" /p:"Framework.xml" /nologo
codesmithconsole.exe /out:"..\Web\Scripts\Enumeration.Generated.js" /t:"C:\Dev\C#\Framework\NewEnumJs\GenerateEnum.cst" /p:"Framework.xml" /nologo

@echo Done
pause