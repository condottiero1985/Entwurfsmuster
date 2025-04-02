namespace Erzeugungsmuster.Fabrikmethode;

public class GutschriftFakturierer : Fakturierer
{
    public override Dokument ErzeugeDokument()
    {
        return new Gutschrift();
    }
}