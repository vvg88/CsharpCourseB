using System.Data.Entity;

namespace HomeWorkWebApp.Models
{
    public class DocumentsDb : DbContext
    {
        public IDbSet<Document> Documents { get; set; }
    }
}
