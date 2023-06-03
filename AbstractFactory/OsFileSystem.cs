using System;

namespace AbstractFactory
{
    public abstract class OsFileSystem
    {
        /// <summary>
        /// ファイルセパレーターを取得
        /// </summary>
        /// <returns></returns>
        public abstract String GetFileSeparator();

        /// <summary>
        /// ルートパスを取得
        /// </summary>
        /// <returns></returns>
        public abstract String GetRootPath();

        /// <summary>
        /// ファイルを保存
        /// </summary>
        /// <param name="fileName"></param>
        public abstract void SaveFile(string fileName);
    }
}