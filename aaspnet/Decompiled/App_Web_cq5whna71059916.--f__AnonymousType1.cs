using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

[CompilerGenerated]
internal sealed class App_Web_cq5whna71059916_002E_003C_003Ef__AnonymousType1<_003Cgrp_003Ej__TPar, _003Crow1_003Ej__TPar>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _003Cgrp_003Ej__TPar _003Cgrp_003Ei__Field;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _003Crow1_003Ej__TPar _003Crow1_003Ei__Field;

	public _003Cgrp_003Ej__TPar grp => _003Cgrp_003Ei__Field;

	public _003Crow1_003Ej__TPar row1 => _003Crow1_003Ei__Field;

	[DebuggerHidden]
	public App_Web_cq5whna71059916_002E_003C_003Ef__AnonymousType1(_003Cgrp_003Ej__TPar grp, _003Crow1_003Ej__TPar row1)
	{
		_003Cgrp_003Ei__Field = grp;
		_003Crow1_003Ei__Field = row1;
	}

	[DebuggerHidden]
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("{ grp = ");
		stringBuilder.Append(_003Cgrp_003Ei__Field);
		stringBuilder.Append(", row1 = ");
		stringBuilder.Append(_003Crow1_003Ei__Field);
		stringBuilder.Append(" }");
		return stringBuilder.ToString();
	}

	[DebuggerHidden]
	public override bool Equals(object value)
	{
		if (value is App_Web_cq5whna71059916_002E_003C_003Ef__AnonymousType1<_003Cgrp_003Ej__TPar, _003Crow1_003Ej__TPar> anon && EqualityComparer<_003Cgrp_003Ej__TPar>.Default.Equals(_003Cgrp_003Ei__Field, anon._003Cgrp_003Ei__Field))
		{
			return EqualityComparer<_003Crow1_003Ej__TPar>.Default.Equals(_003Crow1_003Ei__Field, anon._003Crow1_003Ei__Field);
		}
		return false;
	}

	[DebuggerHidden]
	public override int GetHashCode()
	{
		int num = -1952330959;
		num = -1521134295 * num + EqualityComparer<_003Cgrp_003Ej__TPar>.Default.GetHashCode(_003Cgrp_003Ei__Field);
		return -1521134295 * num + EqualityComparer<_003Crow1_003Ej__TPar>.Default.GetHashCode(_003Crow1_003Ei__Field);
	}
}
