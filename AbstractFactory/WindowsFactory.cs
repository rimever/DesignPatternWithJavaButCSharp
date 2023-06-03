namespace AbstractFactory
{
    public class WindowsFactory : OsFactory
    {
        public override OsFileSystem CreateFileSystem()
        {
            return new WindowsFileSystem();
        }

        public override OsDisplaySystem CreateDisplaySystem()
        {
            return new WindowsDisplaySystem();
        }
    }
}