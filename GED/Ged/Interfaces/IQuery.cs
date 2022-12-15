namespace Ged.Interfaces
{
    public interface IQuery
    {
        string SelectQuery();
        string SelectQuery(object param, string orderBy = "");
        string SelectQuerySequence();
        string InsertQueryReturnInserted();
        string UpdateByIdQuery();
    }
}
