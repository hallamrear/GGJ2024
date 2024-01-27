using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jokebook_Page : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Jokebook_PageDetailsScriptableObject m_DataObject;
    public Jokebook_PageDetailsScriptableObject DataObject
    {
        get { return m_DataObject; }   // get method
    }

    public TMPro.TextMeshProUGUI m_TitleText;
    public TMPro.TextMeshProUGUI m_MainText;

    void Start()
    {
        if (DataObject)
        {
            m_TitleText.text = DataObject.PageTitle;
            m_MainText.text = DataObject.PageData;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
