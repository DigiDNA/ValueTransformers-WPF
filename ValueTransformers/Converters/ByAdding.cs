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
using System.Windows.Data;
using System.Windows.Markup;

namespace ValueTransformers
{
	[MarkupExtensionReturnType( typeof( IValueConverter ) )]
	[ValueConversion( typeof( object ), typeof( object ) )]
	public class ByAdding: MarkupExtension, IValueConverter
	{
		public object? Convert( object? value, Type targetType, object? parameter, System.Globalization.CultureInfo? culture )
		{
			if( value == null )
			{
				return null;
			}

            if( parameter == null )
            {
                parameter = 0;
            }

			double n = System.Convert.ToDouble( value ) + System.Convert.ToDouble( parameter );

			if( targetType == typeof( char ) )
            {
                return ( char )n;
            }

            if( targetType == typeof( sbyte ) )
            {
                return ( sbyte )n;
            }

            if( targetType == typeof( byte ) )
            {
                return ( byte )n;
			}

			if( targetType == typeof( short ) )
			{
				return ( short )n;
			}

			if( targetType == typeof( ushort ) )
			{
				return ( ushort )n;
			}

			if( targetType == typeof( int ) )
			{
				return ( int )n;
			}

			if( targetType == typeof( uint ) )
			{
				return ( uint )n;
			}

			if( targetType == typeof( long ) )
			{
				return ( long )n;
			}

			if( targetType == typeof( long ) )
			{
				return ( long )n;
			}

			if( targetType == typeof( float ) )
			{
				return ( float )n;
			}

			if( targetType == typeof( double ) )
			{
				return ( double )n;
			}

			if( targetType == typeof( decimal ) )
			{
				return ( decimal )n;
			}

			throw new ArgumentException( "Unsupported type", nameof( value ) );
		}

        public object? ConvertBack( object? value, Type targetType, object? parameter, System.Globalization.CultureInfo? culture )
		{
			throw new NotSupportedException();
		}

		private static ByAdding? Converter
		{
			get;
			set;
		}

		public override object ProvideValue( IServiceProvider serviceProvider )
		{
			if( Converter == null )
			{
				Converter = new ByAdding();
			}

			return Converter;
		}
	}
}
