namespace Akroma.Persistence.SQL.Model
{
    public class UncleEntity : BaseEntity
    {
        public BlockEntity Block { get; set; }
        public string Data { get; set; }
    }
}
