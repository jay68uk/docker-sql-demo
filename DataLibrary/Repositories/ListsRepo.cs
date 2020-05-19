using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Repositories
{
    public class ListsRepo
    {
        private readonly DataContext _dbContext;

        public ListsRepo(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int GetCount()
        {
            var td = _dbContext.ListText.Count();
            return td;
        }

        public List<StringItem> GetData()
        {
            return _dbContext.Database.SqlQuery<StringItem>("select table_name from information_schema.tables", null)
                .ToList<StringItem>();
        }
    }
}
