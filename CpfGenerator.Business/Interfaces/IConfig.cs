namespace CpfGenerator.Business.Interfaces
{
    public interface IConfig
    {
        string SQLiteDirectory { get; }
        ISQLITEPLATFORM Plataforma { get; }
    }
}
