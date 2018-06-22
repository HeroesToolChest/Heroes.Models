using System.ComponentModel;

namespace Heroes.Models
{
    public enum HeroDifficulty
    {
        Unknown,
        Easy,
        Medium,
        Hard,
        [Description("Very Hard")]
        VeryHard,
    }
}
