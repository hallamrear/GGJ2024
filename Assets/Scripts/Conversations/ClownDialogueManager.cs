using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Xml.Linq;
using System.Collections;

public class ClownDialogueManager : MonoBehaviour 
{
    /// <summary>
    /// Singleton reference for the <see cref="ClownDialogueManager"/>
    /// </summary>
    public static ClownDialogueManager ClownDialogueManagerInstance
    {
        get
        {
            return clownDialogueManager;
        }
    }
    private static ClownDialogueManager clownDialogueManager;

    /// <summary>
    /// Reference to the background image of the scene
    /// </summary>
    public Image BackgroundImage;

    /// <summary>
    /// Reference to the clown hero image.
    /// </summary>
    public Image ClownImage;

    /// <summary>
    /// Refernce to the text of the clown's dialogue to the player.
    /// </summary>
    public TextMeshProUGUI ClownDialogue;

    /// <summary>
    /// Reference to response button one.
    /// </summary>
    public Button ResponseButtonOne;

    /// <summary>
    /// Reference to response button two.
    /// </summary>
    public Button ResponseButtonTwo;

    /// <summary>
    /// Reference to response button three.
    /// </summary>
    public Button ResponseButtonThree;

    /// <summary>
    /// Reference to the object holding all of the other clowns dialogue.
    /// </summary>
    public GameObject DialogueHolder;

    /// <summary>
    /// Reference to the object holding all of the players available responses.
    /// </summary>
    public GameObject ResponsesHolder;

    /// <summary>
    /// The current node in conversation for navigating the dialogue tree.
    /// </summary>
    private ConversationNode conversation;

    /// <summary>
    /// Reference to the object in the prefab that holds all parts of the UI for showing and hiding the conversation system.
    /// </summary>
    public GameObject everythingHolder;

    /// <summary>
    /// ClownOpinionDisplay
    /// </summary>
    public Slider ClownOpinionOfYou;

    /// <summary>
    /// Reference to the text of the reply button.
    /// </summary>
    public TextMeshProUGUI ReplyButtonText;

    /// <summary>
    /// Reference to the ClaimJoke button.
    /// </summary>
    public GameObject ClaimJokeButton;

    /// <summary>
    /// Helper class for handling all image resources for clowns and backgrounds.
    /// </summary>
    DialogueResources resources;

    NPCInfo activeConvoInfo;

    // Start is called before the first frame update
    private void Start()
    {
        clownDialogueManager = this;
        resources = new DialogueResources();
        resources.PreLoadClowns();
        resources.PreLoadBackgrounds();
        activeConvoInfo = null;
    }

    // Update is called once per frame
    private void Update()
    {
        if (activeConvoInfo != null && activeConvoInfo.OpinionOfPlayer >= 1)
        {
            if (!ClaimJokeButton.activeSelf)
            {
                interuptSpin = true;
                ClaimJokeButton.transform.SetPositionAndRotation(ClaimJokeButton.transform.position, Quaternion.Euler(new Vector3(0, 0, 26.531f)));
                ClaimJokeButton.transform.localScale = new Vector3(4.30905f, 21.62503f, 4.30905f);
                ClaimJokeButton.SetActive(true);
            }
        }
        else
        {
            if (ClaimJokeButton.activeSelf)
            {
                ClaimJokeButton.SetActive(false);
                interuptSpin = true;
            }
        }

    }

    public void ExitDialogueButton()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteraction>().EnterHit();
    }

    /// <summary>
    /// Begins the dialogue interaction for the clown and loads all relevant images.
    /// </summary>
    /// <param name="clownToLoad"></param>
    public void BeginDialogue(Clowns clownToLoad, Location location, NPCInfo clownInfo)
    {
        activeConvoInfo = clownInfo;
        ClownOpinionOfYou.value = activeConvoInfo.OpinionOfPlayer;
        everythingHolder.SetActive(true);

        ClaimJokeButton.transform.SetPositionAndRotation(ClaimJokeButton.transform.position, Quaternion.Euler(new Vector3(0, 0, 26.531f)));
        ClaimJokeButton.transform.localScale = new Vector3(4.30905f, 21.62503f, 4.30905f);

        ClownImage.gameObject.GetComponent<Transform>().SetPositionAndRotation(ClownImage.gameObject.transform.position, Quaternion.identity);

        switch (clownToLoad)
        {
            case Clowns.TEST:
                ClownImage.sprite = resources.ClownPhoto;
                conversation = new ConversationNode(XElement.Load(@"Assets\Resources\TestAssets\TestConvo.xml"));
                ClownDialogue.SetText(conversation.Text);
                break;
            case Clowns.QuestionClown:
                ClownImage.sprite = resources.JohnClownPhoto;
                conversation = new ConversationNode(XElement.Load(@"Assets\Resources\ClownConversations\QuestionClown.xml"));
                ClownDialogue.SetText(conversation.Text);
                location = Location.fence;
                break;
            case Clowns.SadClown:
                ClownImage.sprite = resources.BallClownPhoto;
                conversation = new ConversationNode(XElement.Load(@"Assets\Resources\ClownConversations\DepressedClown.xml"));
                ClownDialogue.SetText(conversation.Text);
                location = Location.purpleTent;
                break;
            case Clowns.SelfconsciousClown:
                ClownImage.sprite = resources.GirlClownPhoto;
                conversation = new ConversationNode(XElement.Load(@"Assets\Resources\ClownConversations\SelfConsciousClown.xml"));
                ClownDialogue.SetText(conversation.Text);
                location = Location.redTent;
                break;
            case Clowns.KillerClown:
                ClownImage.sprite = resources.JugglingClownPhoto;
                conversation = new ConversationNode(XElement.Load(@"Assets\Resources\ClownConversations\KillerClown.xml"));
                ClownDialogue.SetText(conversation.Text);
                location = Location.bridge;
                break;
            default:
                break;
        }

        switch (location)
        {
            case Location.purpleTent:
                BackgroundImage.sprite = resources.PurpleBigTop;
                break;
            case Location.redTent:
                BackgroundImage.sprite = resources.RedWhiteBigTop;
                break;
            case Location.bridge:
                BackgroundImage.sprite = resources.Bridge;
                break;
            case Location.fence:
                BackgroundImage.sprite = resources.Field;
                break;
            default:
                break;
        }

        HidePlayerOptions();
    }

    public void EndDialogue()
    {
        everythingHolder.SetActive(false);
        activeConvoInfo = null;
    }

    private void HidePlayerOptions()
    {
        DialogueHolder.SetActive(true);
        ResponsesHolder.SetActive(false);
    }

    private void ShowPlayerOptions()
    {
        DialogueHolder.SetActive(false);
        ResponsesHolder.SetActive(true);
    }

    public void Reply()
    {
        if (ReplyButtonText.text != "Reply")
        {
            IssueResponse(0);
        }
        else
        {
            ShowPlayerOptions();
            PopulateResponses();
        }
    }

    private void PopulateResponses()
    {
        SetText(ResponseButtonOne.GetComponentInChildren<TextMeshProUGUI>(), "Back To Start");
        SetText(ResponseButtonTwo.GetComponentInChildren<TextMeshProUGUI>(), "Back To Start");
        SetText(ResponseButtonThree.GetComponentInChildren<TextMeshProUGUI>(), "Back To Start");

        if (conversation.Options.Count > 0)
        {
            SetText(ResponseButtonOne.GetComponentInChildren<TextMeshProUGUI>(), conversation.Options[0]);
        }
        if (conversation.Options.Count > 1)
        {
            SetText(ResponseButtonTwo.GetComponentInChildren<TextMeshProUGUI>(), conversation.Options[1]);
        }
        if (conversation.Options.Count > 2)
        {
            SetText(ResponseButtonThree.GetComponentInChildren<TextMeshProUGUI>(), conversation.Options[2]);
        }
    }

    public void IssueResponse(int choice)
    {
        HidePlayerOptions();
        ProcessNextDialogue(choice);
    }

    private void ProcessNextDialogue(int choice)
    {
        float clownOpinion = (activeConvoInfo != null) ? activeConvoInfo.OpinionOfPlayer : 0;
        conversation = conversation.ConversationChoice(choice, ref clownOpinion);
        SetText(ClownDialogue, conversation.Text, false);

        if (activeConvoInfo != null)
        {
            activeConvoInfo.OpinionOfPlayer = clownOpinion;
            ClownOpinionOfYou.value = activeConvoInfo.OpinionOfPlayer;
        }

        if (conversation.Options.Count == 0)
        {
            SetText(ReplyButtonText, "Back To Start");
        }
        else
        {
            if (ReplyButtonText.text != "Reply")
            {
                SetText(ReplyButtonText, "Reply");
            }
        }
    }

    private void SetText(TextMeshProUGUI tmp, string text, bool instantUpdate = true)
    {
        tmp.SetText(text);
        if (!instantUpdate)
        {
            tmp.maxVisibleCharacters = 0;
            StartCoroutine(WaitAndPrint(0.05f, tmp, text));
        }
        else
        {
            tmp.maxVisibleCharacters = text.Length;
        }
    }

    private IEnumerator WaitAndPrint(float waitTime, TextMeshProUGUI tmp, string text)
    {
        bool notCompleted = true;
        int visibleCharacters = 0;
        float rotationPerLetter = 360.0f / (float)text.Length;

        while (notCompleted)
        {
            if (activeConvoInfo?.ClownType == Clowns.QuestionClown)
            {
                ClownImage.gameObject.GetComponent<Transform>().Rotate(new Vector3(0, 0, rotationPerLetter));
            }

            visibleCharacters++;
            tmp.maxVisibleCharacters = visibleCharacters;
            if (visibleCharacters >= text.Length)
            {
                notCompleted = false;
            }

            yield return new WaitForSeconds(waitTime);
        }
    }

    private bool interuptSpin = false;
    private IEnumerator SpinAndVanish(GameObject gameObject)
    {
        interuptSpin = false;
        bool notCompleted = true;
        while (notCompleted)
        {
            gameObject.transform.Rotate(new Vector3(0, 0, 25));
            gameObject.transform.localScale -= new Vector3(0.5f, 2.5f, 0.5f);

            yield return new WaitForSeconds(0.01f);

            if (gameObject.transform.localScale.x <= 0)
            {
                gameObject.transform.localScale = new Vector3(0, 0, 0);
                notCompleted = false;
            }

            if (interuptSpin)
            {
                interuptSpin = false;
                break;
            }
        }
    }

    public void ClaimJokePressed()
    {
        if (activeConvoInfo.Claimed)
            return;

        ClaimJokeButton.GetComponent<AudioSource>().Play();
        StartCoroutine(SpinAndVanish(ClaimJokeButton));

        switch (activeConvoInfo.ClownType)
        {
            case Clowns.QuestionClown:
                break;
            case Clowns.SadClown:
                break;
            case Clowns.SelfconsciousClown:
                break;
            case Clowns.KillerClown:
                break;
        }
    }
}