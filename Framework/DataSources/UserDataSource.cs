namespace Framework.DataSources
{
    public class UserDataSource<T> : BaseDataSource<T>
    {
        protected override string BaseSection => "UsersData";
    }
}
