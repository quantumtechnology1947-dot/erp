using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

[CompilerGenerated]
internal sealed class App_Web_lixpenrb1186294_002E_003C_003Ef__AnonymousType4<_003Cgrp2_003Ej__TPar, _003Crow2_003Ej__TPar>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _003Cgrp2_003Ej__TPar _003Cgrp2_003Ei__Field;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _003Crow2_003Ej__TPar _003Crow2_003Ei__Field;

	public _003Cgrp2_003Ej__TPar grp2 => _003Cgrp2_003Ei__Field;

	public _003Crow2_003Ej__TPar row2 => _003Crow2_003Ei__Field;

	[DebuggerHidden]
	public App_Web_lixpenrb1186294_002E_003C_003Ef__AnonymousType4(_003Cgrp2_003Ej__TPar grp2, _003Crow2_003Ej__TPar row2)
	{
		_003Cgrp2_003Ei__Field = grp2;
		_003Crow2_003Ei__Field = row2;
	}

	[DebuggerHidden]
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("{ grp2 = ");
		stringBuilder.Append(_003Cgrp2_003Ei__Field);
		stringBuilder.Append(", row2 = ");
		stringBuilder.Append(_003Crow2_003Ei__Field);
		stringBuilder.Append(" }");
		return stringBuilder.ToString();
	}

	[DebuggerHidden]
	public override bool Equals(object value)
	{
		if (value is App_Web_lixpenrb1186294_002E_003C_003Ef__AnonymousType4<_003Cgrp2_003Ej__TPar, _003Crow2_003Ej__TPar> anon && EqualityComparer<_003Cgrp2_003Ej__TPar>.Default.Equals(_003Cgrp2_003Ei__Field, anon._003Cgrp2_003Ei__Field))
		{
			return EqualityComparer<_003Crow2_003Ej__TPar>.Default.Equals(_003Crow2_003Ei__Field, anon._003Crow2_003Ei__Field);
		}
		return false;
	}

	[DebuggerHidden]
	public override int GetHashCode()
	{
		int num = 942712795;
		num = -1521134295 * num + EqualityComparer<_003Cgrp2_003Ej__TPar>.Default.GetHashCode(_003Cgrp2_003Ei__Field);
		return -1521134295 * num + EqualityComparer<_003Crow2_003Ej__TPar>.Default.GetHashCode(_003Crow2_003Ei__Field);
	}
}
