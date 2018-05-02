using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class EndofLevel : MonoBehaviour {

    public InputField List1;
    public InputField[] WordIds;
    public Text stickersLog;

    private bool list1Correct;
    private bool wordIdsCorrect;

    private List<Word> Fruit = new List<Word>();
    private List<Word> Family = new List<Word>();
    private List<string> WordsToPrint = new List<string>();

    Dictionary<string, List<Word>> Lists = new Dictionary<string, List<Word>>();

    private List<IDs> ids = new List<IDs>();

    // Use this for initialization
    void Start ()
    {
        Lists.Add("fruit", Fruit);
        Lists.Add("family", Family);

        Fruit.Add(new Word("Banana", true, 7));
        Fruit.Add(new Word("Apple", true, 4));
        Fruit.Add(new Word("Orange", true, 0));
        Fruit.Add(new Word("Pear", false, 0));
        Fruit.Add(new Word("Coconut", false, 0));
        Fruit.Add(new Word("Strawberry", false, 0));

        Family.Add(new Word("Mum", true, 4));
        Family.Add(new Word("Dad", true, 3));
        Family.Add(new Word("Sister", true, 1));
        Family.Add(new Word("Brother", false, 0));
        Family.Add(new Word("Grandma", false, 0));
        Family.Add(new Word("Grandad", false, 0));
     
    }

    public void Restart()
    {
        Lists.Clear();
        Fruit.Clear();
        Family.Clear();
        Start();
    }

    public static void KnuthShuffle<T>(T[] array)
    {
        System.Random random = new System.Random();
        for (int i = 0; i < array.Length; i++)
        {
            int j = random.Next(i, array.Length); // Don't select from the entire array on subsequent loops
            T temp = array[i]; array[i] = array[j]; array[j] = temp;
        }
    }

    public void Submit()
    {
        if (Lists.ContainsKey(List1.text.ToLower()))
        {          
            //The word list is equal to the string in the input field
            var WordList = Lists[List1.text];

            list1Correct = true;
            wordIdsCorrect = true;

            //Iterate through each id inputfield and add number to the id List
            for (int i = 0; i < WordIds.Length; i++)
            {
                int wordValue;
                int.TryParse(WordIds[i].text, out wordValue);

                if ((WordIds[i].text != null) && (0 < wordValue && wordValue < 7))
                {
                    ids.Add(new IDs(WordIds[i].text));
                    //Debug.Log("" + ids[i].id);
                }
                else
                {
                    Debug.Log("Please enter 3 valid ID's");                   
                    wordIdsCorrect = false;
                }
            }

            //If all good, pass through to function
            if (list1Correct && wordIdsCorrect)
            {
                endOfLevel(WordList, ids);
            }

        }

        //If bad, print error
        if (!list1Correct)
        {
            stickersLog.text = "Stickers Awarded \n Please enter a valid list name";
        }
        else if (!wordIdsCorrect)
        {
            stickersLog.text = "Stickers Awarded \n Please enter 3 valid ID's";
        }

        //Reset checks and variables
        list1Correct = false;
        wordIdsCorrect = false;
        ids.Clear();
    }

    public void endOfLevel(List <Word> WordType, List <IDs> WordsLearned)
    {

        // for every Wordslearned.id
        for (int i = 0; i < WordsLearned.Count; i++)
        {
            var currentWord = WordType[(int.Parse(WordsLearned[i].id)) - 1];

            //increase number of times learned
            currentWord.numberOfTimesLearned++;
            //Set hasAlreadyCollected bool
            if (currentWord.hasAlreadyCollected == false)
            {
                WordType[(int.Parse(WordsLearned[i].id)) - 1].hasAlreadyCollected = true;
            }

            //Debug.Log("" + WordType[(int.Parse(WordsLearned[i].id)) - 1].id);
        }

        //New list of all valid words
        for (int t = 0; t < WordType.Count; t++)
        {
            if (WordType[t].hasAlreadyCollected == true)
            {
                WordsToPrint.Add(WordType[t].id);
            }
        }
             
        string[] stringsToPrint = WordsToPrint.ToArray();

        /*
        //Select 3 random words that have been learned and award them    
        for (int i = 0; i < 3; i++)
        {
            var index = Random.Range(0, WordsToPrint.Count);         
            stringsToPrint[i] = WordsToPrint[index];          
        }
        */ 

        //Shuffle the strings
        for (int t = 0; t < stringsToPrint.Length; t++)
        {
            string tmp = stringsToPrint[t];
            int r = Random.Range(t, stringsToPrint.Length);
            stringsToPrint[t] = stringsToPrint[r];
            stringsToPrint[r] = tmp;
        }

        //Print values to screen
        stickersLog.text = "Stickers Awarded \n 1." + stringsToPrint[0]  + "\n 2. " + stringsToPrint[1] + "\n 3. " + stringsToPrint[2];


        //Clear Lists
        ids.Clear();
        WordsToPrint.Clear();
    }

    //var hasCollectedFruit = WordType.Where(x => x.hasAlreadyCollected == true);
}
