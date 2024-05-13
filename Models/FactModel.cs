using System.Text;

namespace netwise_task.Models
{
    public class FactModel
    {
        public string Fact { get; set; }
        public int Length { get; set; }
        

        public override string ToString()
        {
            return $"fact: {this.Fact} \nlength: {this.Length}";
        }
    }
}
