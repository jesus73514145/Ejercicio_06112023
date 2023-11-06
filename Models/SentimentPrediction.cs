using Microsoft.ML.Data;

namespace MiProyecto_v1.Models
{
    public class SentimentPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool IsPositive { get; set; }
    }
}