namespace Erzeugungsmuster.Fabrikmethode;

public abstract class Fakturierer
{
    public abstract Dokument ErzeugeDokument();

    public void FakturiereDokument()
    {
        Dokument dokument = ErzeugeDokument();
		
        // ... arbeite mit dem Dokument
        if(!dokument.IsValid())
        {
            throw new ArgumentException("Das zu verarbeitende Dokument ist nicht gültig");
        }
    }
}