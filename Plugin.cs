using SML;
using UnityEngine;
using HarmonyLib;
using Cinematics.Players;
using Server.Shared.Cinematics.Data;
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
        static public void Prefix(ICinematicData cinematic){
            DeputyKillCinematicData deputyKillCinematicData = cinematic as DeputyKillCinematicData;
			int deputyPosition = deputyKillCinematicData.deputyPosition;
			int otherPosition = deputyKillCinematicData.otherPosition;
            ChatUtils.AddMessage($"<color={ModSettings.GetString("Deputy Msg Color")}>"+ModSettings.GetString("Deputy Message").Replace("%deputy%", "[[@"+(deputyPosition + 1) + "]]").Replace("%deputyRole%", "[[#7]]").Replace("%target%", "[[@"+(otherPosition + 1)+"]]")+"</color>", "", false); //there are multiple styles you can use to paint the text however you want, but i want to give users the freedom to choose their text so im leaving it blank.
        }
        
        }

    [HarmonyPatch(typeof(ProsecutionCinematicPlayer), "Init")]
    class ProsecutionCinematicPlayer_Init_Patch{
        public static void Prefix(ICinematicData cinematic){
            ProsecutionCinematicData prosecutionCinematicData = cinematic as ProsecutionCinematicData;
			int prosecutorPosition = prosecutionCinematicData.prosecutorPostion;
			int otherPosition = prosecutionCinematicData.targetPosition;
            ChatUtils.AddMessage($"<color={ModSettings.GetString("Prosecutor Msg Color")}>"+ModSettings.GetString("Prosecutor Message").Replace("%prosecutor%", "[[@"+(prosecutorPosition + 1) + "]]").Replace("%prosecutorRole%","[[#13]]").Replace("%target%", "[[@"+(otherPosition + 1)+"]]")+"</color>", "", false);
        }
    }
    [HarmonyPatch(typeof(ConjurerKillCinematicPlayer), "Init")]
    class ConjurerKillCinematicPlayer_Init_Patch{
        public static void Prefix(ICinematicData cinematic){
            ConjurerKillCinematicData conjurerKillCinematicData = cinematic as ConjurerKillCinematicData;
			int otherPosition = conjurerKillCinematicData.otherPosition;
            ChatUtils.AddMessage($"<color={ModSettings.GetString("Conjurer Msg Color")}>"+ModSettings.GetString("Conjurer Message").Replace("%conjurerRole%","[[#25]]").Replace("%target%", "[[@"+(otherPosition + 1)+"]]")+"</color>", "", false);
        }
    }
        
}
