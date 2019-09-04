﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sy.Core.Abstracts
{
    public abstract class AuditBase //  Bu sınıftan nesene oluşturmk istiyorum ama kalıtım almak istemiyorum
    {

        
        [StringLength(50)]
        public string CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now; // Constructer yazmaya gerek kalmadan burada eşitleme yaptık

        [StringLength(50)]
        public string UpdatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; } // Boş geçilemeyecği için ? işareti ekledik


    }
}
