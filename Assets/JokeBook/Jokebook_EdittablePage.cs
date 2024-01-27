using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jokebook_EdittablePage : MonoBehaviour
{
    public TMPro.TMP_InputField InputField;
    private Jokebook_PageManager PageManager;

    // Start is called before the first frame update
    void Start()
    {
        PageManager = GameObject.Find("PageList").GetComponent<Jokebook_PageManager>();

        InputField.onTextSelection.AddListener(delegate { DisablePageTurning(); });
        InputField.onEndTextSelection.AddListener(delegate { EnablePageTurning(); });
    }

    public void EnablePageTurning()
    {
        PageManager.CanChangePages(true);
    }
        
    public void DisablePageTurning()
    {
        PageManager.CanChangePages(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
