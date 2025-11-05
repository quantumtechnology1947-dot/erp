using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

[CompilerGenerated]
internal sealed class App_Code240533_002E_003C_003Ef__AnonymousType0<_003Cy_003Ej__TPar>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _003Cy_003Ej__TPar _003Cy_003Ei__Field;

	public _003Cy_003Ej__TPar y => _003Cy_003Ei__Field;

	[DebuggerHidden]
	public App_Code240533_002E_003C_003Ef__AnonymousType0(_003Cy_003Ej__TPar y)
	{
		_003Cy_003Ei__Field = y;
	}

	[DebuggerHidden]
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("{ y = ");
		stringBuilder.Append(_003Cy_003Ei__Field);
		stringBuilder.Append(" }");
		return stringBuilder.ToString();
	}

	[DebuggerHidden]
	public override bool Equals(object value)
	{
		if (value is App_Code240533_002E_003C_003Ef__AnonymousType0<_003Cy_003Ej__TPar> anon)
		{
			return EqualityComparer<_003Cy_003Ej__TPar>.Default.Equals(_003Cy_003Ei__Field, anon._003Cy_003Ei__Field);
		}
		return false;
	}

	[DebuggerHidden]
	public override int GetHashCode()
	{
		int num = -1197777015;
		return -1521134295 * num + EqualityComparer<_003Cy_003Ej__TPar>.Default.GetHashCode(_003Cy_003Ei__Field);
	}
}
