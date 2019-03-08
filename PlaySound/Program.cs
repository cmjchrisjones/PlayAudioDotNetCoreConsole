using NetCoreAudio;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PlaySound
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();

            Console.ReadKey();
        }

        public static async Task MainAsync(string[] args)
        {
            Console.WriteLine("Hello World!");
            try
            {
                var player = new Player();
                var soundClipGrenade = Directory.GetCurrentDirectory() + "\\grenade.wav";
                var soundClipZombieGroan = Directory.GetCurrentDirectory() + "\\zombie-groan.mp3";

                await PlaySound(player, soundClipGrenade);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        public static async Task PlaySound(Player player, string soundPath)
        {
            try
            {
                Console.WriteLine($"playing sound from: {soundPath}");
                await player.Play(soundPath);
                Console.WriteLine("sound should have been played");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}