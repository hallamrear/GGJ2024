using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jokebook_PageManager : MonoBehaviour
{
    [Header("Page Details")]
    [SerializeField]
    private GameObject m_EmptyPagePrefab;
    [SerializeField]
    private GameObject m_PageListGameObject;
    [SerializeField]
    private GameObject m_LeftPanelGameObject;
    [SerializeField]
    private GameObject m_RightPanelGameObject;
    private int MaxPageCount;
    private int m_CurrentPageIndex;
    
    public List<GameObject> m_Pages;

    // Start is called before the first frame update
    void Start()
    {
        Transform[] pageListTransforms = m_PageListGameObject.GetComponentsInChildren<RectTransform>();
        foreach (var pageTransform in pageListTransforms)
        {
            //get all the transform of the immediate children only.
            if (pageTransform.parent == m_PageListGameObject.transform)
            {
                GameObject page = pageTransform.gameObject;
                page.transform.position = m_PageListGameObject.transform.position;
                page.SetActive(false);
                m_Pages.Add(page);
            }
        }

        MaxPageCount = m_Pages.Count;

        DisplayCurrentPageContent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPage()
    {
        if(m_EmptyPagePrefab)
        {
            GameObject newPage = Instantiate(m_EmptyPagePrefab, m_PageListGameObject.transform);
            newPage.transform.position = m_PageListGameObject.transform.position;
            newPage.GetComponent<Image>().color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            newPage.SetActive(false);
            m_Pages.Add(newPage);

            newPage = Instantiate(m_EmptyPagePrefab, m_PageListGameObject.transform);
            newPage.GetComponent<Image>().color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            newPage.transform.position = m_PageListGameObject.transform.position;
            newPage.SetActive(false);
            m_Pages.Add(newPage);

            MaxPageCount = m_Pages.Count;
        }
    }

    public void IncrementPage()
    {
        m_CurrentPageIndex += 2;

        if(m_CurrentPageIndex > MaxPageCount - 2)
        {
            m_CurrentPageIndex = MaxPageCount - 2;
        }

        Debug.Log(m_CurrentPageIndex);
        DisplayCurrentPageContent();
    }

    public void DecrementPage()
    {
        m_CurrentPageIndex -= 2;

        if (m_CurrentPageIndex < 0)
            m_CurrentPageIndex = 0;

        Debug.Log(m_CurrentPageIndex.ToString());
        DisplayCurrentPageContent();
    }

    private void DisplayCurrentPageContent()
    {
        m_LeftPanelGameObject.GetComponent<Image>().color = m_Pages[m_CurrentPageIndex].GetComponent<Image>().color;
        m_LeftPanelGameObject.GetComponent<Jokebook_Page>()?.m_TitleText.SetText(m_Pages[m_CurrentPageIndex].GetComponent<Jokebook_Page>().DataObject.PageTitle);
        m_LeftPanelGameObject.GetComponent<Jokebook_Page>()?.m_MainText.SetText(m_Pages[m_CurrentPageIndex].GetComponent<Jokebook_Page>().DataObject.PageData);
        
        m_RightPanelGameObject.GetComponent<Image>().color = m_Pages[m_CurrentPageIndex + 1].GetComponent<Image>().color;
        m_RightPanelGameObject.GetComponent<Jokebook_Page>()?.m_TitleText.SetText(m_Pages[m_CurrentPageIndex].GetComponent<Jokebook_Page>().DataObject.PageTitle);
        m_RightPanelGameObject.GetComponent<Jokebook_Page>()?.m_MainText.SetText(m_Pages[m_CurrentPageIndex + 1].GetComponent<Jokebook_Page>().DataObject.PageData);
    }
}
