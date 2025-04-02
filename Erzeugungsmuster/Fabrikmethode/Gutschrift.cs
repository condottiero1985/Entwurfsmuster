namespace Erzeugungsmuster.Fabrikmethode;

public class Gutschrift : Dokument
{
    public decimal GutschriftBetrag { get; set; }

    public override bool IsValid()
    {
        return base.IsValid()
               && GutschriftBetrag > 0;
    }
}