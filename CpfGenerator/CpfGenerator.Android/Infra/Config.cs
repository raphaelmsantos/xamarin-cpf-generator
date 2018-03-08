using CpfGenerator.Droid.Infra;
using CpfGenerator.Interfaces;
using SQLite.Net.Interop;
using Xamarin.Forms;

[assembly: Dependency(typeof(Config))]
namespace CpfGenerator.Droid.Infra
{
    
    public class Config : IConfig
    {
        private string _SQLiteDirectory;
        private ISQLitePlatform _platform;
        public string SQLiteDirectory
        {
            get
            {
                if (string.IsNullOrEmpty(_SQLiteDirectory))
                {
                    _SQLiteDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                return _SQLiteDirectory;
            }
        }
        public ISQLitePlatform Plataforma
        {
            get
            {
                if (_platform == null)
                {
                    _platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                }
                return _platform;
            }
        }
    }
}