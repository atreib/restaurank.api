namespace restaurank.api.Infra.Db.SqlServer
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository (AppDbContext context) {
            _context = context;
        }
    }
}