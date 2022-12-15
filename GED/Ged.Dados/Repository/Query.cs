using Ged.Interfaces.Repository;

namespace Ged.Dados.Repository
{
    public class Query<T> : IQuery
    {
        public string SelectQuery() => $"SELECT * FROM {typeof(T).Name}";

        public string SelectQuery(object param, string orderBy = "") => $"SELECT * FROM {typeof(T).Name} WHERE {Query<T>.GetWhere(param)} {orderBy}";

        private static string GetWhere(object param)
        {
            string where = "1 = 1";
            foreach (var p in param.GetType().GetProperties())
                where += $" AND {p.Name} = :{p.Name}";
            return where;
        }

        public string SelectQuerySequence() => $"SELECT {typeof(T).Name}_seq.nextval FROM DUAL";

        public string InsertQueryReturnInserted()
        {
            string insert = $"INSERT INTO {typeof(T).Name} (";
            string values = $"VALUES(";
            foreach (var prop in typeof(T).GetProperties())
            {
                insert += $"{prop.Name},";
                values += $":{prop.Name},";
            }
            return $"{insert.TrimEnd(',')}) {values.TrimEnd(',')})";
        }

        public string UpdateByIdQuery()
        {
            string update = $"UPDATE {typeof(T).Name} SET ";
            foreach (var prop in typeof(T).GetProperties())
            {
                update += $"{prop.Name} = :{prop.Name},";
            }
            return update.Remove(update.Length - 1, 1) + " WHERE Id = :Id";
        }
    }
}
