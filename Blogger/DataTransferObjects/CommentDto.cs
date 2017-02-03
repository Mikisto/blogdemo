using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class CommentDto
    {
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Body { get; set; }
    }
}
