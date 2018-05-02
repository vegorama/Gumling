using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class EndofLevel : MonoBehaviour {

    public InputField List1;
    public InputField[] WordIds;
    public Text stickersLog;

    private List<Word> Fruit = new List<Word>();
    private List<Word> Family = new List<Word>();

    Dictionary<string, List<Word>> Lists = new Dictionary<string, List<Word>>();

    private List<IDs> ids = new List<IDs>();

    // Use this for initialization
    void Start ()
    {
        Lists.Add("fruit", Fruit);
        Lists.Add("family", Family);

        Fruit.Add(new Word("Banana", true, 7));
        Fruit.Add(new Word("Apple", true, 4));
        Fruit.Add(new Word("Orange", false, 0));
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

    public void Submit()
    {
        if (Lists.ContainsKey(List1.text.ToLower()))
        {
            //The word list is equal to the string in the input field
            var WordList = Lists[List1.text];


            for (int i = 0; i < WordIds.Length; i++)
            {
                if (WordIds[i].text != null)
                {
                    ids.Add(new IDs(WordIds[i].text));
                    //Debug.Log("" + ids[i].id);
                }
            }

            //If all good, pass through to function
            endOfLevel(WordList, ids);
        }

        else
        {
            stickersLog.text = "Stickers Awarded \n Please enter a valid list name";
            Debug.Log("Please enter a valid list name");

            ids.Clear();
        }

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

        //Select 3 random words that have been learned and award them

        var hasCollectedFruit = WordType.Where(x => x.hasAlreadyCollected == true);

        
        stickersLog.text = "Stickers Awarded \n 1. \n 2. \n 3.";

        ids.Clear();
    }


}
