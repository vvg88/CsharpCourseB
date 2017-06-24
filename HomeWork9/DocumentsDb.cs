using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9
{
    class DocumentsDb : DbContext
    {
        public IDbSet<Document> Documents { get; set; }
    }
}
