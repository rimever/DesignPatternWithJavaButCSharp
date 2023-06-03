namespace AbstractFactory
{
    public class LinuxFactory : OsFactory
    {
        public override OsFileSystem CreateFileSystem()
        {
            return new LinuxFileSystem();
        }

        public override OsDisplaySystem CreateDisplaySystem()
        {
            return new LinuxDisplaySystem();
        }
    }
}