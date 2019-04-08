using System;
using System.ComponentModel.DataAnnotations;

namespace CurveDatabase2d.Models
{
    public class Entity
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Added { get; set; }

        public int AddedUserId { get; set; }
    }
}
