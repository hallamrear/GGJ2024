using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Joke Object", menuName = "ScriptableObjects/Joke", order = 1)]
public class Jokebook_JokeData : ScriptableObject
{
    public List<string> Lines;
}