using System.Collections.Generic;
using System.Linq;

namespace SyllableProject
{
    public class SyllableLibrary
    {
        public Syllables GetSyllableWords(string word)
        {
            Syllables result = new Syllables();
            Syllable tempWord = new Syllable();


            word = word.ToLower().Trim();
            bool lastWasVowel = false;
            var vowels = new[] {'a', 'e', 'i', 'ı', 'o', 'ö', 'u', 'ü'};

            tempWord.Value = "";


            string tempSyllable = "";
            List<int> wordPosition = new List<int>();
            for (int i = 0; i < word.Length; i++)
            {
                char tempKey = word[i];
                if (vowels.Contains(tempKey))
                {
                    tempSyllable = "";
                }
                else
                {
                    tempSyllable += tempKey;
                    if (tempSyllable.Length > 1)
                    {
                        wordPosition.Add(i - 1);
                    }
                }
            }
            wordPosition.Add(word.Length - 1);


            for (var i = 0; i < wordPosition.Count; i++)
            {
                string innerWord = word.Substring(
                    i == 0 ? 0 : wordPosition[i - 1] + 1,
                    i == 0 ? wordPosition[i] + 1 : wordPosition[i] - wordPosition[i - 1]);


                tempWord = new Syllable();
                foreach (var c in innerWord)
                {
                    tempWord.Value += c;

                    if (vowels.Contains(c))
                    {
                        if (!lastWasVowel)
                        {
                            result.Add(tempWord);
                            tempWord = new Syllable();
                        }

                        lastWasVowel = true;
                    }
                    else
                    {
                        lastWasVowel = false;
                    }
                }

                if (tempWord?.Value?.Length > 0)
                {
                    result.Last().Value += tempWord.Value;
                }
            }


            return result;
        }
    }


    [System.Diagnostics.DebuggerDisplay("{ToString()}")]
    public class Syllable
    {
        string _value;

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public Syllable()
        {

        }

        public Syllable(string value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }

    public class Syllables : List<Syllable>
    {

    }
}
