using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Domain
{
    public class EntityWithComplexId
    {
        public virtual ComplexId Id { get; set; }

        public virtual string Property1 { get; set; }
        public virtual string Property2 { get; set; }
    }

    public class ComplexId
    {
        public bool Equals(ComplexId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Id1, Id1) && other.Id2.Equals(Id2) && other.Id3 == Id3;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (ComplexId)) return false;
            return Equals((ComplexId) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (Id1 != null ? Id1.GetHashCode() : 0);
                result = (result*397) ^ Id2.GetHashCode();
                result = (result*397) ^ Id3;
                return result;
            }
        }

        public virtual string Id1 { get; set; }
        public virtual Guid Id2 { get; set; }
        public virtual int Id3 { get; set; }
    }
}
