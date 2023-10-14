using System;
using Shared.Chat;
using System.Reflection;
using Services;
using Server.Shared.Messages;
using UnityEngine;
using Server.Shared.State.Chat;
using Mentions.UI;
using Home.Common;

namespace Utils{
    static public class ChatUtils{
        static public void AddMessage(string message, string style = "", bool playSound = true, bool stayInChatlogs = true, bool showInChat = true){
            //Always makes the same pre-message. Styles maintain all message.
            MentionPanel mp = (MentionPanel)GameObject.FindObjectOfType(typeof(MentionPanel));
            ChatLogCustomTextEntry chatLogCustomTextEntry = new(mp.mentionsProvider.DecodeText(message), style)
            {
                showInChatLog = stayInChatlogs,
                showInChat = showInChat
            };
            ChatLogMessage chatLogMessage = new(chatLogCustomTextEntry);
            Service.Game.Sim.simulation.HandleChatLog(chatLogMessage);
            if(playSound)GameObject.FindObjectOfType<UIController>().PlaySound("Audio/UI/Error", false);
            
        }

        static public void AddFeedbackMsg(string message, bool playSound = true, string feedbackMessageType = "normal"){
            //Makes cool pre-messages with the types. Doesn't stay on chatlogs.
            try{
            MentionPanel mp = (MentionPanel)GameObject.FindObjectOfType(typeof(MentionPanel));
            ChatLogClientFeedbackEntry chatLogCustomLookupEntry = new ChatLogClientFeedbackEntry(TypesToTypesUtils.StringToFeedbackType(feedbackMessageType), mp.mentionsProvider.DecodeText(message));
			ChatLogMessage chatLogMessage = new ChatLogMessage();
			chatLogMessage.chatLogEntry = chatLogCustomLookupEntry;
			Service.Game.Sim.simulation.incomingChatMessage.ForceSet(chatLogMessage);
            if(playSound)GameObject.FindObjectOfType<UIController>().PlaySound("Audio/UI/Error", false);
        } catch (Exception ex) {
                Debug.Log(ex);
            }  
        }
        
    }
}