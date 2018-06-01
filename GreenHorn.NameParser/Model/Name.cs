using System;
using System.Linq;

namespace GreenHorn.NameParser.Model
{
    public class Name : IEquatable<Name>
    {
        public string Prefix { get; set; }
        public string First { get; set; }
        public string Middle { get; set; }
        public string Last { get; set; }
        public string Suffix { get; set; }
        public bool IsOrganization { get; set; }

        /// <summary>
        /// Check object equality.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override bool Equals(object name) => this.Equals(name as Name);

        /// <summary>
        /// Check Name equality.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Equals(Name name) => name == null ? false :
                Suffix.Equals(name.Suffix) &&
            (
                ReferenceEquals(this.Suffix, name.Suffix) ||
                Suffix != null &&
                Suffix.Equals(name.Suffix)
            ) &&
            (
                ReferenceEquals(this.First, name.First) ||
                First != null &&
                First.Equals(name.First)
            ) &&
            (
                ReferenceEquals(this.Middle, name.Middle) ||
                Middle != null &&
                Middle.Equals(name.Middle)
            ) &&
            (
                ReferenceEquals(this.Last, name.Last) ||
                Last != null &&
                Last.Equals(name.Last)
            ) &&
            (
                ReferenceEquals(this.Prefix, name.Prefix) ||
                Prefix != null &&
                Prefix.Equals(name.Prefix)
            ) &&
            (
                ReferenceEquals(this.IsOrganization, name.IsOrganization) ||
                IsOrganization.Equals(name.IsOrganization)
            );

        /// <summary>
        /// Get object has code.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Convert object to string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Join(" ", new[] { Prefix??string.Empty, First??string.Empty, Middle??string.Empty, Last??string.Empty, Suffix??string.Empty}.Where(x => x != null).ToArray());
        }
    }
}
