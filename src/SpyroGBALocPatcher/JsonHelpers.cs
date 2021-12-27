﻿using System;
using System.IO;
using Newtonsoft.Json;

namespace SpyroGBALocPatcher;

/// <summary>
/// Helper methods for JSON
/// </summary>
public static class JsonHelpers
{
    /// <summary>
    /// Serializes an object to a file
    /// </summary>
    /// <typeparam name="T">The type of file to serialize</typeparam>
    /// <param name="obj">The object to serialize</param>
    /// <param name="filePath">The file to serialize to</param>
    /// <param name="converters">Optional converters to use</param>
    public static void SerializeToFile<T>(T obj, string filePath, params JsonConverter[] converters)
    {
        // Serialize to JSON
        var json = JsonConvert.SerializeObject(obj, Formatting.Indented);

        // Write to output
        File.WriteAllText(filePath, json);
    }

    /// <summary>
    /// Deserializes an object from a file
    /// </summary>
    /// <typeparam name="T">The type of object to deserialize</typeparam>
    /// <param name="filePath">The file to deserialize</param>
    /// <param name="converters">Optional converters to use</param>
    /// <returns>The deserialized object</returns>
    public static T DeserializeFromFile<T>(string filePath, params JsonConverter[] converters)
    {
        // Read the JSON
        var json = File.ReadAllText(filePath);

        // Return the deserialized object
        return JsonConvert.DeserializeObject<T>(json);
    }

    /// <summary>
    /// Deserializes an object from a file
    /// </summary>
    /// <param name="filePath">The file to deserialize</param>
    /// <param name="type">The type of object to deserialize</param>
    /// <param name="converters">Optional converters to use</param>
    /// <returns>The deserialized object</returns>
    public static object DeserializeFromFile(string filePath, Type type, params JsonConverter[] converters)
    {
        // Read the JSON
        var json = File.ReadAllText(filePath);

        // Return the deserialized object
        return JsonConvert.DeserializeObject(json, type);
    }
}