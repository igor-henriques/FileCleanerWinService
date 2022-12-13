# FileCleanerWinService

To register as a windows service, open a CMD in admin mode: 
```
sc.exe create "SERVICE_NAME" binPath="PATH_TO_RELEASE_EXE"
```

To configure the service:
```
sc.exe failure "SERVICE_NAME" reset=0 actions=restart/60000/restart/60000/run/1000
```
This way, you're configuring to try running again twice with a 60 seconds delay between each try, and the last argument is about the frequency the service will run, in the case above, each 1000ms.