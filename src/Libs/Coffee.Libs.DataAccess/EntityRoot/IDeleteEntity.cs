namespace Coffee.Libs.DataAccess.EntityRoot
{
	public interface IDeleteEntity
	{
		bool IsDeleted { get; }
		void Delete();
		void UnDelete();
	}
}