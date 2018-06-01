using GreenHorn.NameParser.Helpers;
using GreenHorn.NameParser.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GreenHorn.NameParser
{
    public class NameParser
    {
        public const string E = "";
        public const string SPACE = " ";

        /// <summary>
        /// Name string passed in by requestor.
        /// </summary>
        public string NameToParse { get; set; } = string.Empty;
        /// <summary>
        /// The total count of each name part from NameToParse.
        /// </summary>
        public Int32 Length { get; set; } = 0;
        /// <summary>
        /// Name components configuration. Add and Remove element as needed.
        /// </summary>
        public Configuration NameConfiguration = new Configuration();
        private readonly Helper _helper;
        
        /// <summary>
        /// Constructor
        /// </summary>
        public NameParser()
        {
            _helper = new Helper();
        }
        
        /// <summary>
        /// Parse name string into name parts.
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        public Name Parse(string fullName)
        {
            NameToParse = string.IsNullOrEmpty(fullName)? throw new ArgumentNullException(nameof(fullName)): fullName;

            List<string> nameParts = fullName.Split(' ').Where(w => !w.StartsWith("(")).ToList();
            Length = nameParts.Count();

            string lastName  = E;
            string firstName = E;
            string initials  = E;
            string prefix    = E;
            string suffix    = E;
            
            //identify name as an organization.
            if (nameParts.Any(x => NameConfiguration.BusinessIndicator.Contains(x.ToLower())))
            {
                return new Name()
                {
                    Prefix = prefix,
                    First = fullName.Trim(),
                    Middle = initials,
                    Last = lastName,
                    Suffix = suffix,
                    IsOrganization = true
                };
            }

            prefix = nameParts.FirstOrDefault(x => NameConfiguration.Prefix.Contains(x))??string.Empty;
            suffix = string.Join(SPACE, nameParts.Intersect(NameConfiguration.Suffix, StringComparer.OrdinalIgnoreCase).ToArray());

            string[] RemainingNameParts = nameParts.Where(x => !NameConfiguration.Suffix.Contains(x) && !NameConfiguration.Prefix.Contains(x)).ToArray();
           
            int start = 0;
            int end = RemainingNameParts.Length;

            string word = RemainingNameParts[start];
            // if we start off with an initial, we'll call it the first name
            if (_helper.IsAnInitial(word))
            {
                // if so, do a look-ahead to see if they go by their middle name 
                // for ex: "R. Jason Smith" => "Jason Smith" & "R." is stored as an initial
                // but "R. J. Smith" => "R. Smith" and "J." is stored as an initial
                if (_helper.IsAnInitial(RemainingNameParts[start + 1]))
                {
                    firstName +=  word.ToUpper();
                }
                else
                {
                    initials +=  word.ToUpper();
                }
            }
            else
            {

                firstName += _helper.FixCase(word);
            }
            int i = 0;
            // concat the first name
            for (i = start + 1; i < (end - 1); i++)
            {
                word = RemainingNameParts[i];
                // move on to parsing the last name if we find an indicator of a compound last name (Von, Van, etc)
                // we do not check earlier to allow for rare cases where an indicator is actually the first name (like "Von Fabella")
                if (NameConfiguration.CompoundName.
                    Any(x => x.Equals(word.ToLower(), StringComparison.OrdinalIgnoreCase))) break;

                if (_helper.IsAnInitial(word))
                {
                    initials += word.ToUpper();
                }
                else
                {
                    firstName += _helper.FixCase(word);
                }
            }

            // check that we have more than 1 word in our string
            //Combine remaining "last name" word sections.
            if ((end - start) > 1)
            {
                // concat the last name
                var j = 0;
                for (j = i; j < end; j++)
                {
                    lastName += SPACE + RemainingNameParts[j];
                }
                lastName = lastName.Trim();
            }
            
            return new Name()
            {
                Prefix = prefix,
                First = firstName,
                Middle = initials,
                Last = lastName,
                Suffix = suffix,
                IsOrganization = false
            };
        }
    }
}
