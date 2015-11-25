using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using SharpDX;

namespace AddonTemplate
{
    public static class Program
    {
        // Set addon ChampName to Soraka
        // Enforces AddOn to work for her alone

        public const string ChampName = "Soraka";

        public static void Main(string[] args)
        {
            // Wait till the loading screen has passed
            Loading.OnLoadingComplete += OnLoadingComplete;
        }

        private static void OnLoadingComplete(EventArgs args)
        {
            // Verify the champion we made this addon for
            if (Player.Instance.ChampionName != ChampName)
            {
                // Champion is not the one we made this addon for,
                // therefore we return
                return;
            }

            // Initialize the classes that we need
            Config.Initialize();
            SpellManager.Initialize();
            ModeManager.Initialize();

            // Listen to events we need
            Drawing.OnDraw += OnDraw;
        }

        private static void OnDraw(EventArgs args)
        {
            // Draw Q range in Gold
            Circle.Draw(Color.Gold, SpellManager.Q.Range, Player.Instance.Position);

            //Circle.Draw(Color.Red, SpellManager.W.Range, Player.Instance.Position);
            
            // Draw E range in Blue
            Circle.Draw(Color.Blue, SpellManager.E.Range, Player.Instance.Position);
            
            //Circle.Draw(Color.Red, SpellManager.R.Range, Player.Instance.Position);
        }
    }
}
