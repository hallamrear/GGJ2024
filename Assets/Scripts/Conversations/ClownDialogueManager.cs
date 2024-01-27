using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Xml.Linq;

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
    /// Helper class for handling all image resources for clowns and backgrounds.
    /// </summary>
    DialogueResources resources;

    private float clownOpinion = 0;

    // Start is called before the first frame update
    private void Start()
    {
        clownDialogueManager = this;
        resources = new DialogueResources();
        resources.PreLoadClowns();
        resources.PreLoadBackgrounds();
    }

    private void PreLoadClowns()
    {

    }

    private void PreLoadBackgrounds()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void ExitDialogueButton()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteraction>().EnterHit();
    }

    /// <summary>
    /// Begins the dialogue interaction for the clown and loads all relevant images.
    /// </summary>
    /// <param name="clownToLoad"></param>
    public void BeginDialogue(Clowns clownToLoad, Location location)
    {
        everythingHolder.SetActive(true);

        switch (clownToLoad)
        {
            case Clowns.TEST:
                ClownImage.sprite = resources.ClownPhoto;
                conversation = new ConversationNode(XElement.Load(@"Assets\Resources\TestAssets\TestConvo.xml"));
                ClownDialogue.SetText(conversation.Text);
                break;
            default:
                break;
        }

        switch (location)
        {
            case Location.tent:
                BackgroundImage.sprite = resources.BigTopBackground;
                break;
            default:
                break;
        }

        HidePlayerOptions();
    }

    public void EndDialogue()
    {
        everythingHolder.SetActive(false);
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
        ResponseButtonOne.GetComponentInChildren<TextMeshProUGUI>().SetText("Back To Start");
        ResponseButtonTwo.GetComponentInChildren<TextMeshProUGUI>().SetText("Back To Start");
        ResponseButtonThree.GetComponentInChildren<TextMeshProUGUI>().SetText("Back To Start");

        if (conversation.Options.Count > 0)
        {
            ResponseButtonOne.GetComponentInChildren<TextMeshProUGUI>().SetText(conversation.Options[0]);
        }
        if (conversation.Options.Count > 1)
        {
            ResponseButtonTwo.GetComponentInChildren<TextMeshProUGUI>().SetText(conversation.Options[1]);
        }
        if (conversation.Options.Count > 2)
        {
            ResponseButtonThree.GetComponentInChildren<TextMeshProUGUI>().SetText(conversation.Options[2]);
        }
    }

    public void IssueResponse(int choice)
    {
        HidePlayerOptions();
        ProcessNextDialogue(choice);
    }

    private void ProcessNextDialogue(int choice)
    {
        conversation = conversation.ConversationChoice(choice, ref clownOpinion);
        ClownDialogue.SetText(conversation.Text);

        ClownOpinionOfYou.value = clownOpinion;

        if (conversation.Options.Count == 0)
        {
            ReplyButtonText.SetText("Back To Start");
        }
        else
        {
            if (ReplyButtonText.text != "Reply")
            {
                ReplyButtonText.SetText("Reply");
            }
        }
    }
}