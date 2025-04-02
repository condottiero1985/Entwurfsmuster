namespace Erzeugungsmuster.Fabrikmethode;

public class RechnungFakturierer : Fakturierer
{
    public override Dokument ErzeugeDokument()
    {
        return new Rechnung();
    }
	
    public Rechnung ErzeugeRechnung(Rechnungstyp rechnungstyp)
    {
        switch (rechnungstyp)
        {
            case Rechnungstyp.Nachnahmerechnung:
                return new Nachnahmerechnung();
            case Rechnungstyp.Vorausrechnung:
                return new Vorausrechnung();
            case Rechnungstyp.Teilzahlungsrechnung:
                return new Teilzahlungsrechnung();
            default:
                return new Rechnung();
        }
    }
}