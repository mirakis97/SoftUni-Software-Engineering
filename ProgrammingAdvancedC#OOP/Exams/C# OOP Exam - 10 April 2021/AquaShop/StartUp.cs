namespace AquaShop
{
    using System;

    using AquaShop.Core;
    using AquaShop.Core.Contracts;
    using AquaShop.IO;
    using AquaShop.IO.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            //Don't forget to comment out the commented code lines in the Engine class!
            //IEngine engine = new Engine();
            //engine.Run();
            var sbWriter = new StringBuilderWriter();

            var engine = new Engine( );
            engine.Run();

            Console.WriteLine(sbWriter.sb.ToString().Trim());
        }
    }
}
