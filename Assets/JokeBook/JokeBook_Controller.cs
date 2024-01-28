using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jokebook_Controller : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("World Details")]
    [SerializeField]
    GameObject m_JokebookDisplayObject;
    [SerializeField]
    private RectTransform m_VisibleTransform;
    [SerializeField]
    private RectTransform m_HiddenTransform;
    private RectTransform m_TargetTransform;

    private RectTransform m_Transform;

    [Header("Transition Details")]
    public float TransitionTolerence;
    public float TransitionTime;


    private bool m_IsVisible { get; set; }  
    private bool m_InTransition = false;

    [SerializeField]
    Jokebook_PageManager m_PageManager;

    [SerializeField]
    GameObject m_NextButton;
    [SerializeField]
    GameObject m_PreviousButton;

    [Header("Sound Effects")]
    [SerializeField]
    private AudioClip m_BookOpeningSoundEffect;
    [SerializeField]
    private AudioSource m_AudioSource;

    void Start()
    {
        m_IsVisible = false;
        m_Transform = m_JokebookDisplayObject.GetComponent<RectTransform>();
        if (m_Transform != null && m_HiddenTransform != null)
        {
            m_Transform.position = m_HiddenTransform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow) && m_InTransition == false)
        {
            ShowBookUI();
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) && m_InTransition == false)
        {
            HideBookUI();
        }

        if (m_IsVisible)
        {
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                m_PageManager.DecrementPage();
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                m_PageManager.IncrementPage();
            }
        }

        m_PreviousButton.gameObject.SetActive(m_PageManager.GetCurrentPageIndex() != 0);
        m_NextButton.gameObject.SetActive(m_PageManager.GetCurrentPageIndex() < m_PageManager.GetMaxPageCount() - 2);

        if (m_Transform == null)
        return;
    }
    IEnumerator MoveToTargetTransform()
    {
        if (m_BookOpeningSoundEffect && m_AudioSource)
            m_AudioSource.PlayOneShot(m_BookOpeningSoundEffect);

        float time = 0;
        Vector2 startPosition = m_Transform.position;
        Vector2 step;
        while (time < TransitionTime)
        {
            step.x = Mathf.SmoothStep(startPosition.x, m_TargetTransform.position.x, time / TransitionTime);
            step.y = Mathf.SmoothStep(startPosition.y, m_TargetTransform.position.y, time / TransitionTime);
            m_Transform.position = step;
            time += Time.deltaTime;
            yield return null;
        }
        m_Transform.position = m_TargetTransform.position;
        m_InTransition = false;
    }

    public void ToggleVisiblity()
    {
        m_IsVisible = !m_IsVisible;

        if (m_IsVisible)
        {
            m_TargetTransform = m_VisibleTransform;
        }
        else
        {
            m_TargetTransform = m_HiddenTransform;
        }

        m_InTransition = true;
        StartCoroutine(MoveToTargetTransform());
    }

    public void ShowBookUI()
    {
        m_TargetTransform = m_VisibleTransform;
        m_IsVisible = true;
        m_InTransition = true;
        StartCoroutine(MoveToTargetTransform());
    }

    public void HideBookUI()
    {
        m_TargetTransform = m_HiddenTransform;
        m_IsVisible = false;
        m_InTransition = true;
        StartCoroutine(MoveToTargetTransform());
    }

}