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
	public class MultipliedBy: MarkupExtension, IValueConverter
	{
		public object? Convert( object? value, Type targetType, object? parameter, System.Globalization.CultureInfo? culture )
		{
			if( value == null )
			{
				return null;
			}

            if( parameter == null )
            {
                parameter = 1;
            }

			double n = System.Convert.ToDouble( value ) * System.Convert.ToDouble( parameter );

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

		private static MultipliedBy? Converter
		{
			get;
			set;
		}

		public override object ProvideValue( IServiceProvider serviceProvider )
		{
			if( Converter == null )
			{
				Converter = new MultipliedBy();
			}

			return Converter;
		}
	}
}
