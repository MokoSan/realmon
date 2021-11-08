﻿using System;
using System.IO;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace realmon.Configuration 
{
    internal static class ConfigurationReader
    {
        /// <summary>
        /// TODO:
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<Configuration> ReadConfiguration(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("Path to the Configuration file is null.");
            }

            IDeserializer deserialier = new DeserializerBuilder()
                                            .WithNamingConvention(UnderscoredNamingConvention.Instance)
                                            .Build();

            string configContents = await File.ReadAllTextAsync(path);
            Configuration configuration = deserialier.Deserialize<Configuration>(configContents);
            return await Task.FromResult(configuration);
        }
    }
}
