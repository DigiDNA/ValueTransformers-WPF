/*******************************************************************************
 * The MIT License (MIT)
 * 
 * Copyright (c) 2021 DigiDNA - www.imazing.com
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
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
