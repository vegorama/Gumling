using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Family
{
    public string id;
    public bool hasAlreadyCollected;
    public int numberOfTimesLearned;

    public Family(string _id, bool _hasAlreadyCollected, int _numberOfTimesLearned)
    {
        id = _id;
        hasAlreadyCollected = _hasAlreadyCollected;
        numberOfTimesLearned = _numberOfTimesLearned;
    }

}
