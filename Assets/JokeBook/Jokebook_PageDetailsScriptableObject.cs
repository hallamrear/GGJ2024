using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Jokebook Pages", menuName = "ScriptableObjects/Jokebook Page Details", order = 1)]
public class Jokebook_PageDetailsScriptableObject : ScriptableObject
{
    public string PageTitle = "";
    public string PageData = "";
}