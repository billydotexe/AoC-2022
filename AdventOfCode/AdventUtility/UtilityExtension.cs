namespace AdventUtility
{
    public static class UtilityExtension
    {
        public static List<string> RemoveEmpty(this List<string> input)
        {
            List<string> tmp = new();
            foreach (var s in input)
                if (!string.IsNullOrEmpty(s)) tmp.Add(s);
            return tmp;
        }

        public static bool IsEveryCharUnique(this string s)
        {
            foreach(char c in s)
            {
                //if when replacing a character with an empty string the result
                //is a string shorter than the starting string length -1 
                //we have more than one occurency, the character is not unique
                if (s.Replace(c.ToString(), "").Length < s.Length - 1)
                    return false;
            }
            return true;
        }
    }
}