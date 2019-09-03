using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//-----------------
using System.ComponentModel.DataAnnotations; // Key için ekledik

namespace Sy.Core.Abstracts
{
    public abstract class BaseEntity<TKey> :AuditBase, IEntity<TKey> // Hepsinde createddate olmasını istediğimiz için : noktadan sonra auditbasei ekledik
    {
        [Key]
        public TKey Id { get; set; }
    }
}
