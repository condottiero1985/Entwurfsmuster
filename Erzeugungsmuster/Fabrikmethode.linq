<Query Kind="Program" />

void Main()
{

}

// You can define other methods, fields, classes and namespaces here
public abstract class Dokument
{
	public int Belegnummer { get; set; }
}

public class Rechnung : Dokument
{

}

public class Gutschrift : Dokument
{
	public decimal GutschriftBetrag { get; set; }
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
		if(!IsValid(dokument))
		{
			throw new ArgumentException("Das zu verarbeitende Dokument ist nicht gültig");
		}
	}
	
	public virtual bool IsValid(Dokument dokument)
	{
		if(dokument.Belegnummer == 0)
		{
			return false;
		}
		
		return true;
	}
}

public class GutschriftFakturierer : Fakturierer
{
	public override Dokument ErzeugeDokument()
	{
		return new Gutschrift();
	}
	
	public override bool IsValid(Dokument dokument)
	{
		return base.IsValid(dokument)
		&& ((Gutschrift)dokument).GutschriftBetrag > 0;
	}
}