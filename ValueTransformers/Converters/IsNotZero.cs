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
    [ MarkupExtensionReturnType( typeof( IValueConverter ) ) ]
	[ ValueConversion( typeof( object ), typeof( bool ) ) ]
	public class IsNotZero: MarkupExtension, IValueConverter
	{
		public object Convert( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture )
        {
            if( value is char )
            {
                return ( char )value != 0;
            }

            if( value is sbyte )
            {
                return ( sbyte )value != 0;
            }

            if( value is byte )
            {
                return ( byte )value != 0;
            }

            if( value is short )
            {
                return ( short )value != 0;
            }

            if( value is ushort )
            {
                return ( ushort )value != 0;
            }

            if( value is int )
            {
                return ( int )value != 0;
            }

            if( value is uint )
            {
                return ( uint )value != 0;
            }

            if( value is long )
            {
                return ( long )value != 0;
            }

            if( value is ulong )
            {
                return ( ulong )value != 0;
            }

            if( value is float )
            {
                return ( float )value != 0.0f;
            }

            if( value is double )
            {
                return ( double )value != 0.0d;
            }

            if( value is decimal )
            {
                return ( decimal )value != 0;
            }

            throw new ArgumentException();
		}

		public object ConvertBack( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture )
		{
			throw new NotSupportedException();
		}

		private static IsNotZero Converter
        {
            get;
            set;
        }

		public override object ProvideValue( IServiceProvider serviceProvider )
		{
			if( Converter == null )
			{
                Converter = new IsNotZero();
			}

			return Converter;
		}
    }
}
