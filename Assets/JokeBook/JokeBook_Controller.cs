using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokeBook_Controller : MonoBehaviour
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

    [Header("Sound Effects")]
    AudioSource m_BookOpeningSoundEffect;

    private bool m_IsVisible { get; set; }  
    private bool m_InTransition = false;

    [SerializeField]
    Jokebook_PageManager m_PageManager;

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
        if(Input.GetKeyUp(KeyCode.P) && m_InTransition == false)
        {
            ToggleVisiblity();
        }

        if(m_IsVisible)
        {
            if(Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                m_PageManager.DecrementPage();
            }

            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                m_PageManager.IncrementPage();
            }
        }

        if (m_Transform == null)
            return;
    }
    IEnumerator MoveToTargetTransform()
    {
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

        if(m_BookOpeningSoundEffect)
            m_BookOpeningSoundEffect.Play();

        m_InTransition = true;
        StartCoroutine(MoveToTargetTransform());
    }
}