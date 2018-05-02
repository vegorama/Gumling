using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Word
{
    public string id;
    public bool hasAlreadyCollected;
    public int numberOfTimesLearned;

    public Word (string _id, bool _hasAlreadyCollected, int _numberOfTimesLearned)
    {
        id = _id;
        hasAlreadyCollected = _hasAlreadyCollected;
        numberOfTimesLearned = _numberOfTimesLearned;
    }
	
}
