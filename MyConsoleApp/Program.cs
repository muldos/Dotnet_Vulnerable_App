using System;
using Newtonsoft.Json;

public class User
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Role { get; set; }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Example object
        User user = new User
        {
            Name = "Alice",
            Age = 30,
            Role = "Admin"
        };

        // Serialize the object to JSON
        string json = JsonConvert.SerializeObject(user);

        Console.WriteLine("Serialized JSON:");
        Console.WriteLine(json);

        // Deserialize the JSON back to an object
        try
        {
            User deserializedUser = JsonConvert.DeserializeObject<User>(json);

            Console.WriteLine("\nDeserialized Object:");
            Console.WriteLine($"Name: {deserializedUser.Name}, Age: {deserializedUser.Age}, Role: {deserializedUser.Role}");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"\nDeserialization error: {ex.Message}");
        }

        // Example with a safe JSON string.
        string safeJson = @"{
            ""Name"": ""Bob"",
            ""Age"": 25,
            ""Role"": ""User""
        }";

        try
        {
            // Deserialize with the safe JSON string.
            User safeObject = JsonConvert.DeserializeObject<User>(safeJson);

            Console.WriteLine("\nSafe deserialization successful.");
            Console.WriteLine($"Name: {safeObject.Name}, Age: {safeObject.Age}, Role: {safeObject.Role}");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"\nDeserialization error: {ex.Message}");
        }

    }
}