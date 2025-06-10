using Newtonsoft.Json;

namespace Prenommer
{

    public class Class2
    {

        public class Fich
        {

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("charge")]
            public string Charge { get; set; }

            [JsonProperty("institute")]
            public string Institute { get; set; }

            [JsonProperty("celebration")]
            public string Celebration { get; set; }

            [JsonProperty("birth")]
            public string Birth { get; set; }

            [JsonProperty("death")]
            public string Death { get; set; }

            [JsonProperty("otherparties")]
            public string Otherparties { get; set; }

            [JsonProperty("othernames")]
            public string Othernames { get; set; }

            [JsonProperty("venerable")]
            public string Venerable { get; set; }

            [JsonProperty("beatified")]
            public string Beatified { get; set; }

            [JsonProperty("canonized")]
            public string Canonized { get; set; }

            [JsonProperty("heading")]
            public string Heading { get; set; }

            [JsonProperty("patron")]
            public string Patron { get; set; }

            [JsonProperty("link")]
            public string Link { get; set; }

            [JsonProperty("image")]
            public string Image { get; set; }

            [JsonProperty("biography")]
            public string Biography { get; set; }

            [JsonProperty("origin")]
            public string Origin { get; set; }

        }

        public class Prenommer
        {

            [JsonProperty("fiches")]
            public Fich[] Fiches { get; set; }

        }

    }
}