using System;
using System.Collections.Generic;
using System.Text;

namespace SGF.Domain.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}
