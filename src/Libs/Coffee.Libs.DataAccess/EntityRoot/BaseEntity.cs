using System;
using System.ComponentModel;

namespace Coffee.Libs.DataAccess.EntityRoot
{
	public class BaseEntity<T> : IEntityRoot, IChangeableEntity, ICommonEntity<T>
	{
		public T Id { get; set; }
		public bool IsDeleted { get; private set; }
		public DateTime CreatedDate { get; private set; }
		public string CreatedBy { get; private set; }
		public DateTime? ModifiedDate { get; private set; }
		public string ModifiedBy { get; private set; }
		public string UpdatedToken { get; private set; }
		public string Note { get; set; }

		public BaseEntity()
		{
			if (typeof(T).ToString() == typeof(string).ToString())
			{
				TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
				Id = (T)converter.ConvertFromInvariantString(Guid.NewGuid().ToString());
			}
		}

		public virtual void Default(string identity, bool isAdd = true)
		{
			DateTime date = DateTime.Now;
			if (isAdd)
			{
				CreatedDate = date;
				CreatedBy = identity;
				UpdatedToken = Guid.NewGuid().ToString();
			}
			else
			{
				ModifiedDate = date;
				ModifiedBy = identity;
				UpdatedToken = Guid.NewGuid().ToString();
			}
		}

		public virtual void Delete()
		{
			IsDeleted = true;
		}

		public virtual void UnDelete()
		{
			IsDeleted = false;
		}
	}
}