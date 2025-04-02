<Query Kind="Program" />

void Main()
{

}

// You can define other methods, fields, classes and namespaces here
public abstract class Dokument
{
	public int Belegnummer { get; set; }
	
	public virtual bool IsValid()
	{
		return Belegnummer > 0;
	}
}

public class Rechnung : Dokument
{

}

public class Nachnahmerechnung : Rechnung { }

public class Vorausrechnung : Rechnung { }

public class Teilzahlungsrechnung : Rechnung { }

public enum Rechnungstyp
{
	Nachnahmerechnung,
	Vorausrechnung,
	Teilzahlungsrechnung
}

public class Gutschrift : Dokument
{
	public decimal GutschriftBetrag { get; set; }

	public override bool IsValid()
	{
		return base.IsValid()
		&& GutschriftBetrag > 0;
	}
}

public class Lieferschein : Dokument
{

}

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

public class GutschriftFakturierer : Fakturierer
{
	public override Dokument ErzeugeDokument()
	{
		return new Gutschrift();
	}
}

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