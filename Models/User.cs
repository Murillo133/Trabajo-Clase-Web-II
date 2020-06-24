using System.Text.Json.Serialization;

namespace clase_4.Models
{
  public class User
  {
    public long Id { get; set; }
    public string Email { get; set; }
    [JsonIgnore]
    public string Password { get; set; }
  }
}
