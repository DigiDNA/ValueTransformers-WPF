﻿/*******************************************************************************
 * Copyright (c) 2019, DigiDNA
 * All rights reserved
 * 
 * Unauthorised copying of this copyrighted work, via any medium is strictly
 * prohibited.
 * Proprietary and confidential.
 ******************************************************************************/

using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace ValueTransformers
{
	[MarkupExtensionReturnType( typeof( IValueConverter ) )]
	[ValueConversion( typeof( string ), typeof( string ) )]
	public class UppercaseString: MarkupExtension, IValueConverter
	{
		public object? Convert( object? value, Type targetType, object? parameter, System.Globalization.CultureInfo? culture )
		{
			if( targetType != typeof( string ) )
			{
				throw new ArgumentException( "Invalid target type", nameof( targetType ) );
			}

			if( value is string str )
			{
				return str.ToUpper();
			}

			return null;
		}

		public object ConvertBack( object? value, Type targetType, object? parameter, System.Globalization.CultureInfo? culture )
		{
			throw new NotSupportedException();
		}

		private static UppercaseString? Converter
		{
			get;
			set;
		}

		public override object ProvideValue( IServiceProvider serviceProvider )
		{
			if( Converter == null )
			{
				Converter = new UppercaseString();
			}

			return Converter;
		}
	}
}