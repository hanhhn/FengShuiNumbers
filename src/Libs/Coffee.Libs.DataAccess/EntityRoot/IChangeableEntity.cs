using System;

namespace Coffee.Libs.DataAccess.EntityRoot
{
	public interface IChangeableEntity
	{
		DateTime CreatedDate { get; }
		string CreatedBy { get; }
		DateTime? ModifiedDate { get; }
		string ModifiedBy { get; }
		string UpdatedToken { get; }
		void Default(string identity, bool isAdd = true);
	}
}