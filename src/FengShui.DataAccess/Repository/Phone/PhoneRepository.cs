using Coffee.Libs.DataAccess.Repository;
using FengShui.DataAccess.DbContext;
using FengShui.DataAccess.Entities;

namespace Snp.TosFix.DataAccess.Repository
{
    public class PhoneRepository : BaseRepository<Phone>, IPhoneRepository
	{
		public PhoneRepository(FengShuiDbContext context) : base(context)
		{
		}
	}
}
