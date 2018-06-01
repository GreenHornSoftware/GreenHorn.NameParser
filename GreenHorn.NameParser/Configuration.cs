using System.Collections.Generic;

namespace GreenHorn.NameParser
{
    public class Configuration
    {
        public const string MR_KEY = "Mr.";
        public const string MRS_KEY = "Mrs.";
        public const string MS_KEY = "Ms.";
        public const string DR_KEY = "Dr.";
        public const string REV_KEY = "Rev.";
        public const string FR_KEY = "Fr.";

        public List<string> Prefix { get; set; } = new List<string>()
        {
            "Dr","Dr.","Fr","Fr.","Master","Miss","Miss.","Mister","Mr","Mr.",
            "Mrs","Mrs.","Rev","Rev.","dr","dr.","fr","fr.","master","miss","miss.",
            "mister","mr","mr.","mrs","mrs.","rev","rev."
        };

        public List<string> Suffix { get; set; } = new List<string>()
        {
            "I", "II", "III", "IV", "V",
            "Senior","Sr", "Sr.",
            "Junior", "Jr", "Jr.",
            "PhD", "Phd.", "Phd",
            "APR",
            "RPh",
            "PE",
            "MD",
            "MA",
            "DMD", "CME",
                "BVM", "CFRE", "CLU", "CPA", "CSC", "CSJ", "DC", "DD", "DDS", "DO", "DVM",
            "EdD",
            "Esq", "Esq.",
                "JD", "LLD", "OD", "OSB", "PC",
            "Ret",
            "RGS", "RN", "RNC", "SHCJ", "SJ", "SNJM", "SSMO",
                "USA", "USAF", "USAFR", "USAR", "USCG", "USMC", "USMCR", "USN", "USNR"
        };

        public List<string> CompoundName { get; set; } = new List<string>()
        {
            "vere", "von", "van", "de", "del", "della", "di", "da", "pietro", "vanden", "du", "st.", "st", "la", "lo", "ter"
        };

        public List<string> BusinessIndicator { get; set; } = new List<string>()
        {
            "$", "+", ".com", ".net", ".org", "alpha", "biz", "business","bussiness", "care", "chiropractic",
            "clinic", "clinics", "company", "consultant", "consultants", "coproration",
            "corp", "corp.", "counsel", "counseler", "counselers", "counselling", "d.b.a.",
            "dba", "depot", "design", "designs", "development", "enterprise", "family",
            "fellowship", "goups", "group", "guru", "health", "help", "inc", "independent",
            "invest", "investment", "investments", "investor", "investors", "l.l.c", "l.p.c",
            "legion", "llc", "lpc", "merchant", "multi", "multi-", "omni", "p.l.c.", "plc", "plus",
            "quality", "sales", "serve", "service", "services", "simple", "simply", "solution",
            "solutions", "source", "store", "stores", "superior", "tech", "technologies", "technology",
            "teck", "tek", "wealth", "world", "www", "zone"
        };

    }
}
