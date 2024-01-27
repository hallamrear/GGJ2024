using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class ConversationNode
{
    private List<ConversationNode> children = null;
    private string text;
    private string entryText;
    private List<string> replies;
    private ConversationNode startNode;
    private int opinionModifier = 0;

    public string Text
    {
        get
        {
            return text;
        }
    }

    public List<string> Options
    {
        get
        {
            return replies;
        }
    }

    public ConversationNode(XElement nodeToLoad)
    {
        children = new List<ConversationNode>();
        replies = new List<string>();

        this.text = nodeToLoad.Attribute("Text").Value.ToString();
        this.entryText = nodeToLoad.Attribute("OptionToEnter")?.Value.ToString();
        
        if (nodeToLoad.Attribute("OpinionModifier") != null)
        {
            opinionModifier = Convert.ToInt32(nodeToLoad.Attribute("OpinionModifier").Value);
        }

        foreach (var ntl in nodeToLoad.Elements())
        {
            var newChild = new ConversationNode(ntl);
            children.Add(newChild);
            replies.Add(newChild.entryText);
            SetConversationStart((startNode != null) ? startNode : this);
        }
    }

    public void SetConversationStart(ConversationNode startNode)
    {
        this.startNode = startNode;
        foreach (var child in children)
        {
            child.SetConversationStart(startNode);
        }
    }

    public ConversationNode ConversationChoice(int choice)
    {
        FireEventForOpinionChange(choice);
        return (choice < children.Count) ? children[choice] : startNode;
    }

    public void FireEventForOpinionChange(int choice)
    {
        if (choice < children.Count)
        {
            int changeInOpinion = children[choice].opinionModifier;
            // TODO: Propogate this to the clowns opinion of the player somehow.
        }
    }
}
