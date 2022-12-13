# FileCleanerWinService

To register as a windows service: 
```
sc create SERVICE_NAME binPath="PATH_TO_RELEASE_EXE"
```

alternatively, is possible to reference the .dll, instead the .exe:
```
sc.exe create "SERVICE_NAME" binpath="PATH_TO_RELEASE_DLL"
```