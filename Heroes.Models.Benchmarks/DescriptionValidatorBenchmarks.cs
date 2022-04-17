namespace Heroes.Models.Benchmarks;

[MemoryDiagnoser]
public class DescriptionValidatorBenchmarks
{
    private readonly string _dvaMechSelfDestruct = "Eject from the Mech, setting it to self-destruct after <c val=\"#TooltipNumbers\">4</c> seconds. Deals <c val=\"#TooltipNumbers\">400</c> to <c val=\"#TooltipNumbers\">1200</c> damage in a large area, depending on distance from center. Only deals <c val=\"#TooltipNumbers\">50%</c> damage against Structures.</n></n><c val=\"FF8000\">Gain <c val=\"#TooltipNumbers\">1%</c> Charge for every <c val=\"#TooltipNumbers\">2</c> seconds spent Basic Attacking, and <c val=\"#TooltipNumbers\">30%</c> Charge per <c val=\"#TooltipNumbers\">100%</c> of Mech Health lost.</c>";

    public DescriptionValidatorBenchmarks()
    {
    }

    [Benchmark]
    public void Validate100()
    {
        for (int i = 0; i < 100; i++)
        {
            DescriptionValidator.Validate(_dvaMechSelfDestruct);
        }
    }

    [Benchmark]
    public void Validate1000()
    {
        for (int i = 0; i < 1000; i++)
        {
            DescriptionValidator.Validate(_dvaMechSelfDestruct);
        }
    }
}
