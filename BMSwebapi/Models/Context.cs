using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BMSwebapi.Models
{
    public class Context:DbContext
    {
            public Context() : base("name=cs") { }
            public DbSet<Account> Accounts { get; set; }
            public DbSet<TransactionDetail> TransactionDetails { get; set; }
            public DbSet<PassBook> PassBooks { get; set; }

        }
    }

