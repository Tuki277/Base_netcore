using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_base.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CategoryNonIdDto
    {
        public string Name { get; set; }
    }
}