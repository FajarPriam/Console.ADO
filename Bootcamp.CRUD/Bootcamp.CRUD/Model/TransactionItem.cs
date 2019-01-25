using Bootcamp.CRUD.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.CRUD.Model
{
    public class TransactionItem : BaseModel
    {
        public int Quantity { get; set; }
        public virtual Item Items { get; set; }
        public virtual Transaction Transaction { get; set; }
    }
}
