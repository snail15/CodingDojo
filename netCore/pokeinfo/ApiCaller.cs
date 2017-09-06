using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace pokeinfo
{
    public class WebRequest
    {
        // The second parameter is a function that returns a Dictionary of string keys to object values.
        // If an API returned an array as its top level collection the parameter type would be "Action>"
        public static async Task GetPokemonDataAsync(int PokeId, Action<Pokemon> Callback)
        {
            // Create a temporary HttpClient connection.
            using (var Client = new HttpClient())
            {
                try
                {
                    Client.BaseAddress = new Uri($"http://pokeapi.co/api/v2/pokemon/{PokeId}");
                    HttpResponseMessage Response = await Client.GetAsync(""); // Make the actual API call.
                    Response.EnsureSuccessStatusCode(); // Throw error if not successful.
                    string StringResponse = await Response.Content.ReadAsStringAsync(); // Read in the response as a string.

                    // Then parse the result into JSON and convert to a dictionary that we can use.
                    // DeserializeObject will only parse the top level object, depending on the API we may need to dig deeper and continue deserializing
                    // Dictionary<string, object> JsonResponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(StringResponse);

                    // Finally, execute our callback, passing it the response we got.
                    // Callback(JsonResponse);

                    JObject PokeObject = JsonConvert.DeserializeObject<JObject>(StringResponse);
                    
                    JArray TypeList = PokeObject["types"].Value<JArray>();

                    JObject SpriteList = PokeObject["sprites"].Value<JObject>();

                    List<string> Types = new List<string>();
                    List<string> Sprites = new List<string>();

                    foreach(KeyValuePair<string, Newtonsoft.Json.Linq.JToken> entry in SpriteList) {
                        if(entry.Value.ToString() != ""){
                            Sprites.Add(entry.Value.ToString());
                        }
                    }

                    foreach(JObject TypeObject in TypeList)
                    {
                        Types.Add(TypeObject["type"]["name"].Value<string>());
                    }

                    Pokemon PokeData = new Pokemon{
                        name = PokeObject["name"].Value<string>(),
                        weight = PokeObject["weight"].Value<int>(),
                        height = PokeObject["height"].Value<int>(),
                        types = Types,
                        sprites = Sprites

                    };
                     
                    // Finally, execute our callback, passing it the response we got.
                    Callback(PokeData);
                }
                catch (HttpRequestException e)
                {
                    // If something went wrong, display the error.
                    Console.WriteLine($"Request exception: {e.Message}");
                }
            }
        }
    }
}