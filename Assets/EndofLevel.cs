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
    private List<IDs> ids = new List<IDs>();

    // Use this for initialization
    void Start ()
    {
        WordIds = new InputField[3];

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

        ids.Add(new IDs("1"));
        ids.Add(new IDs("2"));
        ids.Add(new IDs("3"));
        ids.Add(new IDs("4"));
        ids.Add(new IDs("5"));
        ids.Add(new IDs("6"));

}

    public void submit()
    {
        string WordType = List1.text;
        

        
    }

    public void endOfLevel(List <Word> WordType, List <Word> WordsLearned)
    {
       
    }


    /*
    private List<Word> Fruit = new List<Word>();
    private List<Word> Family = new List<Word>();

    Dictionary<string, List<Word>> Lists = new Dictionary<string, List<Word>>();
    Lists.Add("fruit", Fruit);
    Lists.Add("family", Family);

    And then get it
    var myList = Lists["family"];
    */

}
