using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModels
{
    public class DtoToDoItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int UserID { get; set; }

        public virtual DtoUser User { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool Completed { get; set; }
    }
}
