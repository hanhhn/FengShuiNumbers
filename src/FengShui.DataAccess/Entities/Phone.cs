using Coffee.Libs.DataAccess.EntityRoot;

namespace FengShui.DataAccess.Entities
{
    public class Phone : BaseEntity<int>
    {
        public string Number { get; set; }
        public string Network { get; set; } //viettel,mobile...
    }
}
