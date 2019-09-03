using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//-----------------
using System.ComponentModel.DataAnnotations; // Key için ekledik

namespace Sy.Core.Abstracts
{
    public abstract class BaseEntity<TKey> : IEntity<TKey>
    {
        [Key]
        public TKey Id { get; set; }
    }
}
