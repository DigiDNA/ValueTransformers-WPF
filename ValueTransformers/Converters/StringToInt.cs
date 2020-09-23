/*******************************************************************************
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
	[ValueConversion( typeof( object ), typeof( int ) )]
	public class StringToInt: MarkupExtension, IValueConverter
	{
		public object Convert( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture )
		{
			if( targetType == typeof( string ) )
			{
				return this.ConvertBack( value, targetType, parameter, culture );
			}

			if( targetType != typeof( int ) && targetType != typeof( int? ) )
			{
				throw new ArgumentException();
			}

			if( value is string str )
			{
				try
				{
					return int.Parse( str );
				}
				catch
				{}
			}

			return 0;
		}

		public object ConvertBack( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture )
		{
			if( targetType == typeof( int ) || targetType == typeof( int? ) )
			{
				return this.Convert( value, targetType, parameter, culture );
			}

			if( targetType != typeof( string ) )
			{
				throw new ArgumentException();
			}

			if( value is int i )
			{
				return i.ToString();
			}

			return "";
		}

		private static StringToInt Converter
		{
			get;
			set;
		}

		public override object ProvideValue( IServiceProvider serviceProvider )
		{
			if( Converter == null )
			{
				Converter = new StringToInt();
			}

			return Converter;
		}
	}
}
