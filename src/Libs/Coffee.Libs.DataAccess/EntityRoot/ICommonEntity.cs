namespace Coffee.Libs.DataAccess.EntityRoot
{
	public interface ICommonEntity<T> : IDeleteEntity
	{
		T Id { get; }
		string Note { get; set; }
	}
}