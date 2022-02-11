using System;

namespace ConsoleApp1
{
    /// <summary>
    /// デバッグで出力する呼び出し元情報を指定します。
    /// </summary>
    [Flags]
    public enum DebugOutputCallerInfo : byte
    {
        /// <summary>
        /// 呼び出し元の情報は無しです。
        /// </summary>
        None = 0x00,
        /// <summary>
        /// 呼び出し元情報はメンバー名です。
        /// </summary>
        MemberName = 0x01,
        /// <summary>
        /// 呼び出し元情報はファイル名です。
        /// </summary>
        FilePath = 0x02,
        /// <summary>
        /// 呼び出し元情報は行番号です。
        /// </summary>
        LineNumber = 0x04,
        /// <summary>
        /// 呼び出し元情報は時間です。
        /// </summary>
        Time = 0x08
    }
}
