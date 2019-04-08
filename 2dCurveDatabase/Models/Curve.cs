using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Rewrite.Internal.ApacheModRewrite;

namespace CurveDatabase2d.Models
{
    public class Curve : Entity
    {
        public string Formula { get; set; }
    }
}
