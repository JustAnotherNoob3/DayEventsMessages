using SML;
using UnityEngine;
using HarmonyLib;
using Services;
using Cinematics.Players;
using Server.Shared.Cinematics.Data;
using Home.Services;
using Utils;

namespace Main
{
    [Mod.SalemMod]
    public class Main
    {
        public static void Start()
            {
            Debug.Log("Working?"); 
            }
        
    }

    [HarmonyPatch(typeof(DeputyKillCinematicPlayer), "Init")]
    class DeputyKillCinematicPlayer_Init_Patch{
        static public void Prefix(DeputyKillCinematicPlayer __instance, ICinematicData cinematic){
            DeputyKillCinematicData deputyKillCinematicData = cinematic as DeputyKillCinematicData;
			int deputyPosition = deputyKillCinematicData.deputyPosition;
			int otherPosition = deputyKillCinematicData.otherPosition;
            ChatUtils.AddMessage(ModSettings.GetString("Deputy Message").Replace("%deputy%", "[[@"+(deputyPosition + 1) + "]]").Replace("%deputyRole%",TypesToTypesUtils.GetMentionEncodedText("#deputy")).Replace("%target%", "[[@"+(otherPosition + 1)+"]]"), "", false); //there are multiple styles you can use to paint the text however you want, but i want to give users the freedom to choose their text so im leaving it blank.
        }
        
        }

    [HarmonyPatch(typeof(ProsecutionCinematicPlayer), "Init")]
    class ProsecutionCinematicPlayer_Init_Patch{
        public static void Prefix(ProsecutionCinematicPlayer __instance, ICinematicData cinematic){
            ProsecutionCinematicData prosecutionCinematicData = cinematic as ProsecutionCinematicData;
			int prosecutorPosition = prosecutionCinematicData.prosecutorPostion;
			int otherPosition = prosecutionCinematicData.targetPosition;
            ChatUtils.AddFeedbackMsg(ModSettings.GetString("Prosecutor Message").Replace("%prosecutor%", "[[@"+(prosecutorPosition + 1) + "]]").Replace("%prosecutorRole%",TypesToTypesUtils.GetMentionEncodedText("#prosecutor")).Replace("%target%", "[[@"+(otherPosition + 1)+"]]"),false,"info");
        }
    }
    [HarmonyPatch(typeof(ConjurerKillCinematicPlayer), "Init")]
    class ConjurerKillCinematicPlayer_Init_Patch{
        public static void Prefix(ConjurerKillCinematicPlayer __instance, ICinematicData cinematic){
            ConjurerKillCinematicData conjurerKillCinematicData = cinematic as ConjurerKillCinematicData;
			
			int otherPosition = conjurerKillCinematicData.otherPosition;
            string txt = "critical";
            if(conjurerKillCinematicData.didKill){
                txt = "warning";
            }
            ChatUtils.AddFeedbackMsg(ModSettings.GetString("Conjurer Message").Replace("%conjurerRole%",TypesToTypesUtils.GetMentionEncodedText("#conjurer")).Replace("%target%", "[[@"+(otherPosition + 1)+"]]"),false,txt);
        }
        static string DidKill(bool check){
            if(check){
                return ".";
            }
            return " but they survived. They must be a "+TypesToTypesUtils.GetMentionEncodedText("#neutral apocalypse")+"!";
        }
    }
        
}
