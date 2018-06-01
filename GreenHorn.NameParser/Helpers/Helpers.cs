using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GreenHorn.NameParser.Helpers
{
    public class Helper
    {
        /// <summary>
        /// Check if string is in a Camel-Case format.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool IsCamelCase(string word) => (new Regex("[A-Z]+").IsMatch(word) && new Regex("[a-z]+").IsMatch(word));

        /// <summary>
        /// Check if string is an inital in a name.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool IsAnInitial(string word) => (RemoveIgnoredCharacters(word).Length == 1);

        /// <summary>
        /// Remove Characters from string that should be ignored.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public string RemoveIgnoredCharacters(string word) => word.Replace(".", string.Empty);

        /// <summary>
        /// Correct Letter-Word Case
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public string FixCase(string word)
        {
            // uppercase words split by dashes, like "Kimura-Fay"
            word = SafeUcFirst('-', word);
            // uppercase words split by periods, like "J.P."
            word = SafeUcFirst('.', word);
            return word;
        }

        // helper for this.FixCase
        // uppercase words split by the seperator (ex. dashes or periods)
        public string SafeUcFirst(char seperator, string word)
        {
            if (string.IsNullOrEmpty(word) || string.IsNullOrWhiteSpace(word)) return word;

            var words = word.Trim().Split(seperator).Where(x => x!=string.Empty).ToArray();
            var newWord = new StringBuilder();
            foreach (var thisWord in words)
            {
                if (newWord.Length > 0) newWord.Append(seperator);
                if (IsCamelCase(thisWord))
                {
                    newWord.Append(thisWord);
                }
                else
                {
                    newWord.Append(thisWord.Substring(0, 1).ToUpper() + thisWord.Substring(1).ToLower());
                }
            }
            return newWord.ToString();
        }
    }
}
