using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

[CompilerGenerated]
internal sealed class App_Web_lixpenrb1186294_002E_003C_003Ef__AnonymousType3<_003Cy2_003Ej__TPar>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _003Cy2_003Ej__TPar _003Cy2_003Ei__Field;

	public _003Cy2_003Ej__TPar y2 => _003Cy2_003Ei__Field;

	[DebuggerHidden]
	public App_Web_lixpenrb1186294_002E_003C_003Ef__AnonymousType3(_003Cy2_003Ej__TPar y2)
	{
		_003Cy2_003Ei__Field = y2;
	}

	[DebuggerHidden]
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("{ y2 = ");
		stringBuilder.Append(_003Cy2_003Ei__Field);
		stringBuilder.Append(" }");
		return stringBuilder.ToString();
	}

	[DebuggerHidden]
	public override bool Equals(object value)
	{
		if (value is App_Web_lixpenrb1186294_002E_003C_003Ef__AnonymousType3<_003Cy2_003Ej__TPar> anon)
		{
			return EqualityComparer<_003Cy2_003Ej__TPar>.Default.Equals(_003Cy2_003Ei__Field, anon._003Cy2_003Ei__Field);
		}
		return false;
	}

	[DebuggerHidden]
	public override int GetHashCode()
	{
		int num = 1448858000;
		return -1521134295 * num + EqualityComparer<_003Cy2_003Ej__TPar>.Default.GetHashCode(_003Cy2_003Ei__Field);
	}
}
