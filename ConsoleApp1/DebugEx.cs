using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ConsoleApp1
{
    /// <summary>
    /// デバッグに関する静的関数を提供します。
    /// </summary>
    public static class DebugEx
    {
        /// <summary>
        /// デバッグで出力する呼び出し元情報を取得または設定します。
        /// デフォルトでは全ての呼び出し元情報を出力します。
        /// </summary>
        public static DebugOutputCallerInfo CallerInfo { get; set; } = DebugOutputCallerInfo.MemberName | DebugOutputCallerInfo.FilePath | DebugOutputCallerInfo.LineNumber | DebugOutputCallerInfo.Time;

        /// <summary>
        /// 標準出力にデバッグメッセージを出力し、続けて終端記号を出力します。
        /// </summary>
        /// <param name="value">オブジェクト。</param>
        /// <param name="info">デバッグで出力する呼び出し元情報。</param>
        /// <param name="member">呼び出し元メンバー名。</param>
        /// <param name="filePath">呼び出し元ファイルパス。</param>
        /// <param name="lineNumber">呼び出し元行番号。</param>
        [Conditional("DEBUG")]
        public static void WriteLine(object value,
            DebugOutputCallerInfo? info = null,
            [CallerMemberName] string member = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0)
        {
            Debug.WriteLine(MakeDebugMessage(info, value.ToString(), member, filePath, lineNumber));
        }

        /// <summary>
        /// 標準出力にデバッグメッセージを出力し、続けて終端記号を出力します。
        /// </summary>
        /// <param name="message">デバッグメッセージ。</param>
        /// <param name="info">デバッグで出力する呼び出し元情報。</param>
        /// <param name="member">呼び出し元メンバー名。</param>
        /// <param name="filePath">呼び出し元ファイルパス。</param>
        /// <param name="lineNumber">呼び出し元行番号。</param>
        [Conditional("DEBUG")]
        public static void WriteLine(string message,
            DebugOutputCallerInfo? info = null,
            [CallerMemberName] string member = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0)
        {
            Debug.WriteLine(MakeDebugMessage(info, message, member, filePath, lineNumber));
        }

        /// <summary>
        /// デバッグメッセージを作成します。
        /// </summary>
        /// <param name="info">デバッグで出力する呼び出し元情報。</param>
        /// <param name="message">デバッグメッセージ。</param>
        /// <param name="member">呼び出し元メンバー名。</param>
        /// <param name="filePath">呼び出し元ファイル名。</param>
        /// <param name="lineNumber">呼び出し元行番号。</param>
        /// <returns>デバッグメッセージ。</returns>
        private static string MakeDebugMessage(DebugOutputCallerInfo? info, string message, string member, string filePath, int lineNumber)
        {
            string msg = "";

            // 出力する呼び出し元情報が指定されていない場合はプロパティを使用する
            DebugOutputCallerInfo callerInfo = info.HasValue ? info.Value : CallerInfo;

            msg += "---DEBUG------------------->>" + Environment.NewLine;
            msg += $" Message               :{message}" + Environment.NewLine;

            if (callerInfo != DebugOutputCallerInfo.None)
            {
                if ((callerInfo & DebugOutputCallerInfo.Time) == DebugOutputCallerInfo.Time)
                    msg += $" 呼び出し時間          :{DateTime.Now.ToString("hh:mm:ss.ffff")}" + Environment.NewLine;

                if ((callerInfo & DebugOutputCallerInfo.MemberName) == DebugOutputCallerInfo.MemberName)
                    msg += $" 呼び出し元メンバー名  :{member}" + Environment.NewLine;

                if ((callerInfo & DebugOutputCallerInfo.FilePath) == DebugOutputCallerInfo.FilePath)
                    msg += $" 呼び出し元ファイルパス:{filePath}" + Environment.NewLine;

                if ((callerInfo & DebugOutputCallerInfo.LineNumber) == DebugOutputCallerInfo.LineNumber)
                    msg += $" 呼び出し元行番号      :{lineNumber}" + Environment.NewLine;
            }

            msg += "<<---------------------------";

            return msg;
        }
    }
}
