static bool Check(string[] words, char[] ordering)
        {
            if (words == null || ordering == null)
                return false;

            int length = words[0].Length;
            var dict = new Dictionary<string, int>();

            foreach (string s in words)
            {
                if (length != s.Length)
                    return false;
                if (!dict.ContainsKey(s))
                    dict.Add(s, 0);
            }

            for (int i = 0; i < length; i++)
            {
                foreach (var s in words)
                {
                    int ci = dict[s];
                    bool found = false;
                    for (int j = ci; j < ordering.Length; j++)
                    {
                        if (ordering[j] == s[i])
                        {
                            dict[s] = ci;
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                        return false;
                }
            }
            return true;
        }
