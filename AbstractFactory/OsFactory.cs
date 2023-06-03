using System;

namespace AbstractFactory
{
    public abstract class OsFactory
    {
        public static OsFactory GetFactory(string className)
        {
            OsFactory factory = null;
            try
            {
                var type = Type.GetType(className);
                factory = Activator.CreateInstance(type) as OsFactory;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return factory;
        }

        /// <summary>
        /// FileSystem生成用メソッド
        /// </summary>
        /// <returns></returns>
        public abstract OsFileSystem CreateFileSystem();

        /// <summary>
        /// DisplaySystem生成用メソッド
        /// </summary>
        /// <returns></returns>
        public abstract OsDisplaySystem CreateDisplaySystem();
    }
}