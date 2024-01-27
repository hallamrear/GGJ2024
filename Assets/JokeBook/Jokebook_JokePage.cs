using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jokebook_JokePage : Jokebook_TextPage
{
    [SerializeField]
    List<Jokebook_JokeData> m_JokeList;

    public void AddJoke(Jokebook_JokeData joke)
    {
        string jokeList = m_MainText.text;

        for (int i = 0; i < joke.Lines.Count; i++)
        {
            jokeList += "- " + joke.Lines[i] + "\n";
        }

        m_MainText.SetText(jokeList);
    }
}
