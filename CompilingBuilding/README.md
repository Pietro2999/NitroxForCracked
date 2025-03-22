# Build installation requirements

First step is to check which Subnautica store version you have (Steam, Epic Game and so on...) \
**If you are on this repo you have most likely a Windows cracked Steam version of the game. If you have another one, I cannot guarantee you will be able to build this project yourself.**

Second step is to install Visual Studio 2017 or later and .NET 9.0 SDK.

## Building instruction

You have to put a file in your `<SteamInstallationDir>\steamapps` directory called `appmanifest_264710.acf` with content and put your game in the same installation directory as other Steam games.
```
"AppState"
{
	"appid"		"264710"
	"name"		"Subnautica"
	"installdir"		"Subnautica"
}
```

You should be able to build the project like a normal project in Visual Studio