using Microsoft.ML.Data;

namespace MiProyecto_v1.Models
{
    public class SentimentData
    {
        [ColumnName("Col0")]
        public string Text { get; set; }
    }
}