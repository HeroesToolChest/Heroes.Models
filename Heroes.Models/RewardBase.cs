namespace Heroes.Models;

/// <summary>
/// Contain the information for reward.
/// </summary>
public abstract class RewardBase : ExtractableBase<RewardBase>, IExtractable
{
    /// <summary>
    /// Gets or sets the earned description text.
    /// </summary>
    public TooltipDescription? Description { get; set; }

    /// <summary>
    /// Gets or sets the unearned description text.
    /// </summary>
    public TooltipDescription? DescriptionUnearned { get; set; }
}
