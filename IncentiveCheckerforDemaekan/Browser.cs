﻿using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace IncentiveCheckerforDemaekan
{
    /// <summary>
    /// ブラウザ系処理クラス
    /// </summary>
    public class Browser
    {
        /// <summary>
        /// インストールされているブラウザ名を取得する
        /// </summary>
        /// <returns>ブラウザ名</returns>
        public static List<string> GetInstallBrowser()
        {
            var browsers = new List<string>();
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                RegistryKey? browserKeys = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Clients\StartMenuInternet");
                if (browserKeys == null)
                {
                    // 上記のキーでレジストリが開けない場合はHKEY_LOCAL_MACHINE\SOFTWARE\Clients\StartMenuInternetを開く
                    browserKeys = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Clients\StartMenuInternet");
                }
                if((browserKeys == null)) { return browsers; }
                var subKeyNames = browserKeys.GetSubKeyNames();
                foreach (var browser in subKeyNames)
                {
                    // ブラウザーの名前
                    RegistryKey? browserKey = browserKeys.OpenSubKey(browser);
                    if(browserKey == null) { return browsers; }
                    var browserName = browserKey.GetValue(null);
                    if (browserName == null) { return browsers; }
                    browsers.Add((string)browserName);
                }
            }
            return browsers;
        }

        /// <summary>
        /// WindowsOSでChoromeをインストールする
        /// </summary>
        /// <param name="filePath"></param>
        public static void InstallChromeWindows(string filePath)
        {
            using var file = new File();
            file.ExcuteFile("/c " + filePath, false, false, true);
        }
    }
}
