using SQLite.Net.Interop;

namespace CpfGenerator.Interfaces
{
    public interface IConfig
    {
        string SQLiteDirectory { get; }
        ISQLitePlatform Plataforma { get; }
    }
}
