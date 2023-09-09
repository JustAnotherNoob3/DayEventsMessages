using Server.Shared.State;
using System.Reflection;
using System.Collections.Generic;
using Mentions;
using Mentions.UI;
using UnityEngine;
using System;
namespace Utils{
    static public class TypesToTypesUtils{
        static public string GetMentionEncodedText(string humanText){
            if(humanText[0] != '@' && humanText[0] != '#' && humanText[0] != ':'){
                Console.WriteLine("Error: " + humanText + " does not start with a valid character. Always start with #, : or @");
                return "Error: " + humanText + " does not start with a valid character";
            }
            MentionPanel mentionPanel = (MentionPanel)GameObject.FindObjectOfType(typeof(MentionPanel));
            if(mentionPanel == null)
            {
                return "Error! MentionPanel not found";
            }
           foreach (MentionInfo mentionInfo in (List<MentionInfo>)mentionPanel.mentionsProvider.GetType().GetField("MentionInfos", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(mentionPanel.mentionsProvider))
			{
				if(mentionInfo.humanText == humanText)
				{
                    return mentionInfo.encodedText;
				}
            }
           return "Error: " + humanText + " not found";
        }


        static public ClientFeedbackType StringToFeedbackType(string str){
            switch(str){
                case "normal":
                    return ClientFeedbackType.Normal;
                case "info":
                    return ClientFeedbackType.Info;
                case "warning":
                    return ClientFeedbackType.Warning;
                case "critical":
                    return ClientFeedbackType.Critical;
                case "success":
                    return ClientFeedbackType.Success;
                default:
                    Console.WriteLine("Error: " + str + " is not a valid feedback type, defaulting to normal");
                    return ClientFeedbackType.Normal;
            }
        }    
    }


}