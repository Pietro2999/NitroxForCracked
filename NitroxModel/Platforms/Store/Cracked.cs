using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using NitroxModel.Discovery.Models;
using NitroxModel.Helper;
using NitroxModel.Platforms.OS.Shared;
using NitroxModel.Platforms.Store.Interfaces;

namespace NitroxModel.Platforms.Store {

    public sealed class Cracked : IGamePlatform {


        private static Cracked instance;
        public static Cracked Instance => instance ??= new Cracked();

        public string Name => "Cracked";
        public Platform Platform => Platform.STEAM;

        public bool OwnsGame(string gameRootPath) =>
            gameRootPath switch
            {
                not null when RuntimeInformation.IsOSPlatform(OSPlatform.OSX) => Directory.Exists(Path.Combine(gameRootPath, "Plugins", "steam_api.bundle")),
                not null when File.Exists(Path.Combine(gameRootPath, GameInfo.Subnautica.DataFolder, "Plugins", "x86_64", "steam_api64.dll")) => true,
                not null when (File.Exists(Path.Combine(gameRootPath, GameInfo.Subnautica.DataFolder, "Plugins", "steam_api64.dll")) 
                    && new FileInfo(Path.Combine(gameRootPath, "steam_api64.dll")).Length >= 209000)  => true,
                _ => false
            };
        

        public async Task<ProcessEx> StartPlatformAsync()
        {
            await Task.CompletedTask; // Suppresses async-without-await warning - can be removed.
            throw new NotImplementedException(); // Not necessary to implement unless EGS gets a game SDK and respective game integrates it.
        }

        public string GetExeFile()
        {
            throw new NotImplementedException();
        }

        public async Task<ProcessEx> StartGameAsync(string pathToGameExe, string launchArguments)
        {
            // Normally should call StartPlatformAsync first. But Subnautica will start without EGS.
            return await Task.FromResult(
                ProcessEx.Start(
                    pathToGameExe,
                    new[] { (NitroxUser.LAUNCHER_PATH_ENV_KEY, NitroxUser.LauncherPath) },
                    Path.GetDirectoryName(pathToGameExe),"")
                );
        }
    }
}
