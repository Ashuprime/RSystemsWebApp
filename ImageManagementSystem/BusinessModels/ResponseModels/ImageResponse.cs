using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels.ResponseModels
{
    public class ImageResponse
    {
        public int Id { get; set; }
        public string User { get; set; }
        public DateTime DateCreated { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
    }
}
