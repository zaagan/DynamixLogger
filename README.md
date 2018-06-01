# DynamixLogger
A lightweight hackable logger for C# applications.

The project consists of the DynamixLogger library along with a sample application showing some usage of the library. 



## Framework

- NET Framework 4.5 +



## Installation

#### Using Package Manager

```bash
Install-Package DynamixLogger -Version 1.0.0
```

#### Using .NET CLI

```bash
dotnet add package DynamixLogger --version 1.0.0
```



## Basic Usage

If you have not configured the FileLogInfo properly, The library will dump the log files to the root of the application by default.

```c#
using DynamixLogger;
using DynamixLogger.Info;
using DynamixLogger.LogStrategy;
using DynamixLogger.Utilities;

private void Method1()
{
    FileLogInfo logInfo = new FileLogInfo();
    logInfo.LogMessage = "Just a basic file logging";
    
    FileLogger<FileLogInfo> fileLogger = new FileLogger<FileLogInfo>();
    fileLogger.Write(logInfo);
}
```



## Using Class Inheritance

The library comes with a default Controller class called **DynamixDefaultController**.

The Default Log Controller is configured such that it auto locates a drive with at least 5 GB of minimum space and dumps the log there in a folder named **DynamixExLogs**.



**Default Folder Name :** DynamixExLogs

**Default File Format Sample :** Dynamix-2018-05-31.log



You can however, create your own custom Class and use it instead.

A practical example is as follows:

```c#
using DynamixLogger;

public class YourAwesomeController : DynamixDefaultController
{
    // BASIC LOGGING
    public void DoSomething()
    {
        LogMessage("Your-Message-Goes-Here");
    }
    
    // EXCEPTION LOGGING
    public void LetsLogSomeException()
    {
        try
        {
            throw new Exception("Oops !! I did it again.");
        }
        catch (System.Exception ex)
        {
            LogMessage(ex);
        }
    }
    
}
```



## Using Dependency Injection

Sample dependency injection snippet using Ninject

##### Instantiation :

```c#
NinjectHandler ninjectHandler = new NinjectHandler();
ILogStrategy<FileLogInfo> iLogStrategy = ninjectHandler.Get<ILogStrategy<FileLogInfo>>();

// You can configure the FileLogInfo instance as per your need
FileLogInfo fileLogInfo = DynamixDefaultController.DefaultFileLogInfo(); 
```



##### Exception Logging :

```c#
// FOR EXCEPTION LOGGING
fileLogInfo.LogType = LogType.Exception;
fileLogInfo.LogLevel = LogLevel.EXCEPTION;
fileLogInfo.Exception = new Exception("I forgot to bring my homework");

// LOG EXCEPTION
LogWriter<FileLogInfo>.Write(iLogStrategy, fileLogInfo);
```



##### Message Logging :

```c#
// FOR MESSAGE LOGGING
fileLogInfo.LogType = LogType.Message;
fileLogInfo.LogLevel = LogLevel.INFO;
fileLogInfo.LogMessage = "Did i just log something stupid !!##??";

// LOG MESSAGE
LogWriter<FileLogInfo>.Write(iLogStrategy, fileLogInfo);
```





## Exploring the FileLogInfo



```c#
FileLogInfo fileLogInfo = new FileLogInfo();
fileLogInfo.FilePath = FilePaths.ChooseADrive(FileUtils.SpaceLimit, true).Name;
fileLogInfo.DedicatedFolder = true;
fileLogInfo.FolderName = Execution_LogFolderName;
fileLogInfo.FileName = GenerateLogFileName();
fileLogInfo.Presentation = Presentation.FULL_DETAIL;
fileLogInfo.LogType = LogType.Exception | LogType.Message;
fileLogInfo.LogLevel = LogLevel.EXCEPTION;

// IN CASE OF EXCEPTION
fileLogInfo.Exception = new Exception("...");

// IN CASE OF NORMAL MESSAGE
fileLogInfo.LogMessage = "";
```



**FilePath :** The directory you wish to dump the log files to.

**DedicatedFolder :** (true) If you want the logger to use a dedicated folder for logging.

**FolderName :** The name of the folder

**FileName :** The name of the log file

**Presentation :** The level of detail you wish to expose to the log file .

```
Presentation Types: LOG__ONLY, LOG_WITH_SEVERITY,  FULL_DETAIL
```

**LogType :** Message, Exception

**LogLevel :**  INFO = 1, WARNING = 2, ERROR = 3, EXCEPTION = 4, DEBUG = 0





## Log Strategies 

| Type              | Data         | Description                                | Info Class Type |
| ----------------- | ------------ | ------------------------------------------ | --------------- |
| FileLogger        | File         | Logs to File                               | FileLogInfo     |
| SqlDbLogger       | DB           | Log To SQL Server (Stored Procedure Based) | SqlLogInfo      |
| DiagnosticsLogger | Event Viewer | Log To The System Trace                    | BaseLogInfo     |



## Things To Do

- [ ] Implement Logging To Event Viewer 
- [ ] Implement SqlDbLogger (Incomplete)
- [ ] Concurrent file logging handling
- [ ] Log To Other Data Sources (MongoDB, PostgreSQL etc.)
- [ ] Asynchronous Logging





## Platform

- Windows

