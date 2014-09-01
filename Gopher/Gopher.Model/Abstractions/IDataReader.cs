namespace SwankSpank.Domain.Abstractions
{
    public interface IDataReader
    {
        object this[int index]
        {
            get;
        }

        bool Read();
        string GetString(string name);
        int GetInt32(string name);
    }
}