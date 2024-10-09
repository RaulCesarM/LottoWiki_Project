using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LottoWiki.Service.Utils
{
    public static class Serialization
    {
        public static string SerializeCorrelation(this int[] correl)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = false,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            string jsonString = JsonSerializer.Serialize(correl, options);
            return jsonString;
        }

        public static List<string> GetSerializedCorrelations(this Dictionary<int, int[]> correlations)
        {
            List<int[]> correlationValues = [.. correlations.Values];
            List<string> serializedCorrelations = [];

            foreach (var correl in correlationValues)
            {
                serializedCorrelations.Add(correl.SerializeCorrelation());
            }

            return serializedCorrelations;
        }

        public static string SerializeAllCorrelations(this Dictionary<int, int[]> correlations)
        {
            StringBuilder sb = new();
            sb.Append('[');
            sb.Append("\n");

            foreach (var keyValuePair in correlations)
            {
                sb.Append('[');
                sb.Append(string.Join(",", keyValuePair.Value.Select(x => x.ToString())));
                sb.Append(']');
                sb.Append(",\n");
            }

            if (correlations.Count > 0)
            {
                sb.Length -= 2;
            }
            sb.Append(",\n");
            sb.Append(']');

            return sb.ToString();
        }
    }
}