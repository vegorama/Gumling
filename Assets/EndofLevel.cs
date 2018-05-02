using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class EndofLevel : MonoBehaviour {

    public InputField List1;
    public InputField[] WordIds;


    private List<Word> Fruit = new List<Word>();
    private List<Word> Family = new List<Word>();

    Dictionary<string, List<Word>> Lists = new Dictionary<string, List<Word>>();

    private List<IDs> ids = new List<IDs>();

    // Use this for initialization
    void Start ()
    {
        Lists.Add("Fruit", Fruit);
        Lists.Add("Family", Family);

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
        //TODO make this check if the list exists
        
        if (Lists.ContainsKey(List1.text))
        {
            var WordList = Lists[List1.text];

            for (int i = 0; i < WordIds.Length; i++)
            {
                if (WordIds[i].text != null)
                {
                    ids.Add(new IDs(WordIds[i].text));
                    //Debug.Log("" + ids[i].id);
                }
            }

            endOfLevel(WordList, ids);
        }

        else
        {
            Debug.Log("Please enter a valid list name");
        }

    }


    public void endOfLevel(List <Word> WordType, List <IDs> WordsLearned)
    {
        // for every Wordslearned.id
        for (int i = 0; i < WordsLearned.Count; i++)
        {
            // use Wordtype[WordsLearned[i].id] to fetch the things?

            Debug.Log("" + WordType[int.Parse(WordsLearned[i].id)].id);

            //Debug.Log("" + Fruit[4].id);
        }


    }




}
