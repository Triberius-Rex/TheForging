# [The Forging runs on ServUO]


[![GitHub](https://img.shields.io/github/license/servuo/servuo.svg?color=a)](https://github.com/ServUO/ServUO/blob/master/LICENSE)


The Forging GIT is a the codebase for much of The Forging Server.  This allows collabrative work, and a backup codebase in the event of a catastrophic failure of the hardware the server is running on.  

[ServUO] is a community driven Ultima Online Server Emulator written in C#.


#### Requirements

[.NET 5.0] Runtime and SDK


#### Windows

Run `Compile.WIN - Debug.bat` for development environments.
Run `Compile.WIN - Release.bat` for production environments.


#### OSX
```
brew install mono
brew install dotnet
dotnet build
```
To run `mono ServUO.exe`


#### Ubuntu / Debian
```
apt-get install zlib1g-dev mono-complete dotnet-sdk-5.0 
dotnet build
```
To run `mono ServUO.exe`


#### Summary

1. Starting with the `/Config` directory, find and edit `Server.cfg` to set up the essentials.
2. Go through the remaining `*.cfg` files to ensure they suit your needs.
3. For Windows, run `Compile.WIN - Debug.bat` to produce `ServUO.exe`, Linux users may run `Makefile`.
4. Run `ServUO.exe` to make sure everything boots up, if everything went well, you should see your IP adress being listened on the port you specified.
5. Load up UO and login! - If you require instructions on setting up your particular client, visit the Discord and ask!

   [ServUO]: <https://www.servuo.com>
   [.NET 5.0]: <https://dotnet.microsoft.com/download>
