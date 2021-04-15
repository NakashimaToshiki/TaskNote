using System;

namespace TaskNote
{
    /// <summary>
    /// バージョン取得するプロパティを定義します。
    /// </summary>
    public interface IVersion
    {
        int Major { get; }

        int Minor { get; }

        int Build { get; }

        int Revision { get; }

        string AppName { get; }
    }

    /// <summary>
    /// <see cref="IVersion"/>の拡張メソッドを提供します。
    /// </summary>
    public static class VersionExtentions
    {

        /// <summary>
        /// 文字列のバージョン情報を取得
        /// </summary>
        /// <param name="me"></param>
        /// <returns></returns>
        public static string GetVersionName(this IVersion me)
        {
            return $"{me.Major}.{me.Minor}.{me.Build}.{me.Revision}";
        }

        /// <summary>
        /// 文字列型と数値型のバージョンが一致しているか比較する
        /// </summary>
        public static bool IsMatchVersion(this IVersion me, string versionName)
        {
            if (string.IsNullOrEmpty(versionName)) return false;
            var settingVersions = ParseVersion(versionName.Split('.'));

            if (settingVersions[0] != me.Major) return false;
            if (settingVersions[1] != me.Minor) return false;
            if (settingVersions[2] != me.Build) return false;
            if (settingVersions[3] != me.Revision) return false;

            return true;
        }

        /// <summary>
        /// バージョン情報をstring型の配列からint型に変換する。
        /// </summary>
        public static int[] ParseVersion(string[] versionStrs)
        {
            int[] rets = new int[4];
            if (versionStrs.Length != 4) throw new Exception("バージョン番号が４つでない。");
            if (!int.TryParse(versionStrs[0], out rets[0])) throw new Exception("１つ目の文字を整数に変換できません。");
            if (!int.TryParse(versionStrs[1], out rets[1])) throw new Exception("１つ目の文字を整数に変換できません。");
            if (!int.TryParse(versionStrs[2], out rets[2])) throw new Exception("１つ目の文字を整数に変換できません。");
            if (!int.TryParse(versionStrs[3], out rets[3])) throw new Exception("１つ目の文字を整数に変換できません。");

            return rets;
        }
    }
}
