/*******************************************************************************
	* Copyright (c) 2019, DigiDNA
	* All rights reserved
	* 
	* Unauthorised copying of this copyrighted work, via any medium is strictly
	* prohibited.
	* Proprietary and confidential.
	******************************************************************************/

using System;
using System.Windows.Data;
using System.Windows.Markup;

namespace ValueTransformers
{
	[MarkupExtensionReturnType( typeof( IValueConverter ) )]
	[ValueConversion( typeof( object ), typeof( object ) )]
	public class DividedBy: MarkupExtension, IValueConverter
	{
		public object? Convert( object? value, Type targetType, object? parameter, System.Globalization.CultureInfo? culture )
		{
			if( parameter == null )
			{
				parameter = 1;
			}

			return new MultipliedBy().Convert( value, targetType, 1.0 / System.Convert.ToDouble( parameter ), culture );
		}

		public object? ConvertBack( object? value, Type targetType, object? parameter, System.Globalization.CultureInfo? culture )
		{
			throw new NotSupportedException();
		}

		private static DividedBy? Converter
		{
			get;
			set;
		}

		public override object ProvideValue( IServiceProvider serviceProvider )
		{
			if( Converter == null )
			{
				Converter = new DividedBy();
			}

			return Converter;
		}
	}
}
