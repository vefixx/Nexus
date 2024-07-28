using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Helpers
{
    public class ImageHelper
    {
        public static Bitmap LoadFromResource(string resourcePath)
        {
            Uri resourceUri;
            if (!resourcePath.StartsWith("avares://"))
            {
                var assemblyName = Assembly.GetEntryAssembly()?.GetName().Name;
                resourceUri = new Uri($"avares://{assemblyName}/{resourcePath.TrimStart('/')}");
            }
            else
            {
                resourceUri = new Uri( resourcePath );
            }
            return new Bitmap(AssetLoader.Open( resourceUri ));

            

        }
    }
}
