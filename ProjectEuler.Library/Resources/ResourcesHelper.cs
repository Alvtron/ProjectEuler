﻿namespace ProjectEuler.Library.Resources
{
    internal static class ResourcesHelper
    {
        public static string GetResourcePath(string filePath)
        {
            return Path.Combine(Environment.CurrentDirectory, "Resources", filePath);
        }
    }
}