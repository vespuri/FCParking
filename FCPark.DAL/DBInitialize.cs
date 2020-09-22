using System;
using System.Collections.Generic;
using System.Text;

namespace FCPark.DAL
{
    public class DBInitialize
    {
        private readonly FCParkDbContext _context;
        public DBInitialize(FCParkDbContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            _context.Database.EnsureCreated();
        }
    }
}

