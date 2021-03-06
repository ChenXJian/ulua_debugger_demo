﻿using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Reflection;
using System.IO;

public class Util {

    /// <summary>
    /// 取得Lua路径
    /// </summary>
    public static string LuaPath(string name) {
        string path = Application.dataPath;
        string lowerName = name.ToLower();
        if (lowerName.EndsWith(".lua")) {
            int index = name.LastIndexOf('.');
            name = name.Substring(0, index);
        }
        name = name.Replace('.', '/');
        return path + "/uLua/lua/" + name + ".lua";
    }

    public static void Log(string str) {
        Debug.Log(str);
    }

    public static void LogWarning(string str) {
        Debug.LogWarning(str);
    }

    public static void LogError(string str) {
        Debug.LogError(str);
    }

    /// <summary>
    /// 清理内存
    /// </summary>
    public static void ClearMemory() {
        GC.Collect();
        Resources.UnloadUnusedAssets();
        LuaScriptMgr mgr = LuaScriptMgr.Instance;
        if (mgr != null && mgr.lua != null) mgr.LuaGC();
    }

    /// <summary>
    /// 防止初学者不按步骤来操作
    /// </summary>
    /// <returns></returns>
    static int CheckRuntimeFile() {
        if (!Application.isEditor) return 0;
        string sourceDir = AppConst.uLuaPath + "/Source/LuaWrap/";
        if (!Directory.Exists(sourceDir)) {
            return -2;
        } else {
            string[] files = Directory.GetFiles(sourceDir);
            if (files.Length == 0) return -2;
        }
        return 0;
    }

    /// <summary>
    /// 检查运行环境
    /// </summary>
    public static bool CheckEnvironment() {
        return true;
    }
    /// <summary>
    /// 是不是苹果平台
    /// </summary>
    /// <returns></returns>
    public static bool isApplePlatform {
        get {
            return Application.platform == RuntimePlatform.IPhonePlayer ||
                   Application.platform == RuntimePlatform.OSXEditor ||
                   Application.platform == RuntimePlatform.OSXPlayer;
        }
    }
}