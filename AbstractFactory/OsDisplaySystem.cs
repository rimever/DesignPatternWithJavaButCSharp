namespace AbstractFactory
{
    public abstract class OsDisplaySystem
    {
        /// <summary>
        /// OS名を表示します。
        /// </summary>
        public abstract void DisplayOsName();

        /// <summary>
        /// 文字列を表示します。
        /// </summary>
        /// <param name="str"></param>
        public abstract void DisplayString(string str);
    }
}