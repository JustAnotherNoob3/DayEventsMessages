using Server.Shared.State;
using System.Reflection;
using System.Collections.Generic;
using Mentions;
using Mentions.UI;
using UnityEngine;
using System;
namespace Utils{
    static public class TypesToTypesUtils{
        


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